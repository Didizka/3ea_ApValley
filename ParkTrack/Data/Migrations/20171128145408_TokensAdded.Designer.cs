﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using ParkTrack.Data;
using System;

namespace ParkTrack.Data.Migrations
{
    [DbContext(typeof(SensorContext))]
    [Migration("20171128145408_TokensAdded")]
    partial class TokensAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkTrack.Models.Sensor", b =>
                {
                    b.Property<int>("SensorID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<float>("latitude");

                    b.Property<float>("longitude");

                    b.HasKey("SensorID");

                    b.ToTable("Sensors");
                });
#pragma warning restore 612, 618
        }
    }
}
