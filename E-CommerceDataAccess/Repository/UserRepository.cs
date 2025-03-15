using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces.user;
using E_CommerceBuisnessLayer.Models;
using E_CommerceDataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceDataAccess.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext _context) : base(_context)
        { }

        public async Task<User> GetUserByEmail(string Email)
        {
            return await _context.users.SingleOrDefaultAsync(u=>u.Email==Email);
        }

        public async Task<bool> IsEmailExist(string Email)
        {
           var isExist= await _context.users.AnyAsync(u=> u.Email == Email);
            return isExist;
        }

        public async Task<bool> IsEmailPasswordExist(string Email, string Password)
        {
            var isExist= await _context.users.AnyAsync(u => u.Email == Email && u.Password == Password);
            return isExist;
        }

        public async Task<bool> IsUserNameExist(string UserName)
        {
               var Exist= await _context.users.AnyAsync(u => u.UserName == UserName);
            return Exist == true;
        }

    }
}
