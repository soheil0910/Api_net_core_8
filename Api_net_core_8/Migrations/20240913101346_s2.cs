using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api_net_core_8.Migrations
{
    /// <inheritdoc />
    public partial class s2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PcFan",
                columns: new[] { "Id", "Model", "Name" },
                values: new object[] { 1, "MASTERLIQUID ML360L V2 ARGB", "MASTERLIQUID" });

            migrationBuilder.InsertData(
                table: "PcCpu",
                columns: new[] { "Id", "Model", "Name", "PcFanId" },
                values: new object[,]
                {
                    { 1, "2023", "I9 13900K", 1 },
                    { 2, "2024", "I9 14900K", 1 }
                });

            migrationBuilder.InsertData(
                table: "PcDetails",
                columns: new[] { "Id", "Description", "MotherBord", "PcCpuId", "Power", "Ram" },
                values: new object[,]
                {
                    { 1, "سه تا صد گونی هزار", "sd10", 1, "120W", "1GB" },
                    { 2, "قول مرحله اخر", "zf10", 2, "2300W", "200GB" }
                });

            migrationBuilder.InsertData(
                table: "Pc",
                columns: new[] { "Id", "DescriptionId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "G1" },
                    { 2, 2, "G2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pc",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pc",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PcDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PcDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PcCpu",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PcCpu",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PcFan",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
