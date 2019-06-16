using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_DataAccess.Migrations
{
    public partial class fixed_image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "Images",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AdvertisementId",
                table: "Images",
                column: "AdvertisementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Advertisements_AdvertisementId",
                table: "Images",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Advertisements_AdvertisementId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_AdvertisementId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "Images");
        }
    }
}
