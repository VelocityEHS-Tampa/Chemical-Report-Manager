using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class GLOLastID
    {
        #region Private Fields

        private int _id, _reportid;

        #endregion
        #region Public Properties
        #region Ints

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Report_ID
        {
            get { return _reportid; }
            set { _reportid = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public GLOLastID(string constring, int id)
        {
            this.ID = id;
            SearchLastIDsByID(constring);
        }

        #endregion
        #region Search Methods

        public void SearchLastIDsByID(string constring)
        {
            string strsql = "SELECT * FROM glolastid WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = int.Parse(rdr["id"].ToString());
                        this.Report_ID = int.Parse(rdr["reportid"].ToString());
                    }
                }
            }
        }

        #endregion
    }
}
