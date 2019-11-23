using IShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IShop.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        Task Save();
        Task<List<User>> GetAll();
        Task<List<User>> GetUsers(Expression<Func<User, bool>> predicate);
        Task DeleteUser(int id);
        bool IsEntityExist(int id);
    }
}
