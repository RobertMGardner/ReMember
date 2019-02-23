using Microsoft.EntityFrameworkCore.Migrations;

namespace ReMember.Migrations
{
    public partial class Added_Phone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemberPhoneNumber",
                table: "Member",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberPhoneNumber",
                table: "Member");
        }
    }
}
