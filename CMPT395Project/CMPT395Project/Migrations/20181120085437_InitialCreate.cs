using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMPT395Project.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Contractor",
                columns: table => new
                {
                    ContractorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.ContractorId);
                    table.ForeignKey(
                        name: "ForeignKey_Contractor_Company",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    ContractId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    P1CharRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    P1PayRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    P1StartDate = table.Column<DateTime>(nullable: false),
                    P1EndtDate = table.Column<DateTime>(nullable: false),
                    P2CharRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    P2PayRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    P2StartDate = table.Column<DateTime>(nullable: false),
                    P2EndtDate = table.Column<DateTime>(nullable: false),
                    P3CharRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    P3PayRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    P3StartDate = table.Column<DateTime>(nullable: false),
                    P3EndtDate = table.Column<DateTime>(nullable: false),
                    P4CharRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    P4PayRate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    P4StartDate = table.Column<DateTime>(nullable: false),
                    P4EndtDate = table.Column<DateTime>(nullable: false),
                    Renewal = table.Column<string>(nullable: true),
                    ActiveContract = table.Column<string>(nullable: false),
                    ContractorId = table.Column<int>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.ContractId);
                    table.ForeignKey(
                        name: "FK_Contract_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contract_Contractor_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractor",
                        principalColumn: "ContractorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeHour",
                columns: table => new
                {
                    TimeSheetId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    CurrentMonth = table.Column<int>(nullable: false),
                    PreviousMonth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHour", x => x.TimeSheetId);
                    table.ForeignKey(
                        name: "ForeignKey_EmployeeHours_Contract",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "ContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_CompanyId",
                table: "Contract",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ContractorId",
                table: "Contract",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_CompanyId",
                table: "Contractor",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHour_ContractId",
                table: "EmployeeHour",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeHour");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Contractor");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
