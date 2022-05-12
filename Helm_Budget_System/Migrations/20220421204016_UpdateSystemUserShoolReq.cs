using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Helm_Budget_System.Migrations
{
    public partial class UpdateSystemUserShoolReq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_School_SchoolID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolID",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                defaultValue: 1);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_School_SchoolID",
                table: "AspNetUsers",
                column: "SchoolID",
                principalTable: "School",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_School_SchoolID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_School_SchoolID",
                table: "AspNetUsers",
                column: "SchoolID",
                principalTable: "School",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
