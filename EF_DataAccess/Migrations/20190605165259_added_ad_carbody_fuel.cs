using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_DataAccess.Migrations
{
    public partial class added_ad_carbody_fuel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_CarBody_CarBodyId",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Categories_CategoryId",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Fuel_FuelId",
                table: "Advertisement");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisement_Models_ModelId",
                table: "Advertisement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fuel",
                table: "Fuel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarBody",
                table: "CarBody");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advertisement",
                table: "Advertisement");

            migrationBuilder.RenameTable(
                name: "Fuel",
                newName: "Fuels");

            migrationBuilder.RenameTable(
                name: "CarBody",
                newName: "CarBodies");

            migrationBuilder.RenameTable(
                name: "Advertisement",
                newName: "Advertisements");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisement_ModelId",
                table: "Advertisements",
                newName: "IX_Advertisements_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisement_FuelId",
                table: "Advertisements",
                newName: "IX_Advertisements_FuelId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisement_CategoryId",
                table: "Advertisements",
                newName: "IX_Advertisements_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisement_CarBodyId",
                table: "Advertisements",
                newName: "IX_Advertisements_CarBodyId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Fuels",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Fuels",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CarBodies",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CarBodies",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "FuelId",
                table: "Advertisements",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Advertisements",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Advertisements",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdName",
                table: "Advertisements",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdDescription",
                table: "Advertisements",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fuels",
                table: "Fuels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarBodies",
                table: "CarBodies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advertisements",
                table: "Advertisements",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Fuels_Name",
                table: "Fuels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarBodies_Name",
                table: "CarBodies",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_CarBodies_CarBodyId",
                table: "Advertisements",
                column: "CarBodyId",
                principalTable: "CarBodies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Categories_CategoryId",
                table: "Advertisements",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Fuels_FuelId",
                table: "Advertisements",
                column: "FuelId",
                principalTable: "Fuels",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Models_ModelId",
                table: "Advertisements",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_CarBodies_CarBodyId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Categories_CategoryId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Fuels_FuelId",
                table: "Advertisements");

            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Models_ModelId",
                table: "Advertisements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fuels",
                table: "Fuels");

            migrationBuilder.DropIndex(
                name: "IX_Fuels_Name",
                table: "Fuels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarBodies",
                table: "CarBodies");

            migrationBuilder.DropIndex(
                name: "IX_CarBodies_Name",
                table: "CarBodies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Advertisements",
                table: "Advertisements");

            migrationBuilder.RenameTable(
                name: "Fuels",
                newName: "Fuel");

            migrationBuilder.RenameTable(
                name: "CarBodies",
                newName: "CarBody");

            migrationBuilder.RenameTable(
                name: "Advertisements",
                newName: "Advertisement");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisements_ModelId",
                table: "Advertisement",
                newName: "IX_Advertisement_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisements_FuelId",
                table: "Advertisement",
                newName: "IX_Advertisement_FuelId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisements_CategoryId",
                table: "Advertisement",
                newName: "IX_Advertisement_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Advertisements_CarBodyId",
                table: "Advertisement",
                newName: "IX_Advertisement_CarBodyId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Fuel",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Fuel",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CarBody",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "CarBody",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<int>(
                name: "FuelId",
                table: "Advertisement",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Advertisement",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Advertisement",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "AdName",
                table: "Advertisement",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AdDescription",
                table: "Advertisement",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fuel",
                table: "Fuel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarBody",
                table: "CarBody",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Advertisement",
                table: "Advertisement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_CarBody_CarBodyId",
                table: "Advertisement",
                column: "CarBodyId",
                principalTable: "CarBody",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Categories_CategoryId",
                table: "Advertisement",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Fuel_FuelId",
                table: "Advertisement",
                column: "FuelId",
                principalTable: "Fuel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisement_Models_ModelId",
                table: "Advertisement",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
