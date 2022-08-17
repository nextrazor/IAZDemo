using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAZBackend.Models.ApsEntities.Migrations
{
    public partial class ResourceGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResourceGroup",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResourceGroup",
                table: "Resources");
        }
    }
}
