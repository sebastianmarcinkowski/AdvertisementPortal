using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvertisementPortal.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddImagetoAdvertisementTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Advertisements",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Advertisements");
        }
    }
}
