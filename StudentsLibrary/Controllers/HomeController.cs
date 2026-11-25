using Newtonsoft.Json;
using StudentsLibrary.App_Start;
using StudentsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace StudentsLibrary.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ClaimsPrincipal userClaimsPrincipal = HttpContext.User as ClaimsPrincipal;

            var claims = userClaimsPrincipal.Claims;

            var roles = ((ClaimsIdentity)User.Identity).FindAll("groups").Select(c => c.Value).ToList();
            var name = ((ClaimsIdentity)User.Identity).FindAll("name").Select(c => c.Value).FirstOrDefault();

            string userName = userClaimsPrincipal.Identity.Name;
            ViewBag.UserName = name;
            bool activeStudent = userClaimsPrincipal.Identity.IsAuthenticated;



            return View("~/Views/Home/Index.cshtml");
        }
        [HttpPost]
        public ActionResult GetAllBooks(BooksSearch bookSearch)
        {

            string Settings = @"SELECT  * FROM Settings";
            var DefaultStore = StudentsLibrary.App_Start.Class1.Execute(Settings).Tables[0].Rows[0]["DefaultStore"];
            string whereCondition = " ";
            if (bookSearch.BookName != null && bookSearch.BookName.Trim() != "")
                whereCondition += " and  ItemName like '%" + bookSearch.BookName + "%'";
            if (bookSearch.BookAuthor != null && bookSearch.BookAuthor.Trim() != "")
                whereCondition += " and  Author like '%" + bookSearch.BookAuthor + "%'";
            if (bookSearch.BookPublisher != null && bookSearch.BookPublisher.Trim() != "")
                whereCondition += " and  Publisher like '%" + bookSearch.BookPublisher + "%'";
            if (bookSearch.BookId != null && bookSearch.BookId.Trim() != "")
                whereCondition += " and  ItemId = '" + bookSearch.BookId + "'";
            if (bookSearch.college != null && bookSearch.college.Trim() != "" && bookSearch.college != "0")
                whereCondition += " and  MainGroupId = '" + bookSearch.college + "'";

            whereCondition += " and  isnull (isshow,0) = 1 ";
            string StringQuery = @"DECLARE @var1 int select @var1 =  [defaultstore] from Settings SELECT  *  FROM(SELECT  COUNT(*) OVER() FOUND_ROWS,   ROW_NUMBER() OVER(ORDER BY items.itemid asc) AS RowNum,  itemCode , Items.ItemId,ItemName,Author,Publisher,UnitPriceAfterDiscount,UnitPrice,isshow, maingroupid ,(select top 1 isnull(PIC_PATH,'') from employees_pics where employees_pics.PIC_EMP =Items.ItemId and employees_pics.PIC_TYPE=1 order by employees_pics.PIC_SN desc ) as PIC_PATH FROM  Items   left outer join org_structure o2 on subgroupid=o2.org_sn  inner join (select itemid,isnull(sum(quantity),0) as quantity from transactions where storeId = " + DefaultStore + " and  convert(char(10),transtime,111) <= '" + DateTime.Now.Year.ToString() + '/' + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Day.ToString("00") + "' group by itemid  ) s0 on items.itemid=s0.itemid    WHERE  1=1   and ( isnull(s0.quantity,0) >@var1  ) and  UnitPriceAfterDiscount != 0 and UnitPrice != 0 ) AS RowConstrainedResult WHERE RowNum >= " + bookSearch.MinRow + " AND RowNum <= " + bookSearch.MaxRow + " " + whereCondition + " ORDER BY RowNum  ";

            var books = StudentsLibrary.App_Start.Class1.Execute(StringQuery).Tables[0];

            List<BookForView> bookslist = StudentsLibrary.App_Start.Class1.ConvertDataTable<BookForView>(books);

            string LocalFolderPath = Server.MapPath(ConfigurationManager.AppSettings["LocalPath"].ToString());
            string SourceFolder = ConfigurationManager.AppSettings["SharedFolder"].ToString();


            List<BookForView> newBookList = new List<BookForView>();
            string pathForView = "";

            bookslist.ForEach(book =>
            {
                if (!Directory.Exists(LocalFolderPath))
                {
                    Directory.CreateDirectory(LocalFolderPath);
                }


                if (!String.IsNullOrEmpty(book.PIC_PATH) && book.PIC_PATH != "")
                {

                    string fileName = book.PIC_PATH.Split('/')[1].ToString();

                    string filePathDestanation = Path.Combine(LocalFolderPath, fileName);
                    string filePathSource = Path.Combine(SourceFolder, fileName);

                    if (!System.IO.File.Exists(filePathDestanation))
                    {
                        try
                        {
                            if (System.IO.File.Exists(filePathSource))
                            {
                                System.IO.File.Copy(filePathSource, filePathDestanation, true);
                                pathForView = ConfigurationManager.AppSettings["LocalPath"].ToString().Split('/')[1] + book.PIC_PATH;
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
                    pathForView = ConfigurationManager.AppSettings["LocalPath"].ToString().Split('/')[1] + book.PIC_PATH;


                    }
                }
                else
                {
                    pathForView = @"/assets/book.jpg";

                }

                BookForView newBook = new BookForView();
                    newBook.FOUND_ROWS = book.FOUND_ROWS;
                    newBook.RowNum = book.RowNum;
                    newBook.itemCode = book.itemCode;
                    newBook.ItemId = book.ItemId;
                    newBook.ItemName = book.ItemName;
                    newBook.Author = book.Author;
                    newBook.Publisher = book.Publisher;
                    newBook.UnitPriceAfterDiscount = book.UnitPriceAfterDiscount;
                    newBook.UnitPrice = book.UnitPrice;
                    newBook.PIC_PATH = pathForView;
                    newBookList.Add(newBook);

                

            });

            var Data = JsonConvert.SerializeObject(newBookList);
            return Content(Data);
        }
        [HttpPost]
        public ActionResult GetSettings()
        {
            string StringQuery = @"SELECT  * FROM Settings";
            var Data = JsonConvert.SerializeObject(StudentsLibrary.App_Start.Class1.Execute(StringQuery).Tables[0]);
            return Content(Data);
        }
        [HttpPost]
        public ActionResult About()
        {
            return View("~/Views/Home/Contact.cshtm");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult GetDeliveryPlaces()
        {
            string StringQuery = @"SELECT  StoreId,StoreName FROM Stores join  settings on StoreId = DefaultStore";
            var Data = JsonConvert.SerializeObject(App_Start.Class1.Execute(StringQuery).Tables[0]);
            return Content(Data);
        }
    }
}