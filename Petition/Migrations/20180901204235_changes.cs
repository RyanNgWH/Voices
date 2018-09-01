using Microsoft.EntityFrameworkCore.Migrations;

namespace Petition.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "PetitionModel");

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "PetitionModel",
                nullable: true,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "PetitionModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "PetitionModel",
                nullable: false,
                defaultValue: "");
        }
    }
}
