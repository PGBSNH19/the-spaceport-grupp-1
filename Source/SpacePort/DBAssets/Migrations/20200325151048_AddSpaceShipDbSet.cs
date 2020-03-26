using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePort.Migrations
{
    public partial class AddSpaceShipDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpaceShipID",
                table: "Person");

            migrationBuilder.CreateTable(
                name: "SpaceShip",
                columns: table => new
                {
                    SpaceShipID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Length = table.Column<double>(nullable: false),
                    OwnerPersonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceShip", x => x.SpaceShipID);
                    table.ForeignKey(
                        name: "FK_SpaceShip_Person_OwnerPersonID",
                        column: x => x.OwnerPersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpaceShip_OwnerPersonID",
                table: "SpaceShip",
                column: "OwnerPersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpaceShip");

            migrationBuilder.AddColumn<int>(
                name: "SpaceShipID",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
