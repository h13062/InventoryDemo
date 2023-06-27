using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryDemo.Infrastructure.Migrations
{
    public partial class updateentiredatabaseformaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecordMachines_Records_RecordPOnumber",
                table: "RecordMachines");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordMaterial_Records_RecordPOnumber",
                table: "RecordMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordOperators_Records_RecordPOnumber",
                table: "RecordOperators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordOperators",
                table: "RecordOperators");

            migrationBuilder.DropIndex(
                name: "IX_RecordOperators_OperatorId",
                table: "RecordOperators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordMaterial",
                table: "RecordMaterial");

            migrationBuilder.DropIndex(
                name: "IX_RecordMaterial_MaterialId",
                table: "RecordMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordMachines",
                table: "RecordMachines");

            migrationBuilder.DropIndex(
                name: "IX_RecordMachines_MachineId",
                table: "RecordMachines");

            migrationBuilder.RenameColumn(
                name: "RecordPOnumber",
                table: "RecordOperators",
                newName: "POnumber");

            migrationBuilder.RenameColumn(
                name: "RecordPOnumber",
                table: "RecordMaterial",
                newName: "POnumber");

            migrationBuilder.RenameColumn(
                name: "RecordPOnumber",
                table: "RecordMachines",
                newName: "POnumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordOperators",
                table: "RecordOperators",
                columns: new[] { "OperatorId", "POnumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordMaterial",
                table: "RecordMaterial",
                columns: new[] { "MaterialId", "POnumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordMachines",
                table: "RecordMachines",
                columns: new[] { "MachineId", "POnumber" });

            migrationBuilder.CreateIndex(
                name: "IX_RecordOperators_POnumber",
                table: "RecordOperators",
                column: "POnumber");

            migrationBuilder.CreateIndex(
                name: "IX_RecordMaterial_POnumber",
                table: "RecordMaterial",
                column: "POnumber");

            migrationBuilder.CreateIndex(
                name: "IX_RecordMachines_POnumber",
                table: "RecordMachines",
                column: "POnumber");

            migrationBuilder.AddForeignKey(
                name: "FK_RecordMachines_Records_POnumber",
                table: "RecordMachines",
                column: "POnumber",
                principalTable: "Records",
                principalColumn: "POnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordMaterial_Records_POnumber",
                table: "RecordMaterial",
                column: "POnumber",
                principalTable: "Records",
                principalColumn: "POnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordOperators_Records_POnumber",
                table: "RecordOperators",
                column: "POnumber",
                principalTable: "Records",
                principalColumn: "POnumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecordMachines_Records_POnumber",
                table: "RecordMachines");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordMaterial_Records_POnumber",
                table: "RecordMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordOperators_Records_POnumber",
                table: "RecordOperators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordOperators",
                table: "RecordOperators");

            migrationBuilder.DropIndex(
                name: "IX_RecordOperators_POnumber",
                table: "RecordOperators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordMaterial",
                table: "RecordMaterial");

            migrationBuilder.DropIndex(
                name: "IX_RecordMaterial_POnumber",
                table: "RecordMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordMachines",
                table: "RecordMachines");

            migrationBuilder.DropIndex(
                name: "IX_RecordMachines_POnumber",
                table: "RecordMachines");

            migrationBuilder.RenameColumn(
                name: "POnumber",
                table: "RecordOperators",
                newName: "RecordPOnumber");

            migrationBuilder.RenameColumn(
                name: "POnumber",
                table: "RecordMaterial",
                newName: "RecordPOnumber");

            migrationBuilder.RenameColumn(
                name: "POnumber",
                table: "RecordMachines",
                newName: "RecordPOnumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordOperators",
                table: "RecordOperators",
                columns: new[] { "RecordPOnumber", "OperatorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordMaterial",
                table: "RecordMaterial",
                columns: new[] { "RecordPOnumber", "MaterialId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordMachines",
                table: "RecordMachines",
                columns: new[] { "RecordPOnumber", "MachineId" });

            migrationBuilder.CreateIndex(
                name: "IX_RecordOperators_OperatorId",
                table: "RecordOperators",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordMaterial_MaterialId",
                table: "RecordMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordMachines_MachineId",
                table: "RecordMachines",
                column: "MachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecordMachines_Records_RecordPOnumber",
                table: "RecordMachines",
                column: "RecordPOnumber",
                principalTable: "Records",
                principalColumn: "POnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordMaterial_Records_RecordPOnumber",
                table: "RecordMaterial",
                column: "RecordPOnumber",
                principalTable: "Records",
                principalColumn: "POnumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordOperators_Records_RecordPOnumber",
                table: "RecordOperators",
                column: "RecordPOnumber",
                principalTable: "Records",
                principalColumn: "POnumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
