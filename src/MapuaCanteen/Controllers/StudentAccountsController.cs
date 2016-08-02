using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MapuaCanteen.Data;
using MapuaCanteen.Models;

namespace MapuaCanteen.Controllers
{
    public class StudentAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentAccountsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: StudentAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentAccounts.ToListAsync());
        }

        // GET: StudentAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAccounts = await _context.StudentAccounts.SingleOrDefaultAsync(m => m.ID == id);
            if (studentAccounts == null)
            {
                return NotFound();
            }

            return View(studentAccounts);
        }

        // GET: StudentAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Balance,Email,LastTransaction,Name,PhoneNumber,StudentNumber")] StudentAccounts studentAccounts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentAccounts);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(studentAccounts);
        }

        // GET: StudentAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAccounts = await _context.StudentAccounts.SingleOrDefaultAsync(m => m.ID == id);
            if (studentAccounts == null)
            {
                return NotFound();
            }
            return View(studentAccounts);
        }

        // POST: StudentAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Balance,Email,LastTransaction,Name,PhoneNumber,StudentNumber")] StudentAccounts studentAccounts)
        {
            if (id != studentAccounts.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentAccounts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentAccountsExists(studentAccounts.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(studentAccounts);
        }

        // GET: StudentAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentAccounts = await _context.StudentAccounts.SingleOrDefaultAsync(m => m.ID == id);
            if (studentAccounts == null)
            {
                return NotFound();
            }

            return View(studentAccounts);
        }

        // POST: StudentAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentAccounts = await _context.StudentAccounts.SingleOrDefaultAsync(m => m.ID == id);
            _context.StudentAccounts.Remove(studentAccounts);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StudentAccountsExists(int id)
        {
            return _context.StudentAccounts.Any(e => e.ID == id);
        }
    }
}
