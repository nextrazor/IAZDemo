using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAZBackend.Models.ApsEntities.Migrations
{
    public partial class AdditionalAttrsForOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMilitary",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PartNo",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WorkGroup",
                table: "Orders",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMilitary",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PartNo",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "WorkGroup",
                table: "Orders");
        }
    }
}
