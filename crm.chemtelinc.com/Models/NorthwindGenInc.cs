using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemicalLibrary
{
    public class NorthwindGenInc
    {


        #region Private Variables
        int _id;
        DateTime _calldate, _incidentdate, _notificationdate;
        string _ersoperator, _callername, _phonenumber, _emporcontract, _contractedcompany, _timezone, _incidentcity, _incidentstate, _incidentcounty,_facilityorproject,
            _incidentlocation, _incidenttype, _waterbodiesimpacted, _impactedareas, _incidentdetails, _individualsafety, _notify911, _transporttohospital, _mediaonscene, _emergencyresponders,
            _hsername, _hsercontactnumber, _notificationtime, _incidenttime, _calltime, _injuryexposureillness, _chemicalspillrelease;
        #endregion


        #region Public Variables
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string ERS_Operator
        {
            get { return _ersoperator; }
            set { _ersoperator = value; }
        }
        public string Caller_Name
        {
            get { return _callername; }
            set { _callername = value; }
        }
        public string Caller_Phone_Number
        {
            get { return _phonenumber; }
            set { _phonenumber = value; }
        }
        public string EmpOrContract
        {
            get { return _emporcontract; }
            set { _emporcontract = value; }
        }
        public string ContractedCompany
        {
            get { return _contractedcompany; }
            set { _contractedcompany = value; }
        }
        public DateTime Call_Date
        {
            get { return _calldate; }
            set { _calldate = value; }
        }
        public string Incident_Time
        {
            get { return _calltime; }
            set { _calltime = value; }
        }
        public DateTime Incident_Date
        {
            get { return _incidentdate; }
            set { _incidentdate = value; }
        }
        public string Call_Time
        {
            get { return _incidenttime; }
            set { _incidenttime = value; }
        }
        public string Incident_Time_Zone
        {
            get { return _timezone; }
            set { _timezone = value; }
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
        public string Incident_County
        {
            get { return _incidentcounty; }
            set { _incidentcounty = value; }
        }
        public string FacilityOrProject
        {
            get { return _facilityorproject; }
            set { _facilityorproject = value; }
        }
        public string IncidentLocation
        {
            get { return _incidentlocation; }
            set { _incidentlocation = value; }
        }
        
        public string WaterbodiesImpacted
        {
            get { return _waterbodiesimpacted; }
            set { _waterbodiesimpacted = value; }
        }
        public string ImpactedAreas
        {
            get { return _impactedareas; }
            set { _impactedareas = value; }
        }
        public string IncidentDetails
        {
            get { return _incidentdetails; }
            set { _incidentdetails = value; }
        }
        public string IndividualSafety
        {
            get { return _individualsafety; }
            set { _individualsafety = value; }
        }
        public string Notify_911
        {
            get { return _notify911; }
            set { _notify911 = value; }
        }
        public string Transport_ToHospital
        {
            get { return _transporttohospital; }
            set { _transporttohospital = value; }
        }
        public string Media_On_Scene
        {
            get { return _mediaonscene; }
            set { _mediaonscene = value; }
        }
        public string Emergency_Responders
        {
            get { return _emergencyresponders; }
            set { _emergencyresponders = value; }
        }
        public string HSERName
        {
            get { return _hsername; }
            set { _hsername = value; }
        }
        public string HSERContactNumber
        {
            get { return _hsercontactnumber; }
            set { _hsercontactnumber = value; }
        }
        public DateTime NotificationDate
        {
            get { return _notificationdate; }
            set { _notificationdate = value; }
        }
        public string NotificationTime
        {
            get { return _notificationtime; }
            set { _notificationtime = value; }
        }
        public string IncidentType
        {
            get { return _incidenttype; }
            set { _incidenttype = value; }
        }
        public string InjuryExposureIllness
        {
            get { return _injuryexposureillness; }
            set { _injuryexposureillness = value; }
        }
        public string ChemicalSpillRelease
        {
            get { return _chemicalspillrelease; }
            set { _chemicalspillrelease = value; }
        }
        #endregion

        public NorthwindGenInc()
        {
            _id = 0;
            _ersoperator = "";
            _callername = "";
            _phonenumber = "";
            _emporcontract = "";
            _contractedcompany = "";
            _calldate = DateTime.Now;
            _calltime = "";
            _incidentdate = DateTime.Now;
            _incidenttime = "";
            _timezone = "";
            _incidentcity = "";
            _incidentstate = "";
            _incidentcounty = "N/A";
            _facilityorproject = "";
            _incidentlocation = "";
            _incidenttype = "";
            _individualsafety = "";
            _notify911 = "";
            _transporttohospital = "";
            _mediaonscene = "";
            _emergencyresponders = "";
            _waterbodiesimpacted = "";
            _impactedareas = "";
            _hsername = "";
            _hsercontactnumber = "";
            _notificationdate = DateTime.Now;
            _notificationtime = "";
            _injuryexposureillness = "";
            _chemicalspillrelease = "";
        }
        public NorthwindGenInc(string constring, int id)
        {
            this.ID = id;
            SearchByID(constring);
        }
        private void SearchByID(string constring)
        {
            string strsql = "SELECT * FROM NorthwindGeneralIncidents WHERE ID=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = Int32.Parse(rdr["ID"].ToString());
                        this.ERS_Operator = rdr["ERSOperator"].ToString();
                        this.Caller_Name = rdr["CallerName"].ToString();
                        this.Caller_Phone_Number = rdr["CallerPhone"].ToString();
                        this.EmpOrContract = rdr["EmpOrContract"].ToString();
                        this.ContractedCompany = rdr["ContractedCompany"].ToString();
                        this.Call_Date = DateTime.Parse(rdr["CallDate"].ToString());
                        this.Call_Time = rdr["CallTime"].ToString();
                        this.Incident_Date = DateTime.Parse(rdr["IncidentDate"].ToString());
                        this.Incident_Time = rdr["IncidentTime"].ToString();
                        this.Incident_Time_Zone = rdr["IncidentTimeZone"].ToString();
                        this.Incident_City= rdr["IncidentCity"].ToString();
                        this.Incident_State = rdr["IncidentState"].ToString();
                        this.FacilityOrProject = rdr["FacilityOrProject"].ToString();
                        this.IncidentLocation = rdr["IncidentLocation"].ToString();
                        this.IncidentType = rdr["IncidentNature"].ToString();
                        this.InjuryExposureIllness = rdr["InjuryExposureIllness"].ToString();
                        this.ChemicalSpillRelease = rdr["ChemicalSpillRelease"].ToString();
                        this.WaterbodiesImpacted = rdr["WaterbodiesImpacted"].ToString();
                        this.ImpactedAreas = rdr["ImpactedAreaDetails"].ToString();
                        this.IncidentDetails = rdr["IncidentDetails"].ToString();
                        this.IndividualSafety = rdr["IndividualSafety"].ToString();
                        this.Notify_911 = rdr["Notify911"].ToString();
                        this.Transport_ToHospital = rdr["TransportToHospital"].ToString();
                        this.Media_On_Scene = rdr["MediaOnScene"].ToString();
                        this.Emergency_Responders = rdr["EmergencyResponders"].ToString();
                        this.HSERName = rdr["HSERName"].ToString();
                        this.HSERContactNumber = rdr["HSERPhone"].ToString();
                        this.NotificationDate = DateTime.Parse(rdr["NotificationDate"].ToString());
                        this.NotificationTime = rdr["NotificationTime"].ToString();
                    }
                }
            }
        }
    }
}