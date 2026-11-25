using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;

/// <summary>
/// Summary description for ConnectionManager
/// </summary>

public class ConnectionManager
{
    public ConnectionManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string connectionString;
    static public SqlConnection connection()
    {
        SqlConnection con = new SqlConnection();
      
        con.ConnectionString = @"Server= DESKTOP-R1BF19T\SQL2022; initial catalog = StoresDB; user id = sa; password = '123456'; ";
      

        return con;
    }
}
  