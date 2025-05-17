using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blogSite.Model.Migrations
{
    /// <inheritdoc />
    public partial class NewArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "HomeDetails",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "HomeDetails");
        }
    }
}
