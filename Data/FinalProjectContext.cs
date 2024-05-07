using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata;

namespace FinalProject.Data
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext(DbContextOptions<FinalProjectContext> options) : base(options) { }


        public DbSet<PrivateMove> PrivateMoves { get; set; }


     //   public DbSet<MoveAddress> MoveAddresses { get; set; }
        //public DbSet<Amenities> Amenities { get; set; }
        //public DbSet<Elevator> Elevators { get; set; }
        //public DbSet<FurnitureLift> FurnitureLifts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrivateMove>().OwnsOne(
                pm => pm.MovingAddresses, ma =>
                {
                    ma.WithOwner(x => x.Move);
                    ma.Navigation(x => x.Move).UsePropertyAccessMode(PropertyAccessMode.Property);
                    ma.OwnsOne(y => y.From);
                    ma.OwnsOne(y => y.To);
                }

                );

            modelBuilder.Entity<PrivateMove>().OwnsOne(
                pm => pm.Amenities, a =>
                {
                    a.WithOwner(x => x.Move);
                    a.Navigation(x => x.Move).UsePropertyAccessMode(PropertyAccessMode.Property);
                    a.OwnsOne(y => y.Elevator);
                    a.OwnsOne(y => y.FurnitureLift);
                });

            //modelBuilder.Entity<PrivateMove>().OwnsOne(
            //    x => x.MovingAddresses ma => ma.
            //    )

            //modelBuilder.Entity<DetailedOrder>().OwnsOne(p => p.OrderDetails, od => { od.ToTable("OrderDetails"); });



            //        modelBuilder.Entity<DetailedOrder>().OwnsOne(
            //p => p.OrderDetails, od =>
            //{
            //    od.WithOwner(d => d.Order);
            //    od.Navigation(d => d.Order).UsePropertyAccessMode(PropertyAccessMode.Property);
            //    od.OwnsOne(c => c.BillingAddress);
            //    od.OwnsOne(c => c.ShippingAddress);
            //});

            //modelBuilder.Entity<PrivateMove>()
            //    .HasMany(e => e.)
            //    .WithOne(e => e.Move)
            //    .HasForeignKey(e => e.MoveId)
            //    .IsRequired(false);

            //modelBuilder.Entity<Move>()
            //    .HasOne(e => e.ToAddress)
            //    .WithOne(e => e.Move)
            //    .HasForeignKey<Address>(e => e.MoveId)
            //    .IsRequired(false);

            //    modelBuilder.Entity<MoveAddress>()
            //        .HasMany(e => e.Addresses)
            //        .WithOne(e => e.MoveAddress)
            //    .HasForeignKey(e => e.MoveAddressId)
            //.IsRequired(false);


            base.OnModelCreating(modelBuilder);
        }

    }
}
