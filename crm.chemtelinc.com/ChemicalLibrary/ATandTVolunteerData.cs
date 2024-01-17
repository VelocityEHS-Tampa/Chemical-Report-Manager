using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class ATandTVolunteerData
    {
        #region Private Fields

        private int _rptid;

        #endregion
        #region Public Properties
        #region Ints

        public int Report_ID
        {
            get { return _rptid; }
            set { _rptid = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public ATandTVolunteerData()
        {
            _rptid = 0;
        }

        public ATandTVolunteerData(string constring, int id)
        {
            this.Report_ID = id;
            SearchATandTVolunteerDataByID(constring);
        }

        #endregion
        #region Search Methods

        public void SearchATandTVolunteerDataByID(string constring)
        {
            string strsql = "SELECT * FROM atandtvolunteerdata WHERE reptid=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Report_ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.Report_ID = int.Parse(rdr[0].ToString());
                    }
                }
            }
        }

        #endregion
    }
}
