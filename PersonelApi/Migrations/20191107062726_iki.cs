using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonelApi.Migrations
{
    public partial class iki : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResimYol",
                table: "sehir",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResimYol",
                table: "sehir");
        }
    }
}
