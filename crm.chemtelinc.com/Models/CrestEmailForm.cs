using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crm.chemtelinc.com.Models
{
    public class CrestEmailForm
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string ESREmail { get; set; }
        public string CallerEmail { get; set; }
        public string Location { get; set; }
        public string Region { get; set; }
        public string State { get; set; }
        public int ID { get; set; }
        public string FilePath { get; set; }
        public string Drill { get; set; }
        public string Transportation { get; set; }
        public string EmpOrContract { get; set; }
        public string PC_CWLocOrTransport { get; set; }
        public string IncidentType { get; set; }
        public string FacilityOrConstruction { get; set; }
        public string HighProfile { get; set; }
        public string Pipeline { get; set; }
    }
}