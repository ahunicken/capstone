using Microsoft.Extensions.Configuration;
using RentWheelzDataAccessLayer.Models;

namespace RentWheelzDataAccessLayer.Repositories
{
    public class RentWheelzUserRepository
    {
        private readonly RentWheelzDbContext _rentWheelzDbContext;

        public RentWheelzUserRepository()
        {
            // Add my db context here
            _rentWheelzDbContext = new RentWheelzDbContext();
        }

        // Add RegisterUser method here, please use exception handling, return a boolean
        public bool RegisterUser(User user)
        {
            try
            {
                _rentWheelzDbContext.Users.Add(user);
                _rentWheelzDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // Add LoginUser method here, please use exception handling, return a boolean
        public bool LoginUser(User user)
        {
            try
            {
                var userFromDb = _rentWheelzDbContext.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                if (userFromDb != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        // Add GetUserById method here, please use exception handling, return a user
        public User? GetUserById(int userId)
        {
            try
            {
                return _rentWheelzDbContext.Users.FirstOrDefault(u => u.UserId == userId);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
