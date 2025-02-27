﻿using System;
using System.Linq;
using Groupwork____Ayub_Mohamud.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        using var context = new ParkmanContext();
        InsertVehicles(context);

        Console.WriteLine("1. Parkera fordon\n2. Checka ut fordon\n3. Visa alla parkeringar\nVälj ett alternativ: ");
        var choice = Console.ReadLine();
        if (choice == "1") RegisterParking(context);
        else if (choice == "2") CheckoutVehicle(context);
        else if (choice == "3") DisplayParkingTransactions(context);
        else Console.WriteLine("Ogiltigt val.");
    }

    static void RegisterParking(ParkmanContext context)
    {
        Console.Write("Registreringsnummer: ");
        var vehicle = context.Vehicles.FirstOrDefault(v => v.LicensePlate == Console.ReadLine());
        if (vehicle == null) { Console.WriteLine("Fordon ej registrerat."); return; }

        Console.Write("Parkeringsplats-ID: ");
        if (!int.TryParse(Console.ReadLine(), out int lotId)) { Console.WriteLine("Ogiltigt ID."); return; }

        context.ParkingTransactions.Add(new ParkingTransaction { VehicleId = vehicle.VehicleId, ParkingLotId = lotId, StartTime = DateTime.Now });
        context.SaveChanges();
        Console.WriteLine("Parkering registrerad!");
    }

    static void CheckoutVehicle(ParkmanContext context)
    {
        Console.Write("Registreringsnummer: ");
        var transaction = context.ParkingTransactions.Include(pt => pt.ParkingLot).Include(pt => pt.Vehicle)
            .FirstOrDefault(pt => pt.Vehicle.LicensePlate == Console.ReadLine() && pt.EndTime == null);
        if (transaction == null) { Console.WriteLine("Ingen aktiv parkering hittades."); return; }

        transaction.EndTime = DateTime.Now;
        transaction.Fee = (transaction.EndTime.Value - transaction.StartTime).TotalHours * 20;
        context.SaveChanges();
        Console.WriteLine($"Utcheckning klar. Avgift: {transaction.Fee:C}");
    }

    static void DisplayParkingTransactions(ParkmanContext context)
    {
        context.ParkingTransactions.Include(pt => pt.ParkingLot).Include(pt => pt.Vehicle)
            .ToList().ForEach(transaction => Console.WriteLine($"ID: {transaction.TransactionId}, Plats: {transaction.ParkingLot?.Name ?? "Okänd"}, Fordon: {transaction.Vehicle?.LicensePlate ?? "Okänt"}, Avgift: {transaction.Fee:C}"));
    }

    static void InsertVehicles(ParkmanContext context)
    {
        if (context.Vehicles.Any()) { Console.WriteLine("Fordon redan registrerade."); return; }
        context.Vehicles.AddRange(new Vehicle { LicensePlate = "ABC123", OwnerName = "John Doe", VehicleType = "Car" },
                                  new Vehicle { LicensePlate = "XYZ456", OwnerName = "Jane Doe", VehicleType = "Motorcycle" },
                                  new Vehicle { LicensePlate = "LMN789", OwnerName = "Alice Smith", VehicleType = "Truck" });
        context.SaveChanges();
        Console.WriteLine("Testfordon tillagda.");
    }
}


