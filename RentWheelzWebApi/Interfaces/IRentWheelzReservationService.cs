using RentWheelzDataAccessLayer.Models;
using RentWheelzWebApi.Models;

namespace RentWheelzWebApi.Interfaces
{
    public interface IRentWheelzReservationService
    {
        List<Reservation> GetReservations();
        ModelReservationApi GetReservationById(int reservationId);
        bool AddReservation(Reservation reservation);
        bool CancelReservation(int reservationId);
        bool CloseReservation(int reservationId);
    }
}
