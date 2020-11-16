﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model;

namespace Model.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20201116143126_pierwsza")]
    partial class pierwsza
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Projekt.CzłonekZespołu", b =>
                {
                    b.Property<int>("czlonekZespoluId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataUrodzenia")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataZapisu")
                        .HasColumnType("datetime2");

                    b.Property<string>("Funkcja")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imię")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PESEL1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pleć")
                        .HasColumnType("int");

                    b.Property<int?>("zespolBazazespolId")
                        .HasColumnType("int");

                    b.Property<int>("zespolId")
                        .HasColumnType("int");

                    b.HasKey("czlonekZespoluId");

                    b.HasIndex("zespolBazazespolId");

                    b.ToTable("czlonkowieZespolu");
                });

            modelBuilder.Entity("Projekt.KierownikZespołu", b =>
                {
                    b.Property<int>("kierownikZespoluId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataUrodzenia")
                        .HasColumnType("datetime2");

                    b.Property<int>("Doswiadczenie")
                        .HasColumnType("int");

                    b.Property<string>("Imię")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PESEL1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pleć")
                        .HasColumnType("int");

                    b.HasKey("kierownikZespoluId");

                    b.ToTable("kierownikZespolu");
                });

            modelBuilder.Entity("Projekt.Zespół", b =>
                {
                    b.Property<int>("zespolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("LiczbaCzłonków")
                        .HasColumnType("int");

                    b.Property<string>("Nazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("kierownikZespoluId")
                        .HasColumnType("int");

                    b.HasKey("zespolId");

                    b.HasIndex("kierownikZespoluId");

                    b.ToTable("zespolBaza");
                });

            modelBuilder.Entity("Projekt.CzłonekZespołu", b =>
                {
                    b.HasOne("Projekt.Zespół", "zespolBaza")
                        .WithMany("Członkowie")
                        .HasForeignKey("zespolBazazespolId");

                    b.Navigation("zespolBaza");
                });

            modelBuilder.Entity("Projekt.Zespół", b =>
                {
                    b.HasOne("Projekt.KierownikZespołu", "Kierownik")
                        .WithMany()
                        .HasForeignKey("kierownikZespoluId");

                    b.Navigation("Kierownik");
                });

            modelBuilder.Entity("Projekt.Zespół", b =>
                {
                    b.Navigation("Członkowie");
                });
#pragma warning restore 612, 618
        }
    }
}