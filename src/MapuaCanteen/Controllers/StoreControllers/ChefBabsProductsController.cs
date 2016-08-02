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
    public class ChefBabsProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChefBabsProductsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ChefBabsProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChefBabsProducts.ToListAsync());
        }

        // GET: ChefBabsProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chefBabsProducts = await _context.ChefBabsProducts.SingleOrDefaultAsync(m => m.ID == id);
            if (chefBabsProducts == null)
            {
                return NotFound();
            }

            return View(chefBabsProducts);
        }

        // GET: ChefBabsProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChefBabsProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Image,Item,PreparationTime,Price,Remarks,Stock")] ChefBabsProducts chefBabsProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chefBabsProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(chefBabsProducts);
        }

        // GET: ChefBabsProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chefBabsProducts = await _context.ChefBabsProducts.SingleOrDefaultAsync(m => m.ID == id);
            if (chefBabsProducts == null)
            {
                return NotFound();
            }
            return View(chefBabsProducts);
        }

        // POST: ChefBabsProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Image,Item,PreparationTime,Price,Remarks,Stock")] ChefBabsProducts chefBabsProducts)
        {
            if (id != chefBabsProducts.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chefBabsProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChefBabsProductsExists(chefBabsProducts.ID))
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
            return View(chefBabsProducts);
        }

        // GET: ChefBabsProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chefBabsProducts = await _context.ChefBabsProducts.SingleOrDefaultAsync(m => m.ID == id);
            if (chefBabsProducts == null)
            {
                return NotFound();
            }

            return View(chefBabsProducts);
        }

        // POST: ChefBabsProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chefBabsProducts = await _context.ChefBabsProducts.SingleOrDefaultAsync(m => m.ID == id);
            _context.ChefBabsProducts.Remove(chefBabsProducts);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ChefBabsProductsExists(int id)
        {
            return _context.ChefBabsProducts.Any(e => e.ID == id);
        }
    }
}
