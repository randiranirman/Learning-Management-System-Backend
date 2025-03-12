﻿// <auto-generated />
using System;
using CourseManagementService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseManagementService.Migrations
{
    [DbContext(typeof(LmsContext))]
    partial class LmsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseManagementService.Models.Domains.Subject", b =>
                {
                    b.Property<Guid>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Code")
                        .HasName("PK__Subject__A25C5AA6C59CB22D");

                    b.ToTable("Subject", (string)null);
                });

            modelBuilder.Entity("CourseManagementService.Models.Domains.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<DateOnly?>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id")
                        .HasName("PK__Teacher__3214EC07E179E890");

                    b.HasIndex(new[] { "ContactNo" }, "UQ__Teacher__5C667C05B40BA242")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Teacher__A9D10534CBF4FED0")
                        .IsUnique();

                    b.ToTable("Teacher", (string)null);
                });

            modelBuilder.Entity("CourseManagementService.Models.Domains.TeacherSubject", b =>
                {
                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(1);

                    b.Property<Guid>("SubjectCode")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(2);

                    b.HasKey("TeacherId", "SubjectCode");

                    b.HasIndex("SubjectCode");

                    b.ToTable("TeacherSubject", (string)null);
                });

            modelBuilder.Entity("CourseManagementService.Models.Domains.TeacherSubject", b =>
                {
                    b.HasOne("CourseManagementService.Models.Domains.Subject", "SubjectCodeNavigation")
                        .WithMany()
                        .HasForeignKey("SubjectCode")
                        .IsRequired()
                        .HasConstraintName("FK__TeacherSu__Subje__412EB0B6");

                    b.HasOne("CourseManagementService.Models.Domains.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .IsRequired()
                        .HasConstraintName("FK__TeacherSu__Teach__403A8C7D");

                    b.Navigation("SubjectCodeNavigation");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
