using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonelApi.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "egitim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_egitim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sehir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sehir", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "personel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    SehirId = table.Column<int>(nullable: false),
                    EgitimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personel_egitim_EgitimId",
                        column: x => x.EgitimId,
                        principalTable: "egitim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_personel_sehir_SehirId",
                        column: x => x.SehirId,
                        principalTable: "sehir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personel_EgitimId",
                table: "personel",
                column: "EgitimId");

            migrationBuilder.CreateIndex(
                name: "IX_personel_SehirId",
                table: "personel",
                column: "SehirId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personel");

            migrationBuilder.DropTable(
                name: "egitim");

            migrationBuilder.DropTable(
                name: "sehir");
        }
    }
}
