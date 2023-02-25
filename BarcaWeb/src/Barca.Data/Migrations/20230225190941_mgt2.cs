using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barca.Data.Migrations
{
    /// <inheritdoc />
    public partial class mgt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(4,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "DECIMAL(4,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
