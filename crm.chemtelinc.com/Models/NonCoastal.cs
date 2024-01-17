using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class NonCoastal
    {
        #region Private Fields

        private string _noncoastaltype;

        #endregion
        #region Public Properties
        #region Strings

        public string Non_Coastal_Type
        {
            get { return _noncoastaltype; }
            set { _noncoastaltype = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public NonCoastal()
        {
            _noncoastaltype = "";
        }

        public NonCoastal(string constring, string id)
        {
            this.Non_Coastal_Type = id;
            SearchNonCoastalTypesByID(constring);
        }

        #endregion
        #region Search Methods

        public void SearchNonCoastalTypesByID(string constring)
        {
            string strsql = "SELECT * FROM noncoastal WHERE nonCoastalType=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Non_Coastal_Type);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.Non_Coastal_Type = rdr[0].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
