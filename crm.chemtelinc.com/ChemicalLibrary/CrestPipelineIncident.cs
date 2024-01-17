using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class CrestPipelineIncident
    {
        #region Private Fields

        private int _id, _numofinjuries;
        private string _county, _state, _distancefromtown, _distancefromlandmark, _intersectionormilemarker, _observing, _seeinghearingsmelling, _roworwellpad, _tanks, _landowner, _callername, _callerphone;
        private string _notify911, _anyoneinjured, _immediatedanger, _temp, _windspeed, _winddirection, _relationtoincident, _weatherconditions, _safelywarn, _name1, _name2, _name3, _contactnumber1;
        private string _contactnumber2, _contactnumber3, _location1, _location2, _location3, _leasewellname, _blackwhitesmoke, _flames, _hissing, _liquid, _oilysheen, _otherpipelinemarkers;
        private string _rotteneggodor, _vaporormist, _directions, _city, _time, _timezone, _reporttakername, _reporttakeremail, _description, _calleremail, _callertitle, _calleraffiliation;
        private string _name4, _name5, _contactnumber4, _contactnumber5, _location4, _location5, _calldate, _calltime, _ersoperator, _initials, _notificationdate, _notificationtime, _Drill;
        private DateTime _date;

        #endregion
        #region Public Properties
        #region Ints

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Number_Of_Injuries
        {
            get { return _numofinjuries; }
            set { _numofinjuries = value; }
        }

        #endregion
        #region Strings

        public string County
        {
            get { return _county; }
            set { _county = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string Distance_From_Town
        {
            get { return _distancefromtown; }
            set { _distancefromtown = value; }
        }

        public string Distance_From_Landmark
        {
            get { return _distancefromlandmark; }
            set { _distancefromlandmark = value; }
        }

        public string Intersection_Or_Milemarker
        {
            get { return _intersectionormilemarker; }
            set { _intersectionormilemarker = value; }
        }

        public string Observing
        {
            get { return _observing; }
            set { _observing = value; }
        }

        public string Seeing_Hearing_Smelling
        {
            get { return _seeinghearingsmelling; }
            set { _seeinghearingsmelling = value; }
        }

        public string ROW_OR_Well_Pad
        {
            get { return _roworwellpad; }
            set { _roworwellpad = value; }
        }

        public string Tanks
        {
            get { return _tanks; }
            set { _tanks = value; }
        }

        public string Landowner
        {
            get { return _landowner; }
            set { _landowner = value; }
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

        public string Caller_Email
        {
            get { return _calleremail; }
            set { _calleremail = value; }
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

        public string Notify_911
        {
            get { return _notify911; }
            set { _notify911 = value; }
        }

        public string Anyone_Injured
        {
            get { return _anyoneinjured; }
            set { _anyoneinjured = value; }
        }

        public string Immediate_Danger
        {
            get { return _immediatedanger; }

            set { _immediatedanger = value; }
        }

        public string Temperature
        {
            get { return _temp; }
            set { _temp = value; }
        }

        public string Wind_Speed
        {
            get { return _windspeed; }
            set { _windspeed = value; }
        }

        public string Wind_Direction
        {
            get { return _winddirection; }
            set { _winddirection = value; }
        }

        public string Weather_Conditions
        {
            get { return _weatherconditions; }
            set { _weatherconditions = value; }
        }

        public string Relation_ToIncident
        {
            get { return _relationtoincident; }
            set { _relationtoincident = value; }
        }

        public string Safely_Warn
        {
            get { return _safelywarn; }
            set { _safelywarn = value; }
        }

        public string Name_1
        {
            get { return _name1; }
            set { _name1 = value; }
        }

        public string Name_2
        {
            get { return _name2; }
            set { _name2 = value; }
        }

        public string Name_3
        {
            get { return _name3; }
            set { _name3 = value; }
        }

        public string Name_4
        {
            get { return _name4; }
            set { _name4 = value; }
        }

        public string Name_5
        {
            get { return _name5; }
            set { _name5 = value; }
        }

        public string Contact_Number_1
        {
            get { return _contactnumber1; }
            set { _contactnumber1 = value; }
        }

        public string Contact_Number_2
        {
            get { return _contactnumber2; }
            set { _contactnumber2 = value; }
        }

        public string Contact_Number_3
        {
            get { return _contactnumber3; }
            set { _contactnumber3 = value; }
        }

        public string Contact_Number_4
        {
            get { return _contactnumber4; }
            set { _contactnumber4 = value; }
        }

        public string Contact_Number_5
        {
            get { return _contactnumber5; }
            set { _contactnumber5 = value; }
        }

        public string Location_1
        {
            get { return _location1; }
            set { _location1 = value; }
        }

        public string Location_2
        {
            get { return _location2; }
            set { _location2 = value; }
        }

        public string Location_3
        {
            get { return _location3; }
            set { _location3 = value; }
        }

        public string Location_4
        {
            get { return _location4; }
            set { _location4 = value; }
        }

        public string Location_5
        {
            get { return _location5; }
            set { _location5 = value; }
        }

        public string Lease_Well_Name
        {
            get { return _leasewellname; }
            set { _leasewellname = value; }
        }

        public string Black_Or_White_Smoke
        {
            get { return _blackwhitesmoke; }
            set { _blackwhitesmoke = value; }
        }

        public string Flames
        {
            get { return _flames; }
            set { _flames = value; }
        }

        public string Hissing
        {
            get { return _hissing; }
            set { _hissing = value; }
        }

        public string Liquid
        {
            get { return _liquid; }
            set { _liquid = value; }
        }

        public string Oily_Sheen
        {
            get { return _oilysheen; }
            set { _oilysheen = value; }
        }

        public string Other_Pipeline_Markers
        {
            get { return _otherpipelinemarkers; }
            set { _otherpipelinemarkers = value; }
        }

        public string Rotten_Egg_Odor
        {
            get { return _rotteneggodor; }
            set { _rotteneggodor = value; }
        }

        public string Vapor_Or_Mist
        {
            get { return _vaporormist; }
            set { _vaporormist = value; }
        }

        public string Directins
        {
            get { return _directions; }
            set { _directions = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public string Time_Zone
        {
            get { return _timezone; }
            set { _timezone = value; }
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

        public string Description
        {
            get { return _description; }
            set { _description = value; }
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

        public string ERS_Operator
        {
            get { return _ersoperator; }
            set { _ersoperator = value; }
        }

        public string Initials
        {
            get { return _initials; }
            set { _initials = value; }
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
        public string Drill
        {
            get { return _Drill; }
            set { _Drill = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public CrestPipelineIncident()
        {
            _id = 0;
            _numofinjuries = 0;
            _county = "";
            _state = "";
            _distancefromtown = "";
            _distancefromlandmark = "";
            _intersectionormilemarker = "";
            _observing = "";
            _seeinghearingsmelling = "";
            _roworwellpad = "";
            _tanks = "";
            _landowner = "";
            _callername = "";
            _callerphone = "";
            _notify911 = "";
            _anyoneinjured = "";
            _immediatedanger = "";
            _temp = "";
            _windspeed = "";
            _winddirection = "";
            _weatherconditions = "";
            _relationtoincident = "";
            _safelywarn = "";
            _name1 = "";
            _name2 = "";
            _name3 = "";
            _contactnumber1 = "";
            _contactnumber2 = "";
            _contactnumber3 = "";
            _location1 = "";
            _location2 = "";
            _location3 = "";
            _leasewellname = "";
            _blackwhitesmoke = "";
            _flames = "";
            _hissing = "";
            _liquid = "";
            _oilysheen = "";
            _otherpipelinemarkers = "";
            _rotteneggodor = "";
            _vaporormist = "";
            _directions = "";
            _city = "";
            _date = DateTime.MinValue;
            _time = "";
            _timezone = "";
            _reporttakername = "";
            _reporttakeremail = "";
            _description = "";
            _calleremail = "";
            _calleraffiliation = "";
            _callertitle = "";
            _name4 = "";
            _name5 = "";
            _contactnumber4 = "";
            _contactnumber5 = "";
            _location4 = "";
            _location5 = "";
            _calldate = "";
            _calltime = "";
            _ersoperator = "";
            _initials = "";
            _notificationdate = "";
            _notificationtime = "";
            _Drill = "";
        }

        public CrestPipelineIncident(string constring, int id)
        {
            this.ID = id;
            SearchByID(constring);
        }

        #endregion
        #region Search Methods

        private void SearchByID(string constring)
        {
            string strsql = "SELECT * FROM crestpiplineincidents WHERE id=@id";
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
                        this.Number_Of_Injuries = int.Parse(rdr["numofinjuries"].ToString());
                        this.County = rdr["county"].ToString();
                        this.State = rdr["state"].ToString();
                        this.Distance_From_Town = rdr["distancefromtown"].ToString();
                        this.Distance_From_Landmark = rdr["distancefromlandmark"].ToString();
                        this.Intersection_Or_Milemarker = rdr["intersectionormilemarker"].ToString();
                        this.Observing = rdr["observing"].ToString();
                        this.Seeing_Hearing_Smelling = rdr["seeinghearingsmelling"].ToString();
                        this.ROW_OR_Well_Pad = rdr["roworwellpad"].ToString();
                        this.Tanks = rdr["tanks"].ToString();
                        this.Landowner = rdr["landowner"].ToString();
                        this.Caller_Name = rdr["callername"].ToString();
                        this.Caller_Phone = rdr["callerphone"].ToString();
                        this.Notify_911 = rdr["notify911"].ToString();
                        this.Anyone_Injured = rdr["anyoneinjured"].ToString();
                        this.Immediate_Danger = rdr["immediatedanger"].ToString();
                        this.Temperature = rdr["temp"].ToString();
                        this.Wind_Speed = rdr["windspeed"].ToString();
                        this.Wind_Direction = rdr["winddirection"].ToString();
                        this.Weather_Conditions = rdr["weatherconditions"].ToString();
                        this.Relation_ToIncident = rdr["relationtoincident"].ToString();
                        this.Safely_Warn = rdr["safelywarn"].ToString();
                        this.Name_1 = rdr["name1"].ToString();
                        this.Name_2 = rdr["name2"].ToString();
                        this.Name_3 = rdr["name3"].ToString();
                        this.Contact_Number_1 = rdr["contactnumber1"].ToString();
                        this.Contact_Number_2 = rdr["contactnumber2"].ToString();
                        this.Contact_Number_3 = rdr["contactnumber3"].ToString();
                        this.Location_1 = rdr["location1"].ToString();
                        this.Location_2 = rdr["location2"].ToString();
                        this.Location_3 = rdr["location3"].ToString();
                        this.Lease_Well_Name = rdr["leasewellname"].ToString();
                        this.Black_Or_White_Smoke = rdr["blackorwhitesmoke"].ToString();
                        this.Flames = rdr["flames"].ToString();
                        this.Hissing = rdr["hissing"].ToString();
                        this.Liquid = rdr["liquid"].ToString();
                        this.Oily_Sheen = rdr["oilysheen"].ToString();
                        this.Other_Pipeline_Markers = rdr["otherpipelinemarkers"].ToString();
                        this.Rotten_Egg_Odor = rdr["rotteneggodor"].ToString();
                        this.Vapor_Or_Mist = rdr["vaporormist"].ToString();
                        this.Directins = rdr["directions"].ToString();
                        this.City = rdr["city"].ToString();
                        this.Date = DateTime.Parse(rdr["date"].ToString());
                        this.Time = rdr["time"].ToString();
                        this.Time_Zone = rdr["timezone"].ToString();
                        this.Report_Taker_Name=rdr["reporttakername"].ToString();
                        this.Report_Taker_Email=rdr["reporttakeremail"].ToString();
                        this.Description = rdr["description"].ToString();
                        this.Caller_Email = rdr["calleremail"].ToString();
                        this.Caller_Affiliation=rdr["calleraffiliation"].ToString();
                        this.Caller_Title = rdr["callertitle"].ToString();
                        this.Name_4 = rdr["name4"].ToString();
                        this.Name_5 = rdr["name5"].ToString();
                        this.Contact_Number_4 = rdr["contactnumber4"].ToString();
                        this.Contact_Number_5 = rdr["contactnumber5"].ToString();
                        this.Location_4 = rdr["location4"].ToString();
                        this.Location_5 = rdr["location5"].ToString();
                        this.Call_Date = rdr["calldate"].ToString();
                        this.Call_Time = rdr["calltime"].ToString();
                        this.ERS_Operator = rdr["ersoperator"].ToString();
                        this.Initials = rdr["initials"].ToString();
                        this.NotificationDate = rdr["NotificationDate"].ToString();
                        this.NotificationTime = rdr["NotificationTime"].ToString();
                        this.Drill = rdr["Drill"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
