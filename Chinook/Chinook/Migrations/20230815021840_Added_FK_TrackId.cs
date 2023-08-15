using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chinook.Migrations
{
    /// <inheritdoc />
    public partial class Added_FK_TrackId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PlaylistId",
                table: "Track",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TrackId",
                table: "Playlist",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Track");

            migrationBuilder.DropColumn(
                name: "TrackId",
                table: "Playlist");
        }
    }
}
