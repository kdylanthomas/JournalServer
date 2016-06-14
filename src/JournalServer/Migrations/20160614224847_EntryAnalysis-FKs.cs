using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JournalServer.Migrations
{
    public partial class EntryAnalysisFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EntryAnalysis_UserId",
                table: "EntryAnalysis",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryAnalysis_User_UserId",
                table: "EntryAnalysis",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryAnalysis_User_UserId",
                table: "EntryAnalysis");

            migrationBuilder.DropIndex(
                name: "IX_EntryAnalysis_UserId",
                table: "EntryAnalysis");
        }
    }
}
