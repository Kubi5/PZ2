using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG_menagment.Migrations
{
    public partial class addedUserNickname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nickname",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nickname",
                table: "Users");
        }
    }
}
