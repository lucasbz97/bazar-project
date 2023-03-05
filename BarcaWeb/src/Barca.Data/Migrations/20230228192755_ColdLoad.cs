using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barca.Data.Migrations
{
    /// <inheritdoc />
    public partial class ColdLoad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\Barca.Data\\ScriptSQL\\Products.sql");
            string command = File.ReadAllText(@sql);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
