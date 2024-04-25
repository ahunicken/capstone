using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentWheelzDataAccessLayer.Models;
using RentWheelzDataAccessLayer.Repositories;

namespace RentWheelzWebApi.Controllers
{
    /// <summary>
    /// Controller for managing RentWheelz users.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RentWheelzUserController : Controller
    {
        private readonly RentWheelzUserRepository _rentWheelzUserRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentWheelzUserController"/> class.
        /// </summary>
        public RentWheelzUserController()
        {
            _rentWheelzUserRepository = new RentWheelzUserRepository();
        }

        /// <summary>
        /// Registers a user.
        /// </summary>
        /// <param name="user">The user object containing the user details.</param>
        /// <returns>A JSON result indicating the success or failure of the registration.</returns>
        [HttpPost]
        [Route("RegisterUser")]
        public JsonResult RegisterUser([FromBody] User user)
        {
            var result = _rentWheelzUserRepository.RegisterUser(user);

            if (result)
            {
                return new JsonResult(new { message = "User successfully registered." });
            }
            else
            {
                return new JsonResult(new { message = "Registration failed." });
            }
        }

        /// <summary>
        /// Logs in a user.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A JSON result indicating the success or failure of the login.</returns>
        [HttpGet]
        [Route("LoginUser")]
        public JsonResult LoginUser([FromQuery] string email, [FromQuery] string password)
        {
            User user = new User
            {
                Email = email,
                Password = password
            };

            var result = _rentWheelzUserRepository.LoginUser(user);

            if (result)
            {
                return new JsonResult(new { message = "User successfully logged in." });
            }
            else
            {
                return new JsonResult(new { message = "Login failed." });
            }
        }
    }
}
