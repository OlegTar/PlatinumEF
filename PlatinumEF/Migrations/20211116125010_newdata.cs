using Microsoft.EntityFrameworkCore.Migrations;
using PlatinumEF.Entities;

namespace PlatinumEF.Migrations
{
    public partial class newdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .InsertData(
                           table: "Persons",
             columns: new[] { "Name", "Surname", nameof(Person.CurrentDepartmentId) },
             values: new object[] { "Oleg", "Tarusov", 1 });
            //migrationBuilder.InsertData(table: "Persons", )
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .DeleteData(table: "Person",
                keyColumn: nameof(Person.Name),
                keyValue: "Oleg");
        }
    }
}
