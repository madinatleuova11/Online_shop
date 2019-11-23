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
    public class BasketsController : Controller
    {
        private readonly AppDataContext _context;

        public BasketsController(AppDataContext context)
        {
            _context = context;
        }

        // GET: Baskets
        public async Task<IActionResult> Index()
        {
            var appDataContext = _context.Baskets.Include(b => b.Product).Include(b => b.User);
            return View(await appDataContext.ToListAsync());
        }

        // GET: Baskets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _context.Baskets
                .Include(b => b.Product)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // GET: Baskets/Create
        public IActionResult Create()
        {
            ViewData["productID"] = new SelectList(_context.Products, "productID", "Name");
            ViewData["userID"] = new SelectList(_context.Users, "userID", "FullName");
            return View();
        }

        // POST: Baskets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,userID,productID")] Basket basket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["productID"] = new SelectList(_context.Products, "productID", "Name", basket.productID);
            ViewData["userID"] = new SelectList(_context.Users, "userID", "FullName", basket.userID);
            return View(basket);
        }

        // GET: Baskets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _context.Baskets.FindAsync(id);
            if (basket == null)
            {
                return NotFound();
            }
            ViewData["productID"] = new SelectList(_context.Products, "productID", "Name", basket.productID);
            ViewData["userID"] = new SelectList(_context.Users, "userID", "FullName", basket.userID);
            return View(basket);
        }

        // POST: Baskets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,userID,productID")] Basket basket)
        {
            if (id != basket.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasketExists(basket.ID))
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
            ViewData["productID"] = new SelectList(_context.Products, "productID", "Name", basket.productID);
            ViewData["userID"] = new SelectList(_context.Users, "userID", "FullName", basket.userID);
            return View(basket);
        }

        // GET: Baskets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basket = await _context.Baskets
                .Include(b => b.Product)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (basket == null)
            {
                return NotFound();
            }

            return View(basket);
        }

        // POST: Baskets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basket = await _context.Baskets.FindAsync(id);
            _context.Baskets.Remove(basket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasketExists(int id)
        {
            return _context.Baskets.Any(e => e.ID == id);
        }
    }
}
