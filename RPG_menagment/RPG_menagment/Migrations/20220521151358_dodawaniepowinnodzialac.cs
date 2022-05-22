using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG_menagment.Migrations
{
    public partial class dodawaniepowinnodzialac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Towers",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Towers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Length",
                table: "Rivers",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Rivers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Area",
                table: "Forests",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Forests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Area",
                table: "Caves",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Caves",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Towers_UserID",
                table: "Towers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Rivers_UserID",
                table: "Rivers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Forests_UserID",
                table: "Forests",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Caves_UserID",
                table: "Caves",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Caves_Users_UserID",
                table: "Caves",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forests_Users_UserID",
                table: "Forests",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rivers_Users_UserID",
                table: "Rivers",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Towers_Users_UserID",
                table: "Towers",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caves_Users_UserID",
                table: "Caves");

            migrationBuilder.DropForeignKey(
                name: "FK_Forests_Users_UserID",
                table: "Forests");

            migrationBuilder.DropForeignKey(
                name: "FK_Rivers_Users_UserID",
                table: "Rivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Towers_Users_UserID",
                table: "Towers");

            migrationBuilder.DropIndex(
                name: "IX_Towers_UserID",
                table: "Towers");

            migrationBuilder.DropIndex(
                name: "IX_Rivers_UserID",
                table: "Rivers");

            migrationBuilder.DropIndex(
                name: "IX_Forests_UserID",
                table: "Forests");

            migrationBuilder.DropIndex(
                name: "IX_Caves_UserID",
                table: "Caves");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Towers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Rivers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Forests");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Caves");

            migrationBuilder.AlterColumn<float>(
                name: "Height",
                table: "Towers",
                type: "real",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "Length",
                table: "Rivers",
                type: "real",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "Area",
                table: "Forests",
                type: "real",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "Area",
                table: "Caves",
                type: "real",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
