using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class SpillOrigin
    {
        #region Private Fields

        private string _originid;

        #endregion
        #region Public Properties
        #region Strings

        public string Origin_ID
        {
            get { return _originid; }
            set { _originid = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public SpillOrigin()
        {
            _originid = "";
        }

        public SpillOrigin(string constring, string id)
        {
            this.Origin_ID = id;
            SearchSpillOriginsByID(constring);
        }

        #endregion
        #region Search Methods

        public void SearchSpillOriginsByID(string constring)
        {
            string strsql = "SELECT * FROM spillorigin WHERE originId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Origin_ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.Origin_ID = rdr[0].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
