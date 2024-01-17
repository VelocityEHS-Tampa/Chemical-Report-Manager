using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class GeneralIncidentReportData
    {
        #region Private Fields

        private string _incidentid, _ersoperator, _date, _time, _callersname, _callersphone, _callersaffiliation, _callersfaxoremail, _incidentstreet, _incidentcity, _incidentstate;
        private string _incidentcountry, _incidentdate, _incidenttime, _incidenttimezone, _materialname, _productnumber, _quantityspilled, _cleanupcrewreqs, _agenciesonsite;
        private string _accidentordeliberate, _incidentdetails, _involvefire, _wheredidyougetournumber, _subscribersname, _subscribersmis, _spillorexposure, _typeofexposure;
        private string _numofcasualties, _numofinjuries, _medpersonnelname, _patientname, _patientcondition, _hospitalcliniclocation, _eparegno, _statusofrelease;
        private string _dispersionofmsdsinfo, _reviewedby, _revieweddate, _sentdate, _comments, _datechanged, _username, _incidentzipcode, _reporttype, _callersphoneext;

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

        public string Callers_Name
        {
            get { return _callersname; }
            set { _callersname = value; }
        }

        public string Callers_Phone
        {
            get { return _callersphone; }
            set { _callersphone = value; }
        }

        public string Callers_Affiliation
        {
            get { return _callersaffiliation; }
            set { _callersaffiliation = value; }
        }

        public string Callers_Fax_Or_Email
        {
            get { return _callersfaxoremail; }
            set { _callersfaxoremail = value; }
        }

        public string Incident_Street
        {
            get { return _incidentstreet; }
            set { _incidentstreet = value; }
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

        public string Incident_Country
        {
            get { return _incidentcountry; }
            set { _incidentcountry = value; }
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

        public string Incident_Time_Zone
        {
            get { return _incidenttimezone; }
            set { _incidenttimezone = value; }
        }

        public string Material_Name
        {
            get { return _materialname; }
            set { _materialname = value; }
        }

        public string Product_Number
        {
            get { return _productnumber; }
            set { _productnumber = value; }
        }

        public string Quantity_Spilled
        {
            get { return _quantityspilled; }
            set { _quantityspilled = value; }
        }

        public string Cleanup_Crew_Requirements
        {
            get { return _cleanupcrewreqs; }
            set { _cleanupcrewreqs = value; }
        }

        public string Agencies_On_Site
        {
            get { return _agenciesonsite; }
            set { _agenciesonsite = value; }
        }

        public string Accident_Or_Deliberate
        {
            get { return _accidentordeliberate; }
            set { _accidentordeliberate = value; }
        }

        public string Incident_Details
        {
            get { return _incidentdetails; }
            set { _incidentdetails = value; }
        }

        public string Involve_Fire
        {
            get { return _involvefire; }
            set { _involvefire = value; }
        }

        public string Where_Did_You_Get_Our_Number
        {
            get { return _wheredidyougetournumber; }
            set { _wheredidyougetournumber = value; }
        }

        public string Subscribers_Name
        {
            get { return _subscribersname; }
            set { _subscribersname = value; }
        }

        public string Subscribers_MIS
        {
            get { return _subscribersmis; }
            set { _subscribersmis = value; }
        }

        public string Spill_Or_Exposure
        {
            get { return _spillorexposure; }
            set { _spillorexposure = value; }
        }

        public string Type_Of_Exposure
        {
            get { return _typeofexposure; }
            set { _typeofexposure = value; }
        }

        public string Num_Of_Casualties
        {
            get { return _numofcasualties; }
            set { _numofcasualties = value; }
        }

        public string Num_Of_Injuries
        {
            get { return _numofinjuries; }
            set { _numofinjuries = value; }
        }

        public string Med_Personnel_Name
        {
            get { return _medpersonnelname; }
            set { _medpersonnelname = value; }
        }

        public string Patient_Name
        {
            get { return _patientname; }
            set { _patientname = value; }
        }

        public string Patient_Condition
        {
            get { return _patientcondition; }
            set { _patientcondition = value; }
        }

        public string Hospital_Clinic_Location
        {
            get { return _hospitalcliniclocation; }
            set { _hospitalcliniclocation = value; }
        }

        public string Epa_Reg_No
        {
            get { return _eparegno; }
            set { _eparegno = value; }
        }

        public string Status_Of_Release
        {
            get { return _statusofrelease; }
            set { _statusofrelease = value; }
        }

        public string Dispersion_Of_Msds_Information
        {
            get { return _dispersionofmsdsinfo; }
            set { _dispersionofmsdsinfo = value; }
        }

        public string Reviewed_By
        {
            get { return _reviewedby; }
            set { _reviewedby = value; }
        }

        public string Reviewed_Date
        {
            get { return _revieweddate; }
            set { _revieweddate = value; }
        }

        public string Sent_Date
        {
            get { return _sentdate; }
            set { _sentdate = value; }
        }

        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public string Date_Changed
        {
            get { return _datechanged; }
            set { _datechanged = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Incident_Zip_Code
        {
            get { return _incidentzipcode; }
            set { _incidentzipcode = value; }
        }

        public string Report_Type
        {
            get { return _reporttype; }
            set { _reporttype = value; }
        }

        public string Callers_Phone_Ext
        {
            get { return _callersphoneext; }
            set { _callersphoneext = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public GeneralIncidentReportData()
        {
            _incidentid = "";
            _ersoperator = "";
            _date = "";
            _time = "";
            _callersname = "";
            _callersphone = "";
            _callersaffiliation = "";
            _callersfaxoremail = "";
            _incidentstreet = "";
            _incidentcity = "";
            _incidentstate = "";
            _incidentcountry = "";
            _incidentdate = "";
            _incidenttime = "";
            _incidenttimezone = "";
            _materialname = "";
            _productnumber = "";
            _quantityspilled = "";
            _cleanupcrewreqs = "";
            _agenciesonsite = "";
            _accidentordeliberate = "";
            _incidentdetails = "";
            _involvefire = "";
            _wheredidyougetournumber = "";
            _subscribersname = "";
            _subscribersmis = "";
            _spillorexposure = "";
            _typeofexposure = "";
            _numofcasualties = "";
            _numofinjuries = "";
            _medpersonnelname = "";
            _patientname = "";
            _patientcondition = "";
            _hospitalcliniclocation = "";
            _eparegno = "";
            _statusofrelease = "";
            _dispersionofmsdsinfo = "";
            _reviewedby = "";
            _revieweddate = "";
            _sentdate = "";
            _comments = "";
            _datechanged = "N/A";
            _username = "N/A";
            _incidentzipcode = "";
            _reporttype = "";
            _callersphoneext = "";
        }

        public GeneralIncidentReportData(string constring, string id)
        {
            this.Incident_ID = id;
            SearchGeneralIncidentReportDataByID(constring);
        }

        #endregion
        #region Search Methods

        public void SearchGeneralIncidentReportDataByID(string constring)
        {
            string strsql = "SELECT * FROM generalincidentreportdata WHERE IncidentId=@incidentid";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@incidentid", this.Incident_ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.Incident_ID = rdr["IncidentId"].ToString();
                        this.Ers_Operator = rdr["ErsOperator"].ToString();
                        this.Date = rdr["Date"].ToString();
                        this.Time = rdr["Time"].ToString();
                        this.Callers_Name = rdr["CallersName"].ToString();
                        this.Callers_Phone = rdr["CallersPhone"].ToString();
                        this.Callers_Affiliation = rdr["CallersAffiliation"].ToString();
                        this.Callers_Fax_Or_Email = rdr["CallersFaxOrEmail"].ToString();
                        this.Incident_Street = rdr["IncidentStreet"].ToString();
                        this.Incident_City = rdr["IncidentCity"].ToString();
                        this.Incident_State = rdr["IncidentState"].ToString();
                        this.Incident_Country = rdr["IncidentCountry"].ToString();
                        this.Incident_Date = rdr["IncidentDate"].ToString();
                        this.Incident_Time = rdr["IncidentTime"].ToString();
                        this.Incident_Time_Zone = rdr["IncidentTimeZone"].ToString();
                        this.Material_Name = rdr["MaterialName"].ToString();
                        this.Product_Number = rdr["ProductNumber"].ToString();
                        this.Quantity_Spilled = rdr["QuantitySpilled"].ToString();
                        this.Cleanup_Crew_Requirements = rdr["CleanUpCrewReqs"].ToString();
                        this.Agencies_On_Site = rdr["AgenciesOnSite"].ToString();
                        this.Accident_Or_Deliberate = rdr["AccidentOrDeliberate"].ToString();
                        this.Incident_Details = rdr["IncidentDetails"].ToString();
                        this.Involve_Fire = rdr["InvolveFire"].ToString();
                        this.Where_Did_You_Get_Our_Number = rdr["WhereDidYouGetOurNumber"].ToString();
                        this.Subscribers_Name = rdr["SubscribersName"].ToString();
                        this.Subscribers_MIS = rdr["SubscriberMIS"].ToString();
                        this.Spill_Or_Exposure = rdr["SpillOrExposure"].ToString();
                        this.Type_Of_Exposure = rdr["TypeOfExposure"].ToString();
                        this.Num_Of_Casualties = rdr["NumOfCasualties"].ToString();
                        this.Num_Of_Injuries = rdr["NumOfInjuries"].ToString();
                        this.Med_Personnel_Name = rdr["MedPersonnelName"].ToString();
                        this.Patient_Name = rdr["PatientName"].ToString();
                        this.Patient_Condition = rdr["PatientCondition"].ToString();
                        this.Hospital_Clinic_Location = rdr["HospitalClinicLocation"].ToString();
                        this.Epa_Reg_No = rdr["EpaRegNo"].ToString();
                        this.Status_Of_Release = rdr["StatusOfRelease"].ToString();
                        this.Dispersion_Of_Msds_Information = rdr["DispersionOfMsdsInfo"].ToString();
                        this.Reviewed_By = rdr["ReviewedBy"].ToString();
                        this.Reviewed_Date = rdr["ReviewedDate"].ToString();
                        this.Sent_Date = rdr["SentDate"].ToString();
                        this.Comments = rdr["Comments"].ToString();
                        this.Date_Changed = rdr["DateChanged"].ToString();
                        this.Username = rdr["Username"].ToString();
                        this.Incident_Zip_Code = rdr["IncidentZipCode"].ToString();
                        this.Report_Type = rdr["ReportType"].ToString();
                        this.Callers_Phone_Ext = rdr["CallersPhoneExt"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
