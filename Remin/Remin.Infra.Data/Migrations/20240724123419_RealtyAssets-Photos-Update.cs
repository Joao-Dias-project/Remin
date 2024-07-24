using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Remin.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RealtyAssetsPhotosUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealtyAssets_Regions_RegionId",
                table: "RealtyAssets");

            migrationBuilder.DropTable(
                name: "MediaLines");

            migrationBuilder.AddColumn<int>(
                name: "RealtyAssetId",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_RealtyAssetId",
                table: "Photos",
                column: "RealtyAssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_RealtyAssets_RealtyAssetId",
                table: "Photos",
                column: "RealtyAssetId",
                principalTable: "RealtyAssets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyAssets_Regions_RegionId",
                table: "RealtyAssets",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_RealtyAssets_RealtyAssetId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyAssets_Regions_RegionId",
                table: "RealtyAssets");

            migrationBuilder.DropIndex(
                name: "IX_Photos_RealtyAssetId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "RealtyAssetId",
                table: "Photos");

            migrationBuilder.CreateTable(
                name: "MediaLines",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "int", nullable: false),
                    RealtyAssetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_MediaLines_Photos_PhotoId",
                        column: x => x.PhotoId,
                        principalTable: "Photos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaLines_RealtyAssets_RealtyAssetId",
                        column: x => x.RealtyAssetId,
                        principalTable: "RealtyAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MediaLines_PhotoId",
                table: "MediaLines",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaLines_RealtyAssetId",
                table: "MediaLines",
                column: "RealtyAssetId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyAssets_Regions_RegionId",
                table: "RealtyAssets",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
