// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

ExampleDbContext context = new ();

#region ChangeTracker Property
/*İzlənilən obyektlərə əlçatımlıq təmin edir.Və lazım gəldikdə hər hansı əməliyyatları yerinə yeturməyimizi 
təmin edən bir propertdir*/
//Context sinfinin base sinfi olan DbContext sinfinin bir metodudur.

//var products = await context.Products.ToListAsync();
//products[6].Price = 900;
//context.Products.Remove(products[7]);

//var datas = context.ChangeTracker.Entries();
//await context.SaveChangesAsync();
//Console.WriteLine();

///22:14
#endregion

public class ExampleDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = Localhost; Database = ExampleDb; Integrated Security = true;");
    }
}
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
}
