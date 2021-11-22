using Microsoft.EntityFrameworkCore.Migrations;

namespace FromDB.Migrations
{
    public partial class surname2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Persons",
                newName: "Surname2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname2",
                table: "Persons",
                newName: "Surname");
        }
    }
}
