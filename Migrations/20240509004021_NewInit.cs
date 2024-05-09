using System;
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
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPhone = table.Column<int>(type: "int", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoadingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Packing = table.Column<bool>(type: "bit", nullable: false),
                    PackingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnloadingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Unpacking = table.Column<bool>(type: "bit", nullable: false),
                    UnpackingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PackingPaper = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hot = table.Column<bool>(type: "bit", nullable: false),
                    Not = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivateMoveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Moves_PrivateMoveId",
                        column: x => x.PrivateMoveId,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_Amenities_Moves_PrivateMoveId",
                        column: x => x.PrivateMoveId,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PrivateMoveId",
                table: "Addresses",
                column: "PrivateMoveId");

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
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Moves");
        }
    }
}
