using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAZBackend.Models.ApsEntities.Migrations
{
    public partial class TimeAttrsForOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BatchTime",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OpTimePerItem",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessTimeType",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatchTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OpTimePerItem",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProcessTimeType",
                table: "Orders");
        }
    }
}
