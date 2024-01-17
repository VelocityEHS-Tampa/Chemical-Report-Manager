using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class CompanyInformation
    {
        #region Private Fields

        private int _id;
        private string _name;

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

        #endregion
        #endregion
        #region Public Constructors

        public CompanyInformation()
        {
            _id = 0;
            _name = "";
        }

        public CompanyInformation(string constring, int id)
        {
            this.ID = id;
            SearchCompanyInformationByID(constring);
        }

        public CompanyInformation(string constring, string name)
        {
            this.Name = name;
            SearchCompanyInformationByName(constring);
        }

        #endregion
        #region Search Methods

        public void SearchCompanyInformationByID(string constring)
        {
            string strsql = "SELECT * FROM companyinformation WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = int.Parse(rdr["id"].ToString());
                        this.Name = rdr["name"].ToString();
                    }
                }
            }
        }

        public void SearchCompanyInformationByName(string constring)
        {
            string strsql = "SELECT * FROM companyinformation WHERE name=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Name);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID = int.Parse(rdr["id"].ToString());
                        this.Name = rdr["name"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
