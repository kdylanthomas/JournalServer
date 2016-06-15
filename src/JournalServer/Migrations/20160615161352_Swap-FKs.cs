using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JournalServer.Migrations
{
    public partial class SwapFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntry_EntryAnalysis_EntryAnalysisId",
                table: "JournalEntry");

            migrationBuilder.DropIndex(
                name: "IX_JournalEntry_EntryAnalysisId",
                table: "JournalEntry");

            migrationBuilder.DropColumn(
                name: "EntryAnalysisId",
                table: "JournalEntry");

            migrationBuilder.AddColumn<int>(
                name: "EntryId",
                table: "EntryAnalysis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EntryAnalysis_EntryId",
                table: "EntryAnalysis",
                column: "EntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryAnalysis_JournalEntry_EntryId",
                table: "EntryAnalysis",
                column: "EntryId",
                principalTable: "JournalEntry",
                principalColumn: "EntryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryAnalysis_JournalEntry_EntryId",
                table: "EntryAnalysis");

            migrationBuilder.DropIndex(
                name: "IX_EntryAnalysis_EntryId",
                table: "EntryAnalysis");

            migrationBuilder.DropColumn(
                name: "EntryId",
                table: "EntryAnalysis");

            migrationBuilder.AddColumn<int>(
                name: "EntryAnalysisId",
                table: "JournalEntry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_EntryAnalysisId",
                table: "JournalEntry",
                column: "EntryAnalysisId");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntry_EntryAnalysis_EntryAnalysisId",
                table: "JournalEntry",
                column: "EntryAnalysisId",
                principalTable: "EntryAnalysis",
                principalColumn: "EntryAnalysisId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
