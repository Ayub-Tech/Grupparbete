using System;
using System.Collections.Generic;

namespace Groupwork____Ayub_Mohamud.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }  // Primary Key
    public string LicensePlate { get; set; } = null!;
    public string OwnerName { get; set; } = null!;
    public string VehicleType { get; set; } = null!;

    // En bil kan ha flera parkeringstransaktioner
    public virtual ICollection<ParkingTransaction> ParkingTransactions { get; set; } = new List<ParkingTransaction>();
}
