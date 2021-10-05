using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class modifyclspatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "age",
                table: "Patient",
                newName: "Age");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Age",
                table: "Patient",
                newName: "age");
        }
    }
}
