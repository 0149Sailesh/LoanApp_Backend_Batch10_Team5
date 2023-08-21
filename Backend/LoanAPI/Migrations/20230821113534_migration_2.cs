﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanAPI.Migrations
{
    /// <inheritdoc />
    public partial class migration_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Employee_Gender",
                table: "EMEntity",
                type: "varchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Employee_Gender",
                table: "EMEntity",
                type: "char",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldMaxLength: 1);
        }
    }
}