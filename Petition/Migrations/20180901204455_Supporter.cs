using Microsoft.EntityFrameworkCore.Migrations;

namespace Petition.Migrations
{
    public partial class Supporter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Support",
                columns: table => new
                {
                    SupportId = table.Column<string>(nullable: false),
                    PetitionModelId = table.Column<string>(nullable: true),
                    SupporterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Support", x => x.SupportId);
                    table.ForeignKey(
                        name: "FK_Support_PetitionModel_PetitionModelId",
                        column: x => x.PetitionModelId,
                        principalTable: "PetitionModel",
                        principalColumn: "PetitionModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Support_AspNetUsers_SupporterId",
                        column: x => x.SupporterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Support_PetitionModelId",
                table: "Support",
                column: "PetitionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Support_SupporterId",
                table: "Support",
                column: "SupporterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Support");
        }
    }
}
