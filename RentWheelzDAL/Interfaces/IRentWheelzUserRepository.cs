using RentWheelzDataAccessLayer.Models;

namespace RentWheelzDataAccessLayer.Repositories
{
    public interface IRentWheelzUserRepository
    {
        bool RegisterUser(User user);
        bool LoginUser(User user);
        User? GetUserById(int userId);
    }
}
