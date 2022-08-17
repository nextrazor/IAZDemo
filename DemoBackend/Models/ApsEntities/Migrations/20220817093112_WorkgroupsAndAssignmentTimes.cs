using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAZBackend.Models.ApsEntities.Migrations
{
    public partial class WorkgroupsAndAssignmentTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "OrderSecConstraints",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "OrderSecConstraints",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Workgroups",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsServiceGroup = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workgroups", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "SecConstraintWorkgroup",
                columns: table => new
                {
                    WorkersSecConstraintId = table.Column<int>(type: "int", nullable: false),
                    WorkgroupsNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecConstraintWorkgroup", x => new { x.WorkersSecConstraintId, x.WorkgroupsNumber });
                    table.ForeignKey(
                        name: "FK_SecConstraintWorkgroup_SecConstraints_WorkersSecConstraintId",
                        column: x => x.WorkersSecConstraintId,
                        principalTable: "SecConstraints",
                        principalColumn: "SecConstraintId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SecConstraintWorkgroup_Workgroups_WorkgroupsNumber",
                        column: x => x.WorkgroupsNumber,
                        principalTable: "Workgroups",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SecConstraintWorkgroup_WorkgroupsNumber",
                table: "SecConstraintWorkgroup",
                column: "WorkgroupsNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecConstraintWorkgroup");

            migrationBuilder.DropTable(
                name: "Workgroups");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "OrderSecConstraints");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "OrderSecConstraints");
        }
    }
}
