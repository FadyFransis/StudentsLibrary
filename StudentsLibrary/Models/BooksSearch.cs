using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsLibrary.Models
{
    public class BooksSearch
    {
        public BooksSearch()
        {
            BookAuthor = "";
            BookName = "";
            BookPublisher = "";
        }
        public int MinRow { get; set; }
        public int MaxRow { get; set; }
        public string BookName { get; set; }
        public string BookId { get; set; }
        public string BookAuthor { get; set; }
        public string BookPublisher { get; set; }
        public string college { get; set; }
    }
}
