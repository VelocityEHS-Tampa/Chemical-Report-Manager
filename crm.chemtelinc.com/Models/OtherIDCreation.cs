using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public static class OtherIDCreation
    {
        #region Year Check

        public static bool CheckYear(string date)
        {
            string[] ar = date.Split('/');
            int idyear = int.Parse(ar[ar.Length - 1]);
            string today = DateTime.Now.ToShortDateString();
            string[] arr = today.Split('/');
            int realyear = int.Parse(arr[arr.Length - 1]);
            if (idyear == realyear)
                return true;
            else
                return false;
        }

        #endregion
        #region Table Searches

        public static int SearchForAvailableID(string constring)
        {
            int id = 0;
            int cnt = 0;
            string strsql = "SELECT id FROM otherids WHERE available=@a";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@a", 0);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (cnt > 0)
                            break;
                        else
                            id=int.Parse(rdr[0].ToString());
                        ++cnt;
                    }
                }
            }
            return id;
        }

        public static int GetLastID(string constring)
        {
            int id = 0;
            string strsql = "SELECT TOP 1 incidentid FROM generalincidentreportdata ORDER BY incidentid DESC";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        id = int.Parse(rdr[0].ToString());
                }
            }
            return id;
        }

        #endregion
        #region Increment Method

        public static int Increment(int id)
        {
            return ++id;
        }

        #endregion
    }
}
