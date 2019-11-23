using IShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IShop.Interfaces
{
    public interface IDiscountCardRepository
    {
        void Add(DiscountCard user);
        Task Save();
        Task<List<DiscountCard>> GetAll();
        Task<List<DiscountCard>> GetDiscountCards(Expression<Func<DiscountCard, bool>> predicate);
        Task DeleteDiscountCard(int id);
        bool IsEntityExist(int id);
    }
}
