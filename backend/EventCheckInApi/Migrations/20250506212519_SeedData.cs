using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventCheckInApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Communities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Conferência de Tecnologia" },
                    { 2, "Workshop de Desenvolvimento" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CheckInAt", "CheckOutAt", "CommunityId", "Company", "FirstName", "LastName", "Title" },
                values: new object[] { 1, null, null, 1, "Tech Corp", "João", "Silva", "Desenvolvedor" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Communities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Communities",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
