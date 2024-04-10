using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemicalLibrary
{
    public class NorthwindPipeline
    {
        private int _id;
        private DateTime _calldate,  _incdate,  _notificationdate;
        private string _calltime, _amorpm, _inctime, _notificationtime, _timezone, _county, _state, _city, _closestlandmark, _gendirfrom, _distancefrom, _intersection, _observing,
            _smoke, _flames, _hissing, _liquid, _oilsheen, _markers, _eggodor, _mist, _roworwellpad, _tanks, _landowner, _callername, _callerphone, _leasewellname,
            _notify911, _anyoneinjured, _immediatedanger, _temp, _windspeed, _winddirection, _relationtoincident, _weatherconditions, _safelywarn, _reporttakername, _reporttakeremail,
            _notifiedname, _notifiednumber, _notifiedemail, _seeinghearingsmelling;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime Call_Date
        {
            get { return _calldate; }
            set { _calldate = value; }
        }
        public string Call_Time
        {
            get { return _calltime; }
            set { _calltime = value; }
        }
        public string AMorPM
        {
            get { return _amorpm; }
            set { _amorpm = value; }
        }
        public DateTime Incident_Date
        {
            get { return _incdate; }
            set { _incdate = value; }
        }
        public string Incident_Time
        {
            get { return _inctime; }
            set { _inctime = value; }
        }
        public string TimeZone
        {
            get { return _timezone; }
            set { _timezone = value; }
        }
        public string County
        {
            get { return _county; }
            set { _county = value; }
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
        public string ClosestLandmark
        {
            get { return _closestlandmark; }
            set { _closestlandmark = value; }
        }
        public string GeneralDirectionFrom
        {
            get { return _gendirfrom; }
            set { _gendirfrom = value; }
        }
        public string DistanceFrom
        {
            get { return _distancefrom; }
            set { _distancefrom = value; }
        }
        public string Intersection
        {
            get { return _intersection; }
            set { _intersection = value; }
        }
        public string Observing
        {
            get { return _observing; }
            set { _observing = value; }
        }
        public string Smoke
        {
            get { return _smoke; }
            set { _smoke = value; }
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
            get { return _oilsheen; }
            set { _oilsheen = value; }
        }
        public string Other_Pipeline_Markers
        {
            get { return _markers; }
            set { _markers = value; }
        }
        public string Rotten_Egg_Odor
        {
            get { return _eggodor; }
            set { _eggodor = value; }
        }
        public string Vapor_Or_Mist
        {
            get { return _mist; }
            set { _mist = value; }
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
        public string Lease_Well_Name
        {
            get { return _leasewellname; }
            set { _leasewellname = value; }
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
        public string NotifiedName
        {
            get { return _notifiedname; }
            set { _notifiedname = value; }
        }
        public string NotifiedNumber
        {
            get { return _notifiednumber; }
            set { _notifiednumber = value; }
        }
        public string NotifiedEmail
        {
            get { return _notifiedemail; }
            set { _notifiedemail = value; }
        }
        public string SeeingHearingSmelling
        {
            get { return _seeinghearingsmelling; }
            set { _seeinghearingsmelling = value; }
        }

        public NorthwindPipeline()
        {
            _id = 0;
            _calldate = DateTime.Now;
            _calltime = "";
            _amorpm = "";
            _incdate = DateTime.Now;
            _inctime = "";
            _timezone = "";
            _county = "";
            _state = "";
            _city = "";
            _closestlandmark = "N/A";
            _gendirfrom = "N/A";
            _distancefrom = "N/A";
            _intersection = "";
            _observing = "";
            _smoke = "";
            _flames = "";
            _hissing = "";
            _liquid = "";
            _oilsheen = "";
            _markers = "";
            _eggodor = "";
            _mist = "";
            _roworwellpad = "";
            _tanks = "";
            _landowner = "";
            _callername = "";
            _callerphone = "";
            _leasewellname = "N/A";
            _notify911 = "";
            _anyoneinjured = "";
            _immediatedanger = "";
            _temp = null;
            _windspeed = null;
            _winddirection = null;
            _relationtoincident = "";
            _weatherconditions = null;
            _safelywarn = "";
            _reporttakername = "";
            _reporttakeremail = "";
            _notificationdate = DateTime.Now;
            _notificationtime = "";
            _notifiedname = "";
            _notifiednumber = "";
            _notifiedemail = "";
            _seeinghearingsmelling = "";
        }

    }
}