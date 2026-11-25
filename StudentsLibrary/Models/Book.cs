using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsLibrary.Models
{
    public class Book
    {
        public string BookId { get; set; }
        public string BookName { get; set; }
        public int BookQuantity { get; set; }
        public string BookPrice { get; set; }
        public string BookPriceBeforeDis { get; set; }
        public string BookImage { get; set; }
    }
}