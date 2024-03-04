using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinksEncurtador.Core.Migrations
{
    /// <inheritdoc />
    public partial class RemovedTimeSpan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeconds",
                table: "URLsEncurtadas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableSeconds",
                table: "URLsEncurtadas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
