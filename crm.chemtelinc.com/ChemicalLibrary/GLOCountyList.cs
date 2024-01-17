using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class GLOCountyList
    {
        #region Private Fields

        private double _countycode;
        private string _countyname, _countyglovoicenumber, _countygloregionnumber, _countygloregioncity, _countyglobeepernumber, _countyrrcnumber, _countyrrcdistrictnumber;
        private string _countyrrcdistrictcity, _countytnrccnumber, _countytnrccdistrictnumber, _countytnrccdistrictcity;

        #endregion
        #region Public Properties
        #region Doubles

        public double County_Code
        {
            get { return _countycode; }
            set { _countycode = value; }
        }

        #endregion
        #region Strings

        public string County_Name
        {
            get { return _countyname; }
            set { _countyname = value; }
        }
        public string County_GLO_Voice_Number
        {
            get { return _countyglovoicenumber; }
            set { _countyglovoicenumber = value; }
        }

        public string County_GLO_Region_Number
        {
            get { return _countygloregionnumber; }
            set { _countygloregionnumber = value; }
        }

        public string County_GLO_Region_City
        {
            get { return _countygloregioncity; }
            set { _countygloregioncity = value; }
        }

        public string County_GLO_Beeper_Number
        {
            get { return _countyglobeepernumber; }
            set { _countyglobeepernumber = value; }
        }

        public string County_RRC_Number
        {
            get { return _countyrrcnumber; }
            set { _countyrrcnumber = value; }
        }

        public string County_RRC_District_Number
        {
            get { return _countyrrcdistrictnumber; }
            set { _countyrrcdistrictnumber = value; }
        }

        public string County_RRC_District_City
        {
            get { return _countyrrcdistrictcity; }
            set { _countyrrcdistrictcity = value; }
        }

        public string County_TNRCC_Number
        {
            get { return _countytnrccnumber; }
            set { _countytnrccnumber = value; }
        }

        public string County_TNRCC_District_Number
        {
            get { return _countytnrccdistrictnumber; }
            set { _countytnrccdistrictnumber = value; }
        }

        public string County_TNRCC_District_City
        {
            get { return _countytnrccdistrictcity; }
            set { _countytnrccdistrictcity = value; }
        }

        #endregion
        #endregion
        #region Public Constructors

        public GLOCountyList()
        {
            _countycode = 0;
            _countyname = "";
            _countyglovoicenumber = "";
            _countygloregionnumber = "";
            _countygloregioncity = "";
            _countyglobeepernumber = "";
            _countyrrcnumber = "";
            _countyrrcdistrictnumber = "";
            _countyrrcdistrictcity = "";
            _countytnrccnumber = "";
            _countytnrccdistrictnumber = "";
            _countytnrccdistrictcity = "";
        }

        public GLOCountyList(string constring, double id)
        {
            this.County_Code = id;
            SearchGLOCountyListByCountyCode(constring);
        }

        public GLOCountyList(string constring, string name)
        {
            this.County_Name = name;
            SearchGLOCountyListByCountyName(constring);
        }

        #endregion
        #region Search Methods

        public void SearchGLOCountyListByCountyCode(string constring)
        {
            string strsql = "SELECT * FROM glocountylist WHERE countyCode=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.County_Code);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.County_Code = double.Parse(rdr["countyCode"].ToString());
                        this.County_Name = rdr["countyName"].ToString();
                        this.County_GLO_Voice_Number = rdr["countyGLOVoiceNumber"].ToString();
                        this.County_GLO_Region_Number = rdr["countyGLORegionNumber"].ToString();
                        this.County_GLO_Region_City = rdr["countyGLORegionCity"].ToString();
                        this.County_GLO_Beeper_Number = rdr["countyGLOBeeperNumber"].ToString();
                        this.County_RRC_Number = rdr["countyRRCNumber"].ToString();
                        this.County_RRC_District_Number = rdr["countyRRCDistrictNumber"].ToString();
                        this.County_RRC_District_City = rdr["countyRRCDistrictCity"].ToString();
                        this.County_TNRCC_Number = rdr["countyTNRCCNumber"].ToString();
                        this.County_TNRCC_District_Number = rdr["countyTNRCCDistrictNumber"].ToString();
                        this.County_TNRCC_District_City = rdr["countyTNRCCDistrictCity"].ToString();
                    }
                }
            }
        }

        public void SearchGLOCountyListByCountyName(string constring)
        {
            string strsql = "SELECT * FROM glocountylist WHERE countyName=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.County_Name);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.County_Code = double.Parse(rdr["countyCode"].ToString());
                        this.County_Name = rdr["countyName"].ToString();
                        this.County_GLO_Voice_Number = rdr["countyGLOVoiceNumber"].ToString();
                        this.County_GLO_Region_Number = rdr["countyGLORegionNumber"].ToString();
                        this.County_GLO_Region_City = rdr["countyGLORegionCity"].ToString();
                        this.County_GLO_Beeper_Number = rdr["countyGLOBeeperNumber"].ToString();
                        this.County_RRC_Number = rdr["countyRRCNumber"].ToString();
                        this.County_RRC_District_Number = rdr["countyRRCDistrictNumber"].ToString();
                        this.County_RRC_District_City = rdr["countyRRCDistrictCity"].ToString();
                        this.County_TNRCC_Number = rdr["countyTNRCCNumber"].ToString();
                        this.County_TNRCC_District_Number = rdr["countyTNRCCDistrictNumber"].ToString();
                        this.County_TNRCC_District_City = rdr["countyTNRCCDistrictCity"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
