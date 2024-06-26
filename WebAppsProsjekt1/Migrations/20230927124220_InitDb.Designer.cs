﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppsProsjekt1.Models;

#nullable disable

namespace WebAppsProsjekt1.Migrations
{
    [DbContext(typeof(CardDbContext))]
    [Migration("20230927124220_InitDb")]
    partial class InitDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("WebAppsProsjekt1.Models.Cardset", b =>
                {
                    b.Property<int>("CardSetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CardSetName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("CardSetId");

                    b.ToTable("Cardsets");
                });
#pragma warning restore 612, 618
        }
    }
}
