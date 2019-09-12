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

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Published Date")]
        public DateTime PublishDate { get; set; }

        [Required]
        [Display(Name = "Advertisement Date")]
        public DateTime AddedDate { get; set; }

        [Required]
        public ApplicationUser AdvertisementOwner { get; set; }

        [Required]
        public bool IsForSell { get; set; }

        [Required]
        public bool ExpiredAdvertisement { get; set; }
    }
}