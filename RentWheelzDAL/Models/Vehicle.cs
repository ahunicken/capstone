using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentWheelzDataAccessLayer.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Model { get; set; } = null!;

    [Required]
    public int Year { get; set; }

    [Required]
    [MaxLength(50)]
    public string RegistrationNumber { get; set; } = null!;

    [Required]
    public decimal Price { get; set; }

    public bool Available { get; set; }

    [MaxLength(100)]
    public string Thumbail { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
