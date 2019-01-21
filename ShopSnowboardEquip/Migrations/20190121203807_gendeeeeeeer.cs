using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopSnowboardEquip.Migrations
{
    public partial class gendeeeeeeer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genders_Equipments_EquipmentId",
                table: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Genders_EquipmentId",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Genders");

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Equipments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_GenderId",
                table: "Equipments",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Genders_GenderId",
                table: "Equipments",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Genders_GenderId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_GenderId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Equipments");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Genders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Genders_EquipmentId",
                table: "Genders",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genders_Equipments_EquipmentId",
                table: "Genders",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
