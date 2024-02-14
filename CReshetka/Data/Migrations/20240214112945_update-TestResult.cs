using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CReshetka.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateTestResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "TestResult");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "TestResult",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
