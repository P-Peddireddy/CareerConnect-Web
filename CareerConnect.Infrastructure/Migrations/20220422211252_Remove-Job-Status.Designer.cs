﻿// <auto-generated />
using System;
using CareerConnect.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CareerConnect.Infrastructure.Migrations
{
    [DbContext(typeof(CoreDbContext))]
    [Migration("20220422211252_Remove-Job-Status")]
    partial class RemoveJobStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CareerConnect.Infrastructure.Entity.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("CareerConnect.Infrastructure.Entity.Applicant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("CareerConnect.Infrastructure.Entity.Employer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("CareerConnect.Infrastructure.Entity.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalaryRangeFrom")
                        .HasColumnType("int");

                    b.Property<int?>("SalaryRangeTo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("CareerConnect.Infrastructure.Entity.JobCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobCategories");
                });

            modelBuilder.Entity("CareerConnect.Infrastructure.Entity.Resume", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResumeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("JobId");

                    b.HasIndex("ResumeId");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("JobJobCategory", b =>
                {
                    b.Property<Guid>("CategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriesId", "JobsId");

                    b.HasIndex("JobsId");

                    b.ToTable("JobJobCategory");
                });

            modelBuilder.Entity("CareerConnect.Infrastructure.Entity.Job", b =>
                {
                    b.HasOne("CareerConnect.Infrastructure.Entity.Employer", "CreatedBy")
                        .WithMany("ListedJob")
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("CareerConnect.Infrastructure.Entity.Resume", b =>
                {
                    b.HasOne("CareerConnect.Infrastructure.Entity.Applicant", "Applicant")
                        .WithMany("Resumes")
                        .HasForeignKey("ApplicantId");

                    b.HasOne("CareerConnect.Infrastructure.Entity.Job", null)
                        .WithMany("ApplyingResumes")
                        .HasForeignKey("JobId");

                    b.HasOne("CareerConnect.Infrastructure.Entity.Resume", null)
                        .WithMany("AppliedJobs")
                        .HasForeignKey("ResumeId");

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("JobJobCategory", b =>
                {
                    b.HasOne("CareerConnect.Infrastructure.Entity.JobCategory", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CareerConnect.Infrastructure.Entity.Job", null)
                        .WithMany()
                        .HasForeignKey("JobsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CareerConnect.Infrastructure.Entity.Applicant", b =>
                {
                    b.Navigation("Resumes");
                });

            modelBuilder.Entity("CareerConnect.Infrastructure.Entity.Employer", b =>
                {
                    b.Navigation("ListedJob");
                });

            modelBuilder.Entity("CareerConnect.Infrastructure.Entity.Job", b =>
                {
                    b.Navigation("ApplyingResumes");
                });

            modelBuilder.Entity("CareerConnect.Infrastructure.Entity.Resume", b =>
                {
                    b.Navigation("AppliedJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
