using RentWheelzDataAccessLayer.Models;
using RentWheelzDataAccessLayer.Repositories;

namespace RentWheelzWebApi.Services
{
    public class RentWheelzReservationService
    {
        // Create a private instance of the RentWheelzReservationRepository
        private readonly RentWheelzReservationRepository _rentWheelzReservationRepository;
        private readonly RentWheelzVehicleRepository _rentWheelzVehicleRepository;
        private readonly RentWheelzUserRepository _rentWheelzUserRepository;

        // Create a constructor for the RentWheelzReservationService
        public RentWheelzReservationService()
        {
            // Instantiate the RentWheelzReservationRepository
            _rentWheelzReservationRepository = new RentWheelzReservationRepository();
            _rentWheelzVehicleRepository = new RentWheelzVehicleRepository();
            _rentWheelzUserRepository = new RentWheelzUserRepository();
        }

        // Create a method to get all reservations
        public List<Reservation> GetReservations()
        {
            // Call the GetReservations method from the RentWheelzReservationRepository
            return _rentWheelzReservationRepository.GetReservations();
        }

        // Create a method to get a reservation by id, fill vehicle and user, use exception handling and return a reservation
        public Reservation GetReservationById(int reservationId)
        {
            // Call the GetReservationById method from the RentWheelzReservationRepository
            var reservation = _rentWheelzReservationRepository.GetReservationById(reservationId);

            // check if vehicle exists and then fill vehicle from a reservation
            // check if user exists and then fill user from a reservation
            if (reservation != null)
            {
                reservation.Vehicle = _rentWheelzVehicleRepository.GetVehicleById(reservation.VehicleId);
                reservation.User = _rentWheelzUserRepository.GetUserById(reservation.UserId);
            }

            return new Reservation();
        }

        // Create a method to add a reservation, use exception handling and return a boolean
        public bool AddReservation(Reservation reservation)
        {
            // Call the AddReservation method from the RentWheelzReservationRepository
            return _rentWheelzReservationRepository.AddReservation(reservation);
        }

        // Create a method to cancel a reservation, use exception handling and return a boolean
        public bool CancelReservation(int reservationId)
        {
            // Call the CancelReservation method from the RentWheelzReservationRepository
            return _rentWheelzReservationRepository.CancelReservation(reservationId);
        }

        // Create a method to close a reservation, use exception handling and return a boolean
        public bool CloseReservation(int reservationId)
        {
            // Call the CloseReservation method from the RentWheelzReservationRepository
            return _rentWheelzReservationRepository.CloseReservation(reservationId);
        }
    }
}
