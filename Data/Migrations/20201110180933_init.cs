using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DogIM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fena = table.Column<bool>(nullable: false),
                    Rasa = table.Column<string>(nullable: false),
                    Jmeno = table.Column<string>(nullable: false),
                    Vek = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogIM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fena = table.Column<bool>(nullable: false),
                    Rasa = table.Column<string>(nullable: false),
                    Jmeno = table.Column<string>(nullable: false),
                    Vek = table.Column<int>(nullable: false),
                    MajitelId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_AspNetUsers_MajitelId",
                        column: x => x.MajitelId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_MajitelId",
                table: "Dogs",
                column: "MajitelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogIM");

            migrationBuilder.DropTable(
                name: "Dogs");
        }
    }
}
