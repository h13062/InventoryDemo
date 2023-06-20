using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryDemo.Infrastructure.Migrations
{
    public partial class refreshdatabasewithrecordtableonly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineandPart");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "JobCategories");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    PO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderNumber = table.Column<int>(type: "int", nullable: false),
                    operatorName = table.Column<string>(type: "varchar(100)", nullable: false),
                    operatorDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifytime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    machineName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LOTnumber = table.Column<int>(type: "int", nullable: false),
                    productCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.PO);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Record");

            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "varchar(1000)", nullable: false),
                    PartDescription = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategories", x => x.PartId);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    MachineDescription = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Name = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                });

            migrationBuilder.CreateTable(
                name: "MachineandPart",
                columns: table => new
                {
                    MachinesMachineId = table.Column<int>(type: "int", nullable: false),
                    PartsPartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineandPart", x => new { x.MachinesMachineId, x.PartsPartId });
                    table.ForeignKey(
                        name: "FK_MachineandPart_JobCategories_PartsPartId",
                        column: x => x.PartsPartId,
                        principalTable: "JobCategories",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineandPart_Machines_MachinesMachineId",
                        column: x => x.MachinesMachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachinesMachineId = table.Column<int>(type: "int", nullable: false),
                    PartsPartId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "varchar(1000)", nullable: false),
                    WarehouseName = table.Column<string>(type: "varchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                    table.ForeignKey(
                        name: "FK_Warehouses_JobCategories_PartsPartId",
                        column: x => x.PartsPartId,
                        principalTable: "JobCategories",
                        principalColumn: "PartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Warehouses_Machines_MachinesMachineId",
                        column: x => x.MachinesMachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachineandPart_PartsPartId",
                table: "MachineandPart",
                column: "PartsPartId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_MachinesMachineId",
                table: "Warehouses",
                column: "MachinesMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_PartsPartId",
                table: "Warehouses",
                column: "PartsPartId");
        }
    }
}
