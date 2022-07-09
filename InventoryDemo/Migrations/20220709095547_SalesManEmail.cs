using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryDemo.Migrations
{
    public partial class SalesManEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Salesman",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Salesman");
        }
    }
}
