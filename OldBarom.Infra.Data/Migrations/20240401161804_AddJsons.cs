using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldBarom.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddJsons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectInformations",
                schema: "Portifolio",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectInformations",
                schema: "Portifolio",
                table: "Projects");
        }
    }
}
