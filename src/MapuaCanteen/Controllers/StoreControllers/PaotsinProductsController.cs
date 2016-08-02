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
    public class PaotsinProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaotsinProductsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PaotsinProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaotsinProducts.ToListAsync());
        }

        // GET: PaotsinProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paotsinProducts = await _context.PaotsinProducts.SingleOrDefaultAsync(m => m.ID == id);
            if (paotsinProducts == null)
            {
                return NotFound();
            }

            return View(paotsinProducts);
        }

        // GET: PaotsinProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaotsinProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Image,Item,PreparationTime,Price,Remarks,Stock")] PaotsinProducts paotsinProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paotsinProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paotsinProducts);
        }

        // GET: PaotsinProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paotsinProducts = await _context.PaotsinProducts.SingleOrDefaultAsync(m => m.ID == id);
            if (paotsinProducts == null)
            {
                return NotFound();
            }
            return View(paotsinProducts);
        }

        // POST: PaotsinProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Image,Item,PreparationTime,Price,Remarks,Stock")] PaotsinProducts paotsinProducts)
        {
            if (id != paotsinProducts.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paotsinProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaotsinProductsExists(paotsinProducts.ID))
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
            return View(paotsinProducts);
        }

        // GET: PaotsinProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paotsinProducts = await _context.PaotsinProducts.SingleOrDefaultAsync(m => m.ID == id);
            if (paotsinProducts == null)
            {
                return NotFound();
            }

            return View(paotsinProducts);
        }

        // POST: PaotsinProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paotsinProducts = await _context.PaotsinProducts.SingleOrDefaultAsync(m => m.ID == id);
            _context.PaotsinProducts.Remove(paotsinProducts);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PaotsinProductsExists(int id)
        {
            return _context.PaotsinProducts.Any(e => e.ID == id);
        }

        // GET: PaotsinProducts/Store
        public async Task<IActionResult> Store()
        {
            return View(await _context.PaotsinProducts.ToListAsync());
        }
    }
}
