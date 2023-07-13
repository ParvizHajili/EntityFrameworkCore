using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stored_Procedures.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"Create Procedure sp_PersonOrders 
                                    as
                                    select p.Name ,COUNT(*) [Count] from Persons p 
                                    join Orders o on p.PersonId=o.PersonId
                                    group by p.Name
                                    order by COUNT(*) desc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"DROP Proc sp_PersonOrders");
        }
    }
}
