using Microsoft.EntityFrameworkCore;
using FinalProject.Models.MoveModels;
using FinalProject.Models.FloorModels;
using FinalProject.Models.InventoryModels;
using FinalProject.Models.RoomModels;

namespace FinalProject.Data
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext(DbContextOptions<FinalProjectContext> options) : base(options) { }


        public DbSet<Move> Moves { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<FloorType> FloorTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryType> InventoryTypes { get; set; }
        public DbSet<Wrapping> Wrapping { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Move>()
                .HasMany(e => e.Addresses)
                .WithOne(e => e.Move)
                .HasForeignKey(e => e.MoveId)
                .IsRequired();

            modelBuilder.Entity<Move>()
                .HasOne(e => e.Amenities)
                .WithOne(e => e.Move)
                .HasForeignKey<Amenities>(e => e.MoveId)
                .IsRequired();

            modelBuilder.Entity<Move>()
                .HasMany(e => e.Floors)
                .WithOne(e => e.Move)
                .HasForeignKey(e => e.MoveId)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

    }
}
