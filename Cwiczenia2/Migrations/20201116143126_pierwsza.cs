using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class pierwsza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kierownikZespolu",
                columns: table => new
                {
                    kierownikZespoluId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doswiadczenie = table.Column<int>(type: "int", nullable: false),
                    Imię = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PESEL1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pleć = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kierownikZespolu", x => x.kierownikZespoluId);
                });

            migrationBuilder.CreateTable(
                name: "zespolBaza",
                columns: table => new
                {
                    zespolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kierownikZespoluId = table.Column<int>(type: "int", nullable: true),
                    LiczbaCzłonków = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zespolBaza", x => x.zespolId);
                    table.ForeignKey(
                        name: "FK_zespolBaza_kierownikZespolu_kierownikZespoluId",
                        column: x => x.kierownikZespoluId,
                        principalTable: "kierownikZespolu",
                        principalColumn: "kierownikZespoluId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "czlonkowieZespolu",
                columns: table => new
                {
                    czlonekZespoluId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zespolId = table.Column<int>(type: "int", nullable: false),
                    zespolBazazespolId = table.Column<int>(type: "int", nullable: true),
                    DataZapisu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Funkcja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imię = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PESEL1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pleć = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_czlonkowieZespolu", x => x.czlonekZespoluId);
                    table.ForeignKey(
                        name: "FK_czlonkowieZespolu_zespolBaza_zespolBazazespolId",
                        column: x => x.zespolBazazespolId,
                        principalTable: "zespolBaza",
                        principalColumn: "zespolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_czlonkowieZespolu_zespolBazazespolId",
                table: "czlonkowieZespolu",
                column: "zespolBazazespolId");

            migrationBuilder.CreateIndex(
                name: "IX_zespolBaza_kierownikZespoluId",
                table: "zespolBaza",
                column: "kierownikZespoluId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "czlonkowieZespolu");

            migrationBuilder.DropTable(
                name: "zespolBaza");

            migrationBuilder.DropTable(
                name: "kierownikZespolu");
        }
    }
}
