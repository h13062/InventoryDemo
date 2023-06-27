using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryDemo.Infrastructure.Migrations
{
    public partial class updateentiredatabasetoregistermaterialDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecordMaterial_Materials_MaterialId",
                table: "RecordMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordMaterial_Records_POnumber",
                table: "RecordMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordMaterial",
                table: "RecordMaterial");

            migrationBuilder.RenameTable(
                name: "RecordMaterial",
                newName: "RecordMaterials");

            migrationBuilder.RenameIndex(
                name: "IX_RecordMaterial_POnumber",
                table: "RecordMaterials",
                newName: "IX_RecordMaterials_POnumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordMaterials",
                table: "RecordMaterials",
                columns: new[] { "MaterialId", "POnumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_RecordMaterials_Materials_MaterialId",
                table: "RecordMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordMaterials_Records_POnumber",
                table: "RecordMaterials",
                column: "POnumber",
                principalTable: "Records",
                principalColumn: "POnumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecordMaterials_Materials_MaterialId",
                table: "RecordMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_RecordMaterials_Records_POnumber",
                table: "RecordMaterials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecordMaterials",
                table: "RecordMaterials");

            migrationBuilder.RenameTable(
                name: "RecordMaterials",
                newName: "RecordMaterial");

            migrationBuilder.RenameIndex(
                name: "IX_RecordMaterials_POnumber",
                table: "RecordMaterial",
                newName: "IX_RecordMaterial_POnumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecordMaterial",
                table: "RecordMaterial",
                columns: new[] { "MaterialId", "POnumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_RecordMaterial_Materials_MaterialId",
                table: "RecordMaterial",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "MaterialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecordMaterial_Records_POnumber",
                table: "RecordMaterial",
                column: "POnumber",
                principalTable: "Records",
                principalColumn: "POnumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
