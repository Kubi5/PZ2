using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG_menagment.Migrations
{
    public partial class smthngIsWorking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FighterID",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "FighterID",
                table: "Orcs");

            migrationBuilder.DropColumn(
                name: "FighterID",
                table: "Magicians");

            migrationBuilder.DropColumn(
                name: "FighterID",
                table: "Dragons");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Towers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "Towers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Swordname",
                table: "Soldiers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Soldiers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FightingCharacterID",
                table: "Soldiers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Soldiers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rivers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Orcs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FightingCharacterID",
                table: "Orcs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Orcs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Magicians",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FightingCharacterID",
                table: "Magicians",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Magicians",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Forests",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "FightingCharacters",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FightingCharacters",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dragons",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FightingCharacterID",
                table: "Dragons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Dragons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "dragonSpicies",
                table: "Dragons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Caves",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_FightingCharacterID",
                table: "Soldiers",
                column: "FightingCharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_UserID",
                table: "Soldiers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Orcs_FightingCharacterID",
                table: "Orcs",
                column: "FightingCharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_Orcs_UserID",
                table: "Orcs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Magicians_FightingCharacterID",
                table: "Magicians",
                column: "FightingCharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_Magicians_UserID",
                table: "Magicians",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Dragons_FightingCharacterID",
                table: "Dragons",
                column: "FightingCharacterID");

            migrationBuilder.CreateIndex(
                name: "IX_Dragons_UserID",
                table: "Dragons",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dragons_FightingCharacters_FightingCharacterID",
                table: "Dragons",
                column: "FightingCharacterID",
                principalTable: "FightingCharacters",
                principalColumn: "FightingCharacterID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dragons_Users_UserID",
                table: "Dragons",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Magicians_FightingCharacters_FightingCharacterID",
                table: "Magicians",
                column: "FightingCharacterID",
                principalTable: "FightingCharacters",
                principalColumn: "FightingCharacterID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Magicians_Users_UserID",
                table: "Magicians",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcs_FightingCharacters_FightingCharacterID",
                table: "Orcs",
                column: "FightingCharacterID",
                principalTable: "FightingCharacters",
                principalColumn: "FightingCharacterID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orcs_Users_UserID",
                table: "Orcs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_FightingCharacters_FightingCharacterID",
                table: "Soldiers",
                column: "FightingCharacterID",
                principalTable: "FightingCharacters",
                principalColumn: "FightingCharacterID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_Users_UserID",
                table: "Soldiers",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dragons_FightingCharacters_FightingCharacterID",
                table: "Dragons");

            migrationBuilder.DropForeignKey(
                name: "FK_Dragons_Users_UserID",
                table: "Dragons");

            migrationBuilder.DropForeignKey(
                name: "FK_Magicians_FightingCharacters_FightingCharacterID",
                table: "Magicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Magicians_Users_UserID",
                table: "Magicians");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcs_FightingCharacters_FightingCharacterID",
                table: "Orcs");

            migrationBuilder.DropForeignKey(
                name: "FK_Orcs_Users_UserID",
                table: "Orcs");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_FightingCharacters_FightingCharacterID",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_Users_UserID",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_Soldiers_FightingCharacterID",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_Soldiers_UserID",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_Orcs_FightingCharacterID",
                table: "Orcs");

            migrationBuilder.DropIndex(
                name: "IX_Orcs_UserID",
                table: "Orcs");

            migrationBuilder.DropIndex(
                name: "IX_Magicians_FightingCharacterID",
                table: "Magicians");

            migrationBuilder.DropIndex(
                name: "IX_Magicians_UserID",
                table: "Magicians");

            migrationBuilder.DropIndex(
                name: "IX_Dragons_FightingCharacterID",
                table: "Dragons");

            migrationBuilder.DropIndex(
                name: "IX_Dragons_UserID",
                table: "Dragons");

            migrationBuilder.DropColumn(
                name: "FightingCharacterID",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "FightingCharacterID",
                table: "Orcs");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Orcs");

            migrationBuilder.DropColumn(
                name: "FightingCharacterID",
                table: "Magicians");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Magicians");

            migrationBuilder.DropColumn(
                name: "FightingCharacterID",
                table: "Dragons");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Dragons");

            migrationBuilder.DropColumn(
                name: "dragonSpicies",
                table: "Dragons");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Towers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "Towers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Swordname",
                table: "Soldiers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Soldiers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "FighterID",
                table: "Soldiers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Rivers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Orcs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "FighterID",
                table: "Orcs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Magicians",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "FighterID",
                table: "Magicians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Forests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "FightingCharacters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FightingCharacters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dragons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "FighterID",
                table: "Dragons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Caves",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
