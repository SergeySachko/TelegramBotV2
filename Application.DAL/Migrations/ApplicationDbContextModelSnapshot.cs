﻿// <auto-generated />
using Application.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Application.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Application.Entites.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<double>("WinRate");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("Application.Entites.HeroAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("HeroId");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.Property<bool>("isMainAttribute");

                    b.HasKey("Id");

                    b.HasIndex("HeroId");

                    b.ToTable("HeroAttributes");
                });

            modelBuilder.Entity("Application.Entites.HeroAttribute", b =>
                {
                    b.HasOne("Application.Entites.Hero", "Hero")
                        .WithMany("Attributes")
                        .HasForeignKey("HeroId");
                });
#pragma warning restore 612, 618
        }
    }
}
