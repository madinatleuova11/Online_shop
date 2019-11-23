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
    public class DiscountCardRepository : IDiscountCardRepository
    {
        readonly AppDataContext _context;

        public DiscountCardRepository(AppDataContext context)
        {
            _context = context;
        }

        public void Add(DiscountCard card)
        {
            _context.Add(card);
        }

        public Task DeleteDiscountCard(int id)
        {
            var var = _context.Cards.FindAsync(id);
            _context.Cards.Remove(var.Result);
            return _context.SaveChangesAsync();
        }

        public Task<List<DiscountCard>> GetAll()
        {
            return _context.Cards.ToListAsync();

        }

        public Task<List<DiscountCard>> GetDiscountCards(Expression<Func<DiscountCard, bool>> predicate)
        {
            return _context.Cards.Where(predicate).ToListAsync();
        }

        public bool IsEntityExist(int id)
        {
            return _context.Cards.Any(e => e.CardID == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
