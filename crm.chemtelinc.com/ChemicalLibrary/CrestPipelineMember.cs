using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class CrestPipelineMember
    {
        #region Private Fields

        private int _id, _contact;
        private string _operatorname, _state, _county, _contactname, _phone;

        #endregion
        #region Public Properties
        #region Ints

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        #endregion
        #region Strings

        public string Operator_Name
        {
            get { return _operatorname; }
            set { _operatorname = value; }
        }

        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string County
        {
            get { return _county; }
            set { _county = value; }
        }

        public string Contact_Name
        {
            get { return _contactname; }
            set { _contactname = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }        

        #endregion
        #endregion
        #region Public Constructors

        public CrestPipelineMember()
        {
            _id = 0;
            _operatorname = "";
            _state = "";
            _county = "";
            _contactname = "";
            _phone = "";
            _contact = 0;
        }

        public CrestPipelineMember(string constring, int id)
        {
            this.ID = id;
            SearchByID(constring);
        }

        public CrestPipelineMember(string constring, string name)
        {
            this.Contact_Name = name;
            SearchByContactName(constring);
        }

        #endregion
        #region Search Methods

        private void SearchByID(string constring)
        {
            string strsql = "SELECT * FROM crestpipelinemembers WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    SqlDataReader rdr=cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                  
                        this.ID = int.Parse(rdr["id"].ToString());
                        this.Operator_Name = rdr["operatorname"].ToString();
                        this.State = rdr["state"].ToString();
                        this.County = rdr["county"].ToString();
                        this.Contact_Name = rdr["contactname"].ToString();
                        this.Phone = rdr["phone"].ToString();
                        this.Contact = int.Parse(rdr["contact"].ToString());
                    }
                }
            }
        }

        private void SearchByContactName(string constring)
        {
            string strsql = "SELECT * FROM crestpipelinemembers WHERE contactname=@con";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@con", this.Contact_Name);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = int.Parse(rdr["id"].ToString());
                        this.Operator_Name = rdr["operatorname"].ToString();
                        this.State = rdr["state"].ToString();
                        this.County = rdr["county"].ToString();
                        this.Contact_Name = rdr["contactname"].ToString();
                        this.Phone = rdr["phone"].ToString();
                        //this.Contact = int.Parse(rdr["contact"].ToString());
                    }
                }
            }
        }

        #endregion
    }
}
