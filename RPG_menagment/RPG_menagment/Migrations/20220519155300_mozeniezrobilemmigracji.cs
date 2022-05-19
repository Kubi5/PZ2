using Microsoft.EntityFrameworkCore.Migrations;

namespace RPG_menagment.Migrations
{
    public partial class mozeniezrobilemmigracji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrcTribe",
                table: "Orcs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrcTribe",
                table: "Orcs");
        }
    }
}
