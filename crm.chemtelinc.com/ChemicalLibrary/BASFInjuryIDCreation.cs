using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public static class BASFInjuryIDCreation
    {
        private static bool noid = false;
        public static long GetID(string constring)
        {
            noid = false;
            long id = GetAvailableID(constring);
            if (id > 0)
            {
                bool ok = false;
                while (ok == false)
                {
                    if (id > 0)
                    {
                        if (!CompareCurrentDate(id))
                        {
                            string fid = "I" + id.ToString();
                            VoidReport(constring, fid);
                            ok = false;
                            BASFInjuryIDs b = new BASFInjuryIDs();
                            b.ID = id;
                            b.Available = "1";
                            b.User = "VOID";
                            Update.UpdateBASFInjuryIDS(constring, b);
                            id = GetAvailableID(constring);
                        }
                        else
                        {
                            ok = true;
                            BASFInjuryIDs b = new BASFInjuryIDs();
                            b.ID = id;
                            b.Available = "1";
                            b.User = "";
                            Update.UpdateBASFInjuryIDS(constring, b);
                        }
                    }
                    else
                    {
                        ok = true;
                        id = GetLastID(constring);
                        if (CompareCurrentDate(id) && !noid)
                        {
                            id += 1;
                        }
                        else
                        {
                            DateTime today = DateTime.Now;
                            string tmp = string.Format("{0:yyyyMMdd}", today) + "001";
                            id = long.Parse(tmp);
                        }
                        BASFInjuryIDs b = new BASFInjuryIDs();
                        b.ID = id;
                        b.Available = "1";
                        b.User = "";
                        Add.AddBASFInjuryIDs(constring, b);
                    }
                }
            }
            else
            {
                id = GetLastID(constring);
                if (CompareCurrentDate(id) && !noid)
                {
                    id += 1;
                }
                else
                {
                    DateTime today = DateTime.Now;
                    string tmp = string.Format("{0:yyyyMMdd}", today) + "001";
                    id = long.Parse(tmp);
                }
                BASFInjuryIDs b = new BASFInjuryIDs();
                b.ID = id;
                b.Available = "1";
                b.User = "";
                Add.AddBASFInjuryIDs(constring, b);
            }
            return id;
        }

        private static long GetLastID(string constring)
        {
            long id = 0;
            string strsql = "SELECT id FROM basfinjuryids";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        id = long.Parse(rdr[0].ToString());
                    }
                }
            }
            if (id == 0)
            {
                DateTime today = DateTime.Now;
                string tmp = string.Format("{0:yyyyMMdd}", today) + "001";
                id = long.Parse(tmp);
                noid = true;
            }
            return id;
        }

        private static long GetAvailableID(string constring)
        {
            string available = "0";
            long id = 0;
            string strsql = "SELECT id FROM basfinjuryids WHERE available=@av";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@av", available);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        id = long.Parse(rdr[0].ToString());
                        break;
                    }
                }
            }
            return id;
        }

        private static bool CompareCurrentDate(long id)
        {
            DateTime today = DateTime.Now;
            string todaystring = String.Format("{0:yyyyMMdd}", today);
            string tmp = id.ToString();
            string idstring = tmp.Substring(0, 8);
            if (todaystring == idstring)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void VoidReport(string constring, string id)
        {
            string v = "VOID";
            BASFInjury b = new BASFInjury();
            b.ID = id;
            b.Incident_Date = v;
            b.Incident_Time = v;
            b.Caller_Name = v;
            b.Caller_Phone = v;
            b.Plant_Name = v;            
            b.Description = v;
            b.Injury_Type = v;
            b.Body_Part_Affected = v;
            b.Escorted = v;
            b.Immediate_Actions = v;
            b.Evidence_Collected = v;
            b.Notifications = v;
            b.ERS_Operator = v;
            Add.AddBASFInjury(constring, b);
        }
    }
}
