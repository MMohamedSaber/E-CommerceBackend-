using AutoMapper;
using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Interfaces.user;
using E_CommerceBuisnessLayer.Models;


namespace E_CommerceDataAccess.Sevices
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork _work;
        private IMapper _mapper;
        public UserService(IUnitOfWork userRepository, IMapper mapper)
        {
            _work = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> LoginUsingEmailPasswordExist(string email, string password)
        {
            if (await _work.UserRepository.IsEmailPasswordExist(email, password))
                return true;
            else
                throw new ArgumentException("Email and Password are not exist.");

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

             await _work.UserRepository.AddNew(User);
            return User;
        }

        public async Task<bool> IsEmailExist(string Email)
        {
            return await _work.UserRepository.IsEmailExist(Email);
        }

        public async Task<bool> IsUserNameExist(string userName)
        {
            return await _work.UserRepository.IsUserNameExist(userName);
        }

        public async Task<UserDto> GetUserByEmail(string Email)
        {
            var user = await _work.UserRepository.GetUserByEmail(Email);
            return _mapper.Map<UserDto>(user);
        }
    }
}
