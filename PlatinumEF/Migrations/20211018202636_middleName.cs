using Microsoft.EntityFrameworkCore.Migrations;

namespace PlatinumEF.Migrations
{
    public partial class middleName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "MiddleName",
            //    table: "Persons",
            //    type: "text",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "MiddleName",
            //    table: "Persons");
        }
    }
}
