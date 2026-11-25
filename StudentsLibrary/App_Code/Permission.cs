using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for Permission
/// </summary>
 
    public class Permission : System.Web.UI.Page
    {
        public Permission()
        {


        }
        public static bool GetPermission(string PageName, PermissionActions Action, ref HtmlGenericControl AlertMessage2)
        {
            if (PageName == "") { return true; }
            if (HttpContext.Current.Session["Groups_sn"].ToString() == "21") 
        { return true; }
            if (!Permissions.Authorize(PageName, Action.ToString(), (String)HttpContext.Current.Session[PageName], (String)HttpContext.Current.Session["Groups_sn"].ToString(), (String)HttpContext.Current.Session["USER_SN"].ToString(), ""))
            {
                AlertMessage2.Visible = true;
                AlertMessage2.Attributes["class"] = "alert alert-danger";
                AlertMessage2.InnerHtml = Data.GetMSG(HttpContext.Current.Session["language"].ToString(), "no_permission");
                return false;
            }
            return true;
        }
    }
    public enum PermissionActions
    {
        Add = 1,
        Delete = 2,
        View = 3,
        Edit = 4,
        Print = 5,
    secret = 6
}
 