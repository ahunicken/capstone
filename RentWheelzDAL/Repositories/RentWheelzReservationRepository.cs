using Microsoft.Extensions.Configuration;
using RentWheelzDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentWheelzDataAccessLayer.Repositories
{
    public class RentWheelzReservationRepository: IRentWheelzReservationRepository
    {
        // Add my db context here
        private readonly RentWheelzDbContext _rentWheelzDbContext;

        public RentWheelzReservationRepository()
        {
            _rentWheelzDbContext = new RentWheelzDbContext();
        }

        // Add GetReservations method here, please use exception handling, return a list of reservations
        public List<Reservation> GetReservations()
        {
            try
            {
                return _rentWheelzDbContext.Reservations.ToList();
            }
            catch (Exception e)
            {
                return new List<Reservation>();
            }
        }

        // Add GetReservationById method here, please use exception handling, return a reservation
        public Reservation? GetReservationById(int reservationId)
        {
            try
            {
                return _rentWheelzDbContext.Reservations.FirstOrDefault(r => r.ReservationId == reservationId);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // Add AddReservation method here, please use exception handling, return a boolean  
        public bool AddReservation(Reservation reservation)
        {
            try
            {
                reservation.Status = "Reserved";
                _rentWheelzDbContext.Reservations.Add(reservation);
                _rentWheelzDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // Add a CancelReservation method here, please use exception handling, return a boolean
        public bool CancelReservation(int reservationId)
        {
            try
            {
                var reservation = _rentWheelzDbContext.Reservations.FirstOrDefault(r => r.ReservationId == reservationId);
                if (reservation != null)
                {
                    reservation.Status = "Cancelled";
                    _rentWheelzDbContext.Reservations.Update(reservation);
                    _rentWheelzDbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // Add a CloseReservation method here, please use exception handling, return a boolean
        public bool CloseReservation(int reservationId)
        {
            try
            {
                var reservation = _rentWheelzDbContext.Reservations.FirstOrDefault(r => r.ReservationId == reservationId);
                if (reservation != null)
                {
                    reservation.Status = "Closed";
                    _rentWheelzDbContext.Reservations.Update(reservation);
                    _rentWheelzDbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Reservation> GetReservationsByUserId(int userId)
        {
            try
            {
                return _rentWheelzDbContext.Reservations.Where(r => r.UserId == userId).ToList();
            }
            catch (Exception e)
            {
                return new List<Reservation>();
            }
        }
    }
}
