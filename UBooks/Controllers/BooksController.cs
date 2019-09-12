using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UBooks.Models;

namespace UBooks.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        // GET: Books/SellBook
        public ActionResult SellBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(Book book)
        {
            book.AddedDate = DateTime.Now;
            using (var context = new ApplicationDbContext())
            {
                context.Books.Add(book);
                await context.SaveChangesAsync();
            }

            return RedirectToAction("BooksForSell");
        }

        [AllowAnonymous]
        public ActionResult BooksForSell()
        {
            using (var context = new ApplicationDbContext())
            {
                var books = context.Books.Include(b => b.AdvertisementOwner).Where(b => b.IsForSell).ToList();
                return View(books);
            }
            
        }
    }
}