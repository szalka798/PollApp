using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollApp.DataAccess.Persistence.Migrations
{
    public partial class Poll3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionType",
                table: "Polls",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "Polls");
        }
    }
}
