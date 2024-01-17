using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public static class BASFEnvironmentalIDCreation
    {

        private static bool noid=false;
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
                            string fid = "E" + id.ToString();
                            VoidReport(constring, fid);
                            ok = false;
                            BASFEnvironmentalIDs b = new BASFEnvironmentalIDs();
                            b.ID = id;
                            b.Available = "1";
                            b.User = "VOID";
                            Update.UpdateBASFEnvironmentalIDs(constring, b);
                            id = GetAvailableID(constring);
                        }
                        else
                        {
                            ok = true;
                            BASFEnvironmentalIDs b = new BASFEnvironmentalIDs();
                            b.ID = id;
                            b.Available = "1";
                            b.User = "";
                            Update.UpdateBASFEnvironmentalIDs(constring, b);                           
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
                        BASFEnvironmentalIDs b = new BASFEnvironmentalIDs();
                        b.ID = id;
                        b.Available = "1";
                        b.User = "";
                        Add.AddBASFEnvironmentalIDS(constring, b);
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
                BASFEnvironmentalIDs b = new BASFEnvironmentalIDs();
                b.ID = id;
                b.Available = "1";
                b.User = "";
                Add.AddBASFEnvironmentalIDS(constring, b);
            }
            return id;
        }

        private static long GetLastID(string constring)
        {
            long id = 0;
            string strsql = "SELECT id FROM basfenvironmentalids";
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
            string strsql = "SELECT id FROM basfenvironmentalids WHERE available=@av";
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
            BASFEnvironmental b = new BASFEnvironmental();
            b.ID = id;
            b.Incident_Date = v;
            b.Incident_Time = v;
            b.Caller_Name = v;
            b.Caller_Phone = v;
            b.Plant_Name = v;
            b.Material_Name = v;
            b.SDS_On_Hand = v;
            b.Contained = v;
            b.Handling_Cleanup = v;
            b.Description = v;
            b.Quantity = v;
            b.Quantity_Untits = v;
            b.Release_To = v;
            b.Actions = v;
            b.Achieve_Reportable_Quantity = v;
            b.Notifications = v;
            b.ERS_Operator = v;
            Add.AddBASFEnvironmental(constring, b);
        }
    }
}
