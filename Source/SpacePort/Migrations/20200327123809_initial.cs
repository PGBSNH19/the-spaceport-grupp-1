using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePort.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonInfo",
                columns: table => new
                {
                    PersonDbModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Wallet = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInfo", x => x.PersonDbModelId);
                });

            migrationBuilder.CreateTable(
                name: "SpaceshipInfo",
                columns: table => new
                {
                    SpaceshipDbModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Length = table.Column<double>(nullable: false),
                    PersonDbModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceshipInfo", x => x.SpaceshipDbModelId);
                    table.ForeignKey(
                        name: "FK_SpaceshipInfo_PersonInfo_PersonDbModelId",
                        column: x => x.PersonDbModelId,
                        principalTable: "PersonInfo",
                        principalColumn: "PersonDbModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpaceInfo",
                columns: table => new
                {
                    ParkingSpaceDbModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpaceshipDbModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpaceInfo", x => x.ParkingSpaceDbModelId);
                    table.ForeignKey(
                        name: "FK_ParkingSpaceInfo_SpaceshipInfo_SpaceshipDbModelId",
                        column: x => x.SpaceshipDbModelId,
                        principalTable: "SpaceshipInfo",
                        principalColumn: "SpaceshipDbModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpaceInfo_SpaceshipDbModelId",
                table: "ParkingSpaceInfo",
                column: "SpaceshipDbModelId",
                unique: true,
                filter: "[SpaceshipDbModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceshipInfo_PersonDbModelId",
                table: "SpaceshipInfo",
                column: "PersonDbModelId",
                unique: true,
                filter: "[PersonDbModelId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSpaceInfo");

            migrationBuilder.DropTable(
                name: "SpaceshipInfo");

            migrationBuilder.DropTable(
                name: "PersonInfo");
        }
    }
}
