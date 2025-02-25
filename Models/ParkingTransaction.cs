using System;
using System.Collections.Generic;

namespace Groupwork____Ayub_Mohamud.Models;

public class ParkingTransaction
{
    public int TransactionId { get; set; }
    public int LotId { get; set; }  // Foreign Key
    public int VehicleId { get; set; }  // Foreign Key
    public DateTime EntryTime { get; set; }
    public DateTime? ExitTime { get; set; }
    public decimal Fee { get; set; }

    // ✅ Add these navigation properties
    public virtual ParkingLot ParkingLot { get; set; }
    public virtual Vehicle Vehicle { get; set; }
}
