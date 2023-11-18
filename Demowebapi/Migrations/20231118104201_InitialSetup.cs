using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demowebapi.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    deptid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deptname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.deptid);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    empid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    empname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empsalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    deptid = table.Column<int>(type: "int", nullable: false),
                    Departmentdeptid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.empid);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_Departmentdeptid",
                        column: x => x.Departmentdeptid,
                        principalTable: "Departments",
                        principalColumn: "deptid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Departmentdeptid",
                table: "Employees",
                column: "Departmentdeptid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
