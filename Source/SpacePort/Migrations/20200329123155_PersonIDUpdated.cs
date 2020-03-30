using Microsoft.EntityFrameworkCore.Migrations;

namespace SpacePort.Migrations
{
    public partial class PersonIDUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spaceship_Person_PersonDID",
                table: "Spaceship");

            migrationBuilder.DropIndex(
                name: "IX_Spaceship_PersonDID",
                table: "Spaceship");

            migrationBuilder.DropColumn(
                name: "PersonDID",
                table: "Spaceship");

            migrationBuilder.CreateIndex(
                name: "IX_Spaceship_PersonID",
                table: "Spaceship",
                column: "PersonID",
                unique: true,
                filter: "[PersonID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Spaceship_Person_PersonID",
                table: "Spaceship",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spaceship_Person_PersonID",
                table: "Spaceship");

            migrationBuilder.DropIndex(
                name: "IX_Spaceship_PersonID",
                table: "Spaceship");

            migrationBuilder.AddColumn<int>(
                name: "PersonDID",
                table: "Spaceship",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spaceship_PersonDID",
                table: "Spaceship",
                column: "PersonDID",
                unique: true,
                filter: "[PersonDID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Spaceship_Person_PersonDID",
                table: "Spaceship",
                column: "PersonDID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
