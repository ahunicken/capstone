using RentWheelzDataAccessLayer.Models;

namespace RentWheelzDataAccessLayer.Repositories
{
    public interface IRentWheelzVehicleRepository
    {
        List<Vehicle> GetVehicles();
        Vehicle GetVehicleById(int vehicleId);
        bool AddVehicle(Vehicle vehicle);
        bool UpdateVehicle(Vehicle vehicle);
        bool DeleteVehicle(int vehicleId);
        List<Vehicle> GetAvailableVehicles();
        Vehicle? GetVehicleByRegistrationNumber(string registrationNumber);
        List<Vehicle> GetVehicleByModel(string model);
        List<Vehicle> GetVehicleByPrice(decimal price);
        List<Vehicle> GetVehicleByYear(int year);
        Vehicle? GetVehicleByThumbail(string thumbail);
    }
}
