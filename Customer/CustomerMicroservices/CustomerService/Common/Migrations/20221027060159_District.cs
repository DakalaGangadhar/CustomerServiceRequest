using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class District : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    districtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    districtname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.districtId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Districts");
        }
    }
}
