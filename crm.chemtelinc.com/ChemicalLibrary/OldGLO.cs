using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class OldGLO
    {
        #region Private Fields

        private string _cntspillid, _fdrill, _txtdrilltxt, _txtreporttakenby, _txtreportpartyaffiliation, _datreporttakendate, _datreporttakentime, _txtnotificationagency, _txtdischargereportedby;
        private string _txtdischargedphone1, _txtdischargedphone2, _datdischargedate, _datedischargetime, _txtmaterial1, _dblcasun1, _dblamtspilled1, _txtunitrecovered1, _txtmaterial2;
        private string _dblcasun2, _dblamtspilled2, _txtunitrecovered2, _txtmaterial3, _dblcasun3, _dblamtspilled3, _txtunitrecovered3, _txtmaterial4, _dblcasun4, _dblamtspilled4;
        private string _txtunitrecovered4, _txtmaterial5, _dblcasun5, _dblamtspilled5, _txtunitrecovered5, _wspillcounty, _worigin, _fspillinwater, _fspillairrelease, _fcoastalwater;
        private string _fland, _txtspillreceivingwater, _dblspillamountinwater, _dblspillamountinwaterunits, _memspilllocation, _dblrrcleasenumber, _txtrrcleasername, _txtrrcfieldname;
        private string _txtlandowner, _memactionstakencleanupstatus, _txtnrcnumber, _txtagencyname1, _txtagencyname2, _txtagencyname3, _datdate1, _datdate2, _datdate3, _txtwhere1;
        private string _txtwhere2, _txtwhere3, _txtwho1, _txtwho2, _txtwho3, _dattime1, _dattime2, _dattime3, _txtspiller, _txtspilleraddress, _txtspillercity, _txtspillerstate;
        private string _txtspillerzipcode, _txtspillercontact, _txtspillercontactphone, _memcomments, _txtagcyname1, _txtagcyname2, _txtagcyname3, _datd1, _datd2, _datd3, _txtwhr1;
        private string _txtwhr2, _txtwhr3, _txtw1, _txtw2, _txtw3, _datti1, _datti2, _datti3, _txtlastfield;

        #endregion
        #region Public Properties
        #region Strings

        public string Spill_ID
        {
            get { return _cntspillid; }
            set { _cntspillid = value; }
        }
        public string Drill
        {
            get { return _fdrill; }
            set { _fdrill = value; }
        }
        public string Drill_Txt
        {
            get { return _txtdrilltxt; }
            set { _txtdrilltxt = value; }
        }
        public string Report_Taken_By
        {
            get { return _txtreporttakenby; }
            set { _txtreporttakenby = value; }
        }
        public string Report_Party_Affiliation
        {
            get { return _txtreportpartyaffiliation; }
            set { _txtreportpartyaffiliation = value; }
        }
        public string Report_Taken_Date
        {
            get { return _datreporttakendate; }
            set { _datreporttakendate = value; }
        }
        public string Report_Taken_Time
        {
            get { return _datreporttakentime; }
            set { _datreporttakentime = value; }
        }
        public string Notification_Agency
        {
            get { return _txtnotificationagency; }
            set { _txtnotificationagency = value; }
        }
        public string Discharge_Reported_By
        {
            get { return _txtdischargereportedby; }
            set { _txtdischargereportedby = value; }
        }

        public string Discharged_Phone_1
        {
            get { return _txtdischargedphone1; }
            set { _txtdischargedphone1 = value; }
        }
        public string Discharged_Phone_2
        {
            get { return _txtdischargedphone2; }
            set { _txtdischargedphone2 = value; }
        }
        public string Discharge_Date
        {
            get { return _datdischargedate; }
            set { _datdischargedate = value; }
        }
        public string Discharge_Time
        {
            get { return _datedischargetime; }
            set { _datedischargetime = value; }
        }
        public string Material_1
        {
            get { return _txtmaterial1; }
            set { _txtmaterial1 = value; }
        }
        public string CASUN_1
        {
            get { return _dblcasun1; }
            set { _dblcasun1 = value; }
        }
        public string Amount_Spilled_1
        {
            get { return _dblamtspilled1; }
            set { _dblamtspilled1 = value; }
        }
        public string Unit_Recovered_1
        {
            get { return _txtunitrecovered1; }
            set { _txtunitrecovered1 = value; }
        }
        public string Material_2
        {
            get { return _txtmaterial2; }
            set { _txtmaterial2 = value; }
        }
        public string CASUN_2
        {
            get { return _dblcasun2; }
            set { _dblcasun2 = value; }
        }
        public string Amount_Spilled_2
        {
            get { return _dblamtspilled2; }
            set { _dblamtspilled2 = value; }
        }
        public string Unit_Recovered_2
        {
            get { return _txtunitrecovered2; }
            set { _txtunitrecovered2 = value; }
        }
        public string Material_3
        {
            get { return _txtmaterial3; }
            set { _txtmaterial3 = value; }
        }
        public string CASUN_3
        {
            get { return _dblcasun3; }
            set { _dblcasun3 = value; }
        }
        public string Amount_Spilled_3
        {
            get { return _dblamtspilled3; }
            set { _dblamtspilled3 = value; }
        }
        public string Unit_Recovered_3
        {
            get { return _txtunitrecovered3; }
            set { _txtunitrecovered3 = value; }
        }
        public string Material_4
        {
            get { return _txtmaterial4; }
            set { _txtmaterial4 = value; }
        }
        public string CASUN_4
        {
            get { return _dblcasun4; }
            set { _dblcasun4 = value; }
        }
        public string Amount_Spilled_4
        {
            get { return _dblamtspilled4; }
            set { _dblamtspilled4 = value; }
        }
        public string Unit_Recovered_4
        {
            get { return _txtunitrecovered4; }
            set { _txtunitrecovered4 = value; }
        }
        public string Material_5
        {
            get { return _txtmaterial5; }
            set { _txtmaterial5 = value; }
        }
        public string CASUN_5
        {
            get { return _dblcasun5; }
            set { _dblcasun5 = value; }
        }
        public string Amount_Spilled_5
        {
            get { return _dblamtspilled5; }
            set { _dblamtspilled5 = value; }
        }
        public string Unit_Recovered_5
        {
            get { return _txtunitrecovered5; }
            set { _txtunitrecovered5 = value; }
        }
        public string Spill_County
        {
            get { return _wspillcounty; }
            set { _wspillcounty = value; }
        }
        public string Origin
        {
            get { return _worigin; }
            set { _worigin = value; }
        }
        public string Spill_In_Water
        {
            get { return _fspillinwater; }
            set { _fspillinwater = value; }
        }
        public string Spill_Air_Release
        {
            get { return _fspillairrelease; }
            set { _fspillairrelease = value; }
        }
        public string Coastal_Water
        {
            get { return _fcoastalwater; }
            set { _fcoastalwater = value; }
        }
        public string Land
        {
            get { return _fland; }
            set { _fland = value; }
        }
        public string Spill_Receiving_Water
        {
            get { return _txtspillreceivingwater; }
            set { _txtspillreceivingwater = value; }
        }
        public string Spill_Amount_In_Water
        {
            get { return _dblspillamountinwater; }
            set { _dblspillamountinwater = value; }
        }
        public string Spill_Amount_In_Water_Units
        {
            get { return _dblspillamountinwaterunits; }
            set { _dblspillamountinwaterunits = value; }
        }
        public string Spill_Location
        {
            get { return _memspilllocation; }
            set { _memspilllocation = value; }
        }
        public string RRC_Lease_Number
        {
            get { return _dblrrcleasenumber; }
            set { _dblrrcleasenumber = value; }
        }
        public string RRC_Lease_Name
        {
            get { return _txtrrcleasername; }
            set { _txtrrcleasername = value; }
        }
        public string RRC_Field_Name
        {
            get { return _txtrrcfieldname; }
            set { _txtrrcfieldname = value; }
        }
        public string Land_Owner
        {
            get { return _txtlandowner; }
            set { _txtlandowner = value; }
        }
        public string Actions_Taken_Clean_Up_Status
        {
            get { return _memactionstakencleanupstatus; }
            set { _memactionstakencleanupstatus = value; }
        }
        public string NRC_Number
        {
            get { return _txtnrcnumber; }
            set { _txtnrcnumber = value; }
        }
        public string Agency_Name_1
        {
            get { return _txtagencyname1; }
            set { _txtagencyname1 = value; }
        }
        public string Agency_Name_2
        {
            get { return _txtagencyname2; }
            set { _txtagencyname2 = value; }
        }
        public string Agency_Name_3
        {
            get { return _txtagencyname3; }
            set { _txtagencyname3 = value; }
        }
        public string Date_1
        {
            get { return _datdate1; }
            set { _datdate1 = value; }
        }
        public string Date_2
        {
            get { return _datdate2; }
            set { _datdate2 = value; }
        }
        public string Date_3
        {
            get { return _datdate3; }
            set { _datdate3 = value; }
        }
        public string Where_1
        {
            get { return _txtwhere1; }
            set { _txtwhere1 = value; }
        }
        public string Where_2
        {
            get { return _txtwhere2; }
            set { _txtwhere2 = value; }
        }
        public string Where_3
        {
            get { return _txtwhere3; }
            set { _txtwhere3 = value; }
        }
        public string Who_1
        {
            get { return _txtwho1; }
            set { _txtwho1 = value; }
        }
        public string Who_2
        {
            get { return _txtwho2; }
            set { _txtwho2 = value; }
        }
        public string Who_3
        {
            get { return _txtwho3; }
            set { _txtwho3 = value; }
        }
        public string Time_1
        {
            get { return _dattime1; }
            set { _dattime1 = value; }
        }
        public string Time_2
        {
            get { return _dattime2; }
            set { _dattime2 = value; }
        }
        public string Time_3
        {
            get { return _dattime3; }
            set { _dattime3 = value; }
        }
        public string Spiller
        {
            get { return _txtspiller; }
            set { _txtspiller = value; }
        }
        public string Spiller_Address
        {
            get { return _txtspilleraddress; }
            set { _txtspilleraddress = value; }
        }
        public string Spiller_City
        {
            get { return _txtspillercity; }
            set { _txtspillercity = value; }
        }
        public string Spiller_State
        {
            get { return _txtspillerstate; }
            set { _txtspillerstate = value; }
        }
        public string Spiller_Zip_Code
        {
            get { return _txtspillerzipcode; }
            set { _txtspillerzipcode = value; }
        }
        public string Spiller_Contact
        {
            get { return _txtspillercontact; }
            set { _txtspillercontact = value; }
        }
        public string Spiller_Contact_Phone
        {
            get { return _txtspillercontactphone; }
            set { _txtspillercontactphone = value; }
        }
        public string Comments
        {
            get { return _memcomments; }
            set { _memcomments = value; }
        }
        public string Agcy_Name_1
        {
            get { return _txtagcyname1; }
            set { _txtagcyname1 = value; }
        }
        public string Agcy_Name_2
        {
            get { return _txtagcyname2; }
            set { _txtagcyname2 = value; }
        }
        public string Agcy_Name_3
        {
            get { return _txtagcyname3; }
            set { _txtagcyname3 = value; }
        }
        public string D1
        {
            get { return _datd1; }
            set { _datd1 = value; }
        }
        public string D2
        {
            get { return _datd2; }
            set { _datd2 = value; }
        }
        public string D3
        {
            get { return _datd3; }
            set { _datd3 = value; }
        }
        public string Whr1
        {
            get { return _txtwhr1; }
            set { _txtwhr1 = value; }
        }
        public string Whr2
        {
            get { return _txtwhr2; }
            set { _txtwhr2 = value; }
        }
        public string Whr3
        {
            get { return _txtwhr3; }
            set { _txtwhr3 = value; }
        }
        public string W1
        {
            get { return _txtw1; }
            set { _txtw1 = value; }
        }
        public string W2
        {
            get { return _txtw2; }
            set { _txtw2 = value; }
        }
        public string W3
        {
            get { return _txtw3; }
            set { _txtw3 = value; }
        }
        public string Ti1
        {
            get { return _datti1; }
            set { _datti1 = value; }
        }
        public string Ti2
        {
            get { return _datti2; }
            set { _datti2 = value; }
        }
        public string Ti3
        {
            get { return _datti3; }
            set { _datti3 = value; }
        }
        public string Last_Field
        {
            get { return _txtlastfield; }
            set { _txtlastfield = value; }
        }
        #endregion
        #endregion
        #region Public Constructors

        public OldGLO()
        {
            _cntspillid = "";
            _fdrill = "";
            _txtdrilltxt = "";
            _txtreporttakenby = "";
            _txtreportpartyaffiliation = "";
            _datreporttakendate = "";
            _datreporttakentime = "";
            _txtnotificationagency = "";
            _txtdischargereportedby = "";
            _txtdischargedphone1 = "";
            _txtdischargedphone2 = "";
            _datdischargedate = "";
            _datedischargetime = "";
            _txtmaterial1 = "";
            _txtmaterial2 = "";
            _txtmaterial3 = "";
            _txtmaterial4 = "";
            _txtmaterial5 = "";
            _dblcasun1 = "";
            _dblcasun2 = "";
            _dblcasun3 = "";
            _dblcasun4 = "";
            _dblcasun5 = "";
            _dblamtspilled1 = "";
            _dblamtspilled2 = "";
            _dblamtspilled3 = "";
            _dblamtspilled4 = "";
            _dblamtspilled5 = "";
            _txtunitrecovered1 = "";
            _txtunitrecovered2 = "";
            _txtunitrecovered3 = "";
            _txtunitrecovered4 = "";
            _txtunitrecovered5 = "";
            _wspillcounty = "";
            _worigin = "";
            _fspillinwater = "";
            _fspillairrelease = "";
            _fcoastalwater = "";
            _fland = "";
            _txtspillreceivingwater = "";
            _dblspillamountinwater = "";
            _dblspillamountinwaterunits = "";
            _memspilllocation = "";
            _dblrrcleasenumber = "";
            _txtrrcleasername = "";
            _txtrrcfieldname = "";
            _txtlandowner = "";
            _memactionstakencleanupstatus = "";
            _txtnrcnumber = "";
            _txtagencyname1 = "";
            _txtagencyname2 = "";
            _txtagencyname3 = "";
            _datdate1 = "";
            _datdate2 = "";
            _datdate3 = "";
            _txtwhere1 = "";
            _txtwhere2 = "";
            _txtwhere3 = "";
            _txtwho1 = "";
            _txtwho2 = "";
            _txtwho3 = "";
            _dattime1 = "";
            _dattime2 = "";
            _dattime3 = "";
            _txtspiller = "";
            _txtspilleraddress = "";
            _txtspillercity = "";
            _txtspillerstate = "";
            _txtspillerzipcode = "";
            _txtspillercontact = "";
            _txtspillercontactphone = "";
            _memcomments = "";
            _txtagcyname1 = "";
            _txtagcyname2 = "";
            _txtagcyname3 = "";
            _datd1 = "";
            _datd2 = "";
            _datd3 = "";
            _txtwhr1 = "";
            _txtwhr2 = "";
            _txtwhr3 = "";
            _txtw1 = "";
            _txtw2 = "";
            _txtw3 = "";
            _datti1 = "";
            _datti2 = "";
            _datti3 = "";
            _txtlastfield = "";
        }

        public OldGLO(string constring, string id)
        {
            this.Spill_ID = id;
            SearchGLOBaseReportDataByID(constring);
        }

        #endregion
        #region Search Methods

        public void SearchGLOBaseReportDataByID(string constring)
        {
            string strsql = "SELECT * FROM oldglo WHERE cntSpillId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Spill_ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.Spill_ID = rdr["cntSpillId"].ToString();
                        this.Drill = rdr["fDrill"].ToString();
                        this.Drill_Txt = rdr["txtDrilltxt"].ToString();
                        this.Report_Taken_By = rdr["txtReportTakenBy"].ToString();
                        this.Report_Party_Affiliation = rdr["txtReportPartyAffiliation"].ToString();
                        this.Report_Taken_Date = rdr["datReportTakenDate"].ToString();
                        this.Report_Taken_Time = rdr["datReportTakenTime"].ToString();
                        this.Notification_Agency = rdr["txtNotificationAgency"].ToString();
                        this.Discharge_Reported_By = rdr["txtDischargeReportedBy"].ToString();
                        this.Discharged_Phone_1 = rdr["txtDischargedPhone1"].ToString();
                        this.Discharged_Phone_2 = rdr["txtDischargedPhone2"].ToString();
                        this.Discharge_Date = rdr["datDischargeDate"].ToString();
                        this.Discharge_Time = rdr["datDischargeTime"].ToString();
                        this.Material_1 = rdr["txtMaterial1"].ToString();
                        this.Material_2 = rdr["txtMaterial2"].ToString();
                        this.Material_3 = rdr["txtMaterial3"].ToString();
                        this.Material_4 = rdr["txtMaterial4"].ToString();
                        this.Material_5 = rdr["txtMaterial5"].ToString();
                        this.CASUN_1 = rdr["dblCASUN1"].ToString();
                        this.CASUN_2 = rdr["dblCASUN2"].ToString();
                        this.CASUN_3 = rdr["dblCASUN3"].ToString();
                        this.CASUN_4 = rdr["dblCASUN4"].ToString();
                        this.CASUN_5 = rdr["dblCASUN5"].ToString();
                        this.Amount_Spilled_1=rdr["dblAmtSpilled1"].ToString();
                        this.Amount_Spilled_2=rdr["dblAmtSpilled1"].ToString();
                        this.Amount_Spilled_3 = rdr["dblAmtSpilled3"].ToString();
                        this.Amount_Spilled_4 = rdr["dblAmtSpilled4"].ToString();
                        this.Amount_Spilled_5 = rdr["dblAmtSpilled5"].ToString();
                        this.Unit_Recovered_1 = rdr["txtUnitRecovered1"].ToString();
                        this.Unit_Recovered_2 = rdr["txtUnitRecovered2"].ToString();
                        this.Unit_Recovered_3 = rdr["txtUnitRecovered3"].ToString();
                        this.Unit_Recovered_4 = rdr["txtUnitRecovered4"].ToString();
                        this.Unit_Recovered_5 = rdr["txtUnitRecovered5"].ToString();
                        this.Spill_County = rdr["wSpiillCounty"].ToString();
                        this.Origin = rdr["wOrigin"].ToString();
                        this.Spill_In_Water = rdr["wSpillInWater"].ToString();
                        this.Spill_Air_Release = rdr["fSpillAirRelease"].ToString();
                        this.Coastal_Water = rdr["fCoastalWater"].ToString();
                        this.Land = rdr["fLand"].ToString();
                        this.Spill_Receiving_Water = rdr["txtSpillReceivingWater"].ToString();
                        this.Spill_Amount_In_Water = rdr["dblSpillAmountInWater"].ToString();
                        this.Spill_Amount_In_Water_Units = rdr["txtSpillAmountInWaterUnits"].ToString();
                        this.Spill_Location = rdr["memSpillLocation"].ToString();
                        this.RRC_Lease_Number = rdr["dblRRCLeaseNumber"].ToString();
                        this.RRC_Lease_Name = rdr["txtRRCLeaseName"].ToString();
                        this.RRC_Field_Name = rdr["txtRRCFieldName"].ToString();
                        this.Land_Owner = rdr["txtLandOwner"].ToString();
                        this.Actions_Taken_Clean_Up_Status = rdr["memActionsTakenCleanUpStatus"].ToString();
                        this.NRC_Number = rdr["txtNRCNumber"].ToString();
                        this.Agency_Name_1 = rdr["txtAgencyName1"].ToString();
                        this.Agency_Name_2 = rdr["txtAgencyName2"].ToString();
                        this.Agency_Name_3 = rdr["txtAgencyName3"].ToString();
                        this.Date_1 = rdr["datDate1"].ToString();
                        this.Date_2 = rdr["datDate2"].ToString();
                        this.Date_3 = rdr["datDate3"].ToString();
                        this.Where_1 = rdr["txtWhere1"].ToString();
                        this.Where_2 = rdr["txtWhere2"].ToString();
                        this.Where_3 = rdr["txtWhere3"].ToString();
                        this.Who_1 = rdr["txtWho1"].ToString();
                        this.Who_2 = rdr["txtWho2"].ToString();
                        this.Who_3 = rdr["txtWho3"].ToString();
                        this.Time_1 = rdr["datTime1"].ToString();
                        this.Time_2 = rdr["datTime2"].ToString();
                        this.Time_3 = rdr["datTime3"].ToString();
                        this.Spiller = rdr["txtSpiller"].ToString();
                        this.Spiller_Address = rdr["txtSpillerAddress"].ToString();
                        this.Spiller_City = rdr["txtSpillerCity"].ToString();
                        this.Spiller_State = rdr["txtSpillerState"].ToString();
                        this.Spiller_Zip_Code = rdr["txtSpillerZipCode"].ToString();
                        this.Spiller_Contact = rdr["txtSpillerContact"].ToString();
                        this.Spiller_Contact_Phone = rdr["txtSpillerContactPhone"].ToString();
                        this.Comments = rdr["memComments"].ToString();
                        this.Agcy_Name_1 = rdr["txtAgcyName1"].ToString();
                        this.Agcy_Name_2 = rdr["txtAgcyName2"].ToString();
                        this.Agcy_Name_3 = rdr["txtAgcyName3"].ToString();
                        this.D1 = rdr["datD1"].ToString(); 
                        this.D2 = rdr["datD2"].ToString();
                        this.D3 = rdr["datD3"].ToString();
                        this.Whr1 = rdr["txtWhr1"].ToString();
                        this.Whr2 = rdr["txtWhr2"].ToString();
                        this.Whr3 = rdr["txtWhr3"].ToString();
                        this.W1 = rdr["txtW1"].ToString();
                        this.W2 = rdr["txtW2"].ToString();
                        this.W3 = rdr["txtW3"].ToString();
                        this.Ti1 = rdr["datTi1"].ToString();
                        this.Ti2 = rdr["datTi2"].ToString();
                        this.Ti3 = rdr["datTi3"].ToString();
                        this.Last_Field = rdr["txtLastField"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
