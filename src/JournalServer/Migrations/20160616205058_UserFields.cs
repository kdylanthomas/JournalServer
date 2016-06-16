using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JournalServer.Migrations
{
    public partial class UserFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "User",
                nullable: true);
        }
    }
}
