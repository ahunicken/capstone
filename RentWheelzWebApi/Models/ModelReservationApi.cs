using RentWheelzDataAccessLayer.Models;

namespace RentWheelzWebApi.Models
{
    public sealed class ModelReservationApi
    {
        public int ReservationId { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
