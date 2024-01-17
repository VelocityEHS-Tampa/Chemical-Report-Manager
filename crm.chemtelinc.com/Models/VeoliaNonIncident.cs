using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class VeoliaNonIncident
    {
        #region Private Fields

        private int _id;
        private string _callername, _callerphonenumber, _calleraffiliation, _incidentcity, _incidentstate, _description, _ersoperator, _date, _time;

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

        public string Caller_Affiliation
        {
            get { return _calleraffiliation; }
            set { _calleraffiliation = value; }
        }

        public string Incident_City
        {
            get { return _incidentcity; }
            set { _incidentcity = value; }
        }

        public string Incident_State
        {
            get { return _incidentstate; }
            set { _incidentstate = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string ERS_Operator
        {
            get { return _ersoperator; }
            set { _ersoperator = value; }
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

        #endregion
        #endregion
        #region Public Constructors

        public VeoliaNonIncident()
        {
            _id = 0;
            _callername = "";
            _callerphonenumber = "";
            _calleraffiliation = "";
            _incidentcity = "";
            _incidentstate = "";
            _description = "";
            _ersoperator = "";
            _date = "";
            _time = "";
        }

        public VeoliaNonIncident(string constring, int id)
        {
            this.ID = id;
            SearchbyID(constring);
        }

        #endregion
        #region Search Methods

        private void SearchbyID(string constring)
        {
            string strsql = "SELECT * FROM veolianonincident WHERE id=@id";
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
                        this.Caller_Name = rdr["callername"].ToString();
                        this.Caller_Phone_Number = rdr["callerphonenumber"].ToString();
                        this.Caller_Affiliation = rdr["calleraffiliation"].ToString();
                        this.Incident_City = rdr["incidentcity"].ToString();
                        this.Incident_State = rdr["incidentstate"].ToString();
                        this.Description = rdr["description"].ToString();
                        this.ERS_Operator = rdr["ersoperator"].ToString();
                        this.Date = rdr["date"].ToString();
                        this.Time = rdr["time"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
