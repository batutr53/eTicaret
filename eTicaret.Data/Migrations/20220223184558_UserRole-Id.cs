using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTicaret.Repository.Migrations
{
    public partial class UserRoleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "UserRoles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "UserRoles",
                type: "datetime2",
                nullable: true);
        }
    }
}
