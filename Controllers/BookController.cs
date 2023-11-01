using BM_INFOTRADE_ASP.NETCORE_6.Data;
using BM_INFOTRADE_ASP.NETCORE_6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BM_INFOTRADE_ASP.NETCORE_6.Controllers
{
    public class BookController : Controller
    {
        private readonly BookContext context;

        public BookController(BookContext context)
        {
            this.context = context;
        }
        // GET: BookController
        public async Task<IActionResult> Index()
        {
            var data = await context.Books.ToListAsync();
            return View(data);
        }



        // GET: BookController/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book temp)
        {
            if (ModelState.IsValid)
            {
                await context.Books.AddAsync(temp);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Book");
            }
            return View(temp);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || context.Books == null)
            {
                return NotFound();
            }
            var temp = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (temp == null)
            {
                return NotFound();
            }
            return View(temp);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Books == null)
            {
                return NotFound();
            }
            var temp = await context.Books.FindAsync(id);
            if (temp == null)
            {
                return NotFound();
            }
            return View(temp);
        }


        [HttpPost]

        public async Task<IActionResult> Edit(int id, Book temp)
        {
            if (id != temp.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(temp);
                await context.SaveChangesAsync();
                return RedirectToAction("Index", "Book");
            }
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.Books == null)
            {
                return NotFound();
            }
            var temp = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (temp == null)
            {
                return NotFound();

            }
            return View(temp);
        }
        //[HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var temp = await context.Books.FindAsync(id);
            if (temp != null)
            {
                context.Books.Remove(temp);
            }
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Book");
        }
    }
}




