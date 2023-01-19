﻿// <auto-generated />
using CretaceousApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CretaceousApi.Migrations
{
    [DbContext(typeof(CretaceousApiContext))]
    [Migration("20230118142023_AddJoinTable")]
    partial class AddJoinTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CretaceousApi.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Species")
                        .HasColumnType("longtext");

                    b.HasKey("AnimalId");

                    b.ToTable("Animals");

                    b.HasData(
                        new
                        {
                            AnimalId = 1,
                            Age = 100,
                            Name = "Buck",
                            Species = "Diplodocus"
                        },
                        new
                        {
                            AnimalId = 2,
                            Age = 50,
                            Name = "Bubbles",
                            Species = "Triceratops"
                        },
                        new
                        {
                            AnimalId = 3,
                            Age = 2,
                            Name = "Spot",
                            Species = "Velociraptor"
                        });
                });

            modelBuilder.Entity("CretaceousApi.Models.Continent", b =>
                {
                    b.Property<int>("ContinentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("ContinentId");

                    b.ToTable("Continents");

                    b.HasData(
                        new
                        {
                            ContinentId = 1,
                            Name = "North America"
                        },
                        new
                        {
                            ContinentId = 2,
                            Name = "South America"
                        },
                        new
                        {
                            ContinentId = 3,
                            Name = "Africa"
                        },
                        new
                        {
                            ContinentId = 4,
                            Name = "Europe"
                        },
                        new
                        {
                            ContinentId = 5,
                            Name = "Asia"
                        },
                        new
                        {
                            ContinentId = 6,
                            Name = "Australia"
                        });
                });

            modelBuilder.Entity("CretaceousApi.Models.ContinentAnimal", b =>
                {
                    b.Property<int>("ContinentAnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("ContinentId")
                        .HasColumnType("int");

                    b.HasKey("ContinentAnimalId");

                    b.HasIndex("AnimalId");

                    b.HasIndex("ContinentId");

                    b.ToTable("ContinentAnimals");
                });

            modelBuilder.Entity("CretaceousApi.Models.ContinentAnimal", b =>
                {
                    b.HasOne("CretaceousApi.Models.Animal", "Animal")
                        .WithMany("JoinEntities")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CretaceousApi.Models.Continent", "Continent")
                        .WithMany("JoinEntities")
                        .HasForeignKey("ContinentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Continent");
                });

            modelBuilder.Entity("CretaceousApi.Models.Animal", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("CretaceousApi.Models.Continent", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
