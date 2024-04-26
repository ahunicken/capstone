using System;
using System.Collections.Generic;

namespace RentWheelzDataAccessLayer.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int UserId { get; set; }

    public int VehicleId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Status { get; set; } = null!;

    public int Duration { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual Vehicle Vehicle { get; set; } = null!;
}
