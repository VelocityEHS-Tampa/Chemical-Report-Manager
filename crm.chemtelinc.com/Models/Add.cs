using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Net.Mail;
using System.IO;
using System.Net;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public static class Add
    {
        #region ChemicalReporter

        public static void AddAgencyList(string constring, AgencyList a)
        {
            string strsql="INSERT INTO agencylist (agencyId) VALUES (@aid)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@aid", a.Agency_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddATandTAssociateData(string constring, ATandTAssociateData a)
        {
            string strsql = "INSERT INTO atandtassociatedata (rptid) VALUES (@rid)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@rid", a.Report_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddATandTVolunteerData(string constring, ATandTVolunteerData a)
        {
            string strsql = "INSERT INTO atandtvolunteerdata (rptid) VALUES (@rid)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@rid", a.Report_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddAvailableSpillID(string constring, AvailableSpillID a)
        {
            string strsql = "INSERT INTO availablespillids (Id, available, usedBy) VALUES (@id, @a, @ub)";
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

        public static void AddCompanyInformation(string constring, CompanyInformation c)
        {
            string strsql="INSERT INTO companyinformation (name) VALUES (@n)";
            using(SqlConnection cn=new SqlConnection(constring))
            {
                cn.Open();
                using(SqlCommand cmd=new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@n", c.Name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddGeneralIncidentEdits(string constring, GeneralIncidentEdits g)
        {
            string strsql = "INSERT INTO generalincidentedits (id, username, editdate, numberofedits) VALUES (@i, @u, @e, @n)";
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

        public static void AddGeneralIncidentIDs(string constring, GeneralIncidentIDs g)
        {
            string strsql = "INSERT INTO generalincidentids (id, available, [user]) VALUES (@id, @a, @u)";
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

        public static void AddGeneralIncidentReportData(string constring, GeneralIncidentReportData g)
        {
            string strsql = "INSERT INTO generalincidentreportdata (IncidentId, ErsOperator, Date, Time, CallersName, CallersPhone, CallersAffiliation, CallersFaxOrEmail, IncidentStreet, IncidentCity, IncidentState, IncidentCountry, IncidentDate, IncidentTime, IncidentTimeZone, MaterialName, ProductNumber, QuantitySpilled, CleanUpCrewReqs, AgenciesOnSite, AccidentOrDeliberate, IncidentDetails, InvolveFire, WhereDidYouGetOurNumber, SubscribersName, SubscriberMIS, SpillOrExposure, TypeOfExposure, NumOfCasualties, NumOfInjuries, MedPersonnelName, PatientName, PatientCondition, HospitalClinicLocation, EpaRegNo, StatusOfRelease, DispersionOfMsdsInfo, ReviewedBy, ReviewedDate, SentDate, Comments, DateChanged, Username, IncidentZipCode, ReportType, CallersPhoneExt) VALUES (@id, @eo, @d, @t, @cn, @cp, @ca, @cfoe, @istr, @icit, @ista, @icou, @idat, @it, @itz, @mn, @pnum, @qs, @cucr, @aos, @aod, @idet, @if, @wdygon, @sn, @sm, @soe, @toe, @noc, @noi, @mpn, @pn, @pc, @hcl, @ern, @sor, @domi, @rb, @rd, @sd, @c, @dc, @us, @izc, @rt, @cpe)";
            try
            {
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
                        cmd.Parameters.AddWithValue("@dc", g.Date_Changed);
                        cmd.Parameters.AddWithValue("@us", g.Username);
                        cmd.Parameters.AddWithValue("@izc", g.Incident_Zip_Code);
                        cmd.Parameters.AddWithValue("@rt", g.Report_Type);
                        cmd.Parameters.AddWithValue("@cpe", g.Callers_Phone_Ext);
                        cmd.ExecuteNonQuery();
                    }
                }
            } catch (Exception ex)
            {
                //MessageBox.Show("An error has occured in this program.  The IT department has been notified of this error.", "Chemical Report Manager", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                string path = @"\\chem-fs1.ers.local\Log Files\Chemical.log";
                StreamWriter log;
                if (File.Exists(path))
                    log = File.AppendText(path);
                else
                    log = File.CreateText(path);
                //string sp = " ";
                string mod = "AddGeneralIncidentReportData";
                string pfile = "Add.cs";
                log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" + " Time: " + DateTime.Now.ToShortTimeString() + "\n" + " Error Message: " + ex.Message + "\n" + " File: " + pfile + "\n" + " Method: " + mod + "\n\n\n");
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
                to.Add("mpepitone@ehs.com");
                message.To.Add(to.ToString());
                message.From = from;
                message.Subject = subject;
                message.Body = msg;
                smtp.Send(message);
            }
        }

        public static void AddGLOBaseReportData(string constring, GLOBaseReportData g)
        {
            string strsql = "INSERT INTO globasereportdata (cntSpillId, fDrill, txtDrilltxt, txtReportTakenBy, txtReportPartyAffiliation, datReportTakenDate, datReportTakenTime, txtNotificationAgency, txtDischargeReportedBy, txtDischargedPhone1, txtDischargedPhone2, datDischargeDate, datDischargeTime, txtMaterial1, dblCASUN1, dblAmtSpilled1, txtUnitRecovered1, txtMaterial2, dblCASUN2, dblAmtSpilled2, txtUnitRecovered2, txtMaterial3, dblCASUN3, dblAmtSpilled3, txtUnitRecovered3, txtMaterial4, dblCASUN4, dblAmtSpilled4, txtUnitRecovered4, txtMaterial5, dblCASUN5, dblAmtSpilled5, txtUnitRecovered5, wSpillCounty, wOrigin, fSpillInWater, fSpillAirRelease, fCoastalWater, fLand, txtSpillReceivingWater, dblSpillAmountInWater, txtSpillAmountInWaterUnits, memSpillLocation, dblRRCLeaseNumber, txtRRCLeaseName, txtRRCFieldName, txtLandOwner, memActionsTakenCleanUpStatus, txtNRCNumber, txtAgencyName1, txtAgencyName2, txtAgencyName3, datDate1, datDate2, datDate3, txtWhere1, txtWhere2, txtWhere3, txtWho1, txtWho2, txtWho3, datTime1, datTime2, datTime3, txtSpiller, txtSpillerAddress, txtSpillerCity, txtSpillerState, txtSpillerZipCode, txtSpillerContact, txtSpillerContactPhone, txtAgcyName1, txtAgcyName2, txtAgcyName3, datD1, datD2, datD3, txtWhr1, txtWhr2, txtWhr3, txtW1, txtW2, txtW3, datTi1, datTi2, datTi3, memComments, DateSearch) ";
            strsql += "VALUES (@csi, @fd, @tdt, @trtb, @trpa, @drtd, @drtt, @tna, @tdrb, @tdp1, @tdp2, @ddd, @ddt, @tm1, @dc1, @das1, @tur1, @tm2, @dc2, @das2, @tur2, @tm3, @dc3, @das3, @tur3, @tm4, @dc4, @das4, @tur4, @tm5, @dc5, @das5, @tur5, @wsc, @wo,@fsiw, @fsar, @fcw, @fl, @tsrw, @dsaiw, @tsaiwu, @msl, @drln, @trln, @trfn, @tlo, @matcus, @tnn, @tagn1, @tagn2, @tagn3, @dda1, @dda2, @dda3, @twhe1, @twhe2, @twhe3, @twho1, @twho2, @twho3, @dti1, @dti2, @dti3, @ts, @tsa, @tsc, @tss, @tszc, @tsco, @tscp, @tan1, @tan2, @tan3, @dd1, @dd2, @dd3, @Twhr1, @twhr2, @twhr3, @tw1, @tw2, @tw3, @dt1, @dt2, @dt3, @tlf, @ds)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using(SqlCommand cmd=new SqlCommand(strsql, cn))
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

        public static void AddGLOCountyList(string constring, GLOCountyList g)
        {
            string strsql = "INSERT INTO glocountylist (countyCode, countyName, countyGLOVoiceNumber, countyGLORegionNumber, countyGLORegionCity, countyGLOBeeperNumber, countyRRCNumber, countyRRCDistrictNumber, countyRRCDistrictCity, countyTNRCCNumber, countyTNRCCDistrictNumber, countyTNRCCDistrictCity) VALUES (@cc, @cn, @cgvn, @cgrn, @cgrc, @cgbn, @crn, @crdn, @crdc, @ctn, @ctdn, @ctdc)";
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

        public static void AddGLOEmails(string constring, GLOEmails g)
        {
            string strsql = "INSERT INTO gloemails (name, emailgroup, email01, email02, email03, email04, email05, email06, email07, email08, email09, email10) VALUES (@n, @eg, @e01, @e02, @e03, @e04, @e05, @e06, @e07, E08, @e09, @e10)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
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

        public static void AddGLOIDs(string constring, GLOID g)
        {
            string strsql = "INSERT INTO gloids (id, available, [user]) VALUES (@i, @a, @u)";
            using(SqlConnection cn=new SqlConnection(constring))
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

        public static void AddKnowledgeBase(string constring, Knowlegebase k)
        {
            string strsql = "INSERT INTO knowledgebase (title, body, link) VALUES (@t, @b, @l)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@t", k.Title);
                    cmd.Parameters.AddWithValue("@b", k.Body);
                    cmd.Parameters.AddWithValue("@l", k.Link);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddMODRequests(string constring, MODRequest m)
        {
            string strsql = "INSERT INTO modrequests (ersoperator, companyname, nameofcaller, phone, ext, fax, email, sendingmethod, modclient, datereceived, datefulfilled, comments, prodname1, manu1, qty1, locatedvia1, prodname2, manu2, qty2, locatedvia2, prodname3, manu3, qty3, locatedvia3, prodname4, manu4, qty4, locatedvia4, prodname5, manu5, qty5, locatedvia5, prodname6, manu6, qty6, locatedvia6, prodname7, manu7, qty7, locatedvia7, prodname8, manu8, qty8, locatedvia8, prodname9, manu9, qty9, locatedvia9, prodname10, manu10, qty10, locatedvia10, totalcost, price1, price2, price3, price4, price5, price6, price7, price8, price9, price10, totalqty, monthreceived, yearreceived) ";
            strsql += "VALUES (@eo, @cn, @noc, @ph, @e, @f, @em, @sm, @mc, @dr, @df @c, @pro1, @m1, @q1, @lv1, @pro2, @m2 @q2, @lv2, @pro3, @m3, @q3, @lv3, @pro4, @m4, @q4, @lv4, @pro5, @m5, @q5, @lv5, @pro6, @m6, @q6, @lv6, @pro7, @m7, @q7, @lv7, @pro8, @m8, @q8, @lv8, @pro9, @m9, @q9, @lv9, @pro10, @m10, @q10, @lv10, @tc, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @tq, @mr, @yr)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
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

        public static void AddNonCoastal(string constring, NonCoastal n)
        {
            string strsql = "INSERT INTO noncoastal (nonCoastalType) VALUES (@n)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@n", n.Non_Coastal_Type);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddOldGLO(string constring, OldGLO g)
        {
            string strsql = "INSERT INTO oldglo (cntSpillId, fDrill, txtDrilltxt, txtReportTakenBy, txtReportPartyAffiliation, datReportTakenDate, datReportTakenTime, txtNotificationAgency, txtDischargeReportedBy, txtDischargedPhone1, txtDischargedPhone2, datDischargeDate, datDischargeTime, txtMaterial1, dblCASUN1, dblAmountSpilled1, txtUnitRecovered1, txtMaterial2, dblCASUN2, dblAmountSpilled2, txtUnitRecovered2, txtMaterial3, dblCASUN3, dblAmountSpilled3, txtUnitRecovered3, txtMaterial4, dblCASUN4, dblAmountSpilled4, txtUnitRecovered4, txtMaterial5, dblCASUN5, dblAmountSpilled5, txtUnitRecovered5, wSpillCounty, wOrigin, fSpillInWater, fSpillAirRelease, fCoastalWater, fLand, txtSpillReceivingWater, dblSpillAmountInWater, txtSpillAmountInWaterUnits, memSpillLocation, dblRRCLeaseNumber, txtRRCLeaseName, txtRRCFieldName, txtLandOwner, memActionsTakenCleanUpStatus, txtNRCNumber, txtAgencyName1, txtAgencyName2, txtAgencyName3, datDate1, datDate2, datDate3, txtWhere1, txtWhere2, txtWhere3, txtWho1, txtWho2, txtWho3, datTime1, datTime2, datTime3, txtSpiller, txtSpillerAddress, txtSpillerCity, txtSpillerState, txtSpillerZipCode, txtSpillerContact, txtSpillerContactPhone, memComments, txtAgcyName1, txtAgcyName2, txtAgcyName3, datD1, datD2, datD3, txtWhr1, txtWhr2, txtWhr3, txtW1, txtW2, txtW3, datTi1, datTi2, datTi3, txtLastField) ";
            strsql += "VALUES (@csi, @fd, @tdt, @trtb, @trpa, @drtd, @drtt, @tna, @tdrb, @tdp1, @tdp2, @ddd, @ddt, @tm1, @dc1, @das1, @tur1, @tm2, @dc2, @das2, @tur2, @tm3, @dc3, @das3, @tur3, @tm4, @dc4, @das4, @tur4, @tm5, @dc5, @das5, @tur5, @wsc, @wo,@fsiw, @fsar, @fcw, @fl, @tsrw, @dsaiw, @tsaiwu, @msl, @drln, @trln, @trfn, @tlo, @matcus, @tnn, @tagn1, @tagn2, @tagn3, @dda1, @dda2, @dda3, @twhe1, @twhe2, @twhe3, @twho1, @twho2, @twho3, @dti1, @dti2, @dti3, @ts, @tsa, @tsc, @tss, @tszc, @tsco, @tscp, @mc, @tan1, @tan2, @tan3, @dd1, @dd2, @dd3, @Twhr1, @twhr2, @twhr3, @tw1, @tw2, @tw3, @tt1, @tt2, @tt3, @tlf)";
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
                    cmd.Parameters.AddWithValue("@tag1", g.Agency_Name_1);
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
                    cmd.Parameters.AddWithValue("@dti", g.Time_1);
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

        public static void AddOtherIDs(string constring, OtherID o)
        {
            string strsql = "INSERT INTO otherids (id, available, [user]) VALUES(@i, @a, @u)";
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

        public static void AddShellOilIncidentData(string constring, ShellOilIncidentData s)
        {
            string strsql = "INSERT INTO shelloilincidentdata (incid, ersop, date, time, callername1, callername2, callername3, callerphone1, callerphone2, callerphone3, callerext1, callerext2, callerext3, calleraltphone1, calleraltphone2, calleraltphone3, calleraltext1, calleraltext2, calleraltext3, comments, staffname, staffphone, staffext, staffreporttime, stafftimezone, followupname1, followupname2, followupname3,followupname4,followupname5, followuptime1, followuptime2, followuptime3, followuptime4, followuptime5, followuptimezone1, followuptimezone2, followuptimezone3, followuptimezone4, followuptimezone5, followupphone1,followupphone2, followupphone3, followupphone4, followupphone5, followupext1, followupext2, followupext3, followupext4, followupext5, emailsent, notes) ";
            strsql += "VALUES (@ii, @eo, @d, @t, @cn1, @cn2, @cn3, @cp1, @cp2, @cp3, @ce1, @ce2, @ce3, @cap1, @cap2, @cap3, @cae1, @cae2, @cae3, @c, @sn, @sp, @se, @srt, @stz, @fn1, @fn2, @fn3, @fn4,@fn5, @ft1, @ft2, @ft3, @ft4, @ft5, @ftz1, @ftz2, @ftz3, @ftz4, @ftz5, @fp1, @fp2, @fp3, @fp4, @fp5, @fe1, @fe2, @fe3, @fe4, @fe5, @es, @n)";
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

        public static void AddSpillOrigin(string constring, SpillOrigin s)
        {
            string strsql = "INSERT INTO spillorigin (originId) VALUES (@o)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using(SqlCommand cmd=new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@o", s.Origin_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddSpillUnits(string constring, SpillUnits s)
        {
            string strsql = "INSERT INTO spillunits (unitId) VALUES (@u)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using(SqlCommand cmd=new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@u", s.Unit_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddCleanShotIDs(string constring, CleanshotIDs c)
        {
            string strsql = "INSERT INTO cleanshotids (id, available, [user]) VALUES (@id, @available, @user)";
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

        public static void AddTheoChemCleanShotIncidents(string constring, TheoChemCleanshotIncident t)
        {
            string strsql = "INSERT INTO theochemcleanshotincidents (incidentId, ersOp, rptDate, rptTime, callerName, callerPhone, callerAff, callerFaxEmail, incStreet, incCity, incState, incCountry, incTimeZone, incDate, incTime, quest1, quest2Qty, quest2Units, quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10YesOrNo, quest10IfYesWhat, quest11YesOrNo, quest11IfYesWhat, quest12, quest13, quest14, quest15, quest16, quest17, additCommentsDetails, subName, subAdminContact, subPhone, subFax, subEmail, subAddress, subCityStateZip, emailsent, comments, type) ";
            strsql += "VALUES (@ii, @eo, @rd, @rt, @cn, @cp, @ca, @cfe, @istr, @icit, @ista, @icou, @itz, @id, @it, @q1, @q2q, @q2u, @q3, @q4, @q5, @q6, @q7, @q8, @q9, @q10yon, @q10iyw, @q11yon, @q11iyw, @q12, @q13, @q14, @q15, @q16, @q17, @acd, @sn, @sac, @sp, @sf, @se, @sa, @scsz, @es, @comm, @type)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using(SqlCommand cmd=new SqlCommand(strsql, cn))
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

        public static void AddTheoChemContactInformation(string constring, TheoChemContactInformation t)
        {
            string strsql = "INSERT INTO theochemcontactinformation (name, admincontact, phone, fax, email, address, citystatezip) VALUES (@n, @ac, @p, @f, @e, @a, @c)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using(SqlCommand cmd=new SqlCommand(strsql, cn))
                {
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

        public static void AddTickets(string constring, Ticket t)
        {
            string strsql = "INSERT INTO tickets (id, status, username, subject, description) VALUES (@id, @st, @u, @su, @d)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using(SqlCommand cmd=new SqlCommand(strsql, cn))
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

        public static void AddCrestGeneralIncidents(string constring, CrestGeneralIncident c)
        {
            string strsql = "INSERT INTO crestgeneralincidents (callername, callertitle, calleraffiliation, callerphonenumber, incidentdate, incidentlocation, incidentlatitude, incidentlongitude, incidentoccuron, incidentnature, incidentdescription, involvedname1, involvedname2, involvedname3, involvedcell1, involvedcell2, involvedcell3, involvedinjury1, involvedinjury2, involvedinjury3, weatherconditions, impactedareas, impactedbodyofwater, reporttakername, reporttakeremail, ersname1, ersname2, ersname3, erscontactnumber1, erscontactnumber2, erscontactnumber3, erslocation1, erslocation2, erslocation3, notify911, immediatesupport, transporttohospital, emergencyresponders, fatalities, mediaonscene, incidentprivaterow, incidenttriballand, incidentblmland, incidentstateland, incidentaddress, incidentcity, incidentstate, incidentcounty, incidentintersection, incidentfacilityname, fireorexplosion, pipelinestrike, injury, illnessorexposure, vehicleaccident, spillorrelease, theft, agencyinspectionofvisit, propertydamage, potentialhazardornearmiss, landownercomplaint, impactstowater, landowner, incidenttime, incidenttimezone, calleremail, calldate, calltime, other, ersoperator, numinjuries1, numinjuries2, numinjuries3, none, unknown, tractortrailer, equipment, dispatcheremployee, initials, county, drill, wpviolence, Incident_Contractor_Or_Employee, IndividualSafety, WeaponReported, WeaponType, FacilityOrProject, RegionOrFacility, ContractorName, FacilityOrProjectSelection, OccuredOnPipeline, NotificationDate, NotificationTime, PC_CWLocOrTransport, SusAct, SpillOrReleaseIntoAtmo, MaterialSpilled, WaterbodiesImpacted, ContainedOnSite, SpillContainedSecondary, ControlDevices, PrimaryWorkLocation) VALUES (@cn, @ct, @ca, @cpn, @idate, @iloc, @ilat, @ilong, @ioo, @inat, @ides, @in1, @in2, @in3, @ic1, @ic2, @ic3, @ii1, @ii2, @ii3, @wc, @ia, @ibow, @rtn, @rte, @en1, @en2, @en3, @ecp1, @ecp2, @ecp3, @el1, @el2, @el3, @n9, @isup, @tth, @er, @fat, @mos, @ipr, @itl, @ibl, @isl, @iadd, @icit, @ista, @icou, @iint, @ifn, @foe, @ps, @inj, @ill, @va, @sor, @t, @aiov, @pd, @phonm, @lc, @itw, @lown, @itim, @itimz, @cemail, @cdate, @ctime, @other, @eop, @noi1, @noi2, @noi3, @non, @unk, @tt, @eq, @dise, @init, @county, @drill, @wpviolence, @Incident_Contractor_Or_Employee, @IndividualSafety, @WeaponReported, @WeaponType, @FOP, @ROF, @ConName, @FOPSelection, @OOP, @NotiDate, @NotiTime, @PCLOC, @SusAct, @SORIA, @MaterialSpilled, @WBI, @COS, @SCS, @ConDevices, @PWC)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
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
                    //cmd.Parameters.AddWithValue("@doe", c.Dispatcher_Or_Employee);
                    //cmd.Parameters.AddWithValue("@coe", c.Contractor_Or_Employee);
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
                    cmd.Parameters.AddWithValue("@lc", c.Landowner_Complaint);
                    cmd.Parameters.AddWithValue("@itw", c.Impacts_To_Water);
                    cmd.Parameters.AddWithValue("@lown", c.Landowner);
                    cmd.Parameters.AddWithValue("@itim", c.Incident_Time);
                    cmd.Parameters.AddWithValue("@itimz", c.Incident_Time_Zone);
                    cmd.Parameters.AddWithValue("@cemail", c.Caller_Email);
                    cmd.Parameters.AddWithValue("@cdate", c.Call_Date);
                    cmd.Parameters.AddWithValue("@ctime", c.Call_Time);
                    cmd.Parameters.AddWithValue("@other", c.Other);
                    cmd.Parameters.AddWithValue("@eop", c.ERS_Operator);
                    //cmd.Parameters.AddWithValue("@eqop", c.Equipment_Or_People);
                    cmd.Parameters.AddWithValue("@noi1", c.Number_Of_Injuries_1);
                    cmd.Parameters.AddWithValue("@noi2", c.Number_Of_Injuries_2);
                    cmd.Parameters.AddWithValue("@noi3", c.Number_Of_Injuries_3);
                    cmd.Parameters.AddWithValue("@non", c.None);
                    cmd.Parameters.AddWithValue("@unk", c.Unknown);
                    cmd.Parameters.AddWithValue("@tt", c.Tractor_Trailer);
                    cmd.Parameters.AddWithValue("@eq", c.Equipment);
                    cmd.Parameters.AddWithValue("@dise", c.Dispatcher_Employee);
                    cmd.Parameters.AddWithValue("@init", c.Initials);
                    cmd.Parameters.AddWithValue("@county", c.County);
                    cmd.Parameters.AddWithValue("@drill", c.Drill);
                    cmd.Parameters.AddWithValue("@wpviolence", c.wpviolence);
                    cmd.Parameters.AddWithValue("@Incident_Contractor_Or_Employee", c.Incident_Contractor_Or_Employee);
                    cmd.Parameters.AddWithValue("@IndividualSafety", c.IndividualSafety);
                    cmd.Parameters.AddWithValue("@WeaponReported", c.WeaponReported);
                    cmd.Parameters.AddWithValue("@WeaponType", c.WeaponType);
                    cmd.Parameters.AddWithValue("@FOP", c.FacilityOrProject);
                    cmd.Parameters.AddWithValue("@ROF", c.RegionOrFacility);
                    cmd.Parameters.AddWithValue("@ConName", c.ContractorName);
                    cmd.Parameters.AddWithValue("@FOPSelection", c.FacilityOrProjectSelection);
                    cmd.Parameters.AddWithValue("@OOP", c.OccuredOnPipeline);
                    cmd.Parameters.AddWithValue("@NotiDate", c.NotificationDate);
                    cmd.Parameters.AddWithValue("@NotiTime", c.NotificationTime);
                    cmd.Parameters.AddWithValue("@PCLOC", c.PC_CWLocOrTransport);
                    cmd.Parameters.AddWithValue("@SusAct", c.SusAct);
                    cmd.Parameters.AddWithValue("@SORIA", c.SpillOrReleaseIntoAtmo);
                    cmd.Parameters.AddWithValue("@MaterialSpilled", c.MaterialSpilled);
                    cmd.Parameters.AddWithValue("@WBI", c.WaterbodiesImpacted);
                    cmd.Parameters.AddWithValue("@COS", c.ContainedOnSite);
                    cmd.Parameters.AddWithValue("@SCS", c.SpillContainedSecondary);
                    cmd.Parameters.AddWithValue("@ConDevices", c.ControlDevices);
                    cmd.Parameters.AddWithValue("@PWC", c.PrimaryWorkLocation);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddCrestPipelineIncident(string constring, CrestPipelineIncident c)
        {
            string strsql = "INSERT INTO crestpiplineincidents (county, state, distancefromtown, distancefromlandmark, intersectionormilemarker, observing, seeinghearingsmelling, roworwellpad, tanks, landowner, callername, callerphone, notify911, anyoneinjured, immediatedanger, temp, windspeed, winddirection, weatherconditions, relationtoincident, safelywarn, name1, name2, name3, contactnumber1, contactnumber2, contactnumber3, location1, location2, location3, leasewellname, blackorwhitesmoke, flames, hissing, liquid, oilysheen, otherpipelinemarkers, rotteneggodor, vaporormist, directions, city, date, time, timezone, numofinjuries, reporttakername, reporttakeremail, description, calleremail, callertitle, calleraffiliation, name4, name5, contactnumber4, contactnumber5, location4, location5, calldate, calltime, ersoperator, initials, NotificationDate, NotificationTime, Drill) VALUES (@co, @st, @dft, @dfl, @iom, @ob, @shs, @rowp, @ta, @lo, @cn, @cp, @n9, @ai, @imd, @te, @ws, @wd, @wc, @rti, @sw, @n1, @n2, @n3, @cn1, @cn2, @cn3, @l1, @l2, @l3, @lwn, @bows, @f, @l, @h, @os, @opm, @reo, @voom, @dir, @cit, @dat, @tim, @timz, @noi, @rtn, @rte, @desc, @cemail, @ctitle, @caff, @n4, @n5, @cn4, @cn5, @l4, @l5, @cd, @ct, @eop, @init, @NotiDate, @NotiTime, @Drill)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
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
                    cmd.Parameters.AddWithValue("@reo", c.Rotten_Egg_Odor);
                    cmd.Parameters.AddWithValue("@voom", c.Vapor_Or_Mist);
                    cmd.Parameters.AddWithValue("@dir", c.Directions);
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
                    cmd.Parameters.AddWithValue("@NotiDate", c.NotificationDate);
                    cmd.Parameters.AddWithValue("@NotiTime", c.NotificationTime);
                    cmd.Parameters.AddWithValue("@Drill", c.Drill);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddCrestERS(string constring, CrestERS c)
        {
            string strsql = "INSERT INTO cresters (startdate, enddate, name, phone, email, location) VALUES (@sd, @ed, @na, @ph, @em, @lo)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
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

        public static void AddCrestPipelineMember(string constring, CrestPipelineMember c)
        {
            string strsql = "INSERT INTO crestpipelinemembers (operatorname, state, county, contactname, phone, contact) VALUES (@op, @st, @cou, @con, @ph, @c)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
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

        public static void AddCrest811(string constring, Crest811 c)
        {
            string strsql = "INSERT INTO crest811 (todaydate, todaytime, excavationdate, excavationtime, normaloremergency, requestticketnumber, personcompanyname, callbacknumber, emailaddress, city, state, county, workdate, street, intersection, nature, remarks, callername, callernumber, name, contactnumber, location, FacilityName) VALUES (@td, @tt, @ed, @et, @noe, @rtn, @pcn, @cbn, @ea, @ci, @sta, @cou, @wd, @str, @in, @nat, @re, @cna, @cnu, @nam, @con, @lo, @facilityname)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@td", c.Today_Date);
                    cmd.Parameters.AddWithValue("@tt", c.Today_Time);
                    cmd.Parameters.AddWithValue("@ed", c.Excavation_Date);
                    cmd.Parameters.AddWithValue("@et", c.Excavation_Time);
                    cmd.Parameters.AddWithValue("@noe", c.Normal_Or_Emergency);
                    cmd.Parameters.AddWithValue("@rtn", c.Request_Ticket_Number);
                    cmd.Parameters.AddWithValue("@pcn", c.Person_Company_Name);
                    cmd.Parameters.AddWithValue("@cbn", c.Callback_Number);
                    cmd.Parameters.AddWithValue("@ea", c.Email_Address);
                    cmd.Parameters.AddWithValue("@ci", c.City);
                    cmd.Parameters.AddWithValue("@sta", c.State);
                    cmd.Parameters.AddWithValue("@cou", c.County);
                    cmd.Parameters.AddWithValue("@wd", c.Work_Date);
                    cmd.Parameters.AddWithValue("@str", c.Street);
                    cmd.Parameters.AddWithValue("@in", c.Intersection);
                    cmd.Parameters.AddWithValue("@nat", c.Nature);
                    cmd.Parameters.AddWithValue("@re", c.Remarks);
                    cmd.Parameters.AddWithValue("@cna", c.Caller_Name);
                    cmd.Parameters.AddWithValue("@cnu", c.Caller_Number);
                    cmd.Parameters.AddWithValue("@nam", c.Name);
                    cmd.Parameters.AddWithValue("@con", c.Contact_Number);
                    cmd.Parameters.AddWithValue("@lo", c.Location);
                    cmd.Parameters.AddWithValue("@facilityname", c.FacilityName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddCrestwoosTransportationList(string constring, CrestwoodTransportation t)
        {
            string strsql = "INSERT INTO crestwoodtransportationlist (name, email, Indiana, NewJersey, WestVirginia) VALUES (@n, @e, @i, @nj, @wv)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@n", t.Name);
                    cmd.Parameters.AddWithValue("@e", t.Email);
                    cmd.Parameters.AddWithValue("@i", t.Indiana);
                    cmd.Parameters.AddWithValue("@nj", t.NewJersey);
                    cmd.Parameters.AddWithValue("@wv", t.WestVirginia);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddCrestAllNotifications(string constring, CrestAllNotifications c)
        {
            string strsql = "INSERT INTO crestallnotifications (name, email) VALUES (@n, @e)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@n", c.Name);
                    cmd.Parameters.AddWithValue("@e", c.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddVeoliaNonIncident(string constring, VeoliaNonIncident v)
        {
            string strsql = "INSERT INTO veolianonincident (callername, callerphonenumber, calleraffiliation, incidentcity, incidentstate, description, ersoperator, date, time) VALUES (@cn, @cp, @ca, @ic, @is, @de, @eo, @da, @ti)";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
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

        public static bool AddTCEQ(string constring, TCEQ t)
        {
            try
            {
                string strsql = "INSERT INTO tceqreport (Operator,ReportDate,ReportTime,IncidentDate,IncidentTime,ReportedBy,ContactNumber,ContactNumber2,Emergency,Description,Location,County,MediaAffected,ReceivingWater,AmountWater,UnitWater,PRCompany,PRStreet,PRCity, PRState, PRZipCode,PRContact,PRPhone,Material1,Material2,Material3,Material4,Material5,CAS1,CAS2,CAS3,CAS4,CAS5,Amount1,Amount2,Amount3,Amount4,Amount5,Unit1,Unit2,Unit3,Unit4,Unit5,ResponderName,NotificationTime) VALUES (@ERS, @RD,@RT, @IDT, @IT, @RB, @CN, @OCN, @E, @D, @L,@COU,@MA,@RW,@AW,@UW,@PRCO,@PRS,@PRC,@PRST,@PRZ, @PRCT, @PRP, @M1, @M2, @M3, @M4, @M5, @CAS1, @CAS2, @CAS3, @CAS4, @CAS5, @AM1, @AM2, @AM3, @AM4, @AM5,@U1, @U2, @U3, @U4, @U5,@RN,@NT)";                
                using (SqlConnection cn = new SqlConnection(constring))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(strsql, cn))
                    {                       
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
            catch (Exception ex)
            {
                //MessageBox.Show("An error has occured in this program.  The IT department has been notified of this error.", "Chemical Report Manager", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                string path = @"\\chem-fs1.ers.local\Log Files\Chemical.log";
                StreamWriter log;
                if (File.Exists(path))
                    log = File.AppendText(path);
                else
                    log = File.CreateText(path);
                //string sp = " ";
                string mod = "AddTCEQ";
                string pfile = "Add.cs";
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
