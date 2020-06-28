﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartCtl.Db;

namespace SmartCtl.Db.Migrations
{
    [DbContext(typeof(SmartCtlContext))]
    [Migration("20200628193137_DriveInformation_M1")]
    partial class DriveInformation_M1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("SmartCtl.Domain.DriveInformation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ATAVersionMajor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ATAVersionMinor")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ATAVersionName")
                        .HasColumnType("TEXT");

                    b.Property<long>("BlockCount")
                        .HasColumnType("INTEGER");

                    b.Property<long>("BytesCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirmwareVersion")
                        .HasColumnType("TEXT");

                    b.Property<string>("FormFactor")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasErrorRecovery")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ModelFamily")
                        .HasColumnType("TEXT");

                    b.Property<string>("ModelName")
                        .HasColumnType("TEXT");

                    b.Property<int>("PowerCycleCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PowerOnHours")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RPM")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SATASpeed")
                        .HasColumnType("TEXT");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("SmartOK")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Temperature")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("DriveInformation");
                });
#pragma warning restore 612, 618
        }
    }
}
