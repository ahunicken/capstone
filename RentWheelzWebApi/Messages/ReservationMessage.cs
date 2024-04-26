using RentWheelzWebApi.Models;

namespace RentWheelzWebApi.Messages
{
    public class ReservationMessage
    {
        public ModelReservationApi Reservation { get; set; }

        public string Message { get; set; }
    }
}
