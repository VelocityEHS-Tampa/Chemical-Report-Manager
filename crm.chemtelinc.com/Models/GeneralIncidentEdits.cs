using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class GeneralIncidentEdits
    {
        #region Private Fields

        private string _id, _username;
        private DateTime _editdate;
        private int _numberofedits;

        #endregion
        #region Public Properties
        #region Strings

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        #endregion
        #region DateTimes

        public DateTime Edit_Date
        {
            get { return _editdate; }
            set { _editdate = value; }
        }

        #endregion
        #region Ints

        public int Number_Of_Edits
        {
            get { return _numberofedits; }
            set { _numberofedits = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public GeneralIncidentEdits()
        {
            _id = "";
            _username = "";
            _editdate = DateTime.MinValue;
            _numberofedits = 0;
        }

        public GeneralIncidentEdits(string constring, string id)
        {
            this.ID = id;
            SearchByID(constring);
        }

        #endregion
        #region Search Methods

        private void SearchByID(string constring)
        {
            string strsql = "SELECT * FROM generalincidentedits WHERE id=@i";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@i", this.ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = rdr["id"].ToString();
                        this.Username = rdr["username"].ToString();
                        this.Edit_Date = DateTime.Parse(rdr["editdate"].ToString());
                        this.Number_Of_Edits = int.Parse(rdr["numberofedits"].ToString());
                    }
                }
            }
        }

        #endregion
    }
}
