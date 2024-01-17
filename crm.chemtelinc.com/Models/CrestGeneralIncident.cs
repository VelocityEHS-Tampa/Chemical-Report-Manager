using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class CrestGeneralIncident
    {
        #region Private Fields

        private int _id;
        private string _callername, _callertitle, _calleraffiliation, _callerphonenumber, _incidentlocation, _incidentlatitude, _incidentlongitude, _incidentoccuron, _incidentnature, _incidentdescription;
        private string _involvedname1, _involvedcell1, _involvedinjury1, _involvedname2, _involvedcell2, _involvedinjury2, _involvedname3, _involvedcell3, _involvedinjury3, _weatherconditions, _impactedareas;
        private string _impactedbodyofwater, _reporttakername, _reporttakeremail, _ersname1, _erscontactnumber1, _erslocation1, _ersname2, _erscontactnumber2, _erslocation2, _ersname3, _erscontactnumber3, _erslocation3;
        private string _dispatcheroremployee, _contractororemployee, _notify911, _immediatesupport, _transporttohospital, _emergencyresponders, _fatalities, _mediaonscene;
        private string _incidentprivaterow, _incidenttriballand, _incidentblmland, _incidentstateland, _incidentaddress, _incidentcity, _incidentstate, _incidentcounty, _incidentintersection, _incidentfacilityname;
        private string _fireorexplosion, _pipelinestrike, _injury, _illnessorexposure, _landowner, _vehicleaccident, _spillorrelease, _theft, _agencyinspectionofvisit, _propertydamage;
        private string _potentialhazardornearmiss, _landownercomplaint, _impactstowater, _incidenttime, _incidenttimezone, _calleremail, _calldate, _calltime, _other, _ersoperator;
        private string _equipmentorpeople, _numinjuries1, _numinjuries2, _numinjuries3, _none, _unknown, _tractortrailer, _equipment, _dispatcheremployee, _initials, _county, _drill;
        private string _Incident_Contractor_Or_Employee, _IndividualSafety, _WeaponReported, _WeaponType, _wpviolence , _FacilityOrProject, _RegionOrFacility, _ContractorName, _FacilityOrProjectSelection;
        private string _OccuredOnPipeline, _notificationdate, _notificationtime, _PC_CWLocOrTransport, _SusAct, _SpillOrReleaseIntoAtmo, _MaterialSpilled, _WaterbodiesImpacted, _ContainedOnSite, _SpillContainedSecondary, _ControlDevices;
        private string _primaryworklocation;
        private DateTime _incidentdate;
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

        public string Caller_Title
        {
            get { return _callertitle; }
            set { _callertitle = value; }
        }

        public string Caller_Affiliation
        {
            get { return _calleraffiliation; }
            set { _calleraffiliation = value; }
        }

        public string Caller_Phone_Number
        {
            get { return _callerphonenumber; }
            set { _callerphonenumber = value; }
        }

        public DateTime Incident_Date
        {
            get { return _incidentdate; }
            set { _incidentdate = value; }
        }

        public string Incident_Location
        {
            get { return _incidentlocation; }
            set { _incidentlocation = value; }
        }

        public string Incident_Latitude
        {
            get { return _incidentlatitude; }
            set { _incidentlatitude = value; }
        }

        public string Incident_Longitude
        {
            get { return _incidentlongitude; }
            set { _incidentlongitude = value; }
        }

        public string Incident_Occured_On
        {
            get { return _incidentoccuron; }
            set { _incidentoccuron = value; }

        }
        public string Incident_Nature
        {
            get { return _incidentnature; }
            set { _incidentnature = value; }
        }

        public string Incident_Description
        {
            get { return _incidentdescription; }
            set { _incidentdescription = value; }
        }

        public string Involved_Name_1
        {
            get { return _involvedname1; }
            set { _involvedname1 = value; }
        }

        public string Involved_Name_2
        {
            get { return _involvedname2; }
            set { _involvedname2 = value; }
        }

        public string Involved_Name_3
        {
            get { return _involvedname3; }
            set { _involvedname3 = value; }
        }

        public string Involed_Cell_1
        {
            get { return _involvedcell1; }
            set { _involvedcell1 = value; }
        }

        public string Involved_Cell_2
        {
            get { return _involvedcell2; }
            set { _involvedcell2 = value; }
        }

        public string Involved_Cell_3
        {
            get { return _involvedcell3; }
            set { _involvedcell3 = value; }
        }

        public string Involved_Injury_1
        {
            get { return _involvedinjury1; }
            set { _involvedinjury1 = value; }
        }

        public string Involved_Injury_2
        {
            get { return _involvedinjury2; }
            set { _involvedinjury2 = value; }
        }

        public string Involved_Injury_3
        {
            get { return _involvedinjury3; }
            set { _involvedinjury3 = value; }
        }

        public string Weather_Conditions
        {
            get { return _weatherconditions; }
            set { _weatherconditions = value; }
        }

        public string Impacted_Areas
        {
            get { return _impactedareas; }
            set { _impactedareas = value; }
        }
       
        public string Impacted_Body_Of_Water
        {
            get { return _impactedbodyofwater; }
            set { _impactedbodyofwater = value; }
        }

        public string Report_Taker_Name
        {
            get { return _reporttakername; }
            set { _reporttakername = value; }
        }

        public string Report_Taker_Email
        {
            get { return _reporttakeremail; }
            set { _reporttakeremail = value; }
        }

        public string ERS_Name_1
        {
            get { return _ersname1; }
            set { _ersname1 = value; }
        }

        public string ERS_Name_2
        {
            get { return _ersname2; }
            set { _ersname2 = value; }
        }

        public string ERS_Name_3
        {
            get { return _ersname3; }
            set { _ersname3 = value; }
        }

        public string ERS_Contact_Number_1
        {
            get { return _erscontactnumber1; }
            set { _erscontactnumber1 = value; }
        }

        public string ERS_Contact_Number_2
        {
            get { return _erscontactnumber2; }
            set { _erscontactnumber2 = value; }
        }

        public string ERS_Contact_Number_3
        {
            get { return _erscontactnumber3; }
            set { _erscontactnumber3 = value; }
        }

        public string ERS_Location_1
        {
            get { return _erslocation1; }
            set { _erslocation1 = value; }
        }

        public string ERS_Location_2
        {
            get { return _erslocation2; }
            set { _erslocation2 = value; }
        }

        public string ERS_Location_3
        {
            get { return _erslocation3; }
            set { _erslocation3 = value; }
        }

        public string Dispatcher_Or_Employee
        {
            get { return _dispatcheroremployee; }
            set { _dispatcheroremployee = value; }
        }

        public string Contractor_Or_Employee
        {
            get { return _contractororemployee; }
            set { _contractororemployee = value; }
        }

        public string Notify_911
        {
            get { return _notify911; }
            set { _notify911 = value; }
        }

        public string Immediate_Support
        {
            get { return _immediatesupport; }
            set { _immediatesupport = value; }
        }

        public string Transport_ToHospital
        {
            get { return _transporttohospital; }
            set { _transporttohospital = value; }
        }

        public string Emegency_Responders
        {
            get { return _emergencyresponders; }
            set { _emergencyresponders = value; }
        }

        public string Fatalities
        {
            get { return _fatalities; }
            set { _fatalities = value; }
        }

        public string Media_On_Scene
        {
            get { return _mediaonscene; }
            set { _mediaonscene = value; }
        }

        public string Incident_Private_ROW
        {
            get { return _incidentprivaterow; }
            set { _incidentprivaterow = value; }
        }

        public string Incident_Tribal_Land
        {
            get { return _incidenttriballand; }
            set { _incidenttriballand = value; }
        }

        public string Incident_BLM_Land
        {
            get { return _incidentblmland; }
            set { _incidentblmland = value; }
        }

        public string Incident_State_Land
        {
            get { return _incidentstateland; }
            set { _incidentstateland = value; }
        }

        public string Incident_Address
        {
            get { return _incidentaddress; }
            set { _incidentaddress = value; }
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

        public string Incident_Intersection
        {
            get { return _incidentintersection; }
            set { _incidentintersection = value; }
        }

        public string Incident_Facility_Name
        {
            get { return _incidentfacilityname; }
            set { _incidentfacilityname = value; }
        }

        public string Fire_Or_Explosion
        {
            get { return _fireorexplosion; }
            set { _fireorexplosion = value; }
        }

        public string Pipeline_Strike
        {
            get { return _pipelinestrike; }
            set { _pipelinestrike = value; }
        }

        public string Injury
        {
            get { return _injury; }
            set { _injury = value; }
        }

        public string Illness_Or_Exposure
        {
            get { return _illnessorexposure; }
            set { _illnessorexposure = value; }
        }

        public string Vehicle_Accident
        {
            get { return _vehicleaccident; }
            set { _vehicleaccident = value; }
        }

        public string Spill_Or_Release
        {
            get { return _spillorrelease; }
            set { _spillorrelease = value; }
        }

        public string Theft
        {
            get { return _theft; }
            set { _theft = value; }
        }

        public string Agency_Ispection_Of_Visit
        {
            get { return _agencyinspectionofvisit; }
            set { _agencyinspectionofvisit = value; }
        }

        public string Property_Damage
        {
            get { return _propertydamage; }
            set { _propertydamage = value; }
        }

        public string Potential_hazard_Or_Near_Miss
        {
            get { return _potentialhazardornearmiss; }
            set { _potentialhazardornearmiss = value; }
        }

        public string Landowner_Complaint
        {
            get { return _landownercomplaint; }
            set { _landownercomplaint = value; }
        }

        public string Impacts_To_Water
        {
            get { return _impactstowater; }
            set { _impactstowater = value; }
        }

        public string Landowner
        {
            get { return _landowner; }
            set { _landowner = value; }
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

        public string Caller_Email
        {
            get { return _calleremail; }
            set { _calleremail = value; }
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

        public string Other
        {
            get { return _other; }
            set { _other = value; }
        }

        public string ERS_Operator
        {
            get { return _ersoperator; }
            set { _ersoperator = value; }
        }

        public string Equipment_Or_People
        {
            get { return _equipmentorpeople; }
            set { _equipmentorpeople = value; }
        }

        public string Number_Of_Injuries_1
        {
            get { return _numinjuries1; }
            set { _numinjuries1 = value; }
        }

        public string Number_Of_Injuries_2
        {
            get { return _numinjuries2; }
            set { _numinjuries2 = value; }
        }

        public string Number_Of_Injuries_3
        {
            get { return _numinjuries3; }
            set { _numinjuries3 = value; }
        }

        public string None
        {
            get { return _none; }
            set { _none = value; }
        }

        public string Unknown
        {
            get { return _unknown; }
            set { _unknown = value; }
        }

        public string Tractor_Trailer
        {
            get { return _tractortrailer; }
            set { _tractortrailer = value; }
        }

        public string Equipment
        {
            get { return _equipment; }
            set { _equipment = value; }
        }

        public string Dispatcher_Employee
        {
            get { return _dispatcheremployee; }
            set { _dispatcheremployee = value; }
        }

        public string Initials
        {
            get { return _initials; }
            set { _initials = value; }
        }

        public string County
        {
            get { return _county; }
            set { _county = value; }
        }

        public string Drill
        {
            get { return _drill; }
            set { _drill = value; }
        }

        public string Incident_Contractor_Or_Employee
        {
            get { return _Incident_Contractor_Or_Employee; }
            set { _Incident_Contractor_Or_Employee = value; }
        }

        public string IndividualSafety
        {
            get { return _IndividualSafety; }
            set { _IndividualSafety = value; }
        }

        public string WeaponReported
        {
            get { return _WeaponReported; }
            set { _WeaponReported = value; }
        }
        public string WeaponType
        {
            get { return _WeaponType; }
            set { _WeaponType = value; }
        }

        public string wpviolence
        {
            get { return _wpviolence; }
            set { _wpviolence = value; }
        }

        public string FacilityOrProject { 
            get { return _FacilityOrProject; }
            set { _FacilityOrProject = value; }
        }
        public string RegionOrFacility {
            get { return _RegionOrFacility; }
            set { _RegionOrFacility = value; }
        }
        public string ContractorName
        {
            get { return _ContractorName; }
            set { _ContractorName = value; }
        }

        public string FacilityOrProjectSelection
        {
            get { return _FacilityOrProjectSelection; }
            set { _FacilityOrProjectSelection = value; }
        }
        public string OccuredOnPipeline
        {
            get { return _OccuredOnPipeline; }
            set { _OccuredOnPipeline = value; }
        }
        public string NotificationDate
        {
            get { return _notificationdate; }
            set { _notificationdate = value; }
        }
        public string NotificationTime
        {
            get { return _notificationtime; }
            set { _notificationtime = value; }
        }
        public string PC_CWLocOrTransport
        {
            get { return _PC_CWLocOrTransport; }
            set { _PC_CWLocOrTransport = value; }
        }
        public string SusAct
        {
            get { return _SusAct; }
            set { _SusAct = value; }
        }
        public string SpillOrReleaseIntoAtmo
        {
            get { return _SpillOrReleaseIntoAtmo; }
            set { _SpillOrReleaseIntoAtmo = value; }
        }
        public string MaterialSpilled
        {
            get { return _MaterialSpilled; }
            set { _MaterialSpilled = value; }
        }
        public string WaterbodiesImpacted
        {
            get { return _WaterbodiesImpacted; }
            set { _WaterbodiesImpacted = value; }
        }
        public string ContainedOnSite
        {
            get { return _ContainedOnSite; }
            set { _ContainedOnSite = value; }
        }
        public string SpillContainedSecondary
        {
            get { return _SpillContainedSecondary; }
            set { _SpillContainedSecondary = value; }
        }
        public string ControlDevices
        {
            get { return _ControlDevices; }
            set { _ControlDevices = value; }
        }
        public string PrimaryWorkLocation
        {
            get { return _primaryworklocation; }
            set { _primaryworklocation = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public CrestGeneralIncident()
        {
            _id = 0;
            _callername = "";
            _callertitle = "";
            _calleraffiliation = "";
            _callerphonenumber = "";
            _incidentdate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _incidentlocation = "";
            _incidentlatitude = "";
            _incidentlongitude = "";
            _incidentoccuron = "N/A";
            _incidentnature = "N/A";
            _incidentdescription = "";
            _involvedcell1 = "";
            _involvedcell2 = "";
            _involvedcell3 = "";
            _involvedinjury1 = "";
            _involvedinjury2 = "";
            _involvedinjury3 = "";
            _involvedname1 = "";
            _involvedname2 = "";
            _involvedname3 = "";
            _weatherconditions = "";
            _impactedareas = "";
            _impactedbodyofwater = "";
            _reporttakeremail = "N/A";
            _reporttakername = "N/A";
            _erscontactnumber1 = "";
            _erscontactnumber2 = "";
            _erscontactnumber3 = "";
            _erslocation1 = "";
            _erslocation2 = "";
            _erslocation3 = "";
            _ersname1 = "";
            _ersname2 = "";
            _ersname3 = "";
            _dispatcheroremployee = "N/A";
            _contractororemployee = "N/A";
            _notify911 = "";
            _immediatesupport = "";
            _transporttohospital = "";
            _emergencyresponders = "";
            _fatalities = "";
            _mediaonscene = "";
            _incidentprivaterow = "";
            _incidenttriballand = "";
            _incidentblmland = "";
            _incidentstateland = "";
            _incidentaddress = "";
            _incidentcity = "";
            _incidentstate = "";
            _incidentcounty = "";
            _incidentintersection = "";
            _incidentfacilityname = "N/A";
            _fireorexplosion = "";
            _pipelinestrike = "";
            _injury = "";
            _illnessorexposure = "";
            _vehicleaccident = "";
            _spillorrelease = "";
            _theft = "";
            _agencyinspectionofvisit = "";
            _propertydamage = "";
            _potentialhazardornearmiss = "";
            _landownercomplaint = "";
            _impactstowater = "";
            _landowner = "";
            _incidenttime = "";
            _incidenttimezone = "";
            _calleremail = "";
            _calldate = "";
            _calltime = "";
            _other = "";
            _ersoperator = "";
            _equipmentorpeople = "N/A";
            _numinjuries1 = "0";
            _numinjuries2 = "0";
            _numinjuries3 = "0";
            _none = "";
            _unknown = "";
            _tractortrailer = "";
            _equipment = "";
            _dispatcheremployee = "";
            _initials = "";
            _county = "";
            _Incident_Contractor_Or_Employee = "";
            _IndividualSafety = "";
            _WeaponReported = "";
            _WeaponType = "";
            _wpviolence = "";
            _FacilityOrProject = "";
            _RegionOrFacility = "";
            _ContractorName = "";
            _FacilityOrProjectSelection = "";
            _OccuredOnPipeline = "";
            _notificationdate = "";
            _notificationtime = "";
            _PC_CWLocOrTransport = "";
            _SusAct = "";
            _SpillOrReleaseIntoAtmo = "";
            _MaterialSpilled = "";
            _WaterbodiesImpacted = "";
            _ContainedOnSite = "";
            _SpillContainedSecondary = "";
            _ControlDevices = "";
            _primaryworklocation = "";
        }

        public CrestGeneralIncident(string constring, int id)
        {
            this.ID = id;
            SearchByID(constring);
        }

        #endregion
        #region Search Methods

        private void SearchByID(string constring)
        {
            string strsql = "SELECT * FROM crestgeneralincidents WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using(SqlCommand cmd=new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = int.Parse(rdr["id"].ToString());
                        this.Caller_Name = rdr["callername"].ToString();
                        this.Caller_Title = rdr["callertitle"].ToString();
                        this.Caller_Affiliation = rdr["calleraffiliation"].ToString();
                        this.Caller_Phone_Number = rdr["callerphonenumber"].ToString();
                        this.Incident_Date = DateTime.Parse(rdr["incidentdate"].ToString());
                        this.Incident_Location = rdr["incidentlocation"].ToString();
                        this.Incident_Latitude = rdr["incidentlatitude"].ToString();
                        this.Incident_Longitude = rdr["incidentlongitude"].ToString();
                        this.Incident_Occured_On = rdr["incidentoccuron"].ToString();
                        this.Incident_Nature = rdr["incidentnature"].ToString();
                        this.Incident_Description = rdr["incidentdescription"].ToString();
                        this.Involed_Cell_1 = rdr["involvedcell1"].ToString();
                        this.Involved_Cell_2 = rdr["involvedcell2"].ToString();
                        this.Involved_Cell_3 = rdr["involvedcell3"].ToString();
                        this.Involved_Injury_1 = rdr["involvedinjury1"].ToString();
                        this.Involved_Injury_2 = rdr["involvedinjury2"].ToString();
                        this.Involved_Injury_3 = rdr["involvedinjury3"].ToString();
                        this.Involved_Name_1 = rdr["involvedname1"].ToString();
                        this.Involved_Name_2 = rdr["involvedname2"].ToString();
                        this.Involved_Name_3 = rdr["involvedname3"].ToString();
                        this.Weather_Conditions = rdr["weatherconditions"].ToString();
                        this.Impacted_Areas = rdr["impactedareas"].ToString();
                        this.Impacted_Body_Of_Water = rdr["impactedbodyofwater"].ToString();
                        this.Report_Taker_Email = rdr["reporttakeremail"].ToString();
                        this.Report_Taker_Name = rdr["reporttakername"].ToString();
                        this.ERS_Contact_Number_1 = rdr["erscontactnumber1"].ToString();
                        this.ERS_Contact_Number_2 = rdr["erscontactnumber2"].ToString();
                        this.ERS_Contact_Number_3 = rdr["erscontactnumber3"].ToString();
                        this.ERS_Location_1 = rdr["erslocation1"].ToString();
                        this.ERS_Location_2 = rdr["erslocation2"].ToString();
                        this.ERS_Location_3 = rdr["erslocation3"].ToString();
                        this.ERS_Name_1 = rdr["ersname1"].ToString();
                        this.ERS_Name_2 = rdr["ersname2"].ToString();
                        this.ERS_Name_3 = rdr["ersname3"].ToString();
                        this.Dispatcher_Or_Employee = rdr["dispatcheroremployee"].ToString();
                        this.Contractor_Or_Employee = rdr["contractororemployee"].ToString();
                        this.Notify_911 = rdr["notify911"].ToString();
                        this.Immediate_Support = rdr["immediatesupport"].ToString();
                        this.Transport_ToHospital = rdr["transporttohospital"].ToString();
                        this.Emegency_Responders = rdr["emergencyresponders"].ToString();
                        this.Fatalities = rdr["fatalities"].ToString();
                        this.Media_On_Scene = rdr["mediaonscene"].ToString();
                        this.Incident_Private_ROW = rdr["incidentprivaterow"].ToString();
                        this.Incident_Tribal_Land = rdr["incidenttriballand"].ToString();
                        this.Incident_BLM_Land = rdr["incidentblmland"].ToString();
                        this.Incident_State_Land = rdr["incidentstateland"].ToString();
                        this.Incident_Address = rdr["incidentaddress"].ToString();
                        this.Incident_City = rdr["incidentcity"].ToString();
                        this.Incident_State = rdr["incidentstate"].ToString();
                        this.Incident_County = rdr["incidentcounty"].ToString();
                        this.Incident_Intersection = rdr["incidentintersection"].ToString();
                        this.Incident_Facility_Name = rdr["incidentfacilityname"].ToString();
                        this.Fire_Or_Explosion = rdr["fireorexplosion"].ToString();
                        this.Pipeline_Strike = rdr["pipelinestrike"].ToString();
                        this.Injury = rdr["injury"].ToString();
                        this.Illness_Or_Exposure = rdr["illnessorexposure"].ToString();
                        this.Vehicle_Accident = rdr["vehicleaccident"].ToString();
                        this.Spill_Or_Release = rdr["spillorrelease"].ToString();
                        this.Theft = rdr["theft"].ToString();
                        this.Agency_Ispection_Of_Visit = rdr["agencyinspectionofvisit"].ToString();
                        this.Property_Damage = rdr["propertydamage"].ToString();
                        this.Potential_hazard_Or_Near_Miss = rdr["potentialhazardornearmiss"].ToString();
                        this.Landowner_Complaint = rdr["landownercomplaint"].ToString();
                        this.Impacts_To_Water = rdr["impactstowater"].ToString();
                        this.Landowner = rdr["landowner"].ToString();
                        this.Incident_Time = rdr["incidenttime"].ToString();
                        this.Incident_Time_Zone = rdr["incidenttimezone"].ToString();
                        this.Caller_Email = rdr["calleremail"].ToString();
                        this.Call_Date = rdr["calldate"].ToString();
                        this.Call_Time = rdr["calltime"].ToString();
                        this.Other = rdr["other"].ToString();
                        this.ERS_Operator = rdr["ersoperator"].ToString();
                        this.Equipment_Or_People = rdr["equipmentorpeople"].ToString();
                        this.Number_Of_Injuries_1=rdr["numinjuries1"].ToString();
                        this.Number_Of_Injuries_2=rdr["numinjuries2"].ToString();
                        this.Number_Of_Injuries_3 = rdr["numinjuries3"].ToString();
                        this.None = rdr["none"].ToString();
                        this.Unknown = rdr["unknown"].ToString();
                        this.Tractor_Trailer = rdr["tractortrailer"].ToString();
                        this.Equipment = rdr["equipment"].ToString();
                        this.Dispatcher_Employee = rdr["dispatcheremployee"].ToString();
                        this.Initials = rdr["initials"].ToString();
                        this.County = rdr["county"].ToString();
                        this.Drill=rdr["drill"].ToString();
                        this.Incident_Contractor_Or_Employee =rdr["Incident_Contractor_Or_Employee"].ToString();
                        this.IndividualSafety = rdr["IndividualSafety"].ToString();
                        this.WeaponReported = rdr["WeaponReported"].ToString();
                        this.WeaponType = rdr["WeaponType"].ToString();
                        this.wpviolence = rdr["wpviolence"].ToString();
                        this.FacilityOrProject = rdr["FacilityOrProject"].ToString();
                        this.RegionOrFacility = rdr["RegionOrFacility"].ToString();
                        this.ContractorName = rdr["ContractorName"].ToString();
                        this.FacilityOrProjectSelection = rdr["FacilityOrProjectSelection"].ToString();
                        this.OccuredOnPipeline = rdr["OccuredOnPipeline"].ToString();
                        this.NotificationDate = rdr["NotificationDate"].ToString();
                        this.NotificationTime = rdr["NotificationTime"].ToString();
                        this.PC_CWLocOrTransport = rdr["PC_CWLocOrTransport"].ToString();
                        this.SusAct = rdr["SusAct"].ToString();
                        this.SpillOrReleaseIntoAtmo = rdr["SpillOrReleaseIntoAtmo"].ToString();
                        this.MaterialSpilled = rdr["MaterialSpilled"].ToString();
                        this.WaterbodiesImpacted = rdr["WaterbodiesImpacted"].ToString();
                        this.ContainedOnSite = rdr["ContainedOnSite"].ToString();
                        this.SpillContainedSecondary = rdr["SpillContainedSecondary"].ToString();
                        this.ControlDevices = rdr["ControlDevices"].ToString();
                        this.PrimaryWorkLocation = rdr["PrimaryWorkLocation"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
