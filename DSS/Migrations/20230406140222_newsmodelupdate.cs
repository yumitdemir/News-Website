using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSS.Migrations
{
    /// <inheritdoc />
    public partial class newsmodelupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "NewsId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailImgUrl",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailImgUrl",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewsId",
                table: "Comments",
                type: "int",
                nullable: true);
        }
    }
}
