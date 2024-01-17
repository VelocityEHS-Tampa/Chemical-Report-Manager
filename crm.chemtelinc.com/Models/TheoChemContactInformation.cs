using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class TheoChemContactInformation
    {
        #region Private Fields

        private int _contactid;
        private string _name, _admincontact, _phone, _fax, _email, _address, _citystatezip;

        #endregion
        #region Public Properties
        #region Ints

        public int Contact_ID
        {
            get { return _contactid; }
            set { _contactid = value; }
        }

        #endregion
        #region Strings

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Administrative_Contact
        {
            get {return _admincontact; }
            set { _admincontact = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string City_State_Zip
        {
            get { return _citystatezip; }
            set { _citystatezip = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public TheoChemContactInformation()
        {
            _contactid = 0;
            _name = "";
            _admincontact = "";
            _phone = "";
            _fax = "";
            _email = "";
            _address = "";
            _citystatezip = "";
        }

        public TheoChemContactInformation(string constring, int id)
        {
            this.Contact_ID = id;
            SearchTheoChemContactInformationByID(constring);
        }

        public TheoChemContactInformation(string constring, string name)
        {
            this.Name = name;
            SearchTheoChemContactInformationByName(constring);
        }

        #endregion
        #region Search Methods

        public void SearchTheoChemContactInformationByID(string constring)
        {
            string strsql = "SELECT * FROM theochemcontactinformation WHERE contactid=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Contact_ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.Contact_ID = int.Parse(rdr[0].ToString());
                        this.Name = rdr[1].ToString();
                        this.Administrative_Contact = rdr[2].ToString();
                        this.Phone = rdr[3].ToString();
                        this.Fax = rdr[4].ToString();
                        this.Email = rdr[5].ToString();
                        this.Address = rdr[6].ToString();
                        this.City_State_Zip = rdr[7].ToString();
                    }
                }
            }
        }

        public void SearchTheoChemContactInformationByName(string constring)
        {
            string strsql = "SELECT * FROM theochemcontactinformation WHERE name=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Name);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.Contact_ID = int.Parse(rdr[0].ToString());
                        this.Name = rdr[1].ToString();
                        this.Administrative_Contact = rdr[2].ToString();
                        this.Phone = rdr[3].ToString();
                        this.Fax = rdr[4].ToString();
                        this.Email = rdr[5].ToString();
                        this.Address = rdr[6].ToString();
                        this.City_State_Zip = rdr[7].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
