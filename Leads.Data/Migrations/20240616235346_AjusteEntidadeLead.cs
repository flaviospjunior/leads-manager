using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leads.Data.Migrations
{
    public partial class AjusteEntidadeLead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Leads");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactId",
                table: "Leads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SuburbId",
                table: "Leads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suburb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suburb", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leads_ContactId",
                table: "Leads",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_SuburbId",
                table: "Leads",
                column: "SuburbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Contact_ContactId",
                table: "Leads",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Suburb_SuburbId",
                table: "Leads",
                column: "SuburbId",
                principalTable: "Suburb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Contact_ContactId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Suburb_SuburbId",
                table: "Leads");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Suburb");

            migrationBuilder.DropIndex(
                name: "IX_Leads_ContactId",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_SuburbId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "SuburbId",
                table: "Leads");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Leads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
