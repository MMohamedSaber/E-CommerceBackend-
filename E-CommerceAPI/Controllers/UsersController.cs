using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Models;
using E_CommerceBuisnessLayer.Sevices.UserSevice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceAPI.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("AddNewUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> AddNewUser(CreateUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is required"); // Validation: Check if the request body is null
            }

            if (string.IsNullOrWhiteSpace(userDto.FirstName))
            {
                return BadRequest("First Name is required"); // Validation: First name should not be empty
            }

            if (string.IsNullOrWhiteSpace(userDto.LastName))
            {
                return BadRequest("Last Name is required"); // Validation: Last name should not be empty
            }

            if (!IsValidEmail(userDto.Email))
            {
                return BadRequest("Invalid Email Format"); // Validation: Email format should be valid
            }

            if (string.IsNullOrWhiteSpace(userDto.PhoneNumber) || userDto.PhoneNumber.Length != 11)
            {
                return BadRequest("Invalid Phone Number"); // Validation: Phone number should be 11 digits
            }

            if (string.IsNullOrWhiteSpace(userDto.Password) || userDto.Password.Length < 6)
            {
                return BadRequest("Password must be at least 6 characters long"); // Validation: Password length should be >= 6
            }

            var userToSave =  await _userService.addNewUser(userDto);

            if (userToSave == null)
            {
                return NotFound("User could not be created"); // Validation: Handle service failure
            }

            return Ok(userToSave);

        }


        [HttpPost("LogInUsingEmailAndPassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> Login(string Email, string Password)
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrEmpty(Password))
             return BadRequest("Invalid Email and Password");
            
            if (!await _userService.IsEmailExist(Email))
                return BadRequest("The Email Is not Exist");

            if (!IsValidEmail(Email))
                return BadRequest("Invalid Email");

            if (!await _userService.LoginUsingEmailPasswordExist(Email, Password))
                return Unauthorized("Invalid password");

            var user = await _userService.GetUserByEmail(Email);

            return Ok(user);
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var emailAddress = new System.Net.Mail.MailAddress(email);
                return emailAddress.Address == email;
            }
            catch
            {
                return false;
            }

        }
    }
}