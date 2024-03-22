using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SongRecommendation.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedIdToUserSong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserSongs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserSongs");
        }
    }
}
