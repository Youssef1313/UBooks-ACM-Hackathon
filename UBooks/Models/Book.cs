using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Published Date")]
        public DateTime PublishDate { get; set; }

        public DateTime AddedDate { get; set; }

        public ApplicationUser AdvertisementOwner { get; set; }

        public bool IsForSell { get; set; }
    }
}