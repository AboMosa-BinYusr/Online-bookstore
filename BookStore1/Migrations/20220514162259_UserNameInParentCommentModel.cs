using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore1.Migrations
{
    public partial class UserNameInParentCommentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SubComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SubComments");
        }
    }
}
