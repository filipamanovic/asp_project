using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_DataAccess.Migrations
{
    public partial class _ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarEquipmentAd",
                columns: table => new
                {
                    CarEquipmentId = table.Column<int>(nullable: false),
                    AdvertisementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarEquipmentAd", x => new { x.CarEquipmentId, x.AdvertisementId });
                    table.ForeignKey(
                        name: "FK_CarEquipmentAd_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarEquipmentAd_CarEquipments_CarEquipmentId",
                        column: x => x.CarEquipmentId,
                        principalTable: "CarEquipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarEquipmentAd_AdvertisementId",
                table: "CarEquipmentAd",
                column: "AdvertisementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarEquipmentAd");
        }
    }
}
