using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class Knowlegebase
    {
        #region Private Fields

        private int _knowledgebaseid;
        public string _title, _body, _link;

        #endregion
        #region Public Properties
        #region Ints

        public int Knowledgebase_ID
        {
            get { return _knowledgebaseid; }
            set { _knowledgebaseid = value; }
        }

        #endregion
        #region Strings

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public Knowlegebase()
        {
            _knowledgebaseid = 0;
            _title = "";
            _body = "";
            _link = "";
        }

        public Knowlegebase(string constring, int id)
        {
            this.Knowledgebase_ID = id;
            SearchKnowledgebaseByID(constring);
        }

        public Knowlegebase(string constring, string title)
        {
            this.Title = title;
            SearchKnowledgebaseByTitle(constring);
        }

        #endregion
        #region Search Methods

        public void SearchKnowledgebaseByID(string constring)
        {
            string strsql = "SELECT * FROM knowledgebase WHERE knowledgebase_id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Knowledgebase_ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.Knowledgebase_ID = int.Parse(rdr["knowledgebase_id"].ToString());
                        this.Title = rdr["title"].ToString();
                        this.Body = rdr["body"].ToString();
                        this.Link = rdr["link"].ToString();
                    }
                }
            }
        }

        public void SearchKnowledgebaseByTitle(string constring)
        {
            string strsql = "SELECT * FROM knowledgebase WHERE title=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Title);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.Knowledgebase_ID = int.Parse(rdr["knowledgebase_id"].ToString());
                        this.Title = rdr["title"].ToString();
                        this.Body = rdr["body"].ToString();
                        this.Link = rdr["link"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
