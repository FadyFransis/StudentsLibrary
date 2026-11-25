using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentsLibrary.Models
{
    public class PaymentResultModel
    {
        public string StatusCode { get; set; }
        public string Amount { get; set; }
        public string ReferenceID { get; set; }
        public string PaymentID { get; set; }
        public string TrackID { get; set; }
        public string TransactionID { get; set; }
        public string PurchaseNo { get; set; }
        public string websiteUrl { get; set; }
    }
}