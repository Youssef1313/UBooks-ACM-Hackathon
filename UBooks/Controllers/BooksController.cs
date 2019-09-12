using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Add(Book book)
        {
            book.AddedDate = DateTime.Now;
            var context = new ApplicationDbContext();
            context.Books.Add(book);
            context.SaveChangesAsync();
            // TODO: Later, redirect to page that shows Books for sell.
            return RedirectToAction("Index", "Home");
        }
    }
}