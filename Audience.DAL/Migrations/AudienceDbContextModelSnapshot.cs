﻿// <auto-generated />
using System;
using Audience.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Audience.DAL.Migrations
{
    [DbContext(typeof(AudienceDbContext))]
    partial class AudienceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Audience.DAL.Entities.Audiences", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsHaveMedia")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Audiences");
                });

            modelBuilder.Entity("Audience.DAL.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AudiencesId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<string>("NameGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isNeedMedia")
                        .HasColumnType("bit");

                    b.Property<int>("timetableOfClassesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AudiencesId");

                    b.HasIndex("LecturerId");

                    b.HasIndex("timetableOfClassesId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("Audience.DAL.Entities.Lecturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("Audience.DAL.Entities.TimetableOfClasses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("TimeEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("TimeStart")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("TimetableOfClasses");
                });

            modelBuilder.Entity("Audience.DAL.Entities.Class", b =>
                {
                    b.HasOne("Audience.DAL.Entities.Audiences", "Audiences")
                        .WithMany("ItemsClass")
                        .HasForeignKey("AudiencesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Audience.DAL.Entities.Lecturer", "Lecturer")
                        .WithMany("ItemsClass")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Audience.DAL.Entities.TimetableOfClasses", "timetableOfClasses")
                        .WithMany("ItemsClass")
                        .HasForeignKey("timetableOfClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Audiences");

                    b.Navigation("Lecturer");

                    b.Navigation("timetableOfClasses");
                });

            modelBuilder.Entity("Audience.DAL.Entities.Audiences", b =>
                {
                    b.Navigation("ItemsClass");
                });

            modelBuilder.Entity("Audience.DAL.Entities.Lecturer", b =>
                {
                    b.Navigation("ItemsClass");
                });

            modelBuilder.Entity("Audience.DAL.Entities.TimetableOfClasses", b =>
                {
                    b.Navigation("ItemsClass");
                });
#pragma warning restore 612, 618
        }
    }
}
