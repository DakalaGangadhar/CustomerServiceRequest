using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class State : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    stateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.stateId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
