using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    /// <inheritdoc />
    public partial class ThirdInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressTo_City",
                table: "PrivateMoves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressTo_Country",
                table: "PrivateMoves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressTo_Street",
                table: "PrivateMoves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AddressTo_ZipCode",
                table: "PrivateMoves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "PrivateMoves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LoadingDate",
                table: "PrivateMoves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PrivateMoves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Packing",
                table: "PrivateMoves",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PackingDate",
                table: "PrivateMoves",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PackingPaper",
                table: "PrivateMoves",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Phone",
                table: "PrivateMoves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnloadingDate",
                table: "PrivateMoves",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Unpacking",
                table: "PrivateMoves",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnpackingDate",
                table: "PrivateMoves",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressTo_City",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "AddressTo_Country",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "AddressTo_Street",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "AddressTo_ZipCode",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "LoadingDate",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "Packing",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "PackingDate",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "PackingPaper",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "UnloadingDate",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "Unpacking",
                table: "PrivateMoves");

            migrationBuilder.DropColumn(
                name: "UnpackingDate",
                table: "PrivateMoves");
        }
    }
}
