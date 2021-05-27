﻿// <auto-generated />
using DrunkenWizard_API.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DrunkenWizard_API.Migrations
{
    [DbContext(typeof(Repository))]
    [Migration("20200617225303_local")]
    partial class local
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DrunkenWizard_API.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Key")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("DrunkenWizard_API.Entities.GameClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PremiumClass")
                        .HasColumnType("bit");

                    b.Property<string>("RollEffect1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RollEffect2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RollEffect3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RollEffect4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RollEffect5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RollEffect6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SelectedColor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GameClass");
                });

            modelBuilder.Entity("DrunkenWizard_API.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BoostUsed")
                        .HasColumnType("bit");

                    b.Property<int>("GameClassId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("GameKey")
                        .HasColumnType("int");

                    b.Property<bool>("IsHost")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<bool>("LocalPLayer")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PremiumAccount")
                        .HasColumnType("bit");

                    b.Property<int>("SlayedBeast")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameClassId");

                    b.HasIndex("GameId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("DrunkenWizard_API.Entities.Spell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameClassId")
                        .HasColumnType("int");

                    b.Property<string>("GameClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondStyle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpellImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Style")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameClassId");

                    b.ToTable("Spell");
                });

            modelBuilder.Entity("DrunkenWizard_API.Entities.Player", b =>
                {
                    b.HasOne("DrunkenWizard_API.Entities.GameClass", "GameClass")
                        .WithMany("Players")
                        .HasForeignKey("GameClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DrunkenWizard_API.Entities.Game", "Game")
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DrunkenWizard_API.Entities.Spell", b =>
                {
                    b.HasOne("DrunkenWizard_API.Entities.GameClass", "GameClass")
                        .WithMany("Spells")
                        .HasForeignKey("GameClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
