using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QrMenu.Migrations
{
    public partial class change1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "1");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
               name: "CategoryId",
               table: "Products");

        }
    }
}
