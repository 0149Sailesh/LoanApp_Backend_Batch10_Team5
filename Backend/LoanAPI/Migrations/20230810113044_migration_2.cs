using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanAPI.Migrations
{
    /// <inheritdoc />
    public partial class migration_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ECDEntity",
                table: "ECDEntity");

            migrationBuilder.AlterColumn<string>(
                name: "Issue_Status",
                table: "IMEntity",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char");

            migrationBuilder.AlterColumn<string>(
                name: "Employee_Gender",
                table: "EMEntity",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "EMEntity",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "EMEntity",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "EMEntity",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Card_Id",
                table: "ECDEntity",
                type: "varchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ECDEntity",
                table: "ECDEntity",
                column: "Card_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ECDEntity",
                table: "ECDEntity");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "EMEntity");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "EMEntity");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "EMEntity");

            migrationBuilder.DropColumn(
                name: "Card_Id",
                table: "ECDEntity");

            migrationBuilder.AlterColumn<string>(
                name: "Issue_Status",
                table: "IMEntity",
                type: "char",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)");

            migrationBuilder.AlterColumn<string>(
                name: "Employee_Gender",
                table: "EMEntity",
                type: "char",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ECDEntity",
                table: "ECDEntity",
                column: "Employee_Id");
        }
    }
}
