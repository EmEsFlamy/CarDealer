using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektSR.Migrations
{
    /// <inheritdoc />
    public partial class addTotalPriceColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                table: "Payments",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Payments");
        }
    }
}
