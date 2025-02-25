using System;
using System.Linq;
using Groupwork____Ayub_Mohamud.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        using (var context = new ParkmanContext())
        {
            // Insert vehicles if not already present (this is just an example)
            InsertVehicles(context);

            // Retrieve parking transactions with related parking lot and vehicle data
            var transactions = context.ParkingTransactions
                                      .Include(pt => pt.ParkingLot)  // Include ParkingLot data
                                      .Include(pt => pt.Vehicle)      // Include Vehicle data
                                      .ToList();

            // Display transactions
            Console.WriteLine("\n🚗 Parking Transactions:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Transaction: {transaction.TransactionId}, " +
                                  $"Parking Lot: {transaction.ParkingLot?.Name ?? "Unknown Lot"}, " +
                                  $"Vehicle: {transaction.Vehicle?.LicensePlate ?? "Unknown Vehicle"}, " +
                                  $"Fee: {transaction.Fee:C}");
            }
        }
    }

    // Method to insert test vehicles if not already present
    public static void InsertVehicles(ParkmanContext context)
    {
        // Check if there are already vehicles in the Vehicle table
        if (!context.Vehicles.Any())
        {
            context.Vehicles.AddRange(
                new Vehicle { LicensePlate = "ABC123", OwnerName = "John Doe", VehicleType = "Car" },
                new Vehicle { LicensePlate = "XYZ456", OwnerName = "Jane Doe", VehicleType = "Motorcycle" },
                new Vehicle { LicensePlate = "LMN789", OwnerName = "Alice Smith", VehicleType = "Truck" }
            );

            context.SaveChanges();
            Console.WriteLine("Test vehicles have been added to the database.");
        }
        else
        {
            Console.WriteLine("Vehicles already exist in the database.");
        }
    }
}

