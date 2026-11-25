using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Web.Services.Description;
using Microsoft.Identity.Client;
using Microsoft.Graph;
//using Microsoft.Graph.Auth;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;

namespace StudentsLibrary.App_Start
{
    public class Class1
    {
        static public DataSet Execute(string Sql)
        {
            DataSet ds = new DataSet(); // Define the DataSet
            try
            {

                using (SqlConnection cn = ConnectionManager.connection())
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.CommandText = Sql;
                        cmd.CommandTimeout = 0;
                        using (SqlDataAdapter dr = new SqlDataAdapter(cmd))
                        {
                            dr.Fill(ds);
                        }
                    }

                }

            }
            catch (Exception Ex)
            {
                //Data.Execute("insert into Errors (Error_Page,Error_Data ,Error_Method) values ('ClassData','" + Ex.Data + Sql + "','Execute');");
                //DataSet set = null;
                //return set;
            }
            return ds;
        }

        public static bool sendMailCompany(string subject, string body, string toAddress)
        {

            try
            {


                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("bookstore@paaet.edu.kw");

                    mail.To.Add(toAddress);
                    mail.SubjectEncoding = Encoding.UTF8;
                    mail.BodyEncoding = Encoding.UTF8;
                    mail.IsBodyHtml = true;

                    mail.Subject = subject;

                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient("apprelay.paaet.edu.kw")
                    {

                        Port = 587,

                        Credentials = new NetworkCredential("bookstore@paaet.edu.kw", "P@@et@bookstore23", "PAAET"),
                        EnableSsl = true
                    };

                    try
                    {
                        MailMessage mailMessage = new MailMessage(mail.From.ToString(), mail.To.ToString(), mail.Subject, mail.Body);

                        smtp.Send(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message.ToString();
                        return false;

                    }

                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        if (dr[column.ColumnName] != System.DBNull.Value)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                            pro.SetValue(obj, "", null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
    public class BookForView
    {
        public int FOUND_ROWS { get; set; }
        public long RowNum { get; set; }
        public string itemCode { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public decimal UnitPriceAfterDiscount { get; set; }
        public decimal UnitPrice { get; set; }
        public string PIC_PATH { get; set; }
    }
}
