using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FHWebApp.Data;
using FHWebApp.Models;

namespace FHWebApp.Controllers
{
    public class CardInfosController : Controller
    {
        private readonly FHWebAppContext _context;

        public CardInfosController(FHWebAppContext context)
        {
            _context = context;
        }

        // GET: CardInfos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CardInfo.ToListAsync());
        }

        // GET: CardInfos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardInfo = await _context.CardInfo
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (cardInfo == null)
            {
                return NotFound();
            }

            return View(cardInfo);
        }

        // GET: CardInfos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CardInfos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardId,CustomerId,CardNumber,CVV,CreationDate,Token")] CardInfo cardInfo)
        {
            if (ModelState.IsValid)
            {
                cardInfo.CardId = Guid.NewGuid();
                _context.Add(cardInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardInfo);
        }

        // GET: CardInfos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardInfo = await _context.CardInfo.FindAsync(id);
            if (cardInfo == null)
            {
                return NotFound();
            }
            return View(cardInfo);
        }

        // POST: CardInfos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CardId,CustomerId,CardNumber,CVV,CreationDate,Token")] CardInfo cardInfo)
        {
            if (id != cardInfo.CardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardInfoExists(cardInfo.CardId))
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
            return View(cardInfo);
        }

        // GET: CardInfos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardInfo = await _context.CardInfo
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (cardInfo == null)
            {
                return NotFound();
            }

            return View(cardInfo);
        }

        // POST: CardInfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cardInfo = await _context.CardInfo.FindAsync(id);
            _context.CardInfo.Remove(cardInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardInfoExists(Guid id)
        {
            return _context.CardInfo.Any(e => e.CardId == id);
        }
    }
}
