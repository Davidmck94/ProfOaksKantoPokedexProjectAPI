﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfOaksKantoPokedex.Migrations
{
    /// <inheritdoc />
    public partial class ProfOaksKantoPokedexDbAddDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MovesLearnt",
                type: "TEXT",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "MovesLearnt");
        }
    }
}
