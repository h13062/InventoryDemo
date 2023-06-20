using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryDemo.Infrastructure.Migrations
{
    public partial class addarelationshiptablebetweenoperatorsandmachine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachinesOperators_Machines_MachineId",
                table: "MachinesOperators");

            migrationBuilder.DropForeignKey(
                name: "FK_MachinesOperators_Operators_OperatorId",
                table: "MachinesOperators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MachinesOperators",
                table: "MachinesOperators");

            migrationBuilder.RenameTable(
                name: "MachinesOperators",
                newName: "OperatorAndMachine");

            migrationBuilder.RenameIndex(
                name: "IX_MachinesOperators_OperatorId",
                table: "OperatorAndMachine",
                newName: "IX_OperatorAndMachine_OperatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperatorAndMachine",
                table: "OperatorAndMachine",
                columns: new[] { "MachineId", "OperatorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorAndMachine_Machines_MachineId",
                table: "OperatorAndMachine",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperatorAndMachine_Operators_OperatorId",
                table: "OperatorAndMachine",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "OperatorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperatorAndMachine_Machines_MachineId",
                table: "OperatorAndMachine");

            migrationBuilder.DropForeignKey(
                name: "FK_OperatorAndMachine_Operators_OperatorId",
                table: "OperatorAndMachine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperatorAndMachine",
                table: "OperatorAndMachine");

            migrationBuilder.RenameTable(
                name: "OperatorAndMachine",
                newName: "MachinesOperators");

            migrationBuilder.RenameIndex(
                name: "IX_OperatorAndMachine_OperatorId",
                table: "MachinesOperators",
                newName: "IX_MachinesOperators_OperatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MachinesOperators",
                table: "MachinesOperators",
                columns: new[] { "MachineId", "OperatorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MachinesOperators_Machines_MachineId",
                table: "MachinesOperators",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachinesOperators_Operators_OperatorId",
                table: "MachinesOperators",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "OperatorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
