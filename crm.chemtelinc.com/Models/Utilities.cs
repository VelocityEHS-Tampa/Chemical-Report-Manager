using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public static class Utilities
    {
        public static string GetDirector(string constring, string State, string County)
        {
            string name = "";
            string strsql = "SELECT contactname, phone FROM crestpipelinemembers WHERE state=@sta and county=@cou ORDER BY contact ASC";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@sta", State);
                    cmd.Parameters.AddWithValue("@cou", County);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        name += rdr[0].ToString() + "_" + rdr[1].ToString() + ":";
                    }
                }
            }
            return name;
        }

        public static string GetUsersName(string username)
        {
            string Name = "";
            if (username == "cbotelho")
            {
                Name = "Chrissy Botelho";
            } else if (username == "tcockrell")
            {
                Name = "Terri Cockrell";
            }
            else if (username == "swardino")
            {
                Name = "Sandy Wardino";
            }
            else if (username == "aclements")
            {
                Name = "Austin Clements";
            }
            else if (username == "jperdomo")
            {
                Name = "Jerri Perdomo"; 
            }
            else if (username == "jharvey")
            {
                Name = "Juli Harvey";
            }
            else if (username == "lweckerle")
            {
                Name = "Lynn Weckerle";
            }
            else if (username == "sweckerle")
            {
                Name = "Simond Weckerle";
            }
            else if (username == "scourtney")
            {
                Name = "Sterling Courtney";
            }
            else if (username == "towens")
            {
                Name = "Tonya Owens";
            }
            else if (username == "mpepitone")
            {
                Name = "Michael Pepitone";
            }
            else if (username == "sschulte")
            {
                Name = "Shaye Schulte";
            }
            else if (username == "hmolina")
            {
                Name = "Henry Molina";
            }
            return Name;
        }
    }
}
