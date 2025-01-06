using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poiect_cafea.Migrations
{
    /// <inheritdoc />
    public partial class CoffeeBlend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blend",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlendName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blend", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeBlend",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeeID = table.Column<int>(type: "int", nullable: false),
                    BlendID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeBlend", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CoffeeBlend_Blend_BlendID",
                        column: x => x.BlendID,
                        principalTable: "Blend",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeBlend_Coffee_CoffeeID",
                        column: x => x.CoffeeID,
                        principalTable: "Coffee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeBlend_BlendID",
                table: "CoffeeBlend",
                column: "BlendID");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeBlend_CoffeeID",
                table: "CoffeeBlend",
                column: "CoffeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeBlend");

            migrationBuilder.DropTable(
                name: "Blend");
        }
    }
}
