using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crm.chemtelinc.com.Models
{
    public class CrestwoodLog
    {
        //General Incident Fields
        public int id { get; set; }
        public string CallerName { get; set; }
        public string IncidentDate { get; set; }
        public string IncidentNature { get; set; }
        public string Initials { get; set; }
        public string County { get; set; }
        public string Drill { get; set; }
        public string Incident_Contractor_Or_Employee { get; set; }
        public string IndividualSafety { get; set; }
        public string WeaponReported { get; set; }
        public string WeaponType { get; set; }
        public string wpviolence { get; set; }
        public string FacilityOrProject { get; set; }
        public string RegionOrFacility { get; set; }
        public string ContractorName { get; set; }
        public string FacilityOrProjectSelection { get; set; }
        public string OccuredOnPipeline { get; set; }
        public string NotificationDate { get; set; }
        public string NotificationTime { get; set; }
        public string PC_CWLocOrTransport { get; set; }
        public string SusAct { get; set; }
        public string SpillOrReleaseIntoAtmo { get; set; }
        public string MaterialSpilled { get; set; }
        public string WaterbodiesImpacted { get; set; }
        public string ContainedOnSite { get; set; }
        public string SpillContainedSecondary { get; set; }

        //Pipeline Fields
        public string State { get; set; }
        public string Observing { get; set; }
        public string Date { get; set; }

        //811 Fields
        public string Time { get; set; }
        public string ExcavationDate { get; set; }
        public string ExcavationTime { get; set; }
        public string NormalOrEmergency { get; set; }
        public string RequestTicketNo { get; set; }
        public string PersonCompanyName { get; set; }
        public string CallbackNumber { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public string WorkDate { get; set; }
        public string Street { get; set; }
        public string Intersection { get; set; }
        public string Nature { get; set; }
        public string Remarks { get; set; }
        public string FacilityName { get; set; }

        //Locked Gate Fields
        public string CallerNumber {get; set;}
        public string Name {get; set;}
        public string ContactNumber {get; set; }
        public string Location {get; set; }
    }
}