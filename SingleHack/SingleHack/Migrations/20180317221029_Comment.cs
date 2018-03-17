using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SingleHack.Migrations
{
    public partial class Comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Matcher");

            migrationBuilder.DropColumn(
                name: "ReturnUrl",
                table: "Matcher");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Person",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Matcher",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReturnUrl",
                table: "Matcher",
                nullable: true);
        }
    }
}
