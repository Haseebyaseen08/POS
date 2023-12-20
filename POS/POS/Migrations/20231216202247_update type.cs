using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Migrations
{
    /// <inheritdoc />
    public partial class updatetype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7939d6ac-482f-4b05-91af-6e350d25b6ae", "AQAAAAIAAYagAAAAEHv6sNVTihckkUuW0+mtv3f4hxMBOgcuEg5w7opgyLkLCgdPXAQytyC2TmzljX0ldQ==", "ac8446c8-aab8-4e10-be34-9b91e1bf7cb0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e683e01f-e40b-4a91-bd9d-5666c101b4e5", "AQAAAAIAAYagAAAAENjsdMkEndaTsbc48Y0pO9GqkY2gOHaRH12w8VFzkFos1SlmZHoa1zY65LDEuDhCxg==", "6f9d934b-c6e6-432a-a44b-9ebba1ac41c9" });
        }
    }
}
