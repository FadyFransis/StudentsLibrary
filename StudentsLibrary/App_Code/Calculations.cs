using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Calculations
/// </summary>
public class Calculations
{
	public Calculations()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    static public void UpdateDelays(int emp, int xmonth, int xyear)
    {
        int employee = emp;
        //string empid = id;
        int month = xmonth;
        int year = xyear;



        int total_credit = 0;

        //(1) delete all records for this employee in this month
        Data.Execute(@"delete  from Delays_Credits where DelayCredit_emp=" + employee + @" and 
            DelayCredit_month=" + month + " and DelayCredit_year= " + year);



        // (2) Get the delays for this employee in this month and insert it into delays_credits
        DataTable tbl_delays = Data.Execute(@"select delay_sn, convert(char(10),delay_date,111) as delay_date
,datediff(minute,convert(char(5),delay_hfrom,108),convert(char(5),delay_hto,108)) as delay_period
,convert(char(5),delay_hfrom,108) as delay_hfrom,convert(char(5),delay_hto,108) as delay_hto,delay_type 
from delays where delay_emp=" + employee + " and MONTH(delay_date) = " + month +
" and year(delay_date) = " + year + " order by delay_date ").Tables[0];



        for (int i = 0; i < tbl_delays.Rows.Count; i++)
        {
            int delay_period = int.Parse(tbl_delays.Rows[i]["delay_period"].ToString());
            string delay_date = tbl_delays.Rows[i]["delay_date"].ToString();
            int delay_sn = int.Parse(tbl_delays.Rows[i]["delay_sn"].ToString());

            //insert delay record in delays_Credits
            Data.Execute(@"insert into Delays_Credits
(DelayCredit_emp,DelayCredit_credit,DelayCredit_date,DelayCredit_type,DelayCredit_reason,DelayCredit_month,
DelayCredit_year,DelayCredit_delaysn) values(" + employee + "," + delay_period + ",'" + delay_date
+ "',1,1," + month + "," + year + "," + delay_sn + ")");


            total_credit += delay_period;

        }

        // (3) Check the attendance for days that have delay for this employee

        // (a) Get the delay & attendance settings
        DataTable setting_tbl = Data.Execute(@"select sett_femaleout,sett_pardon,sett_delays3 from 
settings").Tables[0];

        int sett_femaleout = int.Parse(setting_tbl.Rows[0]["sett_femaleout"].ToString());
        int sett_pardon = int.Parse(setting_tbl.Rows[0]["sett_pardon"].ToString());
        int sett_credit = int.Parse(setting_tbl.Rows[0]["sett_delays3"].ToString()) * 60;


        tbl_delays = Data.Execute(@"select delay_sn, convert(char(10),delay_date,111) as delay_date
,datediff(minute,convert(char(5),delay_hfrom,108),convert(char(5),delay_hto,108)) as delay_period
,convert(char(5),delay_hfrom,108) as delay_hfrom,convert(char(5),delay_hto,108) as delay_hto,delay_type 
from delays where delay_emp=" + employee + " and MONTH(delay_date) = " + month +
" and year(delay_date) = " + year + "   and not( MONTH(delay_date) = " + DateTime.Today.Month + " and year(delay_date) = " + DateTime.Today.Year + " and day(delay_date) >= " + DateTime.Today.Day + ") order by delay_date ").Tables[0];




        for (int i = 0; i < tbl_delays.Rows.Count; i++)
        {

            int delay_period = int.Parse(tbl_delays.Rows[i]["delay_period"].ToString());
            string delay_date = tbl_delays.Rows[i]["delay_date"].ToString();
            string delay_hfrom = tbl_delays.Rows[i]["delay_hfrom"].ToString();
            string delay_hto = tbl_delays.Rows[i]["delay_hto"].ToString();
            int delay_type = int.Parse(tbl_delays.Rows[i]["delay_type"].ToString());
            int delay_sn = int.Parse(tbl_delays.Rows[i]["delay_sn"].ToString());
            int delay = 0;
            int early = 0;
            int delay_direct = 0; // يحسب تأخير مباشرة دون التأكد من الرصيد
            int early_direct = 0; // يحسب تأخير مباشرة دون التأكد من الرصيد

            // (b) Get the begin & end of the attendance
            DataTable workperiods_tbl = Data.Execute(@"select exem_time
,convert(varchar(5),Exem_hperiod,108) as Exem_hperiod, convert(varchar(5),work_attend,108) as work_attend
,convert(varchar(5),work_leave,108) as work_leave,emp_sex from work_periods left outer join employees on 
work_sn=case when period_id > 0 then period_id else 1 END left outer join Exemptions 
on Exem_emp = emp_sn and Exem_from <= '" + delay_date + "' and Exem_to >= '" + delay_date + @"' where emp_sn=" + employee).Tables[0];

            int emp_sex = int.Parse(workperiods_tbl.Rows[0]["emp_sex"].ToString());
            string attend_begin = workperiods_tbl.Rows[0]["work_attend"].ToString();
            string attend_end = workperiods_tbl.Rows[0]["work_leave"].ToString();

            if (!(workperiods_tbl.Rows[0]["exem_time"] is DBNull) && workperiods_tbl.Rows[0]["exem_time"].ToString() != "0")
            {
                int exem_time = int.Parse(workperiods_tbl.Rows[0]["exem_time"].ToString());
                string Exem_hperiod = workperiods_tbl.Rows[0]["Exem_hperiod"].ToString();
                if (exem_time == 1) // اعفاء ساعتين بداية الدوام
                {
                    TimeSpan attend_beginTimeSpan = TimeSpan.Parse(attend_begin);
                    TimeSpan Exem_hperiodTimeSpan = TimeSpan.Parse(Exem_hperiod);
                    TimeSpan NewTimeSpan = new TimeSpan(attend_beginTimeSpan.Hours + Exem_hperiodTimeSpan.Hours, attend_beginTimeSpan.Minutes, 0);
                    attend_begin = NewTimeSpan.ToString();

                    if (sett_femaleout > 0 && emp_sex == 1353)
                    {
                        TimeSpan attend_endTimeSpan = TimeSpan.Parse(attend_end);
                        TimeSpan NewTimeSpan2 = new TimeSpan(attend_endTimeSpan.Hours, attend_endTimeSpan.Minutes - sett_femaleout, 0);
                        attend_end = NewTimeSpan2.ToString();
                    }
                }
                else if (exem_time == 2) // اعفاء ساعتين نهاية الدوام
                {
                    TimeSpan attend_endTimeSpan = TimeSpan.Parse(attend_end);
                    TimeSpan Exem_hperiodTimeSpan = TimeSpan.Parse(Exem_hperiod);
                    TimeSpan NewTimeSpan = new TimeSpan(attend_endTimeSpan.Hours - Exem_hperiodTimeSpan.Hours, attend_endTimeSpan.Minutes, 0);
                    attend_end = NewTimeSpan.ToString();

                    if (sett_pardon > 0)
                    {
                        TimeSpan attend_beginTimeSpan = TimeSpan.Parse(attend_begin);
                        TimeSpan NewTimeSpan2 = new TimeSpan(attend_beginTimeSpan.Hours, attend_beginTimeSpan.Minutes + sett_pardon, 0);
                        attend_begin = NewTimeSpan2.ToString();
                    }
                }
                else if (exem_time == 4) // اعفاء ساعة بداية و نهاية الدوام
                {
                    TimeSpan attend_beginTimeSpan = TimeSpan.Parse(attend_begin);
                    TimeSpan Exem_hperiodTimeSpan = TimeSpan.Parse(Exem_hperiod);
                    TimeSpan BeginNewTimeSpan = new TimeSpan(attend_beginTimeSpan.Hours + Exem_hperiodTimeSpan.Hours, attend_beginTimeSpan.Minutes, 0);
                    attend_begin = BeginNewTimeSpan.ToString();

                    TimeSpan attend_endTimeSpan = TimeSpan.Parse(attend_end);
                    TimeSpan EndNewTimeSpan = new TimeSpan(attend_endTimeSpan.Hours - Exem_hperiodTimeSpan.Hours, attend_endTimeSpan.Minutes, 0);
                    attend_end = EndNewTimeSpan.ToString();
                }
            }


            else
            {
                if (sett_femaleout > 0 && emp_sex == 1353)
                {
                    TimeSpan attend_endTimeSpan = TimeSpan.Parse(attend_end);
                    TimeSpan NewTimeSpan = new TimeSpan(attend_endTimeSpan.Hours, attend_endTimeSpan.Minutes - sett_femaleout, 0);
                    attend_end = NewTimeSpan.ToString();
                }

                if (sett_pardon > 0)
                {
                    TimeSpan attend_beginTimeSpan = TimeSpan.Parse(attend_begin);
                    TimeSpan NewTimeSpan = new TimeSpan(attend_beginTimeSpan.Hours, attend_beginTimeSpan.Minutes + sett_pardon, 0);
                    attend_begin = NewTimeSpan.ToString();
                }
            }




            //(b) Get the attendance for this day for this employee
            //                DataTable attendance_tbl= Data.Execute(@"select convert(char(5),timeentry,108) as timeentry
            //,eventid from  employees inner join actatek_logs on actatek_logs.userid=emp_fingerpin  
            //where emp_sn=" + employee + " and convert(char(10),timeentry,111)='" + delay_date + "' ").Tables[0];

            // All IN fingerprints
            DataTable attendanceIN_tbl = Data.Execute(@"select timeentry,convert(varchar(5),timeentry,108) as timeentry2
from  employees inner join actatek_logs on actatek_logs.userid=emp_fingerpin where emp_sn=" + employee +
" and convert(char(10),timeentry,111)='" + delay_date + "' and eventid='IN' order by timeentry").Tables[0];

            // All OUT fingerprints
            DataTable attendanceOUT_tbl = Data.Execute(@"select timeentry,convert(varchar(5),timeentry,108) as timeentry2
from  employees inner join actatek_logs on actatek_logs.userid=emp_fingerpin where emp_sn=" + employee +
" and convert(char(10),timeentry,111)='" + delay_date + "' and eventid='OUT' order by timeentry").Tables[0];


            int FingerInCount = attendanceIN_tbl.Rows.Count;
            int FingerOutCount = attendanceOUT_tbl.Rows.Count;
            string FirstIn = "";
            string LastOut = "";

            if (FingerInCount > 0)
                FirstIn = attendanceIN_tbl.Rows[0]["timeentry2"].ToString();

            if (FingerOutCount > 0)
                LastOut = attendanceOUT_tbl.Rows[attendanceOUT_tbl.Rows.Count - 1]["timeentry2"].ToString();




            switch (delay_type)
            {
                // بداية أو نهاية الدوام
                case 76121:
                case 76122:
                    // ملوش بصمة دخول أو خروج
                    if (FingerOutCount == 0 || FingerInCount == 0)
                    {
                        if (FingerInCount > 0) // له بصمة دخول
                        {
                            if (delay_type == 76121) // بداية الدوام
                            {
                                early = TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Hours * 60 + TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Minutes;
                                delay = 0;
                            }
                            else // نهاية الدوام
                            {
                                early = TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Hours * 60 + TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Minutes;
                                delay = 0;
                            }
                        }
                        else if (FingerOutCount > 0) // له بصمة خروج
                        {
                            if (delay_type == 76121) // بداية الدوام
                            {
                                early = 0;
                                delay = TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Hours * 60 + TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Minutes;
                            }
                            else // نهاية الدوام
                            {
                                early = 0;
                                delay = TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Hours * 60 + TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Minutes;
                            }
                        }
                        else
                        {
                            early = 0;
                            delay = 0;
                        }


                    }
                    else // له بصمات دخول و خروج
                    {
                        if (delay_type == 76121) // بداية الدوام
                        {
                            delay = TimeSpan.Parse(FirstIn).Subtract(TimeSpan.Parse(delay_hto)).Hours * 60 + TimeSpan.Parse(FirstIn).Subtract(TimeSpan.Parse(delay_hto)).Minutes;
                            early_direct = TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(LastOut)).Hours * 60 + TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(LastOut)).Minutes;
                        }
                        else // نهاية الدوام
                        {
                            delay_direct = TimeSpan.Parse(FirstIn).Subtract(TimeSpan.Parse(attend_begin)).Hours * 60 + TimeSpan.Parse(FirstIn).Subtract(TimeSpan.Parse(attend_begin)).Minutes;
                            early = TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(LastOut)).Hours * 60 + TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(LastOut)).Minutes;
                        }
                    }
                    break;

                // أثناء الدوام
                case 76123:

                    #region Prepare Data

                    // Fingers In before begin of delay
                    DataRow[] FingersInB4DelayBegin = attendanceIN_tbl.Select(" timeentry < #" + delay_date + " " + delay_hfrom + "# ", " timeentry ");

                    // Fingers Out before End of delay
                    DataRow[] FingersOutB4DelayEnd = attendanceOUT_tbl.Select(" timeentry < #" + delay_date + " " + delay_hto + "# ", " timeentry ");

                    // Fingers In after begin of delay
                    DataRow[] FingersInAfterDelayBegin = attendanceIN_tbl.Select(" timeentry > #" + delay_date + " " + delay_hfrom + "#", " timeentry ");

                    // Fingers Out after End of delay
                    DataRow[] FingersOutAfterDelayEnd = attendanceOUT_tbl.Select(" timeentry > #" + delay_date + " " + delay_hto + "# ", " timeentry ");


                    // First In after begin of delay
                    string FirstInAfterDelayBegin = "";
                    string LastOutB4DelayEnd = "";

                    if (FingersInAfterDelayBegin.Length > 0)
                        FirstInAfterDelayBegin = FingersInAfterDelayBegin[0][1].ToString();

                    if (FingersOutB4DelayEnd.Length > 0)
                        LastOutB4DelayEnd = FingersOutB4DelayEnd[FingersOutB4DelayEnd.Length - 1][1].ToString();

                    #endregion

                    bool MissingAttendanceFP = false;
                    bool MissingLeaveFP = false;

                    // غياب
                    if (FingerOutCount == 0 && FingerInCount == 0)
                    {
                        break;
                    }

                    // ملوش بصمة دخول أو خروج
                    else if (FingerOutCount == 0 || FingerInCount == 0)
                    {
                        delay = TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Hours * 60 + TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Minutes;
                        early = TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Hours * 60 + TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Minutes;

                        MissingAttendanceFP = true;
                        MissingLeaveFP = true;
                    }
                    else
                    {
                        // مفيش بصمة دخول قبل بداية الاذن أو مفيش بصمة خروج قبل نهاية الاذن
                        if (FingersInB4DelayBegin.Length == 0 || FingersOutB4DelayEnd.Length == 0)
                        {
                            delay = TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Hours * 60 + TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(attend_begin)).Minutes;
                            MissingAttendanceFP = true;
                        }

                        // مفيش بصمة دخول بعد بداية الاذن أو مفيش بصمة خروج بعد نهاية الاذن
                        if (FingersInAfterDelayBegin.Length == 0 || FingersOutAfterDelayEnd.Length == 0)
                        {
                            early = TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Hours * 60 + TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(delay_hto)).Minutes;
                            MissingLeaveFP = true;
                        }
                    }

                    if (!MissingAttendanceFP) // لم يدخل في الحالات السابقة بالنسبة لتأخير حضور
                    {
                        int x = TimeSpan.Parse(FirstIn).Subtract(TimeSpan.Parse(attend_begin)).Hours * 60 + TimeSpan.Parse(FirstIn).Subtract(TimeSpan.Parse(attend_begin)).Minutes;
                        int y = TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(LastOutB4DelayEnd)).Hours * 60 + TimeSpan.Parse(delay_hfrom).Subtract(TimeSpan.Parse(LastOutB4DelayEnd)).Minutes;

                        if (x < 0)
                            x = 0;

                        if (y < 0)
                            y = 0;

                        delay_direct = x;
                        delay = y;
                    }
                    if (!MissingLeaveFP) // لم يدخل في الحالات السابقة بالنسبة لانصراف مبكر
                    {
                        int x = TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(LastOut)).Hours * 60 + TimeSpan.Parse(attend_end).Subtract(TimeSpan.Parse(LastOut)).Minutes;
                        int y = TimeSpan.Parse(FirstInAfterDelayBegin).Subtract(TimeSpan.Parse(delay_hto)).Hours * 60 + TimeSpan.Parse(FirstInAfterDelayBegin).Subtract(TimeSpan.Parse(delay_hto)).Minutes;

