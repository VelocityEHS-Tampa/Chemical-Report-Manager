using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class BASFInjury
    {
        #region Private Fields

        private string _id;
        private string _incidentdate, _incidenttime, _callername, _callerphone, _plantname, _description, _injurytype, _bodypartaffected, _escorted, _immediateactions;
        private string _evidencecollected, _notifications, _ersoperator, _productname, _calldate, _calltime, _nrc, _peas;

        #endregion
        #region Public Properties        
        #region Strings

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Incident_Date
        {
            get { return _incidentdate; }
            set { _incidentdate = value; }
        }

        public string Incident_Time
        {
            get { return _incidenttime; }
            set { _incidenttime = value; }
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

        public string Plant_Name
        {
            get { return _plantname; }
            set { _plantname = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Injury_Type
        {
            get { return _injurytype; }
            set { _injurytype = value; }
        }

        public string Body_Part_Affected
        {
            get { return _bodypartaffected; }
            set { _bodypartaffected = value; }
        }

        public string Escorted
        {
            get { return _escorted; }
            set { _escorted = value; }
        }

        public string Immediate_Actions
        {
            get { return _immediateactions; }
            set { _immediateactions = value; }
        }

        public string Evidence_Collected
        {
            get { return _evidencecollected; }
            set { _evidencecollected = value; }
        }

        public string Notifications
        {
            get { return _notifications; }
            set { _notifications = value; }
        }

        public string ERS_Operator
        {
            get { return _ersoperator; }
            set { _ersoperator = value; }
        }

        public string Product_Name
        {
            get { return _productname; }
            set { _productname = value; }
        }

        public string Call_Date
        {
            get { return _calldate; }
            set { _calldate = value; }
        }

        public string Call_Time
        {
            get { return _calltime; }
            set { _calltime = value; }
        }

        public string NRC
        {
            get { return _nrc; }
            set { _nrc = value; }
        }

        public string PEAS
        {
            get { return _peas; }
            set { _peas = value; }
        }

        #endregion
        #endregion
        #region Public Constructors
        public BASFInjury()
        {
            _id = "";
            _incidentdate = "";
            _incidenttime = "";
            _callername = "";
            _callerphone = "";
            _plantname = "";
            _description = "";
            _injurytype = "";
            _bodypartaffected = "";
            _escorted = "";
            _immediateactions = "";
            _evidencecollected = "";
            _notifications = "";
            _ersoperator = "";
            _productname = "";
            _calldate = "";
            _calltime = "";
            _nrc = "";
            _peas = "";
        }

        public BASFInjury(string constring, string id)
        {
            this.ID = id;
            SearchByID(constring);
        }


        #endregion
        #region Search Methods

        public void SearchByID(string constring)
        {
            string strsql = "SELECT * FROM basfinjury WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = rdr["id"].ToString();
                        this.Incident_Date = rdr["incidentdate"].ToString();
                        this.Incident_Time = rdr["incidenttime"].ToString();
                        this.Caller_Name = rdr["callername"].ToString();
                        this.Caller_Phone = rdr["callerphone"].ToString();
                        this.Plant_Name = rdr["plantname"].ToString();
                        this.Description = rdr["description"].ToString();
                        this.Injury_Type = rdr["injurytype"].ToString();
                        this.Body_Part_Affected = rdr["bodypartaffected"].ToString();
                        this.Escorted = rdr["escorted"].ToString();
                        this.Immediate_Actions = rdr["immediateactions"].ToString();
                        this.Evidence_Collected = rdr["evidencecollected"].ToString();
                        this.Notifications = rdr["notifications"].ToString();
                        this.ERS_Operator = rdr["ersoperator"].ToString();
                        this.Product_Name = rdr["productname"].ToString();
                        this.Call_Date = rdr["calldate"].ToString();
                        this.Call_Time = rdr["calltime"].ToString();
                        this.NRC = rdr["nrc"].ToString();
                        this.PEAS = rdr["peas"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
