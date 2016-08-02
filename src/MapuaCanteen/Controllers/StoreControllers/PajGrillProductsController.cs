using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MapuaCanteen.Data;
using MapuaCanteen.Models;

namespace MapuaCanteen.Controllers.StoreControllers
{
    public class PajGrillProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PajGrillProductsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PajGrillProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.PajGrillProducts.ToListAsync());
        }

        // GET: PajGrillProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pajGrillProducts = await _context.PajGrillProducts.SingleOrDefaultAsync(m => m.ID == id);
            if (pajGrillProducts == null)
            {
                return NotFound();
            }

            return View(pajGrillProducts);
        }

        // GET: PajGrillProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PajGrillProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Image,Item,PreparationTime,Price,Remarks,Stock")] PajGrillProducts pajGrillProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pajGrillProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pajGrillProducts);
        }

        // GET: PajGrillProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pajGrillProducts = await _context.PajGrillProducts.SingleOrDefaultAsync(m => m.ID == id);
            if (pajGrillProducts == null)
            {
                return NotFound();
            }
            return View(pajGrillProducts);
        }

        // POST: PajGrillProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Image,Item,PreparationTime,Price,Remarks,Stock")] PajGrillProducts pajGrillProducts)
        {
            if (id != pajGrillProducts.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pajGrillProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PajGrillProductsExists(pajGrillProducts.ID))
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
            return View(pajGrillProducts);
        }

        // GET: PajGrillProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pajGrillProducts = await _context.PajGrillProducts.SingleOrDefaultAsync(m => m.ID == id);
            if (pajGrillProducts == null)
            {
                return NotFound();
            }

            return View(pajGrillProducts);
        }

        // POST: PajGrillProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pajGrillProducts = await _context.PajGrillProducts.SingleOrDefaultAsync(m => m.ID == id);
            _context.PajGrillProducts.Remove(pajGrillProducts);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PajGrillProductsExists(int id)
        {
            return _context.PajGrillProducts.Any(e => e.ID == id);
        }
    }
}
