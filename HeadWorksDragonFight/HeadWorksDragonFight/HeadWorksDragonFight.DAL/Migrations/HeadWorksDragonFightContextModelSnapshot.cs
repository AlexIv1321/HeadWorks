﻿// <auto-generated />
using System;
using HeadWorksDragonFight.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HeadWorksDragonFight.DAL.Migrations
{
    [DbContext(typeof(HeadWorksDragonFightContext))]
    partial class HeadWorksDragonFightContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HeadWorksDragonFight.Dal.Models.DragonDal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Hp")
                        .HasColumnType("int");

                    b.Property<int>("HpMax")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Dragons");
                });

            modelBuilder.Entity("HeadWorksDragonFight.Dal.Models.HeroDal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weapon")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("Login");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("HeadWorksDragonFight.Dal.Models.HitDal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DragonDalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HeroDalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ImpactForce")
                        .HasColumnType("int");

                    b.Property<string>("NameDragon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("StrikeTime")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("HeroDalId");

                    b.ToTable("Hits");
                });

            modelBuilder.Entity("HeadWorksDragonFight.Dal.Models.HitDal", b =>
                {
                    b.HasOne("HeadWorksDragonFight.Dal.Models.HeroDal", "HeroDal")
                        .WithMany("HitDal")
                        .HasForeignKey("HeroDalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HeroDal");
                });

            modelBuilder.Entity("HeadWorksDragonFight.Dal.Models.HeroDal", b =>
                {
                    b.Navigation("HitDal");
                });
#pragma warning restore 612, 618
        }
    }
}
