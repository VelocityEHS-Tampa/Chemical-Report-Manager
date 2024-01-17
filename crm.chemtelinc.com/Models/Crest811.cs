using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
     public class Crest811
    {
        #region Private Fields

        private int _id;
        private string _todaydate, _todaytime, _excavationdate, _excavationtime, _normaloremergency, _requestticketnumber, _personcompanyname, _callbacknumber, _emailaddress;
        private string _city, _state, _county, _workdate, _street, _intersection, _nature, _remarks, _callername, _callernumber, _name, _contactnumber, _location, _facilityname;

        #endregion
        #region Public Properties
        #region Ints

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        #endregion
        #region Strings

        public string Today_Date
        {
            get { return _todaydate; }
            set { _todaydate = value; }
        }

        public string Today_Time
        {
            get { return _todaytime; }
            set { _todaytime = value; }
        }

        public string Excavation_Date
        {
            get { return _excavationdate; }
            set { _excavationdate = value; }
        }

        public string Excavation_Time
        {
            get { return _excavationtime; }
            set { _excavationtime = value; }
        }

        public string Normal_Or_Emergency
        {
            get { return _normaloremergency; }
            set { _normaloremergency = value; }
        }

        public string Request_Ticket_Number
        {
            get { return _requestticketnumber; }
            set { _requestticketnumber = value; }
        }

        public string Person_Company_Name
        {
            get { return _personcompanyname; }
            set { _personcompanyname = value; }
        }

        public string Callback_Number
        {
            get { return _callbacknumber; }
            set { _callbacknumber = value; }
        }

        public string Email_Address
        {
            get { return _emailaddress; }
            set { _emailaddress = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string County
        {
            get { return _county; }
            set { _county = value; }
        }

        public string Work_Date
        {
            get { return _workdate; }
            set { _workdate = value; }
        }

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        public string Intersection
        {
            get { return _intersection; }
            set { _intersection = value; }
        }

        public string Nature
        {
            get { return _nature; }
            set { _nature = value; }
        }

        public string Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        public string Caller_Name
        {
            get { return _callername; }
            set { _callername = value; }
        }

        public string Caller_Number
        {
            get { return _callernumber; }
            set { _callernumber = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Contact_Number
        {
            get { return _contactnumber; }
            set { _contactnumber = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public string FacilityName
        {
            get { return _facilityname; }
            set { _facilityname = value; }
        }

        #endregion
        #endregion
        #region Public Properties

        public Crest811()
        {
            _id = 0;
            _todaydate = "";
            _todaytime = "";
            _excavationdate = "";
            _excavationtime = "";
            _normaloremergency = "";
            _requestticketnumber = "";
            _personcompanyname = "";
            _callbacknumber = "";
            _emailaddress = "";
            _city = "";
            _state = "";
            _county = "";
            _workdate = "";
            _street = "";
            _intersection = "";
            _nature = "";
            _remarks = "";
            _callername = "";
            _callernumber = "";
            _name = "";
            _contactnumber = "";
            _location = "";
            _facilityname = "";
        }

        public Crest811(string constring, int id)
        {
            this.ID = id;
            SearchByID(constring);
        }

        #endregion
        #region Search Methods

        private void SearchByID(string constring)
        {
            string strsql = "SELECT * FROM crest811 WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = int.Parse(rdr["id"].ToString());
                        this.Today_Date = rdr["todaydate"].ToString();
                        this.Today_Time = rdr["todaytime"].ToString();
                        this.Excavation_Date = rdr["excavationdate"].ToString();
                        this.Excavation_Time = rdr["excavationtime"].ToString();
                        this.Normal_Or_Emergency = rdr["normaloremergency"].ToString();
                        this.Request_Ticket_Number = rdr["requestticketnumber"].ToString();
                        this.Person_Company_Name = rdr["personcompanyname"].ToString();
                        this.Callback_Number = rdr["callbacknumber"].ToString();
                        this.Email_Address = rdr["emailaddress"].ToString();
                        this.City = rdr["city"].ToString();
                        this.State = rdr["state"].ToString();
                        this.County = rdr["county"].ToString();
                        this.Work_Date = rdr["workdate"].ToString();
                        this.Street = rdr["street"].ToString();
                        this.Intersection = rdr["intersection"].ToString();
                        this.Nature = rdr["nature"].ToString();
                        this.Remarks = rdr["remarks"].ToString();
                        this.Caller_Name = rdr["callername"].ToString();
                        this.Caller_Number = rdr["callernumber"].ToString();
                        this.Name = rdr["name"].ToString();
                        this.Contact_Number = rdr["contactnumber"].ToString();
                        this.Location = rdr["location"].ToString();
                        this.FacilityName = rdr["FacilityName"].ToString();
                    }
                }
            }
        }
        #endregion
        #region GetNextID
        public static int GetNextID(string constring)
        {
            string sqlcmd = "SELECT TOP 1 id FROM crest811 ORDER BY id DESC";
            int LatestID = 0;
            int NewID = 0;

            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    con.Open();
                    LatestID = (int)cmd.ExecuteScalar();
                }
            }
            NewID = LatestID + 1;
            return NewID;
        }
        #endregion
    }
}
