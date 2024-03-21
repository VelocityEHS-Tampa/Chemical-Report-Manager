using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemicalLibrary
{
    public class NorthwindGenInc
    {


        #region Private Variables
        DateTime _calldate, _incidentdate, _notificationdate;
        string _ersoperator, _callername, _phonenumber, _emporcontract, _contractedcompany, _timezone, _incidentcity, _incidentstate, _incidentcounty,_facilityorproject,
            _incidentlocation, _incidenttype, _waterbodiesimpacted, _impactedareas, _incidentdetails, _individualsafety, _notify911, _transporttohospital, _mediaonscene, _emergencyresponders,
            _hsername, _hsercontactnumber, _notificationtime, _incidenttime, _calltime;
        #endregion


        #region Public Variables
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
        #endregion

        public NorthwindGenInc()
        {
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
            _incidentcounty = "";
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
        }
    }
}