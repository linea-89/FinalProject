using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class NewInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrivateMoves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovingAddresses_From_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovingAddresses_From_ZipCode = table.Column<int>(type: "int", nullable: false),
                    MovingAddresses_From_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovingAddresses_From_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovingAddresses_To_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovingAddresses_To_ZipCode = table.Column<int>(type: "int", nullable: false),
                    MovingAddresses_To_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovingAddresses_To_Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateMoves", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrivateMoves");
        }
    }
}
