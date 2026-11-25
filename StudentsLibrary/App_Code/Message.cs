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
/// Summary description for Message
/// </summary>
 
    public class Message
    {
        public Message()
        {

        }
        public static void ShowMessage(ref HtmlGenericControl AlertMessage, MessageActions Actions )
        {
            AlertMessage.Visible = true;
            if (Actions == MessageActions.no_permission)
            {
                AlertMessage.Attributes["class"] = "alert alert-danger";
                AlertMessage.InnerHtml = Data.GetMSG(HttpContext.Current.Session["language"].ToString(), "no_permission");
                return;
            }
            else if (Actions == MessageActions.save_fail)
            {
                AlertMessage.Attributes["class"] = "alert alert-danger";
                AlertMessage.InnerHtml = Data.GetMSG(HttpContext.Current.Session["language"].ToString(), "save_fail");
                return;
            }
            else if (Actions == MessageActions.save_success)
            {
                AlertMessage.Attributes["class"] = "alert alert-success";
                AlertMessage.InnerHtml = Data.GetMSG(HttpContext.Current.Session["language"].ToString(), "save_success");
                return;
            }
            else if (Actions == MessageActions.delete_fail)
            {
                AlertMessage.Attributes["class"] = "alert alert-danger";
                AlertMessage.InnerHtml = Data.GetMSG(HttpContext.Current.Session["language"].ToString(), "delete_fail");
                return;
            }

            else if (Actions == MessageActions.update_success)
            {
                AlertMessage.Attributes["class"] = "alert alert-success";
                AlertMessage.InnerHtml = Data.GetMSG(HttpContext.Current.Session["language"].ToString(), "update_success");
                return;
            }
            else if (Actions == MessageActions.delete_success)
            {
                AlertMessage.Attributes["class"] = "alert alert-success";
                AlertMessage.InnerHtml = Data.GetMSG(HttpContext.Current.Session["language"].ToString(), "delete_success");
                return;
            }
            else if (Actions == MessageActions.rec_related)
            {
                AlertMessage.Attributes["class"] = "alert alert-warning";
                AlertMessage.InnerHtml = Data.GetMSG(HttpContext.Current.Session["language"].ToString(), "rec_related");
                return;
            }
            else if (Actions == MessageActions.Updatefailed)
            {
                AlertMessage.Attributes["class"] = "alert alert-warning";
                AlertMessage.InnerHtml = Data.GetMSG(HttpContext.Current.Session["language"].ToString(), "update_fail");
                return;
            }
        }

    public static void refMessage(ref HtmlGenericControl  AlertMessage,string Message , Messagetype info  )
    {
        AlertMessage.Visible = true;
        if (info == Messagetype.fail)
        {
            AlertMessage.Attributes["class"] = "alert alert-danger";
            AlertMessage.InnerHtml = Message;
            return;
        }
        if (info == Messagetype.info)
        {
            AlertMessage.Attributes["class"] = "alert alert-success";
            AlertMessage.InnerHtml = Message;
            return;
        }

    }
}
    public enum MessageActions
    {
        no_permission = 1,
        user_exist = 2,
        save_fail = 3,
        save_success = 4,
        update_success = 5,
        Updatefailed = 6,
        delete_fail = 7,
        delete_success = 8,
        rec_related = 9,
    }
public enum Messagetype
{
    fail = 1,
    info = 2,
 
}

