using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class CrestwoodTransportation
    {
        #region Private Fields

        private int _id, _indiana, _newjersey, _westvirginia;
        private string _name, _email;

        #endregion
        #region Public Properties
        #region Ints

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Indiana
        {
            get { return _indiana; }
            set { _indiana = value; }
        }
        public int NewJersey
        {
            get { return _newjersey; }
            set { _newjersey = value; }
        }
        public int WestVirginia
        {
            get { return _westvirginia; }
            set { _westvirginia = value; }
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

        public CrestwoodTransportation()
        {
            _id = 0;
            _name = "";
            _email = "";
            _indiana = 0;
            _newjersey = 0;
            _westvirginia = 0;
        }

        public CrestwoodTransportation(string constring, int id)
        {
            this.ID = id;
            SearchByID(constring);
        }

        public CrestwoodTransportation(string constring, string name)
        {
            this.Name = name;
            SearchByName(constring);
        }

        #endregion
        #region Search Methods

        private void SearchByID(string constring)
        {
            string strsql = "SELECT * FROM crestwoodtransportationlist WHERE id=@i";
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
                        this.Indiana = Int32.Parse(rdr["Indiana"].ToString());
                        this.NewJersey = Int32.Parse(rdr["NewJersey"].ToString());
                        this.WestVirginia = Int32.Parse(rdr["WestVirginia"].ToString());
                    }
                }
            }
        }

        private void SearchByName(string constring)
        {
            string strsql = "SELECT * FROM crestwoodtransportationlist WHERE name=@n";
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
                        this.Indiana = Int32.Parse(rdr["Indiana"].ToString());
                        this.NewJersey = Int32.Parse(rdr["NewJersey"].ToString());
                        this.WestVirginia = Int32.Parse(rdr["WestVirginia"].ToString());
                    }
                }
            }
        }

        #endregion
    }
}
