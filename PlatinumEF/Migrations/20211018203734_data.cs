using Microsoft.EntityFrameworkCore.Migrations;

namespace PlatinumEF.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.InsertData(
            //    table: "Departments",
            //    ////columns: new[] { "Id", "Name" },
            //    values: new object[,]
            //    {
            //        { 1, "Dep1" }
            //    }
            //);

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Age", "CurrentDepartmentId", "MiddleName", "Name", "Surname" },
                values: new object[,]
                {
                    { 5, null, 1, null, "Oleg", "Tarusov" },
                    { 7, null, 1, null, "Vasya", "Petrov" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
