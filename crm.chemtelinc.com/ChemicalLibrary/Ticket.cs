using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class Ticket
    {
        #region Private Fields

        private string _id, _status, _username, _subject, _description;

        #endregion
        #region Public Properties
        #region Strings

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string User_Name
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public Ticket()
        {
            _id = "";
            _status = "";
            _username = "";
            _subject = "";
            _description = "";
        }

        public Ticket(string constring, string id)
        {
            this.ID = id;
            SearchTicketsByID(constring);
        }

        #endregion
        #region Search Methods

        public void SearchTicketsByID(string constring)
        {
            string strsql = "SELECT * FROM tickets WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = rdr[0].ToString();
                        this.Status = rdr[1].ToString();
                        this.User_Name = rdr[2].ToString();
                        this.Subject = rdr[3].ToString();
                        this.Description = rdr[4].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
