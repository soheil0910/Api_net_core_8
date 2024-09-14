using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api_net_core_8.Migrations
{
    /// <inheritdoc />
    public partial class s1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxSpeed = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PcFan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcFan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PcCpu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcFanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcCpu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PcCpu_PcFan_PcFanId",
                        column: x => x.PcFanId,
                        principalTable: "PcFan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PcDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherBord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Power = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PcCpuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PcDetails_PcCpu_PcCpuId",
                        column: x => x.PcCpuId,
                        principalTable: "PcCpu",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pc_PcDetails_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "PcDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "Id", "Description", "MaxSpeed", "Name" },
                values: new object[,]
                {
                    { 1, "قوطی روغن نباطی", 120, "پراید" },
                    { 2, "دیوار دفاعی", 110, "پیکان" },
                    { 3, "", 220, "پرشیا" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Family", "Name", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "soheil0910line@gmail.com", "Robaty", "soheil", "1234", "soheil0910" },
                    { 2, null, "Robaty", "ali", "1234", "ali001" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pc_DescriptionId",
                table: "Pc",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PcCpu_PcFanId",
                table: "PcCpu",
                column: "PcFanId");

            migrationBuilder.CreateIndex(
                name: "IX_PcDetails_PcCpuId",
                table: "PcDetails",
                column: "PcCpuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Pc");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PcDetails");

            migrationBuilder.DropTable(
                name: "PcCpu");

            migrationBuilder.DropTable(
                name: "PcFan");
        }
    }
}
