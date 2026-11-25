using Newtonsoft.Json;
using StudentsLibrary.App_Start;
using StudentsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace StudentsLibrary.Controllers
{
    public class ShoppingHistoryController : Controller
    {
        // GET: ShoppingHistory
        [Authorize]
        public ActionResult Index()
        {

            ClaimsPrincipal userClaimsPrincipal = HttpContext.User as ClaimsPrincipal;
            string userName = ((ClaimsIdentity)User.Identity).FindAll("name").Select(c => c.Value).FirstOrDefault();
            ViewBag.UserName = userName;
            return View("~/Views/Home/ShoppingHistory.cshtml");
        }
        [HttpPost]
        public ActionResult GetAllpurchases()
        {
            string LocalFolderPath = Server.MapPath(ConfigurationManager.AppSettings["LocalPath"].ToString());
            string SourceFolder = ConfigurationManager.AppSettings["SharedFolder"].ToString();


            List<BookForView> newBookList = new List<BookForView>();
            string pathForView = "";
            ClaimsPrincipal userClaimsPrincipal = HttpContext.User as ClaimsPrincipal;
            string userName = userClaimsPrincipal.Identity.Name;
            DataSet ds = new DataSet();
            string StringQuery = @"SELECT  *,convert (char(10) , Purchasse_Date ,111) as PurchaseDate,case when Is_Deliverd=0 then 'لم يتم الاستلام' when  Is_Deliverd=1 then 'تم الاستلام' end as DeliveryStatus FROM Purchases where Student_Id = '"+ userName + "' order by purchase_No desc";
            var Data = App_Start.Class1.Execute(StringQuery).Tables[0];
            ds.Tables.Add(Data.Copy());
            DataTable PurchaseDetails = new DataTable();
            for(var i = 0; i < Data.Rows.Count; i++)
            {
                string DetailsQuery = @"SELECT  * ,(select top 1 PIC_PATH from employees_pics where employees_pics.PIC_EMP =Items.ItemId and employees_pics.PIC_TYPE=1 order by employees_pics.PIC_SN desc ) as ItemImage  FROM Purchase_Details join Items on ItemId = Book_Id where Purchase_No = " + Data.Rows[i]["Purchase_No"] + "";
                PurchaseDetails = App_Start.Class1.Execute(DetailsQuery).Tables[0];


                if (!Directory.Exists(LocalFolderPath))
                {
                    Directory.CreateDirectory(LocalFolderPath);
                }

                if (!String.IsNullOrEmpty(PurchaseDetails.Rows[0]["ItemImage"].ToString()) && PurchaseDetails.Rows[0]["ItemImage"].ToString() != "")
                {

                    string fileName = PurchaseDetails.Rows[0]["ItemImage"].ToString().Split('/')[1].ToString();

                    string filePathDestanation = Path.Combine(LocalFolderPath, fileName);
                    string filePathSource = Path.Combine(SourceFolder, fileName);

                    if (!System.IO.File.Exists(filePathDestanation))
                    {
                        try
                        {
                            if (System.IO.File.Exists(filePathSource))
                            {
                                System.IO.File.Copy(filePathSource, filePathDestanation, true);
                                pathForView = ConfigurationManager.AppSettings["LocalPath"].ToString().Split('/')[1] + PurchaseDetails.Rows[0]["ItemImage"].ToString();
                            }
                            else
                            {
                                pathForView = @"/assets/book.jpg";
                            }

                        }
                        catch (Exception ex)
                        {
                            string error = ex.Message.ToString();
                            throw;
                        }

                    }
                    else
                    {
                        pathForView = ConfigurationManager.AppSettings["LocalPath"].ToString().Split('/')[1] + PurchaseDetails.Rows[0]["ItemImage"].ToString();


                    }
                }
                else
                {
                    pathForView = @"/assets/book.jpg";

                }
                PurchaseDetails.Rows[0]["ItemImage"] = pathForView;
                var NewDT = PurchaseDetails.Copy();
                NewDT.TableName = "Table" + i + "";
                ds.Tables.Add(NewDT);
            }

            return Content(JsonConvert.SerializeObject(ds));

        }
    }
}