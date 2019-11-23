using IShop.Data;
using IShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IShop.Interfaces
{
    public class UserRepository : IUserRepository
    {
        readonly AppDataContext _context;

        public UserRepository(AppDataContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Add(user);
        }

        public Task DeleteUser(int id)
        {
            var var = _context.Users.FindAsync(id);
            _context.Users.Remove(var.Result);
            return _context.SaveChangesAsync();
        }

        public Task<List<User>> GetAll()
        {
            return _context.Users.ToListAsync();

        }

        public Task<List<User>> GetUsers(Expression<Func<User, bool>> predicate)
        {
            return _context.Users.Where(predicate).ToListAsync();
        }

        public bool IsEntityExist(int id)
        {
            return _context.Users.Any(e => e.userID == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
