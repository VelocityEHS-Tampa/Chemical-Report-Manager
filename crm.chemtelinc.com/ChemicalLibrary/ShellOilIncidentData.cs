using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class ShellOilIncidentData
    {
        #region Private Fields

        public int _incid;
        private string _ersop, _date, _time, _callername1, _callername2, _callername3, _callerphone1, _callerphone2, _callerphone3, _callerext1, _callerext2, _callerext3;
        private string _calleraltphone1, _calleraltphone2, _calleraltphone3, _calleraltext1, _calleraltext2, _calleraltext3, _comments, _staffname, _staffphone, _staffext;
        private string _staffreporttime, _stafftimezone, _followupname1, _followupname2, _followupname3, _followupname4, _followupname5, _followuptime1, _followuptime2, _followuptime3, _followuptime4, _followuptime5;
        private string _followuptimezone1, _followuptimezone2, _followuptimezone3, _followuptimezone4, _followuptimezone5, _followupphone1, _followupphone2, _followupphone3, _followupphone4, _followupphone5, _followupext1, _followupext2, _followupext3, _followupext4, _followupext5, _emailsent, _notes;

        #endregion
        #region Public Properties
        #region Ints

        public int Inc_ID
        {
            get { return _incid; }
            set { _incid = value; }
        }

        #endregion
        #region Strings

        public string ERS_Operator
        {
            get { return _ersop; }
            set { _ersop = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }
        public string Caller_Name_1
        {
            get { return _callername1; }
            set { _callername1 = value; }
        }
        public string Caller_Name_2
        {
            get { return _callername2; }
            set { _callername2 = value; }
        }
        public string Caller_Name_3
        {
            get { return _callername3; }
            set { _callername3 = value; }
        }
        public string Caller_Phone_1
        {
            get { return _callerphone1; }
            set { _callerphone1 = value; }
        }
        public string Caller_Phone_2
        {
            get { return _callerphone2; }
            set { _callerphone2 = value; }
        }
        public string Caller_Phone_3
        {
            get { return _callerphone3; }
            set { _callerphone3 = value; }
        }
        public string Caller_Alt_Phone_1
        {
            get { return _calleraltphone1; }
            set { _calleraltphone1 = value; }
        }
        public string Caller_Alt_Phone_2
        {
            get { return _calleraltphone2; }
            set { _calleraltphone2 = value; }
        }
        public string Caller_Alt_Phone_3
        {
            get { return _calleraltphone3; }
            set { _calleraltphone3 = value; }
        }
        public string Caller_Ext_1
        {
            get { return _callerext1; }
            set { _callerext1 = value; }
        }
        public string Caller_Ext_2
        {
            get { return _callerext2; }
            set { _callerext2 = value; }
        }
        public string Caller_Ext_3
        {
            get { return _callerext3; }
            set { _callerext3 = value; }
        }
        public string Caller_Alt_Ext_1
        {
            get { return _calleraltext1; }
            set { _calleraltext1 = value; }
        }
        public string Caller_Alt_Ext_2
        {
            get { return _calleraltext2; }
            set { _calleraltext2 = value; }
        }
        public string Caller_Alt_Ext_3
        {
            get { return _calleraltext3; }
            set { _calleraltext3 = value; }
        }
        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        public string Staff_Name
        {
            get { return _staffname; }
            set { _staffname = value; }
        }
        public string Staff_Phone
        {
            get { return _staffphone; }
            set { _staffphone = value; }
        }
        public string Staff_Ext
        {
            get { return _staffext; }
            set { _staffext = value; }
        }
        public string Staff_Report_Time
        {
            get { return _staffreporttime; }
            set { _staffreporttime = value; }
        }
        public string Staff_Time_Zone
        {
            get { return _stafftimezone; }
            set { _stafftimezone = value; }
        }
        //---------------------------Follow_Up_Name_1
        public string Follow_Up_Name_1
        {
            get {return _followupname1; }
            set { _followupname1 = value; }
        }
        public string Follow_Up_Name_2
        {
            get { return _followupname2; }
            set { _followupname2 = value; }
        }
        public string Follow_Up_Name_3
        {
            get { return _followupname3; }
            set { _followupname3 = value; }
        }
        public string Follow_Up_Name_4
        {
            get { return _followupname4; }
            set { _followupname4 = value; }
        }
        public string Follow_Up_Name_5
        {
            get { return _followupname5; }
            set { _followupname5 = value; }
        }
        //------------------------Follow_Up_Time_1
        public string Follow_Up_Time_1
        {
            get { return _followuptime1; }
            set { _followuptime1 = value; }
        }
        public string Follow_Up_Time_2
        {
            get { return _followuptime2; }
            set { _followuptime2 = value; }
        }
        public string Follow_Up_Time_3
        {
            get { return _followuptime3; }
            set { _followuptime3 = value; }
        }
        public string Follow_Up_Time_4
        {
            get { return _followuptime4; }
            set { _followuptime4 = value; }
        }
        public string Follow_Up_Time_5
        {
            get { return _followuptime5; }
            set { _followuptime5 = value; }
        }
        //---------------------------Follow_Up_Time_Zone_
        public string Follow_Up_Time_Zone_1
        {
            get { return _followuptimezone1; }
            set { _followuptimezone1 = value; }
        }
        public string Follow_Up_Time_Zone_2
        {
            get { return _followuptimezone2; }
            set { _followuptimezone2 = value; }
        }
        public string Follow_Up_Time_Zone_3
        {
            get { return _followuptimezone3; }
            set { _followuptimezone3 = value; }
        }
        public string Follow_Up_Time_Zone_4
        {
            get { return _followuptimezone4; }
            set { _followuptimezone4 = value; }
        }
        public string Follow_Up_Time_Zone_5
        {
            get { return _followuptimezone5; }
            set { _followuptimezone5 = value; }
        }
        //--------------------------------Follow_Up_Phone_1
        public string Follow_Up_Phone_1
        {
            get { return _followupphone1; }
            set { _followupphone1 = value; }
        }
        public string Follow_Up_Phone_2
        {
            get { return _followupphone2; }
            set { _followupphone2 = value; }
        }
        public string Follow_Up_Phone_3
        {
            get { return _followupphone3; }
            set { _followupphone3 = value; }
        }
        public string Follow_Up_Phone_4
        {
            get { return _followupphone4; }
            set { _followupphone4 = value; }
        }
        public string Follow_Up_Phone_5
        {
            get { return _followupphone5; }
            set { _followupphone5 = value; }
        }
        //-------------------------------Follow_Up_Ext_1
        public string Follow_Up_Ext_1
        {
            get { return _followupext1; }
            set { _followupext1 = value; }
        }
        public string Follow_Up_Ext_2
        {
            get { return _followupext2; }
            set { _followupext2 = value; }
        }
        public string Follow_Up_Ext_3
        {
            get { return _followupext3; }
            set { _followupext3 = value; }
        }
        public string Follow_Up_Ext_4
        {
            get { return _followupext4; }
            set { _followupext4 = value; }
        }
        public string Follow_Up_Ext_5
        {
            get { return _followupext5; }
            set { _followupext5 = value; }
        }

        public string Email_Sent
        {
            get { return _emailsent; }
            set { _emailsent = value; }
        }

        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public ShellOilIncidentData()
        {
            _incid = 0;
            _ersop = "";
            _date = "";
            _time = "";
            _callername1 = "";
            _callername2 = "";
            _callername3 = "";
            _callerphone1 = "";
            _callerphone2 = "";
            _callerphone3 = "";
            _callerext1 = "";
            _callerext2 = "";
            _callerext3 = "";
            _calleraltphone1 = "";
            _calleraltphone2 = "";
            _calleraltphone3 = "";
            _calleraltext1 = "";
            _calleraltext2 = "";
            _calleraltext3 = "";
            _comments = "";
            _staffname = "";
            _staffphone = "";
            _staffext = "";
            _staffreporttime = "";
            _stafftimezone = "";
            _followupname1 = "";
            _followupname2 = "";
            _followupname3 = "";
            _followupname4 = "";
            _followupname5 = "";
            _followuptime1 = "";
            _followuptime2 = "";
            _followuptime3 = "";
            _followuptime4 = "";
            _followuptime5 = "";
            _followuptimezone1 = "";
            _followuptimezone2 = "";
            _followuptimezone3 = "";
            _followuptimezone4 = "";
            _followuptimezone5 = "";
            _followupphone1 = "";
            _followupphone2 = "";
            _followupphone3 = "";
            _followupphone4 = "";
            _followupphone5 = "";
            _followupext1 = "";
            _followupext2 = "";
            _followupext3 = "";
            _followupext4 = "";
            _followupext5 = "";
            _emailsent = "";
            _notes = "";
        }

        public ShellOilIncidentData(string constring, int id)
        {
            this.Inc_ID=id;
            SearchShellOilIncidentDataByID(constring);
        }

        #endregion
        #region Search Methods

        public void SearchShellOilIncidentDataByID(string constring)
        {
            string strsql = "SELECT * FROM shelloilincidentdata WHERE incid=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Inc_ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.Inc_ID = int.Parse(rdr[0].ToString());
                        this.ERS_Operator = rdr[1].ToString();
                        this.Date = rdr[2].ToString();
                        this.Time = rdr[3].ToString();
                        this.Caller_Name_1 = rdr[4].ToString();
                        this.Caller_Name_2 = rdr[5].ToString();
                        this.Caller_Name_3 = rdr[6].ToString();
                        this.Caller_Phone_1 = rdr[7].ToString();
                        this.Caller_Phone_2 = rdr[8].ToString();
                        this.Caller_Phone_3 = rdr[9].ToString();
                        this.Caller_Ext_1 = rdr[10].ToString();
                        this.Caller_Ext_2 = rdr[11].ToString();
                        this.Caller_Ext_3 = rdr[12].ToString();
                        this.Caller_Alt_Phone_1 = rdr[13].ToString();
                        this.Caller_Alt_Phone_2 = rdr[14].ToString();
                        this.Caller_Alt_Phone_3 = rdr[15].ToString();
                        this.Caller_Alt_Ext_1 = rdr[16].ToString();
                        this.Caller_Alt_Ext_2 = rdr[17].ToString();
                        this.Caller_Alt_Ext_3 = rdr[18].ToString();
                        this.Comments = rdr[19].ToString();
                        this.Staff_Name = rdr[20].ToString();
                        this.Staff_Phone = rdr[21].ToString();
                        this.Staff_Ext = rdr[22].ToString();
                        this.Staff_Report_Time = rdr[23].ToString();
                        this.Staff_Time_Zone = rdr[24].ToString();

                        this.Follow_Up_Name_1 = rdr[25].ToString();
                        this.Follow_Up_Name_2 = rdr[26].ToString();
                        this.Follow_Up_Name_3 = rdr[27].ToString();
                        this.Follow_Up_Name_4 = rdr[28].ToString();
                        this.Follow_Up_Name_5 = rdr[29].ToString();

                        this.Follow_Up_Time_1 = rdr[30].ToString();
                        this.Follow_Up_Time_2 = rdr[31].ToString();
                        this.Follow_Up_Time_3 = rdr[32].ToString();
                        this.Follow_Up_Time_4 = rdr[33].ToString();
                        this.Follow_Up_Time_5 = rdr[34].ToString();


                        this.Follow_Up_Time_Zone_1 = rdr[35].ToString();
                        this.Follow_Up_Time_Zone_2 = rdr[36].ToString();
                        this.Follow_Up_Time_Zone_3 = rdr[37].ToString();
                        this.Follow_Up_Time_Zone_4 = rdr[38].ToString();
                        this.Follow_Up_Time_Zone_5 = rdr[39].ToString();

                        this.Follow_Up_Phone_1 = rdr[40].ToString();
                        this.Follow_Up_Phone_2 = rdr[41].ToString();
                        this.Follow_Up_Phone_3 = rdr[42].ToString();
                        this.Follow_Up_Phone_4 = rdr[43].ToString();
                        this.Follow_Up_Phone_5 = rdr[44].ToString();

                        this.Follow_Up_Ext_1 = rdr[45].ToString();
                        this.Follow_Up_Ext_2 = rdr[46].ToString();
                        this.Follow_Up_Ext_3 = rdr[47].ToString();
                        this.Follow_Up_Ext_4 = rdr[48].ToString();
                        this.Follow_Up_Ext_5 = rdr[49].ToString();

                        this.Email_Sent = rdr[50].ToString();
                        this.Notes = rdr[51].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
