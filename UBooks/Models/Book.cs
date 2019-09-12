using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UBooks.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}