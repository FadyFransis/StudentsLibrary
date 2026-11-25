using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsLibrary.Models
{
    public class ShoppingCart
    {
        public string Books { get; set; }
        public string DeliveryPlace { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryHour { get; set; }
        public string TotalPrice { get; set; }
    }
}