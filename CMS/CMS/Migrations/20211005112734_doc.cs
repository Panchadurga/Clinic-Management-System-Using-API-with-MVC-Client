using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class doc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Doctor",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Doctor",
                newName: "EndTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Doctor",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Doctor",
                newName: "End");
        }
    }
}
