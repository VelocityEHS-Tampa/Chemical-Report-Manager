using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemicalLibrary
{
    public class NorthwindLog
    {
        public int id { get; set; }
        public string ERSOperator { get; set; }
        public string CallerName { get; set; }
        public string CallerPhone { get; set; }
        public string Incident_Contractor_Or_Employee { get; set; }
        public string ContractedCompany { get; set; }
        public string CallDate { get; set; }
        public string CallTime { get; set; }
        public string IncidentDate { get; set; }
        public string IncidentTime { get; set; }
        public string IncidentTimeZone { get; set; }
        public string IncidentCity { get; set; }
        public string FacilityOrProject { get; set; }
        public string IncidentLocation { get; set; }
        public string IncidentNature { get; set; }
        public string WaterBodiesImpacted { get; set; }
        public string ImpactedArea { get; set; }
        public string IncidentDetails { get; set; }
        public string IndividualSafety { get; set; }
        public string Notify911 { get; set; }
        public string TransportToHospital { get; set; }
        public string MediaOnScene { get; set; }
        public string EMSOnScene { get; set; }
        public string HSERName { get; set; }
        public string HSERPhone { get; set; }
        public string InjuryExposureIllness { get; set; }
        public string ChemicalSpillRelease { get; set; }
        public string NotificationDate { get; set; }
        public string NotificationTime { get; set; }
        public string EmailSent { get; set; }

        //Pipeline Fields
        public string State { get; set; }
        public string Observing { get; set; }
        public string Date { get; set; }
        public string FacilityOrProjectSelection { get; set; }
        public string County { get; set; }
    }
}