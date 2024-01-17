using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class AgencyList
    {
        #region Private Fields

        private string _agencyid;

        #endregion
        #region Public Properties
        #region Strings

        public string Agency_ID
        {
            get { return _agencyid; }
            set { _agencyid = value; }
        }

        #endregion
        #endregion
        #region Public Costructors

        public AgencyList()
        {
            _agencyid = "";
        }

        public AgencyList(string constring, string id)
        {
            this.Agency_ID = id;
            SearchAgencyListByID(constring);
        }

        #endregion
        #region Search Methods

        public void SearchAgencyListByID(string constring)
        {
            string strsql = "SELECT * FROM agencylist WHERE agencyId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open(); using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Agency_ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.Agency_ID = rdr[0].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
