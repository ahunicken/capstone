using RentWheelzDataAccessLayer.Models;

namespace RentWheelzDataAccessLayer.Repositories
{
    public interface IRentWheelzReservationRepository
    {
        List<Reservation> GetReservations();
        Reservation? GetReservationById(int reservationId);
        bool AddReservation(Reservation reservation);
        bool CancelReservation(int reservationId);
        bool CloseReservation(int reservationId);
        List<Reservation> GetReservationsByUserId(int userId);
    }
}
