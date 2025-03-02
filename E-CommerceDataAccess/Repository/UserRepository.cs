using E_CommerceBuisnessLayer.DTOs;
using E_CommerceBuisnessLayer.Interfaces;
using E_CommerceBuisnessLayer.Models;
using E_CommerceDataAccess.Data;
using Microsoft.EntityFrameworkCore;
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
           return await _context.users.AnyAsync(u=> u.Email == Email);
        }

        public async Task<bool> IsEmailPasswordExist(string Email, string Password)
        {
            return await _context.users.AnyAsync(u => u.Email == Email && u.Password == Password);
        }

        public async Task<bool> IsUserNameExist(string UserName)
        {
            return await _context.users.AnyAsync(u => u.UserName == UserName);
        }

    }
}
