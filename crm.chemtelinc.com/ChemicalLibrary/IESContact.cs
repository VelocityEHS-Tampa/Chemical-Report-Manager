using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class IESContact
    {
        #region Private Fields

        private int _id, _order;
        private string _name, _phonenumber;

        #endregion
        #region Public Properties
        #region Ints

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }

        #endregion
        #region Strings

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Phone_Number
        {
            get { return _phonenumber; }
            set { _phonenumber = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public IESContact()
        {
            _id = 0;
            _order = 0;
            _name = "";
            _phonenumber = "";
        }

        public IESContact(string constring, int id)
        {
            this.ID = id;
            SearchByID(constring);
        }

        public IESContact(string constring, string name)
        {
            this.Name = name;
            SearchByName(constring);
        }

        #endregion
        #region Search Methods

        private void SearchByID(string constring)
        {
            string strsql = "SELECT * FROM iescontacts WHERE id=@i";
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
                        this.Order=int.Parse(rdr["priority"].ToString());
                        this.Name = rdr["name"].ToString();
                        this.Phone_Number = rdr["phonenumber"].ToString();
                    }
                }
            }
        }

        private void SearchByName(string constring)
        {
            string strsql = "SELECT * FROM iescontacts WHERE name=@n";
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
                        this.Order = int.Parse(rdr["priority"].ToString());
                        this.Name = rdr["name"].ToString();
                        this.Phone_Number = rdr["phonenumber"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
