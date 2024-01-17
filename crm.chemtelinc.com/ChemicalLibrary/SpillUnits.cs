using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary

{
    public class SpillUnits
    {
        #region Private Fields

        private string _unitid;

        #endregion
        #region Public Properties
        #region Strings

        public string Unit_ID
        {
            get { return _unitid; }
            set { _unitid = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public SpillUnits()
        {
            _unitid = "";
        }

        public SpillUnits(string constring, string id)
        {
            this.Unit_ID = id;
            SearchSpillUnitsByID(constring);
        }

        #endregion
        #region Search Methods

        public void SearchSpillUnitsByID(string constring)
        {
            string strsql = "SELECT * FROM spillunits WHERE unitId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Unit_ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        this.Unit_ID = rdr[0].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
