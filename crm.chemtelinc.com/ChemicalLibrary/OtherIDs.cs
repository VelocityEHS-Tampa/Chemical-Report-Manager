using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class OtherID
    {
        #region Private Fields

        private int _id, _available;
        private string _user;

        #endregion
        #region Public Properties
        #region Ints

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Available
        {
            get { return _available; }
            set { _available = value; }
        }

        #endregion
        #region Strings

        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public OtherID()
        {
            _id = 0;
            _available = 0;
            _user = "";
        }

        public OtherID(string constring, int id)
        {
            this.ID = id;
            SearchOtherIDsByID(constring);
        }

        #endregion
        #region Search Methods

        public void SearchOtherIDsByID(string constring)
        {
            string strsql = "SELECT * FROM otherids WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = int.Parse(rdr[0].ToString());
                        this.Available = int.Parse(rdr[1].ToString());
                        this.User=rdr[2].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
