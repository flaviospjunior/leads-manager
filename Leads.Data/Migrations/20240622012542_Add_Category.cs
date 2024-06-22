using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leads.Data.Migrations
{
    public partial class Add_Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Leads",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leads_CategoryId",
                table: "Leads",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Category_CategoryId",
                table: "Leads",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Category_CategoryId",
                table: "Leads");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Leads_CategoryId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Leads");
        }
    }
}
