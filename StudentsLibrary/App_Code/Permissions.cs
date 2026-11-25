using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections;


/// <summary>
/// Summary description for Permissions
/// </summary>
 
    public class Permissions
    {
        public Permissions()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        static public string Authenticate(string page_name, string Groups_sn)
        {
            try
            {
                string result = "";// page_name +": ";

                ArrayList fn = new ArrayList();
                fn.Add("*");
                DataSet ds2 = new DataSet();
                ds2 = Data.GetElements("Permissions  ", fn, " Groups_sn=" + Groups_sn + " and per_Page= '" + page_name + "'");

            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0]["per_view"].ToString().ToLower() == "true")
                {
                    result += "view ";
                }

                if (ds2.Tables[0].Rows[0]["per_add"].ToString().ToLower() == "true")
                {
                    result += "add ";
                }

                if (ds2.Tables[0].Rows[0]["per_edit"].ToString().ToLower() == "true")
                {
                    result += "edit ";
                }

                if (ds2.Tables[0].Rows[0]["per_delete"].ToString().ToLower() == "true")
                {
                    result += "delete ";
                }

                if (ds2.Tables[0].Rows[0]["per_print"].ToString().ToLower() == "true")
                {
                    result += "print ";
                }
                if (ds2.Tables[0].Rows[0]["Per_secret"].ToString().ToLower() == "true")
                {
                    result += "secret ";
                }

                //return result;
            }





                return result;


            }
            catch (Exception Ex)
            {
                return "";

                //#region ############## Catch Error To Error File

                //string MethodName = new System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name;
                //string pageName = XmlErrorFile.GetCurrentPageName();

                //XmlErrorFile.Insert(pageName, MethodName, Ex.Message);
                //#endregion ############## Catch Error To Error File
            }
        }

        static public bool Authorize(string page_name, string ActionName, string Session2, string role_id, string USER_ID, string xnotes)
        {

            try
            {

                if (role_id == "21")
                {
                    return true;
                }

                if (!string.IsNullOrEmpty(Session2))
                {
                    if (Session2.Contains(ActionName.ToLower()))
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception Ex)
            {
                return false;

                //#region ############## Catch Error To Error File

                //string MethodName = new System.Diagnostics.StackTrace().GetFrame(0).GetMethod().Name;
                //string pageName = XmlErrorFile.GetCurrentPageName();

                //XmlErrorFile.Insert(pageName, MethodName, Ex.Message);
                //#endregion ############## Catch Error To Error File
            }
        }


    }
 