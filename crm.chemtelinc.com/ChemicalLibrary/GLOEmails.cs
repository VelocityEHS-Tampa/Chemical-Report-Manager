using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary

{
    public class GLOEmails
    {
        #region Private Fields

        private int _id;
        private string _name, _emailgroup, _email01, _email02, _email03, _email04, _email05, _email06, _email07, _email08, _email09, _email10;

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

        public string Email_Group
        {
            get { return _emailgroup; }
            set { _emailgroup = value; }
        }

        public string Email_01
        {
            get { return _email01; }
            set { _email01 = value; }
        }

        public string Email_02
        {
            get { return _email02; }
            set { _email02 = value; }
        }

        public string Email_03
        {
            get { return _email03; }
            set { _email03 = value; }
        }

        public string Email_04
        {
            get { return _email04; }
            set { _email04 = value; }
        }

        public string Email_05
        {
            get { return _email05; }
            set { _email05 = value; }
        }

        public string Email_06
        {
            get { return _email06; }
            set { _email06 = value; }
        }

        public string Email_07
        {
            get { return _email07; }
            set { _email07 = value; }
        }

        public string Email_08
        {
            get { return _email08; }
            set { _email08 = value; }
        }

        public string Email_09
        {
            get { return _email09; }
            set { _email09 = value; }
        }

        public string Email_10
        {
            get { return _email10; }
            set { _email10 = value; }
        }
        #endregion
        #endregion
        #region Public Constructors

        public GLOEmails()
        {
            _id = 0;
            _name = "";
            _emailgroup = "";
            _email01 = "";
            _email02 = "";
            _email03 = "";
            _email04 = "";
            _email05 = "";
            _email06 = "";
            _email07 = "";
            _email08 = "";
            _email09 = "";
            _email10 = "";
        }

        public GLOEmails(string constring, int id)
        {
            this.ID = id;
            SearchGLOEmailsByID(constring);
        }

        public GLOEmails(string constring, string n)
        {
            this.Name = n;
            SearchGLOEmailsByName(constring);
        }

        #endregion
        #region Search Methods

        public void SearchGLOEmailsByID(string constring)
        {
            string strsql = "SELECT * FROM gloemails WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID=int.Parse(rdr["id"].ToString());
                        this.Name=rdr["name"].ToString();
                        this.Email_Group=rdr["emailgroup"].ToString();
                        this.Email_01=rdr["email01"].ToString();
                        this.Email_02=rdr["email02"].ToString();
                        this.Email_03=rdr["email03"].ToString();
                        this.Email_04=rdr["email04"].ToString();
                        this.Email_05=rdr["email05"].ToString();
                        this.Email_06=rdr["email06"].ToString();
                        this.Email_07=rdr["email07"].ToString();
                        this.Email_08=rdr["email08"].ToString();
                        this.Email_09=rdr["email09"].ToString();
                        this.Email_10=rdr["email10"].ToString();
                    }
                }
            }
        }

        public void SearchGLOEmailsByName(string constring)
        {
            string strsql = "SELECT * FROM gloemails WHERE name=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Name);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.ID=int.Parse(rdr["id"].ToString());
                        this.Name=rdr["name"].ToString();
                        this.Email_Group=rdr["emailgroup"].ToString();
                        this.Email_01=rdr["email01"].ToString();
                        this.Email_02=rdr["email02"].ToString();
                        this.Email_03=rdr["email03"].ToString();
                        this.Email_04=rdr["email04"].ToString();
                        this.Email_05=rdr["email05"].ToString();
                        this.Email_06=rdr["email06"].ToString();
                        this.Email_07=rdr["email07"].ToString();
                        this.Email_08=rdr["email08"].ToString();
                        this.Email_09=rdr["email09"].ToString();
                        this.Email_10=rdr["email10"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
