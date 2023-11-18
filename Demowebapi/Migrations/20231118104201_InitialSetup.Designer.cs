﻿// <auto-generated />
using Demowebapi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demowebapi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231118104201_InitialSetup")]
    partial class InitialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Demowebapi.Model.Department", b =>
                {
                    b.Property<int>("deptid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("deptid"), 1L, 1);

                    b.Property<string>("deptname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("deptid");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Demowebapi.Model.Employee", b =>
                {
                    b.Property<int>("empid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("empid"), 1L, 1);

                    b.Property<int>("Departmentdeptid")
                        .HasColumnType("int");

                    b.Property<int>("deptid")
                        .HasColumnType("int");

                    b.Property<string>("empname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("empsalary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("empid");

                    b.HasIndex("Departmentdeptid");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Demowebapi.Model.Employee", b =>
                {
                    b.HasOne("Demowebapi.Model.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("Departmentdeptid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Demowebapi.Model.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}