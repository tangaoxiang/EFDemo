using Microsoft.EntityFrameworkCore.Migrations;

namespace demo.Data.Migrations
{
    public partial class OneToOne2sql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "Players",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "Players");
        }
    }
}
