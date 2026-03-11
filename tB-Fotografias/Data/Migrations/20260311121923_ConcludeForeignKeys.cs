using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tB_Fotografias.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConcludeForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerFK",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryFK",
                table: "Photographies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PhotographyPurchase",
                columns: table => new
                {
                    ListofPhotosId = table.Column<int>(type: "int", nullable: false),
                    ListofPurchasesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotographyPurchase", x => new { x.ListofPhotosId, x.ListofPurchasesId });
                    table.ForeignKey(
                        name: "FK_PhotographyPurchase_Photographies_ListofPhotosId",
                        column: x => x.ListofPhotosId,
                        principalTable: "Photographies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotographyPurchase_Purchases_ListofPurchasesId",
                        column: x => x.ListofPurchasesId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_BuyerFK",
                table: "Purchases",
                column: "BuyerFK");

            migrationBuilder.CreateIndex(
                name: "IX_Photographies_CategoryFK",
                table: "Photographies",
                column: "CategoryFK");

            migrationBuilder.CreateIndex(
                name: "IX_PhotographyPurchase_ListofPurchasesId",
                table: "PhotographyPurchase",
                column: "ListofPurchasesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photographies_Categories_CategoryFK",
                table: "Photographies",
                column: "CategoryFK",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_MyUsers_BuyerFK",
                table: "Purchases",
                column: "BuyerFK",
                principalTable: "MyUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photographies_Categories_CategoryFK",
                table: "Photographies");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_MyUsers_BuyerFK",
                table: "Purchases");

            migrationBuilder.DropTable(
                name: "PhotographyPurchase");

            migrationBuilder.DropIndex(
                name: "IX_Purchases_BuyerFK",
                table: "Purchases");

            migrationBuilder.DropIndex(
                name: "IX_Photographies_CategoryFK",
                table: "Photographies");

            migrationBuilder.DropColumn(
                name: "BuyerFK",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CategoryFK",
                table: "Photographies");
        }
    }
}
