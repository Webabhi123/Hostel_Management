using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hostel_Management.Migrations
{
    /// <inheritdoc />
    public partial class addattributeEmailPhonenumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phonenumber",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phonenumber",
                table: "users");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "users");
        }
    }
}
