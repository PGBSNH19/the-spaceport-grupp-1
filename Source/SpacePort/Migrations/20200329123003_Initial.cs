using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePort.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Wallet = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Spaceship",
                columns: table => new
                {
                    SpaceshipID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Length = table.Column<double>(nullable: false),
                    PersonID = table.Column<int>(nullable: true),
                    PersonDID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaceship", x => x.SpaceshipID);
                    table.ForeignKey(
                        name: "FK_Spaceship_Person_PersonDID",
                        column: x => x.PersonDID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    PersonID = table.Column<int>(nullable: true),
                    SpaceshipID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoice_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Spaceship_SpaceshipID",
                        column: x => x.SpaceshipID,
                        principalTable: "Spaceship",
                        principalColumn: "SpaceshipID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parkingspace",
                columns: table => new
                {
                    ParkingSpaceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpaceshipID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkingspace", x => x.ParkingSpaceID);
                    table.ForeignKey(
                        name: "FK_Parkingspace_Spaceship_SpaceshipID",
                        column: x => x.SpaceshipID,
                        principalTable: "Spaceship",
                        principalColumn: "SpaceshipID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_PersonID",
                table: "Invoice",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SpaceshipID",
                table: "Invoice",
                column: "SpaceshipID");

            migrationBuilder.CreateIndex(
                name: "IX_Parkingspace_SpaceshipID",
                table: "Parkingspace",
                column: "SpaceshipID",
                unique: true,
                filter: "[SpaceshipID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Spaceship_PersonDID",
                table: "Spaceship",
                column: "PersonDID",
                unique: true,
                filter: "[PersonDID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Parkingspace");

            migrationBuilder.DropTable(
                name: "Spaceship");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
