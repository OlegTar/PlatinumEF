using Microsoft.EntityFrameworkCore.Migrations;

namespace PlatinumEF.Migrations
{
    public partial class data2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Age", "CurrentDepartmentId", "MiddleName", "Name", "Surname" },
                values: new object[,]
                {
                    { 8, null, 1, null, "Oleg1", "Tarusov" },
                    { 9, null, 1, null, "Vasya2", "Petrov" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Age", "CurrentDepartmentId", "MiddleName", "Name", "Surname" },
                values: new object[,]
                {
                    { 5, null, 1, null, "Oleg", "Tarusov" },
                    { 7, null, 1, null, "Vasya", "Petrov" }
                });
        }
    }
}
