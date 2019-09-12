using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UBooks.Models;

namespace UBooks.Controllers
{
    // TODO: Remove comment [Authorize]
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
            return HttpNotFound();
        }
    }
}