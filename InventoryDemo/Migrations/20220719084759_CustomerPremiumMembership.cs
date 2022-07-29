using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryDemo.Migrations
{
    public partial class CustomerPremiumMembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PremiumMembership",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PremiumMembership",
                table: "Customer");
        }
    }
}
