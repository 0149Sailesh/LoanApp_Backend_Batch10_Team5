﻿// <auto-generated />
using System;
using LoanAPI.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoanAPI.Migrations
{
    [DbContext(typeof(LoanDbContext))]
    partial class LoanDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LOANAPI.Entites.EmployeeIssueDetailsEntity", b =>
                {
                    b.Property<string>("Issue_Id")
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<string>("Employee_Id")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("Issue_Date")
                        .HasColumnType("DateTime");

                    b.Property<string>("Item_Id")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("Return_Date")
                        .HasColumnType("DateTime");

                    b.HasKey("Issue_Id");

                    b.ToTable("EIDEntity");
                });

            modelBuilder.Entity("LOANAPI.Entites.EmployeeMastersEntity", b =>
                {
                    b.Property<string>("Employee_Id")
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("Date_of_Birth")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("Date_of_Joining")
                        .HasColumnType("DateTime");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<string>("Employee_Gender")
                        .IsRequired()
                        .HasColumnType("char");

                    b.Property<string>("Employee_Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.HasKey("Employee_Id");

                    b.ToTable("EMEntity");
                });

            modelBuilder.Entity("LoanAPI.Entities.EmployeeCardDetailsEntity", b =>
                {
                    b.Property<string>("Card_Id")
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("Card_Issue_Date")
                        .HasColumnType("DateTime");

                    b.Property<string>("Employee_Id")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<string>("Loan_Id")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.HasKey("Card_Id");

                    b.ToTable("ECDEntity");
                });

            modelBuilder.Entity("LoanAPI.Entities.LoanCardMasterEntity", b =>
                {
                    b.Property<string>("Loan_Id")
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<int>("Duration")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.Property<string>("Loan_Type")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar");

                    b.HasKey("Loan_Id");

                    b.ToTable("LCMEntity");
                });

            modelBuilder.Entity("LoanAPI.Entity.ItemMasterEntity", b =>
                {
                    b.Property<string>("Item_Id")
                        .HasMaxLength(6)
                        .HasColumnType("varchar");

                    b.Property<string>("Issue_Status")
                        .IsRequired()
                        .HasColumnType("char");

                    b.Property<string>("Item_Category")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar");

                    b.Property<string>("Item_Description")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<string>("Item_Make")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<int>("Item_Valuation")
                        .HasMaxLength(6)
                        .HasColumnType("int");

                    b.HasKey("Item_Id");

                    b.ToTable("IMEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
