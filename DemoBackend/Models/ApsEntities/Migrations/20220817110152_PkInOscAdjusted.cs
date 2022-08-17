using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAZBackend.Models.ApsEntities.Migrations
{
    public partial class PkInOscAdjusted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderSecConstraints",
                table: "OrderSecConstraints");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "OrderSecConstraints",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderSecConstraints",
                table: "OrderSecConstraints",
                columns: new[] { "DatasetId", "OrderId", "SecConstraintId", "StartTime" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderSecConstraints",
                table: "OrderSecConstraints");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "OrderSecConstraints",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderSecConstraints",
                table: "OrderSecConstraints",
                columns: new[] { "DatasetId", "OrderId", "SecConstraintId" });
        }
    }
}
