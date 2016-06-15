using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JournalServer.Migrations
{
    public partial class UserHrefs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Entries",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EntryAnalyses",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entries",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EntryAnalyses",
                table: "User");
        }
    }
}
