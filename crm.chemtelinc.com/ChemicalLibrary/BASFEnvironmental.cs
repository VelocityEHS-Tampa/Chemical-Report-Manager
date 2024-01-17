using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class BASFEnvironmental
    {
        #region Private Fields

        private string _id;
        private string _incidentdate, _incidenttime, _callername, _callerphone, _plantname, _materialname, _sdsonhand, _contained, _handlingcleanup, _description;
        private string _quantity, _quantityunits, _releaseto, _actions, _achievereportablequantity, _notifications, _ersoperator,  _calldate, _calltime, _nrc, _peas;

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

        public string Material_Name
        {
            get { return _materialname; }
            set { _materialname = value; }
        }

        public string SDS_On_Hand
        {
            get { return _sdsonhand; }
            set { _sdsonhand = value; }
        }

        public string Contained
        {
            get { return _contained; }
            set { _contained = value; }
        }

        public string Handling_Cleanup
        {
            get { return _handlingcleanup; }
            set { _handlingcleanup = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public string Quantity_Untits
        {
            get { return _quantityunits; }
            set { _quantityunits = value; }
        }

        public string Release_To
        {
            get { return _releaseto; }
            set { _releaseto = value; }
        }

        public string Actions
        {
            get { return _actions; }
            set { _actions = value; }
        }

        public string Achieve_Reportable_Quantity
        {
            get { return _achievereportablequantity; }
            set { _achievereportablequantity = value; }
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

        public BASFEnvironmental()
        {
            _id = "";
            _incidentdate = "";
            _incidenttime = "";
            _callername = "";
            _callerphone = "";
            _plantname = "";
            _materialname = "";
            _sdsonhand = "";
            _contained = "";
            _handlingcleanup = "";
            _description = "";
            _quantity = "";
            _quantityunits = "";
            _releaseto = "";
            _actions = "";
            _achievereportablequantity = "";
            _notifications = "";
            _ersoperator = "";
            _calldate = "";
            _calltime = "";
            _nrc = "";
            _peas = "";
        }

        public BASFEnvironmental(string constring, string id)
        {
            this.ID = id;
            SearchByID(constring);
        }

        #endregion
        #region Search Methods

        private void SearchByID(string constring)
        {
            string strsql = "SELECT * FROM basfenvironmental WHERE id=@id";
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
                        this.Material_Name = rdr["materialname"].ToString();
                        this.SDS_On_Hand = rdr["sdsonhand"].ToString();
                        this.Contained = rdr["contained"].ToString();
                        this.Handling_Cleanup = rdr["handlingcleanup"].ToString();
                        this.Description = rdr["description"].ToString();
                        this.Quantity = rdr["quantity"].ToString();
                        this.Quantity_Untits = rdr["quantityunits"].ToString();
                        this.Release_To = rdr["releaseto"].ToString();
                        this.Actions = rdr["actions"].ToString();
                        this.Achieve_Reportable_Quantity = rdr["achievereportablequantity"].ToString();
                        this.Notifications = rdr["notifications"].ToString();
                        this.ERS_Operator = rdr["ersoperator"].ToString();
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
