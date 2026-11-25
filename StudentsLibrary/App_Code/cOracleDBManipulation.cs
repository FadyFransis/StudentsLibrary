//############################################################################
//'''''''''''''''''''''''»”„ «··Â «·—Õ„‰ «·—ÕÌ„'''''''''''''''''''''''
//Project Name: BLDG permits
//Company:  Orbits Engineering
//File Name: cOracleDBManipulation
//Title: All needed procedures for oracle database manipulation
//Requires: Oracle client
//Author : Eng. Mahmoud Ali
//Mail: engmahmoudali84@yahoo.com  
//Date:
//Last Updated: 2/3/2008 5:00 PM
//#############################################################################



using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


/// <summary>
/// Summary description for OraDBManipulation
/// </summary>
 
    public class cOracleDBManipulation
    {



        public cOracleDBManipulation()
        {
        }

        #region Function to generate SQL SELECT statment to select all fields

        public string SelectGenerator(string TableName)
        {
            string strSelectCommand;

            strSelectCommand = "SELECT * FROM " + TableName;

            return strSelectCommand;
        }

        #endregion


        #region Function to generate SQL SELECT statment to select all fields , and WHERE condition

        public string SelectGenerator(string TableName, string WhereCondition)
        {
            string strSelectCommand;

            strSelectCommand = "SELECT * FROM " + TableName + " WHERE " + WhereCondition;

            return strSelectCommand;

        }

        #endregion


        #region Function to generate SQL SELECT statment to select all fields , WHERE condition, and ORDER BY

        public string SelectGenerator(string TableName, string WhereCondition, string OrderbyFieldName)
        {
            string strSelectCommand;

            strSelectCommand = "SELECT * FROM " + TableName + " WHERE " + WhereCondition + " ORDER BY " + OrderbyFieldName;

            return strSelectCommand;
        }

        #endregion


        #region Function to generate SQL SELECT statment with FieldNames

        public string SelectGenerator(string TableName, ArrayList FieldNames)
        {
            string strSelectCommand;

            //Generate the select statment 
            strSelectCommand = "SELECT ";

            for (int i = 0; i <= FieldNames.Count - 1; i++)
            {
                if (i != FieldNames.Count - 1)
                {
                    strSelectCommand += FieldNames[i] + ", ";
                }
                else
                {
                    strSelectCommand += FieldNames[i];
                }

            }


            strSelectCommand += " FROM " + TableName;

            return strSelectCommand;
        }

        #endregion


        #region Function to generate SQL SELECT statment with FieldNames, and WHERE condition

        public string SelectGenerator(string TableName, ArrayList FieldNames, string WhereCondition, string GroupBy = "",bool isMail=false)
        {
            string strSelectCommand;

            //code to verify that the fieldnames are exist in the table

            //Generate the select statment 
            strSelectCommand = "SELECT ";

            for (int i = 0; i <= FieldNames.Count - 1; i++)
            {

                if (i != FieldNames.Count - 1)
                {
                    strSelectCommand += FieldNames[i] + ", ";
                }
                else
                {
                    strSelectCommand += FieldNames[i];
                }

            }
            if(GroupBy=="")
                strSelectCommand += " FROM " + TableName + " where  " + WhereCondition;
            else
                strSelectCommand += " FROM " + TableName + " where  " + WhereCondition + " GROUP BY  " + GroupBy;

        return strSelectCommand;
        }
        #endregion
        public string SelectGenerator1(string TableName, ArrayList FieldNames, string WhereCondition)
        {
            string strSelectCommand;

            //code to verify that the fieldnames are exist in the table

            //Generate the select statment 
            strSelectCommand = "SELECT ";

            for (int i = 0; i <= FieldNames.Count - 1; i++)
            {

                if (i != FieldNames.Count - 1)
                {
                    strSelectCommand += FieldNames[i] + ", ";
                }
                else
                {
                    strSelectCommand += FieldNames[i];
                }

            }
            strSelectCommand += " FROM " + TableName + WhereCondition;

            return strSelectCommand;
        }



        #region Function to generate SQL SELECT statment with FieldNames, WHERE condition, and ORDER BY
        /// <summary>
        /// Mahmoud ALI
        /// </summary>
        /// <param name="TableName">TableName : (string) value for tablename</param>
        /// <param name="FieldNames">FieldNames: (ArrayList) of the fields names</param>
        /// <param name="WhereCondition">WhereCondition: (string) spacify the where condtion</param>
        /// <param name="OrderbyFieldName">OrderbyFieldName: (string) name of the Order By</param>
        /// <returns></returns>
        public string SelectGenerator(string TableName, ArrayList FieldNames, string WhereCondition, string OrderbyFieldName)
        {
            string strSelectCommand;

            //Generate the select statment 
            strSelectCommand = "SELECT ";

            for (int i = 0; i <= FieldNames.Count - 1; i++)
            {
                if (i != FieldNames.Count - 1)
                {
                    strSelectCommand += FieldNames[i] + ", ";
                }
                else
                {
                    strSelectCommand += FieldNames[i];
                }
            }
            strSelectCommand += " FROM " + TableName + " WHERE " + WhereCondition + " ORDER BY " + OrderbyFieldName;

            return strSelectCommand;
        }
        #endregion


        #region Function to generate SQL INSERT statment with FieldNames ,and FieldValues

        public string InsertGenerator(string TableName, ArrayList FieldNames, ArrayList FieldValues)
        {
            string strInsertCommand;

            //Generate Insert Statment
            strInsertCommand = "INSERT INTO " + TableName + " (";

            //Code to add fieldnames to insert command
            for (int i = 0; i <= FieldNames.Count - 1; i++)
            {
                if (i != FieldValues.Count - 1)
                {
                    strInsertCommand += FieldNames[i] + ", ";
                }
                else
                {
                    strInsertCommand += FieldNames[i];
                }
            }
            strInsertCommand += ") VALUES (";

            //Code to add fieldvalues to insert command
            for (int ii = 0; ii <= FieldValues.Count - 1; ii++)
            {
                if (ii != FieldValues.Count - 1)
                {
                    //if (FieldValues[ii].GetType() == TypeCode.String)
                    //{
                    //    strInsertCommand += "'" + FieldValues[ii] +"'"+ " , ";
                    //}
                    //else
                    //{
                    strInsertCommand += FieldValues[ii] + ", ";
                    //}
                }
                else
                {
                    //if (FieldValues[ii].GetType() == TypeCode.String)
                    //{
                    //    strInsertCommand += "'" + FieldValues[ii] + "'";
                    //}
                    //else
                    //{
                    strInsertCommand += FieldValues[ii];
                    //}

                }
            }

            strInsertCommand += ")";

            return strInsertCommand;
        }

        #endregion


        #region Function to generate SQL UPDATE statment with FieldNames , FieldValues, and WHERE condition

        public string UpdateGenerator(string TableName, ArrayList FieldNames, ArrayList FieldValues, string WhereCondition)
        {
            string strUpdateCommand;
            strUpdateCommand = "UPDATE " + TableName + " SET ";

            //Code to generate Update statment with FieldNames , FieldValues, and WHERE condition 
            for (int i = 0; i <= FieldNames.Count - 1; i++)
            {

                if (i != FieldValues.Count - 1)
                {

                    strUpdateCommand += FieldNames[i] + " = " + FieldValues[i] + ", ";

                }
                else
                {
                    strUpdateCommand += FieldNames[i] + " = " + FieldValues[i];
                }

            }

            strUpdateCommand += " WHERE " + WhereCondition;

            //Code here
            return strUpdateCommand;

        }
        #endregion


        #region  Function to generate SQL Delete statment with WHERE condition

        public string DeleteGenerator(string TableName, string WhereCondition)
        {
            string strDeleteCommand;
            //Code to generate SQL Delete statment
            strDeleteCommand = "DELETE FROM " + TableName + " WHERE " + WhereCondition;

            return strDeleteCommand;

        }
        #endregion


        #region GET unique values of FieldName

        public ArrayList getUniqueValues(string TableName, string FieldName)
        {
            ArrayList uniqueValues;
            using (SqlConnection dbConn = ConnectionManager.connection())
            {
                string selectCommand;
                //there is an error when i put "UNIQUE" to the select statment I don't know why?
                selectCommand = "SELECT  DISTINCT(" + FieldName + ") FROM " + TableName;
                if (dbConn.State != ConnectionState.Open)
                {
                    dbConn.Open();
                }
                uniqueValues = ReadData(selectCommand, FieldName);
            }
            return uniqueValues;
        }

        #endregion


        #region GET unique values of FieldName + WHERE

        public ArrayList getUniqueValues(string TableName, string FieldName, string WhereCondition)
        {
            ArrayList uniqueValues;

            using (SqlConnection dbConn = ConnectionManager.connection())
            {
                string selectCommand;
                //there is an error when i put "UNIQUE" to the select statment I don't know why?
                selectCommand = "SELECT  DISTINCT(" + FieldName + ") FROM " + TableName + " WHERE " + WhereCondition;
                uniqueValues = ReadData(selectCommand, FieldName);
            }
            return uniqueValues;
        }

        #endregion


        #region GET unique values of FieldName + ORDER BY

        public ArrayList getUniqueValues(string TableName, string FieldName, string OrderBy, int i)
        {
            ArrayList uniqueValues;
            using (SqlConnection dbConn = ConnectionManager.connection())
            {
                string selectCommand;
                if (FieldName == OrderBy)
                {
                    selectCommand = "SELECT  DISTINCT(" + FieldName + ") FROM " + TableName + " ORDER BY " + OrderBy;
                    uniqueValues = ReadData(selectCommand, FieldName);
                }
                else
                {
                    selectCommand = "SELECT  DISTINCT(" + FieldName + ")," + OrderBy + " FROM " + TableName + " ORDER BY " + OrderBy;
                    uniqueValues = ReadData(selectCommand, FieldName);
                }
            }
            return uniqueValues;
        }

        #endregion


        #region GET unique values of FieldName + WHERE + ORDER BY

        public ArrayList getUniqueValues(string TableName, string FieldName, string WhereCondition, string OrderBy)
        {
            ArrayList uniqueValues;
            using (SqlConnection dbConn = ConnectionManager.connection())
            {
                string selectCommand;
                if (FieldName == OrderBy)
                {
                    selectCommand = "SELECT  DISTINCT(" + FieldName + ") FROM " + TableName + " WHERE " + WhereCondition + " ORDER BY " + OrderBy;
                    uniqueValues = ReadData(selectCommand, FieldName);
                }
                else
                {
                    selectCommand = "SELECT  DISTINCT(" + FieldName + ")," + OrderBy + " FROM " + TableName + " WHERE " + WhereCondition + " ORDER BY " + OrderBy;
                    uniqueValues = ReadData(selectCommand, FieldName);
                }
            }
            return uniqueValues;
        }

        #endregion


        #region Function to Get data from databass basd on select statement Offline mode

        public DataTable getDataTable(SqlConnection dbconn, string TableName, string quiryString)
        {
            // 1. create new dataTable
            DataTable dt = new DataTable();

            // 2. Pass the strings to the SqlDataAdapter constructor
            SqlDataAdapter dataAdapter = new SqlDataAdapter(quiryString, dbconn);

            // 3. Create a DataSet
            DataSet dataSet = new DataSet();

            // 4. fill the dataset object
            dataAdapter.Fill(dataSet, TableName);

            // 5. Get the table from the dataset
            DataTable dataTable = dataSet.Tables[TableName];

            // 6. Bind to the Gridview

            return dt;
        }

        #endregion


        #region Function to fill DropDownList withe ArrayList

        public void fillDrobDownList(DropDownList drplst, ArrayList dataArrayList)
        {
            drplst.Items.Clear();
            for (int i = 0; i <= dataArrayList.Count - 1; i++)
            {
                drplst.Items.Add(dataArrayList[i].ToString());
            }

        }

        #endregion


        #region Function to fill DropDownList withe ArrayList and fill the DropDownList with values ArrayList

        public void fillDrobDownList(DropDownList drplst, ArrayList dataArrayList, ArrayList valuesArrayList)
        {
            drplst.Items.Clear();
            if (dataArrayList.Count == valuesArrayList.Count)
            {
                for (int i = 0; i <= dataArrayList.Count - 1; i++)
                {
                    drplst.Items.Add(dataArrayList[i].ToString());
                }

                for (int i = 0; i <= dataArrayList.Count - 1; i++)
                {
                    drplst.Items[i].Value = valuesArrayList[i].ToString();
                }
            }

            ListItem item = new ListItem("-- √Œ — --", "-1");
            drplst.Items.Insert(0, item);

        }

        #endregion


        #region Function to fill ListBox withe ArrayList

        public void fillListBox(ListBox lstbx, ArrayList dataAraayList)
        {
            lstbx.Items.Clear();
            for (int i = 0; i <= dataAraayList.Count - 1; i++)
            {
                lstbx.Items.Add(dataAraayList[i].ToString());
            }
        }

        #endregion


        #region Function to Check if any data exist in a table

        public bool tableHasData(SqlConnection dbConn, string tableName)
        {

            string selectStatment = SelectGenerator(tableName);


            SqlCommand cmd = new SqlCommand(selectStatment);
            cmd.Connection = dbConn;
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
            SqlDataReader datardr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            return datardr.HasRows;

        }

        #endregion


        #region Function to get record count

        public int getRecordCount(SqlConnection dbConn, string tableName)
        {

            string selectStatment = SelectGenerator(tableName);


            SqlCommand cmd = new SqlCommand(selectStatment);
            cmd.Connection = dbConn;
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
            }
            SqlDataReader datardr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            int i = 0;
            while (datardr.Read())
            {
                i++;
            }
            return i;

        }

        #endregion


        #region Function to Fill DataTable with select Statment

        public DataTable fillDataTable(string TableName, string SelectStatment)
        {
            //create DataTable
            DataTable dataTbl = new DataTable();

            using (SqlConnection dbConn = ConnectionManager.connection())
            {
                //Chech if the table has data or not
                if (tableHasData(dbConn, TableName))
                {
                    SqlDataAdapter dataAdapt = new SqlDataAdapter(SelectStatment, dbConn);
                    DataSet dst = new DataSet();
                    dataAdapt.Fill(dst, TableName);

                    dataTbl = dst.Tables[TableName];
                }
            }
            return dataTbl;
        }

        #endregion


        #region Function to get Sequance Next Value

        public string SequenceNextValGen(string SequenceName)
        {
            return (fillDataTable("dual", "select " + SequenceName + ".nextval" + " from dual")).Rows[0][0].ToString();
        }

        #endregion


        #region Function to get no. of records affected by SQL satatment

        public int recordsAffected(SqlConnection dbConn, string SQLStatment)
        {

            SqlCommand cmd = new SqlCommand(SQLStatment);
            cmd.Connection = dbConn;
            dbConn.Open();
            return cmd.ExecuteNonQuery();
        }

        #endregion


        #region Function to Show pathed columns names and hide the others in pathed GridView

        public void GridViewColumns(GridView gv, ArrayList VisableColumns)
        {
            int i = 0, j = 0;

            //Loop for each columns in the datagrid 
            //and compaire it with thw pathed column name 
            for (i = 0; i <= gv.Columns.Count - 1; i++)
            {
                for (j = 0; j <= VisableColumns.Count - 1; j++)
                {
                    if (gv.Columns[i].HeaderText == VisableColumns[j])
                    {
                        gv.Columns[i].Visible = true;
                        break;
                    }
                }
            }
        }

        #endregion


        #region Function to show or hide the columns of the pathed DataGrid based on CheckBoxList

        public void GridViewColumns(GridView gv, CheckBoxList cbl)
        {
            int i = 0;
            //Code to Show columns
            for (i = 0; i <= cbl.Items.Count - 1; i++)
            {

                if (cbl.Items[i].Selected)
                {
                    gv.Columns[i].Visible = true;
                }
                else
                {
                    gv.Columns[i].Visible = false;
                }

            }

        }

        #endregion


        #region Function to get ConnectionString

   


        #endregion


        #region Function to Formate longe DateTime to short DateTime

        public string toShortDateTime(DateTime longDateTime)
        {

            string shortDateTime;

            shortDateTime = longDateTime.ToShortDateString();

            return shortDateTime;
        }


        #endregion


        #region Function to format string to datetime

        public string To_Date(string str)
        {
            if (str != "")
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(str);
                str = dt.ToString("dd/MM/yyyy", culture);
                str = "TO_DATE('" + str + "', 'dd/MM/yyyy')";
            }
            else
            {
                str = "'01/01/1420'";
            }

            return str;
        }

        public string To_Date(string str, int AddDay, int AddMonth, int AddYear)
        {
            string go;
            if (str != "")
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                DateTime dt = new DateTime();
                string sDay = str.Substring(0, 2);
                string sMonth = str.Substring(3, 2);
                string sYear = str.Substring(6, 4);
                int intDay = Convert.ToInt16(sDay);
                int intMonth = Convert.ToInt16(sMonth);
                int intYear = Convert.ToInt16(sYear);
                if (AddMonth > 12)
                {
                    AddYear = AddMonth / 12;
                    AddMonth = AddMonth % 12;
                }
                dt = Convert.ToDateTime(intDay + "/" + (intMonth + AddMonth) + "/" + (intYear + AddYear));
                dt.AddDays(AddDay);
                go = dt.ToString("dd/MM/yyyy", culture);
            }
            else
            {
                go = "'01/01/2008'";
            }
            return "TO_DATE('" + go + "', 'dd/MM/yyyy')";
        }
        public string To_Date_txt(string str, int AddDay, int AddMonth, int AddYear)
        {
            string go;
            if (str != "")
            {
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                DateTime dt = new DateTime();
                string sDay = str.Substring(0, 2);
                string sMonth = str.Substring(3, 2);
                string sYear = str.Substring(6, 4);
                int intDay = Convert.ToInt16(sDay);
                int intMonth = Convert.ToInt16(sMonth);
                int intYear = Convert.ToInt16(sYear);
                if (AddMonth > 12)
                {
                    AddYear = AddMonth / 12;
                    AddMonth = AddMonth % 12;
                }
                dt = Convert.ToDateTime(intDay + "/" + (intMonth + AddMonth) + "/" + (intYear + AddYear));
                dt.AddDays(AddDay);
                go = dt.ToString("dd/MM/yyyy");
            }
            else
            {
                go = "'01/01/1420'";
            }
            return go;
        }
        #endregion


        #region Function to reset text from textboxes

        public void ResetText(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType().ToString().Equals("System.Web.UI.WebControls.TextBox")
                    || c.GetType().ToString().Equals("ASP.custom_controls_hjcalender_ascx"))
                {
                    // ...do something...
                    ((TextBox)c).Text = "";
                }

                if (c.GetType().ToString().Equals("System.Web.UI.WebControls.DropDownList"))
                {
                    if (((DropDownList)c).Items.Count > 0)
                    {
                        ((DropDownList)c).SelectedIndex = 0;
                    }
                }

                if (c.Controls.Count > 0)
                {
                    ResetText(c);
                }
            }
        }
        public void ResetText(Control parent, string ParentID)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType().ToString().Equals("System.Web.UI.WebControls.TextBox")
                    || c.GetType().ToString().Equals("ASP.custom_controls_hjcalender_ascx"))
                {
                    // ...do something...
                    if (c.Parent.ID == ParentID)
                    {
                        ((TextBox)c).Text = "";
                    }
                }

                if (c.GetType().ToString().Equals("System.Web.UI.WebControls.DropDownList"))
                {
                    if (((DropDownList)c).Items.Count > 0)
                    {
                        ((DropDownList)c).SelectedIndex = 0;
                    }
                }

                if (c.Controls.Count > 0)
                {
                    ResetText(c, ParentID);
                }
            }
        }
        #endregion


        #region Function to Set Controls ReadOnly

        public void SetControlsReadOnly(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType().ToString().Equals("System.Web.UI.WebControls.TextBox")
                    || c.GetType().ToString().Equals("ASP.custom_controls_hjcalender_ascx"))
                {
                    // ...do something...
                    ((TextBox)c).Enabled = false;
                }

                if (c.GetType().ToString().Equals("System.Web.UI.WebControls.DropDownList"))
                {

                    ((DropDownList)c).Enabled = false;

                }

                if (c.Controls.Count > 0)
                {
                    SetControlsReadOnly(c);
                }
            }
        }
        #endregion


        #region Function to calculate fees
        public double CalculateFees(double InitValue, double SpicificValue, double onwhatCalculate)
        {
            //DataTable dt1 = new DataTable();
            //DataTable dt2 = new DataTable();
            //int fID=0;
            //if (appID == 1) fID = 1;
            //dt1 = fillDataTable("T_FEES", SelectGenerator("T_FEES", "FEES_ID = " + fID + " AND APP_ID = " + appID));
            //dt2 = fillDataTable("T_FEES", SelectGenerator("T_FEES", "FEES_ID = " + feesID + " AND APP_ID = " + appID));
            //switch (appID)
            //{
            //    case 1:
            //        switch (feesID)
            //        {
            //            case 2:case 3:case 4:case 5:case 6:case 9:
            //                    return (onwhatCalculate * Convert.ToDouble(dt2.Rows[0]["FEES_VALUE"].ToString())) + Convert.ToDouble(dt1.Rows[0]["FEES_VALUE"].ToString());
            //                break;
            //            case 7:
            //            case 8:
            //                return Convert.ToDouble(dt2.Rows[0]["FEES_VALUE"].ToString()) + Convert.ToDouble(dt1.Rows[0]["FEES_VALUE"].ToString());
            //        }
            //        break;
            //}
            return (onwhatCalculate * SpicificValue) + InitValue;
        }
        public string ConvertNumberToString(double MyNumber)
        {

            string num_val = MyNumber.ToString();
            string num_decimal = "00";
            string[] NumberParts = new string[2];
            if (num_val.Contains("."))
            {
                NumberParts = num_val.Split('.');
                num_val = NumberParts[0];
                num_decimal = NumberParts[1];
            }
            string numstr;
            string[] PART1 = new string[5];
            string[,] ORDER1 = new string[4, 3];

            ORDER1[0, 0] = "";
            ORDER1[0, 1] = "";
            ORDER1[0, 2] = "";

            ORDER1[1, 0] = " «·›";
            ORDER1[1, 1] = " «·›«‰";
            ORDER1[1, 2] = " «·«› ";

            ORDER1[2, 0] = " „·ÌÊ‰";
            ORDER1[2, 1] = " „·ÌÊ‰«‰";
            ORDER1[2, 2] = " „·«ÌÌ‰ ";

            int SpaceNumber = 9 - num_val.Trim().Length;
            string Spaces = "";
            for (int i = 1; i <= SpaceNumber; i++)
            {
                Spaces += " ";
            }
            numstr = Spaces + num_val.Trim();  //Space(14 - Len(num_val.Trim)) & num_val.Trim  ', 14, 3)
            PART1[0] = numstr.Substring(6, 3);
            PART1[1] = numstr.Substring(3, 3);// Mid(numstr, 5, 3);
            PART1[2] = numstr.Substring(0, 3);// Mid(numstr, 2, 3);
            int Indx = 2;
            string temp_chr_val = "";
            double part1_val, first_digit, first_two = 0;
            while (Indx > -1)
            {
                string str = PART1[Indx];
                if (str.Trim() != "" && int.Parse(str.Trim()) != 0)
                {
                    if (temp_chr_val != "")
                    {
                        temp_chr_val += " Ê";
                    }
                    part1_val = (PART1[Indx].Trim() == "") ? 0.0 : double.Parse(PART1[Indx]);
                    first_digit = (PART1[Indx].Substring(2, 1).Trim() == "") ? 0.0 : double.Parse(PART1[Indx].Substring(2, 1));
                    first_two = (PART1[Indx].Substring(1, 2).Trim() == "") ? 0.0 : double.Parse(PART1[Indx].Substring(1, 2));
                    if (first_two - first_digit == 0 && part1_val - first_two == 0)
                    {
                        if (first_digit == 1)
                        {
                            if (Indx > 0)
                            {
                                temp_chr_val += ORDER1[Indx, 0];
                            }
                            else
                            {
                                temp_chr_val += F9F9((int)first_digit, "", 'M') + ORDER1[Indx, 0];
                            }
                        }
                        else if (first_digit == 2)
                        {
                            if (Indx > 0)
                            {
                                temp_chr_val += ORDER1[Indx, 1];
                            }
                            else
                            {
                                temp_chr_val += F9F9((int)first_digit, "", 'M') + ORDER1[Indx, 1];
                            }

                        }
                        else
                        {
                            temp_chr_val += F9F9((int)first_digit, "", 'M') + ORDER1[Indx, 2];
                        }
                    }
                    else
                    {
                        temp_chr_val += F9F9((int)part1_val, "", 'M') + ORDER1[Indx, 0];
                    }
                }
                Indx -= 1;
            }
            temp_chr_val += " —Ì«·";
            num_decimal += "00";
            num_decimal = num_decimal.Substring(0, 2);
            if (num_decimal != "" && int.Parse(num_decimal) != 0)
            {
                if (num_decimal.Length == 1)
                {
                    num_decimal += "0";
                }
                temp_chr_val += " Ê " + F9F9(int.Parse(num_decimal), "", 'M') + " Â··Â";
            }
            return temp_chr_val.Trim();
        }
        private string F9F9(int pnum_val, string chr_val, char MALE_FEMAL)
        {
            string[] FIRST_TWO = new string[21];
            string[] FIRST_TWO_F = new string[21];
            string[] TENS = new string[10];
            string[] HUNDREDS = new string[10];

            string chr_val_n;
            FIRST_TWO[1] = " Ê«Õœ";
            FIRST_TWO[2] = " «À‰«‰";
            FIRST_TWO[3] = " À·«À…";
            FIRST_TWO[4] = " «—»⁄…";
            FIRST_TWO[5] = " Œ„”…";
            FIRST_TWO[6] = " ” …";
            FIRST_TWO[7] = " ”»⁄…";
            FIRST_TWO[8] = " À„«‰Ì…";
            FIRST_TWO[9] = "  ”⁄…";
            FIRST_TWO[10] = " ⁄‘—";
            FIRST_TWO[11] = " «Õœ ⁄‘—";
            FIRST_TWO[12] = " «À‰« ⁄‘—";
            FIRST_TWO[13] = " À·«À… ⁄‘—";
            FIRST_TWO[14] = " «—»⁄… ⁄‘—";
            FIRST_TWO[15] = " Œ„”… ⁄‘—";
            FIRST_TWO[16] = " ” … ⁄‘—";
            FIRST_TWO[17] = " ”»⁄… ⁄‘—";
            FIRST_TWO[18] = " À„«‰Ì… ⁄‘—";
            FIRST_TWO[19] = "  ”⁄… ⁄‘—";

            FIRST_TWO_F[0] = " «ÕœÏ";
            FIRST_TWO_F[1] = " «À‰ «‰";
            FIRST_TWO_F[2] = " À·«À";
            FIRST_TWO_F[3] = " «—»⁄";
            FIRST_TWO_F[4] = " Œ„”";
            FIRST_TWO_F[5] = " ” ";
            FIRST_TWO_F[6] = " ”»⁄";
            FIRST_TWO_F[7] = " À„«‰Ì";
            FIRST_TWO_F[8] = "  ”⁄";
            FIRST_TWO_F[9] = " ⁄‘—…";
            FIRST_TWO_F[10] = " «ÕœÏ ⁄‘—…";
            FIRST_TWO_F[11] = " «À‰ « ⁄‘—…";
            FIRST_TWO_F[12] = " À·«À ⁄‘—…";
            FIRST_TWO_F[13] = " «—»⁄ ⁄‘—…";
            FIRST_TWO_F[14] = " Œ„” ⁄‘—…";
            FIRST_TWO_F[15] = " ” … ⁄‘—…";
            FIRST_TWO_F[16] = " ”»⁄ ⁄‘—…";
            FIRST_TWO_F[17] = " À„«‰Ì… ⁄‘—…";
            FIRST_TWO_F[18] = "  ”⁄… ⁄‘—…";

            TENS[2] = " ⁄‘—Ê‰";
            TENS[3] = " À·«ÀÊ‰";
            TENS[4] = " «—»⁄Ê‰";
            TENS[5] = " Œ„”Ê‰";
            TENS[6] = " ” Ê‰";
            TENS[7] = " ”»⁄Ê‰";
            TENS[8] = " À„«‰Ê‰";
            TENS[9] = "  ”⁄Ê‰";

            HUNDREDS[1] = " „«∆…";
            HUNDREDS[2] = " „«∆ «‰";
            HUNDREDS[3] = " À·«À„«∆…";
            HUNDREDS[4] = " «—»⁄„«∆…";
            HUNDREDS[5] = " Œ„”„«∆…";
            HUNDREDS[6] = " ” „«∆…";
            HUNDREDS[7] = " ”»⁄„«∆…";
            HUNDREDS[8] = " À„«‰„«∆…";
            HUNDREDS[9] = "  ”⁄„«∆…";

            chr_val_n = pnum_val.ToString();
            if (chr_val_n.Length == 1)
            {
                chr_val_n = "00" + chr_val_n;
            }
            if (chr_val_n.Length == 2)
            {
                chr_val_n = "0" + chr_val_n;
            }

            chr_val = "";
            bool Next_Waw = false;
            if (int.Parse(chr_val_n.Substring(0, 1)) != 0)
            {
                chr_val = chr_val + HUNDREDS[int.Parse(chr_val_n.Substring(0, 1))];
                Next_Waw = true;
            }

            if (int.Parse(chr_val_n.Substring(1, 2)) > 0)
            {
                if (int.Parse(chr_val_n.Substring(1, 2)) < 20)
                {
                    if (Next_Waw)
                    {
                        chr_val = chr_val + " Ê";
                    }
                    if (MALE_FEMAL == 'M')
                    {
                        chr_val = chr_val + FIRST_TWO[int.Parse(chr_val_n.Substring(1, 2))];
                    }
                    else
                    {
                        chr_val = chr_val + FIRST_TWO_F[int.Parse(chr_val_n.Substring(1, 2))];
                    }
                }
                else
                {
                    if (Next_Waw)
                    {
                        chr_val = chr_val + " Ê";
                    }
                    if (int.Parse(chr_val_n.Substring(2, 1)) != 0)
                    {
                        if (MALE_FEMAL == 'M')
                        {
                            chr_val = chr_val + FIRST_TWO[int.Parse(chr_val_n.Substring(2, 1))];
                        }
                        else
                        {
                            chr_val = chr_val + FIRST_TWO_F[int.Parse(chr_val_n.Substring(2, 1))];
                        }
                        chr_val = chr_val + " Ê";
                    }
                    chr_val = chr_val + TENS[int.Parse(chr_val_n.Substring(1, 1))];
                }
            }
            return chr_val;

        }

        //public string CalculateFeesText(int feesID, int appID, double onwhatCalculate)
        //{
        //    double CalculatedFees = (CalculateFees(feesID, appID, onwhatCalculate));
        //    CalculatedFees=CalculatedFees.ToString(""
        //    return CalculatedFees;
        //}
        #endregion




















        #region Function to execute Select statment

        //code to execute query command
        public ArrayList ReadData(string queryString, string FieldName)
        {
            ArrayList dataList = new ArrayList();



            using (SqlConnection dbConn = ConnectionManager.connection())
            {
                if (dbConn.State == ConnectionState.Closed)
                {
                    dbConn.Open();
                }

                SqlCommand command = new SqlCommand(queryString, dbConn);

                SqlDataReader reader = command.ExecuteReader();

                //code to fill the arraylist with the reader data 

                while (reader.Read() == true)
                {
                    dataList.Add(reader[FieldName]);
                }

                reader.Close();
            }
            return dataList;

        }

        #endregion


        #region Function InsertRow to insert row into DATABASE with insertSQL statement string

        public int InsertRow(string insertSQL)
        {
            int recordsAffected = 0;
            using (SqlConnection dbConn = ConnectionManager.connection())
            {

                // The insertSQL string contains a SQL statement that
                // inserts a new row in the source table.
                SqlCommand command = new SqlCommand(insertSQL);

                // Set the Connection to the new SqlConnection.
                command.Connection = dbConn;

                // Open the connection and execute the insert command.
                try
                {
                    if (dbConn.State != ConnectionState.Open)
                    {
                        dbConn.Open();
                    }
                    recordsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                // The connection is automatically closed when the
                // code exits the using block.
            }

            return recordsAffected;
        }
        #endregion


        #region Function DeleteRow to DELETE row from DATABASE with deleteSQL statment string

        public int DeleteRow(string DeleteSQL)
        {
            int recordsAffected = 0;

            using (SqlConnection dbConn = ConnectionManager.connection())
            {

                // The insertSQL string contains a SQL statement that
                // inserts a new row in the source table.
                SqlCommand command = new SqlCommand(DeleteSQL);

                // Set the Connection to the new SqlConnection.
                command.Connection = dbConn;

                // Open the connection and execute the insert command.
                try
                {
                    dbConn.Open();
                    recordsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                }
                // The connection is automatically closed when the
                // code exits the using block.
            }

            return recordsAffected;

        }
        #endregion


        #region Execute Update command

        public int UpdateRow(string updateSQL)
        {
            int recordsAffected = 0;

            // The updateSQL string contains a SQL statement that
            // updates a row in the source table.
            SqlCommand command = new SqlCommand(updateSQL);

            using (SqlConnection dbConn = ConnectionManager.connection())
            {
                // Set the Connection to the new SqlConnection.
                command.Connection = dbConn;

                // Open the connection and execute the insert command.
                try
                {
                    dbConn.Open();
                    recordsAffected = command.ExecuteNonQuery();
                    dbConn.Close();
                }
                catch (Exception ex)
                {

                }
                // The connection is automatically closed when the
                // code exits the using block.
            }
            return recordsAffected;

        }
        #endregion



    }
 