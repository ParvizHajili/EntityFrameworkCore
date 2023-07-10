// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Linq;

Console.WriteLine("Hello World");
ExampleDbContontext context = new();
#region M1
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

#region Single and SingleOrDefault
/*Əgər sorğuda bizə yalnız 1 datanı gətirmək lazıdırsa bu zaman Single və ya SingleOrDefault istifadə
 edilə bilər. */
#region SingleAsync
//Sorğu nəticəsində birdən çox data gəlirsə və ya heç gəlmirsə hər iki variantda da exception atır.
#region One Record
//var product = await context.Products.SingleAsync(i=>i.Id==101);
#endregion
#region No Record
//var product = await context.Products.SingleAsync(i => i.Id == 2000);
//System.InvalidOperationException
#endregion
#region Many Records
//var product = await context.Products.SingleAsync(i => i.Id >100);
//System.InvalidOperationException
#endregion
#endregion

#region SingleOrDefault
//Sorğu nəticəsində birdən çox data gəlirsə exception atır.Heç gəlmirsə null qaytarır.
#region One Record
//var product = await context.Products.SingleOrDefaultAsync(i=>i.Id==101);
#endregion
#region No Record
//var product = await context.Products.SingleOrDefaultAsync(i=>i.Id==9999);
//System.NullReferenceException
#endregion
#region Many Records
//var product = await context.Products.SingleOrDefaultAsync(i => i.Id >= 50);
//System.InvalidOperationException
#endregion
#endregion
#endregion

#region First and FirstOrDefaultAsync
//Edilen sorguda tek bir datanin gelmeyi lazimdirsa first ve ya firstordefault istifade olunur.
#region First
//Sorgu neticesinde elde edilen datalardan ilkini getirir.Eger hec data gelmese exception atar.
#region One Record
//var product = context.Products.First(p => p.Id == 120);
#endregion
#region No Record
//var product = context.Products.First(p => p.Id == 12000);
//System.InvalidOperationException
#endregion
#region Many Records
//var product = context.Products.First(p => p.Id >110 && p.Id<500);
#endregion
#endregion

#region FirstOrDefault
//Sorgu neticeside elde olunan datalardan ilkini getirir. Eger ki data gelmese null qaytaracaq.
#region One Record
//var product = context.Products.FirstOrDefault(p => p.Id ==500);
#endregion
#region No Record
//var product = context.Products.FirstOrDefault(p => p.Id ==9999);
//null
#endregion
#region Many Records
//var product = context.Products.FirstOrDefault(p => p.Id > 110 && p.Id < 500);
#endregion
#endregion
#endregion

#region Find
//Find funksiyası primary key-ə görə sorğulama edir

//var product = context.Products.Find(50);
#region Composite Primary Key
//var product = context.ProductPieces.Find(4, 2);
#endregion
#endregion

#region Last
//gələn sorğudan sondakı datanı gətirir.
//var product = context.Products.OrderBy(i=>i.Name).Last(i => i.Id > 50);
#endregion
#region LastOrDefault
//var product = context.Products.OrderBy(i => i.Name).LastOrDefault(i => i.Id > 1);
#endregion
#endregion

#region M2

#region CountAsync
//Sorğu execute edilərkən neçə ədəd sətirin ələ ediləcəyi rəqəm olaraq(int) bizlərə bildirir.
//var productCount = await context.Products.CountAsync();
#endregion

#region LongCount
//Sorğu execute edilərkən neçə ədəd sətirin ələ ediləcəyi rəqəm olaraq(long) bizlərə bildirir.
//var productsCount = context.Products.LongCount();
//var productsCount = context.Products.LongCount(x=>x.Id<400);
#endregion

#region Any
//Sorğu nəticəsində datanın gəlib gəlmədiyini göstərir.(bool)
//var IsExist =await context.Products.AnyAsync();
#endregion

#region Max
//var price = context.Products.Max(p => p.Price);
#endregion

#region Distinct
//Sorğuda təkrar rekordlar  varsa bunları təkləşdirən bir əməliyyata sahibdir.
//var product = context.Products.Distinct().ToList();
#endregion

#region AllAssync
//bir sorgu neticesinde gelen datalarin verilen sertde olub olmadigini gosterir.True false qaytarir
//var product = await context.Products.AllAsync(i => i.Price > 1000);
#endregion

#region Sum
//Vermis oldugumuz reqemsal propertinin cemini hesablayir.
//var sum = context.Products.Sum(u => u.Price);
#endregion

#region AvarageAsync
//var avarage = await context.Products.AverageAsync(x=>x.Price);
#endregion

#region Contains
//Like sorgusu yaratmagimizi temin edir.
//var products = context.Products.Where(p => p.Name.Contains("P")).ToList();
#endregion
#endregion

#region M3
#region ToDictionary
/*sorgu neticesinde gelen datani bir dictionary olaraq elde etmek/tutmaq istesek istifade edilir.
 Tolist ile eyni meqsedde istifade olunur.Yeni yaradilan sorgu neticesinde datani execute
 edib neticeni aliriq
Tolist:Gelen sorgu neticesinde entity tipinde bir kolleksiona(List<TEntity>) cevirir
ToDictionary ise:Gelen sorgu neticesinde Dictionary tipinden bir kolleksiyaya cevirir.
 */
//var products = await context.Products.ToDictionaryAsync(x=>x.Name,x=>x.Price);
#endregion

#region ToArray
/*Yaradilan sorgunu massiv olaraq elde eder.
 * ToList ile eyni meqsedlidir.Yeni sorgu execute olunur ancaq gelen data massiv olaraq elde edilir.
 */

//var products = context.Products.ToArray();
#endregion

#region Select
/*
 Select funksiyasinin funksional birden cox davranisi var.
1)Select generate edilecek sorgunun getirilecek columnlari-nin tenzimlenmesini temin edir. 
 */
//var products = context.Products.Select(x =>new Product
//{
//    Id = x.Id,
//    Price = x.Price,
//}).ToList();

//var products = context.Products.Select(p => new ProductDetail
//{
//    Id = p.Id,
//    Price = p.Price
//});

#endregion

#region SelectMany
//Select ilə eyni məqsədidir.Əlaqəli tablelər nəticəsində gələn dataları təkləşdirmyimizi təmin edir.

//var products =context.Products.Include(p => p.Pieces).SelectMany(p => p.Pieces, (p, pc) => new
//{
//    p.Id,
//    p.Price,
//    pc.Name
//}).ToList();
#endregion
#endregion


#region GroupBy
#region Method Syntax
//var datas = context.Products.GroupBy(p => p.Price).Select(group => new
//{
//    Count = group.Count(),
//    Price = group.Key
//}).ToList();
#endregion
#region Query Syntax
//var datas = (from product in context.Products
//            group product by product.Price
//            into @group
//            select new
//            {
//                Price =@group.Key,
//                Count =@group.Count()
//            }).ToList();
#endregion
#endregion


Console.ReadLine();
public class ExampleDbContontext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = Localhost; Database = ExampleDb; Integrated Security = true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductPiece>().HasKey(i => new { i.ProductId, i.PieceId });
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Piece> Pieces { get; set; }
    public DbSet<ProductPiece> ProductPieces { get; set; }
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

public class ProductPiece
{
    public int ProductId { get; set; }
    public int PieceId { get; set; }
    public Product Product { get; set; }
    public Piece Piece { get; set; }
}

public class ProductDetail
{
    public int Id { get; set; }
    public float Price { get; set; }
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



#region One Record

#endregion
#region No Record

#endregion
#region Many Records

#endregion