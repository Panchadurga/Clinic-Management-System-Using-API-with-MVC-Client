using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Migrations
{
    public partial class modifyclassdocschedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Schedule");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Doctor");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Schedule",
                newName: "Specialization");

            migrationBuilder.RenameColumn(
                name: "SelectSpeciality",
                table: "Schedule",
                newName: "AppointmentTime");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Doctor",
                newName: "VisitingHour");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specialization",
                table: "Schedule",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "AppointmentTime",
                table: "Schedule",
                newName: "SelectSpeciality");

            migrationBuilder.RenameColumn(
                name: "VisitingHour",
                table: "Doctor",
                newName: "StartTime");

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "Schedule",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
