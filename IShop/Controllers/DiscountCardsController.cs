using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IShop.Data;
using IShop.Models;

namespace IShop.Controllers
{
    public class DiscountCardsController : Controller
    {
        private readonly AppDataContext _context;

        public DiscountCardsController(AppDataContext context)
        {
            _context = context;
        }

        // GET: DiscountCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cards.ToListAsync());
        }

        // GET: DiscountCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountCard = await _context.Cards
                .FirstOrDefaultAsync(m => m.CardID == id);
            if (discountCard == null)
            {
                return NotFound();
            }

            return View(discountCard);
        }

        // GET: DiscountCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiscountCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardID,type")] DiscountCard discountCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discountCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(discountCard);
        }

        // GET: DiscountCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountCard = await _context.Cards.FindAsync(id);
            if (discountCard == null)
            {
                return NotFound();
            }
            return View(discountCard);
        }

        // POST: DiscountCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardID,type")] DiscountCard discountCard)
        {
            if (id != discountCard.CardID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discountCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscountCardExists(discountCard.CardID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(discountCard);
        }

        // GET: DiscountCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountCard = await _context.Cards
                .FirstOrDefaultAsync(m => m.CardID == id);
            if (discountCard == null)
            {
                return NotFound();
            }

            return View(discountCard);
        }

        // POST: DiscountCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discountCard = await _context.Cards.FindAsync(id);
            _context.Cards.Remove(discountCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscountCardExists(int id)
        {
            return _context.Cards.Any(e => e.CardID == id);
        }
    }
}
