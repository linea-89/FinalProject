using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class NewInit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElevatorFromAddress = table.Column<bool>(type: "bit", nullable: false),
                    ElevatorToAddress = table.Column<bool>(type: "bit", nullable: false),
                    FurnitureLiftFromAddress = table.Column<bool>(type: "bit", nullable: false),
                    FurnitureLiftToAddress = table.Column<bool>(type: "bit", nullable: false),
                    PrivateMoveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenities_PrivateMoves_PrivateMoveId",
                        column: x => x.PrivateMoveId,
                        principalTable: "PrivateMoves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_PrivateMoveId",
                table: "Amenities",
                column: "PrivateMoveId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");
        }
    }
}
