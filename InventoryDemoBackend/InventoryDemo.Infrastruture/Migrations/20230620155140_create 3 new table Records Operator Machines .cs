using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryDemo.Infrastructure.Migrations
{
    public partial class create3newtableRecordsOperatorMachines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Record");

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MachineDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    OperatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatorName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OperatorInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OperatorDatetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.OperatorId);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    POnumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    ModifyDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LOTnumber = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.POnumber);
                });

            migrationBuilder.CreateTable(
                name: "MachinesOperators",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    OperatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachinesOperators", x => new { x.MachineId, x.OperatorId });
                    table.ForeignKey(
                        name: "FK_MachinesOperators_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachinesOperators_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "OperatorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MachineUsingInRecord",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    RecordPOnumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineUsingInRecord", x => new { x.MachineId, x.RecordPOnumber });
                    table.ForeignKey(
                        name: "FK_MachineUsingInRecord_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineUsingInRecord_Records_RecordPOnumber",
                        column: x => x.RecordPOnumber,
                        principalTable: "Records",
                        principalColumn: "POnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperatorWorkInRecord",
                columns: table => new
                {
                    OperatorId = table.Column<int>(type: "int", nullable: false),
                    RecordPOnumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorWorkInRecord", x => new { x.OperatorId, x.RecordPOnumber });
                    table.ForeignKey(
                        name: "FK_OperatorWorkInRecord_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "OperatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatorWorkInRecord_Records_RecordPOnumber",
                        column: x => x.RecordPOnumber,
                        principalTable: "Records",
                        principalColumn: "POnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MachinesOperators_OperatorId",
                table: "MachinesOperators",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineUsingInRecord_RecordPOnumber",
                table: "MachineUsingInRecord",
                column: "RecordPOnumber");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorWorkInRecord_RecordPOnumber",
                table: "OperatorWorkInRecord",
                column: "RecordPOnumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachinesOperators");

            migrationBuilder.DropTable(
                name: "MachineUsingInRecord");

            migrationBuilder.DropTable(
                name: "OperatorWorkInRecord");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    PO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOTnumber = table.Column<int>(type: "int", nullable: false),
                    machineName = table.Column<string>(type: "varchar(50)", nullable: false),
                    modifytime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    operatorDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    operatorName = table.Column<string>(type: "varchar(100)", nullable: false),
                    orderNumber = table.Column<int>(type: "int", nullable: false),
                    productCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.PO);
                });
        }
    }
}
