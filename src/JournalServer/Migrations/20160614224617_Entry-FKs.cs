using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JournalServer.Migrations
{
    public partial class EntryFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_EntryAnalysisId",
                table: "JournalEntry",
                column: "EntryAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_UserId",
                table: "JournalEntry",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntry_EntryAnalysis_EntryAnalysisId",
                table: "JournalEntry",
                column: "EntryAnalysisId",
                principalTable: "EntryAnalysis",
                principalColumn: "EntryAnalysisId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntry_User_UserId",
                table: "JournalEntry",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntry_EntryAnalysis_EntryAnalysisId",
                table: "JournalEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntry_User_UserId",
                table: "JournalEntry");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntry_EntryAnalysisId",
                table: "JournalEntry");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntry_UserId",
                table: "JournalEntry");
        }
    }
}
