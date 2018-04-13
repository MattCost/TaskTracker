using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TaskApp2.Migrations
{
    public partial class TimeStampTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "TaskTemplate",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "TaskTemplate",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "TaskList",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "TaskList",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "TaskTemplate");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "TaskTemplate");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "TaskList");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "TaskList");
        }
    }
}
