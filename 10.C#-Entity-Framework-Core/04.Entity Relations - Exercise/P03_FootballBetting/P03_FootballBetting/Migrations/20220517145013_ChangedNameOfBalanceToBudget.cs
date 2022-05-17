using Microsoft.EntityFrameworkCore.Migrations;

namespace P03_FootballBetting.Migrations
{
    public partial class ChangedNameOfBalanceToBudget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Teams");

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Teams",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Teams");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Teams",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
