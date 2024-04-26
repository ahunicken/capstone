using AutoMapper;
using RentWheelzDataAccessLayer.Models;
using RentWheelzWebApi.Models;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Reservation, ModelReservationApi>();
        CreateMap<User, ModelUserApi>();
        CreateMap<Vehicle, ModelVehicleApi>();
    }
}
