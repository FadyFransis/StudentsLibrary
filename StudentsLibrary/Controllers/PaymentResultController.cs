using StudentsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace StudentsLibrary.Controllers
{
    public class PaymentResultController : Controller
    {
        // GET: PaymentResult
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FinishShop(string Params, string DeliveryPlace, string DeliveryDate, string DeliveryHour, string TotalPrice)
        {
            ClaimsPrincipal userClaimsPrincipal = HttpContext.User as ClaimsPrincipal;
            string userName = userClaimsPrincipal.Identity.Name;
            var ValidDate = App_Start.Class1.Execute("select Delivery_Date,Delivery_Hours from purchases where Delivery_Date = '" + DeliveryDate + "' and Delivery_Hours = '" + DeliveryHour + "' and Delivey_Location = '" + DeliveryPlace + "'").Tables[0];
            var Settings = App_Start.Class1.Execute("select Stds_Per_Time from Settings").Tables[0].Rows[0]["Stds_Per_Time"].ToString();
            if (ValidDate.Rows.Count >= int.Parse(Settings))
            {
                return Content("-2");
            }


            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            object[] BooksList = (object[])json_serializer.DeserializeObject(Params);
            for (var i = 0; i < BooksList.Length; i++)
            {
                var c = BooksList[i];
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                var json = serializer.Serialize(c);
                Book book = serializer.Deserialize<Book>(json);
                //var IsBookAvailable = App_Start.Class1.Execute("select  dbo.getCurrentBalance('" + DeliveryDate + "','" + book.BookId + "') union all select ISNULL(sum(Book_Quantity),0) from purchases join Purchase_Details on purchases.Purchase_No = Purchase_Details.Purchase_No where Delivery_Date = '" + DeliveryDate + "' and Delivey_Location = " + DeliveryPlace + " and Book_Id = " + book.BookId + " union all select ISNULL(Min_Count,0) from Settings").Tables[0];
                //int CurrentCount = int.Parse(IsBookAvailable.Rows[0]["Column1"].ToString());
                //int ReservedCount = int.Parse(IsBookAvailable.Rows[1]["Column1"].ToString());
                //int MinCount = int.Parse(IsBookAvailable.Rows[2]["Column1"].ToString());

                //if (CurrentCount - (ReservedCount + book.BookQuantity) <= MinCount)
                //{
                //    return Json(book.BookName);
                //}
            }
            App_Start.Class1.Execute("insert into Purchases (Delivery_Date,Delivey_Location,Delivery_Hours,Total_Price,Student_Id) values('" + DeliveryDate + "','" + DeliveryPlace + "','" + DeliveryHour + "','" + TotalPrice + "','" + userName + "')");
            var PurchaseNo = App_Start.Class1.Execute("select Purchase_No from Purchases order by Purchase_No desc").Tables[0].Rows[0]["Purchase_No"];

            for (var i = 0; i < BooksList.Length; i++)
            {
                var c = BooksList[i];
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                var json = serializer.Serialize(c);
                Book book = serializer.Deserialize<Book>(json);
                App_Start.Class1.Execute("insert into Purchase_Details (Purchase_No,Book_Id,Book_Quantity,Book_Price,Book_Price_Before_Dis) values(" + PurchaseNo + ",'" + book.BookId + "'," + book.BookQuantity + "," + book.BookPrice + "," + book.BookPriceBeforeDis + ")");
            }
            return Content("1");
        }
    }
}