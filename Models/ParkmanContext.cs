using Groupwork____Ayub_Mohamud.Models;
using Microsoft.EntityFrameworkCore;

public class ParkmanContext : DbContext
{
    public DbSet<ParkingLot> ParkingLots { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<ParkingTransaction> ParkingTransactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ParkingTransaction>()
            .HasOne(pt => pt.ParkingLot)  // ✅ Defines relationship
            .WithMany()
            .HasForeignKey(pt => pt.LotId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ParkingTransaction>()
            .HasOne(pt => pt.Vehicle)
            .WithMany()
            .HasForeignKey(pt => pt.VehicleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
