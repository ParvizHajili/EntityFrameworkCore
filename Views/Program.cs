// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Reflection;

Console.WriteLine("Hello, World!");

ApplicationDbContext context = new();
#region Birinci addim view yaratma
/*
1)Boş migration yaradılır.
2)Migration içindəki up metodunda viewun create kodları və down metodunda isə drop kodları yazılmalıdır.
3)Migrate et
 */
#endregion

#region View Istifadesi
/*
 View EfCre uzerinden sorgulaya bilmek ucun view neticesini qarsilaya bilecek bir entity
 yaradilmasi ve bu entity tipinden dbset propertysi elave olunmasi lazimdir.
 */
#endregion

#region View ozellikler
/*
 1) Viewlarda primary key ola bilmez.Buna gore dbset hasnokey ile isarelenmelidir.
2)View neticesinde gelen datalar changetracker ile takib edilmir. uzerinde edilen deyişiklikleri Ef core 
db ye yansitmir.
 */

var personOrder = await context.PersonOrders.FirstAsync();

personOrder.Name = "Perviz";


#endregion

//var personOrders = await context.PersonOrders
//    .Where(p => p.Count > 10)
//    .ToListAsync();

Console.WriteLine(5);








public class Person
{
    public int PersonId { get; set; }
    public string Name { get; set; }

    public ICollection<Order> Orders { get; set; }
}
public class Order
{
    public int OrderId { get; set; }
    public int PersonId { get; set; }
    public string Description { get; set; }

    public Person Person { get; set; }
}
public class PersonOrder
{
    public string Name { get; set; }
    public int Count { get; set; }
}
class ApplicationDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<PersonOrder>()
            .ToView("vm_PersonOrders")
            .HasNoKey();

        modelBuilder.Entity<Person>()
            .HasMany(p => p.Orders)
            .WithOne(o => o.Person)
            .HasForeignKey(o => o.PersonId);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=EntityFrameworkCoreDb;Integrated Security=True");
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<PersonOrder> PersonOrders { get; set; }
}
