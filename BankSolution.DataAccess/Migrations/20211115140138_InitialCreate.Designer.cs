﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using BankSolution.DataAccess;

namespace BankSolution.DataAccess.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20211115140138_InitialCreate.Designer")]
    public partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModuleHW.DataAccess.Models.Employee", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("EmployeeId")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<DateTime?>("DateOfBirth")
                    .HasColumnType("date")
                    .HasColumnName("DateOfBirth");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)")
                    .HasColumnName("FirstName");

                b.Property<DateTime>("HiredDate")
                    .HasPrecision(7)
                    .HasColumnType("datetime2(7)")
                    .HasColumnName("HiredDate");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)")
                    .HasColumnName("LastName");

                b.Property<int>("OfficeId")
                    .HasColumnType("int");

                b.Property<int>("TitleId")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("OfficeId");

                b.HasIndex("TitleId");

                b.ToTable("Employee");
            });

            modelBuilder.Entity("ModuleHW.DataAccess.Models.EmployeeProject", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("EmployeeProjectId")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<int>("EmployeeId")
                    .HasColumnType("int");

                b.Property<int>("ProjectId")
                    .HasColumnType("int");

                b.Property<decimal>("Rate")
                    .HasColumnType("money")
                    .HasColumnName("Rate");

                b.Property<DateTime>("StartedDate")
                    .HasPrecision(7)
                    .HasColumnType("datetime2(7)")
                    .HasColumnName("StartedDate");

                b.HasKey("Id");

                b.HasIndex("EmployeeId");

                b.HasIndex("ProjectId");

                b.ToTable("EmployeeProject");
            });

            modelBuilder.Entity("ModuleHW.DataAccess.Models.Office", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("OfficeId")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Location")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)")
                    .HasColumnName("Location");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)")
                    .HasColumnName("Title");

                b.HasKey("Id");

                b.ToTable("Office");
            });

            modelBuilder.Entity("ModuleHW.DataAccess.Models.Project", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("ProjectId")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<decimal>("Budget")
                    .HasColumnType("money")
                    .HasColumnName("Budget");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)")
                    .HasColumnName("Name");

                b.Property<DateTime>("StartedDate")
                    .HasPrecision(7)
                    .HasColumnType("datetime2(7)")
                    .HasColumnName("StartedDate");

                b.HasKey("Id");

                b.ToTable("Project");
            });

            modelBuilder.Entity("ModuleHW.DataAccess.Models.Title", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasColumnName("TitleId")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)")
                    .HasColumnName("Name");

                b.HasKey("Id");

                b.ToTable("Title");
            });

            modelBuilder.Entity("ModuleHW.DataAccess.Models.Employee", b =>
            {
                b.HasOne("ModuleHW.DataAccess.Models.Office", "Office")
                    .WithMany("Employees")
                    .HasForeignKey("OfficeId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("ModuleHW.DataAccess.Models.Title", "Title")
                    .WithMany("Employees")
                    .HasForeignKey("TitleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Office");

                b.Navigation("Title");
            });

            modelBuilder.Entity("ModuleHW.DataAccess.Models.EmployeeProject", b =>
            {
                b.HasOne("ModuleHW.DataAccess.Models.Employee", "Employee")
                    .WithMany("EmployeeProject")
                    .HasForeignKey("EmployeeId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("ModuleHW.DataAccess.Models.Project", "Project")
                    .WithMany("EmployeeProject")
                    .HasForeignKey("ProjectId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Employee");

                b.Navigation("Project");
            });

            modelBuilder.Entity("ModuleHW.DataAccess.Models.Employee", b =>
            {
                b.Navigation("EmployeeProject");
            });

            modelBuilder.Entity("ModuleHW.DataAccess.Models.Office", b =>
            {
                b.Navigation("Employees");
            });

            modelBuilder.Entity("ModuleHW.DataAccess.Models.Project", b =>
            {
                b.Navigation("EmployeeProject");
            });

            modelBuilder.Entity("ModuleHW.DataAccess.Models.Title", b =>
            {
                b.Navigation("Employees");
            });
#pragma warning restore 612, 618
        }
    }
}
