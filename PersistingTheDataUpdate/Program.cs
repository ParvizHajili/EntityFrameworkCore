// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

#region Update Data
//ExampleDbContext context = new();
//var product = await context.Products.FirstOrDefaultAsync(x => x.Id == 1549854);
//product.Name = "Updated Product";
//product.Price = 999;

//await context.SaveChangesAsync();

//Console.WriteLine(product?.Name);
#endregion

#region ChangeTracker
/*Changetracker context üzərindən gələn dataları izləyən bir mexanizmdir. Changetracker mexanizmi
 sayəsində context üzərindən gələn datalarla əlaqəli əməliyyatlar nəticəsində update və ya delete 
 sorğularının yaradılması başa düşülür.
 */
#endregion

#region  How to update the data which not following ChangeTracker

// Update istifadə etmək üçün mütləq İd dəyəri bildirilməlidir.
//ExampleDbContext exampleDb = new ExampleDbContext();

//Product product = new()
//{
//    Id = 1549855,
//    Name = "New Product",
//    Price = 3535,
//    DateTime = DateTime.UtcNow
//};
//exampleDb.Products.Update(product);
//await exampleDb.SaveChangesAsync();
#endregion

#region EntityState

//ExampleDbContext context = new ExampleDbContext();
//Product product = new();
//Console.WriteLine(context.Entry(product).State);
#endregion

#region 
//ExampleDbContext context = new();
//Product product = await context.Products.FirstOrDefaultAsync(x => x.Id == 1549856);
//Console.WriteLine(context.Entry(product).State);

//product.Name = "Test2";

//Console.WriteLine(context.Entry(product).State);

//await context.SaveChangesAsync();
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
    public DateTime DateTime { get; set; }= DateTime.Now;
}
