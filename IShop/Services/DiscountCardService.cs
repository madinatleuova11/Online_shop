using IShop.Interfaces;
using IShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IShop.Services
{
    public class DiscountCardService
    {
        private readonly IDiscountCardRepository _card;

        public DiscountCardService(IDiscountCardRepository context)
        {
            _card = context;
        }

        public async Task<List<DiscountCard>> GetDiscountCards()
        {
            return await _card.GetAll();
        }

        public async Task AddAndSave(DiscountCard card)
        {
            _card.Add(card);
            await _card.Save();
        }

        public async Task DeleteCard(int id)
        {
            await _card.DeleteDiscountCard(id);
        }

        public bool IsEntityExist(int id)
        {
            return _card.IsEntityExist(id);
        }

    }
}
