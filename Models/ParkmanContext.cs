using Groupwork____Ayub_Mohamud.Models;
using Microsoft.EntityFrameworkCore;

public class ParkmanContext : DbContext
{
    public DbSet<ParkingLot> ParkingLots { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<ParkingTransaction> ParkingTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=Ayub-Tech\\SQLEXPRESS;Database=parkman;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Definiera primärnyckeln explicit för ParkingLot
        modelBuilder.Entity<ParkingLot>()
            .HasKey(pl => pl.LotId);

        modelBuilder.Entity<ParkingTransaction>()
            .HasKey(pt => pt.TransactionId);

        modelBuilder.Entity<ParkingTransaction>()
            .HasOne(pt => pt.ParkingLot)
            .WithMany(pl => pl.ParkingTransactions)
            .HasForeignKey(pt => pt.ParkingLotId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ParkingTransaction>()
            .HasOne(pt => pt.Vehicle)
            .WithMany(v => v.ParkingTransactions)
            .HasForeignKey(pt => pt.VehicleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
