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
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        [Authorize]

        public ActionResult Index()
        {
            ClaimsPrincipal userClaimsPrincipal = HttpContext.User as ClaimsPrincipal;


            var claims = userClaimsPrincipal.Claims;

            var roles = ((ClaimsIdentity)User.Identity).FindAll("groups").Select(c => c.Value).ToList();
            var name = ((ClaimsIdentity)User.Identity).FindAll("name").Select(c => c.Value).FirstOrDefault();

            string userName = userClaimsPrincipal.Identity.Name;
            ViewBag.UserName = name;

            return View("~/Views/Home/ShoppingCart.cshtml");
        }
        [HttpPost]
        public ActionResult IsBookSupported(string Params)
        {
            ClaimsPrincipal userClaimsPrincipal = HttpContext.User as ClaimsPrincipal;
            string email = userClaimsPrincipal.Identity.Name;

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            object[] BooksList = (object[])json_serializer.DeserializeObject(Params);
            List<string> CountSupported = new List<string>();
            for (var i = 0; i < BooksList.Length; i++)
            {
                var c = BooksList[i];
                var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                var json = serializer.Serialize(c);
                Book book = serializer.Deserialize<Book>(json);
                string Count = StudentsLibrary.App_Start.Class1.Execute("select count(*) from Purchase_Details left join purchases on Purchase_Details.Purchase_No = purchases.Purchase_No where book_Id = " + book.BookId + " and Student_Id = '" + email + "' ").Tables[0].Rows[0]["Column1"].ToString();
                CountSupported.Add(Count);
            }
            var Data = JsonConvert.SerializeObject(CountSupported);
            return Content(Data);
        }
        [HttpPost]
        public ActionResult GetSettings()
        {
            ClaimsPrincipal userClaimsPrincipal = HttpContext.User as ClaimsPrincipal;
            var claims = userClaimsPrincipal.Claims;
            var roles = ((ClaimsIdentity)User.Identity).FindAll("groups").Select(c => c.Value).ToList();
            string userName = ((ClaimsIdentity)User.Identity).FindAll("name").Select(c => c.Value).FirstOrDefault();
            string StringQuery = @"SELECT  * FROM Settings";
            var dt = StudentsLibrary.App_Start.Class1.Execute(StringQuery).Tables[0];
            DataColumn roleColumn = new DataColumn("IsStudent", typeof(string));
            dt.Columns.Add(roleColumn);
            if (roles[0].ToString() == "Students")
                dt.Rows[0]["IsStudent"] = "1";
            else
                dt.Rows[0]["IsStudent"] = "0";
            var Data = JsonConvert.SerializeObject(dt);
            return Content(Data);
        }
        [HttpPost]
        public ActionResult GetDeliveryPlaces()
        {
            string StringQuery = @"SELECT  StoreId,StoreName FROM Stores join  settings on StoreId = DefaultStore";
            var Data = JsonConvert.SerializeObject(App_Start.Class1.Execute(StringQuery).Tables[0]);
            return Content(Data);
        }

        [HttpPost]
        public ActionResult Getcollege()
        {
            string StringQuery = @"SELECT  org_sn,org_Name FROM Org_Structure where org_parentsn<>0 union select 0,'اخنر' ";
            var Data = JsonConvert.SerializeObject(App_Start.Class1.Execute(StringQuery).Tables[0]);
            return Content(Data);
        }


        [HttpPost]
        public ActionResult ValidationFinishShop(string Params, string DeliveryPlace, string DeliveryDate, string DeliveryHour, string TotalPrice)
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
                var IsBookAvailable = App_Start.Class1.Execute("select  dbo.[getBalance]('" + DeliveryDate + "','" + DeliveryPlace + "','" + book.BookId + "')  union all select ISNULL(Min_Count,0) from Settings").Tables[0];
                int CurrentCount = int.Parse(IsBookAvailable.Rows[0]["Column1"].ToString());
                int MinCount = int.Parse(IsBookAvailable.Rows[1]["Column1"].ToString());

                if (CurrentCount - book.BookQuantity < MinCount)
                {
                    return Json(book.BookName);
                }



            }

            return Content("1");
        }

    }
}