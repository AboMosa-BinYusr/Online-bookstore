using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore1.Migrations
{
    public partial class removeUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MainComments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MainComments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
