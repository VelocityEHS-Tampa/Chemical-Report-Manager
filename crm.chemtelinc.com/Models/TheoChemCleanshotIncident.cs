using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class TheoChemCleanshotIncident
    {
        #region Private Fields

        private string _incidentid, _ersop, _rptdate, _rpttime, _callername, _callerphone, _calleraff, _callerfaxemail, _incstreet, _inccity, _incstate, _inccountry, _inctimezone;
        private string _incdate, _inctime, _quest1, _quest2qty, _quest2units, _quest3, _quest4, _quest5, _quest6, _quest7, _quest8, _quest9, _quest10yoesorno, _quest10ifyeswhat;
        private string _quest11yesorno, _quest11ifyeswhat, _quest12, _quest13, _quest14, _quest15, _quest16, _quest17, _additcommentsdetails, _subname, _subadmincontact, _subphone;
        private string _subfax, _subemail, _subaddress, _subcitystatezip, _emailsent, _comments, _type;

        #endregion
        #region Public Properties
        #region Strings

        public string Incident_ID
        {
            get { return _incidentid; }
            set { _incidentid = value; }
        }

        public string Ers_Operator
        {
            get { return _ersop; }
            set { _ersop = value; }
        }

        public string Report_Date
        {
            get { return _rptdate; }
            set { _rptdate = value; }
        }

        public string Report_Time
        {
            get { return _rpttime; }
            set { _rpttime = value; }
        }

        public string Caller_Name
        {
            get { return _callername; }
            set { _callername = value; }
        }

        public string Caller_Phone
        {
            get { return _callerphone; }
            set { _callerphone = value; }
        }

        public string Caller_Affiliate
        {
            get { return _calleraff; }
            set { _calleraff = value; }
        }

        public string Caller_Fax_Email
        {
            get { return _callerfaxemail; }
            set { _callerfaxemail = value; }
        }

        public string Incident_Street
        {
            get { return _incstreet; }
            set { _incstreet = value; }
        }

        public string Incident_City
        {
            get { return _inccity; }
            set { _inccity = value; }
        }

        public string Incident_State
        {
            get { return _incstate; }
            set { _incstate = value; }
        }
        
        public string Incident_Country
        {
            get{ return _inccountry;}
            set {_inccountry=value;}
        }

        public string Incident_Time_Zone
        {
            get { return _inctimezone; }
            set { _inctimezone = value; }
        }

        public string Incident_Date
        {
            get { return _incdate; }
            set { _incdate = value; }
        }

        public string Incident_Time
        {
            get { return _inctime; }
            set { _inctime = value; }
        }

        public string Question_1
        {
            get { return _quest1; }
            set { _quest1 = value; }
        }

        public string Question_2_Quantity
        {
            get { return _quest2qty; }
            set { _quest2qty = value; }
        }

        public string Question_2_Units
        {
            get { return _quest2units; }
            set { _quest2units = value; }
        }

        public string Question_3
        {
            get { return _quest3; }
            set { _quest3 = value; }
        }

        public string Question_4
        {
            get { return _quest4; }
            set { _quest4 = value; }
        }

        public string Question_5
        {
            get { return _quest5; }
            set { _quest5 = value; }
        }

        public string Question_6
        {
            get { return _quest6; }
            set { _quest6 = value; }
        }

        public string Question_7
        {
            get { return _quest7; }
            set { _quest7 = value; }
        }

        public string Question_8
        {
            get { return _quest8; }
            set { _quest8 = value; }
        }

        public string Question_9
        {
            get { return _quest9; }
            set { _quest9 = value; }
        }

        public string Question_10_Yes_Or_No
        {
            get { return _quest10yoesorno; }
            set { _quest10yoesorno = value; }
        }

        public string Question_10_IfYes_What
        {
            get { return _quest10ifyeswhat; }
            set { _quest10ifyeswhat = value; }
        }

        public string Question_11_Yes_Or_No
        {
            get { return _quest11yesorno; }
            set { _quest11yesorno = value; }
        }

        public string Question_11_If_Yes_What
        {
            get { return _quest11ifyeswhat; }
            set { _quest11ifyeswhat = value; }
        }

        public string Question_12
        {
            get { return _quest12; }
            set { _quest12 = value; }
        }

        public string Question_13
        {
            get { return _quest13; }
            set { _quest13 = value; }
        }

        public string Question_14
        {
            get { return _quest14; }
            set { _quest14 = value; }
        }

        public string Question_15
        {
            get { return _quest15; }
            set { _quest15 = value; }
        }

        public string Question_16
        {
            get { return _quest16; }
            set { _quest16 = value; }
        }

        public string Question_17
        {
            get { return _quest17; }
            set { _quest17 = value; }
        }

        public string Add_It_Comments_Details
        {
            get { return _additcommentsdetails; }
            set { _additcommentsdetails = value; }
        }

        public string Sub_Name
        {
            get { return _subname; }
            set { _subname = value; }
        }

        public string Sub_Administrative_Contact
        {
            get { return _subadmincontact; }
            set { _subadmincontact = value; }
        }

        public string Sub_Phone
        {
            get { return _subphone; }
            set { _subphone = value; }
        }

        public string Sub_Fax
        {
            get { return _subfax; }
            set { _subfax = value; }
        }

        public string Sub_Email
        {
            get { return _subemail; }
            set { _subemail = value; }
        }

        public string Sub_Address
        {
            get { return _subaddress; }
            set { _subaddress = value; }
        }

        public string Sub_City_State_Zip
        {
            get { return _subcitystatezip; }
            set { _subcitystatezip = value; }
        }

        public string Email_Sent
        {
            get { return _emailsent; }
            set { _emailsent = value; }
        }

        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public TheoChemCleanshotIncident()
        {
            _incidentid = "";
            _ersop = "";
            _rptdate = "";
            _rpttime = "";
            _callername = "";
            _callerphone = "";
            _calleraff = "";
            _callerfaxemail = "";
            _incstreet = "";
            _inccity = "";
            _incstate = "";
            _inccountry = "";
            _inctimezone = "";
            _incdate = "";
            _inctime = "";
            _quest1 = "";
            _quest2qty = "";
            _quest2units = "";
            _quest3 = "";
            _quest4 = "";
            _quest5 = "";
            _quest6 = "";
            _quest7 = "";
            _quest8 = "";
            _quest9 = "";
            _quest10yoesorno = "";
            _quest10ifyeswhat = "";
            _quest11yesorno = "";
            _quest11ifyeswhat = "";
            _quest12 = "";
            _quest13 = "";
            _quest14 = "";
            _quest15 = "";
            _quest16 = "";
            _quest17 = "";
            _additcommentsdetails = "";
            _subname = "";
            _subadmincontact = "";
            _subphone = "";
            _subfax = "";
            _subemail = "";
            _subaddress = "";
            _subcitystatezip = "";
            _emailsent = "";
            _comments = "";
            _type = "";
        }

        public TheoChemCleanshotIncident(string constring, string id)
        {
            this.Incident_ID = id;
            SearchTheoChemCleanShotIncidents(constring);
        }

        #endregion
        #region Search Methods

        public void SearchTheoChemCleanShotIncidents(string constring)
        {
            string strsql = "SELECT * FROM theochemcleanshotincidents WHERE incidentId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Incident_ID);
                    SqlDataReader rdr=cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        this.Incident_ID=rdr[0].ToString();
                        this.Ers_Operator=rdr[1].ToString();
                        this.Report_Date=rdr[2].ToString();
                        this.Report_Time=rdr[3].ToString();
                        this.Caller_Name=rdr[4].ToString();
                        this.Caller_Phone=rdr[5].ToString();
                        this.Caller_Affiliate=rdr[6].ToString();
                        this.Caller_Fax_Email=rdr[7].ToString();
                        this.Incident_Street=rdr[8].ToString();
                        this.Incident_City=rdr[9].ToString();
                        this.Incident_State=rdr[10].ToString();
                        this.Incident_Country = rdr[11].ToString();
                        this.Incident_Time_Zone = rdr[12].ToString();
                        this.Incident_Date = rdr[13].ToString();
                        this.Incident_Time = rdr[14].ToString();
                        this.Question_1 = rdr[15].ToString();
                        this.Question_2_Quantity = rdr[16].ToString();
                        this.Question_2_Units = rdr[17].ToString();
                        this.Question_3 = rdr[18].ToString();
                        this.Question_4 = rdr[19].ToString();
                        this.Question_5 = rdr[20].ToString();
                        this.Question_6 = rdr[21].ToString();
                        this.Question_7 = rdr[22].ToString();
                        this.Question_8 = rdr[23].ToString();
                        this.Question_9 = rdr[24].ToString();
                        this.Question_10_Yes_Or_No = rdr[25].ToString();
                        this.Question_10_IfYes_What = rdr[26].ToString();
                        this.Question_11_Yes_Or_No = rdr[27].ToString();
                        this.Question_11_If_Yes_What = rdr[28].ToString();
                        this.Question_12 = rdr[29].ToString();
                        this.Question_13 = rdr[30].ToString();
                        this.Question_14 = rdr[31].ToString();
                        this.Question_15 = rdr[32].ToString();
                        this.Question_16 = rdr[33].ToString();
                        this.Question_17 = rdr[34].ToString();
                        this.Add_It_Comments_Details = rdr[35].ToString();
                        this.Sub_Name = rdr[36].ToString();
                        this.Sub_Administrative_Contact = rdr[37].ToString();
                        this.Sub_Phone = rdr[38].ToString();
                        this.Sub_Fax = rdr[39].ToString();
                        this.Sub_Email = rdr[40].ToString();
                        this.Sub_Address = rdr[41].ToString();
                        this.Sub_City_State_Zip = rdr[42].ToString();
                        this.Email_Sent = rdr[43].ToString();
                        this.Comments = rdr[44].ToString();
                        this.Type = rdr[45].ToString();
                    }
                }
            }
        }

        #endregion

    }
}
