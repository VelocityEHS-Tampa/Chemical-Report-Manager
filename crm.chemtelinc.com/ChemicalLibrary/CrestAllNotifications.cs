using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class CrestAllNotifications
    {
        #region Private Fields

        private int _id;
        private string _name, _email;

        #endregion
        #region Public Properties
        #region Ints

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        #endregion
        #region Strings

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public CrestAllNotifications()
        {
            _id = 0;
            _name = "";
            _email = "";
        }

        public CrestAllNotifications(string constring, int id)
        {
            this.ID = id;
            SearchByID(constring);
        }

        public CrestAllNotifications(string constring, string name)
        {
            this.Name = name;
            SearchByName(constring);
        }

        #endregion
        #region Search Methods

        private void SearchByID(string constring)
        {
            string strsql = "SELECT * FROM crestallnotifications WHERE id=@i";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@i", this.ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = int.Parse(rdr["id"].ToString());
                        this.Name = rdr["name"].ToString();
                        this.Email = rdr["email"].ToString();
                    }
                }
            }
        }

        private void SearchByName(string constring)
        {
            string strsql = "SELECT * FROM crestallnotifications WHERE name=@n";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@n", this.Name);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = int.Parse(rdr["id"].ToString());
                        this.Name = rdr["name"].ToString();
                        this.Email = rdr["email"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
