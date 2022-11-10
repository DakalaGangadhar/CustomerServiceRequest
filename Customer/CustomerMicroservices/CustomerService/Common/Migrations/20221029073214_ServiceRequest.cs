using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class ServiceRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createrequestdate",
                table: "ServiceRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createrequestdate",
                table: "ServiceRequests");
        }
    }
}
