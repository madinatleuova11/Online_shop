using IShop.Interfaces;
using IShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.Services
{
    public class UserService
    {
        private readonly IUserRepository _user;

        public UserService(IUserRepository context)
        {
            _user = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _user.GetAll();
        }

        public async Task AddAndSave(User user)
        {
            _user.Add(user);
            await _user.Save();
        }

        public async Task DeleteUser(int id)
        {
            await _user.DeleteUser(id);
        }

        public bool IsEntityExist(int id)
        {
            return _user.IsEntityExist(id);
        }


    }
}
