using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResistenceSocialNetwork.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rebel",
                columns: table => new
                {
                    IdRebel = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ReportTraitor = table.Column<int>(type: "int", nullable: false),
                    Traitor = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rebel", x => x.IdRebel);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    IdInventory = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Resource = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    IdRebel = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.IdInventory);
                    table.ForeignKey(
                        name: "FK_inventory_rebel_IdRebel",
                        column: x => x.IdRebel,
                        principalTable: "rebel",
                        principalColumn: "IdRebel",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    IdLocation = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    GalaxyName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdRebel = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location", x => x.IdLocation);
                    table.ForeignKey(
                        name: "FK_location_rebel_IdRebel",
                        column: x => x.IdRebel,
                        principalTable: "rebel",
                        principalColumn: "IdRebel",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_IdRebel",
                table: "inventory",
                column: "IdRebel");

            migrationBuilder.CreateIndex(
                name: "IX_location_IdRebel",
                table: "location",
                column: "IdRebel",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "rebel");
        }
    }
}
