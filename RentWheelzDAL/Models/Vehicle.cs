using System;
using System.Collections.Generic;

namespace RentWheelzDataAccessLayer.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public string RegistrationNumber { get; set; } = null!;

    public decimal Price { get; set; }

    public bool Available { get; set; }

    public string Thumbail { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
