using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helm_Budget_System.Migrations.Helm_Budget_Db
{
    public partial class AddTravelModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TravelEntry",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetSectorID = table.Column<int>(type: "int", nullable: false),
                    YearID = table.Column<int>(type: "int", nullable: false),
                    TravelCategoryID = table.Column<int>(type: "int", nullable: false),
                    TravelStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TravelEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InState = table.Column<bool>(type: "bit", nullable: false),
                    IsConference = table.Column<bool>(type: "bit", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelEntry", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TravelMiscellaneousExpense",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelEntryID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalExpense = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelMiscellaneousExpense", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TravelMiscellaneousExpense_TravelEntry_TravelEntryID",
                        column: x => x.TravelEntryID,
                        principalTable: "TravelEntry",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelParty",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelEntryID = table.Column<int>(type: "int", nullable: false),
                    TravelerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelParty", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TravelParty_TravelEntry_TravelEntryID",
                        column: x => x.TravelEntryID,
                        principalTable: "TravelEntry",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelAirfare",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelPartyID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostPerPerson = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    BaggagePerPerson = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    BaggageCostTotal = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    AgentFee = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    AgentFeeTotal = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    IsCharter = table.Column<bool>(type: "bit", nullable: false),
                    TotalAirfareExpense = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAirfare", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TravelAirfare_TravelParty_TravelPartyID",
                        column: x => x.TravelPartyID,
                        principalTable: "TravelParty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelAuto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelPartyID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAuto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TravelAuto_TravelParty_TravelPartyID",
                        column: x => x.TravelPartyID,
                        principalTable: "TravelParty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelLodging",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelPartyID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nights = table.Column<int>(type: "int", nullable: false),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    RoomRate = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    TotalExpense = table.Column<decimal>(type: "decimal(12,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelLodging", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TravelLodging_TravelParty_TravelPartyID",
                        column: x => x.TravelPartyID,
                        principalTable: "TravelParty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelPerDiem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelPartyID = table.Column<int>(type: "int", nullable: false),
                    BreakfastDays = table.Column<int>(type: "int", nullable: false),
                    LunchDays = table.Column<int>(type: "int", nullable: false),
                    DinnerDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPerDiem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TravelPerDiem_TravelParty_TravelPartyID",
                        column: x => x.TravelPartyID,
                        principalTable: "TravelParty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelAirfare_TravelPartyID",
                table: "TravelAirfare",
                column: "TravelPartyID");

            migrationBuilder.CreateIndex(
                name: "IX_TravelAuto_TravelPartyID",
                table: "TravelAuto",
                column: "TravelPartyID");

            migrationBuilder.CreateIndex(
                name: "IX_TravelLodging_TravelPartyID",
                table: "TravelLodging",
                column: "TravelPartyID");

            migrationBuilder.CreateIndex(
                name: "IX_TravelMiscellaneousExpense_TravelEntryID",
                table: "TravelMiscellaneousExpense",
                column: "TravelEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_TravelParty_TravelEntryID",
                table: "TravelParty",
                column: "TravelEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPerDiem_TravelPartyID",
                table: "TravelPerDiem",
                column: "TravelPartyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelAirfare");

            migrationBuilder.DropTable(
                name: "TravelAuto");

            migrationBuilder.DropTable(
                name: "TravelCategory");

            migrationBuilder.DropTable(
                name: "TravelLodging");

            migrationBuilder.DropTable(
                name: "TravelMiscellaneousExpense");

            migrationBuilder.DropTable(
                name: "TravelPerDiem");

            migrationBuilder.DropTable(
                name: "TravelParty");

            migrationBuilder.DropTable(
                name: "TravelEntry");
        }
    }
}
