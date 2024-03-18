using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Autopiter.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrintDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConnectionType = table.Column<int>(type: "int", nullable: false),
                    MacAdress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintDevices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyBranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_CompanyBranches_CompanyBranchId",
                        column: x => x.CompanyBranchId,
                        principalTable: "CompanyBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Installations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyBranchId = table.Column<int>(type: "int", nullable: false),
                    PrintingDeviceId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    UseIndicator = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Installations_CompanyBranches_CompanyBranchId",
                        column: x => x.CompanyBranchId,
                        principalTable: "CompanyBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Installations_PrintDevices_PrintingDeviceId",
                        column: x => x.PrintingDeviceId,
                        principalTable: "PrintDevices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CompanyBranches",
                columns: new[] { "Id", "LocationName", "Name" },
                values: new object[,]
                {
                    { 1, "Тридевятое царство", null },
                    { 2, "Дремучий лес", null },
                    { 3, "Луна", null }
                });

            migrationBuilder.InsertData(
                table: "PrintDevices",
                columns: new[] { "Id", "ConnectionType", "MacAdress", "Name" },
                values: new object[,]
                {
                    { 1, 0, null, "Папирус" },
                    { 2, 0, null, "Бумага" },
                    { 3, 1, null, "Камень" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyBranchId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Царь" },
                    { 2, 1, "Добрыня" },
                    { 3, 2, "Яга" },
                    { 4, 3, "Копатыч" },
                    { 5, 3, "Кощей" },
                    { 6, 3, "Лосяш" }
                });

            migrationBuilder.InsertData(
                table: "Installations",
                columns: new[] { "Id", "CompanyBranchId", "Name", "OrderNumber", "PrintingDeviceId", "UseIndicator" },
                values: new object[,]
                {
                    { 1, 1, "Дворец", 1, 1, true },
                    { 2, 1, "Конюшни", 2, 2, false },
                    { 3, 1, "Оружейная", 3, 2, false },
                    { 4, 3, "Кратер", 1, 3, true },
                    { 5, 2, "Избушка", 3, 2, false },
                    { 6, 2, "Топи", 2, 1, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyBranchId",
                table: "Employees",
                column: "CompanyBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Installations_CompanyBranchId",
                table: "Installations",
                column: "CompanyBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Installations_PrintingDeviceId",
                table: "Installations",
                column: "PrintingDeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Installations");

            migrationBuilder.DropTable(
                name: "CompanyBranches");

            migrationBuilder.DropTable(
                name: "PrintDevices");
        }
    }
}
