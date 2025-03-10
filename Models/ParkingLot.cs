using System;
using System.Collections.Generic;

namespace Groupwork____Ayub_Mohamud.Models;

public partial class ParkingLot
{
    public int LotId { get; set; }  // Primary Key
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public int Capacity { get; set; }

    public virtual ICollection<ParkingTransaction> ParkingTransactions { get; set; } = new List<ParkingTransaction>();
}
