using Newtonsoft.Json;
using StudentsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace StudentsLibrary.Controllers
{
    public class FinishShopController : Controller
    {
        // GET: FinishShop
        [Authorize]
        public ActionResult Index()
        {
            ClaimsPrincipal userClaimsPrincipal = HttpContext.User as ClaimsPrincipal;
            string userName =((ClaimsIdentity)User.Identity).FindAll("name").Select(c => c.Value).FirstOrDefault();
            ViewBag.UserName = userName;
            return View("~/Views/Home/FinishShop.cshtml");
        }
        [HttpPost]
        public ActionResult GetSettings()
        {
            string StringQuery = @"SELECT  * FROM Settings";
            var Data = StudentsLibrary.App_Start.Class1.Execute(StringQuery).Tables[0];
            ClaimsPrincipal userClaimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var claims = userClaimsPrincipal.Claims;
            var roles = ((ClaimsIdentity)User.Identity).FindAll("groups").Select(c => c.Value).ToList();
            DataColumn roleColumn = new DataColumn("IsStudent", typeof(string));
            Data.Columns.Add(roleColumn);
            if ( roles[0].ToString() == "Students")
                Data.Rows[0]["IsStudent"] = "1";
            else
                Data.Rows[0]["IsStudent"] = "0";
            return Content(JsonConvert.SerializeObject(Data));
        }
        [HttpPost]
        public ActionResult FinishShop(string Params, string DeliveryPlace, string DeliveryDate, string DeliveryHour, string TotalPrice)
        {
            ShoppingCart shoppingCart = new ShoppingCart()
            {
                Books = Params,
                DeliveryDate = DeliveryDate,
                DeliveryPlace = DeliveryPlace,
                DeliveryHour = DeliveryHour,
                TotalPrice = TotalPrice
            };
            if (Params != null)
                Session["ShoppingCart"] = shoppingCart;
            
            return Content("1");
        }
        
        public ActionResult processpayment()
        {
            ShoppingCart current = (ShoppingCart)Session["ShoppingCart"];
            var TrxId = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
            ClaimsPrincipal userClaimsPrincipal = HttpContext.User as ClaimsPrincipal;
            string userName = ((ClaimsIdentity)User.Identity).FindAll("name").Select(c => c.Value).FirstOrDefault();
            string email = userClaimsPrincipal.Identity.Name;
            string url = "https://onlinegate.paaet.edu.kw/frmpay.aspx?ApplicationCode=WSTRNHWN&ServiceCode=ENQCFACW&Action=1&Amount=" + current.TotalPrice + "&Currency=414&Language=ARA&ResponseURL=" + "https://webapps.paaet.edu.kw/onlinebookstore/FinishShop/PaymentResult" + "&ErrorURL=" + "https://webapps.paaet.edu.kw/onlinebookstore/FinishShop/PaymentResult" + "&TransactionID=" + TrxId + "&CID=" + email + "&CN=" + userName + "&UDF1=USERDEFINEDFIELD1&UDF2=USERDEFINEDFIELD2&UDF3=USERDEFINEDFIELD3&UDF4=USERDEFINEDFIELD4";

            return Redirect(url);
        }
        public ActionResult PaymentResult(PaymentResultModel model)
        {
            ClaimsPrincipal userClaimsPrincipal = HttpContext.User as ClaimsPrincipal;
            string email = userClaimsPrincipal.Identity.Name;
            string userName = ((ClaimsIdentity)User.Identity).FindAll("name").Select(c => c.Value).FirstOrDefault();
            StudentsLibrary.App_Start.Class1.Execute("insert into PaymentTransactions(Payment_ID,Transaction_ID,Track_ID,Status_Code,Amount,UserEmail,UserName) values(" + model.PaymentID + "," + model.TransactionID + "," + model.TrackID + "," + model.StatusCode + "," + model.Amount + ",'" + email + "','"+ userName + "')");
            List<string> ErrorCodes = new List<string>() {  "11", "12", "13", "14", "15" };
            if (string.IsNullOrEmpty(model.StatusCode) || ErrorCodes.Contains(model.StatusCode))
            {
                Session["IsSuccess"] = 0;
                ViewBag.Result = 0;
            }
            else
            {
                Session["IsSuccess"] = 1;
                Session["TransactionId"] = model.TransactionID;
                ViewBag.Result = 1;
                
                    ShoppingCart current = (ShoppingCart)Session["ShoppingCart"];
                    JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                    object[] BooksList = (object[])json_serializer.DeserializeObject(current.Books);
                    for (var i = 0; i < BooksList.Length; i++)
                    {
                        var c = BooksList[i];
                        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                        var json = serializer.Serialize(c);
                        Book book = serializer.Deserialize<Book>(json);
                    }
                    App_Start.Class1.Execute("insert into Purchases (Delivery_Date,Delivey_Location,Delivery_Hours,Total_Price,Student_Id,Transaction_NO,UserName) values('" + current.DeliveryDate + "','" + current.DeliveryPlace + "','" + current.DeliveryHour + "','" + current.TotalPrice + "','" + email + "','" + Session["TransactionId"] + "','"+userName+"')");
                    var PurchaseNo = App_Start.Class1.Execute("select Purchase_No from Purchases order by Purchase_No desc").Tables[0].Rows[0]["Purchase_No"];
                    for (var i = 0; i < BooksList.Length; i++)
                    {
                        var c = BooksList[i];
                        var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                        var json = serializer.Serialize(c);
                        Book book = serializer.Deserialize<Book>(json);
                        App_Start.Class1.Execute("insert into Purchase_Details (Purchase_No,Book_Id,Book_Quantity,Book_Price,Book_Price_Before_Dis) values(" + PurchaseNo + ",'" + book.BookId + "'," + book.BookQuantity + "," + book.BookPrice + "," + book.BookPriceBeforeDis + ")");
                    }
                    Session["ShoppingCart"] = null;
                model.PurchaseNo = PurchaseNo.ToString();

                App_Start.Class1.sendMailCompany("عملية شراء ناجحة", "تم اتمام عملية شراء نجاح باجمالى سعر " + current.TotalPrice + " برقم فاتورة " + model.PurchaseNo + " يرجى التوجه للاستلام من مخزن " + current.DeliveryPlace + " فى تاريخ " + current.DeliveryDate + "", email);

                model.websiteUrl = App_Start.Class1.Execute("select WebSite_Url from Settings").Tables[0].Rows[0]["WebSite_Url"].ToString();


            }
            return View(model);
        }
    }
}