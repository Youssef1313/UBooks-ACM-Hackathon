using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}