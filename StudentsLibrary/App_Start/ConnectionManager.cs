using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentsLibrary.App_Start
{
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
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            con.ConnectionString = connectionString;


            return con;
        }
    }
}