using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class AvailableSpillID
    {
        #region Private Fields

        private int _available;
        private string _id, _usedby;

        #endregion
        #region Public Properties
        #region Ints

        public int Available
        {
            get { return _available; }
            set { _available = value; }
        }

        #endregion
        #region Strings

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Used_By
        {
            get { return _usedby; }
            set { _usedby = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public AvailableSpillID()
        {
            _id = "";
            _available = 0;
            _usedby = "";
        }

        public AvailableSpillID(string constring, string id)
        {
            this.ID = id;
            SearchAvailableIDsByID(constring);
        }

        #endregion
        #region Search Methods

        public void SearchAvailableIDsByID(string constring)
        {
            string strsql = "SELECT * FROM availablespillids WHERE Id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = rdr["Id"].ToString();
                        this.Available = int.Parse(rdr["available"].ToString());
                        this.Used_By = rdr["usedBy"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
