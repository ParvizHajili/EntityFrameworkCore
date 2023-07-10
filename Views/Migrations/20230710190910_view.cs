using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Views.Migrations
{
    public partial class view : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"CREATE VIEW vm_PersonOrders
                                    AS
                                    select top 100 p.Name, COUNT(*) [Count] from Persons p
                                    inner join Orders o
                                    on p.PersonId=o.OrderId
                                    Group By p.Name
                                    Order By [COUNT] Desc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP VIEW vm_PersonOrders");
        }
    }
}
