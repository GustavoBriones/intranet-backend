using Microsoft.EntityFrameworkCore.Migrations;

namespace BusinessLogic.Identity.Migrations
{
    public partial class ModUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApellidoMaterno",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ApellidoPaterno",
                table: "AspNetUsers",
                newName: "Apellidos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Apellidos",
                table: "AspNetUsers",
                newName: "ApellidoPaterno");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoMaterno",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
