using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using crm.chemtelinc.com.Models;
using ChemicalLibrary;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace crm.chemtelinc.com.Controllers
{
    public class ManagerToolsController : Controller
    {
        string constring = Properties.Settings.Default.chemicalConnectionString;
        string constringTest = Properties.Settings.Default.chemicalTestConnectionString;
        // GET: ManagerTools
        public ActionResult IDEditing()
        {
            //Check if user is logged in, if not, force login.
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                return RedirectToAction("Index", "Home", new { e = "You must login before proceeding!" });
            }
            ViewBag.IDsSelected = Request.QueryString["IDsSelected"].ToString();
            return View();
        }
        public ActionResult Logs()
        {
            List<GLOID> GLOIDList = new List<GLOID>();
            List<TheoChemCleanshotIncident> CleanshotIDList = new List<TheoChemCleanshotIncident>();
            List<GeneralIncidentReportData> GenIncIDList = new List<GeneralIncidentReportData>();
            List<ShellOilIncidentData> ShellIDList = new List<ShellOilIncidentData>();

            //Check if user is logged in, if not, force login.
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                return RedirectToAction("Index", "Home", new { e = "You must login before proceeding!" });
            }
            ViewBag.LogsSelected = Request.QueryString["LogsSelected"].ToString();
            
            if (ViewBag.LogsSelected == "CleanShot")
            {
                CleanshotIDList = GetCleanshotids();
                ViewBag.CleanshotIDs = CleanshotIDList;
            }
            else if (ViewBag.LogsSelected == "GenInc")
            {
                GenIncIDList = GetGenIncids();
                ViewBag.GenIncIDs = GenIncIDList;
            }
             else if (ViewBag.LogsSelected == "Shell")
            {
                ShellIDList = GetShellids();
                ViewBag.ShellIDs = ShellIDList;
            }
            return View();
        }
        public ActionResult ManagerToolsEtc()
        {
            //Check if user is logged in, if not, force login.
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                return RedirectToAction("Index", "Home", new { e = "You must login before proceeding!" });
            }

            ViewBag.OtherToolSelected = Request.QueryString["OtherToolSelected"].ToString();

            if (ViewBag.OtherToolSelected == "GLOCountyList")
            {
                List<GLOCountyList> GLOCountyList = new List<GLOCountyList>();
                string sqlcmd = "SELECT * FROM glocountylist";
                using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                    {
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            GLOCountyList g = new GLOCountyList();
                            g.County_Code = double.Parse(rdr["countyCode"].ToString());
                            g.County_Name = rdr["countyName"].ToString();
                            g.County_GLO_Voice_Number = rdr["countyGLOVoiceNumber"].ToString();
                            g.County_GLO_Region_Number = rdr["countyGLORegionNumber"].ToString();
                            g.County_GLO_Region_City = rdr["countyGLORegionCity"].ToString();
                            g.County_GLO_Beeper_Number = rdr["countyGLOBeeperNumber"].ToString();
                            g.County_RRC_Number = rdr["countyRRCNumber"].ToString();
                            g.County_RRC_District_Number = rdr["countyRRCDistrictNumber"].ToString();
                            g.County_RRC_District_City = rdr["countyRRCDistrictCity"].ToString();
                            g.County_TNRCC_Number = rdr["countyTNRCCNumber"].ToString();
                            g.County_TNRCC_District_Number = rdr["countyTNRCCDistrictNumber"].ToString();
                            g.County_TNRCC_District_City = rdr["countyTNRCCDistrictCity"].ToString();
                            GLOCountyList.Add(g);
                        }
                    }
                }
                return View(GLOCountyList.ToList());
            } else
            {
                return View();
            }
        }

        #region Account Management
        public ActionResult UserManagement()
        {
            return View();
        }
        public JsonResult GetUserInfo(string username)
        {
            string name = "";
            string type = "";
            string sql = "SELECT * FROM CRMWebU WHERE Username = @uname";
            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@uname", username);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        name = sdr["Name"].ToString();
                        type = sdr["UserType"].ToString();
                    }
                }
            }
            return Json(new { Name = name, UserType = type }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UserChanges(FormCollection fc)
        {
            //If no Username is selected, add new user
            if (fc["username"].ToString() == null || fc["username"].ToString() == "")
            {
                string Name = fc["Name"].ToString();
                string username = "";
                string password = fc["password"].ToString();
                string userType = fc["UserOptions"].ToString();
                string SqlCmd = "INSERT INTO CRMWebU (Username, Name, Password, UserType, LastPassChange) VALUES (@un, @n, @p, @ut, @lpc)";

                //Create new username
                string NameFirstLetter = Name[0].ToString();
                string[] LastName = Name.Split(' ');
                username += NameFirstLetter.ToLower() + LastName[1].ToLower();
                
                string EncPass = PassEncrypt.EncodePassword(password);

                using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(SqlCmd, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@un", username);
                        cmd.Parameters.AddWithValue("@n", Name);
                        cmd.Parameters.AddWithValue("@p", EncPass);
                        cmd.Parameters.AddWithValue("@ut", userType);
                        cmd.Parameters.AddWithValue("@lpc", DateTime.Now.ToShortDateString());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else //If there is a username selected, update the user info.
            {
                string username = fc["username"].ToString();
                string SqlCmd = "";

                if (fc["password"].ToString() != "" && fc["password"].ToString() != null) //If the password has been entered into the text box, update the password.
                {
                    SqlCmd = "UPDATE CRMWebU SET Password = @p, LastPassChange = @lpc, Name = @name, UserType = @utype WHERE Username = @un";
                    string password = fc["password"].ToString();
                    string EncPass = PassEncrypt.EncodePassword(password);
                    using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                    {
                        using (SqlCommand cmd = new SqlCommand(SqlCmd, con))
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@p", EncPass);
                            cmd.Parameters.AddWithValue("@un", username);
                            cmd.Parameters.AddWithValue("@lpc", DateTime.Now.ToShortDateString());
                            cmd.Parameters.AddWithValue("@name", fc["Name"].ToString());
                            cmd.Parameters.AddWithValue("@utype", fc["UserOptions"].ToString());
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else //Update user type and name if no password entered.
                {
                    SqlCmd = "UPDATE CRMWebU SET Name = @name, UserType = @utype WHERE Username = @un";
                    using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                    {
                        using (SqlCommand cmd = new SqlCommand(SqlCmd, con))
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@name", fc["Name"].ToString());
                            cmd.Parameters.AddWithValue("@utype", fc["UserOptions"].ToString());
                            cmd.Parameters.AddWithValue("@un", username);
                            cmd.ExecuteNonQuery();
                        }
                    }

                }
            }

            if (fc["Submit"].ToString() == "Remove User") //Remove user if Remove button is clicked.
            {
                string SqlCmd = "DELETE FROM CRMWebU WHERE Username = @un";
                using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(SqlCmd, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@un", fc["username"].ToString());
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            return View("UserManagement");
        }

        #endregion

        #region GLO Functions
        public JsonResult SearchGLOEmails(string SearchType)
        {
            GLOEmails g = new GLOEmails(Session["constring"].ToString(), SearchType);
            return Json(new { Email1 = g.Email_01, Email2 = g.Email_02, Email3 = g.Email_03, Email4 = g.Email_04, Email5 = g.Email_05, Email6 = g.Email_06, Email7 = g.Email_07, Email8 = g.Email_08, Email9 = g.Email_09, Email10 = g.Email_10 }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetGLOEmailGroups(string emailgroup)
        {
            string OptionList = "";
            string strsql = "SELECT name FROM gloemails WHERE emailgroup=@eg";
            using (SqlConnection cn = new SqlConnection(Session["constring"].ToString()))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@eg", emailgroup);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        OptionList += rdr[0].ToString() + ",";
                    }
                }
            }
            return Json(OptionList.Trim(','), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GLOEmailUpdates(FormCollection fc)
        {
            GLOEmails g = new GLOEmails(Session["constring"].ToString(), fc["HiddenCBSearch"].ToString());
            //If there are no values in text boxes, set to N/A by default
            if (fc["Email1"].ToString() == "") { g.Email_01 = "N/A"; } else { g.Email_01 = fc["Email1"].ToString(); }
            if (fc["Email2"].ToString() == "") { g.Email_02 = "N/A"; } else { g.Email_02 = fc["Email2"].ToString(); }
            if (fc["Email3"].ToString() == "") { g.Email_03 = "N/A"; } else { g.Email_03 = fc["Email3"].ToString(); }
            if (fc["Email4"].ToString() == "") { g.Email_04 = "N/A"; } else { g.Email_04 = fc["Email4"].ToString(); }
            if (fc["Email5"].ToString() == "") { g.Email_05 = "N/A"; } else { g.Email_05 = fc["Email5"].ToString(); }
            if (fc["Email6"].ToString() == "") { g.Email_06 = "N/A"; } else { g.Email_06 = fc["Email6"].ToString(); }
            if (fc["Email7"].ToString() == "") { g.Email_07 = "N/A"; } else { g.Email_07 = fc["Email7"].ToString(); }
            if (fc["Email8"].ToString() == "") { g.Email_08 = "N/A"; } else { g.Email_08 = fc["Email8"].ToString(); }
            if (fc["Email9"].ToString() == "") { g.Email_09 = "N/A"; } else { g.Email_09 = fc["Email9"].ToString(); }
            if (fc["Email10"].ToString() == "") { g.Email_10 = "N/A"; } else { g.Email_10 = fc["Email10"].ToString(); }
            Update.UpdateGLOEmails(Session["constring"].ToString(), g);
            ViewBag.Success = "GLO Emails Successfully Updated";
            return RedirectToAction("ManagerToolsEtc", new { OtherToolSelected = "GLOEmails" });
        }


        public ActionResult SearchGLOCounties(FormCollection fc)
        {
            ViewBag.OtherToolSelected = "GLOCountyList";
            List<GLOCountyList> GLOCountyList = new List<GLOCountyList>();
            string sqlcmd = "SELECT * FROM glocountylist";
            if (fc["Search"].ToString() != "")
            {
                if (fc["SearchType"].ToString() == "County")
                {
                    sqlcmd += " WHERE countyName LIKE '%" + fc["Search"].ToString() + "%'";
                }
                if (fc["SearchType"].ToString() == "GLO Region")
                {
                    sqlcmd += " WHERE countyGLORegionNumber='" + fc["Search"].ToString() + "'";
                }
                if (fc["SearchType"].ToString() == "RRC District")
                {
                    sqlcmd += " WHERE countyRRCDistrictNumber='" + fc["Search"].ToString() + "'";
                }
                if (fc["SearchType"].ToString() == "TCEQ")
                {
                    sqlcmd += " WHERE countyTNRCCDistrictNumber='" + fc["Search"].ToString() + "'";
                }
            }
            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        GLOCountyList g = new GLOCountyList();
                        g.County_Code = double.Parse(rdr["countyCode"].ToString());
                        g.County_Name = rdr["countyName"].ToString();
                        g.County_GLO_Voice_Number = rdr["countyGLOVoiceNumber"].ToString();
                        g.County_GLO_Region_Number = rdr["countyGLORegionNumber"].ToString();
                        g.County_GLO_Region_City = rdr["countyGLORegionCity"].ToString();
                        g.County_GLO_Beeper_Number = rdr["countyGLOBeeperNumber"].ToString();
                        g.County_RRC_Number = rdr["countyRRCNumber"].ToString();
                        g.County_RRC_District_Number = rdr["countyRRCDistrictNumber"].ToString();
                        g.County_RRC_District_City = rdr["countyRRCDistrictCity"].ToString();
                        g.County_TNRCC_Number = rdr["countyTNRCCNumber"].ToString();
                        g.County_TNRCC_District_Number = rdr["countyTNRCCDistrictNumber"].ToString();
                        g.County_TNRCC_District_City = rdr["countyTNRCCDistrictCity"].ToString();
                        GLOCountyList.Add(g);
                    }
                }
            }
            return View("ManagerToolsEtc", GLOCountyList.ToList());
        }

        public JsonResult UpdateGLOCounties(double CountyCode, string GLOVoice, string GLOBeeper, string RRCNumb, string TNRCCNumb)
        {
            string sql = "UPDATE glocountylist SET countyGLOVoiceNumber=@GLOVoice, countyGLOBeeperNumber=@GLOBeeper, countyRRCNumber=@RRCNumb, countyTNRCCNumber=@TNRCCNumb WHERE countyCode=@cc";
            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@cc", CountyCode);
                    cmd.Parameters.AddWithValue("@GLOVoice", GLOVoice);
                    cmd.Parameters.AddWithValue("@GLOBeeper", GLOBeeper);
                    cmd.Parameters.AddWithValue("@RRCNumb", RRCNumb);
                    cmd.Parameters.AddWithValue("@TNRCCNumb", TNRCCNumb);
                    cmd.ExecuteNonQuery();
                }
            }
            return Json(new {success="Success"}, JsonRequestBehavior.AllowGet);
        }

        #endregion
        #region Cleanshot Functions
        public List<TheoChemCleanshotIncident> GetCleanshotids()
        {
            List<TheoChemCleanshotIncident> CleanshotidList = new List<TheoChemCleanshotIncident>();
            string sqlcmd = "SELECT TOP 100 * FROM theochemcleanshotincidents ORDER BY IncidentID DESC";
            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        TheoChemCleanshotIncident c = new TheoChemCleanshotIncident();
                        c.Incident_ID = sdr["incidentid"].ToString();
                        c.Ers_Operator = sdr["ersOp"].ToString();
                        c.Report_Date = sdr["rptDate"].ToString();
                        c.Report_Time = sdr["rptTime"].ToString();
                        c.Caller_Name = sdr["callerName"].ToString();
                        c.Caller_Phone = sdr["callerPhone"].ToString();
                        c.Caller_Affiliate = sdr["callerAff"].ToString();
                        c.Caller_Fax_Email = sdr["callerFaxEmail"].ToString();
                        c.Incident_City = sdr["incCity"].ToString();
                        c.Incident_State = sdr["incState"].ToString();
                        c.Incident_Country = sdr["incCountry"].ToString();
                        c.Incident_Time_Zone = sdr["incTimeZone"].ToString();
                        c.Incident_Date = sdr["incDate"].ToString();
                        c.Incident_Time = sdr["incTime"].ToString();
                        c.Question_1 = sdr["quest1"].ToString();
                        c.Question_2_Quantity = sdr["quest2Qty"].ToString();
                        c.Question_2_Units = sdr["quest2Units"].ToString();
                        c.Question_3 = sdr["quest3"].ToString();
                        c.Question_4 = sdr["quest4"].ToString();
                        c.Question_5 = sdr["quest5"].ToString();
                        c.Question_6 = sdr["quest6"].ToString();
                        c.Question_7 = sdr["quest7"].ToString();
                        c.Question_8 = sdr["quest8"].ToString();
                        c.Question_9 = sdr["quest9"].ToString();
                        c.Question_10_Yes_Or_No = sdr["quest10YesOrNo"].ToString();
                        c.Question_10_IfYes_What = sdr["quest10IfYesWhat"].ToString();
                        c.Question_11_Yes_Or_No = sdr["quest11YesOrNo"].ToString();
                        c.Question_11_If_Yes_What = sdr["quest11IfYesWhat"].ToString();
                        c.Question_12 = sdr["quest12"].ToString();
                        c.Question_13 = sdr["quest13"].ToString();
                        c.Question_14 = sdr["quest14"].ToString();
                        c.Question_15 = sdr["quest15"].ToString();
                        c.Question_16 = sdr["quest16"].ToString();
                        c.Question_17 = sdr["quest17"].ToString();
                        c.Add_It_Comments_Details = sdr["additCommentsDetails"].ToString();
                        c.Sub_Name = sdr["subName"].ToString();
                        c.Sub_Administrative_Contact = sdr["subAdminContact"].ToString();
                        c.Sub_Phone = sdr["subPhone"].ToString();
                        c.Sub_Fax = sdr["subFax"].ToString();
                        c.Sub_Email = sdr["subEmail"].ToString();
                        c.Sub_Address = sdr["subAddress"].ToString();
                        c.Sub_City_State_Zip = sdr["subCityStateZip"].ToString();
                        c.Email_Sent = sdr["emailsent"].ToString();
                        c.Comments = sdr["comments"].ToString();
                        c.Type = sdr["type"].ToString();
                        CleanshotidList.Add(c);
                    }
                }
            }
            return CleanshotidList;
        }
        public ActionResult SearchCleanshotids(FormCollection fc)
        {
            if (fc["btnCorrect"].ToString() == "Search")
            {
                List<TheoChemCleanshotIncident> CleanshotidList = new List<TheoChemCleanshotIncident>();
                string sqlcmd = "SELECT TOP 100 * FROM theochemcleanshotincidents WHERE incidentid LIKE '%" + fc["Cleanshotcbsearch"].ToString() + "%' ORDER BY IncidentID DESC";
                using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                    {
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            TheoChemCleanshotIncident c = new TheoChemCleanshotIncident();
                            c.Incident_ID = sdr["incidentid"].ToString();
                            c.Ers_Operator = sdr["ersOp"].ToString();
                            c.Report_Date = sdr["rptDate"].ToString();
                            c.Report_Time = sdr["rptTime"].ToString();
                            c.Caller_Name = sdr["callerName"].ToString();
                            c.Caller_Phone = sdr["callerPhone"].ToString();
                            c.Caller_Affiliate = sdr["callerAff"].ToString();
                            c.Caller_Fax_Email = sdr["callerFaxEmail"].ToString();
                            c.Incident_City = sdr["incCity"].ToString();
                            c.Incident_State = sdr["incState"].ToString();
                            c.Incident_Country = sdr["incCountry"].ToString();
                            c.Incident_Time_Zone = sdr["incTimeZone"].ToString();
                            c.Incident_Date = sdr["incDate"].ToString();
                            c.Incident_Time = sdr["incTime"].ToString();
                            c.Question_1 = sdr["quest1"].ToString();
                            c.Question_2_Quantity = sdr["quest2Qty"].ToString();
                            c.Question_2_Units = sdr["quest2Units"].ToString();
                            c.Question_3 = sdr["quest3"].ToString();
                            c.Question_4 = sdr["quest4"].ToString();
                            c.Question_5 = sdr["quest5"].ToString();
                            c.Question_6 = sdr["quest6"].ToString();
                            c.Question_7 = sdr["quest7"].ToString();
                            c.Question_8 = sdr["quest8"].ToString();
                            c.Question_9 = sdr["quest9"].ToString();
                            c.Question_10_Yes_Or_No = sdr["quest10YesOrNo"].ToString();
                            c.Question_10_IfYes_What = sdr["quest10IfYesWhat"].ToString();
                            c.Question_11_Yes_Or_No = sdr["quest11YesOrNo"].ToString();
                            c.Question_11_If_Yes_What = sdr["quest11IfYesWhat"].ToString();
                            c.Question_12 = sdr["quest12"].ToString();
                            c.Question_13 = sdr["quest13"].ToString();
                            c.Question_14 = sdr["quest14"].ToString();
                            c.Question_15 = sdr["quest15"].ToString();
                            c.Question_16 = sdr["quest16"].ToString();
                            c.Question_17 = sdr["quest17"].ToString();
                            c.Add_It_Comments_Details = sdr["additCommentsDetails"].ToString();
                            c.Sub_Name = sdr["subName"].ToString();
                            c.Sub_Administrative_Contact = sdr["subAdminContact"].ToString();
                            c.Sub_Phone = sdr["subPhone"].ToString();
                            c.Sub_Fax = sdr["subFax"].ToString();
                            c.Sub_Email = sdr["subEmail"].ToString();
                            c.Sub_Address = sdr["subAddress"].ToString();
                            c.Sub_City_State_Zip = sdr["subCityStateZip"].ToString();
                            c.Email_Sent = sdr["emailsent"].ToString();
                            c.Comments = sdr["comments"].ToString();
                            c.Type = sdr["type"].ToString();
                            CleanshotidList.Add(c);
                        }
                    }
                }
                ViewBag.LogsSelected = "CleanShot";
                ViewBag.CleanshotIDs = CleanshotidList.ToList();
                return View("Logs");
            } else if (fc["btnCorrect"].ToString() == "Revise") {
                ViewBag.Corrected = "true";
                ViewBag.LogsSelected = "CleanShot";
                TheoChemCleanshotIncident c = new TheoChemCleanshotIncident(Session["constring"].ToString(), fc["Cleanshotcbsearch"]);  //Gets the desired report and puts it into a custom class variable.
                return View("~/Views/OtherReports/CleanShotReport.cshtml", c);
            } else
            {
                return RedirectToAction("Logs", new { LogsSelected = "CleanShot" });
            }
        }
        public JsonResult UpdateCleanshot(string IncidentID, string Comments, string EmailSent)
        {
            string sql = "UPDATE theochemcleanshotincidents SET comments = '" + Comments + "', emailsent = '" + EmailSent + "' WHERE incidentId = '" + IncidentID + "'";
            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return Json(new { success = "Success" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region General Incident Functions
        public List<GeneralIncidentReportData> GetGenIncids()
        {
            List<GeneralIncidentReportData> GenIncidList = new List<GeneralIncidentReportData>();
            string sqlcmd = "SELECT TOP 100 * FROM generalincidentreportdata ORDER BY IncidentID DESC";
            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        GeneralIncidentReportData g = new GeneralIncidentReportData();
                        g.Incident_ID = sdr["IncidentId"].ToString();
                        g.Ers_Operator = sdr["ErsOperator"].ToString();
                        g.Date = sdr["Date"].ToString();
                        g.Subscribers_Name = sdr["SubscribersName"].ToString();
                        g.Reviewed_By = sdr["ReviewedBy"].ToString();
                        g.Reviewed_Date = sdr["ReviewedDate"].ToString();
                        g.Sent_Date = sdr["SentDate"].ToString();
                        g.Comments = sdr["Comments"].ToString();
                        g.Report_Type = sdr["ReportType"].ToString();
                        GenIncidList.Add(g);
                    }
                }
            }
            return GenIncidList;
        }

        public ActionResult SearchGenIncids(FormCollection fc)
        {
            if (fc["btnCorrect"].ToString() == "Search")
            {
                List<GeneralIncidentReportData> GenIncidList = new List<GeneralIncidentReportData>();
                string sqlcmd = "SELECT TOP 100 * FROM generalincidentreportdata WHERE incidentid LIKE '%" + fc["GenInccbsearch"].ToString() + "%' ORDER BY incidentid DESC";
                using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                    {
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            GeneralIncidentReportData g = new GeneralIncidentReportData();
                            g.Incident_ID = sdr["IncidentId"].ToString();
                            g.Ers_Operator = sdr["ErsOperator"].ToString();
                            g.Date = sdr["Date"].ToString();
                            g.Time = sdr["Time"].ToString();
                            g.Callers_Name = sdr["CallersName"].ToString();
                            g.Callers_Phone = sdr["CallersPhone"].ToString();
                            g.Callers_Affiliation = sdr["CallersAffiliation"].ToString();
                            g.Callers_Fax_Or_Email = sdr["CallersFaxOrEmail"].ToString();
                            g.Incident_Street = sdr["IncidentStreet"].ToString();
                            g.Incident_City = sdr["IncidentCity"].ToString();
                            g.Incident_Country = sdr["IncidentCountry"].ToString();
                            g.Incident_Date = sdr["IncidentDate"].ToString();
                            g.Incident_Time = sdr["IncidentTime"].ToString();
                            g.Incident_Time_Zone = sdr["IncidentTimeZone"].ToString();
                            g.Material_Name = sdr["MaterialName"].ToString();
                            g.Product_Number = sdr["ProductNumber"].ToString();
                            g.Quantity_Spilled = sdr["QuantitySpilled"].ToString();
                            g.Cleanup_Crew_Requirements = sdr["CleanUpCrewReqs"].ToString();
                            g.Agencies_On_Site = sdr["AgenciesOnSite"].ToString();
                            g.Accident_Or_Deliberate = sdr["AccidentOrDeliberate"].ToString();
                            g.Incident_Details = sdr["IncidentDetails"].ToString();
                            g.Involve_Fire = sdr["InvolveFire"].ToString();
                            g.Where_Did_You_Get_Our_Number = sdr["WhereDidYouGetOurNumber"].ToString();
                            g.Subscribers_Name = sdr["SubscribersName"].ToString();
                            g.Subscribers_MIS = sdr["SubscriberMIS"].ToString();
                            g.Type_Of_Exposure = sdr["TypeOfExposure"].ToString();
                            g.Num_Of_Casualties = sdr["NumOfCasualties"].ToString();
                            g.Num_Of_Injuries = sdr["NumOfInjuries"].ToString();
                            g.Med_Personnel_Name = sdr["MedPersonnelName"].ToString();
                            g.Patient_Name = sdr["PatientName"].ToString();
                            g.Patient_Condition = sdr["PatientCondition"].ToString();
                            g.Hospital_Clinic_Location = sdr["HospitalClinicLocation"].ToString();
                            g.Epa_Reg_No = sdr["EpaRegNo"].ToString();
                            g.Status_Of_Release = sdr["StatusOfRelease"].ToString();
                            g.Dispersion_Of_Msds_Information = sdr["DispersionOfMsdsInfo"].ToString();
                            g.Reviewed_By = sdr["ReviewedBy"].ToString();
                            g.Reviewed_Date = sdr["ReviewedDate"].ToString();
                            g.Sent_Date = sdr["SentDate"].ToString();
                            g.Comments = sdr["Comments"].ToString();
                            g.Date_Changed = sdr["DateChanged"].ToString();
                            g.Username = sdr["Username"].ToString();
                            g.Incident_Zip_Code = sdr["IncidentZipCode"].ToString();
                            g.Report_Type = sdr["ReportType"].ToString();
                            g.Callers_Phone_Ext = sdr["CallersPhoneExt"].ToString();
                            GenIncidList.Add(g);
                        }
                    }
                }
                ViewBag.LogsSelected = "GenInc";
                ViewBag.GenIncIDs = GenIncidList.ToList();
                return View("Logs");
            }
            else if (fc["btnCorrect"].ToString() == "Revise")
            {
                ViewBag.Updated = "true";
                ViewBag.LogsSelected = "GenInc";
                GeneralIncidentReportData g = new GeneralIncidentReportData(Session["constring"].ToString(), fc["GenInccbsearch"]);  //Gets the desired report and puts it into a custom class variable.
                ViewBag.ID = Int32.Parse(g.Incident_ID);
                return View("~/Views/OtherReports/GeneralIncident.cshtml", g);
            }
            else
            {
                return RedirectToAction("Logs", new { LogsSelected = "GenInc" });
            }
        }


        public JsonResult UpdateGenInc(string IncidentID, string Comments, string ReviewedDate, string SentDate)
        {
            string sql = "UPDATE generalincidentreportdata SET Comments = '" + Comments + "', ReviewedDate = '" + ReviewedDate + "', SentDate = '" + SentDate + "' WHERE IncidentID = '" + IncidentID + "'";
            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return Json(new { success = "Success" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Shell Oil Functions
        public List<ShellOilIncidentData> GetShellids()
        {
            List<ShellOilIncidentData> ShellidList = new List<ShellOilIncidentData>();
            string sqlcmd = "SELECT TOP 100 * FROM shelloilincidentdata ORDER BY incid DESC";
            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        ShellOilIncidentData s = new ShellOilIncidentData();
                        s.Inc_ID = Int32.Parse(sdr["incid"].ToString());
                        s.ERS_Operator = sdr["ersop"].ToString();
                        s.Date = sdr["date"].ToString();
                        s.Time = sdr["time"].ToString();
                        s.Caller_Name_1 = sdr["callername1"].ToString();
                        s.Caller_Name_2 = sdr["callername2"].ToString();
                        s.Caller_Name_3 = sdr["callername3"].ToString();
                        s.Caller_Phone_1 = sdr["callerphone1"].ToString();
                        s.Caller_Phone_2 = sdr["callerphone2"].ToString();
                        s.Caller_Phone_3 = sdr["callerphone3"].ToString();
                        s.Caller_Ext_1 = sdr["callerext1"].ToString();
                        s.Caller_Ext_2 = sdr["callerext2"].ToString();
                        s.Caller_Ext_3 = sdr["callerext3"].ToString();
                        s.Caller_Alt_Phone_1 = sdr["calleraltphone1"].ToString();
                        s.Caller_Alt_Phone_2 = sdr["calleraltphone2"].ToString();
                        s.Caller_Alt_Phone_3 = sdr["calleraltphone3"].ToString();
                        s.Caller_Alt_Ext_1 = sdr["calleraltext1"].ToString();
                        s.Caller_Alt_Ext_2 = sdr["calleraltext2"].ToString();
                        s.Caller_Alt_Ext_3 = sdr["calleraltext3"].ToString();
                        s.Comments = sdr["comments"].ToString();
                        s.Staff_Name = sdr["staffname"].ToString();
                        s.Staff_Phone = sdr["staffphone"].ToString();
                        s.Staff_Ext = sdr["staffext"].ToString();
                        s.Staff_Report_Time = sdr["staffreporttime"].ToString();
                        s.Staff_Time_Zone = sdr["stafftimezone"].ToString();
                        s.Follow_Up_Name_1 = sdr["followupname1"].ToString();
                        s.Follow_Up_Name_2 = sdr["followupname2"].ToString();
                        s.Follow_Up_Name_3 = sdr["followupname3"].ToString();
                        s.Follow_Up_Name_4 = sdr["followupname4"].ToString();
                        s.Follow_Up_Name_5 = sdr["followupname5"].ToString();
                        s.Follow_Up_Time_1 = sdr["followuptime1"].ToString();
                        s.Follow_Up_Time_2 = sdr["followuptime2"].ToString();
                        s.Follow_Up_Time_3 = sdr["followuptime3"].ToString();
                        s.Follow_Up_Time_4 = sdr["followuptime4"].ToString();
                        s.Follow_Up_Time_5 = sdr["followuptime5"].ToString();
                        s.Follow_Up_Time_Zone_1 = sdr["followuptimezone1"].ToString();
                        s.Follow_Up_Time_Zone_2 = sdr["followuptimezone2"].ToString();
                        s.Follow_Up_Time_Zone_3 = sdr["followuptimezone3"].ToString();
                        s.Follow_Up_Time_Zone_4 = sdr["followuptimezone4"].ToString();
                        s.Follow_Up_Time_Zone_5 = sdr["followuptimezone5"].ToString();
                        s.Follow_Up_Phone_1 = sdr["followupphone1"].ToString();
                        s.Follow_Up_Phone_2 = sdr["followupphone2"].ToString();
                        s.Follow_Up_Phone_3 = sdr["followupphone3"].ToString();
                        s.Follow_Up_Phone_4 = sdr["followupphone4"].ToString();
                        s.Follow_Up_Phone_5 = sdr["followupphone5"].ToString();
                        s.Follow_Up_Ext_1 = sdr["followupext1"].ToString();
                        s.Follow_Up_Ext_2 = sdr["followupext2"].ToString();
                        s.Follow_Up_Ext_3 = sdr["followupext3"].ToString();
                        s.Follow_Up_Ext_4 = sdr["followupext4"].ToString();
                        s.Follow_Up_Ext_5 = sdr["followupext5"].ToString();
                        s.Email_Sent = sdr["emailsent"].ToString();
                        s.Notes = sdr["notes"].ToString();
                        ShellidList.Add(s);
                    }
                }
            }
            return ShellidList;
        }

        public ActionResult SearchShellIDs(FormCollection fc)
        {
            if (fc["btnCorrect"].ToString() == "Search")
            {
                List<ShellOilIncidentData> ShellidList = new List<ShellOilIncidentData>();
                string sqlcmd = "SELECT TOP 100 * FROM shelloilincidentdata WHERE incid LIKE '%" + fc["Shellcbsearch"].ToString() + "%' ORDER BY incid DESC";
                using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                    {
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            ShellOilIncidentData s = new ShellOilIncidentData();
                            s.Inc_ID = Int32.Parse(sdr["incid"].ToString());
                            s.ERS_Operator = sdr["ersop"].ToString();
                            s.Date = sdr["date"].ToString();
                            s.Time = sdr["time"].ToString();
                            s.Caller_Name_1 = sdr["callername1"].ToString();
                            s.Caller_Name_2 = sdr["callername2"].ToString();
                            s.Caller_Name_3 = sdr["callername3"].ToString();
                            s.Caller_Phone_1 = sdr["callerphone1"].ToString();
                            s.Caller_Phone_2 = sdr["callerphone2"].ToString();
                            s.Caller_Phone_3 = sdr["callerphone3"].ToString();
                            s.Caller_Ext_1 = sdr["callerext1"].ToString();
                            s.Caller_Ext_2 = sdr["callerext2"].ToString();
                            s.Caller_Ext_3 = sdr["callerext3"].ToString();
                            s.Caller_Alt_Phone_1 = sdr["calleraltphone1"].ToString();
                            s.Caller_Alt_Phone_2 = sdr["calleraltphone2"].ToString();
                            s.Caller_Alt_Phone_3 = sdr["calleraltphone3"].ToString();
                            s.Caller_Alt_Ext_1 = sdr["calleraltext1"].ToString();
                            s.Caller_Alt_Ext_2 = sdr["calleraltext2"].ToString();
                            s.Caller_Alt_Ext_3 = sdr["calleraltext3"].ToString();
                            s.Comments = sdr["comments"].ToString();
                            s.Staff_Name = sdr["staffname"].ToString();
                            s.Staff_Phone = sdr["staffphone"].ToString();
                            s.Staff_Ext = sdr["staffext"].ToString();
                            s.Staff_Report_Time = sdr["staffreporttime"].ToString();
                            s.Staff_Time_Zone = sdr["stafftimezone"].ToString();
                            s.Follow_Up_Name_1 = sdr["followupname1"].ToString();
                            s.Follow_Up_Name_2 = sdr["followupname2"].ToString();
                            s.Follow_Up_Name_3 = sdr["followupname3"].ToString();
                            s.Follow_Up_Name_4 = sdr["followupname4"].ToString();
                            s.Follow_Up_Name_5 = sdr["followupname5"].ToString();
                            s.Follow_Up_Time_1 = sdr["followuptime1"].ToString();
                            s.Follow_Up_Time_2 = sdr["followuptime2"].ToString();
                            s.Follow_Up_Time_3 = sdr["followuptime3"].ToString();
                            s.Follow_Up_Time_4 = sdr["followuptime4"].ToString();
                            s.Follow_Up_Time_5 = sdr["followuptime5"].ToString();
                            s.Follow_Up_Time_Zone_1 = sdr["followuptimezone1"].ToString();
                            s.Follow_Up_Time_Zone_2 = sdr["followuptimezone2"].ToString();
                            s.Follow_Up_Time_Zone_3 = sdr["followuptimezone3"].ToString();
                            s.Follow_Up_Time_Zone_4 = sdr["followuptimezone4"].ToString();
                            s.Follow_Up_Time_Zone_5 = sdr["followuptimezone5"].ToString();
                            s.Follow_Up_Phone_1 = sdr["followupphone1"].ToString();
                            s.Follow_Up_Phone_2 = sdr["followupphone2"].ToString();
                            s.Follow_Up_Phone_3 = sdr["followupphone3"].ToString();
                            s.Follow_Up_Phone_4 = sdr["followupphone4"].ToString();
                            s.Follow_Up_Phone_5 = sdr["followupphone5"].ToString();
                            s.Follow_Up_Ext_1 = sdr["followupext1"].ToString();
                            s.Follow_Up_Ext_2 = sdr["followupext2"].ToString();
                            s.Follow_Up_Ext_3 = sdr["followupext3"].ToString();
                            s.Follow_Up_Ext_4 = sdr["followupext4"].ToString();
                            s.Follow_Up_Ext_5 = sdr["followupext5"].ToString();
                            s.Email_Sent = sdr["emailsent"].ToString();
                            s.Notes = sdr["notes"].ToString();
                            ShellidList.Add(s);
                        }
                    }
                }
                ViewBag.LogsSelected = "Shell";
                ViewBag.ShellIDs = ShellidList.ToList();
                return View("Logs");
            }
            else if (fc["btnCorrect"].ToString() == "Revise")
            {
                ViewBag.Updated = "true";
                ShellOilIncidentData glo = new ShellOilIncidentData(Session["constring"].ToString(), Int32.Parse(fc["Shellcbsearch"].ToString()));  //Gets the desired report and puts it into a custom class variable.
                return View("~/Views/OtherReports/ShellOilReport.cshtml", glo);
            }
            else
            {
                return RedirectToAction("Logs", new { LogsSelected = "Shell" });
            }
        }

        public JsonResult UpdateShellOil(string IncidentID, string Comments, string EmailSent)
        {
            string sql = "UPDATE shelloilincidentdata SET notes = '" + Comments + "', emailsent = '" + EmailSent + "' WHERE incid = '" + IncidentID + "'";
            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return Json(new { success = "Success" }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region HWCG Emails
        public ActionResult HWCGEmail(string ReportID)
        {
            if (ReportID == null)
            {
                ViewBag.ReportID = 0;
            } else
            {
                ViewBag.ReportID = ReportID;
            }
            return View();
        }
        public ActionResult SendHWCGEmail(string SelectedID, FormCollection fc)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("ers@ehs.com");
            //string emails = "mpepitone@ehs.com,ers@ehs.com,tgillis@ehs.com";
            string emails = "";
            string body = "";
            string subject = "";

            if (fc["submit"].ToString() == "Send Test Email")
            {
                emails = "ers@ehs.com,mpepitone@ehs.com,anital@hwcg.org";
                body = "HWCG LLC Test Event Notification Form <br /> Please see attachment.";
                subject = "HWCG LLC Test Event Notification";

            }
            else
            {
                emails = "ers@ehs.com,mpepitone@ehs.com,andy.jefferies@imr247.com,lance.labiche@imr247.com,Jake.Scott@imr247.com,Allen.Cowart@imr247.com,amir.paknejad@imr247.com,Hamed.mojarrad@imr247.com,Paul.drake@imr247.com,EOC@IMR247.com,mitchg@hwcg.org,anital@hwcg.org,craigc@hwcg.org,jml@beaconoffshore.com,eventnotifications@hwcg.org";
                body = "HWCG LLC Event Notification Form <br /> Please see attachment.";
                subject = "HWCG LLC Event Notification";
            }

            string[] emaillist = emails.Split(',');
            string filepath = @"\\chem-fs1.ers.local\Completed Reports\Helix\" + SelectedID.ToString() + ".pdf";  //Temp variable to hold the report path.

            //Need a list created for SendGrid to send to multiple email address.
            List<EmailAddress> to = new List<EmailAddress>();
            foreach (string e in emaillist)
            {
                if (e.Trim() != null && e.Trim() != "")
                {
                    to.Add(new EmailAddress(e.Trim()));
                }
            }

            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, "", body);

            //Attach PDF
            var filename = Path.GetFileName(filepath);
            var bytes = System.IO.File.ReadAllBytes(filepath); //Get Attachment Bytes
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment(filename, file); //Add Attachment to email.
            var response = client.SendEmailAsync(msg);

            string path = @"\\chem-fs1.ers.local\Log Files\CRMEmails.log";
            StreamWriter log;
            if (System.IO.File.Exists(path))
                log = System.IO.File.AppendText(path);
            else
                log = System.IO.File.CreateText(path);
            log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\n ReportType: HWCG \n Message: " + response.Result.StatusCode + "\n" + "Subject Line: " + subject + " -- " + SelectedID.ToString() + "\n\n\n");
            log.Close();

            string ResultCode = response.Result.StatusCode.ToString();
            return RedirectToAction("HWCGEmail", "ManagerTools", new { Result = ResultCode });

        }
        #endregion
    }
}