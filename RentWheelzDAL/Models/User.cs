using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentWheelzDataAccessLayer.Models;

public partial class User
{
    public int UserId { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Email { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string Password { get; set; } = null!;

    [MaxLength(50)]
    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
