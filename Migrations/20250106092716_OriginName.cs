using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poiect_cafea.Migrations
{
    /// <inheritdoc />
    public partial class OriginName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Coffee");

            migrationBuilder.AddColumn<int>(
                name: "OriginID",
                table: "Coffee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Origin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origin", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coffee_OriginID",
                table: "Coffee",
                column: "OriginID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coffee_Origin_OriginID",
                table: "Coffee",
                column: "OriginID",
                principalTable: "Origin",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coffee_Origin_OriginID",
                table: "Coffee");

            migrationBuilder.DropTable(
                name: "Origin");

            migrationBuilder.DropIndex(
                name: "IX_Coffee_OriginID",
                table: "Coffee");

            migrationBuilder.DropColumn(
                name: "OriginID",
                table: "Coffee");

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Coffee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
