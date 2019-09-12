using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UBooks.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime SellDate { get; set; }
        public ApplicationUser SellerOrBuyer { get; set; }
        public bool IsForSell { get; set; }

    }
}