﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using donglers.Data;

#nullable disable

namespace donglers.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("donglers.Models.Admin", b =>
                {
                    b.Property<int>("admin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("admin_id"));

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("admin_id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("donglers.Models.Autentifikacija", b =>
                {
                    b.Property<int>("autentifikacija_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("autentifikacija_id"));

                    b.Property<DateTime>("datum_autentifikcije")
                        .HasColumnType("datetime2");

                    b.Property<int>("korisnik_id")
                        .HasColumnType("int");

                    b.Property<string>("vrijednost")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("autentifikacija_id");

                    b.HasIndex("korisnik_id");

                    b.ToTable("Autentifikacija");
                });

            modelBuilder.Entity("donglers.Models.Korisnik", b =>
                {
                    b.Property<int>("korisnik_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("korisnik_id"));

                    b.Property<DateTime?>("datum_kreiranja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("datum_rodenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_student")
                        .HasColumnType("bit");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("prihvacena_pravila")
                        .HasColumnType("bit");

                    b.Property<int>("score")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("korisnik_id");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("donglers.Models.KorisnikLekcija", b =>
                {
                    b.Property<int>("korisnik_lekcija_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("korisnik_lekcija_id"));

                    b.Property<int>("korisnik_id")
                        .HasColumnType("int");

                    b.Property<int>("lekcija_id")
                        .HasColumnType("int");

                    b.HasKey("korisnik_lekcija_id");

                    b.HasIndex("korisnik_id");

                    b.HasIndex("lekcija_id");

                    b.ToTable("KorisnikLekcija");
                });

            modelBuilder.Entity("donglers.Models.Kurs", b =>
                {
                    b.Property<int>("kurs_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("kurs_id"));

                    b.Property<DateTime?>("datum_kreiranja")
                        .HasColumnType("datetime2");

                    b.Property<int>("kreator_id")
                        .HasColumnType("int");

                    b.Property<string>("naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("kurs_id");

                    b.HasIndex("kreator_id");

                    b.ToTable("Kurs");
                });

            modelBuilder.Entity("donglers.Models.Lekcija", b =>
                {
                    b.Property<int>("lekcija_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("lekcija_id"));

                    b.Property<DateTime?>("datum_kreiranja")
                        .HasColumnType("datetime2");

                    b.Property<int>("kreator_id")
                        .HasColumnType("int");

                    b.Property<int?>("level_id")
                        .HasColumnType("int");

                    b.Property<string>("naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postavka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rjesenje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tezina")
                        .HasColumnType("int");

                    b.HasKey("lekcija_id");

                    b.HasIndex("kreator_id");

                    b.HasIndex("level_id");

                    b.ToTable("Lekcija");
                });

            modelBuilder.Entity("donglers.Models.Level", b =>
                {
                    b.Property<int>("level_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("level_id"));

                    b.Property<DateTime?>("datum_kreiranja")
                        .HasColumnType("datetime2");

                    b.Property<int>("kreator_id")
                        .HasColumnType("int");

                    b.Property<int?>("kurs_id")
                        .HasColumnType("int");

                    b.Property<string>("opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stepen")
                        .HasColumnType("int");

                    b.HasKey("level_id");

                    b.HasIndex("kreator_id");

                    b.HasIndex("kurs_id");

                    b.ToTable("Level");
                });

            modelBuilder.Entity("donglers.Models.Poruka", b =>
                {
                    b.Property<int>("poruka_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("poruka_id"));

                    b.Property<DateTime?>("datum_slanja")
                        .HasColumnType("datetime2");

                    b.Property<bool>("is_pregledana")
                        .HasColumnType("bit");

                    b.Property<string>("naslov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("posiljaoc_id")
                        .HasColumnType("int");

                    b.Property<int>("primaoc_id")
                        .HasColumnType("int");

                    b.Property<string>("sadrzaj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("poruka_id");

                    b.HasIndex("posiljaoc_id");

                    b.HasIndex("primaoc_id");

                    b.ToTable("Poruka");
                });

            modelBuilder.Entity("donglers.Models.Autentifikacija", b =>
                {
                    b.HasOne("donglers.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnik_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");
                });

            modelBuilder.Entity("donglers.Models.KorisnikLekcija", b =>
                {
                    b.HasOne("donglers.Models.Korisnik", "korisnik")
                        .WithMany()
                        .HasForeignKey("korisnik_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("donglers.Models.Lekcija", "lekcija")
                        .WithMany()
                        .HasForeignKey("lekcija_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnik");

                    b.Navigation("lekcija");
                });

            modelBuilder.Entity("donglers.Models.Kurs", b =>
                {
                    b.HasOne("donglers.Models.Korisnik", "kreator")
                        .WithMany()
                        .HasForeignKey("kreator_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kreator");
                });

            modelBuilder.Entity("donglers.Models.Lekcija", b =>
                {
                    b.HasOne("donglers.Models.Korisnik", "kreator")
                        .WithMany()
                        .HasForeignKey("kreator_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("donglers.Models.Level", null)
                        .WithMany("lekcije")
                        .HasForeignKey("level_id");

                    b.Navigation("kreator");
                });

            modelBuilder.Entity("donglers.Models.Level", b =>
                {
                    b.HasOne("donglers.Models.Korisnik", "kreator")
                        .WithMany()
                        .HasForeignKey("kreator_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("donglers.Models.Kurs", null)
                        .WithMany("leveli")
                        .HasForeignKey("kurs_id");

                    b.Navigation("kreator");
                });

            modelBuilder.Entity("donglers.Models.Poruka", b =>
                {
                    b.HasOne("donglers.Models.Korisnik", "posiljaoc")
                        .WithMany()
                        .HasForeignKey("posiljaoc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("donglers.Models.Korisnik", "primaoc")
                        .WithMany()
                        .HasForeignKey("primaoc_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("posiljaoc");

                    b.Navigation("primaoc");
                });

            modelBuilder.Entity("donglers.Models.Kurs", b =>
                {
                    b.Navigation("leveli");
                });

            modelBuilder.Entity("donglers.Models.Level", b =>
                {
                    b.Navigation("lekcije");
                });
#pragma warning restore 612, 618
        }
    }
}
