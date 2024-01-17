using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class BASFEnvironmentalIDs
    {
        #region Private Fields

        private long _id;
        private string _available, _user;

        #endregion
        #region Public Properties
        #region Ints

        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }

        #endregion
        #region Strings

        public string Available
        {
            get { return _available; }
            set { _available = value; }
        }

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public BASFEnvironmentalIDs()
        {
            _id = 0;
            _available = "";
            _user = "";
        }

        public BASFEnvironmentalIDs(string constring, long id)
        {
            this.ID = id;
            SearchByID(constring);
        }

        #endregion
        #region Search Methods

        private void SearchByID(string constring)
        {
            string strsql = "SELECT * FROM basfenvironmentalids WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID=long.Parse(rdr["id"].ToString());
                        this.Available = rdr["available"].ToString();
                        this.User = rdr["user"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
