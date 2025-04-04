﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBasketball.Models;

#nullable disable

namespace NBasketball.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NBasketball.Models.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("NBasketball.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("DATE")
                        .HasColumnName("date_added");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateAdded = new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/lebron.jpg",
                            Name = "Леброн Джеймс",
                            Position = "Форвард",
                            TeamId = 1
                        },
                        new
                        {
                            Id = 2,
                            DateAdded = new DateTime(2024, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/kavai.jpg",
                            Name = "Кавай Ленард",
                            Position = "Нападающий",
                            TeamId = 1
                        },
                        new
                        {
                            Id = 3,
                            DateAdded = new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/pol.jpg",
                            Name = "Пол Джордж",
                            Position = "Нападающий",
                            TeamId = 1
                        },
                        new
                        {
                            Id = 4,
                            DateAdded = new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/batler.jpg",
                            Name = "Джимми Батлер",
                            Position = "Нападающий",
                            TeamId = 3
                        },
                        new
                        {
                            Id = 5,
                            DateAdded = new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/steph.jpg",
                            Name = "Стефен Карри",
                            Position = "Защитник",
                            TeamId = 2
                        },
                        new
                        {
                            Id = 6,
                            DateAdded = new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/kevin.jpg",
                            Name = "Кевин Дюрант",
                            Position = "Форвард",
                            TeamId = 3
                        },
                        new
                        {
                            Id = 7,
                            DateAdded = new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/yanis.jpg",
                            Name = "Яннис Адетокунбо",
                            Position = "Форвард",
                            TeamId = 2
                        },
                        new
                        {
                            Id = 8,
                            DateAdded = new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/nikola.jpg",
                            Name = "Никола Йокич",
                            Position = "Центровой",
                            TeamId = 3
                        },
                        new
                        {
                            Id = 9,
                            DateAdded = new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/llull.jpg",
                            Name = "Серхио Льюль",
                            Position = "Защитник",
                            TeamId = 6
                        },
                        new
                        {
                            Id = 10,
                            DateAdded = new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/mirotic.jpg",
                            Name = "Никола Миротич",
                            Position = "Форвард",
                            TeamId = 7
                        },
                        new
                        {
                            Id = 11,
                            DateAdded = new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/satoransky.jpg",
                            Name = "Томас Саторански",
                            Position = "Защитник",
                            TeamId = 7
                        },
                        new
                        {
                            Id = 12,
                            DateAdded = new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/huertas.jpg",
                            Name = "Марсельиньо Уэртас",
                            Position = "Защитник",
                            TeamId = 8
                        },
                        new
                        {
                            Id = 13,
                            DateAdded = new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/decolo.jpg",
                            Name = "Нандо Де Коло",
                            Position = "Защитник",
                            TeamId = 10
                        },
                        new
                        {
                            Id = 14,
                            DateAdded = new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/micic.jpg",
                            Name = "Василие Мицич",
                            Position = "Защитник",
                            TeamId = 11
                        },
                        new
                        {
                            Id = 15,
                            DateAdded = new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/vesely.jpg",
                            Name = "Ян Веселы",
                            Position = "Центровой",
                            TeamId = 12
                        },
                        new
                        {
                            Id = 16,
                            DateAdded = new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImagePath = "/assets/sloukas.jpg",
                            Name = "Костас Слукас",
                            Position = "Защитник",
                            TeamId = 13
                        });
                });

            modelBuilder.Entity("NBasketball.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("League")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            League = "NBA",
                            Name = "Los Angeles Lakers"
                        },
                        new
                        {
                            Id = 2,
                            League = "NBA",
                            Name = "Golden State Warriors"
                        },
                        new
                        {
                            Id = 3,
                            League = "NBA",
                            Name = "Chicago Bulls"
                        },
                        new
                        {
                            Id = 4,
                            League = "NBA",
                            Name = "Boston Celtics"
                        },
                        new
                        {
                            Id = 5,
                            League = "NBA",
                            Name = "Miami Heat"
                        },
                        new
                        {
                            Id = 6,
                            League = "ACB",
                            Name = "Real Madrid"
                        },
                        new
                        {
                            Id = 7,
                            League = "ACB",
                            Name = "FC Barcelona"
                        },
                        new
                        {
                            Id = 8,
                            League = "ACB",
                            Name = "Baskonia"
                        },
                        new
                        {
                            Id = 9,
                            League = "ACB",
                            Name = "Valencia Basket"
                        },
                        new
                        {
                            Id = 10,
                            League = "EuroLeague",
                            Name = "CSKA Moscow"
                        },
                        new
                        {
                            Id = 11,
                            League = "EuroLeague",
                            Name = "Anadolu Efes"
                        },
                        new
                        {
                            Id = 12,
                            League = "EuroLeague",
                            Name = "Fenerbahçe"
                        },
                        new
                        {
                            Id = 13,
                            League = "EuroLeague",
                            Name = "Olympiacos"
                        },
                        new
                        {
                            Id = 14,
                            League = "Greek League",
                            Name = "Panathinaikos"
                        },
                        new
                        {
                            Id = 15,
                            League = "Israeli League",
                            Name = "Maccabi Tel Aviv"
                        },
                        new
                        {
                            Id = 16,
                            League = "Italian League",
                            Name = "Virtus Bologna"
                        });
                });

            modelBuilder.Entity("NBasketball.Models.Favorite", b =>
                {
                    b.HasOne("NBasketball.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("NBasketball.Models.Player", b =>
                {
                    b.HasOne("NBasketball.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("NBasketball.Models.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
