// See https://aka.ms/new-console-template for more information
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;
Console.WriteLine("Hello World");



//ExampleDbContext exampleDb = new();
//await exampleDb.Database.MigrateAsync();

public class ExampleDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = Localhost; Database = ExampleDb; Integrated Security = true;");
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
}