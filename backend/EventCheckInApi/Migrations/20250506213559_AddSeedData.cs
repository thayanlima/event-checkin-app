using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventCheckInApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Communities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Feira de Startups" },
                    { 4, "Hackathon Global" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CheckInAt", "CheckOutAt", "CommunityId", "Company", "FirstName", "LastName", "Title" },
                values: new object[,]
                {
                    { 2, null, null, 2, "DevHouse", "Maria", "Souza", "Product Manager" },
                    { 3, null, null, 1, "InovaTech", "Carlos", "Pereira", "CTO" },
                    { 6, null, null, 2, "AppFlow", "Ana", "Costa", "QA Engineer" },
                    { 7, null, null, 1, "BitWise", "Rafael", "Martins", "Engenheiro de Software" },
                    { 10, null, null, 2, "DevHouse", "Camila", "Rocha", "Tech Lead" },
                    { 4, null, null, 3, "WebSolutions", "Fernanda", "Dias", "Designer" },
                    { 5, null, null, 4, "CloudX", "Lucas", "Lima", "DevOps" },
                    { 8, null, null, 3, "Tech Corp", "Juliana", "Oliveira", "Scrum Master" },
                    { 9, null, null, 4, "WebSolutions", "Marcos", "Ferreira", "Analista de Sistemas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Communities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Communities",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
