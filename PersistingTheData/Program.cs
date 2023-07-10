// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");
#region SaveAsync
//ExampleDb exampleDb = new ExampleDb();
//Product product = new()
//{
//    Name = "Product 1",
//    Price = 100
//};

//Console.WriteLine(exampleDb.Entry(product).State);
//await exampleDb.AddAsync(product);
//Console.WriteLine(exampleDb.Entry(product).State);

//await exampleDb.SaveChangesAsync();

//await exampleDb.Products.AddAsync(product);
#endregion

#region AddRange
ExampleDb exampleDb = new ExampleDb();

//Product product = new()
//{
//    Name = "Product",
//    Price = 100
//};
//Product product1 = new()
//{
//    Name = "Product 2",
//    Price = 100
//};
//Product product2 = new()
//{
//    Name = "Product 2",
//    Price = 100
//};

//    exampleDb.AddRange(product,product1,product2);
//    exampleDb.SaveChanges();
#endregion
public class ExampleDb : DbContext
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
    public DateTime DateTime { get; set; }
}