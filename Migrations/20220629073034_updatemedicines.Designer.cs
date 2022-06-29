﻿// <auto-generated />
using System;
using ClinicManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicManagement.Migrations
{
    [DbContext(typeof(ClinicManagementDbContext))]
    [Migration("20220629073034_updatemedicines")]
    partial class updatemedicines
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClinicManagement.Models.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Country")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Post_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Street")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("ID");

                    b.ToTable("addresses");
                });

            modelBuilder.Entity("ClinicManagement.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DoctorID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorID");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClinicManagement.Models.BoolGroup", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("BoolGroups");
                });

            modelBuilder.Entity("ClinicManagement.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descriptions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ParentCategoryID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ParentCategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ClinicManagement.Models.ClinicInfo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ClinicInfos");
                });

            modelBuilder.Entity("ClinicManagement.Models.Doctor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("BloodGroupID")
                        .HasColumnType("int");

                    b.Property<bool>("Doctor_Status")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("GenderID")
                        .HasColumnType("int");

                    b.Property<string>("ImatePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Registed_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.HasIndex("BloodGroupID");

                    b.HasIndex("GenderID");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("ClinicManagement.Models.Gender", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("ClinicManagement.Models.Manufacture", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Manufactures");
                });

            modelBuilder.Entity("ClinicManagement.Models.Medicines", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModify")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("OldSellPrice")
                        .HasColumnType("smallmoney");

                    b.Property<decimal?>("OldUnitPrice")
                        .HasColumnType("smallmoney");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("SellPrice")
                        .HasColumnType("smallmoney");

                    b.Property<int?>("UnitID")
                        .HasColumnType("int");

                    b.Property<decimal?>("UnitPrice")
                        .HasColumnType("smallmoney");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserIDModify")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.HasIndex("UnitID");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("ClinicManagement.Models.MedicinesCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("MedicinesID")
                        .HasColumnType("int");

                    b.HasKey("CategoryID", "MedicinesID");

                    b.HasIndex("MedicinesID");

                    b.ToTable("MedicinesCategories");
                });

            modelBuilder.Entity("ClinicManagement.Models.MedicinesHistory", b =>
                {
                    b.Property<int>("MedicinesID")
                        .HasColumnType("int");

                    b.Property<int>("PaymentHeaderID")
                        .HasColumnType("int");

                    b.HasKey("MedicinesID", "PaymentHeaderID");

                    b.HasIndex("PaymentHeaderID");

                    b.ToTable("MedicinesHistories");
                });

            modelBuilder.Entity("ClinicManagement.Models.Patient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressID")
                        .HasColumnType("int");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("BloodGroupID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("GenderID")
                        .HasColumnType("int");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Registed_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AddressID");

                    b.HasIndex("BloodGroupID");

                    b.HasIndex("GenderID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("ClinicManagement.Models.PaymentDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MedicinesID")
                        .HasColumnType("int");

                    b.Property<int>("PaymentHeaderID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("SellPrice")
                        .HasColumnType("smallmoney");

                    b.HasKey("ID");

                    b.HasIndex("MedicinesID");

                    b.HasIndex("PaymentHeaderID");

                    b.ToTable("paymentDetails");
                });

            modelBuilder.Entity("ClinicManagement.Models.PaymentHeader", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<decimal?>("Total")
                        .HasColumnType("smallmoney");

                    b.HasKey("ID");

                    b.HasIndex("PatientID");

                    b.ToTable("PaymentHeaders");
                });

            modelBuilder.Entity("ClinicManagement.Models.PrescriptionsDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MedicinesID")
                        .HasColumnType("int");

                    b.Property<int>("No_of_day")
                        .HasColumnType("int");

                    b.Property<int?>("PrescriptionsID")
                        .HasColumnType("int");

                    b.Property<string>("When_To_Take")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_Before_Meal")
                        .HasColumnType("bit");

                    b.Property<int>("prescriptionsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MedicinesID");

                    b.HasIndex("PrescriptionsID");

                    b.ToTable("prescriptionsDetails");
                });

            modelBuilder.Entity("ClinicManagement.Models.Unit", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("ClinicManagement.Models.prescriptions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NextVisit")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.Property<string>("advice")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("ClinicManagement.Models.AppUser", b =>
                {
                    b.HasOne("ClinicManagement.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("ClinicManagement.Models.Category", b =>
                {
                    b.HasOne("ClinicManagement.Models.Category", "ParentCategory")
                        .WithMany("CategoryChildren")
                        .HasForeignKey("ParentCategoryID");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("ClinicManagement.Models.Doctor", b =>
                {
                    b.HasOne("ClinicManagement.Models.Address", "address")
                        .WithMany()
                        .HasForeignKey("AddressID");

                    b.HasOne("ClinicManagement.Models.BoolGroup", "boolGroup")
                        .WithMany()
                        .HasForeignKey("BloodGroupID");

                    b.HasOne("ClinicManagement.Models.Gender", "gender")
                        .WithMany()
                        .HasForeignKey("GenderID");

                    b.Navigation("address");

                    b.Navigation("boolGroup");

                    b.Navigation("gender");
                });

            modelBuilder.Entity("ClinicManagement.Models.Medicines", b =>
                {
                    b.HasOne("ClinicManagement.Models.Unit", "Units")
                        .WithMany()
                        .HasForeignKey("UnitID");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("ClinicManagement.Models.MedicinesCategory", b =>
                {
                    b.HasOne("ClinicManagement.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicManagement.Models.Medicines", "Medicines")
                        .WithMany("MedicinesCatogorys")
                        .HasForeignKey("MedicinesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Medicines");
                });

            modelBuilder.Entity("ClinicManagement.Models.MedicinesHistory", b =>
                {
                    b.HasOne("ClinicManagement.Models.Medicines", "medicines")
                        .WithMany()
                        .HasForeignKey("MedicinesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicManagement.Models.PaymentHeader", "PaymentHeader")
                        .WithMany()
                        .HasForeignKey("PaymentHeaderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("medicines");

                    b.Navigation("PaymentHeader");
                });

            modelBuilder.Entity("ClinicManagement.Models.Patient", b =>
                {
                    b.HasOne("ClinicManagement.Models.Address", "address")
                        .WithMany()
                        .HasForeignKey("AddressID");

                    b.HasOne("ClinicManagement.Models.BoolGroup", "boolGroup")
                        .WithMany()
                        .HasForeignKey("BloodGroupID");

                    b.HasOne("ClinicManagement.Models.Gender", "gender")
                        .WithMany()
                        .HasForeignKey("GenderID");

                    b.Navigation("address");

                    b.Navigation("boolGroup");

                    b.Navigation("gender");
                });

            modelBuilder.Entity("ClinicManagement.Models.PaymentDetail", b =>
                {
                    b.HasOne("ClinicManagement.Models.Medicines", "Medicines")
                        .WithMany()
                        .HasForeignKey("MedicinesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicManagement.Models.PaymentHeader", "paymentHeader")
                        .WithMany("PaymentDetail")
                        .HasForeignKey("PaymentHeaderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicines");

                    b.Navigation("paymentHeader");
                });

            modelBuilder.Entity("ClinicManagement.Models.PaymentHeader", b =>
                {
                    b.HasOne("ClinicManagement.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("ClinicManagement.Models.PrescriptionsDetail", b =>
                {
                    b.HasOne("ClinicManagement.Models.Medicines", "Medicines")
                        .WithMany()
                        .HasForeignKey("MedicinesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicManagement.Models.prescriptions", "prescriptionsmaster")
                        .WithMany("PrescriptionsDetail")
                        .HasForeignKey("PrescriptionsID");

                    b.Navigation("Medicines");

                    b.Navigation("prescriptionsmaster");
                });

            modelBuilder.Entity("ClinicManagement.Models.prescriptions", b =>
                {
                    b.HasOne("ClinicManagement.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicManagement.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ClinicManagement.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ClinicManagement.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicManagement.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ClinicManagement.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClinicManagement.Models.Category", b =>
                {
                    b.Navigation("CategoryChildren");
                });

            modelBuilder.Entity("ClinicManagement.Models.Medicines", b =>
                {
                    b.Navigation("MedicinesCatogorys");
                });

            modelBuilder.Entity("ClinicManagement.Models.PaymentHeader", b =>
                {
                    b.Navigation("PaymentDetail");
                });

            modelBuilder.Entity("ClinicManagement.Models.prescriptions", b =>
                {
                    b.Navigation("PrescriptionsDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
