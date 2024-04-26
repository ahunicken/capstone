using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentWheelzDataAccessLayer.Models;
using RentWheelzDataAccessLayer.Repositories;

namespace RentWheelzWebApi.Controllers
{
    /// <summary>
    /// Controller for managing RentWheelz vehicles.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RentWheelzVehicleController : ControllerBase
    {
        private readonly IRentWheelzVehicleRepository _rentWheelzVehicleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentWheelzVehicleController"/> class.
        /// </summary>
        public RentWheelzVehicleController(IRentWheelzVehicleRepository rentWheelzVehicleRepository)
        {
            _rentWheelzVehicleRepository = rentWheelzVehicleRepository;
        }

        /// <summary>
        /// Gets all vehicles.
        /// </summary>
        /// <returns>A list of vehicles.</returns>
        [HttpGet]
        [Route("GetVehicles")]
        public IActionResult GetVehicles()
        {
            var vehicles = _rentWheelzVehicleRepository.GetVehicles();
            return Ok(vehicles);
        }

        /// <summary>
        /// Gets a vehicle by its ID.
        /// </summary>
        /// <param name="vehicleId">The ID of the vehicle.</param>
        /// <returns>The vehicle with the specified ID.</returns>
        [HttpGet]
        [Route("GetVehicleById")]
        public IActionResult GetVehicleById([FromQuery] int vehicleId)
        {
            var vehicle = _rentWheelzVehicleRepository.GetVehicleById(vehicleId);
            return Ok(vehicle);
        }

        /// <summary>
        /// Adds a new vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        /// <returns>The result of the operation.</returns>
        [HttpPost]
        [Route("AddVehicle")]
        public IActionResult AddVehicle([FromBody] Vehicle vehicle)
        {
            var result = _rentWheelzVehicleRepository.AddVehicle(vehicle);
            return Ok(result);
        }

        /// <summary>
        /// Updates a vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to update.</param>
        /// <returns>The result of the operation.</returns>
        [HttpPut]
        [Route("UpdateVehicle")]
        public IActionResult UpdateVehicle([FromBody] Vehicle vehicle)
        {
            var result = _rentWheelzVehicleRepository.UpdateVehicle(vehicle);
            return Ok(result);
        }
    }
}
