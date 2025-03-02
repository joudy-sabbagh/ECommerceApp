using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceApp.Models;

namespace ECommerceApp.Controllers
{
    public class BorrowingRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BorrowingRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BorrowingRecords.Include(b => b.Book).Include(b => b.Member);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BorrowingRecords == null)
            {
                return NotFound();
            }

            var borrowingRecord = await _context.BorrowingRecords
                .Include(b => b.Book)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.BorrowingRecordId == id);
            if (borrowingRecord == null)
            {
                return NotFound();
            }

            return View(borrowingRecord);
        }

        public IActionResult Create()
        {
            ViewBag.Members = new SelectList(_context.Members, "MemberId", "Name");
            ViewBag.Books = new SelectList(_context.Books, "BookId", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowingRecordId,BorrowDate,ReturnDate,MemberId,BookId")] BorrowingRecord borrowingRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrowingRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", borrowingRecord.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", borrowingRecord.MemberId);
            return View(borrowingRecord);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BorrowingRecords == null)
            {
                return NotFound();
            }

            var borrowingRecord = await _context.BorrowingRecords.FindAsync(id);
            if (borrowingRecord == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", borrowingRecord.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", borrowingRecord.MemberId);
            return View(borrowingRecord);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowingRecordId,BorrowDate,ReturnDate,MemberId,BookId")] BorrowingRecord borrowingRecord)
        {
            if (id != borrowingRecord.BorrowingRecordId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowingRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowingRecordExists(borrowingRecord.BorrowingRecordId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", borrowingRecord.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId", borrowingRecord.MemberId);
            return View(borrowingRecord);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BorrowingRecords == null)
            {
                return NotFound();
            }

            var borrowingRecord = await _context.BorrowingRecords
                .Include(b => b.Book)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.BorrowingRecordId == id);
            if (borrowingRecord == null)
            {
                return NotFound();
            }

            return View(borrowingRecord);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BorrowingRecords == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BorrowingRecords'  is null.");
            }
            var borrowingRecord = await _context.BorrowingRecords.FindAsync(id);
            if (borrowingRecord != null)
            {
                _context.BorrowingRecords.Remove(borrowingRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowingRecordExists(int id)
        {
          return (_context.BorrowingRecords?.Any(e => e.BorrowingRecordId == id)).GetValueOrDefault();
        }
    }
}
