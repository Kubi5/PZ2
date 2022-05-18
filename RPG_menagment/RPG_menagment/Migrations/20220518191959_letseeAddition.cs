using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG_menagment.Migrations
{
    public partial class letseeAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dragons_FightingCharacters_FightingCharacterID",
                table: "Dragons");

            migrationBuilder.DropForeignKey(
                name: "FK_Magicians_FightingCharacters_FightingCharacterID",
                table: "Magicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcs_FightingCharacters_FightingCharacterID",
                table: "Orcs");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_FightingCharacters_FightingCharacterID",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_Soldiers_FightingCharacterID",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_Orcs_FightingCharacterID",
                table: "Orcs");

            migrationBuilder.DropIndex(
                name: "IX_Magicians_FightingCharacterID",
                table: "Magicians");

            migrationBuilder.DropIndex(
                name: "IX_Dragons_FightingCharacterID",
                table: "Dragons");

            migrationBuilder.DropColumn(
                name: "FightingCharacterID",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "FightingCharacterID",
                table: "Orcs");

            migrationBuilder.DropColumn(
                name: "FightingCharacterID",
                table: "Magicians");

            migrationBuilder.DropColumn(
                name: "FightingCharacterID",
                table: "Dragons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FightingCharacterID",
                table: "Soldiers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FightingCharacterID",
                table: "Orcs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FightingCharacterID",
                table: "Magicians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FightingCharacterID",
                table: "Dragons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_FightingCharacterID",
                table: "Soldiers",
                column: "FightingCharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_Orcs_FightingCharacterID",
                table: "Orcs",
                column: "FightingCharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_Magicians_FightingCharacterID",
                table: "Magicians",
                column: "FightingCharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_Dragons_FightingCharacterID",
                table: "Dragons",
                column: "FightingCharacterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dragons_FightingCharacters_FightingCharacterID",
                table: "Dragons",
                column: "FightingCharacterID",
                principalTable: "FightingCharacters",
                principalColumn: "FightingCharacterID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Magicians_FightingCharacters_FightingCharacterID",
                table: "Magicians",
                column: "FightingCharacterID",
                principalTable: "FightingCharacters",
                principalColumn: "FightingCharacterID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcs_FightingCharacters_FightingCharacterID",
                table: "Orcs",
                column: "FightingCharacterID",
                principalTable: "FightingCharacters",
                principalColumn: "FightingCharacterID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_FightingCharacters_FightingCharacterID",
                table: "Soldiers",
                column: "FightingCharacterID",
                principalTable: "FightingCharacters",
                principalColumn: "FightingCharacterID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
