using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG_menagment.Migrations
{
    public partial class WorkingonMagician : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "magicianSpicies",
                table: "Magicians",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "magicianSpicies",
                table: "Magicians");
        }
    }
}
