﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentsApi.Data;

#nullable disable

namespace StudentsApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220724110840_Updated Units to nullable Student table")]
    partial class UpdatedUnitstonullableStudenttable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("StudentsApi.Models.Identification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("IssueDatate")
                        .HasColumnType("TEXT");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("IDNumber");
                });

            modelBuilder.Entity("StudentsApi.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentsApi.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("StudentsApi.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ComputerApplications")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Csharp")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DataBase")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mathematics")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("StudentUnit", b =>
                {
                    b.Property<int>("StudentsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnitsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentsId", "UnitsId");

                    b.HasIndex("UnitsId");

                    b.ToTable("StudentUnit");
                });

            modelBuilder.Entity("TeacherUnit", b =>
                {
                    b.Property<int>("TeachersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnitsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeachersId", "UnitsId");

                    b.HasIndex("UnitsId");

                    b.ToTable("TeacherUnit");
                });

            modelBuilder.Entity("StudentsApi.Models.Identification", b =>
                {
                    b.HasOne("StudentsApi.Models.Student", "Student")
                        .WithOne("IDNumbers")
                        .HasForeignKey("StudentsApi.Models.Identification", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentUnit", b =>
                {
                    b.HasOne("StudentsApi.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentsApi.Models.Unit", null)
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TeacherUnit", b =>
                {
                    b.HasOne("StudentsApi.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudentsApi.Models.Unit", null)
                        .WithMany()
                        .HasForeignKey("UnitsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudentsApi.Models.Student", b =>
                {
                    b.Navigation("IDNumbers")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}