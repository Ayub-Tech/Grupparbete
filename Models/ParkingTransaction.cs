using System;
using System.Collections.Generic;

namespace Groupwork____Ayub_Mohamud.Models;
public class ParkingTransaction
{
    public int TransactionId { get; set; }
    public int ParkingLotId { get; set; }  // Foreign Key
    public int VehicleId { get; set; }  // Foreign Key
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public double Fee { get; set; }

    public virtual ParkingLot ParkingLot { get; set; }
    public virtual Vehicle Vehicle { get; set; }
}
