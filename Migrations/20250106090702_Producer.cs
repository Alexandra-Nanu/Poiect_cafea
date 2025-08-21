using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poiect_cafea.Migrations
{
    /// <inheritdoc />
    public partial class Producer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProducerID",
                table: "Coffee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coffee_ProducerID",
                table: "Coffee",
                column: "ProducerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Coffee_Producer_ProducerID",
                table: "Coffee",
                column: "ProducerID",
                principalTable: "Producer",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coffee_Producer_ProducerID",
                table: "Coffee");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropIndex(
                name: "IX_Coffee_ProducerID",
                table: "Coffee");

            migrationBuilder.DropColumn(
                name: "ProducerID",
                table: "Coffee");
        }
    }
}
