using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(Book book)
        {
            string authorizedUserId = User.Identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                book.AddedDate = DateTime.Now;
                book.AdvertisementOwner = context.Users.First(u => u.Id == authorizedUserId);
                context.Books.Add(book);
                await context.SaveChangesAsync();
            }

            return RedirectToAction("BooksForSell");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Book book)
        {
            using (var context = new ApplicationDbContext())
            {
                var bookInDb = await context.Books.Include(b => b.AdvertisementOwner).FirstOrDefaultAsync(b => b.Id == book.Id);
                if (bookInDb == null) return HttpNotFound();

                string authorizedUserId = User.Identity.GetUserId();
                if (authorizedUserId != bookInDb.AdvertisementOwner.Id) return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                bookInDb.Title = book.Title;
                bookInDb.Author = book.Author;
                bookInDb.Description = book.Description;
                bookInDb.PublishDate = book.PublishDate;
                bookInDb.ExpiredAdvertisement = book.ExpiredAdvertisement;
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

        [AllowAnonymous]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null) return HttpNotFound();
            using (var context = new ApplicationDbContext())
            {
                var book = await context.Books.Include(b => b.AdvertisementOwner).FirstOrDefaultAsync(b => b.Id == id);
                if (book == null) return HttpNotFound();

                string authorizedUserId = User.Identity.GetUserId();
                return View(authorizedUserId == book.AdvertisementOwner.Id ? "EditBook" : "ReadOnlyBook", book);
            }
        }
    }
}