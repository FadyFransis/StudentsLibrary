using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.SqlClient;

namespace StudentsLibrary.Models
{
    public class SqlData
    {
//        static public string GetChilds(string parent)
//        {
//            try
//            {

//                DataTable ds = new DataTable();
//                ds = Data.GetElements_parm("select * from Organizational_Structure where org_Parentsn = " + parent);

//                string Childs = string.Empty;
//                for (int i = 0; i < ds.Rows.Count; i++)
//                {
//                    Childs += "," + ds.Rows[i]["org_sn"].ToString();
//                    Childs += GetChilds(ds.Rows[i]["org_sn"].ToString());
//                }

//                return Childs;

//            }
//            catch (Exception ex)
//            {

//                Data.Execute("insert into Errors (Error_Page,Error_Data ,Error_Method) values ('GetChilds','" + ex.Data + "','GetChilds');");
//                return "";
//            }
//        }
//        static public DataSet GetElements(string TableName, ArrayList FieldNames, string where_condition)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    command.CommandTimeout = 0;
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();
//                    command.CommandText = COracle.SelectGenerator(TableName, FieldNames, where_condition);
//                    SqlDataAdapter da = new SqlDataAdapter(command);
//                    DataSet set = new DataSet();
//                    da.Fill(set, "Security");
//                    return set;
//                }
//                catch (Exception Ex)
//                {

//                    Data.Execute("insert into Errors (Error_Page,Error_Data ,Error_Method) values ('ClassData','" + Ex.Data + "','GetElements');");
//                    DataSet set = null;
//                    return set;
//                }
//            }
//        }
//        static public DataSet proc_exec(string ProcedureName, string Params)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    //cOracleDBManipulation COracle = new cOracleDBManipulation();

//                    command.CommandText = "execute " + ProcedureName + " " + Params;

//                    SqlDataAdapter da = new SqlDataAdapter(command);
//                    DataSet set = new DataSet();
//                    da.Fill(set, "Security");
//                    return set;

//                }
//                catch (Exception Ex)
//                {

//                    Data.Execute("insert into Errors (Error_Page,Error_Data ,Error_Method) values ('ClassData','" + Ex.Data + "','proc_exec');");
//                    DataSet set = null;
//                    return set;
//                }

//            }


//        }
//        static public DataSet GetElements_Transaction(string TableName, ArrayList FieldNames, string where_condition, SqlConnection connection)
//        {
//            //using (SqlConnection connection = ConnectionManager.connection())
//            //{
//            try
//            {
//                //connection.Open();
//                SqlCommand command = new SqlCommand();
//                command.Connection = connection;
//                command.CommandType = CommandType.Text;
//                command.CommandTimeout = 0;
//                cOracleDBManipulation COracle = new cOracleDBManipulation();

//                command.CommandText = COracle.SelectGenerator(TableName, FieldNames, where_condition);

//                SqlDataAdapter da = new SqlDataAdapter(command);
//                DataSet set = new DataSet();
//                da.Fill(set, "Security");
//                return set;

//            }
//            catch (Exception Ex)
//            {

//                Data.Execute("insert into Errors (Error_Page,Error_Data ,Error_Method) values ('ClassData','" + Ex.Data + "','GetElements_Transaction');");
//                DataSet set = null;
//                return set;
//            }

//            //}


//        }
//        static public int GetNextID(string tblName, string fldname)
//        {
//            int id = 0;

//            string sql = "select max(" + fldname + ") as NextID from " + tblName;
//            SqlDataAdapter adapter = new SqlDataAdapter();
//            DataSet Ds = new DataSet();

//            string connectionString = ConnectionManager.connectionString;
//            SqlConnection Connection = ConnectionManager.connection();

//            if (Connection.State == ConnectionState.Closed)
//            {
//                try
//                {
//                    Connection.Open();

//                }
//                catch
//                {

//                }
//            }
//            try
//            {

//                adapter.SelectCommand = new SqlCommand(sql, Connection);
//                adapter.Fill(Ds);
//                Connection.Close();
//                Connection.Dispose();

//                try
//                {
//                    id = Convert.ToInt32(Ds.Tables[0].Rows[0][0]) + 1;
//                }
//                catch (Exception Ex)
//                {
//                    id = 0;
//                }

//            }
//            catch (Exception Ex)
//            {
//                Data.Execute("insert into Errors (Error_Page,Error_Data ,Error_Method) values ('ClassData','" + Ex.Data + "','GetNextID');");
//            }
//            return id;
//        }
//        static public int GetNextID_Transaction(string tblName, string fldname, SqlConnection connection)
//        {
//            int id = 0;

//            string sql = "select max(" + fldname + ") as NextID from " + tblName;
//            SqlDataAdapter adapter = new SqlDataAdapter();
//            DataSet Ds = new DataSet();

//            try
//            {
//                adapter.SelectCommand = new SqlCommand(sql, connection);
//                adapter.Fill(Ds);
//                try
//                {
//                    id = Convert.ToInt32(Ds.Tables[0].Rows[0][0]) + 1;
//                }
//                catch (Exception Ex)
//                {
//                    id = 0;
//                }

//            }
//            catch (Exception Ex)
//            {
//                Data.Execute("insert into Errors (Error_Page,Error_Data ,Error_Method) values ('ClassData','" + Ex.Data + "','GetNextID_Transaction');");
//            }
//            return id;
//        }
//        static public int check_value(string Table_Name, ArrayList Column_Name, ArrayList Value, ArrayList string_con)
//        {
//            ArrayList col = new ArrayList();
//            col = Column_Name;
//            ArrayList where_col = new ArrayList();
//            ArrayList where_value = new ArrayList();
//            for (int i = 0; i < Column_Name.Count; i++)
//            {
//                where_col.Add(Column_Name[i]);
//                where_value.Add(Value[i]);
//            }
//            int x = -1;
//            DataSet ds = GetElements2(Table_Name, col, where_col, where_value, string_con);
//            if (ds != null)
//            {
//                if (ds.Tables[0].Rows.Count > 0)
//                {
//                    x = 1;
//                }
//                else
//                {
//                    x = 0;
//                }
//            }
//            return x;
//        }
//        static public DataSet Execute(string Sql)
//        {
//            DataSet ds = new DataSet(); // Define the DataSet
//            try
//            {

//                using (SqlConnection cn = ConnectionManager.connection())
//                {
//                    cn.Open();
//                    using (SqlCommand cmd = new SqlCommand())
//                    {
//                        cmd.Connection = cn;
//                        cmd.CommandText = Sql;
//                        cmd.CommandTimeout = 0;
//                        using (SqlDataAdapter dr = new SqlDataAdapter(cmd))
//                        {
//                            dr.Fill(ds);
//                        }
//                    }

//                }

//            }
//            catch (Exception Ex)
//            {
//                //Data.Execute("insert into Errors (Error_Page,Error_Data ,Error_Method) values ('ClassData','" + Ex.Data + Sql + "','Execute');");
//                //DataSet set = null;
//                //return set;
//            }
//            return ds;
//        }
//        // function view
//        static public string GetMSG(string lang, string msgType)
//        {
//            string MSG = string.Empty;
//            if (lang.ToLower() == "en-us")
//            {
//                switch (msgType)
//                {
//                    case "rec_count":
//                        MSG = "Records: ";
//                        break;
//                    case "no_credit":
//                        MSG = "There is no balance remaining to that employee, you can not save";
//                        break;
//                    case "no_transact":
//                        MSG = "Activities are registered in the same period, you can not save";
//                        break;
//                    case "no_permission":
//                        MSG = "You do not have permission to perform this operation";
//                        break;
//                    case "save_success":
//                        MSG = "Data saved successfully";
//                        break;
//                    case "save_fail":
//                        MSG = "Save failed";
//                        break;
//                    case "update_success":
//                        MSG = "Data updated successfully";
//                        break;
//                    case "update_fail":
//                        MSG = "Update failed";
//                        break;
//                    case "delete_success":
//                        MSG = "Data deleted successfully";
//                        break;
//                    case "delete_fail":
//                        MSG = "Delete failed";
//                        break;
//                    case "rec_related":
//                        MSG = "There are related records, you can not delete";
//                        break;
//                    case "group_no_upd":
//                        MSG = "This group can not de modified";
//                        break;
//                    case "group_no_del":
//                        MSG = "This group can not de deleted";
//                        break;
//                    case "user_no_del":
//                        MSG = "This user can not de deleted";
//                        break;
//                    case "Emp_ret_success":
//                        MSG = "Employee returned";
//                        break;
//                    case "Emp_ret_fail":
//                        MSG = "Returning employee failed";
//                        break;
//                    case "already_updated":
//                        MSG = "Authorities already updated";
//                        break;
//                    case "group_exist":
//                        MSG = "There is a group with the same name, please write another name";
//                        break;
//                    case "user_exist":
//                        MSG = "There is a user with the same name, please write another name";
//                        break;
//                    case "no_remain_time":
//                        MSG = "There is no balance remaining to that employee, you can not save";
//                        break;
//                    case "longer_time":
//                        MSG = "Permission time is longer than the maximum, you can not save";
//                        break;
//                    case "temp_time_exist":
//                        MSG = "There is Occasional work time name with the same name, please change the name";
//                        break;
//                    case "user_active_before":
//                        MSG = "User's account is actived before";
//                        break;
//                    case "user_actived":
//                        MSG = "User actived successfully";
//                        break;
//                    case "select_file":
//                        MSG = "First, select file to be deleted";
//                        break;
//                    case "code_exist":
//                        MSG = "This code is registered to another empoyee";
//                        break;
//                    case "CivilID_exist":
//                        MSG = "This Civil ID is registered to another empoyee";
//                        break;
//                    case "check_data":
//                        MSG = "Please review the data";
//                        break;
//                    case "add_file":
//                        MSG = "Please make sure adding file";
//                        break;
//                    case "select_file_type":
//                        MSG = "Please make sure selecting file type";
//                        break;
//                    case "no_sub_add":
//                        MSG = "Can not add sub-unit to a division";
//                        break;
//                    case "no_upd_unit":
//                        MSG = "Can not modify this unit";
//                        break;
//                    case "name_exist":
//                        MSG = "There is a record with the same name";
//                        break;
//                    case "ckecked_more":
//                        MSG = "Checked fields should be less than or equal 10";
//                        break;
//                    case "no_parent_itself":
//                        MSG = "Can not determine a parent to itself";
//                        break;
//                    case "end_Previous_wait":
//                        MSG = "The previous wait period did not ended that strat from date ";
//                        break;
//                    case "end_Previous_trans":
//                        MSG = "The previous transfer period did not ended that start from date ";
//                        break;
//                    case "end_Previous_vac":
//                        MSG = "The previous vacation period did not ended that start from date ";
//                        break;


//                }
//            }
//            else
//            {
//                switch (msgType)
//                {
//                    case "rec_count":
//                        MSG = "ÚÏÏ ÇáÓÌáÇÊ: ";
//                        break;
//                    case "no_credit":
//                        MSG = "áÇ íæÌÏ ÑÕíÏ ãÊÈÞí áåÐÇ ÇáãæÙÝ , áÇ íãßäß ÇáÍÝÙ";
//                        break;
//                    case "no_transact":
//                        MSG = "ÊæÌÏ ÍÑßÇÊ ãÓÌáÉ Ýí äÝÓ ÇáÝÊÑÉ , áÇ íãßäß ÇáÍÝÙ";
//                        break;
//                    case "no_permission":
//                        MSG = "áíÓ áÏíß ÕáÇÍíÉ áÊäÝíÐ åÐå ÇáÚãáíÉ";
//                        break;
//                    case "save_success":
//                        MSG = "Êã ÍÝÙ ÇáÈíÇäÇÊ ÈäÌÇÍ";
//                        break;
//                    case "save_fail":
//                        MSG = "ÝÔáÊ ÚãáíÉ ÇáÍÝÙ";
//                        break;
//                    case "update_success":
//                        MSG = "Êã ÊÍÏíË ÇáÈíÇäÇÊ";
//                        break;
//                    case "update_fail":
//                        MSG = "ÝÔáÊ ÚãáíÉ ÇáÊÍÏÈË";
//                        break;
//                    case "delete_success":
//                        MSG = "ÊãÊ ÚãáíÉ ÇáÍÐÝ ÈäÌÇÍ";
//                        break;
//                    case "delete_fail":
//                        MSG = "ÝÔáÊ ÚãáíÉ ÇáÍÐÝ";
//                        break;
//                    case "rec_related":
//                        MSG = "ÊæÌÏ ÓÌáÇÊ ãÑÊÈØÉ, áÇ íãßäß ÇáÍÐÝ";
//                        break;
//                    case "group_no_upd":
//                        MSG = "áÇ íãßä ÊÚÏíá åÐå ÇáãÌãæÚÉ";
//                        break;
//                    case "group_no_del":
//                        MSG = "áÇ íãßä ÍÐÝ åÐå ÇáãÌãæÚÉ";
//                        break;
//                    case "user_no_del":
//                        MSG = "áÇ íãßä ÍÐÝ åÐÇ ÇáãÓÊÎÏã";
//                        break;
//                    case "Emp_ret_success":
//                        MSG = "Êã ÅÚÇÏÉ ÇáãæÙÝ";
//                        break;
//                    case "Emp_ret_fail":
//                        MSG = "ÝÔáÊ ÚãáíÉ ÇáÅÚÇÏÉ";
//                        break;
//                    case "already_updated":
//                        MSG = "ÇáÕáÇÍíÇÊ ãÍÏËÉ ÈÇáÝÚá";
//                        break;

//                    case "group_exist":
//                        MSG = "ÊæÌÏ ãÌãæÚÉ ÈäÝÓ ÇáÇÓã , ÈÑÌÇÁ ÇÎÊíÇÑ ÇÓã ÂÎÑ";
//                        break;
//                    case "user_exist":
//                        MSG = "íæÌÏ ãÓÊÎÏã ÈäÝÓ ÇáÇÓã , ÈÑÌÇÁ ÇÎÊíÇÑ ÇÓã ÂÎÑ";
//                        break;
//                    case "no_remain_time":
//                        MSG = "áÇ íæÌÏ ÑÕíÏ ãÊÈÞí áåÐÇ ÇáãæÙÝ, áÇ íãßäß ÇáÍÝÙ";
//                        break;
//                    case "longer_time":
//                        MSG = "ãÏÉ ÇáÅÐä ÃØæá ãä ÇáÍÏ ÇáÃÞÕì, áÇ íãßäß ÇáÍÝÙ";
//                        break;
//                    case "temp_time_exist":
//                        MSG = "íæÌÏ ÏæÇã ãÄÞÊ ÈäÝÓ ÇáÇÓã Ýí åÐÇ ÇáÏæÇã , ÈÑÌÇÁ ÊÛííÑ ÇáÇÓã";
//                        break;
//                    case "user_active_before":
//                        MSG = "åÐÇ ÇáãÓÊÎÏã ÍÓÇÈå ãÝÚá ãä ÞÈá";
//                        break;
//                    case "user_actived":
//                        MSG = "Êã ÊÝÚíá ÇáãÓÊÎÏã ÈäÌÇÍ";
//                        break;
//                    case "select_file":
//                        MSG = "ÇáÑÌÇÁ ÇÎÊíÇÑ ÇáãáÝ ÇáãÑÇÏ ÍÐÝå ÃæáÇð";
//                        break;
//                    case "code_exist":
//                        MSG = "ßæÏ ÇáãæÙÝ ãÓÌá áãæÙÝ ÂÎÑ";
//                        break;
//                    case "CivilID_exist":
//                        MSG = "ÇáÑÞã ÇáãÏäì ãÓÌá áãæÙÝ ÂÎÑ";
//                        break;
//                    case "check_data":
//                        MSG = "ÈÑÌÇÁ ãÑÇÌÚÉ ÇáÈíÇäÇÊ";
//                        break;
//                    case "add_file":
//                        MSG = "ÇáÑÌÇÁ ÇáÊÇßÏ ãä ÅÖÇÝÉ ãáÝ";
//                        break;
//                    case "select_file_type":
//                        MSG = "ÇáÑÌÇÁ ÇÎÊíÇÑ äæÚ ÇáãáÝ";
//                        break;
//                    case "no_sub_add":
//                        MSG = "áÇ íãßä ÅÖÇÝÉ æÍÏÉ ÝÑÚíÉ áÞÓã";
//                        break;
//                    case "no_upd_unit":
//                        MSG = "áÇ íãßä ÊÚÏíá åÐå ÇáæÍÏÉ";
//                        break;
//                    case "name_exist":
//                        MSG = "íæÌÏ ÓÌá ÈäÝÓ ÇáÇÓã";
//                        break;
//                    case "ckecked_more":
//                        MSG = " ÇáÚäÇÕÑ ÇáãÎÊÇÑÉ íÌÈ Çä Êßæä ÃÞá ãä Çæ ÊÓÇæí 10";
//                        break;
//                    case "no_parent_itself":
//                        MSG = "ÇáãæÞÚ ÇáÊÇÈÚ áå áÇ íãßä Ãä íßæä äÝÓ ÇáãæÞÚ ";
//                        break;
//                    case "end_Previous_wait":
//                        MSG = "ÝÊÑÉ ÇáÇäÊÙÇÑ ÇáÓÇÈÞÉ áã íÊã ÅäåÇÆåÇ æÇáÊí ÊÈÏÃ ãä ÊÇÑíÎ ";
//                        break;
//                    case "end_Previous_trans":
//                        MSG = "ÝÊÑÉ ÇáäÞá ÇáÓÇÈÞÉ áã íÊã ÅäåÇÆåÇ æÇáÊí ÊÈÏÃ ãä ÊÇÑíÎ ";
//                        break;
//                    case "end_Previous_vac":
//                        MSG = "ÝÊÑÉ ÇáÇÌÇÒÉ ÇáÓÇÈÞÉ áã íÊã ÅäåÇÆåÇ æÇáÊí ÊÈÏÃ ãä ÊÇÑíÎ ";
//                        break;

//                }

//            }
//            return MSG;
//        }


//        static public DataSet GetElements1(string TableName, ArrayList FieldNames, ArrayList where_field, ArrayList where_value)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    command.Parameters.Clear();
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();

//                    string where_condition = " where ";
//                    string where_condition1 = "";
//                    for (int i = 0; i <= where_field.Count - 1; i++)
//                    {

//                        where_condition1 += where_field[i] + "=" + command.Parameters.AddWithValue("@" + where_field[i].ToString(), where_value[i].ToString());
//                        if (i < where_value.Count - 1)
//                        {
//                            where_condition1 += " and ";
//                        }

//                    }
//                    where_condition = where_condition + where_condition1;
//                    command.CommandText = COracle.SelectGenerator1(TableName, FieldNames, where_condition);

//                    SqlDataAdapter da = new SqlDataAdapter(command);
//                    DataSet set = new DataSet();
//                    da.Fill(set, "Security");
//                    return set;
//                }
//                catch (Exception Ex)
//                {
//                    DataSet set = null;

//                    Data.Execute("insert into Errors (Error_Page,Error_Data ,Error_Method) values ('ClassData','" + Ex.Data + "','GetElements1');");
//                    return set;
//                }

//            }
//        }

//        static public DataSet GetElements2(string TableName, ArrayList FieldNames, ArrayList where_field, ArrayList where_value, ArrayList string_condition)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    command.Parameters.Clear();
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();

//                    string where_condition = " where ";
//                    string where_condition1 = "";
//                    for (int i = 0; i <= where_field.Count - 1; i++)
//                    {

//                        where_condition1 += where_field[i] + " " + string_condition[i].ToString() + " " + command.Parameters.AddWithValue("@" + where_field[i].ToString(), where_value[i].ToString());
//                        if (i < where_value.Count - 1)
//                        {
//                            where_condition1 += " and ";
//                        }

//                    }
//                    where_condition = where_condition1;
//                    command.CommandText = COracle.SelectGenerator(TableName, FieldNames, where_condition);

//                    SqlDataAdapter da = new SqlDataAdapter(command);
//                    DataSet set = new DataSet();
//                    da.Fill(set, "Security");
//                    return set;
//                }
//                catch (Exception Ex)
//                {

//                    Data.Execute("insert into Errors (Error_Page,Error_Data ,Error_Method) values ('ClassData','" + Ex.Data + "','GetElements2');");
//                    DataSet set = null;
//                    return set;
//                }

//            }
//        }

//        static public DataSet GetElements(string TableName, ArrayList FieldNames, string WhereCondition, string ordrebyfield)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandTimeout = 0;
//                    command.CommandType = CommandType.Text;
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();
//                    command.CommandText = COracle.SelectGenerator(TableName, FieldNames, WhereCondition, ordrebyfield);

//                    SqlDataAdapter da = new SqlDataAdapter(command);
//                    DataSet set = new DataSet();
//                    da.Fill(set, "Security");
//                    return set;
//                }
//                catch (Exception Ex)
//                {

//                    Data.Execute("insert into Errors (Error_Page,Error_Data ,Error_Method) values ('ClassData','" + Ex.Data + "','GetElements');");
//                    DataSet set = null;
//                    return set;
//                }

//            }
//        }


//        static public int InsertItem(string TableName, ArrayList FieldNames, ArrayList FieldValues)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();
//                    command.CommandText = COracle.InsertGenerator(TableName, FieldNames, FieldValues);

//                    string str = " insert into " + TableName + "  ( ";
//                    string str1 = "";
//                    for (int i = 0; i <= FieldNames.Count - 1; i++)
//                    {

//                        str1 += FieldNames[i];
//                        if (i < FieldNames.Count - 1)
//                        {
//                            str1 += " ,";
//                        }

//                    }
//                    str1 += "  ) VALUES ( ";
//                    for (int i = 0; i <= FieldValues.Count - 1; i++)
//                    {
//                        str1 += command.Parameters.AddWithValue("@" + FieldNames[i].ToString(), FieldValues[i].ToString());
//                        if (i < FieldValues.Count - 1)
//                        {
//                            str1 += " , ";
//                        }
//                    }
//                    str1 += " ) ";
//                    command.CommandText = str + str1;



//                    return command.ExecuteNonQuery();

//                }
//                catch (Exception Ex)
//                {

//                    Data.Execute("insert into Errors (Error_Page,Error_Data ,Error_Method) values ('ClassData','" + Ex.Data + "','InsertItem');");
//                    return -1;
//                }
//            }
//        }


//        static public int InsertItem1(string TableName, ArrayList FieldNames, ArrayList FieldValues)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();
//                    //command.CommandText = COracle.InsertGenerator(TableName, FieldNames, FieldValues);

//                    string str = " insert into " + TableName + "  ( ";
//                    string str1 = "";
//                    for (int i = 0; i <= FieldNames.Count - 1; i++)
//                    {

//                        str1 += FieldNames[i];
//                        if (i < FieldNames.Count - 1)
//                        {
//                            str1 += " ,";
//                        }

//                    }
//                    str1 += "  ) VALUES ( ";
//                    for (int i = 0; i <= FieldValues.Count - 1; i++)
//                    {
//                        str1 += command.Parameters.AddWithValue("@" + FieldNames[i].ToString(), FieldValues[i].ToString());
//                        if (i < FieldValues.Count - 1)
//                        {
//                            str1 += " , ";
//                        }
//                    }
//                    str1 += " ) ";
//                    command.CommandText = str + str1;

//                    return command.ExecuteNonQuery();

//                }
//                catch (Exception Ex)
//                {


//                    //HttpContext.Current.Response.Redirect(@"~/ERRORPAGE.aspx");
//                    return -1;
//                }
//            }
//        }
//        // methods to insert date with parameter
//        static public int InsertItem_date(string TableName, ArrayList FieldNames, ArrayList FieldValues, ArrayList col_date, ArrayList val_date)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();
//                    //command.CommandText = COracle.InsertGenerator(TableName, FieldNames, FieldValues);

//                    string str = " insert into " + TableName + "  ( ";
//                    string str1 = "";
//                    for (int i = 0; i <= FieldNames.Count - 1; i++)
//                    {

//                        str1 += FieldNames[i];
//                        if (i < FieldNames.Count - 1)
//                        {
//                            str1 += " ,";
//                        }

//                    }
//                    str1 += " ,";
//                    for (int j = 0; j <= col_date.Count - 1; j++)
//                    {
//                        str1 += col_date[j];
//                        if (j < col_date.Count - 1)
//                        {
//                            str1 += " ,";
//                        }

//                    }
//                    str1 += "  ) VALUES ( ";
//                    for (int i = 0; i <= FieldValues.Count - 1; i++)
//                    {
//                        str1 += command.Parameters.AddWithValue("@" + FieldNames[i].ToString(), FieldValues[i].ToString());
//                        if (i < FieldValues.Count - 1)
//                        {
//                            str1 += " , ";
//                        }
//                    }
//                    str1 += " , ";
//                    for (int j = 0; j <= val_date.Count - 1; j++)
//                    {
//                        if (val_date[j] != null && val_date[j] != "")
//                        {
//                            str1 += " convert(datetime," + "'" + val_date[j].ToString() + "'" + " , 103) ";
//                            //str1 += " convert(datetime," + "'" + ((DateTime)val_date[j]).Date.ToShortDateString() + "'" + " , 103) ";
//                        }
//                        else
//                        {
//                            str1 += "NULL";
//                        }

//                        if (j < val_date.Count - 1)
//                        {
//                            str1 += " , ";
//                        }
//                    }
//                    str1 += " ) ";
//                    command.CommandText = str + str1;



//                    return command.ExecuteNonQuery();

//                }
//                catch (Exception Ex)
//                {

//                    return -1;
//                }
//            }
//        }

//        static public int InsertItem_Todaydate(string TableName, ArrayList FieldNames, ArrayList FieldValues, ArrayList col_date, ArrayList val_date)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();
//                    //command.CommandText = COracle.InsertGenerator(TableName, FieldNames, FieldValues);

//                    string str = " insert into " + TableName + "  ( ";
//                    string str1 = "";
//                    for (int i = 0; i <= FieldNames.Count - 1; i++)
//                    {

//                        str1 += FieldNames[i];
//                        if (i < FieldNames.Count - 1)
//                        {
//                            str1 += " ,";
//                        }

//                    }
//                    str1 += " ,";
//                    for (int j = 0; j <= col_date.Count - 1; j++)
//                    {
//                        str1 += col_date[j];
//                        if (j < col_date.Count - 1)
//                        {
//                            str1 += " ,";
//                        }

//                    }
//                    str1 += "  ) VALUES ( ";
//                    for (int i = 0; i <= FieldValues.Count - 1; i++)
//                    {
//                        str1 += command.Parameters.AddWithValue("@" + FieldNames[i].ToString(), FieldValues[i].ToString());
//                        if (i < FieldValues.Count - 1)
//                        {
//                            str1 += " , ";
//                        }
//                    }
//                    str1 += " , ";
//                    for (int j = 0; j <= val_date.Count - 1; j++)
//                    {
//                        if (val_date[j] != null && val_date[j] != "")
//                        {
//                            str1 += " convert(datetime," + val_date[j].ToString() + " , 103) ";
//                            //str1 += " convert(datetime," + "'" + ((DateTime)val_date[j]).Date.ToShortDateString() + "'" + " , 103) ";
//                        }
//                        else
//                        {
//                            str1 += "NULL";
//                        }

//                        if (j < val_date.Count - 1)
//                        {
//                            str1 += " , ";
//                        }
//                    }
//                    str1 += " ) ";
//                    command.CommandText = str + str1;



//                    return command.ExecuteNonQuery();

//                }
//                catch (Exception Ex)
//                {

//                    return -1;
//                }
//            }
//        }

//        static public int InsertItem2(string TableName, ArrayList FieldNames, ArrayList FieldValues)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();
//                    command.CommandText = COracle.InsertGenerator(TableName, FieldNames, FieldValues);

//                    //string str = " insert into " + TableName + "  ( ";
//                    //string str1 = "";
//                    //for (int i = 0; i <= FieldNames.Count - 1; i++)
//                    //{

//                    //    str1 += FieldNames[i];
//                    //    if (i < FieldNames.Count - 1)
//                    //    {
//                    //        str1 += " ,";
//                    //    }

//                    //}
//                    //str1 += "  ) VALUES ( ";
//                    //for (int i = 0; i <= FieldValues.Count - 1; i++)
//                    //{
//                    //    str1 += command.Parameters.AddWithValue(":" + FieldNames[i].ToString(), FieldValues[i].ToString());
//                    //    if (i < FieldValues.Count - 1)
//                    //    {
//                    //        str1 += " , ";
//                    //    }
//                    //}
//                    //str1 += " ) ";
//                    //command.CommandText = str + str1;

//                    return command.ExecuteNonQuery();

//                }
//                catch (Exception Ex)
//                {

//                    return -1;
//                }
//            }
//        }

//        static public int DeleteItem(string TableName, string WhereCondition)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();
//                    command.CommandText = COracle.DeleteGenerator(TableName, WhereCondition);
//                    return command.ExecuteNonQuery();
//                }
//                catch (Exception Ex)
//                {

//                    return -1;
//                }
//            }
//        }

//        static public int UpdateItem(string TableName, ArrayList FieldNames, ArrayList FieldValues, string WhereCondition)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();
//                    command.CommandText = COracle.UpdateGenerator(TableName, FieldNames, FieldValues, WhereCondition);
//                    return command.ExecuteNonQuery();
//                }
//                catch (Exception Ex)
//                {

//                    return -1;
//                }
//            }
//        }


//        static public bool CompareTowDates(DateTime FirstDate, DateTime SecondDate)
//        {
//            if (FirstDate.Year < SecondDate.Year)
//            {
//                return true;
//            }
//            else
//            {
//                if (FirstDate.Year == SecondDate.Year)
//                {
//                    if (FirstDate.Month < SecondDate.Month)
//                    {
//                        return true;
//                    }
//                    else
//                    {
//                        if (FirstDate.Month == SecondDate.Month)
//                        {
//                            if (FirstDate.Day < SecondDate.Day)
//                            {
//                                return true;
//                            }
//                        }
//                    }
//                }
//            }
//            return false;
//        }

//        static public string Convert_To_HijiryDate(DateTime Date)
//        {
//            string x3 = null;
//            string x4 = null;
//            System.Globalization.UmAlQuraCalendar um = new System.Globalization.UmAlQuraCalendar();
//            int x = um.GetYear(Date);
//            int x1 = um.GetMonth(Date);
//            int x2 = um.GetDayOfMonth(Date);
//            if (x2 < 10)
//            {

//                x3 = "0" + x2.ToString();
//            }
//            else
//            {
//                x3 = x2.ToString();
//            }
//            if (x1 < 10)
//            {
//                x4 = "0" + x1.ToString();
//            }
//            else
//            {
//                x4 = x1.ToString();
//            }
//            string HijreDate = x3 + "/" + x4.ToString() + "/" + x.ToString();
//            return string.Format("{0:dd/MM/yyyy}", HijreDate);


//        }

//        static public string Convert_To_HijiryDate(string Date1)
//        {
//            DateTime Date = Convert.ToDateTime(Date1);
//            string x3 = null;
//            string x4 = null;
//            System.Globalization.UmAlQuraCalendar um = new System.Globalization.UmAlQuraCalendar();
//            int x = um.GetYear(Date);
//            int x1 = um.GetMonth(Date);
//            int x2 = um.GetDayOfMonth(Date);
//            if (x2 < 10)
//            {

//                x3 = "0" + x2.ToString();
//            }
//            else
//            {
//                x3 = x2.ToString();
//            }
//            if (x1 < 10)
//            {
//                x4 = "0" + x1.ToString();
//            }
//            else
//            {
//                x4 = x1.ToString();
//            }
//            string HijreDate = x3 + "/" + x4.ToString() + "/" + x.ToString();
//            return string.Format("{0:dd/MM/yyyy}", HijreDate);


//        }

//        static public DateTime Convert_To_MiladyDate(DateTime Date)
//        {

//            System.Globalization.UmAlQuraCalendar um = new System.Globalization.UmAlQuraCalendar();


//            DateTime dt = new DateTime();
//            return dt = um.ToDateTime(Date.Year, Date.Month, Date.Day, 0, 0, 0, 0);


//        }

//        public static DateTime Convert_To_MiladyDate1(string Date)
//        {
//            int year = int.Parse(Date.Substring(6, 4));
//            int moth = int.Parse(Date.Substring(3, 2));
//            int day = int.Parse(Date.Substring(0, 2));
//            System.Globalization.UmAlQuraCalendar um = new System.Globalization.UmAlQuraCalendar();
//            DateTime dt = new DateTime();
//            return dt = um.ToDateTime(year, moth, day, 0, 0, 0, 0);

//        }

//        public static string Convert_To_MiladyDate2(string Date)
//        {
//            int year = int.Parse(Date.Substring(6, 4));
//            int moth = int.Parse(Date.Substring(3, 2));
//            int day = int.Parse(Date.Substring(0, 2));
//            System.Globalization.UmAlQuraCalendar um = new System.Globalization.UmAlQuraCalendar();
//            DateTime dt = new DateTime();
//            dt = um.ToDateTime(year, moth, day, 0, 0, 0, 0);
//            return dt.ToShortDateString();

//        }

//        static public int UpdateItem1(string TableName, ArrayList FieldNames, ArrayList FieldValues, ArrayList Where_field, ArrayList where_value)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();
//                    //command.CommandText = COracle.UpdateGenerator(TableName, FieldNames, FieldValues, WhereCondition);
//                    string str = " update " + TableName + " set ";
//                    string str1 = "";
//                    for (int i = 0; i <= FieldNames.Count - 1; i++)
//                    {

//                        str1 += FieldNames[i] + "=" + command.Parameters.AddWithValue("@" + FieldNames[i].ToString(), FieldValues[i].ToString());
//                        if (i < FieldNames.Count - 1)
//                        {
//                            str1 += " ,";
//                        }

//                    }
//                    string where_condition = " where ";
//                    string where_condition1 = "";
//                    for (int i = 0; i <= Where_field.Count - 1; i++)
//                    {

//                        where_condition1 += Where_field[i] + "=" + command.Parameters.AddWithValue("@" + Where_field[i].ToString(), where_value[i].ToString());
//                        if (i < Where_field.Count - 1)
//                        {
//                            where_condition1 += " and ";
//                        }

//                    }
//                    where_condition = where_condition + where_condition1;
//                    string group = str + str1 + where_condition;
//                    //char[] ch = WhereCondition.ToCharArray();
//                    //string test = "";
//                    //string test2 = "";
//                    //for (int i = 0; i < ch.Length; i++)
//                    //{

//                    //    if (ch[i] != '=')
//                    //    {
//                    //        test += ch[i];
//                    //    }

//                    //    else
//                    //    {i++;
//                    //    test2 += ch[i];


//                    //    }
//                    //    if (test == " and"|| test=="  and" || test=="   and" || test=="    and" || test==" and " || test==" and  " || test==" and   " || test==" and    ")
//                    //    {
//                    //        test = "";
//                    //    }




//                    //}
//                    command.CommandText = group;
//                    return command.ExecuteNonQuery();
//                }
//                catch (Exception Ex)
//                {

//                    return -1;
//                }
//            }
//        }

//        static public int UpdateItem1_Transaction(string TableName, ArrayList FieldNames, ArrayList FieldValues, ArrayList Where_field, ArrayList where_value, SqlConnection connection)
//        {
//            //using (SqlConnection connection = ConnectionManager.connection())
//            //{
//            try
//            {
//                //connection.Open();
//                SqlCommand command = new SqlCommand();
//                command.Connection = connection;
//                command.CommandType = CommandType.Text;
//                command.CommandTimeout = 0;
//                cOracleDBManipulation COracle = new cOracleDBManipulation();
//                //command.CommandText = COracle.UpdateGenerator(TableName, FieldNames, FieldValues, WhereCondition);
//                string str = " update " + TableName + " set ";
//                string str1 = "";
//                for (int i = 0; i <= FieldNames.Count - 1; i++)
//                {

//                    str1 += FieldNames[i] + "=" + command.Parameters.AddWithValue("@" + FieldNames[i].ToString(), FieldValues[i].ToString());
//                    if (i < FieldNames.Count - 1)
//                    {
//                        str1 += " ,";
//                    }

//                }
//                string where_condition = " where ";
//                string where_condition1 = "";
//                for (int i = 0; i <= Where_field.Count - 1; i++)
//                {

//                    where_condition1 += Where_field[i] + "=" + command.Parameters.AddWithValue("@" + Where_field[i].ToString(), where_value[i].ToString());
//                    if (i < Where_field.Count - 1)
//                    {
//                        where_condition1 += " and ";
//                    }

//                }
//                where_condition = where_condition + where_condition1;
//                string group = str + str1 + where_condition;
//                //char[] ch = WhereCondition.ToCharArray();
//                //string test = "";
//                //string test2 = "";
//                //for (int i = 0; i < ch.Length; i++)
//                //{

//                //    if (ch[i] != '=')
//                //    {
//                //        test += ch[i];
//                //    }

//                //    else
//                //    {i++;
//                //    test2 += ch[i];


//                //    }
//                //    if (test == " and"|| test=="  and" || test=="   and" || test=="    and" || test==" and " || test==" and  " || test==" and   " || test==" and    ")
//                //    {
//                //        test = "";
//                //    }




//                //}
//                command.CommandText = group;
//                return command.ExecuteNonQuery();
//            }
//            catch (Exception Ex)
//            {

//                return -1;
//            }
//            //}
//        }
//        // update table with date formate
//        static public int UpdateItem_date(string TableName, ArrayList FieldNames, ArrayList FieldValues, ArrayList Where_field, ArrayList where_value, ArrayList date_col, ArrayList date_value)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();
//                    //command.CommandText = COracle.UpdateGenerator(TableName, FieldNames, FieldValues, WhereCondition);
//                    string str = " update " + TableName + " set ";
//                    string str1 = "";
//                    for (int i = 0; i <= FieldNames.Count - 1; i++)
//                    {

//                        str1 += FieldNames[i] + "=" + command.Parameters.AddWithValue("@" + FieldNames[i].ToString(), FieldValues[i].ToString());
//                        if (i < FieldNames.Count - 1)
//                        {
//                            str1 += " ,";
//                        }

//                    }
//                    str1 += " ,";
//                    for (int j = 0; j <= date_col.Count - 1; j++)
//                    {
//                        if (date_value[j] != null && date_value[j] != "")
//                        {
//                            str1 += date_col[j] + "=" + " convert(datetime, '" + date_value[j].ToString() + "'" + " , 103) ";
//                            //str1 += date_col[j] + "=" +" convert(datetime," + "'" + ((DateTime)date_value[j]).Date.ToShortDateString() + "'" +" , 103) ";
//                        }
//                        else
//                        {
//                            str1 += date_col[j] + " = " + " NULL ";
//                        }



//                        //      str1 += date_col[j] + "=" + " convert(datetime," + "'" + date_value[j].ToString() + "'" + " , 103) ";// date_col[j] + "=" + "TO_DATE('" + date_value[j].ToString() + "','dd/MM/yyyy hh:mi:ss am')"; 
//                        if (j < date_col.Count - 1)
//                        {
//                            str1 += " ,";
//                        }

//                    }
//                    string where_condition = " where ";
//                    string where_condition1 = "";
//                    for (int i = 0; i <= Where_field.Count - 1; i++)
//                    {

//                        where_condition1 += Where_field[i] + "=" + command.Parameters.AddWithValue("@" + Where_field[i].ToString(), where_value[i].ToString());
//                        if (i < Where_field.Count - 1)
//                        {
//                            where_condition1 += " and ";
//                        }

//                    }
//                    where_condition = where_condition + where_condition1;
//                    string group = str + str1 + where_condition;
//                    //char[] ch = WhereCondition.ToCharArray();
//                    //string test = "";
//                    //string test2 = "";
//                    //for (int i = 0; i < ch.Length; i++)
//                    //{

//                    //    if (ch[i] != '=')
//                    //    {
//                    //        test += ch[i];
//                    //    }

//                    //    else
//                    //    {i++;
//                    //    test2 += ch[i];


//                    //    }
//                    //    if (test == " and"|| test=="  and" || test=="   and" || test=="    and" || test==" and " || test==" and  " || test==" and   " || test==" and    ")
//                    //    {
//                    //        test = "";
//                    //    }




//                    //}
//                    command.CommandText = group;
//                    return command.ExecuteNonQuery();
//                }
//                catch (Exception Ex)
//                {

//                    return -1;
//                }
//            }
//        }
//        static public int UpdateItem_FullDate(string TableName, ArrayList FieldNames, ArrayList FieldValues, ArrayList Where_field, ArrayList where_value, ArrayList date_col, ArrayList date_value)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();
//                    string str = " update " + TableName + " set ";
//                    string str1 = "";
//                    for (int i = 0; i <= FieldNames.Count - 1; i++)
//                    {

//                        str1 += FieldNames[i] + "=" + command.Parameters.AddWithValue("@" + FieldNames[i].ToString(), FieldValues[i].ToString());
//                        if (i < FieldNames.Count - 1)
//                        {
//                            str1 += " ,";
//                        }

//                    }
//                    str1 += " ,";
//                    for (int j = 0; j <= date_col.Count - 1; j++)
//                    {
//                        if (date_value[j] != null && date_value[j] != "")
//                        {
//                            str1 += date_col[j] + "=" + " convert(datetime, '" + date_value[j].ToString() + "'" + " , 103) ";
//                        }
//                        else
//                        {
//                            str1 += date_col[j] + " = " + " NULL ";
//                        }
//                        if (j < date_col.Count - 1)
//                        {
//                            str1 += " ,";
//                        }

//                    }
//                    string where_condition = " where ";
//                    string where_condition1 = "";
//                    for (int i = 0; i <= Where_field.Count - 1; i++)
//                    {

//                        where_condition1 += Where_field[i] + "=" + command.Parameters.AddWithValue("@" + Where_field[i].ToString(), where_value[i].ToString());
//                        if (i < Where_field.Count - 1)
//                        {
//                            where_condition1 += " and ";
//                        }

//                    }
//                    where_condition = where_condition + where_condition1;
//                    string group = str + str1 + where_condition;

//                    command.CommandText = group;
//                    return command.ExecuteNonQuery();
//                }
//                catch (Exception Ex)
//                {

//                    return -1;
//                }
//            }
//        }





//        static public int UpdateItem1(string TableName, ArrayList FieldNames, ArrayList FieldValues, ArrayList Where_field, ArrayList where_value, int s)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();
//                    //command.CommandText = COracle.UpdateGenerator(TableName, FieldNames, FieldValues, WhereCondition);
//                    string str = " update " + TableName + " set ";
//                    string str1 = "";
//                    for (int i = 0; i <= FieldNames.Count - 1; i++)
//                    {

//                        str1 += FieldNames[i] + "=" + FieldValues[i].ToString();
//                        if (i < FieldNames.Count - 1)
//                        {
//                            str1 += " ,";
//                        }

//                    }
//                    string where_condition = " where ";
//                    string where_condition1 = "";
//                    for (int i = 0; i <= Where_field.Count - 1; i++)
//                    {

//                        where_condition1 += Where_field[i] + "=" + where_value[i].ToString();
//                        if (i < Where_field.Count - 1)
//                        {
//                            where_condition1 += " or ";
//                        }

//                    }
//                    where_condition = where_condition + where_condition1;
//                    string group = str + str1 + where_condition;
//                    //char[] ch = WhereCondition.ToCharArray();
//                    //string test = "";
//                    //string test2 = "";
//                    //for (int i = 0; i < ch.Length; i++)
//                    //{

//                    //    if (ch[i] != '=')
//                    //    {
//                    //        test += ch[i];
//                    //    }

//                    //    else
//                    //    {i++;
//                    //    test2 += ch[i];


//                    //    }
//                    //    if (test == " and"|| test=="  and" || test=="   and" || test=="    and" || test==" and " || test==" and  " || test==" and   " || test==" and    ")
//                    //    {
//                    //        test = "";
//                    //    }




//                    //}
//                    command.CommandText = group;
//                    return command.ExecuteNonQuery();
//                }
//                catch
//                {
//                    return -1;
//                }
//            }
//        }


//        static public DataTable ConvertTable_To_Hj(DataTable dataTable, string FristFieldName, string SecondFieldName)
//        {

//            int count = dataTable.Rows.Count;
//            if (FristFieldName != "" && SecondFieldName != "")
//            {
//                dataTable.Columns[FristFieldName].ColumnName = FristFieldName + "A";
//                dataTable.Columns[SecondFieldName].ColumnName = SecondFieldName + "A";
//                dataTable.Columns.Add(FristFieldName);
//                dataTable.Columns.Add(SecondFieldName);
//                for (int i = 0; i < count; i++)
//                {
//                    if (dataTable.Rows[i][FristFieldName + "A"].ToString() != "")
//                    {

//                        dataTable.Rows[i][FristFieldName] = Convert_To_HijiryDate(dataTable.Rows[i][FristFieldName + "A"].ToString());



//                    }
//                    if (dataTable.Rows[i][SecondFieldName + "A"].ToString() != "")
//                    {

//                        dataTable.Rows[i][SecondFieldName] = Convert_To_HijiryDate(dataTable.Rows[i][SecondFieldName + "A"].ToString());



//                    }
//                }
//            }
//            else if (FristFieldName == "" && SecondFieldName != "")
//            {


//                dataTable.Columns[SecondFieldName].ColumnName = SecondFieldName + "A";

//                dataTable.Columns.Add(SecondFieldName);
//                // dataTable.Columns[SecondFieldName].DataType.DeclaringType = System.Type.GetType("System.String");
//                for (int i = 0; i < count; i++)
//                {
//                    if (dataTable.Rows[i][SecondFieldName + "A"].ToString() != "")
//                    {

//                        dataTable.Rows[i][SecondFieldName] = Convert_To_HijiryDate(dataTable.Rows[i][SecondFieldName + "A"].ToString());



//                    }
//                }
//            }
//            else if (FristFieldName != "" && SecondFieldName == "")
//            {
//                dataTable.Columns[FristFieldName].ColumnName = FristFieldName + "A";
//                //dataTable.Columns[SecondFieldName].Caption = "secend";
//                dataTable.Columns.Add(FristFieldName);
//                // dataTable.Columns.Add(SecondFieldName);
//                // dataTable.Columns[FristFieldName].DataType.DeclaringType = System.Type.GetType("System.String");
//                for (int i = 0; i < count; i++)
//                {
//                    if (dataTable.Rows[i][FristFieldName + "A"].ToString() != "")
//                    {

//                        dataTable.Rows[i][FristFieldName] = Convert_To_HijiryDate(dataTable.Rows[i][FristFieldName + "A"].ToString());



//                    }
//                }
//            }

//            return dataTable;

//        }



//        // convert table with date time


//        static public DataTable ConvertTable_To_Hj2(DataTable dataTable, string FristFieldName, string SecondFieldName)
//        {

//            int count = dataTable.Rows.Count;
//            if (FristFieldName != "" && SecondFieldName != "")
//            {
//                dataTable.Columns[FristFieldName].ColumnName = "first";
//                dataTable.Columns[SecondFieldName].ColumnName = "secend";
//                dataTable.Columns.Add(FristFieldName);
//                dataTable.Columns.Add(SecondFieldName);
//                for (int i = 0; i < count; i++)
//                {
//                    if (dataTable.Rows[i]["first"].ToString() != "")
//                    {
//                        string time = dataTable.Rows[i]["first"].ToString();
//                        //HoursValue + ":" + MinutesValue + ":" + SecondsValue + " " + PeriodValue
//                        string time2 = time.Substring(11, 2) + ":" + time.Substring(14, 2) + ":" + time.Substring(17, 2) + " " + time.Substring(20, 1);

//                        dataTable.Rows[i][FristFieldName] = Convert_To_HijiryDate(dataTable.Rows[i]["first"].ToString()) + " " + time2;



//                    }
//                    if (dataTable.Rows[i]["secend"].ToString() != "")
//                    {
//                        string time = dataTable.Rows[i]["secend"].ToString();
//                        //HoursValue + ":" + MinutesValue + ":" + SecondsValue + " " + PeriodValue
//                        string time2 = time.Substring(11, 2) + ":" + time.Substring(14, 2) + ":" + time.Substring(17, 2) + " " + time.Substring(20, 1);

//                        dataTable.Rows[i][SecondFieldName] = Convert_To_HijiryDate(dataTable.Rows[i]["secend"].ToString()) + " " + time2;



//                    }
//                }
//            }
//            else if (FristFieldName == "" && SecondFieldName != "")
//            {
//                //dataTable.Columns[FristFieldName].ColumnName = "first";
//                dataTable.Columns[SecondFieldName].ColumnName = "secend";
//                //dataTable.Columns.Add(FristFieldName);
//                dataTable.Columns.Add(SecondFieldName);
//                for (int i = 0; i < count; i++)
//                {
//                    if (dataTable.Rows[i]["secend"].ToString() != "")
//                    {
//                        string time = dataTable.Rows[i]["secend"].ToString();
//                        //HoursValue + ":" + MinutesValue + ":" + SecondsValue + " " + PeriodValue
//                        string time2 = time.Substring(11, 2) + ":" + time.Substring(14, 2) + ":" + time.Substring(17, 2) + " " + time.Substring(20, 1);
//                        dataTable.Rows[i][SecondFieldName] = Convert_To_HijiryDate(dataTable.Rows[i]["secend"].ToString()) + " " + time2;



//                    }
//                }
//            }
//            else if (FristFieldName != "" && SecondFieldName == "")
//            {
//                dataTable.Columns[FristFieldName].ColumnName = "first";
//                //dataTable.Columns[SecondFieldName].ColumnName = "secend";
//                dataTable.Columns.Add(FristFieldName);
//                // dataTable.Columns.Add(SecondFieldName);

//                for (int i = 0; i < count; i++)
//                {
//                    if (dataTable.Rows[i]["first"].ToString() != "")
//                    {
//                        string time = dataTable.Rows[i]["first"].ToString();
//                        //HoursValue + ":" + MinutesValue + ":" + SecondsValue + " " + PeriodValue
//                        string time2 = time.Substring(11, 2) + ":" + time.Substring(14, 2) + ":" + time.Substring(17, 2) + " " + time.Substring(20, 1);
//                        dataTable.Rows[i][FristFieldName] = Convert_To_HijiryDate(dataTable.Rows[i]["first"].ToString()) + " " + time2;



//                    }
//                }
//            }

//            return dataTable;

//        }

//        // update to exp
//        static public int Update_T_IE(string id)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    bool result = false;
//                    SqlCommand Comm = new SqlCommand("PRC_IO_DELETE_IE_IM", connection);
//                    Comm.CommandType = CommandType.StoredProcedure;
//                    // Set the parameters
//                    Comm.Parameters.Add("p_id", SqlDbType.NVarChar).Value = id;

//                    // Comm.CommandText = group;
//                    return Comm.ExecuteNonQuery();
//                }
//                catch (Exception Ex)
//                {

//                    return -1;
//                }
//            }
//        }
//        static public int Update_T_IE2(string id_exp, string id_imp)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    bool result = false;
//                    SqlCommand Comm = new SqlCommand("PRC_IO_DELETE_IE_IM2", connection);
//                    Comm.CommandType = CommandType.StoredProcedure;
//                    // Set the parameters
//                    Comm.Parameters.Add("p_id1", SqlDbType.NVarChar).Value = id_exp;
//                    Comm.Parameters.Add("p_id2", SqlDbType.NVarChar).Value = id_imp;
//                    // Comm.CommandText = group;
//                    return Comm.ExecuteNonQuery();
//                }
//                catch (Exception Ex)
//                {

//                    return -1;
//                }
//            }
//        }

//        // THIS FUNCTION TO GET NEXT VALUES OF GENERAL IMPORT
//        static public void genimpnxtval(string curryear, ref string flag, ref string nextval, ref string nextval_year, ref string year)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//                try
//                {

//                    SqlCommand COM = new SqlCommand("PRC_IO_GENERAL_IMPORT_SEQUENCE", connection);
//                    COM.CommandType = CommandType.StoredProcedure;
//                    COM.Parameters.AddWithValue("p_year", curryear);//p_year
//                    //COM.Parameters.Add("p_seq_next_val", SqlDbType.Number).Direction = ParameterDirection.Output;
//                    //COM.Parameters.Add("p_string", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output;
//                    //COM.Parameters.Add("flag", SqlDbType.Number).Direction = ParameterDirection.Output;
//                    //COM.Parameters.Add("P_FLAG", SqlDbType.Number).Direction = ParameterDirection.Output;
//                    connection.Open();

//                    int x = COM.ExecuteNonQuery();
//                    nextval = COM.Parameters["p_seq_next_val"].Value.ToString();
//                    nextval_year = COM.Parameters["p_string"].Value.ToString();
//                    flag = COM.Parameters["P_FLAG"].Value.ToString();
//                    year = COM.Parameters["p_year"].Value.ToString();
//                    connection.Close();
//                }

//                catch (Exception Ex)
//                {

//                }
//        }

//        // THIS FUNCTION TO GET NEXT VALUES OF GENERAL EXPORT
//        static public void genexpnxtval(string curryear, ref string flag, ref string nextval, ref string nextval_year, ref string year)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//                try
//                {

//                    SqlCommand COM = new SqlCommand("PRC_IO_GENERAL_EXPORT_SEQUENCE", connection);
//                    COM.CommandType = CommandType.StoredProcedure;
//                    COM.Parameters.AddWithValue("p_year", curryear);//p_year
//                    //COM.Parameters.Add("p_seq_next_val", OracleType.Number).Direction = ParameterDirection.Output;
//                    //COM.Parameters.Add("p_string", OracleType.NVarChar, 200).Direction = ParameterDirection.Output;
//                    //COM.Parameters.Add("flag", OracleType.Number).Direction = ParameterDirection.Output;
//                    //COM.Parameters.Add("P_FLAG", OracleType.Number).Direction = ParameterDirection.Output;
//                    connection.Open();

//                    int x = COM.ExecuteNonQuery();
//                    nextval = COM.Parameters["p_seq_next_val"].Value.ToString();
//                    nextval_year = COM.Parameters["p_string"].Value.ToString();
//                    flag = COM.Parameters["P_FLAG"].Value.ToString();
//                    year = COM.Parameters["p_year"].Value.ToString();
//                    connection.Close();
//                }

//                catch (Exception Ex)
//                {

//                }
//        }

//        // THIS FUNCTION TO GET NEXT VALUES OF INTERNAL EXPORT
//        static public void intexpnxtval(string curryear, ref string flag, ref string nextval, ref string nextval_year, ref string year)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//                try
//                {

//                    SqlCommand COM = new SqlCommand("PRC_IO_INTERNAL_EXPORT_SEQ", connection);
//                    COM.CommandType = CommandType.StoredProcedure;
//                    COM.Parameters.AddWithValue("p_year", curryear);//p_year
//                    //COM.Parameters.Add("p_seq_next_val", SqlDbType.Number).Direction = ParameterDirection.Output;
//                    //COM.Parameters.Add("p_string", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output;
//                    //COM.Parameters.Add("flag", SqlDbType.Number).Direction = ParameterDirection.Output;
//                    //COM.Parameters.Add("P_FLAG", SqlDbType.Number).Direction = ParameterDirection.Output;
//                    connection.Open();

//                    int x = COM.ExecuteNonQuery();
//                    nextval = COM.Parameters["p_seq_next_val"].Value.ToString();
//                    nextval_year = COM.Parameters["p_string"].Value.ToString();
//                    flag = COM.Parameters["P_FLAG"].Value.ToString();
//                    year = COM.Parameters["p_year"].Value.ToString();
//                    connection.Close();
//                }

//                catch (Exception Ex)
//                {

//                }
//        }


//        // THIS FUNCTION TO GET NEXT VALUES OF INTERNAL IMPORT
//        static public void intimpnxtval(string curryear, ref string flag, ref string nextval, ref string nextval_year, ref string year)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//                try
//                {

//                    SqlCommand COM = new SqlCommand("PRC_IO_INTERNAL_IMPORT_SEQ", connection);
//                    COM.CommandType = CommandType.StoredProcedure;
//                    COM.Parameters.AddWithValue("p_year", curryear);//p_year
//                    //COM.Parameters.Add("p_seq_next_val", SqlDbType.Number).Direction = ParameterDirection.Output;
//                    //COM.Parameters.Add("p_string", SqlDbType.NVarChar, 200).Direction = ParameterDirection.Output;
//                    //COM.Parameters.Add("flag", SqlDbType.Number).Direction = ParameterDirection.Output;
//                    //COM.Parameters.Add("P_FLAG", SqlDbType.Number).Direction = ParameterDirection.Output;
//                    connection.Open();

//                    int x = COM.ExecuteNonQuery();
//                    nextval = COM.Parameters["p_seq_next_val"].Value.ToString();
//                    nextval_year = COM.Parameters["p_string"].Value.ToString();
//                    flag = COM.Parameters["P_FLAG"].Value.ToString();
//                    year = COM.Parameters["p_year"].Value.ToString();
//                    connection.Close();
//                }

//                catch (Exception Ex)
//                {

//                }
//        }
//        static public int Get_Numbers(string prc_name)
//        {
//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand Comm = new SqlCommand(prc_name, connection);
//                    Comm.CommandType = CommandType.StoredProcedure;
//                    // Set the parameters
//                    Comm.Parameters.Add("FLAG", SqlDbType.Int).Direction = ParameterDirection.Output;
//                    // Comm.CommandText = group;
//                    return Comm.ExecuteNonQuery();
//                }
//                catch (Exception Ex)
//                {
//                    return -1;
//                }
//            }
//        }
//        static public DataTable GetElements_parm(string TableName)
//        {

//            using (SqlConnection connection = ConnectionManager.connection())
//            {
//                try
//                {
//                    connection.Open();
//                    SqlCommand command = new SqlCommand();
//                    command.Connection = connection;
//                    command.CommandType = CommandType.Text;
//                    cOracleDBManipulation COracle = new cOracleDBManipulation();

//                    //command.CommandText = COracle.SelectGenerator(TableName, FieldNames, where_condition);
//                    command.CommandText = TableName;

//                    SqlDataAdapter da = new SqlDataAdapter(command);
//                    DataTable set = new DataTable();
//                    da.Fill(set);
//                    return set;
//                }
//                catch (Exception Ex)
//                {

//                    DataTable set = null;
//                    return set;
//                }

//            }

//        }

//        static public void UpdateDelays(int employee, int month, int year)
//        {
//            try
//            {
//                //            DataTable tbl_emp =  Data.Execute(@"select distinct emp_sn from employees inner join delays on delay_emp=emp_sn 
//                //            where emp_ISterminated <> 'true' and  MONTH(delay_date) = " + month +
//                //    " and year(delay_date) = " + year).Tables[0];

//                //for (int L = 0; L < tbl_emp.Rows.Count; L++)
//                //{
//                // int employee = int.Parse(tbl_emp.Rows[L]["emp_sn"].ToString());

//                int total_credit = 0;

//                //(1) delete all records for this employee in this month
//                Data.Execute(@"delete  from Delays_Credits where DelayCredit_emp=" + employee + @" and 
//            DelayCredit_month=" + month + " and DelayCredit_year= " + year);

//                // (2) Get the delays for this employee in this month and insert it into delays_credits
//                DataTable tbl_delays = Data.Execute(@"select delay_sn, convert(char(10),delay_date,111) as delay_date
//,datediff(minute,convert(char(5),delay_hfrom,108),convert(char(5),delay_hto,108)) as delay_period
//,convert(char(5),delay_hfrom,108) as delay_hfrom,convert(char(5),delay_hto,108) as delay_hto,delay_type 
//from delays where delay_emp=" + employee + " and MONTH(delay_date) = " + month +
//    " and year(delay_date) = " + year + " order by delay_date ").Tables[0];

//                for (int i = 0; i < tbl_delays.Rows.Count; i++)
//                {
//                    int delay_period = int.Parse(tbl_delays.Rows[i]["delay_period"].ToString());
//                    string delay_date = tbl_delays.Rows[i]["delay_date"].ToString();
//                    int delay_sn = int.Parse(tbl_delays.Rows[i]["delay_sn"].ToString());

//                    //insert delay record in delays_Credits
//                    Data.Execute(@"insert into Delays_Credits
//(DelayCredit_emp,DelayCredit_credit,DelayCredit_date,DelayCredit_type,DelayCredit_reason,DelayCredit_month,
//DelayCredit_year,DelayCredit_delaysn) values(" + employee + "," + delay_period + ",'" + delay_date
//    + "',1,1," + month + "," + year + "," + delay_sn + ")");

//                    total_credit += delay_period;

//                }

//                // (3) Check the attendance for days that have delay for this employee

//                // (a) Get the delay & attendance settings
//                DataTable setting_tbl = Data.Execute(@"select sett_femaleout,sett_pardon,sett_delays3 from 
//settings").Tables[0];

//                int sett_femaleout = int.Parse(setting_tbl.Rows[0]["sett_femaleout"].ToString());
//                int sett_pardon = int.Parse(setting_tbl.Rows[0]["sett_pardon"].ToString());
//                int sett_credit = int.Parse(setting_tbl.Rows[0]["sett_delays3"].ToString()) * 60;





//                for (int i = 0; i < tbl_delays.Rows.Count; i++)
//                {

//                    int delay_period = int.Parse(tbl_delays.Rows[i]["delay_period"].ToString());
//                    string delay_date = tbl_delays.Rows[i]["delay_date"].ToString();
//                    string delay_hfrom = tbl_delays.Rows[i]["delay_hfrom"].ToString();
//                    string delay_hto = tbl_delays.Rows[i]["delay_hto"].ToString();
//                    int delay_type = int.Parse(tbl_delays.Rows[i]["delay_type"].ToString());
//                    int delay_sn = int.Parse(tbl_delays.Rows[i]["delay_sn"].ToString());
//                    int delay = 0;
//                    int early = 0;
//                    int delay_direct = 0; // íÍÓÈ ÊÃÎíÑ ãÈÇÔÑÉ Ïæä ÇáÊÃßÏ ãä ÇáÑÕíÏ
//                    int early_direct = 0; // íÍÓÈ ÊÃÎíÑ ãÈÇÔÑÉ Ïæä ÇáÊÃßÏ ãä ÇáÑÕíÏ

//                    // (b) Get the begin & end of the attendance
//                    DataTable workperiods_tbl = Data.Execute(@"select exem_time
//,convert(varchar(5),Exem_hperiod,108) as Exem_hperiod, convert(varchar(5),work_attend,108) as work_attend
//,convert(varchar(5),work_leave,108) as work_leave,emp_sex from work_periods left outer join employees on 
//work_sn=case when period_id > 0 then period_id else 1 END left outer join Exemptions 
//on Exem_emp = emp_sn and Exem_from <= '" + delay_date + "' and Exem_to >= '" + delay_date + @"' where emp_sn=" + employee).Tables[0];

//                    int emp_sex = int.Parse(workperiods_tbl.Rows[0]["emp_sex"].ToString());
//                    string attend_begin = workperiods_tbl.Rows[0]["work_attend"].ToString();
//                    string attend_end = workperiods_tbl.Rows[0]["work_leave"].ToString();

//                    if (!(workperiods_tbl.Rows[0]["exem_time"] is DBNull))
//                    {
//                        int exem_time = int.Parse(workperiods_tbl.Rows[0]["exem_time"].ToString());
//                        string Exem_hperiod = workperiods_tbl.Rows[0]["Exem_hperiod"].ToString();
//                        if (exem_time == 1) // begin
//                        {
//                            TimeSpan attend_beginTimeSpan = TimeSpan.Parse(attend_begin);
//                            TimeSpan Exem_hperiodTimeSpan = TimeSpan.Parse(Exem_hperiod);
//                            TimeSpan NewTimeSpan = new TimeSpan(attend_beginTimeSpan.Hours + Exem_hperiodTimeSpan.Hours, attend_beginTimeSpan.Minutes, 0);
//                            attend_begin = NewTimeSpan.ToString();

//                            if (sett_femaleout > 0 && emp_sex == 1353)
//                            {
//                                TimeSpan attend_endTimeSpan = TimeSpan.Parse(attend_end);
//                                TimeSpan NewTimeSpan2 = new TimeSpan(attend_endTimeSpan.Hours, attend_endTimeSpan.Minutes - sett_femaleout, 0);
//                                attend_end = NewTimeSpan2.ToString();
//                            }
//                        }
//                        else
//                        {
//                            TimeSpan attend_endTimeSpan = TimeSpan.Parse(attend_end);
//                            TimeSpan Exem_hperiodTimeSpan = TimeSpan.Parse(Exem_hperiod);
//                            TimeSpan NewTimeSpan = new TimeSpan(attend_endTimeSpan.Hours - Exem_hperiodTimeSpan.Hours, attend_endTimeSpan.Minutes, 0);
//                            attend_end = NewTimeSpan.ToString();

//                            if (sett_pardon > 0)
//                            {
//                                TimeSpan attend_beginTimeSpan = TimeSpan.Parse(attend_begin);
//                                TimeSpan NewTimeSpan2 = new TimeSpan(attend_beginTimeSpan.Hours, attend_beginTimeSpan.Minutes + sett_pardon, 0);
//                                attend_begin = NewTimeSpan2.ToString();
//                            }
//                        }
//                    }

//                    else
//                    {
//                        if (sett_femaleout > 0 && emp_sex == 1353)
//                        {
//                            TimeSpan attend_endTimeSpan = TimeSpan.Parse(attend_end);
//                            TimeSpan NewTimeSpan = new TimeSpan(attend_endTimeSpan.Hours, attend_endTimeSpan.Minutes - sett_femaleout, 0);
//                            attend_end = NewTimeSpan.ToString();
//                        }

//                        if (sett_pardon > 0)
//                        {
//                            TimeSpan attend_beginTimeSpan = TimeSpan.Parse(attend_begin);
//                            TimeSpan NewTimeSpan = new TimeSpan(attend_beginTimeSpan.Hours, attend_beginTimeSpan.Minutes + sett_pardon, 0);
//                            attend_begin = NewTimeSpan.ToString();
//                        }
//                    }



//                    //(b) Get the attendance for this day for this employee
//                    //                DataTable attendance_tbl= Data.Execute(@"select convert(char(5),timeentry,108) as timeentry
//                    //,eventid from  employees inner join actatek_logs on actatek_logs.userid=emp_fingerpin  
//                    //where emp_sn=" + employee + " and convert(char(10),timeentry,111)='" + delay_date + "' ").Tables[0];

//                    // All IN fingerprints
//                    DataTable attendanceIN_tbl = Data.Execute(@"select timeentry,convert(varchar(5),timeentry,108) as timeentry2
//from  employees inner join actatek_logs on actatek_logs.userid=emp_fingerpin where emp_sn=" + employee +
//    " and convert(char(10),timeentry,111)='" + delay_date + "' and eventid='IN' order by timeentry").Tables[0];

//                    // All OUT fingerprints
//                    DataTable attendanceOUT_tbl = Data.Execute(@"select timeentry,convert(varchar(5),timeentry,108) as timeentry2
//from  employees inner join actatek_logs on actatek_logs.userid=emp_fingerpin where emp_sn=" + employee +
//    " and convert(char(10),timeentry,111)='" + delay_date + "' and eventid='OUT' order by timeentry").Tables[0];


//                    int FingerInCount = attendanceIN_tbl.Rows.Count;
//                    int FingerOutCount = attendanceOUT_tbl.Rows.Count;
//                    string FirstIn = "";
//                    string LastOut = "";

//                    if (FingerInCount > 0)
//                        FirstIn = attendanceIN_tbl.Rows[0]["timeentry2"].ToString();

//                    if (FingerOutCount > 0)
//                        LastOut = attendanceOUT_tbl.Rows[attendanceOUT_tbl.Rows.Count - 1]["timeentry2"].ToString();




//                    switch (delay_type)
//                    {
//                        // ÈÏÇíÉ Ãæ äåÇíÉ ÇáÏæÇã
//                        case 76121:
//                        case 76122:
//                            // ãáæÔ ÈÕãÉ ÏÎæá Ãæ ÎÑæÌ
//                            if (FingerOutCount == 0 || FingerInCount == 0)
//                            {
//                                if (FingerInCount > 0) // áå ÈÕãÉ ÏÎæá
//                                {
//                                    if (delay_type == 76121) // ÈÏÇíÉ ÇáÏæÇã
//                                    {
//                                        early = TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Hours * 60 + TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Minutes;
//                                        delay = 0;
//                                    }
//                                    else // äåÇíÉ ÇáÏæÇã
//                                    {
//                                        early = TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Hours * 60 + TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Minutes;
//                                        delay = 0;
//                                    }
//                                }
//                                else if (FingerOutCount > 0) // áå ÈÕãÉ ÎÑæÌ
//                                {
//                                    if (delay_type == 76121) // ÈÏÇíÉ ÇáÏæÇã
//                                    {
//                                        early = 0;
//                                        delay = TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Hours * 60 + TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Minutes;
//                                    }
//                                    else // äåÇíÉ ÇáÏæÇã
//                                    {
//                                        early = 0;
//                                        delay = TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Hours * 60 + TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Minutes;
//                                    }
//                                }
//                                else
//                                {
//                                    early = 0;
//                                    delay = 0;
//                                }


//                            }
//                            else // áå ÈÕãÇÊ ÏÎæá æ ÎÑæÌ
//                            {
//                                if (delay_type == 76121) // ÈÏÇíÉ ÇáÏæÇã
//                                {
//                                    delay_direct = TimeSpan.Parse(FirstIn).Subtract(TimeSpan.Parse(delay_hto)).Hours * 60 + TimeSpan.Parse(FirstIn).Subtract(TimeSpan.Parse(delay_hto)).Minutes;
//                                    early_direct = TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(LastOut)).Hours * 60 + TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(LastOut)).Minutes;
//                                }
//                                else // äåÇíÉ ÇáÏæÇã
//                                {
//                                    delay_direct = TimeSpan.Parse(FirstIn).Subtract(TimeSpan.Parse(attend_begin)).Hours * 60 + TimeSpan.Parse(FirstIn).Subtract(TimeSpan.Parse(attend_begin)).Minutes;
//                                    early_direct = TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(LastOut)).Hours * 60 + TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(LastOut)).Minutes;
//                                }
//                            }
//                            break;

//                        // ÃËäÇÁ ÇáÏæÇã
//                        case 76123:

//                            #region Perpare Data

//                            // Fingers In before begin of delay
//                            DataRow[] FingersInB4DelayBegin = attendanceIN_tbl.Select(" timeentry < #" + delay_date + " " + delay_hfrom + "# ", " timeentry ");

//                            // Fingers Out before End of delay
//                            DataRow[] FingersOutB4DelayEnd = attendanceOUT_tbl.Select(" timeentry < #" + delay_date + " " + delay_hto + "# ", " timeentry ");

//                            // Fingers In after begin of delay
//                            DataRow[] FingersInAfterDelayBegin = attendanceIN_tbl.Select(" timeentry > #" + delay_date + " " + delay_hfrom + "#", " timeentry ");

//                            // Fingers Out after End of delay
//                            DataRow[] FingersOutAfterDelayEnd = attendanceOUT_tbl.Select(" timeentry > #" + delay_date + " " + delay_hto + "# ", " timeentry ");

//                            // First In after begin of delay
//                            string FirstInAfterDelayBegin = "";
//                            string LastOutB4DelayEnd = "";

//                            if (FingersInAfterDelayBegin.Length > 0)
//                                FirstInAfterDelayBegin = FingersInAfterDelayBegin[0][1].ToString();

//                            if (FingersOutB4DelayEnd.Length > 0)
//                                LastOutB4DelayEnd = FingersOutB4DelayEnd[FingersOutB4DelayEnd.Length - 1][1].ToString();

//                            #endregion

//                            bool MissingAttendanceFP = false;
//                            bool MissingLeaveFP = false;

//                            // ÛíÇÈ
//                            if (FingerOutCount == 0 && FingerInCount == 0)
//                            {
//                                break;
//                            }

//                            // ãáæÔ ÈÕãÉ ÏÎæá Ãæ ÎÑæÌ
//                            else if (FingerOutCount == 0 || FingerInCount == 0)
//                            {
//                                delay = TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Hours * 60 + TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Minutes;
//                                early = TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Hours * 60 + TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Minutes;

//                                MissingAttendanceFP = true;
//                                MissingLeaveFP = true;
//                            }
//                            else
//                            {
//                                // ãÝíÔ ÈÕãÉ ÏÎæá ÞÈá ÈÏÇíÉ ÇáÇÐä Ãæ ãÝíÔ ÈÕãÉ ÎÑæÌ ÞÈá äåÇíÉ ÇáÇÐä
//                                if (FingersInB4DelayBegin.Length == 0 || FingersOutB4DelayEnd.Length == 0)
//                                {
//                                    delay = TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Hours * 60 + TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Minutes;
//                                    MissingAttendanceFP = true;
//                                }

//                                // ãÝíÔ ÈÕãÉ ÏÎæá ÈÚÏ ÈÏÇíÉ ÇáÇÐä Ãæ ãÝíÔ ÈÕãÉ ÎÑæÌ ÈÚÏ äåÇíÉ ÇáÇÐä
//                                if (FingersInAfterDelayBegin.Length == 0 || FingersOutAfterDelayEnd.Length == 0)
//                                {
//                                    early = TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Hours * 60 + TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Minutes;
//                                    MissingLeaveFP = true;
//                                }
//                            }

//                            if (!MissingAttendanceFP) // áã íÏÎá Ýí ÇáÍÇáÇÊ ÇáÓÇÈÞÉ ÈÇáäÓÈÉ áÊÃÎíÑ ÍÖæÑ
//                            {
//                                int x = TimeSpan.Parse(FirstIn).Subtract(TimeSpan.Parse(attend_begin)).Hours * 60 + TimeSpan.Parse(FirstIn).Subtract(TimeSpan.Parse(attend_begin)).Minutes;
//                                int y = TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(LastOutB4DelayEnd)).Hours * 60 + TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(LastOutB4DelayEnd)).Minutes;

//                                if (x < 0)
//                                    x = 0;

//                                if (y < 0)
//                                    y = 0;

//                                delay_direct = x + y;
//                            }
//                            if (!MissingLeaveFP) // áã íÏÎá Ýí ÇáÍÇáÇÊ ÇáÓÇÈÞÉ ÈÇáäÓÈÉ áÇäÕÑÇÝ ãÈßÑ
//                            {
//                                int x = TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(LastOut)).Hours * 60 + TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(LastOut)).Minutes;
//                                int y = TimeSpan.Parse(FirstInAfterDelayBegin).Subtract(TimeSpan.Parse(delay_hto)).Hours * 60 + TimeSpan.Parse(FirstInAfterDelayBegin).Subtract(TimeSpan.Parse(delay_hto)).Minutes;

//                                if (x < 0)
//                                    x = 0;

//                                if (y < 0)
//                                    y = 0;

//                                early_direct = x + y;
//                            }



//                            break;
//                    } // Switch

//                    if (delay < 0)
//                        delay = 0;
//                    if (early < 0)
//                        early = 0;

//                    int total_delays_Indirect = delay + early;

//                    if (delay_direct < 0)
//                        delay_direct = 0;
//                    if (early_direct < 0)
//                        early_direct = 0;

//                    int total_delays_direct = delay_direct + early_direct;

//                    if (total_delays_Indirect > 0)
//                    {
//                        int total_delay = delay + delay_direct;
//                        int total_early = early + early_direct;
//                        int total_delays = total_delays_direct + total_delays_Indirect;

//                        if (total_credit < sett_credit)
//                        {
//                            if (total_credit + total_delays_Indirect <= sett_credit)
//                            {
//                                //íÊã ÇáÎÕã ãä ÇáÑÕíÏ ÅÌãÇáí ÊÃÎíÑ åÐÇ Çáíæã
//                                Data.Execute(@"insert into Delays_Credits
//(DelayCredit_emp,DelayCredit_credit,DelayCredit_date,DelayCredit_type,DelayCredit_reason,DelayCredit_month,
//DelayCredit_year,DelayCredit_delaysn) values(" + employee + "," + total_delays_Indirect + ",'" + delay_date
//                + "',1,2," + month + "," + year + "," + delay_sn + ")");
//                                total_credit += total_delays_Indirect;

//                                // ÎÕã ÇáÊÃÎíÑ ÇáãÈÇÔÑ
//                                if (total_delays_direct > 0)
//                                {
//                                    //íÊã ÇáÎÕã ãä ÇáÊÃÎíÑ
//                                    Data.Execute(@"insert into Delays_Credits
//(DelayCredit_emp,DelayCredit_credit,DelayCredit_date,DelayCredit_type,DelayCredit_reason,DelayCredit_month,
//DelayCredit_year,DelayCredit_delay,DelayCredit_early,DelayCredit_delaysn) 
//values(" + employee + "," + total_delays_direct + ",'" + delay_date
//                    + "',2,2," + month + "," + year + "," + delay_direct + "," + early_direct + "," + delay_sn + ")");
//                                }
//                            }
//                            else
//                            {
//                                int FromCredit = sett_credit - total_credit;
//                                int FromDelay = total_delays_Indirect - FromCredit;

//                                if (delay >= FromDelay)
//                                {
//                                    delay = FromDelay;
//                                    early = 0;
//                                }
//                                else
//                                {
//                                    early = FromDelay - delay;
//                                }

//                                int delay_reminder = delay + delay_direct;
//                                int early_reminder = early + early_direct;

//                                int total_delay_reminder = delay_reminder + early_reminder;


//                                total_credit += total_delays_Indirect;

//                                //íÊã ÇáÎÕã ãä ÇáÑÕíÏ ÅÌãÇáí ÇáÊÃÎíÑ ÇáÐí íÓãÍ Èå ÇáÑÕíÏ
//                                Data.Execute(@"insert into Delays_Credits
//(DelayCredit_emp,DelayCredit_credit,DelayCredit_date,DelayCredit_type,DelayCredit_reason,DelayCredit_month,
//DelayCredit_year,DelayCredit_delaysn) values(" + employee + "," + FromCredit + ",'" + delay_date
//                + "',1,2," + month + "," + year + "," + delay_sn + ")");

//                                //íÊã ÇáÎÕã ãä ÇáÊÃÎíÑ ÇáæÞÊ ÇáÒÇÆÏ Úä ÇáÑÕíÏ
//                                Data.Execute(@"insert into Delays_Credits
//(DelayCredit_emp,DelayCredit_credit,DelayCredit_date,DelayCredit_type,DelayCredit_reason,DelayCredit_month,
//DelayCredit_year,DelayCredit_delay,DelayCredit_early,DelayCredit_delaysn) 
//values(" + employee + "," + total_delay_reminder + ",'" + delay_date
//                + "',2,2," + month + "," + year + "," + delay_reminder + "," + early_reminder + "," + delay_sn + ")");
//                            }
//                        }
//                        else // áÇ íæÌÏ ÑÕíÏ
//                        {
//                            //íÊã ÇáÎÕã ãä ÇáÊÃÎíÑ
//                            Data.Execute(@"insert into Delays_Credits
//(DelayCredit_emp,DelayCredit_credit,DelayCredit_date,DelayCredit_type,DelayCredit_reason,DelayCredit_month,
//DelayCredit_year,DelayCredit_delay,DelayCredit_early,DelayCredit_delaysn) 
//values(" + employee + "," + total_delays + ",'" + delay_date
//            + "',2,2," + month + "," + year + "," + total_delay + "," + total_early + "," + delay_sn + ")");

//                            total_credit += total_delays_Indirect;
//                        }
//                    }
//                    else if (total_delays_direct > 0)
//                    {
//                        //íÊã ÇáÎÕã ãä ÇáÊÃÎíÑ
//                        Data.Execute(@"insert into Delays_Credits
//(DelayCredit_emp,DelayCredit_credit,DelayCredit_date,DelayCredit_type,DelayCredit_reason,DelayCredit_month,
//DelayCredit_year,DelayCredit_delay,DelayCredit_early,DelayCredit_delaysn) 
//values(" + employee + "," + total_delays_direct + ",'" + delay_date
//        + "',2,2," + month + "," + year + "," + delay_direct + "," + early_direct + "," + delay_sn + ")");
//                    }

//                } // Big For
//                // }
//            }
//            catch (Exception ex)
//            {

//            }
//        }

//        static public ArrayList GetMonths(DateTime BigDate, DateTime SmallDate)
//        {
//            int currentMonth = BigDate.Month;
//            int currentYear = BigDate.Year;
//            ArrayList mydates = new ArrayList();

//            if (BigDate < SmallDate)
//            {
//                return mydates;
//            }

//            DateTime mydate = new DateTime(currentYear, currentMonth, 1);
//            mydates.Add(mydate);

//            while (SmallDate.Year != currentYear || SmallDate.Month != currentMonth)
//            {
//                if (currentMonth != 1)
//                {
//                    currentMonth--;
//                }
//                else
//                {
//                    currentMonth = 12;
//                    currentYear--;
//                }

//                mydate = new DateTime(currentYear, currentMonth, 1);
//                mydates.Add(mydate);
//            }

//            return mydates;
//        }


//        static public void SaveLogs(ArrayList FieldName, ArrayList Fieldvalue, string Action, string user, string page_name, string pk, string Log_Emp)
//        {

//            try
//            {
//                int Affect = Data.InsertItem("Logs", new ArrayList { "Log_User", "Log_Action", "Log_Page", "Log_PK", "Log_Emp" },
//                 new ArrayList { user, Action, page_name, pk, Log_Emp });
//                if (Affect > 0)
//                {
//                    string Detail_Log = Convert.ToString(Data.GetNextID("Logs", "Log_sn") - 1);
//                    for (int i = 0; i < Fieldvalue.Count; i++)
//                    {
//                        ArrayList fn1 = new ArrayList();
//                        ArrayList fl1 = new ArrayList();
//                        fn1.Add("Detail_FieldName");
//                        fl1.Add(FieldName[i].ToString());
//                        fn1.Add("Detail_Value");
//                        fl1.Add(Fieldvalue[i].ToString());

//                        fn1.Add("Log_sn");
//                        fl1.Add(Detail_Log);

//                        //fn1.Add("Detail_OldValue");
//                        //fl1.Add(FieldOldvaluelog[i].ToString());


//                        Data.InsertItem("Logs_Details", fn1, fl1);
//                    }
//                }
//            }
//            catch (Exception Ex)
//            {

//            }
//        }
//    }

}