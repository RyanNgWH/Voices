using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Petition.Migrations
{
    public partial class PetitionSignature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetitionModel",
                columns: table => new
                {
                    PetitionModelId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Votes = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetitionModel", x => x.PetitionModelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetitionModel");
        }
    }
}
