using RentWheelzDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentWheelzDataAccessLayer.Repositories
{
    public class RentWheelzVehicleRepository
    {
        // Add my db context here
        private readonly RentWheelzDbContext _rentWheelzDbContext;

        public RentWheelzVehicleRepository()
        {
            _rentWheelzDbContext = new RentWheelzDbContext();
        }

        // Add GetVehicles method here, please use exception handling, return a list of vehicles
        public List<Vehicle> GetVehicles()
        {
            try
            {
                return _rentWheelzDbContext.Vehicles.ToList();
            }
            catch (Exception e)
            {
                return new List<Vehicle>();
            }
        }

        // Add GetVehicleById method here, please use exception handling, return a vehicle
        public Vehicle GetVehicleById(int vehicleId)
        {
            try
            {
                return _rentWheelzDbContext.Vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);
            }
            catch (Exception e)
            {
                return new Vehicle();
            }
        }

        // Add AddVehicle method here, please use exception handling, return a boolean
        public bool AddVehicle(Vehicle vehicle)
        {
            try
            {
                _rentWheelzDbContext.Vehicles.Add(vehicle);
                _rentWheelzDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // Add UpdateVehicle method here, please use exception handling, return a boolean
        public bool UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                var vehicleFromDb = _rentWheelzDbContext.Vehicles.FirstOrDefault(v => v.VehicleId == vehicle.VehicleId);
                if (vehicleFromDb != null)
                {
                    vehicleFromDb.Model = vehicle.Model;
                    vehicleFromDb.Year = vehicle.Year;
                    vehicleFromDb.RegistrationNumber = vehicle.RegistrationNumber;
                    vehicleFromDb.Price = vehicle.Price;
                    vehicleFromDb.Available = vehicle.Available;
                    vehicleFromDb.Thumbail = vehicle.Thumbail;
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

        // Add DeleteVehicle method here, please use exception handling, return a boolean
        public bool DeleteVehicle(int vehicleId)
        {
            try
            {
                var vehicleFromDb = _rentWheelzDbContext.Vehicles.FirstOrDefault(v => v.VehicleId == vehicleId);
                if (vehicleFromDb != null)
                {
                    _rentWheelzDbContext.Vehicles.Remove(vehicleFromDb);
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

        // Add GetAvailableVehicles method here, please use exception handling, return a list of vehicles
        public List<Vehicle> GetAvailableVehicles()
        {
            try
            {
                return _rentWheelzDbContext.Vehicles.Where(v => v.Available == true).ToList();
            }
            catch (Exception e)
            {
                return new List<Vehicle>();
            }
        }

        // Add GetVehicleByRegistrationNumber method here, please use exception handling, return a vehicle
        public Vehicle? GetVehicleByRegistrationNumber(string registrationNumber)
        {
            try
            {
                return _rentWheelzDbContext.Vehicles.FirstOrDefault(v => v.RegistrationNumber == registrationNumber);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        // Add GetVehicleByModel method here, please use exception handling
        public List<Vehicle> GetVehicleByModel(string model)
        {
            try
            {
                return _rentWheelzDbContext.Vehicles.Where(v => v.Model == model).ToList();
            }
            catch (Exception e)
            {
                return new List<Vehicle>();
            }
        }

        // Add GetVehicleByPrice method here, please use exception handling, return a list of vehicles
        public List<Vehicle> GetVehicleByPrice(decimal price)
        {
            try
            {
                return _rentWheelzDbContext.Vehicles.Where(v => v.Price == price).ToList();
            }
            catch (Exception e)
            {
                return new List<Vehicle>();
            }
        }

        // Add GetVehicleByYear method here, please use exception handling, return a list of vehicles
        public List<Vehicle> GetVehicleByYear(int year)
        {
            try
            {
                return _rentWheelzDbContext.Vehicles.Where(v => v.Year == year).ToList();
            }
            catch (Exception e)
            {
                return new List<Vehicle>();
            }
        }

        // Add GetVehicleByThumbail method here, please use exception handling, return a vehicle
        public Vehicle? GetVehicleByThumbail(string thumbail)
        {
            try
            {
                return _rentWheelzDbContext.Vehicles.FirstOrDefault(v => v.Thumbail == thumbail);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
