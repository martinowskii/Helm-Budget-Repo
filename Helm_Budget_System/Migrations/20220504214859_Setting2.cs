using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helm_Budget_System.Migrations.Helm_Budget_Db
{
    public partial class Setting2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetSector",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetSectorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetSector", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BudgetSector_School_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "School",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DescriptorDescription",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptorDescriptionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptorDescription", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExpenseCategory_School_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "School",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PayrollCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayrollCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolID = table.Column<int>(type: "int", nullable: false),
                    FringeBenefitRate = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    AnnualBenefitRate = table.Column<decimal>(type: "decimal(12,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PayrollCategory_School_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "School",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RevenueCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevenueCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RevenueCategory_School_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "School",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TransactionDescriptor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDescriptorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionDescriptor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransactionDescriptor_School_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "School",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelRateGroup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolID = table.Column<int>(type: "int", nullable: false),
                    MealPerDiemRate = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    CoachTravelRate = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    RecruitTravelRate = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelRateGroup", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TravelRateGroup_School_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "School",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DescriptorDesignation",
                columns: table => new
                {
                    DescriptorDesignationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionDescriptorID = table.Column<int>(type: "int", nullable: false),
                    DescriptorDescriptionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptorDesignation", x => x.DescriptorDesignationID);
                    table.ForeignKey(
                        name: "FK_DescriptorDesignation_DescriptorDescription_DescriptorDescriptionID",
                        column: x => x.DescriptorDescriptionID,
                        principalTable: "DescriptorDescription",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescriptorDesignation_TransactionDescriptor_TransactionDescriptorID",
                        column: x => x.TransactionDescriptorID,
                        principalTable: "TransactionDescriptor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetSector_SchoolID",
                table: "BudgetSector",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptorDesignation_DescriptorDescriptionID",
                table: "DescriptorDesignation",
                column: "DescriptorDescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptorDesignation_TransactionDescriptorID",
                table: "DescriptorDesignation",
                column: "TransactionDescriptorID");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategory_SchoolID",
                table: "ExpenseCategory",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_PayrollCategory_SchoolID",
                table: "PayrollCategory",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_RevenueCategory_SchoolID",
                table: "RevenueCategory",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionDescriptor_SchoolID",
                table: "TransactionDescriptor",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_TravelRateGroup_SchoolID",
                table: "TravelRateGroup",
                column: "SchoolID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetSector");

            migrationBuilder.DropTable(
                name: "DescriptorDesignation");

            migrationBuilder.DropTable(
                name: "ExpenseCategory");

            migrationBuilder.DropTable(
                name: "PayrollCategory");

            migrationBuilder.DropTable(
                name: "RevenueCategory");

            migrationBuilder.DropTable(
                name: "TravelRateGroup");

            migrationBuilder.DropTable(
                name: "DescriptorDescription");

            migrationBuilder.DropTable(
                name: "TransactionDescriptor");

        }
    }
}
