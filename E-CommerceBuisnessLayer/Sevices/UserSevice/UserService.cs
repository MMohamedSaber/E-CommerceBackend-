using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Models;
using System;


namespace E_CommerceBuisnessLayer.Sevices.UserSevice
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> LoginUsingEmailPasswordExist(string email, string password)
        {
            if (await _userRepository.IsEmailPasswordExist(email, password))
                return true;
            else
                return false;
            
        }

        public async Task<User> addNewUser(CreateUserDto userdto)
        {
            if (await IsUserNameExist(userdto.UserName))
            {
                throw new InvalidOperationException("Username already exists.");
            }

            if (!new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(userdto.Email))
            {
                throw new ArgumentException("Invalid email format.");
            }

            if (await IsEmailExist(userdto.Email))
            {
                throw new ArgumentException("Email Is Already Exist Chose another one.");

            }

            var User = _mapper.Map<User>(userdto);

            var user = await _userRepository.AddNew(User);
            return user;
        }

        public async Task<bool> IsEmailExist(string Email)
        {
            return await _userRepository.IsEmailExist(Email);
        }

        public async Task<bool> IsUserNameExist(string userName)
        {
            return await _userRepository.IsUserNameExist(userName);
        }

        public async Task<UserDto> GetUserByEmail(string Email)
        {
            
            var user= await _userRepository.GetUserByEmail(Email);

            return _mapper.Map<UserDto>(user);


        }
    }
}
