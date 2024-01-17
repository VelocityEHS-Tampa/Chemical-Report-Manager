using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class IES
    {
        #region Private Fields

        private int _id;
        private string _emergency, _facilityname, _location, _address, _city, _state, _zip, _callername, _callerphonenumber, _contactonscenename, _contactonscenephonenumber;
        private string _callerunknown, _contactunknown;

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

        public string Emergency
        {
            get { return _emergency; }
            set { _emergency = value; }
        }

        public string Facility_Name
        {
            get { return _facilityname; }
            set { _facilityname = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
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

        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        public string Caller_Name
        {
            get { return _callername; }
            set { _callername = value; }
        }

        public string Caller_Phone_Number
        {
            get { return _callerphonenumber; }
            set { _callerphonenumber = value; }
        }

        public string Contact_On_Scene_Name
        {
            get { return _contactonscenename; }
            set { _contactonscenename = value; }
        }

        public string Contact_On_Scene_Phone_Number
        {
            get { return _contactonscenephonenumber; }
            set { _contactonscenephonenumber = value; }
        }

        public string Caller_Unknown
        {
            get { return _callerunknown; }
            set { _callerunknown = value; }
        }

        public string Contact_Unknown
        {
            get { return _contactunknown; }
            set { _contactunknown = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public IES()
        {
            _id = 0;
            _emergency = "";
            _facilityname = "";
            _location = "";
            _address = "";
            _city = "";
            _state = "";
            _zip = "";
            _callername = "";
            _callerphonenumber = "";
            _contactonscenename = "";
            _contactonscenephonenumber = "";
            _callerunknown = "";
            _contactunknown = "";
        }

        public IES(string constring, int id)
        {
            this.ID = id;
            SearchByID(constring);
        }

        #endregion
        #region Search Methods

        private void SearchByID(string constring)
        {
            string strsql = "SELECT * FROM ies WHERE id=@id";
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
                        this.Emergency = rdr["emergency"].ToString();
                        this.Facility_Name = rdr["facilityname"].ToString();
                        this.Location = rdr["location"].ToString();
                        this.Address = rdr["address"].ToString();
                        this.City = rdr["city"].ToString();
                        this.State = rdr["state"].ToString();
                        this.Zip = rdr["zip"].ToString();
                        this.Caller_Name = rdr["callername"].ToString();
                        this.Caller_Phone_Number = rdr["callerphonenumber"].ToString();
                        this.Contact_On_Scene_Name = rdr["contactonscenename"].ToString();
                        this.Contact_On_Scene_Phone_Number = rdr["contactonscenephonenumber"].ToString();
                        this.Caller_Unknown = rdr["callerunknown"].ToString();
                        this.Contact_Unknown = rdr["contactunknown"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
