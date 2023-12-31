﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanAPI.Migrations
{
    /// <inheritdoc />
    public partial class myfirs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminEntity",
                columns: table => new
                {
                    Username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminEntity", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "ECDEntity",
                columns: table => new
                {
                    Card_Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Employee_Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Loan_Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Card_Issue_Date = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECDEntity", x => x.Card_Id);
                });

            migrationBuilder.CreateTable(
                name: "EIDEntity",
                columns: table => new
                {
                    Issue_Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Employee_Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Item_Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Issue_Date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Return_Date = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EIDEntity", x => x.Issue_Id);
                });

            migrationBuilder.CreateTable(
                name: "EMEntity",
                columns: table => new
                {
                    Employee_Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Employee_Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Employee_Gender = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    Designation = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Department = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Date_of_Birth = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Date_of_Joining = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMEntity", x => x.Employee_Id);
                });

            migrationBuilder.CreateTable(
                name: "IMEntity",
                columns: table => new
                {
                    Item_Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Item_Description = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Issue_Status = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    Item_Make = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Item_Category = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Item_Valuation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMEntity", x => x.Item_Id);
                });

            migrationBuilder.CreateTable(
                name: "LCMEntity",
                columns: table => new
                {
                    Loan_Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Loan_Type = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LCMEntity", x => x.Loan_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminEntity");

            migrationBuilder.DropTable(
                name: "ECDEntity");

            migrationBuilder.DropTable(
                name: "EIDEntity");

            migrationBuilder.DropTable(
                name: "EMEntity");

            migrationBuilder.DropTable(
                name: "IMEntity");

            migrationBuilder.DropTable(
                name: "LCMEntity");
        }
    }
}
