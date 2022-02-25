using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTicaret.Repository.Migrations
{
    public partial class CommenIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActıve",
                table: "ProductComments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActıve",
                table: "ProductComments");
        }
    }
}
