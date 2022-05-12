using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helm_Budget_System.Migrations
{
    public partial class UserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemAdmin = table.Column<bool>(type: "bit", nullable: false),
                    PrimarySchoolAdmin = table.Column<bool>(type: "bit", nullable: false),
                    SchoolAdmin = table.Column<bool>(type: "bit", nullable: false),
                    SchoolUser = table.Column<bool>(type: "bit", nullable: false),
                    ReadOnlyUser = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
