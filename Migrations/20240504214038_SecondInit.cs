using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class SecondInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Amenities_Elevator_FromAddress",
                table: "PrivateMoves",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Amenities_Elevator_ToAddress",
                table: "PrivateMoves",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Amenities_FurnitureLift_FromAddress",
                table: "PrivateMoves",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Amenities_FurnitureLift_ToAddress",
                table: "PrivateMoves",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amenities_Elevator_FromAddress",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "Amenities_Elevator_ToAddress",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "Amenities_FurnitureLift_FromAddress",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "Amenities_FurnitureLift_ToAddress",
                table: "PrivateMoves");
        }
    }
}
