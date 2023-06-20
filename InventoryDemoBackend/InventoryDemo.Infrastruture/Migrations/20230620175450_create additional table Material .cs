using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryDemo.Infrastructure.Migrations
{
    public partial class createadditionaltableMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineUsingInRecord_Machines_MachineId",
                table: "MachineUsingInRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineUsingInRecord_Records_RecordPOnumber",
                table: "MachineUsingInRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatorWorkInRecord_Operators_OperatorId",
                table: "OperatorWorkInRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatorWorkInRecord_Records_RecordPOnumber",
                table: "OperatorWorkInRecord");

            migrationBuilder.DropTable(
                name: "OperatorAndMachine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperatorWorkInRecord",
                table: "OperatorWorkInRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MachineUsingInRecord",
                table: "MachineUsingInRecord");

            migrationBuilder.DropColumn(
                name: "OperatorDatetime",
                table: "Operators");

            migrationBuilder.DropColumn(
                name: "OperatorInfo",
                table: "Operators");

            migrationBuilder.DropColumn(
                name: "MachineDescription",
                table: "Machines");

            migrationBuilder.RenameTable(
                name: "OperatorWorkInRecord",
                newName: "OperatorAndRecord");

            migrationBuilder.RenameTable(
                name: "MachineUsingInRecord",
                newName: "MachineAndRecord");

            migrationBuilder.RenameColumn(
                name: "ModifyDatetime",
                table: "Records",
                newName: "OrderDate");

            migrationBuilder.RenameIndex(
                name: "IX_OperatorWorkInRecord_RecordPOnumber",
                table: "OperatorAndRecord",
                newName: "IX_OperatorAndRecord_RecordPOnumber");

            migrationBuilder.RenameIndex(
                name: "IX_MachineUsingInRecord_RecordPOnumber",
                table: "MachineAndRecord",
                newName: "IX_MachineAndRecord_RecordPOnumber");

            migrationBuilder.AlterColumn<string>(
                name: "LOTnumber",
                table: "Records",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompleteDate",
                table: "Records",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Records",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperatorAndRecord",
                table: "OperatorAndRecord",
                columns: new[] { "OperatorId", "RecordPOnumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MachineAndRecord",
                table: "MachineAndRecord",
                columns: new[] { "MachineId", "RecordPOnumber" });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_MaterialId",
                table: "Records",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAndRecord_Machines_MachineId",
                table: "MachineAndRecord",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineAndRecord_Records_RecordPOnumber",
                table: "MachineAndRecord",
                column: "RecordPOnumber",
                principalTable: "Records",
                principalColumn: "POnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorAndRecord_Operators_OperatorId",
                table: "OperatorAndRecord",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "OperatorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorAndRecord_Records_RecordPOnumber",
                table: "OperatorAndRecord",
                column: "RecordPOnumber",
                principalTable: "Records",
                principalColumn: "POnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Materials_MaterialId",
                table: "Records",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineAndRecord_Machines_MachineId",
                table: "MachineAndRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineAndRecord_Records_RecordPOnumber",
                table: "MachineAndRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatorAndRecord_Operators_OperatorId",
                table: "OperatorAndRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatorAndRecord_Records_RecordPOnumber",
                table: "OperatorAndRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Materials_MaterialId",
                table: "Records");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Records_MaterialId",
                table: "Records");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperatorAndRecord",
                table: "OperatorAndRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MachineAndRecord",
                table: "MachineAndRecord");

            migrationBuilder.DropColumn(
                name: "CompleteDate",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Records");

            migrationBuilder.RenameTable(
                name: "OperatorAndRecord",
                newName: "OperatorWorkInRecord");

            migrationBuilder.RenameTable(
                name: "MachineAndRecord",
                newName: "MachineUsingInRecord");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Records",
                newName: "ModifyDatetime");

            migrationBuilder.RenameIndex(
                name: "IX_OperatorAndRecord_RecordPOnumber",
                table: "OperatorWorkInRecord",
                newName: "IX_OperatorWorkInRecord_RecordPOnumber");

            migrationBuilder.RenameIndex(
                name: "IX_MachineAndRecord_RecordPOnumber",
                table: "MachineUsingInRecord",
                newName: "IX_MachineUsingInRecord_RecordPOnumber");

            migrationBuilder.AlterColumn<int>(
                name: "LOTnumber",
                table: "Records",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<DateTime>(
                name: "OperatorDatetime",
                table: "Operators",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "OperatorInfo",
                table: "Operators",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MachineDescription",
                table: "Machines",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperatorWorkInRecord",
                table: "OperatorWorkInRecord",
                columns: new[] { "OperatorId", "RecordPOnumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MachineUsingInRecord",
                table: "MachineUsingInRecord",
                columns: new[] { "MachineId", "RecordPOnumber" });

            migrationBuilder.CreateTable(
                name: "OperatorAndMachine",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    OperatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorAndMachine", x => new { x.MachineId, x.OperatorId });
                    table.ForeignKey(
                        name: "FK_OperatorAndMachine_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatorAndMachine_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "OperatorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperatorAndMachine_OperatorId",
                table: "OperatorAndMachine",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineUsingInRecord_Machines_MachineId",
                table: "MachineUsingInRecord",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineUsingInRecord_Records_RecordPOnumber",
                table: "MachineUsingInRecord",
                column: "RecordPOnumber",
                principalTable: "Records",
                principalColumn: "POnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorWorkInRecord_Operators_OperatorId",
                table: "OperatorWorkInRecord",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "OperatorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorWorkInRecord_Records_RecordPOnumber",
                table: "OperatorWorkInRecord",
                column: "RecordPOnumber",
                principalTable: "Records",
                principalColumn: "POnumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
