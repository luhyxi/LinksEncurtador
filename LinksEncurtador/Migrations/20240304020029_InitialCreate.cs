using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinksEncurtador.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "URLsEncurtadas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OriginalURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortenedURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    AvailableSeconds = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLsEncurtadas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_URLsEncurtadas_Code",
                table: "URLsEncurtadas",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "URLsEncurtadas");
        }
    }
}
