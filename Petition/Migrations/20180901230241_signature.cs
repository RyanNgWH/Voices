using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Petition.Migrations
{
    public partial class signature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Signature",
                columns: table => new
                {
                    SignatureId = table.Column<string>(nullable: false),
                    PetitionModelId = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SignerId = table.Column<string>(nullable: true),
                    SignatureDetails = table.Column<string>(nullable: true),
                    Traction = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signature", x => x.SignatureId);
                    table.ForeignKey(
                        name: "FK_Signature_PetitionModel_PetitionModelId",
                        column: x => x.PetitionModelId,
                        principalTable: "PetitionModel",
                        principalColumn: "PetitionModelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Signature_AspNetUsers_SignerId",
                        column: x => x.SignerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Signature_PetitionModelId",
                table: "Signature",
                column: "PetitionModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Signature_SignerId",
                table: "Signature",
                column: "SignerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Signature");
        }
    }
}
