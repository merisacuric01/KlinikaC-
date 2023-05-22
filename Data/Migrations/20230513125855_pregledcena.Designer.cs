﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using klinika.Data;

#nullable disable

namespace klinika.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230513125855_pregledcena")]
    partial class pregledcena
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("klinika.models.Doktor", b =>
                {
                    b.Property<int>("DoktorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("longtext");

                    b.Property<string>("Kontact")
                        .HasColumnType("longtext");

                    b.Property<int>("OdeljenjeID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("longtext");

                    b.HasKey("DoktorID");

                    b.HasIndex("OdeljenjeID");

                    b.ToTable("Doktori");

                    b.HasData(
                        new
                        {
                            DoktorID = 1,
                            Ime = "Jasmina",
                            Kontact = "0641458792",
                            OdeljenjeID = 1,
                            Prezime = "Zupic"
                        },
                        new
                        {
                            DoktorID = 2,
                            Ime = "Kimeta",
                            Kontact = "0641665892",
                            OdeljenjeID = 2,
                            Prezime = "Lukic"
                        });
                });

            modelBuilder.Entity("klinika.models.Odeljenje", b =>
                {
                    b.Property<int>("OdeljenjeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("longtext");

                    b.HasKey("OdeljenjeID");

                    b.ToTable("Odeljenja");

                    b.HasData(
                        new
                        {
                            OdeljenjeID = 1,
                            Naziv = "Hirurg"
                        },
                        new
                        {
                            OdeljenjeID = 2,
                            Naziv = "Decije"
                        });
                });

            modelBuilder.Entity("klinika.models.Pacijent", b =>
                {
                    b.Property<int>("PacijentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("longtext");

                    b.Property<string>("Istorija")
                        .HasColumnType("longtext");

                    b.Property<string>("Prezime")
                        .HasColumnType("longtext");

                    b.HasKey("PacijentID");

                    b.ToTable("Pacijenti");
                });

            modelBuilder.Entity("klinika.models.Pregled", b =>
                {
                    b.Property<int>("PregledID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("CenaPregleda")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Dijagnoza")
                        .HasColumnType("longtext");

                    b.Property<int>("DoktorID")
                        .HasColumnType("int");

                    b.Property<int>("PacijentID")
                        .HasColumnType("int");

                    b.Property<int>("StatusPregleda")
                        .HasColumnType("int");

                    b.HasKey("PregledID");

                    b.HasIndex("DoktorID");

                    b.HasIndex("PacijentID");

                    b.ToTable("Pregledi");
                });

            modelBuilder.Entity("klinika.models.Doktor", b =>
                {
                    b.HasOne("klinika.models.Odeljenje", "Odeljenje")
                        .WithMany()
                        .HasForeignKey("OdeljenjeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Odeljenje");
                });

            modelBuilder.Entity("klinika.models.Pregled", b =>
                {
                    b.HasOne("klinika.models.Doktor", "Doktor")
                        .WithMany()
                        .HasForeignKey("DoktorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("klinika.models.Pacijent", "Pacijent")
                        .WithMany()
                        .HasForeignKey("PacijentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("Pacijent");
                });
#pragma warning restore 612, 618
        }
    }
}
