using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IAZBackend.Models.ApsEntities.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders_Dataset",
                columns: table => new
                {
                    DatasetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_Dataset", x => x.DatasetId);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    ResourceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FiniteOrInfinite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ResourceId);
                });

            migrationBuilder.CreateTable(
                name: "SecConstraints",
                columns: table => new
                {
                    SecConstraintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecConstraints", x => x.SecConstraintId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DatasetId = table.Column<int>(type: "int", nullable: false),
                    ResourceId = table.Column<int>(type: "int", nullable: true),
                    OrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    OpNo = table.Column<int>(type: "int", nullable: false),
                    OperationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MidBatchQuantity = table.Column<double>(type: "float", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => new { x.OrderId, x.DatasetId });
                    table.ForeignKey(
                        name: "FK_Orders_Orders_Dataset_DatasetId",
                        column: x => x.DatasetId,
                        principalTable: "Orders_Dataset",
                        principalColumn: "DatasetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "ResourceId");
                });

            migrationBuilder.CreateTable(
                name: "OrderLinks",
                columns: table => new
                {
                    DatasetId = table.Column<int>(type: "int", nullable: false),
                    FromOrderId = table.Column<int>(type: "int", nullable: false),
                    ToOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLinks", x => new { x.DatasetId, x.FromOrderId, x.ToOrderId });
                    table.ForeignKey(
                        name: "FK_OrderLinks_Orders_Dataset_DatasetId",
                        column: x => x.DatasetId,
                        principalTable: "Orders_Dataset",
                        principalColumn: "DatasetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLinks_Orders_FromOrderId_DatasetId",
                        columns: x => new { x.FromOrderId, x.DatasetId },
                        principalTable: "Orders",
                        principalColumns: new[] { "OrderId", "DatasetId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLinks_Orders_ToOrderId_DatasetId",
                        columns: x => new { x.ToOrderId, x.DatasetId },
                        principalTable: "Orders",
                        principalColumns: new[] { "OrderId", "DatasetId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderSecConstraints",
                columns: table => new
                {
                    DatasetId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    SecConstraintId = table.Column<int>(type: "int", nullable: false),
                    ConstraintUsage = table.Column<int>(type: "int", nullable: false),
                    ConstraintQuantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSecConstraints", x => new { x.DatasetId, x.OrderId, x.SecConstraintId });
                    table.ForeignKey(
                        name: "FK_OrderSecConstraints_Orders_Dataset_DatasetId",
                        column: x => x.DatasetId,
                        principalTable: "Orders_Dataset",
                        principalColumn: "DatasetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSecConstraints_Orders_OrderId_DatasetId",
                        columns: x => new { x.OrderId, x.DatasetId },
                        principalTable: "Orders",
                        principalColumns: new[] { "OrderId", "DatasetId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderSecConstraints_SecConstraints_SecConstraintId",
                        column: x => x.SecConstraintId,
                        principalTable: "SecConstraints",
                        principalColumn: "SecConstraintId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLinks_FromOrderId_DatasetId",
                table: "OrderLinks",
                columns: new[] { "FromOrderId", "DatasetId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLinks_ToOrderId_DatasetId",
                table: "OrderLinks",
                columns: new[] { "ToOrderId", "DatasetId" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DatasetId",
                table: "Orders",
                column: "DatasetId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ResourceId",
                table: "Orders",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSecConstraints_OrderId_DatasetId",
                table: "OrderSecConstraints",
                columns: new[] { "OrderId", "DatasetId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderSecConstraints_SecConstraintId",
                table: "OrderSecConstraints",
                column: "SecConstraintId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLinks");

            migrationBuilder.DropTable(
                name: "OrderSecConstraints");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "SecConstraints");

            migrationBuilder.DropTable(
                name: "Orders_Dataset");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
