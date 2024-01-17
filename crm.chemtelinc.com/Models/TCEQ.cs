using System.Collections.Generic;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class TCEQ
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int ID_TCEQ { get; set; }
        public string ERS_Operator { get; set; }
        public string Report_Date { get; set; }
        public string Report_Time { get; set; }
        public string Incident_Date { get; set; }
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
            this.Report_Date = "";
            this.Report_Time = "00:00";
            this.Incident_Date = "";
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
        public TCEQ(string constring, int id)
        {
            this.ID_TCEQ = id;
            SearchTCEQbyID(constring);
        }
        public void SearchTCEQbyID(string constring)
        {
            string strsql = "SELECT * FROM tceqreport WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.ID_TCEQ);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ERS_Operator = rdr["Operator"].ToString();
                        this.Report_Date = rdr["ReportDate"].ToString();
                        this.Report_Time = rdr["ReportTime"].ToString();
                        this.Incident_Date = rdr["IncidentDate"].ToString();
                        this.Incident_Time = rdr["IncidentTime"].ToString();
                        this.Report_By = rdr["ReportedBy"].ToString();
                        this.Contact_Number = rdr["ContactNumber"].ToString();
                        this.Contact_Number_2 = rdr["ContactNumber2"].ToString();
                        this.Emergency = rdr["Emergency"].ToString();
                        this.Description = rdr["Description"].ToString();
                        this.Location = rdr["Location"].ToString();
                        this.County = rdr["County"].ToString();
                        this.Media_Affected = rdr["MediaAffected"].ToString();
                        this.Receiving_Water = rdr["ReceivingWater"].ToString();
                        this.Amount_Water = rdr["AmountWater"].ToString();
                        this.Unit_Water = rdr["UnitWater"].ToString();
                        this.PR_Company = rdr["PRCompany"].ToString();
                        this.PR_Street = rdr["PRStreet"].ToString();
                        this.PR_City = rdr["PRCity"].ToString();
                        this.PR_State = rdr["PRState"].ToString();
                        this.PR_ZipCode = rdr["PRZipCode"].ToString();
                        this.PR_Contact = rdr["PRContact"].ToString();
                        this.PR_Phone = rdr["PRPhone"].ToString();
                        this.Material1 = rdr["Material1"].ToString();
                        this.Material2 = rdr["Material2"].ToString();
                        this.Material3 = rdr["Material3"].ToString();
                        this.Material4 = rdr["Material4"].ToString();
                        this.Material5 = rdr["Material5"].ToString();
                        this.CAS1 = rdr["CAS1"].ToString();
                        this.CAS2 = rdr["CAS2"].ToString();
                        this.CAS3 = rdr["CAS3"].ToString();
                        this.CAS4 = rdr["CAS4"].ToString();
                        this.CAS5 = rdr["CAS5"].ToString();
                        this.Amount1 = rdr["Amount1"].ToString();
                        this.Amount2 = rdr["Amount2"].ToString();
                        this.Amount3 = rdr["Amount3"].ToString();
                        this.Amount4 = rdr["Amount4"].ToString();
                        this.Amount5 = rdr["Amount5"].ToString();
                        this.Unit1 = rdr["Unit1"].ToString();
                        this.Unit2 = rdr["Unit2"].ToString();
                        this.Unit3 = rdr["Unit3"].ToString();
                        this.Unit4 = rdr["Unit4"].ToString();
                        this.Unit5 = rdr["Unit5"].ToString();
                        this.ResponderName = rdr["ResponderName"].ToString();
                        this.NotificationTime = rdr["NotificationTime"].ToString();
                    }
                }
            }
        }
    }
    public class TceqLog
    {
        public int ID { get; set; }
        public string ERS { get; set; }
        public string ReportDate { get; set; }
        public string ReportTime { get; set; }
        public string IncidentDate { get; set; }
        public string IncidentTime { get; set; }
        public string ReportedBy { get; set; }
        public string ContactNumber { get; set; }
        public string OtherNumbers { get; set; }
        public string County { get; set; }
        public string NotificationTime { get; set; }
    }

}
