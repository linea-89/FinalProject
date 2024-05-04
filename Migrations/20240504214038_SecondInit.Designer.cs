﻿// <auto-generated />
using FinalProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalProject.Migrations
{
    [DbContext(typeof(FinalProjectContext))]
    [Migration("20240504214038_SecondInit")]
    partial class SecondInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinalProject.Models.PrivateMove", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("PrivateMoves");
                });

            modelBuilder.Entity("FinalProject.Models.PrivateMove", b =>
                {
                    b.OwnsOne("FinalProject.Models.Amenities", "Amenities", b1 =>
                        {
                            b1.Property<int>("MoveId")
                                .HasColumnType("int");

                            b1.HasKey("MoveId");

                            b1.ToTable("PrivateMoves");

                            b1.WithOwner("Move")
                                .HasForeignKey("MoveId");

                            b1.OwnsOne("FinalProject.Models.Elevator", "Elevator", b2 =>
                                {
                                    b2.Property<int>("AmenitiesMoveId")
                                        .HasColumnType("int");

                                    b2.Property<bool>("FromAddress")
                                        .HasColumnType("bit");

                                    b2.Property<bool>("ToAddress")
                                        .HasColumnType("bit");

                                    b2.HasKey("AmenitiesMoveId");

                                    b2.ToTable("PrivateMoves");

                                    b2.WithOwner()
                                        .HasForeignKey("AmenitiesMoveId");
                                });

                            b1.OwnsOne("FinalProject.Models.FurnitureLift", "FurnitureLift", b2 =>
                                {
                                    b2.Property<int>("AmenitiesMoveId")
                                        .HasColumnType("int");

                                    b2.Property<bool>("FromAddress")
                                        .HasColumnType("bit");

                                    b2.Property<bool>("ToAddress")
                                        .HasColumnType("bit");

                                    b2.HasKey("AmenitiesMoveId");

                                    b2.ToTable("PrivateMoves");

                                    b2.WithOwner()
                                        .HasForeignKey("AmenitiesMoveId");
                                });

                            b1.Navigation("Elevator")
                                .IsRequired();

                            b1.Navigation("FurnitureLift")
                                .IsRequired();

                            b1.Navigation("Move");
                        });

                    b.OwnsOne("FinalProject.Models.MoveAddress", "MovingAddresses", b1 =>
                        {
                            b1.Property<int>("MoveId")
                                .HasColumnType("int");

                            b1.HasKey("MoveId");

                            b1.ToTable("PrivateMoves");

                            b1.WithOwner("Move")
                                .HasForeignKey("MoveId");

                            b1.OwnsOne("FinalProject.Models.Address", "From", b2 =>
                                {
                                    b2.Property<int>("MoveAddressMoveId")
                                        .HasColumnType("int");

                                    b2.Property<string>("City")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Country")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Street")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<int>("ZipCode")
                                        .HasColumnType("int");

                                    b2.HasKey("MoveAddressMoveId");

                                    b2.ToTable("PrivateMoves");

                                    b2.WithOwner()
                                        .HasForeignKey("MoveAddressMoveId");
                                });

                            b1.OwnsOne("FinalProject.Models.Address", "To", b2 =>
                                {
                                    b2.Property<int>("MoveAddressMoveId")
                                        .HasColumnType("int");

                                    b2.Property<string>("City")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Country")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<string>("Street")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<int>("ZipCode")
                                        .HasColumnType("int");

                                    b2.HasKey("MoveAddressMoveId");

                                    b2.ToTable("PrivateMoves");

                                    b2.WithOwner()
                                        .HasForeignKey("MoveAddressMoveId");
                                });

                            b1.Navigation("From")
                                .IsRequired();

                            b1.Navigation("Move");

                            b1.Navigation("To")
                                .IsRequired();
                        });

                    b.Navigation("Amenities")
                        .IsRequired();

                    b.Navigation("MovingAddresses")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
