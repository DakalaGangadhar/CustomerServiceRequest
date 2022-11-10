using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class Registration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    registrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    customername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pancard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contactnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cId = table.Column<int>(type: "int", nullable: false),
                    stateId = table.Column<int>(type: "int", nullable: false),
                    districtId = table.Column<int>(type: "int", nullable: false),
                    registrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.registrationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");
        }
    }
}
