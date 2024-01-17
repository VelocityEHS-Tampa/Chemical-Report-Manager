using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemicalLibrary
{
    public class TCEQ
    {
        public int ID_TCEQ { get; set; }
        public string ERS_Operator { get; set; }
        public DateTime Report_Date { get; set; }
        public string Report_Time { get; set; }
        public DateTime Incident_Date { get; set; }
        public string Incident_Time { get; set; }
        public string Report_By { get; set; }
        public string Contact_Number { get; set; }
        public string Contact_Number_2 { get; set; }
        public string Emergency { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string County { get; set; }
        public string Media_Affected { get; set; }
        public string Receiving_Water { get; set; }
        public string Amount_Water { get; set; }
        public string Unit_Water { get; set; }
        public string PR_Company { get; set; }
        public string PR_Street { get; set; }
        public string PR_City { get; set; }
        public string PR_State { get; set; }
        public string PR_ZipCode { get; set; }
        public string PR_Contact { get; set; }
        public string PR_Phone { get; set; }
        public string Material1 { get; set; }
        public string Material2 { get; set; }
        public string Material3 { get; set; }
        public string Material4 { get; set; }
        public string Material5 { get; set; }
        public string CAS1 { get; set; }
        public string CAS2 { get; set; }
        public string CAS3 { get; set; }
        public string CAS4 { get; set; }
        public string CAS5 { get; set; }
        public string Amount1 { get; set; }
        public string Amount2 { get; set; }
        public string Amount3 { get; set; }
        public string Amount4 { get; set; }
        public string Amount5 { get; set; }
        public string Unit1 { get; set; }
        public string Unit2 { get; set; }
        public string Unit3 { get; set; }
        public string Unit4 { get; set; }
        public string Unit5 { get; set; }
        public string ResponderName { get; set; }
        public string NotificationTime { get; set; }

        public TCEQ()
        {
            this.ERS_Operator = "";
            this.Report_Date = new DateTime();
            this.Report_Time = "00:00";
            this.Incident_Date = new DateTime();
            this.Incident_Time = "00:00";
            this.Report_By = "ANONYMOUS";
            this.Contact_Number = "(000) 000-0000";
            this.Contact_Number_2 = "(000) 000-0000";
            this.Emergency = "NO";
            this.Description = "";
            this.Location = "";
            this.County = "";
            this.Media_Affected = "NA";
            this.Receiving_Water = "NA";
            this.Amount_Water = "0.00";
            this.Unit_Water = "NA";
            this.PR_Company = "UNKNOWN";
            this.PR_Street = "UNKNOWN";
            this.PR_City = "UNKNOWN";
            this.PR_State = "NA";
            this.PR_ZipCode = "00000-0000";
            this.PR_Contact = "UNKNOWN";
            this.PR_Phone = "(000) 000-0000";
            this.Material1 = "";
            this.Material2 = "";
            this.Material3 = "";
            this.Material4 = "";
            this.Material5 = "";
            this.CAS1 = "NA";
            this.CAS2 = "NA";
            this.CAS3 = "NA";
            this.CAS4 = "NA";
            this.CAS5 = "NA";
            this.Amount1 = "0.00";
            this.Amount2 = "0.00";
            this.Amount3 = "0.00";
            this.Amount4 = "0.00";
            this.Amount5 = "0.00";
            this.Unit1 = "NA";
            this.Unit2 = "NA";
            this.Unit3 = "NA";
            this.Unit4 = "NA";
            this.Unit5 = "NA";
            this.ResponderName = "";
            this.NotificationTime = "";
        }
    }
}
