using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryDemo.Infrastructure.Migrations
{
    public partial class updateentiredatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Materials_MaterialId",
                table: "Records");

            migrationBuilder.DropTable(
                name: "MachineAndRecord");

            migrationBuilder.DropTable(
                name: "OperatorAndRecord");

            migrationBuilder.DropIndex(
                name: "IX_Records_MaterialId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Records");

            migrationBuilder.AlterColumn<string>(
                name: "LOTnumber",
                table: "Records",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "OperatorName",
                table: "Operators",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialName",
                table: "Materials",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "MachineName",
                table: "Machines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.CreateTable(
                name: "RecordMachines",
                columns: table => new
                {
                    RecordPOnumber = table.Column<int>(type: "int", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordMachines", x => new { x.RecordPOnumber, x.MachineId });
                    table.ForeignKey(
                        name: "FK_RecordMachines_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordMachines_Records_RecordPOnumber",
                        column: x => x.RecordPOnumber,
                        principalTable: "Records",
                        principalColumn: "POnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordMaterial",
                columns: table => new
                {
                    RecordPOnumber = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordMaterial", x => new { x.RecordPOnumber, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_RecordMaterial_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordMaterial_Records_RecordPOnumber",
                        column: x => x.RecordPOnumber,
                        principalTable: "Records",
                        principalColumn: "POnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordOperators",
                columns: table => new
                {
                    RecordPOnumber = table.Column<int>(type: "int", nullable: false),
                    OperatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordOperators", x => new { x.RecordPOnumber, x.OperatorId });
                    table.ForeignKey(
                        name: "FK_RecordOperators_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "OperatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecordOperators_Records_RecordPOnumber",
                        column: x => x.RecordPOnumber,
                        principalTable: "Records",
                        principalColumn: "POnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecordMachines_MachineId",
                table: "RecordMachines",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordMaterial_MaterialId",
                table: "RecordMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordOperators_OperatorId",
                table: "RecordOperators",
                column: "OperatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordMachines");

            migrationBuilder.DropTable(
                name: "RecordMaterial");

            migrationBuilder.DropTable(
                name: "RecordOperators");

            migrationBuilder.AlterColumn<string>(
                name: "LOTnumber",
                table: "Records",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "OperatorName",
                table: "Operators",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MaterialName",
                table: "Materials",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MachineName",
                table: "Machines",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "MachineAndRecord",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    RecordPOnumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAndRecord", x => new { x.MachineId, x.RecordPOnumber });
                    table.ForeignKey(
                        name: "FK_MachineAndRecord_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MachineAndRecord_Records_RecordPOnumber",
                        column: x => x.RecordPOnumber,
                        principalTable: "Records",
                        principalColumn: "POnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperatorAndRecord",
                columns: table => new
                {
                    OperatorId = table.Column<int>(type: "int", nullable: false),
                    RecordPOnumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorAndRecord", x => new { x.OperatorId, x.RecordPOnumber });
                    table.ForeignKey(
                        name: "FK_OperatorAndRecord_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "OperatorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatorAndRecord_Records_RecordPOnumber",
                        column: x => x.RecordPOnumber,
                        principalTable: "Records",
                        principalColumn: "POnumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_MaterialId",
                table: "Records",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAndRecord_RecordPOnumber",
                table: "MachineAndRecord",
                column: "RecordPOnumber");

            migrationBuilder.CreateIndex(
                name: "IX_OperatorAndRecord_RecordPOnumber",
                table: "OperatorAndRecord",
                column: "RecordPOnumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Materials_MaterialId",
                table: "Records",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
