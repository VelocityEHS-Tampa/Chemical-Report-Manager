using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary

{
    public static class Search
    {
        #region GenericListReturns

        public static List<string> GeneralIncidentReportData(string constring)
        {
            List<string> ids = new List<string>();
            string strsql = "SELECT IncidentId FROM generalincidentreportdata";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        ids.Add(rdr[0].ToString());
                    }
                }
                if(ids.Count==0)
                {
                    ids.Add("No IDs found");
                }
            }
            return ids;
        }

        public static List<string> GLOBaseReportData(string constring)
        {
            List<string> ids = new List<string>();
            string strsql = "SELECT cntSpillId FROM globasereportdata";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(rdr[0].ToString());
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add("No IDs found");
                }
            }
            return ids;
        }

        public static List<string> ShellOilIncidentData(string constring)
        {
            List<string> ids = new List<string>();
            string strsql = "SELECT incid FROM shelloilincidentdata";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(rdr[0].ToString());
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add("No IDs found");
                }
            }
            return ids;
        }

        public static List<string> TheoChemCleanShotIncidents(string constring)
        {
            List<string> ids = new List<string>();
            string strsql = "SELECT incidentId FROM theochemcleanshotincidents";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(rdr[0].ToString());
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add("No IDs found");
                }
            }
            return ids;
        }

        public static List<string> AvailableSpillIDs(string constring)
        {
            List<string> ids = new List<string>();
            string strsql = "SELECT Id FROM availablespillids";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(rdr[0].ToString());
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add("No IDs found");
                }
            }
            return ids;
        }

        public static List<string> GeneralIncidentIDs(string constring)
        {
            List<string> ids = new List<string>();
            string strsql = "SELECT id FROM generalincidentids";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(rdr[0].ToString());
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add("Mo IDs found");
                }
            }
            return ids;
        }

        public static List<double> GLOCountyList(string constring)
        {
            List<double> ids = new List<double>();
            string strsql = "SELECT countyCode FROM glocountylist";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(double.Parse(rdr[0].ToString()));
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add(0);
                }
            }
            return ids;
        }

        public static List<string> GLOCountyListNames(string constring)
        {
            List<string> ids = new List<string>();
            string strsql = "SELECT countyName FROM glocountylist";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(rdr[0].ToString());
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add("no county names found");
                }
            }
            return ids;
        }

        public static List<int> GLOEmailIDs(string constring)
        {
            List<int> ids = new List<int>();
            string strsql = "SELECT id FROM gloemails";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(int.Parse(rdr[0].ToString()));
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add(0);
                }
            }
            return ids;
        }

        public static List<string> GLOEmailNames(string constring)
        {
            List<string> ids = new List<string>();
            string strsql = "SELECT name FROM gloemails";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(rdr[0].ToString());
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add("No names found");
                }
            }
            return ids;
        }

        public static List<int> MODRequestIDs(string constring)
        {
            List<int> ids = new List<int>();
            string strsql = "SELECT modrequestid  FROM modrequests";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(int.Parse(rdr[0].ToString()));
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add(0);
                }
            }
            return ids;
        }

        public static List<string> MODRequestCompanyName(string constring)
        {
            List<string> ids = new List<string>();
            string strsql = "SELECT DISTINCT companyname FROM modrequests";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(rdr[0].ToString());
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add("No company names found");
                }
            }
            return ids;
        }

        public static List<string> NonCoastal(string constring)
        {
            List<string> ids = new List<string>();
            string strsql = "SELECT nonCoastalType FROM noncoastal";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(rdr[0].ToString());
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add("No noncoastal types found");
                }
            }
            return ids;
        }

        public static List<string> SpillOrigins(string constring)
        {
            List<string> ids = new List<string>();
            string strsql = "SELECT originId FROM spillorigin";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(rdr[0].ToString());
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add("No spill origins found");
                }
            }
            return ids;
        }

        public static List<string> SpillUnits(string constring)
        {
            List<string> ids = new List<string>();
            string strsql = "SELECT unitId FROM spillunits";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(rdr[0].ToString());
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add("No spill units found");
                }
            }
            return ids;
        }

        public static List<string> TicketIDs(string constring)
        {
            List<string> ids = new List<string>();
            string strsql = "SELECT id FROM tickets";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(rdr[0].ToString());
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add("No IDs found");
                }
            }
            return ids;
        }

        public static List<string> TicketStatuses(string constring)
        {
            List<string> ids = new List<string>();
            string strsql = "SELECT status FROM tickets";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ids.Add(rdr[0].ToString());
                    }
                }
                if (ids.Count == 0)
                {
                    ids.Add("No statuses found");
                }
            }
            return ids;
        }

        public static List<string> EmailByRegion(string constring, string region)
        {
            List<string> names = new List<string>();
            string strsql = "SELECT DISTINCT name, location FROM cresters WHERE location LIKE @lo ORDER BY location, name";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@lo", "%" + region + "%");
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        names.Add(rdr[0].ToString() + "-" + rdr[1].ToString());
                    }
                }
            }
            return names;
        }

        public static List<string> AllEmails(string constring)
        {
            List<string> names = new List<string>();
            string strsql = "SELECT DISTINCT name, location FROM cresters ORDER BY location";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {                   
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        names.Add(rdr[0].ToString() + "-" + rdr[1].ToString());
                    }
                }
            }
            return names;
        }

        public static List<string> IESPhoneNumbers(string constring)
        {
            List<string> numbers = new List<string>();
            string strsql = "SELECT phonenumber FROM iescontacts";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        numbers.Add(rdr[0].ToString());
                    }
                }
            }
            return numbers;
        }

        public static List<string> IESNames(string constring)
        {
            List<string> names = new List<string>();
            string strsql = "SELECT name FROM iescontacts";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        names.Add(rdr[0].ToString());
                    }
                }
            }
            return names;
        }

        #endregion
        #region Special Search Routines

        public static bool CheckIncidentID(string constring, string id)
        {
            int cnt = 0;
            string strsql = "SELECT * FROM generalincidentreportdata WHERE IncidentId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        ++cnt;
                }
            }
            if (cnt > 0)
                return false;
            else
                return true;
        }

        public static bool CheckCleanShotID(string constring, string id)
        {
            int cnt = 0;
            string strsql = "SELECT * FROM theochemcleanshotincidents WHERE incidentId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        ++cnt;
                }
            }
            if (cnt > 0)
                return false;
            else
                return true;
        }

        public static bool CheckGLOID(string constring, string id)
        {
            int cnt = 0;
            string strsql = "SELECT * FROM globasereportdata WHERE cntSpillId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        ++cnt;
                }
            }
            if (cnt > 0)
                return false;
            else
                return true;
        }

        public static List<string> GetCrestERSNames(string constring)
        {
            List<string> names = new List<string>();
            string strsql = "SELECT name, location, id FROM cresters";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        names.Add(rdr[1].ToString()+"_"+rdr[0].ToString()+"_"+rdr[2].ToString());
                }
            }
            return names;
        }

        public static List<string> GetEmailsByLocation(string constring, string location)
        {
            List<string> emails = new List<string>();
            string strsql = "SELECT DISTINCT email FROM cresters WHERE location=@l";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@l", location);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        emails.Add(rdr[0].ToString());
                    }
                }
            }
            return emails;
        }

        public static List<string> GetContactNames(string constring)
        {
            List<string> names = new List<string>();
            string strsql = "SELECT contactname, operatorname, state, county, id FROM crestpipelinemembers";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        names.Add(rdr[0].ToString()+"_"+rdr[1].ToString()+"_"+rdr[2].ToString()+"_"+rdr[3].ToString()+"_"+rdr[4].ToString());
                }
            }
            return names;
        }

        public static List<string> GetLocations(string constring, string name)
        {
            List<string> locations = new List<string>();
            string strsql = "SELECT location FROM cresters WHERE name=@n";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    SqlDataReader rdr=cmd.ExecuteReader();
                    while (rdr.Read())
                        locations.Add(rdr[0].ToString());
                }
            }
            return locations;
        }

        public static List<string> GetPipelineNames(string constring, string state, string county)
        {
            List<string> names = new List<string>();
            string strsql = "SELECT DISTINCT contactname FROM crestpipelinemembers WHERE state=@s AND county=@c ORDER BY contactname";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@s", state);
                    cmd.Parameters.AddWithValue("@c", county);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        names.Add(rdr[0].ToString());
                    }
                }
            }
            return names;
        }

        public static List<string> GetStates(string constring)
        {
            List<string> states = new List<string>();
            string strsql = "SELECT abbreviation FROM statesdb.states";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using(SqlCommand cmd=new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        states.Add(rdr[0].ToString());
                    }
                }
            }
            return states;
        }

        public static string GetEmailAddress(string constring, string name, string region)
        {
            string email = "";
            string strsql = "SELECT email FROM cresters WHERE name=@n";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@l", region);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        email = rdr[0].ToString();
                }
            }
            return email;
        }

        public static List<string> GetTransportationNames(string constring)
        {
            List<string> names = new List<string>();
            string strsql = "SELECT name FROM crestwoodtransportationlist";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        names.Add(rdr[0].ToString());
                }
            }
            return names;
        }

        public static List<string> GetNonTransportEmails(string constring, string State)
        {
            List<string> emails = new List<string>();

            switch (State)
            {
                case "IN":
                    emails.Add("Local-S&L-Terminal-IN@crestwoodlp.com");
                    break;
                case "MI":
                    emails.Add("Local-S&L-Terminal-MI@crestwoodlp.com");
                    break;
                case "MO":
                    emails.Add("Local-S&L-Terminal-MO@crestwoodlp.com");
                    break;
                case "NH":
                    emails.Add("Local-S&L-Terminal-NH@crestwoodlp.com");
                    break;
                case "NJ":
                    emails.Add("Local-S&L-Terminal-NJ@crestwoodlp.com");
                    break;
                case "NY":
                    emails.Add("Local-S&L-Terminal-NY01@crestwoodlp.com");
                    emails.Add("Local-S&L-Terminal-NY-MONT@crestwoodlp.com");
                    break;
                case "NC":
                    emails.Add("Local-S&L-Terminal-NC@crestwoodlp.com");
                    break;
                case "OH":
                    emails.Add("Local-S&L-Terminal-OH@crestwoodlp.com");
                    break;
                case "PA":
                    emails.Add("Local-S&L-Terminal-PA@crestwoodlp.com");
                    break;
                case "RI":
                    emails.Add("Local-S&L-Terminal-RI@crestwoodlp.com");
                    break;
                case "SC":
                    emails.Add("Local-S&L-Terminal-SC-HS@crestwoodlp.com");
                    emails.Add("Local-S&L-Terminal-SC-TIR@crestwoodlp.com");
                    break;
                case "MD":
                    emails.Add("Local-WildBasin@crestwoodlp.com");
                    break;
                case "MT":
                    emails.Add("Local-WildBasin@crestwoodlp.com");
                    break;
            }
            return emails;
        }

        public static string GetTransportationEmails(string constring, int Indiana, int NJ, int WV)
        {
            string emails = "";
            string strsql = "SELECT email FROM crestwoodtransportationlist";
            if (Indiana == 1)
            {
                strsql = strsql + " WHERE Indiana = 1";
            }
            if (NJ == 1)
            {
                strsql = strsql + " WHERE NewJersey = 1";
            }
            if (WV == 1)
            {
                strsql = strsql + " WHERE WestVirginia = 1";
            }
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    emails = cmd.ExecuteScalar().ToString();
                }
            }
            return emails;
        }

        public static List<string> GetAllNotifificationNames(string constring)
        {
            List<string> names = new List<string>();
            string strsql = "SELECT name FROM crestallnotifications";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())                    
                        names.Add(rdr[0].ToString());
                }
            }
            return names;
        }

        public static List<string> GetAllNotificationEmails(string constring)
        {
            List<string> emails = new List<string>();
            string strsql="SELECT email FROM crestallnotifications";
            using(SqlConnection cn=new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        emails.Add(rdr[0].ToString());
                }
            }
            return emails;
        }

        public static List<string> GetManDownEmails(string constring)
        {
            List<string> emails = new List<string>();
            string strsql = "SELECT DISTINCT email FROM cresters WHERE location=@l";
            string location = "Central Non-MC Incidents";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@l", location);
                    SqlDataReader rdr=cmd.ExecuteReader();
                    while(rdr.Read())
                        emails.Add(rdr[0].ToString());
                }
            }
            return emails;
        }

        public static string GetManDownOnCall(string constring)
        {
            string text = "";
            string datestring = DateTime.Now.ToShortDateString();
            DateTime date = DateTime.Parse(datestring+" 09:00");
            string strsql = "SELECT DISTINCT name, phone FROM cresters WHERE location=@l AND startdate<=@d AND enddate>=@d";
            string location = "Central Non-MC Incidents";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@d", date);
                    cmd.Parameters.AddWithValue("@l", location);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        text = "Call " + rdr[0].ToString() + " at " + rdr[1].ToString();
                    }
                }
                return text;
            }
        }

        public static string GetShellID(string constring)
        {
            string id = "";
            string strsql = "SELECT incid FROM shelloilincidentdata";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using(SqlCommand cmd=new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        id = rdr[0].ToString();
                    }
                }
            }
            return id;
        }

        #endregion
        #region Int Return Methods

        public static int GetLastIESID(string constring)
        {
            int id = 0;
            string strsql = "SELECT id FROM ies";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        id = int.Parse(rdr[0].ToString());
                    }
                }
            }
            return id;
        }

        #endregion
    }
}
