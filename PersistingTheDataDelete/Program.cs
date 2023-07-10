// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
Console.WriteLine("Hello, World!");
#region Delete
//ExampleDbContext context = new();
//var product = await context.Products.FirstOrDefaultAsync(x => x.Id == 1549858);
//context.Products.Remove(product);
//context.SaveChanges();
#endregion

#region Not Following ChangeTracker
//ExampleDbContext context = new();
//Product product = new()
//{
//    Id = 1549856
//};
//context.Products.Remove(product);
//context.SaveChanges();

#endregion

#region Delete with EntityState

//ExampleDbContext context = new();
//Product product = new() { Id = 1549859 };
//context.Entry(product).State = EntityState.Deleted;
//context.SaveChanges();
#endregion

#region RemoveRange
//ExampleDbContext context = new();
//List<Product> products = context.Products.Where(x => x.Id >= 1549860 && x.Id <= 1549874).ToList();
//context.Products.RemoveRange(products);
//context.SaveChanges();
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
    public DateTime DateTime { get; set; } = DateTime.Now;
}
