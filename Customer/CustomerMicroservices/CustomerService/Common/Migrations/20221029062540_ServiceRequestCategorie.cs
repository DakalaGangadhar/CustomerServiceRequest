using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class ServiceRequestCategorie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRequestCategorys");

            migrationBuilder.CreateTable(
                name: "ServiceRequestCategories",
                columns: table => new
                {
                    srcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequestCategories", x => x.srcId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRequestCategories");

            migrationBuilder.CreateTable(
                name: "ServiceRequestCategorys",
                columns: table => new
                {
                    srcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequestCategorys", x => x.srcId);
                });
        }
    }
}
