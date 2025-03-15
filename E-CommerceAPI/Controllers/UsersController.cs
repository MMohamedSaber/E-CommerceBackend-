using E_CommerceAPI.helper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.user;
using E_CommerceBuisnessLayer.Models;
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

        [HttpPost("add-new")]
        public async Task<IActionResult> AddNewUser(CreateUserDto userDto)
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

            try
            {

            var userToSave =  await _userService.addNewUser(userDto);
                if (userToSave != null)
                {
                  return Ok(userToSave);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, ex.Message));
            }

                return NotFound("User could not be created"); // Validation: Handle service failure

        }


        [HttpPost("loginbyEmailandAddress")]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrEmpty(Password))
                return BadRequest("Invalid Email and Password");


            if (!IsValidEmail(Email))
                return BadRequest("Invalid Email");

            if (!await _userService.LoginUsingEmailPasswordExist(Email, Password))
                return Unauthorized("Invalid password");

            try
            {

            var user = await _userService.GetUserByEmail(Email);
            return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, ex.Message));
            }

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