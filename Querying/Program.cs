// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello World");
ExampleDbContontext context = new();

#region Basic Query
#region Method syntax
//var products = await context.Products.ToListAsync();
#endregion
#region Query Syntax
//var products = await (from product in context.Products select product).ToListAsync();
#endregion
#endregion

#region IQueryable and IEnumerable difference
//IQueryable efcore ilə edilmiş olan sorğunun execute edilməmiş halını ifadə edir.
//IEnumerable isə execute olunmuş sorğunun datalarının İnmemorye yüklənmiş halını ifadə edir.

//var products = await (from product in context.Products select product).ToListAsync();
#endregion


#region Deferred Execution
//IQueryable sorğularinda əlaqəli kod yazıldığı yerdə tətiklənməz.Yəni kod yazıldığı yerdə sorğunu generate olunmaz.
//Execute olunmuş yerdə tətiklənir.

//int productId = 10;

//var products = from product in context.Products where product.Id > productId select product;

//productId = 70;
//foreach (var item in products)
//{
//    Console.WriteLine(item.Name);
//}

#endregion

#region Where
#region MethodSyntax
//var products = context.Products.Where(i => i.Name.StartsWith("a")).ToList(); //like query
//var products = context.Products.Where(i => i.Id >= 500).ToList();
//foreach (var product in products)
//{
//    Console.WriteLine(product.Name);
//}
#endregion
#region QuerySyntax
//var products = from product in context.Products
//               where product.Id >100 && product.Id<150
//               select product;
//foreach (var product in products)
//{
//    Console.WriteLine(product.Name);
//}
#endregion
#endregion

#region OrderBy
//sorğu üzərində sıralama etməyimizi təmin edir.(Ascending)
#region Method Syntax
//var products = context.Products.Where(x => x.Id > 700 || x.Name.EndsWith("2")).OrderBy(i=>i.Name);
//products.ToList();
#endregion
#region Query Syntax
//var products = from product in context.Products
//               where product.Id>500|| product.Name.EndsWith("2")
//               orderby product.Name
//               select product;
//products.ToList();
#endregion
#endregion

#region ThenBy
//orderyBy üzərində olan sorğuları fərqli columnlara da tətbiq etməyimizi təmin edir.(Ascending)

//var products = context.Products.Where(i => i.Id > 100 && i.Name.EndsWith("2"))
//    .OrderBy(i => i.Name)
//    .ThenBy(i => i.Price)
//    .ThenBy(i => i.Id).ToList();
//foreach (var product in products)
//{
//    Console.WriteLine(product.Name);
//}
#endregion

Console.ReadLine();
public class ExampleDbContontext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = Localhost; Database = ExampleDb; Integrated Security = true;");
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Piece> Pieces { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }

    public ICollection<Piece> Pieces { get; set; }
}
public class Piece
{
    public int Id { get; set; }
    public string Name { get; set; }
}


//for (int i = 0; i < 50; i++)
//{
//    Product product = new()
//    {
//        Name = "Product " + i,
//        Price = 100 + i
//    };
//    context.AddRange(product);
//}
//context.SaveChanges();

//for (int i = 0; i < 50; i++)
//{
//    Piece piece = new()
//    {
//        Name = "Piece " + i,
//    };
//    context.AddRange(piece);
//}
//context.SaveChanges();