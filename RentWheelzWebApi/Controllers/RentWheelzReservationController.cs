using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RentWheelzDataAccessLayer.Models;
using RentWheelzWebApi.Services;

namespace RentWheelzWebApi.Controllers
{
    /// <summary>
    /// Controller for managing reservations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RentWheelzReservationController : ControllerBase
    {
        private readonly RentWheelzReservationService _rentWheelzReservationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentWheelzReservationController"/> class.
        /// </summary>
        public RentWheelzReservationController(IMapper mapper)
        {
            _rentWheelzReservationService = new RentWheelzReservationService(mapper);
        }

        /// <summary>
        /// Get all reservations.
        /// </summary>
        /// <returns>A list of reservations.</returns>
        [HttpGet]
        [Route("GetReservations")]
        public IActionResult GetReservations()
        {
            var reservations = _rentWheelzReservationService.GetReservations();
            return Ok(reservations);
        }

        /// <summary>
        /// Get a reservation by ID.
        /// </summary>
        /// <param name="reservationId">The ID of the reservation.</param>
        /// <returns>A JSON result containing the reservation and a message indicating success or failure.</returns>
        [HttpGet]
        [Route("GetReservationById")]
        public JsonResult GetReservationById([FromQuery] int reservationId)
        {
            var reservation = _rentWheelzReservationService.GetReservationById(reservationId);

            if (reservation != null)
            {
                return new JsonResult(new { reservation, message = "Reservation successfully loaded." });
            }
            else
            {
                return new JsonResult(new { message = "Reservation not found." });
            }
        }

        /// <summary>
        /// Add a new reservation.
        /// </summary>
        /// <param name="reservation">The reservation to add.</param>
        /// <returns>A JSON result with a message indicating success or failure.</returns>
        [HttpPost]
        [Route("AddReservation")]
        public JsonResult AddReservation([FromBody] Reservation reservation)
        {
            var result = _rentWheelzReservationService.AddReservation(reservation);

            if (result)
            {
                return new JsonResult(new { message = "Reservation successfully added." });
            }
            else
            {
                return new JsonResult(new { message = "Reservation failed." });
            }
        }

        /// <summary>
        /// Cancel a reservation.
        /// </summary>
        /// <param name="reservationId">The ID of the reservation to cancel.</param>
        /// <returns>A JSON result with a message indicating success or failure.</returns>
        [HttpPut]
        [Route("CancelReservation")]
        public JsonResult CancelReservation([FromQuery] int reservationId)
        {
            var result = _rentWheelzReservationService.CancelReservation(reservationId);

            if (result)
            {
                return new JsonResult(new { message = "Reservation successfully cancelled." });
            }
            else
            {
                return new JsonResult(new { message = "Cancellation failed." });
            }
        }

        /// <summary>
        /// Close a reservation.
        /// </summary>
        /// <param name="reservationId">The ID of the reservation to close.</param>
        /// <returns>A JSON result with a message indicating success or failure.</returns>
        [HttpPut]
        [Route("CloseReservation")]
        public JsonResult CloseReservation([FromQuery] int reservationId)
        {
            var result = _rentWheelzReservationService.CloseReservation(reservationId);

            if (result)
            {
                return new JsonResult(new { message = "Reservation successfully closed." });
            }
            else
            {
                return new JsonResult(new { message = "Closing failed." });
            }
        }
    }
}
