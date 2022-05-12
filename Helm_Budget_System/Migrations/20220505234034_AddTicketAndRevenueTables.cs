using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helm_Budget_System.Migrations.Helm_Budget_Db
{
    public partial class AddTicketAndRevenueTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Revenue",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevenueDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevenueComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevenueQuantity = table.Column<int>(type: "int", nullable: false),
                    RevenueRate = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    OtherRevenue = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    BudgetSectorID = table.Column<int>(type: "int", nullable: false),
                    RevenueCategoryID = table.Column<int>(type: "int", nullable: false),
                    DescriptorDescriptionID = table.Column<int>(type: "int", nullable: false),
                    SchoolID = table.Column<int>(type: "int", nullable: false),
                    YearID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenue", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Revenue_BudgetSector_BudgetSectorID",
                        column: x => x.BudgetSectorID,
                        principalTable: "BudgetSector",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Revenue_DescriptorDescription_DescriptorDescriptionID",
                        column: x => x.DescriptorDescriptionID,
                        principalTable: "DescriptorDescription",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Revenue_RevenueCategory_RevenueCategoryID",
                        column: x => x.RevenueCategoryID,
                        principalTable: "RevenueCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Revenue_School_SchoolID",
                        column: x => x.SchoolID,
                        principalTable: "School",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Revenue_Year_YearID",
                        column: x => x.YearID,
                        principalTable: "Year",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolID = table.Column<int>(type: "int", nullable: false),
                    TicketType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TicketPrice = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TicketName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Revenue_BudgetSectorID",
                table: "Revenue",
                column: "BudgetSectorID");

            migrationBuilder.CreateIndex(
                name: "IX_Revenue_DescriptorDescriptionID",
                table: "Revenue",
                column: "DescriptorDescriptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Revenue_RevenueCategoryID",
                table: "Revenue",
                column: "RevenueCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Revenue_SchoolID",
                table: "Revenue",
                column: "SchoolID");

            migrationBuilder.CreateIndex(
                name: "IX_Revenue_YearID",
                table: "Revenue",
                column: "YearID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Revenue");

            migrationBuilder.DropTable(
                name: "Ticket");
        }
    }
}
