using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demowebapi.Migrations
{
    public partial class InitialSetu1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_Departmentdeptid",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "Departmentdeptid",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_Departmentdeptid",
                table: "Employees",
                column: "Departmentdeptid",
                principalTable: "Departments",
                principalColumn: "deptid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_Departmentdeptid",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "Departmentdeptid",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_Departmentdeptid",
                table: "Employees",
                column: "Departmentdeptid",
                principalTable: "Departments",
                principalColumn: "deptid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
