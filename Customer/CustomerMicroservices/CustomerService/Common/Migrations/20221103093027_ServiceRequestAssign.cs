using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class ServiceRequestAssign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "ServiceRequestAssigns",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "ServiceRequestAssigns",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "ServiceRequestAssigns");

            migrationBuilder.DropColumn(
                name: "password",
                table: "ServiceRequestAssigns");
        }
    }
}
