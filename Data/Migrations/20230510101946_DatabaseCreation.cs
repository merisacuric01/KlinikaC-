using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace klinika.Data.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Odeljenja",
                columns: table => new
                {
                    OdeljenjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odeljenja", x => x.OdeljenjeID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pacijenti",
                columns: table => new
                {
                    PacijentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prezime = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Istorija = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijenti", x => x.PacijentID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Doktori",
                columns: table => new
                {
                    DoktorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ime = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prezime = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kontact = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OdeljenjeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktori", x => x.DoktorID);
                    table.ForeignKey(
                        name: "FK_Doktori_Odeljenja_OdeljenjeID",
                        column: x => x.OdeljenjeID,
                        principalTable: "Odeljenja",
                        principalColumn: "OdeljenjeID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pregledi",
                columns: table => new
                {
                    PregledID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StatusPregleda = table.Column<int>(type: "int", nullable: false),
                    DoktorID = table.Column<int>(type: "int", nullable: false),
                    Dijagnoza = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PacijentID = table.Column<int>(type: "int", nullable: false),
                    CenaPregleda = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregledi", x => x.PregledID);
                    table.ForeignKey(
                        name: "FK_Pregledi_Doktori_DoktorID",
                        column: x => x.DoktorID,
                        principalTable: "Doktori",
                        principalColumn: "DoktorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pregledi_Pacijenti_PacijentID",
                        column: x => x.PacijentID,
                        principalTable: "Pacijenti",
                        principalColumn: "PacijentID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Odeljenja",
                columns: new[] { "OdeljenjeID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Hirurg" },
                    { 2, "Decije" }
                });

            migrationBuilder.InsertData(
                table: "Doktori",
                columns: new[] { "DoktorID", "Ime", "Kontact", "OdeljenjeID", "Prezime" },
                values: new object[,]
                {
                    { 1, "Jasmina", "0641458792", 1, "Zupic" },
                    { 2, "Kimeta", "0641665892", 2, "Lukic" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doktori_OdeljenjeID",
                table: "Doktori",
                column: "OdeljenjeID");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_DoktorID",
                table: "Pregledi",
                column: "DoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Pregledi_PacijentID",
                table: "Pregledi",
                column: "PacijentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pregledi");

            migrationBuilder.DropTable(
                name: "Doktori");

            migrationBuilder.DropTable(
                name: "Pacijenti");

            migrationBuilder.DropTable(
                name: "Odeljenja");
        }
    }
}
