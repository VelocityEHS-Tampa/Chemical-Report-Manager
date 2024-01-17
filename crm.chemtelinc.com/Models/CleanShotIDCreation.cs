using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public static class CleanShotIDCreation
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

        public static string SearchForAvailableID(string constring)
        {
            string id = "";
            int cnt = 0;
            string strsql = "SELECT id FROM cleanshotids WHERE available=@a";
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
                            id = rdr[0].ToString();
                        ++cnt;
                    }
                }
            }
            return id;
        }

        public static string GetLastID(string constring)
        {
            string id = "";
            string strsql = "SELECT id FROM cleanshotids";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        id = rdr[0].ToString();
                }
            }
            return id;
        }

        #endregion
        #region Increment Method

        public static string Increment(string id)
        {
            int num=int.Parse(id.Substring(3));
            ++num;
            id = id.Substring(0, 3) + num.ToString();
            return id;
        }

        #endregion
    }
}