                        if (x < 0)
                            x = 0;

                        if (y < 0)
                            y = 0;

                        early_direct = x;
                        early = y;
                    }



                    break;
            } // Switch

            if (delay < 0)
                delay = 0;
            if (early < 0)
                early = 0;

            int total_delays_Indirect = delay + early;

            if (delay_direct < 0)
                delay_direct = 0;
            if (early_direct < 0)
                early_direct = 0;

            int total_delays_direct = delay_direct + early_direct;

            if (total_delays_Indirect > 0)
            {
                int total_delay = delay + delay_direct;
                int total_early = early + early_direct;
                int total_delays = total_delays_direct + total_delays_Indirect;

                if (total_credit < sett_credit)
                {
                    if (total_credit + total_delays_Indirect <= sett_credit)
                    {
                        //يتم الخصم من الرصيد إجمالي تأخير هذا اليوم
                        Data.Execute(@"insert into Delays_Credits
(DelayCredit_emp,DelayCredit_credit,DelayCredit_date,DelayCredit_type,DelayCredit_reason,DelayCredit_month,
DelayCredit_year,DelayCredit_delaysn) values(" + employee + "," + total_delays_Indirect + ",'" + delay_date
        + "',1,2," + month + "," + year + "," + delay_sn + ")");
                        total_credit += total_delays_Indirect;



                        // خصم التأخير المباشر
                        if (total_delays_direct > 0)
                        {
                            //يتم الخصم من التأخير
                            Data.Execute(@"insert into Delays_Credits
(DelayCredit_emp,DelayCredit_credit,DelayCredit_date,DelayCredit_type,DelayCredit_reason,DelayCredit_month,
DelayCredit_year,DelayCredit_delay,DelayCredit_early,DelayCredit_delaysn) 
values(" + employee + "," + total_delays_direct + ",'" + delay_date
            + "',2,2," + month + "," + year + "," + delay_direct + "," + early_direct + "," + delay_sn + ")");
                        }
                    }
                    else
                    {
                        int FromCredit = sett_credit - total_credit;
                        int FromDelay = total_delays_Indirect - FromCredit;

                        if (delay >= FromDelay)
                        {
                            delay = FromDelay;
                            early = 0;
                        }
                        else
                        {
                            early = FromDelay - delay;
                        }

                        int delay_reminder = delay + delay_direct;
                        int early_reminder = early + early_direct;

                        int total_delay_reminder = delay_reminder + early_reminder;


                        total_credit += total_delays_Indirect;

                        //يتم الخصم من الرصيد إجمالي التأخير الذي يسمح به الرصيد
                        Data.Execute(@"insert into Delays_Credits
(DelayCredit_emp,DelayCredit_credit,DelayCredit_date,DelayCredit_type,DelayCredit_reason,DelayCredit_month,
DelayCredit_year,DelayCredit_delaysn) values(" + employee + "," + FromCredit + ",'" + delay_date
        + "',1,2," + month + "," + year + "," + delay_sn + ")");

                        //يتم الخصم من التأخير الوقت الزائد عن الرصيد
                        Data.Execute(@"insert into Delays_Credits
(DelayCredit_emp,DelayCredit_credit,DelayCredit_date,DelayCredit_type,DelayCredit_reason,DelayCredit_month,
DelayCredit_year,DelayCredit_delay,DelayCredit_early,DelayCredit_delaysn) 
values(" + employee + "," + total_delay_reminder + ",'" + delay_date
        + "',2,2," + month + "," + year + "," + delay_reminder + "," + early_reminder + "," + delay_sn + ")");
                    }
                }
                else // لا يوجد رصيد
                {
                    //يتم الخصم من التأخير
                    Data.Execute(@"insert into Delays_Credits
(DelayCredit_emp,DelayCredit_credit,DelayCredit_date,DelayCredit_type,DelayCredit_reason,DelayCredit_month,
DelayCredit_year,DelayCredit_delay,DelayCredit_early,DelayCredit_delaysn) 
values(" + employee + "," + total_delays + ",'" + delay_date
    + "',2,2," + month + "," + year + "," + total_delay + "," + total_early + "," + delay_sn + ")");

                    total_credit += total_delays_Indirect;
                }
            }
            else if (total_delays_direct > 0)
            {
                //يتم الخصم من التأخير
                Data.Execute(@"insert into Delays_Credits
(DelayCredit_emp,DelayCredit_credit,DelayCredit_date,DelayCredit_type,DelayCredit_reason,DelayCredit_month,
DelayCredit_year,DelayCredit_delay,DelayCredit_early,DelayCredit_delaysn) 
values(" + employee + "," + total_delays_direct + ",'" + delay_date
+ "',2,2," + month + "," + year + "," + delay_direct + "," + early_direct + "," + delay_sn + ")");
            }

        } // Big For
        // }



    }
}
