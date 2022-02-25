using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTicaret.Repository.Migrations
{
    public partial class CommenIsActiveRE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActıve",
                table: "ProductComments",
                newName: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ProductComments",
                newName: "IsActıve");
        }
    }
}
