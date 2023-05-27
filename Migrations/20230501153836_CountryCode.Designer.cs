﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication3.Models;

#nullable disable

namespace WebApplication3.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230501153836_CountryCode")]
    partial class CountryCode
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("WebApplication3.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CountryCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("WebApplication3.Models.Odds", b =>
                {
                    b.Property<int>("OddsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MatchId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("ltp")
                        .HasColumnType("REAL");

                    b.Property<string>("teamName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("timeStamp")
                        .HasColumnType("TEXT");

                    b.HasKey("OddsId");

                    b.HasIndex("MatchId");

                    b.ToTable("Odds");
                });

            modelBuilder.Entity("WebApplication3.Models.Odds", b =>
                {
                    b.HasOne("WebApplication3.Models.Match", null)
                        .WithMany("Odds")
                        .HasForeignKey("MatchId");
                });

            modelBuilder.Entity("WebApplication3.Models.Match", b =>
                {
                    b.Navigation("Odds");
                });
#pragma warning restore 612, 618
        }
    }
}
