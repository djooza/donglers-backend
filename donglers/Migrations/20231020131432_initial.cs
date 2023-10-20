using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace donglers.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.admin_id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    korisnik_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_student = table.Column<bool>(type: "bit", nullable: false),
                    datum_rodenja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    score = table.Column<int>(type: "int", nullable: false),
                    prihvacena_pravila = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    datum_kreiranja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.korisnik_id);
                });

            migrationBuilder.CreateTable(
                name: "Autentifikacija",
                columns: table => new
                {
                    autentifikacija_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnik_id = table.Column<int>(type: "int", nullable: false),
                    vrijednost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datum_autentifikcije = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autentifikacija", x => x.autentifikacija_id);
                    table.ForeignKey(
                        name: "FK_Autentifikacija_Korisnik_korisnik_id",
                        column: x => x.korisnik_id,
                        principalTable: "Korisnik",
                        principalColumn: "korisnik_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kurs",
                columns: table => new
                {
                    kurs_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datum_kreiranja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    kreator_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurs", x => x.kurs_id);
                    table.ForeignKey(
                        name: "FK_Kurs_Korisnik_kreator_id",
                        column: x => x.kreator_id,
                        principalTable: "Korisnik",
                        principalColumn: "korisnik_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poruka",
                columns: table => new
                {
                    poruka_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    posiljaoc_id = table.Column<int>(type: "int", nullable: false),
                    primaoc_id = table.Column<int>(type: "int", nullable: false),
                    naslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_pregledana = table.Column<bool>(type: "bit", nullable: false),
                    datum_slanja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poruka", x => x.poruka_id);
                    table.ForeignKey(
                        name: "FK_Poruka_Korisnik_posiljaoc_id",
                        column: x => x.posiljaoc_id,
                        principalTable: "Korisnik",
                        principalColumn: "korisnik_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Poruka_Korisnik_primaoc_id",
                        column: x => x.primaoc_id,
                        principalTable: "Korisnik",
                        principalColumn: "korisnik_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    level_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stepen = table.Column<int>(type: "int", nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    datum_kreiranja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    kreator_id = table.Column<int>(type: "int", nullable: false),
                    kurs_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.level_id);
                    table.ForeignKey(
                        name: "FK_Level_Korisnik_kreator_id",
                        column: x => x.kreator_id,
                        principalTable: "Korisnik",
                        principalColumn: "korisnik_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Level_Kurs_kurs_id",
                        column: x => x.kurs_id,
                        principalTable: "Kurs",
                        principalColumn: "kurs_id");
                });

            migrationBuilder.CreateTable(
                name: "Lekcija",
                columns: table => new
                {
                    lekcija_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    postavka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rjesenje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tezina = table.Column<int>(type: "int", nullable: false),
                    datum_kreiranja = table.Column<DateTime>(type: "datetime2", nullable: true),
                    kreator_id = table.Column<int>(type: "int", nullable: false),
                    level_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lekcija", x => x.lekcija_id);
                    table.ForeignKey(
                        name: "FK_Lekcija_Korisnik_kreator_id",
                        column: x => x.kreator_id,
                        principalTable: "Korisnik",
                        principalColumn: "korisnik_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lekcija_Level_level_id",
                        column: x => x.level_id,
                        principalTable: "Level",
                        principalColumn: "level_id");
                });

            migrationBuilder.CreateTable(
                name: "KorisnikLekcija",
                columns: table => new
                {
                    korisnik_lekcija_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnik_id = table.Column<int>(type: "int", nullable: false),
                    lekcija_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnikLekcija", x => x.korisnik_lekcija_id);
                    table.ForeignKey(
                        name: "FK_KorisnikLekcija_Korisnik_korisnik_id",
                        column: x => x.korisnik_id,
                        principalTable: "Korisnik",
                        principalColumn: "korisnik_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_KorisnikLekcija_Lekcija_lekcija_id",
                        column: x => x.lekcija_id,
                        principalTable: "Lekcija",
                        principalColumn: "lekcija_id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autentifikacija_korisnik_id",
                table: "Autentifikacija",
                column: "korisnik_id");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikLekcija_korisnik_id",
                table: "KorisnikLekcija",
                column: "korisnik_id");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikLekcija_lekcija_id",
                table: "KorisnikLekcija",
                column: "lekcija_id");

            migrationBuilder.CreateIndex(
                name: "IX_Kurs_kreator_id",
                table: "Kurs",
                column: "kreator_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lekcija_kreator_id",
                table: "Lekcija",
                column: "kreator_id");

            migrationBuilder.CreateIndex(
                name: "IX_Lekcija_level_id",
                table: "Lekcija",
                column: "level_id");

            migrationBuilder.CreateIndex(
                name: "IX_Level_kreator_id",
                table: "Level",
                column: "kreator_id");

            migrationBuilder.CreateIndex(
                name: "IX_Level_kurs_id",
                table: "Level",
                column: "kurs_id");

            migrationBuilder.CreateIndex(
                name: "IX_Poruka_posiljaoc_id",
                table: "Poruka",
                column: "posiljaoc_id");

            migrationBuilder.CreateIndex(
                name: "IX_Poruka_primaoc_id",
                table: "Poruka",
                column: "primaoc_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Autentifikacija");

            migrationBuilder.DropTable(
                name: "KorisnikLekcija");

            migrationBuilder.DropTable(
                name: "Poruka");

            migrationBuilder.DropTable(
                name: "Lekcija");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "Kurs");

            migrationBuilder.DropTable(
                name: "Korisnik");
        }
    }
}
