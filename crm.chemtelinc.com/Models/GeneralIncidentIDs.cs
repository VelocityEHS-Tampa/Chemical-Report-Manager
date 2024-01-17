using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class GeneralIncidentIDs
    {
        #region Private Fields

        private int _available;
        private string _id, _user;

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

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public GeneralIncidentIDs()
        {
            _id = "";
            _available = 0;
            _user = "";
        }

        public GeneralIncidentIDs(string constring, string id)
        {
            this.ID = id;
            SearchGeneralIncidentIDsByID(constring);
        }

        #endregion
        #region Search Methods

        public void SearchGeneralIncidentIDsByID(string constring)
        {
            string strsql = "SELECT * FROM generalincidentids WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = rdr["id"].ToString();
                        this.Available = int.Parse(rdr["available"].ToString());
                        this.User = rdr["user"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
