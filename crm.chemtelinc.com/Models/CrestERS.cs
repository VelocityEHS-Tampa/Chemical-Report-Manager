using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class CrestERS
    {
        #region Private Fields

        private int _id;
        private DateTime _startdate, _enddate;
        private string _name, _phone, _email, _location;

        #endregion
        #region Public Properties
        #region Ints

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        #endregion
        #region DateTimes

        public DateTime Start_Date
        {
            get { return _startdate; }
            set { _startdate = value; }
        }

        public DateTime End_Date
        {
            get { return _enddate; }
            set { _enddate = value; }
        }

        #endregion
        #region Strings

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public CrestERS()
        {
            _id = 0;
            _startdate = DateTime.MinValue;
            _enddate = DateTime.MinValue;
            _name = "";
            _phone = "";
            _email = "";
            _location = "";
        }

        public CrestERS(string constring, int id)
        {
            this.ID = id;
            //SearchByID(constring);
        }

        public CrestERS(string constring, string name)
        {
            this.Name = name;
            SearchByName(constring);
        }

        public CrestERS(string constring, string name, string location)
        {
            this.Name = name;
            this.Location = location;
            SearchByNameAndLocation(constring);
        }

        public CrestERS(string constring, string name, DateTime startdate, DateTime enddate)
        {
            this.Name = name;
            this.Start_Date = startdate;
            this.End_Date = enddate;
            SearchByNameAndDate(constring);
        }

        #endregion
        #region Search Methods

        private void SearchByName(string constring)
        {
            string strsql = "SELECT * FROM cresters WHERE name=@na";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@na", this.Name);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = int.Parse(rdr["id"].ToString());
                        this.Start_Date = DateTime.Parse(rdr["startdate"].ToString());
                        this.End_Date = DateTime.Parse(rdr["enddate"].ToString());
                        this.Name = rdr["name"].ToString();
                        this.Phone = rdr["phone"].ToString();
                        this.Email = rdr["email"].ToString();
                        this.Location = rdr["location"].ToString();
                    }
                }
            }
        }

        private void SearchByNameAndLocation(string constring)
        {
            string strsql = "SELECT * FROM cresters WHERE name=@na AND location=@lo";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@na", this.Name);
                    cmd.Parameters.AddWithValue("@lo", this.Location);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = int.Parse(rdr["id"].ToString());
                        this.Start_Date = DateTime.Parse(rdr["startdate"].ToString());
                        this.End_Date = DateTime.Parse(rdr["enddate"].ToString());
                        this.Name = rdr["name"].ToString();
                        this.Phone = rdr["phone"].ToString();
                        this.Email = rdr["email"].ToString();
                        this.Location = rdr["location"].ToString();
                    }
                }
            }
        }

        private void SearchByNameAndDate(string constring)
        {
            string strsql = "SELECT * FROM cresters WHERE name=@na AND (startdate=@sd AND enddate=@ed)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@na", this.Name);
                    cmd.Parameters.AddWithValue("@sd", this.Start_Date);
                    cmd.Parameters.AddWithValue("@ed", this.End_Date);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = int.Parse(rdr["id"].ToString());
                        this.Start_Date = DateTime.Parse(rdr["startdate"].ToString());
                        this.End_Date = DateTime.Parse(rdr["enddate"].ToString());
                        this.Name = rdr["name"].ToString();
                        this.Phone = rdr["phone"].ToString();
                        this.Email = rdr["email"].ToString();
                        this.Location = rdr["location"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
