using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace ChemicalLibrary

{
    public static class Update
    {
 
        #region ChemicalReporter

        public static void UpdateAvailableSpillIds(string constring, AvailableSpillID a)
        {
            string strsql = "UPDATE availablespillids SET available=@a, usedBy=@ub, WHERE Id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", a.ID);
                    cmd.Parameters.AddWithValue("@a", a.Available);
                    cmd.Parameters.AddWithValue("@ub", a.Used_By);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCompanyInformation(string constring, CompanyInformation c)
        {
            string strsql = "UPDATE companyinformation SET name=@n WHERE id=@id";
            using(SqlConnection cn=new SqlConnection(constring))
            {
                cn.Open();
                using(SqlCommand cmd=new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", c.ID);
                    cmd.Parameters.AddWithValue("@n", c.Name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateGeneralIncidentEdits(string constring, GeneralIncidentEdits g)
        {
            string strsql = "UPDATE generalincidentedits SET username=@u, editdate=@e, numberofedits=@n WHERE id=@i";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@i", g.ID);
                    cmd.Parameters.AddWithValue("@u", g.Username);
                    cmd.Parameters.AddWithValue("@e", g.Edit_Date);
                    cmd.Parameters.AddWithValue("@n", g.Number_Of_Edits);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateGeneralIncidentIDs(string constring, GeneralIncidentIDs g)
        {
            string strsql = "UPDATE generalincidentids SET available=@a, [user]=@u WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", g.ID);
                    cmd.Parameters.AddWithValue("@a", g.Available);
                    cmd.Parameters.AddWithValue("@u", g.User);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateGeneralIncidentReportData(string constring, GeneralIncidentReportData g)
        {
            string strsql = "UPDATE generalincidentreportdata SET ErsOperator=@eo, Date=@d, Time=@t, CallersName=@cn, CallersPhone=@cp, CallersAffiliation=@ca, CallersFaxOrEmail=@cfoe, IncidentStreet=@istr, IncidentCity=@icit, IncidentState=@ista, IncidentCountry=@icou, IncidentDate=@idat, IncidentTime=@it, IncidentTimeZone=@itz, MaterialName=@mn, ProductNumber=@pnum, QuantitySpilled=@qs, CleanUpCrewReqs=@cucr, AgenciesOnSite=@aos, AccidentOrDeliberate=@aod, IncidentDetails=@idet, InvolveFire=@if, WhereDidYouGetOurNumber=@wdygon, SubscribersName=@sn, SubscriberMIS=@sm, SpillOrExposure=@soe, TypeOfExposure=@toe, NumOfCasualties=@noc, NumOfInjuries=@noi, MedPersonnelName=@mpn, PatientName=@pn, PatientCondition=@pc, HospitalClinicLocation=@hcl, EpaRegNo=@ern, StatusOfRelease=@sor, DispersionOfMsdsInfo=@domi, ReviewedBy=@rb, ReviewedDate=@rd, SentDate=@sd, Comments=@c, DateChanged=@datechanged, Username=@username, IncidentZipCode=@izc, ReportType=@rt, CallersPhoneExt=@cpe WHERE IncidentId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", g.Incident_ID);
                    cmd.Parameters.AddWithValue("@eo", g.Ers_Operator);
                    cmd.Parameters.AddWithValue("@d", g.Date);
                    cmd.Parameters.AddWithValue("@t", g.Time);
                    cmd.Parameters.AddWithValue("@cn", g.Callers_Name);
                    cmd.Parameters.AddWithValue("@cp", g.Callers_Phone);
                    cmd.Parameters.AddWithValue("@ca", g.Callers_Affiliation);
                    cmd.Parameters.AddWithValue("@cfoe", g.Callers_Fax_Or_Email);
                    cmd.Parameters.AddWithValue("@istr", g.Incident_Street);
                    cmd.Parameters.AddWithValue("@icit", g.Incident_City);
                    cmd.Parameters.AddWithValue("@ista", g.Incident_State);
                    cmd.Parameters.AddWithValue("@icou", g.Incident_Country);
                    cmd.Parameters.AddWithValue("@idat", g.Incident_Date);
                    cmd.Parameters.AddWithValue("@it", g.Incident_Time);
                    cmd.Parameters.AddWithValue("@itz", g.Incident_Time_Zone);
                    cmd.Parameters.AddWithValue("@mn", g.Material_Name);
                    cmd.Parameters.AddWithValue("@pnum", g.Product_Number);
                    cmd.Parameters.AddWithValue("@qs", g.Quantity_Spilled);
                    cmd.Parameters.AddWithValue("@cucr", g.Cleanup_Crew_Requirements);
                    cmd.Parameters.AddWithValue("@aos", g.Agencies_On_Site);
                    cmd.Parameters.AddWithValue("@aod", g.Accident_Or_Deliberate);
                    cmd.Parameters.AddWithValue("@idet", g.Incident_Details);
                    cmd.Parameters.AddWithValue("@if", g.Involve_Fire);
                    cmd.Parameters.AddWithValue("@wdygon", g.Where_Did_You_Get_Our_Number);
                    cmd.Parameters.AddWithValue("@sn", g.Subscribers_Name);
                    cmd.Parameters.AddWithValue("@sm", g.Subscribers_MIS);
                    cmd.Parameters.AddWithValue("@soe", g.Spill_Or_Exposure);
                    cmd.Parameters.AddWithValue("@toe", g.Type_Of_Exposure);
                    cmd.Parameters.AddWithValue("@noc", g.Num_Of_Casualties);
                    cmd.Parameters.AddWithValue("@noi", g.Num_Of_Injuries);
                    cmd.Parameters.AddWithValue("@mpn", g.Med_Personnel_Name);
                    cmd.Parameters.AddWithValue("@pn", g.Patient_Name);
                    cmd.Parameters.AddWithValue("@pc", g.Patient_Condition);
                    cmd.Parameters.AddWithValue("@hcl", g.Hospital_Clinic_Location);
                    cmd.Parameters.AddWithValue("@ern", g.Epa_Reg_No);
                    cmd.Parameters.AddWithValue("@sor", g.Status_Of_Release);
                    cmd.Parameters.AddWithValue("@domi", g.Dispersion_Of_Msds_Information);
                    cmd.Parameters.AddWithValue("@rb", g.Reviewed_By);
                    cmd.Parameters.AddWithValue("@rd", g.Reviewed_Date);
                    cmd.Parameters.AddWithValue("@sd", g.Sent_Date);
                    cmd.Parameters.AddWithValue("@c", g.Comments);
                    cmd.Parameters.AddWithValue("@datechanged", g.Date_Changed);
                    cmd.Parameters.AddWithValue("@username", g.Username);
                    cmd.Parameters.AddWithValue("@izc", g.Incident_Zip_Code);
                    cmd.Parameters.AddWithValue("@rt", g.Report_Type);
                    cmd.Parameters.AddWithValue("@cpe", g.Callers_Phone_Ext);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateGeneralIncidentPdf(string constring, GeneralIncidentPdf g)
        {
            string strsql = "UPDATE generalincidentpdf SET IncidentId=@iid, ErsOperator=@eo, Date=@d, Time=@t, CallersName=@cn, CallersPhone=@cp, CallersAffiliation=@ca, CallersFaxOrEmail=@cfoe, IncidentStreet=@istr, IncidentCity=@icit, IncidentState=@ista, IncidentCountry=@icou, IncidentDate=@idat, IncidentTime=@it, IncidentTimeZone=@itz, MaterialName=@mn, ProductNumber=@pnum, QuantitySpilled=@qs, CleanUpCrewReqs=@cucr, AgenciesOnSite=@aos, AccidentOrDeliberate=@aod, IncidentDetails=@idet, InvolveFire=@if, WhereDidYouGetOurNumber=@wdygon, SubscribersName=@sn, SubscriberMIS=@sm, SpillOrExposure=@soe, TypeOfExposure=@toe, NumOfCasualties=@noc, NumOfInjuries=@noi, MedPersonnelName=@mpn, PatientName=@pn, PatientCondition=@pc, HospitalClinicLocation=@hcl, EpaRegNo=@ern, StatusOfRelease=@sor, DispersionOfMsdsInfo=@domi, ReviewedBy=@rb, ReviewedDate=@rd, SentDate=@sd, Comments=@c, DateChanged=@datechanged, Username=@username WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", g.ID);
                    cmd.Parameters.AddWithValue("@iid", g.Incident_ID);
                    cmd.Parameters.AddWithValue("@eo", g.Ers_Operator);
                    cmd.Parameters.AddWithValue("@d", g.Date);
                    cmd.Parameters.AddWithValue("@t", g.Time);
                    cmd.Parameters.AddWithValue("@cn", g.Callers_Name);
                    cmd.Parameters.AddWithValue("@cp", g.Callers_Phone);
                    cmd.Parameters.AddWithValue("@ca", g.Callers_Affiliation);
                    cmd.Parameters.AddWithValue("@cfoe", g.Callers_Fax_Or_Email);
                    cmd.Parameters.AddWithValue("@istr", g.Incident_Street);
                    cmd.Parameters.AddWithValue("@icit", g.Incident_City);
                    cmd.Parameters.AddWithValue("@ista", g.Incident_State);
                    cmd.Parameters.AddWithValue("@icou", g.Incident_Country);
                    cmd.Parameters.AddWithValue("@idat", g.Incident_Date);
                    cmd.Parameters.AddWithValue("@it", g.Incident_Time);
                    cmd.Parameters.AddWithValue("@itz", g.Incident_Time_Zone);
                    cmd.Parameters.AddWithValue("@mn", g.Material_Name);
                    cmd.Parameters.AddWithValue("@pnum", g.Product_Number);
                    cmd.Parameters.AddWithValue("@qs", g.Quantity_Spilled);
                    cmd.Parameters.AddWithValue("@cucr", g.Cleanup_Crew_Requirements);
                    cmd.Parameters.AddWithValue("@aos", g.Agencies_On_Site);
                    cmd.Parameters.AddWithValue("@aod", g.Accident_Or_Deliberate);
                    cmd.Parameters.AddWithValue("@idet", g.Incident_Details);
                    cmd.Parameters.AddWithValue("@if", g.Involve_Fire);
                    cmd.Parameters.AddWithValue("@wdygon", g.Where_Did_You_Get_Our_Number);
                    cmd.Parameters.AddWithValue("@sn", g.Subscribers_Name);
                    cmd.Parameters.AddWithValue("@sm", g.Subscribers_MIS);
                    cmd.Parameters.AddWithValue("@soe", g.Spill_Or_Exposure);
                    cmd.Parameters.AddWithValue("@toe", g.Type_Of_Exposure);
                    cmd.Parameters.AddWithValue("@noc", g.Num_Of_Casualties);
                    cmd.Parameters.AddWithValue("@noi", g.Num_Of_Injuries);
                    cmd.Parameters.AddWithValue("@mpn", g.Med_Personnel_Name);
                    cmd.Parameters.AddWithValue("@pn", g.Patient_Name);
                    cmd.Parameters.AddWithValue("@pc", g.Patient_Condition);
                    cmd.Parameters.AddWithValue("@hcl", g.Hospital_Clinic_Location);
                    cmd.Parameters.AddWithValue("@ern", g.Epa_Reg_No);
                    cmd.Parameters.AddWithValue("@sor", g.Status_Of_Release);
                    cmd.Parameters.AddWithValue("@domi", g.Dispersion_Of_Msds_Information);
                    cmd.Parameters.AddWithValue("@rb", g.Reviewed_By);
                    cmd.Parameters.AddWithValue("@rd", g.Reviewed_Date);
                    cmd.Parameters.AddWithValue("@sd", g.Sent_Date);
                    cmd.Parameters.AddWithValue("@c", g.Comments);
                    cmd.Parameters.AddWithValue("@datechanged", g.Date_Changed);
                    cmd.Parameters.AddWithValue("@username", g.Username);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateGLOBaseReportData(string constring, GLOBaseReportData g)
        {
            string strsql = "UPDATE globasereportdata SET fDrill=@fd, txtDrilltxt=@tdt, txtReportTakenBy=@trtb, txtReportPartyAffiliation=@trpa, datReportTakenDate=@drtd, datReportTakenTime=@drtt, txtNotificationAgency=@tna, txtDischargeReportedBy=@tdrb, txtDischargedPhone1=@tdp1, txtDischargedPhone2=@tdp2, datDischargeDate=@ddd, datDischargeTime=@ddt, txtMaterial1=@tm1, dblCASUN1=@dc1, dblAmtSpilled1=@das1, txtUnitRecovered1=@tur1, txtMaterial2=@tm2, dblCASUN2=@dc2, dblAmtSpilled2=@das2, txtUnitRecovered2=@tur2, txtMaterial3=@tm3, dblCASUN3=@dc3, dblAmtSpilled3=@das3, txtUnitRecovered3=@tur3, txtMaterial4=@tm4, dblCASUN4=@dc4, dblAmtSpilled4=@das4, txtUnitRecovered4=@tur4, txtMaterial5=@tm5, dblCASUN5=@dc5, dblAmtSpilled5=@das5, txtUnitRecovered5=@tur5, wSpillCounty=@wsc, wOrigin=@wo, fSpillInWater=@fsiw, fSpillAirRelease=@fsar, fCoastalWater=@fcw, fLand=@fl, txtSpillReceivingWater=@tsrw, dblSpillAmountInWater=@dsaiw, txtSpillAmountInWaterUnits=@tsaiwu, memSpillLocation=@msl, dblRRCLeaseNumber=@drln, txtRRCLeaseName=@trln, txtRRCFieldName=@trfn, txtLandOwner=@tlo, memActionsTakenCleanUpStatus=@matcus, txtNRCNumber=@tnn, txtAgencyName1=@tagn1, txtAgencyName2=@tagn2, txtAgencyName3=@tagn3, datDate1=@dda1, datDate2=@dda2, datDate3=@dda3, txtWhere1=@twhe1, txtWhere2=@twhe2, txtWhere3=@twhe3, txtWho1=@twho1, txtWho2=@twho2, txtWho3=@twho3, datTime1=@dti1, datTime2=@dti2, datTime3=@dti3, txtSpiller=@ts, txtSpillerAddress=@tsa, txtSpillerCity=@tsc, txtSpillerState=@tss, txtSpillerZipCode=@tszc, txtSpillerContact=@tsco, txtSpillerContactPhone=@tscp, txtAgcyName1=@tan1, txtAgcyName2=@tan2, txtAgcyName3=@tan3, datD1=@dd1, datD2=@dd2, datD3=@dd3, txtWhr1=@twhr1, txtWhr2=@twhr2, txtWhr3=@twhr3, txtW1=@tw1, txtW2=@tw2, txtW3=@tw3, datTi1=@dt1, datTi2=@dt2, datTi3=@dt3, memComments=@tlf, DateSearch=@ds WHERE cntSpillId=@csi";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@csi", g.Spill_ID);
                    cmd.Parameters.AddWithValue("@fd", g.Drill);
                    cmd.Parameters.AddWithValue("@tdt", g.Drill_Txt);
                    cmd.Parameters.AddWithValue("@trtb", g.Report_Taken_By);
                    cmd.Parameters.AddWithValue("@trpa", g.Report_Party_Affiliation);
                    cmd.Parameters.AddWithValue("@drtd", g.Report_Taken_Date);
                    cmd.Parameters.AddWithValue("@drtt", g.Report_Taken_Time);
                    cmd.Parameters.AddWithValue("@tna", g.Notification_Agency);
                    cmd.Parameters.AddWithValue("@tdrb", g.Discharge_Reported_By);
                    cmd.Parameters.AddWithValue("@tdp1", g.Discharged_Phone_1);
                    cmd.Parameters.AddWithValue("@tdp2", g.Discharged_Phone_2);
                    cmd.Parameters.AddWithValue("@ddd", g.Discharge_Date);
                    cmd.Parameters.AddWithValue("@ddt", g.Discharge_Time);
                    cmd.Parameters.AddWithValue("@tm1", g.Material_1);
                    cmd.Parameters.AddWithValue("@tm2", g.Material_2);
                    cmd.Parameters.AddWithValue("@tm3", g.Material_3);
                    cmd.Parameters.AddWithValue("@tm4", g.Material_4);
                    cmd.Parameters.AddWithValue("@tm5", g.Material_5);
                    cmd.Parameters.AddWithValue("@dc1", g.CASUN_1);
                    cmd.Parameters.AddWithValue("@dc2", g.CASUN_2);
                    cmd.Parameters.AddWithValue("@dc3", g.CASUN_3);
                    cmd.Parameters.AddWithValue("@dc4", g.CASUN_4);
                    cmd.Parameters.AddWithValue("@dc5", g.CASUN_5);
                    cmd.Parameters.AddWithValue("@das1", g.Amount_Spilled_1);
                    cmd.Parameters.AddWithValue("@das2", g.Amount_Spilled_2);
                    cmd.Parameters.AddWithValue("@das3", g.Amount_Spilled_3);
                    cmd.Parameters.AddWithValue("@das4", g.Amount_Spilled_4);
                    cmd.Parameters.AddWithValue("@das5", g.Amount_Spilled_5);
                    cmd.Parameters.AddWithValue("@tur1", g.Unit_Recovered_1);
                    cmd.Parameters.AddWithValue("@tur2", g.Unit_Recovered_2);
                    cmd.Parameters.AddWithValue("@tur3", g.Unit_Recovered_3);
                    cmd.Parameters.AddWithValue("@tur4", g.Unit_Recovered_4);
                    cmd.Parameters.AddWithValue("@tur5", g.Unit_Recovered_5);
                    cmd.Parameters.AddWithValue("@wsc", g.Spill_County);
                    cmd.Parameters.AddWithValue("@wo", g.Origin);
                    cmd.Parameters.AddWithValue("@fsiw", g.Spill_In_Water);
                    cmd.Parameters.AddWithValue("@fsar", g.Spill_Air_Release);
                    cmd.Parameters.AddWithValue("@fcw", g.Coastal_Water);
                    cmd.Parameters.AddWithValue("@fl", g.Land);
                    cmd.Parameters.AddWithValue("@tsrw", g.Spill_Receiving_Water);
                    cmd.Parameters.AddWithValue("@dsaiw", g.Spill_Amount_In_Water);
                    cmd.Parameters.AddWithValue("@tsaiwu", g.Spill_Amount_In_Water_Units);
                    cmd.Parameters.AddWithValue("@msl", g.Spill_Location);
                    cmd.Parameters.AddWithValue("@drln", g.RRC_Lease_Number);
                    cmd.Parameters.AddWithValue("@trln", g.RRC_Lease_Name);
                    cmd.Parameters.AddWithValue("@trfn", g.RRC_Field_Name);
                    cmd.Parameters.AddWithValue("@tlo", g.Land_Owner);
                    cmd.Parameters.AddWithValue("@matcus", g.Actions_Taken_Clean_Up_Status);
                    cmd.Parameters.AddWithValue("@tnn", g.NRC_Number);
                    cmd.Parameters.AddWithValue("@tagn1", g.Agency_Name_1);
                    cmd.Parameters.AddWithValue("@tagn2", g.Agency_Name_2);
                    cmd.Parameters.AddWithValue("@tagn3", g.Agency_Name_3);
                    cmd.Parameters.AddWithValue("@dda1", g.Date_1);
                    cmd.Parameters.AddWithValue("@dda2", g.Date_2);
                    cmd.Parameters.AddWithValue("@dda3", g.Date_3);
                    cmd.Parameters.AddWithValue("@twhe1", g.Where_1);
                    cmd.Parameters.AddWithValue("@twhe2", g.Where_2);
                    cmd.Parameters.AddWithValue("@twhe3", g.Where_3);
                    cmd.Parameters.AddWithValue("@twho1", g.Who_1);
                    cmd.Parameters.AddWithValue("@twho2", g.Who_2);
                    cmd.Parameters.AddWithValue("@twho3", g.Who_3);
                    cmd.Parameters.AddWithValue("@dti1", g.Time_1);
                    cmd.Parameters.AddWithValue("@dti2", g.Time_2);
                    cmd.Parameters.AddWithValue("@dti3", g.Time_3);
                    cmd.Parameters.AddWithValue("@ts", g.Spiller);
                    cmd.Parameters.AddWithValue("@tsa", g.Spiller_Address);
                    cmd.Parameters.AddWithValue("@tsc", g.Spiller_City);
                    cmd.Parameters.AddWithValue("@tss", g.Spiller_State);
                    cmd.Parameters.AddWithValue("@tszc", g.Spiller_Zip_Code);
                    cmd.Parameters.AddWithValue("@tsco", g.Spiller_Contact);
                    cmd.Parameters.AddWithValue("@tscp", g.Spiller_Contact_Phone);
                    cmd.Parameters.AddWithValue("@tan1", g.Agcy_Name_1);
                    cmd.Parameters.AddWithValue("@tan2", g.Agcy_Name_2);
                    cmd.Parameters.AddWithValue("@tan3", g.Agcy_Name_3);
                    cmd.Parameters.AddWithValue("@dd1", g.D1);
                    cmd.Parameters.AddWithValue("@dd2", g.D2);
                    cmd.Parameters.AddWithValue("@dd3", g.D3);
                    cmd.Parameters.AddWithValue("@twhr1", g.Whr1);
                    cmd.Parameters.AddWithValue("@twhr2", g.Whr2);
                    cmd.Parameters.AddWithValue("@twhr3", g.Whr3);
                    cmd.Parameters.AddWithValue("@tw1", g.W1);
                    cmd.Parameters.AddWithValue("@tw2", g.W2);
                    cmd.Parameters.AddWithValue("@tw3", g.W3);
                    cmd.Parameters.AddWithValue("@dt1", g.Ti1);
                    cmd.Parameters.AddWithValue("@dt2", g.Ti2);
                    cmd.Parameters.AddWithValue("@dt3", g.Ti3);
                    cmd.Parameters.AddWithValue("@tlf", g.Last_Field);
                    cmd.Parameters.AddWithValue("@ds", g.Date_Search);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdatGLOCountyList(string constring, GLOCountyList g)
        {
            string strsql = "UPDATE glocountylist SET countyName=@cn, countyGLOVoiceNumber=@cgvn, countyGLORegionNumber=@cgrn, countyGLORegionCity=@cgrc, countyGLOBeeperNumber=@cgbn, countyRRCNumber=@crn, countyRRCDistrictNumber=@crdn, countyRRCDistrictCity=@crdc, countyTNRCCNumber=@ctn, countyTNRCCDistrictNumber=@ctdn, countyTNRCCDistrictCity=@ctdc WHERE countyCode=@cc";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@cc", g.County_Code);
                    cmd.Parameters.AddWithValue("@cn", g.County_Name);
                    cmd.Parameters.AddWithValue("@cgvn", g.County_GLO_Voice_Number);
                    cmd.Parameters.AddWithValue("@cgrn", g.County_GLO_Region_Number);
                    cmd.Parameters.AddWithValue("@cgrc", g.County_GLO_Region_City);
                    cmd.Parameters.AddWithValue("@cgbn", g.County_GLO_Beeper_Number);
                    cmd.Parameters.AddWithValue("@crn", g.County_RRC_Number);
                    cmd.Parameters.AddWithValue("@crdn", g.County_RRC_District_Number);
                    cmd.Parameters.AddWithValue("@crdc", g.County_RRC_District_City);
                    cmd.Parameters.AddWithValue("@ctn", g.County_TNRCC_Number);
                    cmd.Parameters.AddWithValue("@ctdn", g.County_TNRCC_District_Number);
                    cmd.Parameters.AddWithValue("@ctdc", g.County_TNRCC_District_City);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateGLOEmails(string constring, GLOEmails g)
        {
            string strsql = "UPDATE gloemails SET name=@n, emailgroup=@eg, email01=@e01, email02=@e02, email03=@e03, email04=@e04, email05=@e05, email06=@e06, email07=@e07, email08=@e08, email09=@e09, email10=@e10 WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", g.ID);
                    cmd.Parameters.AddWithValue("@n", g.Name);
                    cmd.Parameters.AddWithValue("@eg", g.Email_Group);
                    cmd.Parameters.AddWithValue("@e01", g.Email_01);
                    cmd.Parameters.AddWithValue("@e02", g.Email_02);
                    cmd.Parameters.AddWithValue("@e03", g.Email_03);
                    cmd.Parameters.AddWithValue("@e04", g.Email_04);
                    cmd.Parameters.AddWithValue("@e05", g.Email_05);
                    cmd.Parameters.AddWithValue("@e06", g.Email_06);
                    cmd.Parameters.AddWithValue("@e07", g.Email_07);
                    cmd.Parameters.AddWithValue("@e08", g.Email_08);
                    cmd.Parameters.AddWithValue("@e09", g.Email_09);
                    cmd.Parameters.AddWithValue("@e10", g.Email_10);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateGLOIDs(string constring, GLOID g)
        {
            string strsql = "UPDATE gloids SET available=@a, [user]=@u WHERE id=@i";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@i", g.ID);
                    cmd.Parameters.AddWithValue("@a", g.Available);
                    cmd.Parameters.AddWithValue("@u", g.User);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateGLOLastID(string constring, GLOLastID g)
        {
            string strsql = "UPDATE glolastid SET reportid=@ri WHERE id=@i";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@i", g.ID);
                    cmd.Parameters.AddWithValue("@ri", g.Report_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateKnowlegeBase(string constring, Knowlegebase k)
        {
            string strsql = "UPDATE knowledgebase SET title=@t, body=@b, link=@l WHERE knowledgebase_id=@kid";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@kid", k.Knowledgebase_ID);
                    cmd.Parameters.AddWithValue("@t", k.Title);
                    cmd.Parameters.AddWithValue("@b", k.Body);
                    cmd.Parameters.AddWithValue("@l", k.Link);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateMODRequests(string constring, MODRequest m)
        {
            string strsql = "UPDATE modrequests SET ersooperator=@eo, companyname=@cn, nameofcaller=@noc, phone=@ph, fax=@f, email=@em,sendingmethod=@sm, modclient=@mc, datereceived=@dr, datefulfilled=@df, comments=@c, prodnane1=@pro1, manu1=@m1, qty1=@q1, locatedvia1=@lv1, prodname2=@pro2, manu2=@m2, qty2=@q2, locatedvia2=@lv2, prodname3=@pro3, manu3=@m3= qty3=@q3, locatedvia3=@lv3, prodname4=@pro4, manu4=@m4, qty4=@q4, locatedvia4=@lv4, prodname5=@pro5, manu5=@m5, qty5=@q5, locatedvia5=@lv5, prodname6=@pro6, manu6=@m6, qty6=@q6, locatedvia6=@lv6, prodname7=@pro7, manu7=@m7, qty7=@q7, locatedvia7=@lv7, prodname8=@pro8, manu8=@m8, qty8=@q8, locatedvia8=@lv8, prodname9=@pro9, manu9=@m9, qty9=@q9, locatedvia9=@lv9, prodname10=@pro10, manu10=@m10, qty10=@q10, locatedvia10=@lv10, totalcost=@tc, price1=@p1, price2=@p2, price3=@p3, price4=@p4, price5=@p5, price6=@p6, price7=@p7, price8=@p8, price9=2p9, price10=@p10, totalqty=@tq, monthreceived=@mr, yearreceived=@yr WHERE modrequestid=@mid";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@mid", m.MOD_Request_ID);
                    cmd.Parameters.AddWithValue("@eo", m.Ers_Operator);
                    cmd.Parameters.AddWithValue("@cn", m.Company_Name);
                    cmd.Parameters.AddWithValue("@noc", m.Name_Of_Caller);
                    cmd.Parameters.AddWithValue("@ph", m.Phone);
                    cmd.Parameters.AddWithValue("@e", m.Ext);
                    cmd.Parameters.AddWithValue("@f", m.Fax);
                    cmd.Parameters.AddWithValue("@em", m.Email);
                    cmd.Parameters.AddWithValue("@sm", m.Sending_Method);
                    cmd.Parameters.AddWithValue("@mc", m.MOD_Client);
                    cmd.Parameters.AddWithValue("@dr", m.Date_Received);
                    cmd.Parameters.AddWithValue("@df", m.Date_Fulfilled);
                    cmd.Parameters.AddWithValue("@c", m.Comments);
                    cmd.Parameters.AddWithValue("@pro1", m.Product_Name_1);
                    cmd.Parameters.AddWithValue("@pro2", m.Product_Name_2);
                    cmd.Parameters.AddWithValue("@pro3", m.Product_Name_3);
                    cmd.Parameters.AddWithValue("@pro4", m.Product_Name_4);
                    cmd.Parameters.AddWithValue("@pro5", m.Product_Name_5);
                    cmd.Parameters.AddWithValue("@pro6", m.Product_Name_6);
                    cmd.Parameters.AddWithValue("@pro7", m.Product_Name_7);
                    cmd.Parameters.AddWithValue("@pro8", m.Product_Name_8);
                    cmd.Parameters.AddWithValue("@pro9", m.Product_Name_9);
                    cmd.Parameters.AddWithValue("@pro10", m.Product_Name_10);
                    cmd.Parameters.AddWithValue("@m1", m.Manu_1);
                    cmd.Parameters.AddWithValue("@m2", m.Manu_2);
                    cmd.Parameters.AddWithValue("@m3", m.Manu_3);
                    cmd.Parameters.AddWithValue("@m4", m.Manu_4);
                    cmd.Parameters.AddWithValue("@m5", m.Manu_5);
                    cmd.Parameters.AddWithValue("@m6", m.Manu_6);
                    cmd.Parameters.AddWithValue("@m7", m.Manu_7);
                    cmd.Parameters.AddWithValue("@m8", m.Manu_8);
                    cmd.Parameters.AddWithValue("@m9", m.Manu_9);
                    cmd.Parameters.AddWithValue("@m10", m.Manu_10);
                    cmd.Parameters.AddWithValue("@q1", m.Qty_1);
                    cmd.Parameters.AddWithValue("@q2", m.Qty_2);
                    cmd.Parameters.AddWithValue("@q3", m.Qty_3);
                    cmd.Parameters.AddWithValue("@q4", m.Qty_4);
                    cmd.Parameters.AddWithValue("@q5", m.Qty_5);
                    cmd.Parameters.AddWithValue("@q6", m.Qty_6);
                    cmd.Parameters.AddWithValue("@q7", m.Qty_7);
                    cmd.Parameters.AddWithValue("@q8", m.Qty_8);
                    cmd.Parameters.AddWithValue("@q9", m.Qty_9);
                    cmd.Parameters.AddWithValue("@q10", m.Qty_10);
                    cmd.Parameters.AddWithValue("@lv1", m.Located_Via_1);
                    cmd.Parameters.AddWithValue("@lv2", m.Located_Via_2);
                    cmd.Parameters.AddWithValue("@lv3", m.Located_Via_3);
                    cmd.Parameters.AddWithValue("@lv4", m.Located_Via_4);
                    cmd.Parameters.AddWithValue("@lv5", m.Located_Via_5);
                    cmd.Parameters.AddWithValue("@lv6", m.Located_Via_6);
                    cmd.Parameters.AddWithValue("@lv7", m.Located_Via_7);
                    cmd.Parameters.AddWithValue("@lv8", m.Located_Via_8);
                    cmd.Parameters.AddWithValue("@lv9", m.Located_Via_9);
                    cmd.Parameters.AddWithValue("@lv10", m.Located_Via_10);
                    cmd.Parameters.AddWithValue("@tc", m.Total_Cost);
                    cmd.Parameters.AddWithValue("@p1", m.Price_1);
                    cmd.Parameters.AddWithValue("@p2", m.Price_2);
                    cmd.Parameters.AddWithValue("@p3", m.Price_3);
                    cmd.Parameters.AddWithValue("@p4", m.Price_4);
                    cmd.Parameters.AddWithValue("@p5", m.Price_5);
                    cmd.Parameters.AddWithValue("@p6", m.Price_6);
                    cmd.Parameters.AddWithValue("@p7", m.Price_7);
                    cmd.Parameters.AddWithValue("@p8", m.Price_8);
                    cmd.Parameters.AddWithValue("@p9", m.Price_9);
                    cmd.Parameters.AddWithValue("@p10", m.Price_10);
                    cmd.Parameters.AddWithValue("@tq", m.Total_Qty);
                    cmd.Parameters.AddWithValue("@mr", m.MOD_Client);
                    cmd.Parameters.AddWithValue("@yr", m.Year_Received);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateOldGLO(string constring, OldGLO g)
        {
            string strsql = "UPDATE oldglo SET fDrill=@fd, txtDrilltxt=@tdt, txtReportTakenBy=@trtb, txtReportPartyAffiliation=@trpa, datReportTakenDate=@drtd, datReportTakenTime=@drtt, txtNotificationAgency=@tna, txtDischargeReportedBy=@tdrb, txtDischargedPhone1=@tdp1, txtDischargedPhone2=@tdp2, datDischargeDate=@ddd, datDischargeTime=@ddt, txtMaterial1=@tm1, dblCASUN1=@dc1, dblAmountSpilled1=@das1, txtUnitRecovered1=@tur1, txtMateial2=@tm2, dblCASUN2=@dc2, dblAmountSpilled2=@das2, txtUnitRecovered2=@tur2, txtMaterial3=@tm3, dblCASUN3, dblAmountSpilled3=@das3, txtUnitRecovered3=@tur3, txtMaterial4=@tm4, dblCASUN4=@dc4, dblAmountSpilled4=@das4, txtUnitRecovered4=@tur4, txtMaterial5=@tm5, dblCASUN5=@dc5, dblAmountSpilled5=@das5, txtUnitRecovered5=@tur5, wSpillCounty=@wsc, wOrigin=@wo, fSpillInWater=@fsiw, fSpillAirRelease=@fsar, fCoastalWater=@fcw, fLand=@fl, txtSpillReceivingWater=@fsrw, dblSpillAmountInWater=@dsaiw, txtSpillAmountInWaterUnits=@tsaiwu, memSpillLocation=@msl, dblRRCLeaseNumber=@drln, txtRRCLeaseName=@trln, txtRRCFieldName=@trfn, txtLandOwner=@tlo, memActionsTakenCleanUpStatus=@matcus, txtNRCNumber=@tnn, txtAgencyName1=@tagn1, txtAgencyName2=@tagn2, txtAgencyName3=@tagn3, datDate1=@dda1, datDate2=@dda2, datDate3=@dda3, txtWhere1=@twhe1, txtWhere2=@twhe2, txtWhere3=@twhe3, txtWho1=@twho1, txtWho2=@twho2, txtWho3=@twho3, datTime1=@dti1, datTime2=@dti2, datTime3=@dti3, txtSpiller=@ts, txtSpillerAddress=@tsa, txtSpillerCity=@tsc, txtSpillerState=@tss, txtSpillerZipCode=@tszc, txtSpillerContact=@tsco, txtSpillerContactPhone=@tscp, memComments=@mc, txtAgcyName1=@tan1, txtAgcyName2=@tan2, txtAgcyName3=@tan3, datD1=@dd1, datD2=@dd2, datD3=@dd3, txtWhr1=@twhr1, txtWhr2=@twhr2, txtWhr3=@twhr3, txtW1=!tw1, txtW2=@tw2, txtW3=@tw3, datTi1=@dt1, datTi2=@dt2, datTi3=@datti3, txtLastField=@tlf WHERE cntSpillId=@csi";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@csi", g.Spill_ID);
                    cmd.Parameters.AddWithValue("@fd", g.Drill);
                    cmd.Parameters.AddWithValue("@tdt", g.Drill_Txt);
                    cmd.Parameters.AddWithValue("@trtv", g.Report_Taken_By);
                    cmd.Parameters.AddWithValue("@trpa", g.Report_Party_Affiliation);
                    cmd.Parameters.AddWithValue("@drtd", g.Report_Taken_Date);
                    cmd.Parameters.AddWithValue("@drtt", g.Report_Taken_Time);
                    cmd.Parameters.AddWithValue("@tna", g.Notification_Agency);
                    cmd.Parameters.AddWithValue("@tdrb", g.Discharge_Reported_By);
                    cmd.Parameters.AddWithValue("@tdp1", g.Discharged_Phone_1);
                    cmd.Parameters.AddWithValue("@tdp2", g.Discharged_Phone_2);
                    cmd.Parameters.AddWithValue("@ddd", g.Discharge_Date);
                    cmd.Parameters.AddWithValue("@ddt", g.Discharge_Time);
                    cmd.Parameters.AddWithValue("@tm1", g.Material_1);
                    cmd.Parameters.AddWithValue("@tm2", g.Material_2);
                    cmd.Parameters.AddWithValue("@tm3", g.Material_3);
                    cmd.Parameters.AddWithValue("@tm4", g.Material_4);
                    cmd.Parameters.AddWithValue("@tm5", g.Material_5);
                    cmd.Parameters.AddWithValue("@dc1", g.CASUN_1);
                    cmd.Parameters.AddWithValue("@dc2", g.CASUN_2);
                    cmd.Parameters.AddWithValue("@dc3", g.CASUN_3);
                    cmd.Parameters.AddWithValue("@dc4", g.CASUN_4);
                    cmd.Parameters.AddWithValue("@dc5", g.CASUN_5);
                    cmd.Parameters.AddWithValue("@das1", g.Amount_Spilled_1);
                    cmd.Parameters.AddWithValue("@das2", g.Amount_Spilled_2);
                    cmd.Parameters.AddWithValue("@das3", g.Amount_Spilled_3);
                    cmd.Parameters.AddWithValue("@das4", g.Amount_Spilled_4);
                    cmd.Parameters.AddWithValue("@das5", g.Amount_Spilled_5);
                    cmd.Parameters.AddWithValue("@tur1", g.Unit_Recovered_1);
                    cmd.Parameters.AddWithValue("@tur2", g.Unit_Recovered_2);
                    cmd.Parameters.AddWithValue("@tur3", g.Unit_Recovered_3);
                    cmd.Parameters.AddWithValue("@tur4", g.Unit_Recovered_4);
                    cmd.Parameters.AddWithValue("@tur5", g.Unit_Recovered_5);
                    cmd.Parameters.AddWithValue("@wsc", g.Spill_County);
                    cmd.Parameters.AddWithValue("@wo", g.Origin);
                    cmd.Parameters.AddWithValue("@fsiw", g.Spill_In_Water);
                    cmd.Parameters.AddWithValue("@fsar", g.Spill_Air_Release);
                    cmd.Parameters.AddWithValue("@fcw", g.Coastal_Water);
                    cmd.Parameters.AddWithValue("@fl", g.Land);
                    cmd.Parameters.AddWithValue("@tsrw", g.Spill_Receiving_Water);
                    cmd.Parameters.AddWithValue("@dsaiw", g.Spill_Amount_In_Water);
                    cmd.Parameters.AddWithValue("@tsaiwu", g.Spill_Amount_In_Water_Units);
                    cmd.Parameters.AddWithValue("@msl", g.Spill_Location);
                    cmd.Parameters.AddWithValue("@drln", g.RRC_Lease_Number);
                    cmd.Parameters.AddWithValue("@trln", g.RRC_Lease_Name);
                    cmd.Parameters.AddWithValue("@trfn", g.RRC_Field_Name);
                    cmd.Parameters.AddWithValue("@tlo", g.Land_Owner);
                    cmd.Parameters.AddWithValue("@matcus", g.Actions_Taken_Clean_Up_Status);
                    cmd.Parameters.AddWithValue("@tnn", g.NRC_Number);
                    cmd.Parameters.AddWithValue("@tagn1", g.Agency_Name_1);
                    cmd.Parameters.AddWithValue("@tagn2", g.Agency_Name_2);
                    cmd.Parameters.AddWithValue("@tagn3", g.Agency_Name_3);
                    cmd.Parameters.AddWithValue("@dda1", g.Date_1);
                    cmd.Parameters.AddWithValue("@dda2", g.Date_2);
                    cmd.Parameters.AddWithValue("@dda3", g.Date_3);
                    cmd.Parameters.AddWithValue("@twhe1", g.Where_1);
                    cmd.Parameters.AddWithValue("@twhe2", g.Where_2);
                    cmd.Parameters.AddWithValue("@twhe3", g.Where_3);
                    cmd.Parameters.AddWithValue("@twho1", g.Who_1);
                    cmd.Parameters.AddWithValue("@twho2", g.Who_2);
                    cmd.Parameters.AddWithValue("@twho3", g.Who_3);
                    cmd.Parameters.AddWithValue("@dti1", g.Time_1);
                    cmd.Parameters.AddWithValue("@dti2", g.Time_2);
                    cmd.Parameters.AddWithValue("@dti3", g.Time_3);
                    cmd.Parameters.AddWithValue("@ts", g.Spiller);
                    cmd.Parameters.AddWithValue("@tsa", g.Spiller_Address);
                    cmd.Parameters.AddWithValue("@tsc", g.Spiller_City);
                    cmd.Parameters.AddWithValue("@tss", g.Spiller_State);
                    cmd.Parameters.AddWithValue("@tszc", g.Spiller_Zip_Code);
                    cmd.Parameters.AddWithValue("@tsco", g.Spiller_Contact);
                    cmd.Parameters.AddWithValue("@tscp", g.Spiller_Contact_Phone);
                    cmd.Parameters.AddWithValue("@mc", g.Comments);
                    cmd.Parameters.AddWithValue("@tan1", g.Agcy_Name_1);
                    cmd.Parameters.AddWithValue("@tan2", g.Agcy_Name_2);
                    cmd.Parameters.AddWithValue("@tan3", g.Agcy_Name_3);
                    cmd.Parameters.AddWithValue("@dd1", g.D1);
                    cmd.Parameters.AddWithValue("@dd2", g.D2);
                    cmd.Parameters.AddWithValue("@dd3", g.D3);
                    cmd.Parameters.AddWithValue("@twhr1", g.Whr1);
                    cmd.Parameters.AddWithValue("@twhr2", g.Whr2);
                    cmd.Parameters.AddWithValue("@twhr3", g.Whr3);
                    cmd.Parameters.AddWithValue("@tw1", g.W1);
                    cmd.Parameters.AddWithValue("@tw2", g.W2);
                    cmd.Parameters.AddWithValue("@tw3", g.W3);
                    cmd.Parameters.AddWithValue("@dt1", g.Ti1);
                    cmd.Parameters.AddWithValue("@dt2", g.Ti2);
                    cmd.Parameters.AddWithValue("@dt3", g.Ti3);
                    cmd.Parameters.AddWithValue("@tlf", g.Last_Field);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateOtherIDs(string constring, OtherID o)
        {
            string strsql = "UPDATE otherids SET available=@a, [user]=@u WHERE id=@i";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@i", o.ID);
                    cmd.Parameters.AddWithValue("@a", o.Available);
                    cmd.Parameters.AddWithValue("@u", o.User);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateShellOilIncidentData(string constring, ShellOilIncidentData s)
        {
            string strsql = "UPDATE shelloilincidentdata SET ersop=@eo, date=@d, time=@t, callername1=@cn1, callername2=@cn2, callername3=@cn3, callerphone1=@cp1, callerphone2=@cp2, callerphone3=@cp3, callerext1=@ce1, callerext2=@ce2, callerext3=@ce3, calleraltphone1=@cap1, calleraltphone2=@cap2, calleraltphone3=@cap3, calleraltext1=@cae1, calleraltext2=@cae2, calleraltext3=@cae3, comments=@c, staffname=@sn, staffphone=@sp, staffext=@se, staffreporttime=@srt, stafftimezone=@stz, followupname1=@fn1, followupname2=@fn2, followupname3=@fn3, followupname4=@fn4, followupname5=@fn5, followuptime1=@ft1, followuptime2=@ft2, followuptime3=@ft3,followuptime4=@ft4,followuptime5=@ft5, followuptimezone1=@ftz1, followuptimezone2=@ftz2, followuptimezone3=@ftz3, followuptimezone4=@ftz4, followuptimezone5=@ftz5, followupphone1=@fp1, followupphone2=@fp2, followupphone3=@fp3,followupphone4=@fp4,followupphone5=@fp5, followupext1=@fe1, followupext2=@fe2, followupext3=@fe3, followupext4=@fe4,followupext5=@fe5, emailsent=@es, notes=@n WHERE  incid=@ii";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@ii", s.Inc_ID);
                    cmd.Parameters.AddWithValue("@eo", s.ERS_Operator);
                    cmd.Parameters.AddWithValue("@d", s.Date);
                    cmd.Parameters.AddWithValue("@t", s.Time);
                    cmd.Parameters.AddWithValue("@cn1", s.Caller_Name_1);
                    cmd.Parameters.AddWithValue("@cn2", s.Caller_Name_2);
                    cmd.Parameters.AddWithValue("@cn3", s.Caller_Name_3);
                    cmd.Parameters.AddWithValue("@cp1", s.Caller_Phone_1);
                    cmd.Parameters.AddWithValue("@cp2", s.Caller_Phone_2);
                    cmd.Parameters.AddWithValue("@cp3", s.Caller_Phone_3);
                    cmd.Parameters.AddWithValue("@ce1", s.Caller_Ext_1);
                    cmd.Parameters.AddWithValue("@ce2", s.Caller_Ext_2);
                    cmd.Parameters.AddWithValue("@ce3", s.Caller_Ext_3);
                    cmd.Parameters.AddWithValue("@cap1", s.Caller_Alt_Phone_1);
                    cmd.Parameters.AddWithValue("@cap2", s.Caller_Alt_Phone_2);
                    cmd.Parameters.AddWithValue("@cap3", s.Caller_Alt_Phone_3);
                    cmd.Parameters.AddWithValue("@cae1", s.Caller_Alt_Ext_1);
                    cmd.Parameters.AddWithValue("@cae2", s.Caller_Alt_Ext_2);
                    cmd.Parameters.AddWithValue("@cae3", s.Caller_Alt_Ext_3);
                    cmd.Parameters.AddWithValue("@c", s.Comments);
                    cmd.Parameters.AddWithValue("@sn", s.Staff_Name);
                    cmd.Parameters.AddWithValue("@sp", s.Staff_Phone);
                    cmd.Parameters.AddWithValue("@se", s.Staff_Ext);
                    cmd.Parameters.AddWithValue("@srt", s.Staff_Report_Time);
                    cmd.Parameters.AddWithValue("@stz", s.Staff_Time_Zone);
                    cmd.Parameters.AddWithValue("@fn1", s.Follow_Up_Name_1);
                    cmd.Parameters.AddWithValue("@fn2", s.Follow_Up_Name_2);
                    cmd.Parameters.AddWithValue("@fn3", s.Follow_Up_Name_3);
                    cmd.Parameters.AddWithValue("@fn4", s.Follow_Up_Name_4);
                    cmd.Parameters.AddWithValue("@fn5", s.Follow_Up_Name_5);
                    cmd.Parameters.AddWithValue("@ft1", s.Follow_Up_Time_1);
                    cmd.Parameters.AddWithValue("@ft2", s.Follow_Up_Time_2);
                    cmd.Parameters.AddWithValue("@ft3", s.Follow_Up_Time_3);
                    cmd.Parameters.AddWithValue("@ft4", s.Follow_Up_Time_4);
                    cmd.Parameters.AddWithValue("@ft5", s.Follow_Up_Time_5);
                    cmd.Parameters.AddWithValue("@ftz1", s.Follow_Up_Time_Zone_1);
                    cmd.Parameters.AddWithValue("@ftz2", s.Follow_Up_Time_Zone_2);
                    cmd.Parameters.AddWithValue("@ftz3", s.Follow_Up_Time_Zone_3);
                    cmd.Parameters.AddWithValue("@ftz4", s.Follow_Up_Time_Zone_4);
                    cmd.Parameters.AddWithValue("@ftz5", s.Follow_Up_Time_Zone_5);
                    cmd.Parameters.AddWithValue("@fp1", s.Follow_Up_Phone_1);
                    cmd.Parameters.AddWithValue("@fp2", s.Follow_Up_Phone_2);
                    cmd.Parameters.AddWithValue("@fp3", s.Follow_Up_Phone_3);
                    cmd.Parameters.AddWithValue("@fp4", s.Follow_Up_Phone_4);
                    cmd.Parameters.AddWithValue("@fp5", s.Follow_Up_Phone_5);
                    cmd.Parameters.AddWithValue("@fe1", s.Follow_Up_Ext_1);
                    cmd.Parameters.AddWithValue("@fe2", s.Follow_Up_Ext_2);
                    cmd.Parameters.AddWithValue("@fe3", s.Follow_Up_Ext_3);
                    cmd.Parameters.AddWithValue("@fe4", s.Follow_Up_Ext_4);
                    cmd.Parameters.AddWithValue("@fe5", s.Follow_Up_Ext_5);
                    cmd.Parameters.AddWithValue("@es", s.Email_Sent);
                    cmd.Parameters.AddWithValue("@n", s.Notes);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCleanshotIDs(string constring, CleanshotIDs c)
        {
            string strsql = "UPDATE cleanshotids SET available=@available, [user]=@user WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", c.ID);
                    cmd.Parameters.AddWithValue("@available", c.Available);
                    cmd.Parameters.AddWithValue("@user", c.User);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateTheoChemCleanShotIncidents(string constring, TheoChemCleanshotIncident t)
        {
            string strsql = "UPDATE theochemcleanshotincidents SET ersOp=@eo, rptDate=@rd, rptTime=@rt, callerName=@cn, callerPhone=@cp, callerAff=@ca, callerFaxEmail=@cfe, incStreet=@istr, incCity=@icit, incState=@ista, incCountry=@icou, incTimeZone=@itz, incDate=@id, incTime=@it, quest1=@q1, quest2Qty=@q2q, quest2Units=@q2u, quest3=@q3, quest4=@q4, quest5=@q5, quest6=@q6, quest7=@q7, quest8=@q8, quest9=@q9, quest10YesOrNo=@q10yon, quest10IfYesWhat=@q10iyw, quest11YesOrNo=@q11yon, quest11IfYesWhat=@q11iyw, quest12=@q12, quest13=@q13, quest14=@q14, quest15=@q15, quest16=@q16, quest17=@q17, additCommentsDetails=@acd, subName=@sn, subAdminContact=@sac, subPhone=@sp, subFax=@sf, subEmail=@se, subAddress=@sa, subCityStateZip=@scsz, emailsent=@es, comments=@comm, type=@type WHERE incidentId=@ii";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@ii", t.Incident_ID);
                    cmd.Parameters.AddWithValue("@eo", t.Ers_Operator);
                    cmd.Parameters.AddWithValue("@rd", t.Report_Date);
                    cmd.Parameters.AddWithValue("@rt", t.Report_Time);
                    cmd.Parameters.AddWithValue("@cn", t.Caller_Name);
                    cmd.Parameters.AddWithValue("@cp", t.Caller_Phone);
                    cmd.Parameters.AddWithValue("@ca", t.Caller_Affiliate);
                    cmd.Parameters.AddWithValue("@cfe", t.Caller_Fax_Email);
                    cmd.Parameters.AddWithValue("@istr", t.Incident_Street);
                    cmd.Parameters.AddWithValue("@icit", t.Incident_City);
                    cmd.Parameters.AddWithValue("@ista", t.Incident_State);
                    cmd.Parameters.AddWithValue("@icou", t.Incident_Country);
                    cmd.Parameters.AddWithValue("@itz", t.Incident_Time_Zone);
                    cmd.Parameters.AddWithValue("@id", t.Incident_Date);
                    cmd.Parameters.AddWithValue("@it", t.Incident_Time);
                    cmd.Parameters.AddWithValue("@q1", t.Question_1);
                    cmd.Parameters.AddWithValue("@q2q", t.Question_2_Quantity);
                    cmd.Parameters.AddWithValue("@q2u", t.Question_2_Units);
                    cmd.Parameters.AddWithValue("@q3", t.Question_3);
                    cmd.Parameters.AddWithValue("@q4", t.Question_4);
                    cmd.Parameters.AddWithValue("@q5", t.Question_5);
                    cmd.Parameters.AddWithValue("@q6", t.Question_6);
                    cmd.Parameters.AddWithValue("@q7", t.Question_7);
                    cmd.Parameters.AddWithValue("@q8", t.Question_8);
                    cmd.Parameters.AddWithValue("@q9", t.Question_9);
                    cmd.Parameters.AddWithValue("@q10yon", t.Question_10_Yes_Or_No);
                    cmd.Parameters.AddWithValue("@q10iyw", t.Question_10_IfYes_What);
                    cmd.Parameters.AddWithValue("@q11yon", t.Question_11_Yes_Or_No);
                    cmd.Parameters.AddWithValue("@q11iyw", t.Question_11_If_Yes_What);
                    cmd.Parameters.AddWithValue("@q12", t.Question_12);
                    cmd.Parameters.AddWithValue("@q13", t.Question_13);
                    cmd.Parameters.AddWithValue("@q14", t.Question_14);
                    cmd.Parameters.AddWithValue("@q15", t.Question_15);
                    cmd.Parameters.AddWithValue("@q16", t.Question_16);
                    cmd.Parameters.AddWithValue("@q17", t.Question_17);
                    cmd.Parameters.AddWithValue("@acd", t.Add_It_Comments_Details);
                    cmd.Parameters.AddWithValue("@sn", t.Sub_Name);
                    cmd.Parameters.AddWithValue("@sac", t.Sub_Administrative_Contact);
                    cmd.Parameters.AddWithValue("@sp", t.Sub_Phone);
                    cmd.Parameters.AddWithValue("@sf", t.Sub_Fax);
                    cmd.Parameters.AddWithValue("@se", t.Sub_Email);
                    cmd.Parameters.AddWithValue("@sa", t.Sub_Address);
                    cmd.Parameters.AddWithValue("@scsz", t.Sub_City_State_Zip);
                    cmd.Parameters.AddWithValue("@es", t.Email_Sent);
                    cmd.Parameters.AddWithValue("@comm", t.Comments);
                    cmd.Parameters.AddWithValue("@type", t.Type);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateTheoChemContactInformation(string constring, TheoChemContactInformation t)
        {
            string strsql = "UPDATE theochemcontactinformation SET name=@n, admincontact=@ac, phone=@p, fax=@f, email=@e, address=@a, citystatezip=@c WHERE contactid=@cid";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@cid", t.Contact_ID);
                    cmd.Parameters.AddWithValue("@n", t.Name);
                    cmd.Parameters.AddWithValue("@ac", t.Administrative_Contact);
                    cmd.Parameters.AddWithValue("@p", t.Phone);
                    cmd.Parameters.AddWithValue("@f", t.Fax);
                    cmd.Parameters.AddWithValue("@e", t.Email);
                    cmd.Parameters.AddWithValue("@a", t.Address);
                    cmd.Parameters.AddWithValue("@c", t.City_State_Zip);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateTickets(string constring, Ticket t)
        {
            string strsql = "UPDATE tickets SET status=@st, username=@u, subject=@su, description=@d WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", t.ID);
                    cmd.Parameters.AddWithValue("@st", t.Status);
                    cmd.Parameters.AddWithValue("@u", t.User_Name);
                    cmd.Parameters.AddWithValue("@su", t.Subject);
                    cmd.Parameters.AddWithValue("@d", t.Description);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCrestGeneralIncidents(string constring, CrestGeneralIncident c)
        {
            string strsql = "UPDATE crestgeneralincidents SET callername=@cn, callertitle=@ct, calleraffiliation=@ca, callerphonenumber=@cpn, incidentdate=@idate, incidentlocation=@iloc, incidentlatitude=@ilat, incidentlongitude=@ilong, incidentoccuron=@ioo, incidentnature=@inat, incidentdescription=@ides, involvedname1=@in1, involvedname2=@in2, involvedname3=@in3, involvedcell1=@ic1, involvedcell2=@ic2, involvedcell3=@ic3, involvedinjury1=@ii1, involvedinjury2=@ii2, involvedinjury3=@ii3, weatherconditions=@wc, impactedareas=@ia, impactedbodyofwater=@ibow, reporttakername=@rtn, reporttakeremail=@rte, ersname1=@en1, ersname2=@en2, ersname3=@en3, erscontactnumber1=@ecp1, erscontactnumber2=@ecp2, erscontactnumber3=@ecp3, erslocation1=@el1, erslocation2=@el2, erslocation3=@el3, dispatcheroremployee=@doe, contractororemployee=@coe, notify911=@n9, immediatesupport=@isup, transporttohospital=@tth, emergencyresponders=@er, fatalities=@fat, mediaonscene=@mos, incidentprivaterow=@ipr, incidenttriballand=@itl, incidentblmland=@ibl, incidentstateland=@isl, incidentaddress=@iadd, incidentcity=@icit, incidentstate=@ista, incidentcounty=@icou, incidentintersection=@iint, incidentfacilityname=@ifn, fireorexplosion=@foe, pipelinestrike=@ps, injury=@inj, illnessorexposure=@ill, vehicleaccident=@va, spillorrelease=@sor, theft=@t, agencyinspectionofvisit=@aiov, propertydamage=@pd, potentialhazardornearmiss=@phonm, landownercomplaint=@lo, impactstowater=@itw, landowner=@lown, incidenttime=@itim, incidenttimezone=@itimz, calleremail=@cemail, calldate=@cdate, calltime=@ctime, other=@other, ersoperator=@eop, equipmentorpeople=@eqop, numinjuries1=@noi1, numinjuries2=@noi2, numinjuries3=@noi3, none=@non, unknown=@unk, tractortrailer=@tt, equipment=@eq, dispatcheremployee=@dise, initials=@init, county=@coun, drill=@drill, Incident_Contractor_Or_Employee=@Incident_Contractor_Or_Employee, IndividualSafety=@IndividualSafety, WeaponReported=@WeaponReported, WeaponType=@WeaponType, wpviolence=@WPVoilence, FacilityOrProject=@FOP, RegionOrFacility=@ROF, ContractorName=@ConName, FacilityOrProjectSelection=@FOPSelection, NotificationDate=@nd, NotificationTime=@nt, PC_CWLocOrTransport=@PCLOC WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", c.ID);
                    cmd.Parameters.AddWithValue("@cn", c.Caller_Name);
                    cmd.Parameters.AddWithValue("@ct", c.Caller_Title);
                    cmd.Parameters.AddWithValue("@ca", c.Caller_Affiliation);
                    cmd.Parameters.AddWithValue("@cpn", c.Caller_Phone_Number);
                    cmd.Parameters.AddWithValue("@idate", c.Incident_Date);
                    cmd.Parameters.AddWithValue("@iloc", c.Incident_Location);
                    cmd.Parameters.AddWithValue("@ilat", c.Incident_Latitude);
                    cmd.Parameters.AddWithValue("@ilong", c.Incident_Longitude);
                    cmd.Parameters.AddWithValue("@ioo", c.Incident_Occured_On);
                    cmd.Parameters.AddWithValue("@inat", c.Incident_Nature);
                    cmd.Parameters.AddWithValue("@ides", c.Incident_Description);
                    cmd.Parameters.AddWithValue("@in1", c.Involved_Name_1);
                    cmd.Parameters.AddWithValue("@in2", c.Involved_Name_2);
                    cmd.Parameters.AddWithValue("@in3", c.Involved_Name_3);
                    cmd.Parameters.AddWithValue("@ic1", c.Involed_Cell_1);
                    cmd.Parameters.AddWithValue("@ic2", c.Involved_Cell_2);
                    cmd.Parameters.AddWithValue("@ic3", c.Involved_Cell_3);
                    cmd.Parameters.AddWithValue("@ii1", c.Involved_Injury_1);
                    cmd.Parameters.AddWithValue("@ii2", c.Involved_Injury_2);
                    cmd.Parameters.AddWithValue("@ii3", c.Involved_Injury_3);
                    cmd.Parameters.AddWithValue("@wc", c.Weather_Conditions);
                    cmd.Parameters.AddWithValue("@ia", c.Impacted_Areas);
                    cmd.Parameters.AddWithValue("@ibow", c.Impacted_Body_Of_Water);
                    cmd.Parameters.AddWithValue("@rtn", c.Report_Taker_Name);
                    cmd.Parameters.AddWithValue("@rte", c.Report_Taker_Email);
                    cmd.Parameters.AddWithValue("@en1", c.ERS_Name_1);
                    cmd.Parameters.AddWithValue("@en2", c.ERS_Name_2);
                    cmd.Parameters.AddWithValue("@en3", c.ERS_Name_3);
                    cmd.Parameters.AddWithValue("@ecp1", c.ERS_Contact_Number_1);
                    cmd.Parameters.AddWithValue("@ecp2", c.ERS_Contact_Number_2);
                    cmd.Parameters.AddWithValue("@ecp3", c.ERS_Contact_Number_3);
                    cmd.Parameters.AddWithValue("@el1", c.ERS_Location_1);
                    cmd.Parameters.AddWithValue("@el2", c.ERS_Location_2);
                    cmd.Parameters.AddWithValue("@el3", c.ERS_Location_3);
                    cmd.Parameters.AddWithValue("@n9", c.Notify_911);
                    cmd.Parameters.AddWithValue("@doe", c.Dispatcher_Or_Employee);
                    cmd.Parameters.AddWithValue("@coe", c.Contractor_Or_Employee);
                    cmd.Parameters.AddWithValue("@isup", c.Immediate_Support);
                    cmd.Parameters.AddWithValue("@tth", c.Transport_ToHospital);
                    cmd.Parameters.AddWithValue("@er", c.Emegency_Responders);
                    cmd.Parameters.AddWithValue("@fat", c.Fatalities);
                    cmd.Parameters.AddWithValue("@mos", c.Media_On_Scene);
                    cmd.Parameters.AddWithValue("@ipr", c.Incident_Private_ROW);
                    cmd.Parameters.AddWithValue("@itl", c.Incident_Tribal_Land);
                    cmd.Parameters.AddWithValue("@ibl", c.Incident_BLM_Land);
                    cmd.Parameters.AddWithValue("@isl", c.Incident_State_Land);
                    cmd.Parameters.AddWithValue("@iadd", c.Incident_Address);
                    cmd.Parameters.AddWithValue("@icit", c.Incident_City);
                    cmd.Parameters.AddWithValue("@ista", c.Incident_State);
                    cmd.Parameters.AddWithValue("@icou", c.Incident_County);
                    cmd.Parameters.AddWithValue("@iint", c.Incident_Intersection);
                    cmd.Parameters.AddWithValue("@ifn", c.Incident_Facility_Name);
                    cmd.Parameters.AddWithValue("@foe", c.Fire_Or_Explosion);
                    cmd.Parameters.AddWithValue("@ps", c.Pipeline_Strike);
                    cmd.Parameters.AddWithValue("@inj", c.Injury);
                    cmd.Parameters.AddWithValue("@ill", c.Illness_Or_Exposure);
                    cmd.Parameters.AddWithValue("@va", c.Vehicle_Accident);
                    cmd.Parameters.AddWithValue("@sor", c.Spill_Or_Release);
                    cmd.Parameters.AddWithValue("@t", c.Theft);
                    cmd.Parameters.AddWithValue("@aiov", c.Agency_Ispection_Of_Visit);
                    cmd.Parameters.AddWithValue("@pd", c.Property_Damage);
                    cmd.Parameters.AddWithValue("@phonm", c.Potential_hazard_Or_Near_Miss);
                    cmd.Parameters.AddWithValue("@lo", c.Landowner_Complaint);
                    cmd.Parameters.AddWithValue("@itw", c.Impacts_To_Water);
                    cmd.Parameters.AddWithValue("@lown", c.Landowner);
                    cmd.Parameters.AddWithValue("@itim", c.Incident_Time);
                    cmd.Parameters.AddWithValue("@itimz", c.Incident_Time_Zone);
                    cmd.Parameters.AddWithValue("@cemail", c.Caller_Email);
                    cmd.Parameters.AddWithValue("@cdate", c.Call_Date);
                    cmd.Parameters.AddWithValue("@ctime", c.Call_Time);
                    cmd.Parameters.AddWithValue("@other", c.Other);
                    cmd.Parameters.AddWithValue("@eop", c.ERS_Operator);
                    cmd.Parameters.AddWithValue("@eqop", c.Equipment_Or_People);
                    cmd.Parameters.AddWithValue("@noi1", c.Number_Of_Injuries_1);
                    cmd.Parameters.AddWithValue("@noi2", c.Number_Of_Injuries_2);
                    cmd.Parameters.AddWithValue("@noi3", c.Number_Of_Injuries_3);
                    cmd.Parameters.AddWithValue("@non", c.None);
                    cmd.Parameters.AddWithValue("@unk", c.Unknown);
                    cmd.Parameters.AddWithValue("@tt", c.Tractor_Trailer);
                    cmd.Parameters.AddWithValue("@eq", c.Equipment);
                    cmd.Parameters.AddWithValue("@dise", c.Dispatcher_Employee);
                    cmd.Parameters.AddWithValue("@init", c.Initials);
                    cmd.Parameters.AddWithValue("@coun", c.County);
                    cmd.Parameters.AddWithValue("@drill", c.Drill);
                    cmd.Parameters.AddWithValue("@Incident_Contractor_Or_Employee", c.Incident_Contractor_Or_Employee);
                    cmd.Parameters.AddWithValue("@IndividualSafety", c.IndividualSafety);
                    cmd.Parameters.AddWithValue("@WeaponReported", c.WeaponReported);
                    cmd.Parameters.AddWithValue("@WeaponType", c.WeaponType);
                    cmd.Parameters.AddWithValue("@WPVoilence", c.wpviolence);
                    cmd.Parameters.AddWithValue("@FOP", c.FacilityOrProject);
                    cmd.Parameters.AddWithValue("@ROF", c.RegionOrFacility);
                    cmd.Parameters.AddWithValue("@ConName", c.ContractorName);
                    cmd.Parameters.AddWithValue("@FOPSelection", c.FacilityOrProjectSelection);
                    cmd.Parameters.AddWithValue("@nd", c.NotificationDate);
                    cmd.Parameters.AddWithValue("@nt", c.NotificationTime);
                    cmd.Parameters.AddWithValue("@PCLOC", c.PC_CWLocOrTransport);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCrestGeneralLogInitials(string constring, int id, string init)
        {
            string strsql = "UPDATE crestgeneralincidents SET initials=@init WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@init", init);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCrestPiplineIncident(string constring, CrestPipelineIncident c)
        {
            string strsql = "UPDATE crestpiplineincidents SET county=@co, state=@st, distancefromtown=@dft, distancefromlandmark=@dfl, intersectionormilemarker=@iom, observing=@ob, seeinghearingsmelling=@shs, roworwellpad=@rowp, tanks=@ta, landowner=@lo, callername=@cn, callerphone=@cp, notify911=@n9, anyoneinjured=@ai, immediatedanger=@imd, temp=@te, windspeed=@ws, winddirection=@wd, weatherconditions=@wc, relationtoincident=@rti, safelywarn=@sw, name1=@n1, name2=@n2, name3=@n3, contactnumber1=@cn1, contactnumber2=@cn2, contactnumber3=@cn3, location1=@l1, location2=@l2, location3=@l3, leasewellname=@lwn, blackorwhitesmoke=@bows, flames=@f, hissing=@h, liquid=@l, oilysheen=@os, otherpipelinemarkers=@opm, rotteneggodor=@roe, vaporormist=@voom, directions=@dir, city=@cit, date=@dat, time=@tim, timezone=@timz, numofinjuries=@noi, reporttakername=@rtn, reporttakeremail=@rte, description=@desc, calleremail=@cemail, callertitle=@ctitle, calleraffiliation=@caff, name4=@n4, name5=@n5, contactnumber4=@cn4, contactnumber5=@cn5, location4=@l4, location5=@l5, calldate=@cd, calltime=@ct, ersoperator=@eop, initials=@init, NotificationDate=@nd, NotificationTime=@nt, Drill=@Drill WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", c.ID);
                    cmd.Parameters.AddWithValue("@co", c.County);
                    cmd.Parameters.AddWithValue("@st", c.State);
                    cmd.Parameters.AddWithValue("@dft", c.Distance_From_Town);
                    cmd.Parameters.AddWithValue("@dfl", c.Distance_From_Landmark);
                    cmd.Parameters.AddWithValue("@iom", c.Intersection_Or_Milemarker);
                    cmd.Parameters.AddWithValue("@ob", c.Observing);
                    cmd.Parameters.AddWithValue("@shs", c.Seeing_Hearing_Smelling);
                    cmd.Parameters.AddWithValue("@rowp", c.ROW_OR_Well_Pad);
                    cmd.Parameters.AddWithValue("@ta", c.Tanks);
                    cmd.Parameters.AddWithValue("@lo", c.Landowner);
                    cmd.Parameters.AddWithValue("@cn", c.Caller_Name);
                    cmd.Parameters.AddWithValue("@cp", c.Caller_Phone);
                    cmd.Parameters.AddWithValue("@n9", c.Notify_911);
                    cmd.Parameters.AddWithValue("@ai", c.Anyone_Injured);
                    cmd.Parameters.AddWithValue("@imd", c.Immediate_Danger);
                    cmd.Parameters.AddWithValue("@te", c.Temperature);
                    cmd.Parameters.AddWithValue("@ws", c.Wind_Speed);
                    cmd.Parameters.AddWithValue("@wd", c.Wind_Direction);
                    cmd.Parameters.AddWithValue("@wc", c.Weather_Conditions);
                    cmd.Parameters.AddWithValue("@rti", c.Relation_ToIncident);
                    cmd.Parameters.AddWithValue("@sw", c.Safely_Warn);
                    cmd.Parameters.AddWithValue("@n1", c.Name_1);
                    cmd.Parameters.AddWithValue("@n2", c.Name_2);
                    cmd.Parameters.AddWithValue("@n3", c.Name_3);
                    cmd.Parameters.AddWithValue("@cn1", c.Contact_Number_1);
                    cmd.Parameters.AddWithValue("@cn2", c.Contact_Number_2);
                    cmd.Parameters.AddWithValue("@cn3", c.Contact_Number_3);
                    cmd.Parameters.AddWithValue("@l1", c.Location_1);
                    cmd.Parameters.AddWithValue("@l2", c.Location_2);
                    cmd.Parameters.AddWithValue("@l3", c.Location_3);
                    cmd.Parameters.AddWithValue("@lwn", c.Lease_Well_Name);
                    cmd.Parameters.AddWithValue("@bows", c.Black_Or_White_Smoke);
                    cmd.Parameters.AddWithValue("@f", c.Flames);
                    cmd.Parameters.AddWithValue("@h", c.Hissing);
                    cmd.Parameters.AddWithValue("@l", c.Liquid);
                    cmd.Parameters.AddWithValue("@os", c.Oily_Sheen);
                    cmd.Parameters.AddWithValue("@opm", c.Other_Pipeline_Markers);
                    cmd.Parameters.AddWithValue("@roe", c.Rotten_Egg_Odor);
                    cmd.Parameters.AddWithValue("@voom", c.Vapor_Or_Mist); 
                    cmd.Parameters.AddWithValue("@dir", c.Directins);
                    cmd.Parameters.AddWithValue("@cit", c.City);
                    cmd.Parameters.AddWithValue("@dat", c.Date);
                    cmd.Parameters.AddWithValue("@tim", c.Time);
                    cmd.Parameters.AddWithValue("@timz", c.Time_Zone);
                    cmd.Parameters.AddWithValue("@noi", c.Number_Of_Injuries);
                    cmd.Parameters.AddWithValue("@rtn", c.Report_Taker_Name);
                    cmd.Parameters.AddWithValue("@rte", c.Report_Taker_Email);
                    cmd.Parameters.AddWithValue("@desc", c.Description);
                    cmd.Parameters.AddWithValue("@cemail", c.Caller_Email);
                    cmd.Parameters.AddWithValue("@ctitle", c.Caller_Title);
                    cmd.Parameters.AddWithValue("@caff", c.Caller_Affiliation);
                    cmd.Parameters.AddWithValue("@n4", c.Name_4);
                    cmd.Parameters.AddWithValue("@n5", c.Name_5);
                    cmd.Parameters.AddWithValue("@cn4", c.Contact_Number_4);
                    cmd.Parameters.AddWithValue("@cn5", c.Contact_Number_5);
                    cmd.Parameters.AddWithValue("@l4", c.Location_4);
                    cmd.Parameters.AddWithValue("@l5", c.Location_5);
                    cmd.Parameters.AddWithValue("@cd", c.Call_Date);
                    cmd.Parameters.AddWithValue("@ct", c.Call_Time);
                    cmd.Parameters.AddWithValue("@eop", c.ERS_Operator);
                    cmd.Parameters.AddWithValue("@init", c.Initials);
                    cmd.Parameters.AddWithValue("@nd", c.NotificationDate);
                    cmd.Parameters.AddWithValue("@nt", c.NotificationTime);
                    cmd.Parameters.AddWithValue("@Drill", c.Drill);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCrestPipelineLog(string constring, int id, string init)
        {
            string strsql = "UPDATE crestpiplineincidents SET initials=@init WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@init", init);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCrestERS(string constring, CrestERS c)
        {
            string strsql = "UPDATE cresters SET startdate=@sd, enddate=@ed, name=@na, phone=@ph, email=@em, location=@lo WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("id", c.ID);
                    cmd.Parameters.AddWithValue("@sd", c.Start_Date);
                    cmd.Parameters.AddWithValue("@ed", c.End_Date);
                    cmd.Parameters.AddWithValue("@na", c.Name);
                    cmd.Parameters.AddWithValue("@ph", c.Phone);
                    cmd.Parameters.AddWithValue("@em", c.Email);
                    cmd.Parameters.AddWithValue("@lo", c.Location);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCrestPipelineMember(string constring, CrestPipelineMember c)
        {
            string strsql = "UPDATE crestpipelinemembers SET operatorname=@op, state=@st, county=@cou, contactname=@con, phone=@ph, contact=@c WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", c.ID);
                    cmd.Parameters.AddWithValue("@op", c.Operator_Name);
                    cmd.Parameters.AddWithValue("@st", c.State);
                    cmd.Parameters.AddWithValue("@cou", c.County);
                    cmd.Parameters.AddWithValue("@con", c.Contact_Name);
                    cmd.Parameters.AddWithValue("@ph", c.Phone);
                    cmd.Parameters.AddWithValue("@c", c.Contact);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCrestwoodTransportationList(string constring, CrestwoodTransportation t)
        {
            string strsql = "UPDATE crestwoodtransportationlist SET name=@n, email=@e, Indiana=@in, NewJersey=@nj, WestVirginia=@wv WHERE id=@i";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@i", t.ID);
                    cmd.Parameters.AddWithValue("@n", t.Name);
                    cmd.Parameters.AddWithValue("@e", t.Email);
                    cmd.Parameters.AddWithValue("@in", t.Indiana);
                    cmd.Parameters.AddWithValue("@nj", t.NewJersey);
                    cmd.Parameters.AddWithValue("@wv", t.WestVirginia);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateCrestwoodAllNotifications(string constring, CrestAllNotifications c)
        {
            string strsql = "UPDATE crestallnotifications SET name=@n, email=@e WHERE id=@i";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@i", c.ID);
                    cmd.Parameters.AddWithValue("@n", c.Name);
                    cmd.Parameters.AddWithValue("@e", c.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateVeoliaNonIncident(string constring, VeoliaNonIncident v)
        {
            string strsql = "UPDATE veolianonincident SET callername=@cn, callerphonenumber=@cp, calleraffiliation=@ca, incidentcity=@ic, incidentstate=@is, descripton=@de, ersoperator=@eo, date=@da, time=@ti WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", v.ID);
                    cmd.Parameters.AddWithValue("@cn", v.Caller_Name);
                    cmd.Parameters.AddWithValue("@cp", v.Caller_Phone_Number);
                    cmd.Parameters.AddWithValue("@ca", v.Caller_Affiliation);
                    cmd.Parameters.AddWithValue("@ic", v.Incident_City);
                    cmd.Parameters.AddWithValue("@is", v.Incident_State);
                    cmd.Parameters.AddWithValue("@de", v.Description);
                    cmd.Parameters.AddWithValue("@eo", v.ERS_Operator);
                    cmd.Parameters.AddWithValue("@da", v.Date);
                    cmd.Parameters.AddWithValue("@ti", v.Time);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateBASFEnvironmentalIDs(string constring, BASFEnvironmentalIDs b)
        {
            string strsql = "UPDATE basfenvironmentalids SET available=@av, [user]=@us WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", b.ID);
                    cmd.Parameters.AddWithValue("@av", b.Available);
                    cmd.Parameters.AddWithValue("@us", b.User);
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public static void UpdateBASFEnvironmental(string constring, BASFEnvironmental b)
        {
            string strsql = "UPDATE basfenvironmental SET incidentdate=@ind, incidenttime=@int, callername=@cn, callerphone=@cp, plantname=@pn, materialname=@mn, sdsonhand=@soh, contained=@co, handlingcleanup=@hc, description=@de, quantity=@qty, quantityunits=@qtyu, releaseto=@rt, actions=@ac, achievereportablequantity=@arq, notifications=@no, ersoperator=@eo, calldate=@cd, calltime=@ct, nrc=@nr, peas=@pe WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", b.ID);
                    cmd.Parameters.AddWithValue("@ind", b.Incident_Date);
                    cmd.Parameters.AddWithValue("@int", b.Incident_Time);
                    cmd.Parameters.AddWithValue("@cn", b.Caller_Name);
                    cmd.Parameters.AddWithValue("@cp", b.Caller_Phone);
                    cmd.Parameters.AddWithValue("@pn", b.Plant_Name);
                    cmd.Parameters.AddWithValue("@mn", b.Material_Name);
                    cmd.Parameters.AddWithValue("@soh", b.SDS_On_Hand);
                    cmd.Parameters.AddWithValue("@co", b.Contained);
                    cmd.Parameters.AddWithValue("@hc", b.Handling_Cleanup);
                    cmd.Parameters.AddWithValue("@de", b.Description);
                    cmd.Parameters.AddWithValue("@qty", b.Quantity);
                    cmd.Parameters.AddWithValue("@qtyu", b.Quantity_Untits);
                    cmd.Parameters.AddWithValue("@rt", b.Release_To);
                    cmd.Parameters.AddWithValue("@ac", b.Actions);
                    cmd.Parameters.AddWithValue("@arq", b.Achieve_Reportable_Quantity);
                    cmd.Parameters.AddWithValue("@no", b.Notifications);
                    cmd.Parameters.AddWithValue("@eo", b.ERS_Operator);
                    cmd.Parameters.AddWithValue("@cd", b.Call_Date);
                    cmd.Parameters.AddWithValue("@ct", b.Call_Time);
                    cmd.Parameters.AddWithValue("@nr", b.NRC);
                    cmd.Parameters.AddWithValue("@pe", b.PEAS);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateBASFInjuryIDS(string constring, BASFInjuryIDs b)
        {
            string strsql = "UPDATE basfinjuryids SET available=@av, [user]=@us WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using(SqlCommand cmd=new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", b.ID);
                    cmd.Parameters.AddWithValue("@av", b.Available);
                    cmd.Parameters.AddWithValue("@us", b.User);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateBASFInjury(string constring, BASFInjury b)
        {
            string strsql = "UPDATE basfinjury SET incidentdate=@ind, incidenttime=@int, callername=@cn, callerphone=@cp, plantname=@pn, description=@de, injurytype=@it, bodypartaffected=@bpa, escorted=@es, immediateactions=@ia, evidencecollected=@ec, notifications=@no, ersoperator=@eo, productname=@pna, calldate=@cd, calltime=@ct, nrc=@nr, peas=@pe WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", b.ID);
                    cmd.Parameters.AddWithValue("@ind", b.Incident_Date);
                    cmd.Parameters.AddWithValue("@int", b.Incident_Time);
                    cmd.Parameters.AddWithValue("@cn", b.Caller_Name);
                    cmd.Parameters.AddWithValue("@cp", b.Caller_Phone);
                    cmd.Parameters.AddWithValue("@pn", b.Plant_Name);
                    cmd.Parameters.AddWithValue("@de", b.Description);
                    cmd.Parameters.AddWithValue("@it", b.Injury_Type);
                    cmd.Parameters.AddWithValue("@bpa", b.Body_Part_Affected);
                    cmd.Parameters.AddWithValue("@es", b.Escorted);
                    cmd.Parameters.AddWithValue("@ia", b.Immediate_Actions);
                    cmd.Parameters.AddWithValue("@ec", b.Evidence_Collected);
                    cmd.Parameters.AddWithValue("@no", b.Notifications);
                    cmd.Parameters.AddWithValue("@eo", b.ERS_Operator);
                    cmd.Parameters.AddWithValue("@pna", b.Product_Name);
                    cmd.Parameters.AddWithValue("@cd", b.Call_Date);
                    cmd.Parameters.AddWithValue("@ct", b.Call_Time);
                    cmd.Parameters.AddWithValue("@nr", b.NRC);
                    cmd.Parameters.AddWithValue("@pe", b.PEAS);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateIES(string constring, IES i)
        {
            string strsql = "UPDATE ies SET emergency=@em, facilityname=@fn, location=@lo, address=@ad, city=@ci, state=@st, zip=@zi, callername=@cn, callerphonenumber=@cp, contactonscenename=@csn, contactonscenephonenumber=@csp, callerunknown=@cau, contactunknown=@cou WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", i.ID);
                    cmd.Parameters.AddWithValue("@em", i.Emergency);
                    cmd.Parameters.AddWithValue("@fn", i.Facility_Name);
                    cmd.Parameters.AddWithValue("@lo", i.Location);
                    cmd.Parameters.AddWithValue("@ad", i.Address);
                    cmd.Parameters.AddWithValue("@ci", i.City);
                    cmd.Parameters.AddWithValue("@st", i.State);
                    cmd.Parameters.AddWithValue("@zi", i.Zip);
                    cmd.Parameters.AddWithValue("@cn", i.Caller_Name);
                    cmd.Parameters.AddWithValue("@cp", i.Caller_Phone_Number);
                    cmd.Parameters.AddWithValue("@csn", i.Contact_On_Scene_Phone_Number);
                    cmd.Parameters.AddWithValue("@csp", i.Emergency);
                    cmd.Parameters.AddWithValue("@cau", i.Caller_Unknown);
                    cmd.Parameters.AddWithValue("@cou", i.Contact_Unknown);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateIESContact(string constring, IESContact i)
        {
            string strsql = "UPDATE iescontacts SET name=@n, phonenumber=@p, priority=@o WHERE id=@i";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@i", i.ID);
                    cmd.Parameters.AddWithValue("@n", i.Name);
                    cmd.Parameters.AddWithValue("@p", i.Phone_Number);
                    cmd.Parameters.AddWithValue("@o", i.Order);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static bool UpdateTCEQ(string constring, TCEQ t)
        {
            try
            {
                string strsql = "UPDATE tceqreport SET Operator=@ERS,ReportDate=@RD,ReportTime=@RT,IncidentDate=@IDT,IncidentTime=@IT,ReportedBy=@RB,ContactNumber=@CN,ContactNumber2=@OCN,Emergency=@E,Description=@D,Location=@L,County=@COU,MediaAffected=@MA,ReceivingWater=@RW,AmountWater=@AW,UnitWater=@UW,PRCompany=@PRCO,PRStreet=@PRS,PRCity=@PRC,PRState=@PRST,PRZipCode=@PRZ,PRContact=@PRCT,PRPhone=@PRP,Material1=@M1,Material2=@M2,Material3=@M3,Material4=@M4,Material5=@M5,CAS1=@CAS1,CAS2=@CAS2,CAS3=@CAS3,CAS4=@CAS4,CAS5=@CAS5,Amount1=@AM1,Amount2=@AM2,Amount3=@AM3,Amount4=@AM4,Amount5=@AM5,Unit1=@U1,Unit2=@U2,Unit3=@U3,Unit4=@U4,Unit5=@U5,ResponderName=@RN,NotificationTime=@NT WHERE id=@i";
                using (SqlConnection cn = new SqlConnection(constring))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(strsql, cn))
                    {
                        cmd.Parameters.AddWithValue("@i", t.ID_TCEQ);
                        cmd.Parameters.AddWithValue("@ERS", t.ERS_Operator);
                        cmd.Parameters.AddWithValue("@RD", t.Report_Date);
                        cmd.Parameters.AddWithValue("@RT", t.Report_Time);
                        cmd.Parameters.AddWithValue("@IDT", t.Incident_Date);
                        cmd.Parameters.AddWithValue("@IT", t.Incident_Time);
                        cmd.Parameters.AddWithValue("@RB", t.Report_By);
                        cmd.Parameters.AddWithValue("@CN", t.Contact_Number);
                        cmd.Parameters.AddWithValue("@OCN", t.Contact_Number_2);
                        cmd.Parameters.AddWithValue("@E", t.Emergency);
                        cmd.Parameters.AddWithValue("@D", t.Description);
                        cmd.Parameters.AddWithValue("@L", t.Location);
                        cmd.Parameters.AddWithValue("@COU", t.County);
                        cmd.Parameters.AddWithValue("@MA", t.Media_Affected);
                        cmd.Parameters.AddWithValue("@RW", t.Receiving_Water);
                        cmd.Parameters.AddWithValue("@AW", t.Amount_Water);
                        cmd.Parameters.AddWithValue("@UW", t.Unit_Water);
                        cmd.Parameters.AddWithValue("@PRCO", t.PR_Company);                  
                        cmd.Parameters.AddWithValue("@PRS", t.PR_Street);
                        cmd.Parameters.AddWithValue("@PRC", t.PR_City);
                        cmd.Parameters.AddWithValue("@PRST", t.PR_State);
                        cmd.Parameters.AddWithValue("@PRZ", t.PR_ZipCode);
                        cmd.Parameters.AddWithValue("@PRCT", t.PR_Contact);
                        cmd.Parameters.AddWithValue("@PRP", t.PR_Phone);
                        cmd.Parameters.AddWithValue("@M1", t.Material1);
                        cmd.Parameters.AddWithValue("@M2", t.Material2);
                        cmd.Parameters.AddWithValue("@M3", t.Material3);
                        cmd.Parameters.AddWithValue("@M4", t.Material4);
                        cmd.Parameters.AddWithValue("@M5", t.Material5);
                        cmd.Parameters.AddWithValue("@CAS1", t.CAS1);
                        cmd.Parameters.AddWithValue("@CAS2", t.CAS2);
                        cmd.Parameters.AddWithValue("@CAS3", t.CAS3);
                        cmd.Parameters.AddWithValue("@CAS4", t.CAS4);
                        cmd.Parameters.AddWithValue("@CAS5", t.CAS5);
                        cmd.Parameters.AddWithValue("@AM1", t.Amount1);
                        cmd.Parameters.AddWithValue("@AM2", t.Amount2);
                        cmd.Parameters.AddWithValue("@AM3", t.Amount3);
                        cmd.Parameters.AddWithValue("@AM4", t.Amount4);
                        cmd.Parameters.AddWithValue("@AM5", t.Amount5);
                        cmd.Parameters.AddWithValue("@U1", t.Unit1);
                        cmd.Parameters.AddWithValue("@U2", t.Unit2);
                        cmd.Parameters.AddWithValue("@U3", t.Unit3);
                        cmd.Parameters.AddWithValue("@U4", t.Unit4);
                        cmd.Parameters.AddWithValue("@U5", t.Unit5);
                        cmd.Parameters.AddWithValue("@RN", t.ResponderName);
                        cmd.Parameters.AddWithValue("@NT", t.NotificationTime);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (IOException ex)
            {
                if (ex.Message.Contains("being used by another process"))
                {
                    MessageBox.Show("The file you are updating is currently open.  If the file is not open, please contact the IT department to verify that the file is closed.", "Chemical Report Manager", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured in this program.  The IT department has been notified of this error.", "Chemical Report Manager", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                string path = @"\\chem-fs1.chemtel.local\Log Files\Chemical.log";
                StreamWriter log;
                if (File.Exists(path))
                    log = File.AppendText(path);
                else
                    log = File.CreateText(path);
                //string sp = " ";
                string mod = "UpdateTCEQ";
                string pfile = "Update.cs";
                log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\n" + "Error Message: " + ex.Message + "\n" + "File: " + pfile + "\n" + "Method: " + mod + "\n\n\n");
                log.Close();
                var smtpCreds = new NetworkCredential(@"CHEMTEL\emergency", "ERS*33602");
                SmtpClient smtp = new SmtpClient("mail.chemtelinc.com", 587);
                MailAddress from = new MailAddress("ers@ehs.com");
                MailAddressCollection to = new MailAddressCollection();
                MailMessage message = new MailMessage();
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = smtpCreds;
                string msg = "Check the log file!";
                string subject = "Chemical Report Manager Error";
                to.Add("mpepitone@ehs.com,tgillis@ehs.com");
                // to.Add("mpepitone@ehs.com");
                message.To.Add(to.ToString());
                message.From = from;
                message.Subject = subject;
                message.Body = msg;
                smtp.Send(message);
                return false;
            }      
            
        }
        
        #endregion
    }
}
