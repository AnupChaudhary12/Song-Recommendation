﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SongRecommendation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deletedRatingColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "UserSongs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "UserSongs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
