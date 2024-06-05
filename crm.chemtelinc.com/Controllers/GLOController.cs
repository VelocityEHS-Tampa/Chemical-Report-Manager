using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ChemicalLibrary;
using crm.chemtelinc.com.Models;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace crm.chemtelinc.com.Controllers
{
    public class GLOController : Controller
    {
        string profile = System.Environment.UserName.ToLower();
        string corrected = "false"; //Flag to determine if the current report is a corrected report
        string report = "nuevo"; //Flag to determine if the current report is a new report
        string updated = "false"; //Flag to determine if the current report is an updated report
        string BackToReport = "false"; //Flag to determine if the current report is an updated report
        public string SpillID = ""; //Class-level variable to hold a spill ID that will be passed from the manager tools log
        string ersoperator = ""; //Temp variable
        string glo = "";
        bool ok = true;
        string constring = Properties.Settings.Default.chemicalConnectionString;
        string constringTest = Properties.Settings.Default.chemicalTestConnectionString; //Class-level variable containg the connection string to the database.

        #region GLO Report Page Load
        public ActionResult GLOReport(string txtspillid)
        {
            //Check if user is logged in, if not, force login.
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                ViewBag.ErrorMessage = "You must login before proceeding!";
                return RedirectToAction("Index", "Home", new { e = "You must login before proceeding!" });
            }
            //if (updated == "false")
                //YearCheck(txtspillid);
            TimeZone tzone = TimeZone.CurrentTimeZone;
            DateTime today = DateTime.Now;
            string date = DateTime.Now.ToShortDateString(); //Gets the current date.
            string time = DateTime.Now.AddHours(-1).ToString("HHmm"); //Gets the current time in military timw.
            CalculateTime(time);  //This method converts the current time into central time.
            int hr = int.Parse(time.Substring(0, 2));
            if (hr == 0)
                date = DateTime.Now.AddDays(-1).ToShortDateString();
            else
                date = DateTime.Now.ToShortDateString();
            ViewBag.txtreportdate = date;
            ViewBag.Updated = "false";
            ViewBag.Corrected = "false";
            ViewBag.BackToReport = "false";
            ViewBag.VoidedReport = "false";
            return View(new GLOBaseReportData());
        }
        public ActionResult CorrectedGLO(FormCollection fc)
        {
            int id = 0; //Initializes the ID variable to 0.
            id = int.Parse(fc["cbsearch"].ToString()); //Converts he ID to an integer.
            GLOID gid = new GLOID(Session["constring"].ToString(), id);
            gid.Available = 0;
            gid.User = "";
            Update.UpdateGLOIDs(Session["constring"].ToString(), gid); //This line and the previous lines make the current ID available so it can be reused.
            if (fc["UpdateOrCorrect"] == "Corrected")
            {
                corrected = "true";  //Sets the corrected flag to true.
                ViewBag.Corrected = "true";
            }
            else if (fc["UpdateOrCorrect"] == "Updated")
            {
                updated = "true";  //Sets the corrected flag to true.
                ViewBag.Updated = "true";
            }
            else if (fc["UpdateOrCorrect"] == "Back To Report")
            {
                BackToReport = "true";
                ViewBag.BackToReport = "true";
            }
            else if (fc["UpdateOrCorrect"] == "Void Report")
            {
                VoidReport(fc["cbsearch"].ToString());
                BackToReport = "true";
                ViewBag.BackToReport = "true";
            }
            report = "All";
            GLOBaseReportData glo = new GLOBaseReportData(Session["constring"].ToString(), fc["cbsearch"]);  //Gets the desired report and puts it into a custom class variable.
            return View("GLOReport", glo);
        }
        private void YearCheck(string txtspillid)
        {
            try
            {
                int id = GLOIDCreation.GetLastID(Session["constring"].ToString()); //Calls a static class method to get the last ID in the ID table.
                string year = id.ToString().Substring(0, 4);  //Takes the ID and gets the first 4 digits, which represents the current year.
                if (GLOIDCreation.CheckYear(year)) //Calls a static class method that checks the year against the current date.
                {
                    int oldid = GLOIDCreation.SearchForAvailableID(Session["constring"].ToString()); //Calls a static class method to look for an ID in the database that's available.
                    if (oldid > 0) //This checks to see if an available ID was found.
                    {
                        if (Search.CheckGLOID(Session["constring"].ToString(), oldid.ToString())) //Checks to see if the ID has a report associated with it.  Return true if no report has that ID.
                        {
                            id = oldid; //Copies the ID to a temp variable.
                            GLOID gid = new GLOID(Session["constring"].ToString(), id); //Retrieves the ID record from the database and puts it in a custom class variable.
                            gid.Available = 1;
                            gid.User = "None";
                            ChemicalLibrary.Update.UpdateGLOIDs(Session["constring"].ToString(), gid); //Updates the ID record to make it unavailable.
                        }
                        else
                        {
                            GLOID gid = new GLOID(Session["constring"].ToString(), oldid);
                            GLOBaseReportData g = new GLOBaseReportData(Session["constring"].ToString(), oldid.ToString());
                            gid.Available = 1;
                            gid.User = "mpepitone";
                            ChemicalLibrary.Update.UpdateGLOIDs(Session["constring"].ToString(), gid);
                            //YearCheck(); //Recursive call that happens only when the ID has a report with it.  The call is made in order to get the next available ID.
                            ok = false; //Flag used to keep the first function call from overwriting the ID textbox with the previous ID.
                        }
                    }
                    else
                    {
                        if (ok) //Statements in this block execute only if no recursion takes place.
                        {
                            id = GLOIDCreation.Increment(id); //Calls a static class method to increment the last ID by 1.
                            GLOID gid = new GLOID(); //Creates a custom class variable.
                            gid.ID = id;
                            gid.Available = 1;
                            gid.User = "";
                            Add.AddGLOIDs(Session["constring"].ToString(), gid); //Adds the newly created ID to the database as unavailable
                            GLOLastID glid = new GLOLastID(Session["constring"].ToString(), 1); //The next few lines gets the new ID and records it in a special table.
                            glid.Report_ID = id;
                            ChemicalLibrary.Update.UpdateGLOLastID(Session["constring"].ToString(), glid);
                        }
                    }
                    if (ok)
                        ViewBag.txtspillid = id.ToString(); //Puts the new ID in the form only if no recursive calls are made.
                }
                else
                {
                    NewYear(int.Parse(year), txtspillid); //If the condition of the first if returns false, This method is called, which generates a new ID for the new year.
                }
            }
            catch (Exception ex)
            {
                string mod = "YearCheck";
                string pfile = "GLOController.cs";
                //Write Error Message in Log
                string path = @"\\chem-fs1.ers.local\Log Files\Chemical.log";
                StreamWriter log;
                if (System.IO.File.Exists(path))
                    log = System.IO.File.AppendText(path);
                else
                    log = System.IO.File.CreateText(path);
                log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" +
                    "Time: " + DateTime.Now.ToShortTimeString() + "\n" +
                    "User: " + Session["username"].ToString() + "\n" +
                    "Error Message: " + ex.Message + "\n" +
                    "File: " + pfile + "\n" +
                    "Method: " + mod + "\n\n\n"
                );
                log.Close();
                RedirectToAction("Error", "Home", new { ErrorMessage = ex.Message});
            }
        }
        private void NewYear(int year, string txtspillid)
        {
            year++;
            string yr = year.ToString() + "0001";
            int id = int.Parse(yr);
            txtspillid = yr;
            GLOID gid = new GLOID(); //Creates a custom class variable.
            gid.ID = id;
            gid.Available = 1;
            gid.User = "";
            Add.AddGLOIDs(Session["constring"].ToString(), gid); //Adds the newly created ID to the database as unavailable
            GLOLastID glid = new GLOLastID(Session["constring"].ToString(), 1); //The next few lines gets the new ID and records it in a special table.
            glid.Report_ID = id;
            ChemicalLibrary.Update.UpdateGLOLastID(Session["constring"].ToString(), glid);
        }
        private void CalculateTime(string time)
        {
            string hour = time.Substring(0, 2); //Gets the hour portion of the time.
            string min = time.Substring(2, 2); //Gets the minute portion of the time
            int hr = int.Parse(hour); //Converts the hour to an integer.
            //if (hr != 1)
            //{
            if (hr == 0)
                hour = "23";
            else
            {
                --hr; //Decrements the hour by 1.
                if (hr >= 0 && hr <= 9) //If the hour is between 1 and 9, put a 0 in front of the number and convert it back to a string/
                    hour = "0" + hr.ToString();
                else
                    hour = hr.ToString(); //If the hour is 10 or greater, just convert it to a string.
            }
            time = hour + min; //Put the time back together.
            ViewBag.txtreporttime = time; //Put the time in the textbox.
        }
        public ActionResult GLOPhoneNumbers()
        {
            string SelectedCounty = Request.QueryString["County"];
            GLOCountyList countycode = new GLOCountyList(Session["constring"].ToString(), SelectedCounty);

            GLOCountyList CountyInfo = new GLOCountyList(Session["constring"].ToString(), countycode.County_Code);
            return View(CountyInfo);
        }

        public ActionResult VoidReport(string id)
        {
            GLOBaseReportData g = new GLOBaseReportData();  //Calls the custom class constructor.
            g = GetVoidData(id);
            Update.UpdateGLOBaseReportData(Session["constring"].ToString(), g);  //Static class method that adds the data to the database.
            GLOBaseReportData g2 = new GLOBaseReportData(); // reset the model to clear out the ID before returning to the GLO report.
            return View("GLOReport", g2);
        }
        #endregion

        #region submit new glo report
        public ActionResult SubmitGLOReport(FormCollection fc)
        {
            if (fc["SubmitGLOForm"].ToString() == "Commit Report")
            {
                string ReportID = "";
                if (CheckForVoidID() == "")
                {
                    ReportID = CommitReport(fc); //Run function to add first half of report to database and get GLO ID
                } else
                {
                    ReportID = CheckForVoidID();
                    GLOBaseReportData g = new GLOBaseReportData();  //Calls the custom class constructor.
                    g = GetData(fc); //This method returns the form data and puts it in the custom class variable.
                    g.Spill_ID = ReportID; //Set the ID in the model to the voided ID to update the proper ID.
                    Update.UpdateGLOBaseReportData(Session["constring"].ToString(), g);  //Static class method that adds the data to the database.
                    ViewBag.VoidedReport = "true";
                }
                report = "All";
                ViewBag.Committed = "true";
                GLOBaseReportData glo = new GLOBaseReportData(Session["constring"].ToString(), ReportID);  //Gets the desired report and puts it into a custom class variable.
                return View("GLOReport", glo);
            }
            else
            {
                GLOBaseReportData g = new GLOBaseReportData();  //Calls the custom class constructor.
                g = GetData(fc); //This method returns the form data and puts it in the custom class variable.
                Update.UpdateGLOBaseReportData(Session["constring"].ToString(), g);  //Static class method that adds the data to the database.
                GLOID gid = new GLOID();  //Creates the ID class variable.
                gid.ID = int.Parse(fc["txtspillid"].ToString());
                gid.Available = 1;
                gid.User = g.Report_Taken_By;
                Update.UpdateGLOIDs(Session["constring"].ToString(), gid); //Updates the ID record with a 1 and the operator's username.
                string reportpath = CreateReport(fc["txtspillid"].ToString()); //This calls the method to create the report and returns the path to the report file so the email form can attach the report.
            
                //Set ViewBag variables to use on view page.
                ViewBag.GLOReportPath = reportpath; //Puts the path to the report in the email form's class-level variable.
                ViewBag.glo = "true";  //Sets the email form's flag to let it know this is a GLO report and not a line report.
                ViewBag.Corrected = fc["Corrected"].ToString();
                ViewBag.Report = report;
                ViewBag.FilePath = @"\\chem-fs1.ers.local\completed reports\GLO\" + DateTime.Now.Year + @"\" + fc["txtspillid"].ToString() + ".pdf";
            
                string agcy1 = g.Agcy_Name_1;//From this line through the 2 if statements, a reminder is built for the email form to indicate where the report should be emailed.
                string where1 = g.Whr1;
                string subject = g.Spill_ID + " " + g.W1;
                string final = "";
                final = agcy1 + " - " + where1;

                //Create Reminder label text.
                if (g.Agcy_Name_2 != "N/A" && g.Whr2 != "")
                {
                    final += ", " + g.Agcy_Name_2 + "-" + g.Whr2;
                }
                if (g.Agcy_Name_3 != "N/A" && g.Whr3 != "")
                {
                    final += ", " + g.Agcy_Name_3 + "-" + g.Whr3;
                }
                ViewBag.ReminderLbl = "This email should be sent to the following: " + final;

                //Create the subject line for a GLO report.
                if (g.Drill_Txt == "YES")
                {
                    subject += " (DRILL)";
                }
                if (fc["Corrected"].ToString() == "true")
                {
                    subject += " (CORRECTED)";
                }
                ViewBag.Subject = subject;

                return View("GLOEmailForm", g);
            }
        }
        [HttpGet]
        private string CommitReport(FormCollection fc)
        {
            string NewID = "0";
            string DrillBit = "FALSE";
            string spillinwater = "";
            string spillinair = "";
            string spillonland = "";
            string coastalwaters = "";
            string user = "";

            if (fc["Drill_Txt"] == "YES")
            {
                DrillBit = "FALSE";
            }
            if (fc["SpillType"] == "rbland") { spillonland = "TRUE"; }
            else if (fc["SpillType"] == "rbspillinwater") { spillinwater = "TRUE"; }
            else if (fc["SpillType"] == "rbcoastalwater") { coastalwaters = "TRUE"; }
            else if (fc["SpillType"] == "rbairrelease") { spillinair = "TRUE"; }

            if (fc["ersop"] != "")
            {
                user = fc["ersop"];
            } else
            {
                user = Session["Username"].ToString().ToUpper();
            }


            string strsql = "INSERT INTO globasereportdata (fDrill, txtDrilltxt, txtReportTakenBy, txtReportPartyAffiliation, datReportTakenDate, datReportTakenTime, txtNotificationAgency, txtDischargeReportedBy, txtDischargedPhone1, txtDischargedPhone2, datDischargeDate, datDischargeTime, txtMaterial1, dblCASUN1, dblAmtSpilled1, txtUnitRecovered1, txtMaterial2, dblCASUN2, dblAmtSpilled2, txtUnitRecovered2, txtMaterial3, dblCASUN3, dblAmtSpilled3, txtUnitRecovered3, txtMaterial4, dblCASUN4, dblAmtSpilled4, txtUnitRecovered4, txtMaterial5, dblCASUN5, dblAmtSpilled5, txtUnitRecovered5, wSpillCounty, wOrigin, fSpillInWater, fSpillAirRelease, fCoastalWater, fLand, txtSpillReceivingWater, dblSpillAmountInWater, txtSpillAmountInWaterUnits, memSpillLocation, dblRRCLeaseNumber, txtRRCLeaseName, txtRRCFieldName, txtLandOwner, memActionsTakenCleanUpStatus, txtNRCNumber, txtAgencyName1, txtAgencyName2, txtAgencyName3, datDate1, datDate2, datDate3, txtWhere1, txtWhere2, txtWhere3, txtWho1, txtWho2, txtWho3, datTime1, datTime2, datTime3, txtSpiller, txtSpillerAddress, txtSpillerCity, txtSpillerState, txtSpillerZipCode, txtSpillerContact, txtSpillerContactPhone, DateSearch, datTi1, datTi2, datTi3) ";
            strsql += "VALUES (@fDrill, @txtDrilltxt, @txtReportTakenBy, @txtReportPartyAffiliation, @datReportTakenDate, @datReportTakenTime, @txtNotificationAgency, @txtDischargeReportedBy, @txtDischargedPhone1, @txtDischargedPhone2, @datDischargeDate, @datDischargeTime, @txtMaterial1, @dblCASUN1, @dblAmtSpilled1, @txtUnitRecovered1, @txtMaterial2, @dblCASUN2, @dblAmtSpilled2, @txtUnitRecovered2, @txtMaterial3, @dblCASUN3, @dblAmtSpilled3, @txtUnitRecovered3, @txtMaterial4, @dblCASUN4, @dblAmtSpilled4, @txtUnitRecovered4, @txtMaterial5, @dblCASUN5, @dblAmtSpilled5, @txtUnitRecovered5, @wSpillCounty, @wOrigin, @fSpillInWater, @fSpillAirRelease, @fCoastalWater, @fLand, @txtSpillReceivingWater, @dblSpillAmountInWater, @txtSpillAmountInWaterUnits, @memSpillLocation, @dblRRCLeaseNumber, @txtRRCLeaseName, @txtRRCFieldName, @txtLandOwner, @memActionsTakenCleanUpStatus, @txtNRCNumber, @txtAgencyName1, @txtAgencyName2, @txtAgencyName3, @datDate1, @datDate2, @datDate3, @txtWhere1, @txtWhere2, @txtWhere3, @txtWho1, @txtWho2, @txtWho3, @datTime1, @datTime2, @datTime3, @txtSpiller, @txtSpillerAddress, @txtSpillerCity, @txtSpillerState, @txtSpillerZipCode, @txtSpillerContact, @txtSpillerContactPhone, @DateSearch, @datTi1, @datTi2, @datTi3)";
            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(strsql, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@fDrill", DrillBit);
                    cmd.Parameters.AddWithValue("@txtDrilltxt", fc["Drill_Txt"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtReportTakenBy", user);
                    cmd.Parameters.AddWithValue("@txtReportPartyAffiliation", fc["txtreportaffiliation"].ToUpper());
                    cmd.Parameters.AddWithValue("@datReportTakenDate", fc["txtreportdate"]);
                    cmd.Parameters.AddWithValue("@datReportTakenTime", fc["txtreporttime"]);
                    cmd.Parameters.AddWithValue("@txtNotificationAgency", fc["txtagencynotification"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtDischargeReportedBy", fc["txtreportedby"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtDischargedPhone1", fc["txtdischargedphone1"]);
                    cmd.Parameters.AddWithValue("@txtDischargedPhone2", fc["txtdischargedphone2"]);
                    cmd.Parameters.AddWithValue("@datDischargeDate", fc["datincidentdate"]);
                    cmd.Parameters.AddWithValue("@datDischargeTime", fc["txtincidenttime"]);
                    cmd.Parameters.AddWithValue("@txtMaterial1", fc["txtmaterial1"].ToUpper());
                    cmd.Parameters.AddWithValue("@dblCASUN1", fc["txtcasun1"].ToUpper());
                    cmd.Parameters.AddWithValue("@dblAmtSpilled1", fc["txtamountspilled1"]);
                    cmd.Parameters.AddWithValue("@txtUnitRecovered1", fc["cbunits1"]);
                    cmd.Parameters.AddWithValue("@txtMaterial2", fc["txtmaterial2"].ToUpper());
                    cmd.Parameters.AddWithValue("@dblCASUN2", fc["txtcasun2"].ToUpper());
                    cmd.Parameters.AddWithValue("@dblAmtSpilled2", fc["txtamountspilled2"]);
                    cmd.Parameters.AddWithValue("@txtUnitRecovered2", fc["cbunits2"]);
                    cmd.Parameters.AddWithValue("@txtMaterial3", fc["txtmaterial3"].ToUpper());
                    cmd.Parameters.AddWithValue("@dblCASUN3", fc["txtcasun3"].ToUpper());
                    cmd.Parameters.AddWithValue("@dblAmtSpilled3", fc["txtamountspilled3"]);
                    cmd.Parameters.AddWithValue("@txtUnitRecovered3", fc["cbunits3"]);
                    cmd.Parameters.AddWithValue("@txtMaterial4", fc["txtmaterial4"].ToUpper());
                    cmd.Parameters.AddWithValue("@dblCASUN4", fc["txtcasun4"].ToUpper());
                    cmd.Parameters.AddWithValue("@dblAmtSpilled4", fc["txtamountspilled4"]);
                    cmd.Parameters.AddWithValue("@txtUnitRecovered4", fc["cbunits4"]);
                    cmd.Parameters.AddWithValue("@txtMaterial5", fc["txtmaterial5"].ToUpper());
                    cmd.Parameters.AddWithValue("@dblCASUN5", fc["txtcasun5"].ToUpper());
                    cmd.Parameters.AddWithValue("@dblAmtSpilled5", fc["txtamountspilled5"]);
                    cmd.Parameters.AddWithValue("@txtUnitRecovered5", fc["cbunits5"]);
                    cmd.Parameters.AddWithValue("@wSpillCounty", fc["cbcounty"]);
                    cmd.Parameters.AddWithValue("@wOrigin", fc["cborigin"]);
                    cmd.Parameters.AddWithValue("@fSpillInWater", spillinwater);
                    cmd.Parameters.AddWithValue("@fSpillAirRelease", spillinair);
                    cmd.Parameters.AddWithValue("@fCoastalWater", coastalwaters);
                    cmd.Parameters.AddWithValue("@fLand", spillonland);
                    cmd.Parameters.AddWithValue("@txtSpillReceivingWater", fc["txtreceivingwater"].ToUpper());
                    cmd.Parameters.AddWithValue("@dblSpillAmountInWater", fc["txtamountinwater"]);
                    cmd.Parameters.AddWithValue("@txtSpillAmountInWaterUnits", fc["cbamountinwaterunits"].ToUpper());
                    cmd.Parameters.AddWithValue("@memSpillLocation", fc["txtincidentlocation"].ToUpper());
                    cmd.Parameters.AddWithValue("@dblRRCLeaseNumber", fc["txtrrcleasenumber"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtRRCLeaseName", fc["txtrrcleasename"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtRRCFieldName", fc["txtrrcfieldname"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtLandOwner", fc["txtrrclandowner"].ToUpper());
                    cmd.Parameters.AddWithValue("@memActionsTakenCleanUpStatus", fc["txtdescription"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtNRCNumber", fc["txtnrcnumber"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtAgencyName1", fc["cbagency1"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtAgencyName2", fc["cbagency2"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtAgencyName3", fc["cbagency3"].ToUpper());
                    cmd.Parameters.AddWithValue("@datDate1", fc["txtdate1"]);
                    cmd.Parameters.AddWithValue("@datDate2", fc["txtdate2"]);
                    cmd.Parameters.AddWithValue("@datDate3", fc["txtdate3"]);
                    cmd.Parameters.AddWithValue("@txtWhere1", fc["txtwhere1"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtWhere2", fc["txtwhere2"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtWhere3", fc["txtwhere3"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtWho1", fc["txtwho1"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtWho2", fc["txtwho2"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtWho3", fc["txtwho3"].ToUpper());
                    cmd.Parameters.AddWithValue("@datTime1", fc["txttime1"]);
                    cmd.Parameters.AddWithValue("@datTime2", fc["txttime2"]);
                    cmd.Parameters.AddWithValue("@datTime3", fc["txttime3"]);
                    cmd.Parameters.AddWithValue("@txtSpiller", fc["txtspiller"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtSpillerAddress", fc["txtspilleraddress"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtSpillerCity", fc["txtspillercity"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtSpillerState", fc["txtspillerstate"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtSpillerZipCode", fc["txtspillerzipcode"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtSpillerContact", fc["txtcontactperson"].ToUpper());
                    cmd.Parameters.AddWithValue("@txtSpillerContactPhone", fc["txtcontactphone"]);
                    cmd.Parameters.AddWithValue("@DateSearch", DateTime.Now.ToShortDateString());
                    //Insert these before submit due to cancelling out the 4 0's and only adding 1.
                    cmd.Parameters.AddWithValue("@datTi1", fc["txtti1"]);
                    cmd.Parameters.AddWithValue("@datTi2", fc["txtti2"]);
                    cmd.Parameters.AddWithValue("@datTi3", fc["txtti3"]);
                    cmd.ExecuteNonQuery();
                }
            }

            string sqlcmd2 = "SELECT TOP 1 cntSpillId FROM globasereportdata ORDER BY cntSpillId DESC";
            using (SqlConnection con2 = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd2 = new SqlCommand(sqlcmd2, con2))
                {
                    con2.Open();
                    NewID = cmd2.ExecuteScalar().ToString();
                }
            }
            return NewID;
        }
        private GLOBaseReportData GetData(FormCollection fc)
        {
            //Remove all special characters from phones and zip codes.
            string plainDisChargePhone1 = fc["txtdischargedphone1"].ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string plainDisChargePhone2 = fc["txtdischargedphone2"].ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string plainZipcode = fc["txtspillerzipcode"].ToString().Replace("-", "");
            string plainContactPhone = fc["txtcontactphone"].ToString().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string user = "";
            string final = "";
            GLOBaseReportData g = new GLOBaseReportData();
            if (fc["Drill_Txt"].ToString() == "YES")
            {
                g.Drill = "TRUE";
                g.Drill_Txt = "YES";
            }
            else
            {
                g.Drill = "FALSE";
                g.Drill_Txt = "NO";
            }
            g.Spill_ID = fc["txtspillid"].ToString();
            g.Report_Taken_Date = DateTime.Parse(fc["txtreportdate"].ToString()).ToString("MM/dd/yyyy");
            g.Date_Search = DateTime.Parse(g.Report_Taken_Date);
            g.Report_Taken_Time = fc["txtreporttime"].ToString();
            g.Notification_Agency = fc["txtagencynotification"].ToString().ToUpper();
            if (fc["Corrected"].ToString() == "true")
            {
                user = fc["ersop"].ToString();
            }
            else
            {
                user = Session["Username"].ToString().ToUpper();
            }
            g.Report_Taken_By = user;
            g.Discharge_Date = fc["datincidentdate"].ToString();
            g.Discharge_Time = fc["txtincidenttime"].ToString();
            g.Discharge_Reported_By = fc["txtreportedby"].ToString().ToUpper();
            g.Report_Party_Affiliation = fc["txtreportaffiliation"].ToString().ToUpper();
            g.Discharged_Phone_1 = plainDisChargePhone1;
            g.Discharged_Phone_2 = plainDisChargePhone2;
            g.Material_1 = fc["txtmaterial1"].ToString().ToUpper();
            g.Material_2 = fc["txtmaterial2"].ToString().ToUpper();
            g.Material_3 = fc["txtmaterial3"].ToString().ToUpper();
            g.Material_4 = fc["txtmaterial4"].ToString().ToUpper();
            g.Material_5 = fc["txtmaterial5"].ToString().ToUpper();
            g.CASUN_1 = fc["txtcasun1"].ToString().ToUpper();
            g.CASUN_2 = fc["txtcasun2"].ToString().ToUpper();
            g.CASUN_3 = fc["txtcasun3"].ToString().ToUpper();
            g.CASUN_4 = fc["txtcasun4"].ToString().ToUpper();
            g.CASUN_5 = fc["txtcasun5"].ToString().ToUpper();
            g.Amount_Spilled_1 = fc["txtamountspilled1"].ToString();
            g.Amount_Spilled_2 = fc["txtamountspilled2"].ToString();
            g.Amount_Spilled_3 = fc["txtamountspilled3"].ToString();
            g.Amount_Spilled_4 = fc["txtamountspilled4"].ToString();
            g.Amount_Spilled_5 = fc["txtamountspilled5"].ToString();
            g.Unit_Recovered_1 = fc["cbunits1"].ToString();
            g.Unit_Recovered_2 = fc["cbunits2"].ToString();
            g.Unit_Recovered_3 = fc["cbunits3"].ToString();
            g.Unit_Recovered_4 = fc["cbunits4"].ToString();
            g.Unit_Recovered_5 = fc["cbunits5"].ToString();
            g.Spill_County = fc["cbcounty"].ToString();
            g.Origin = fc["cborigin"].ToString();
            g.Spill_Receiving_Water = fc["txtreceivingwater"].ToString().ToUpper();
            g.Spill_Amount_In_Water = fc["txtamountinwater"].ToString().ToUpper();
            g.Spill_Amount_In_Water_Units = fc["cbamountinwaterunits"].ToString();
            if (fc["SpillType"] == "rbland")
                g.Land = "TRUE";
            else
                g.Land = "FALSE";
            if (fc["SpillType"] == "rbspillinwater")
                g.Spill_In_Water = "TRUE";
            else
                g.Spill_In_Water = "FALSE";
            if (fc["SpillType"] == "rbcoastalwater")
                g.Coastal_Water = "TRUE";
            else
                g.Coastal_Water = "FALSE";
            if (fc["SpillType"] == "rbairrelease")
                g.Spill_Air_Release = "TRUE";
            else
                g.Spill_Air_Release = "FALSE";
            g.Spill_Location = fc["txtincidentlocation"].ToString().ToUpper();
            g.NRC_Number = fc["txtnrcnumber"].ToString().ToUpper();
            g.Actions_Taken_Clean_Up_Status = fc["txtdescription"].ToString().ToUpper();
            g.RRC_Lease_Name = fc["txtrrcleasename"].ToString().ToUpper();
            g.RRC_Lease_Number = fc["txtrrcleasenumber"].ToString().ToUpper();
            g.RRC_Field_Name = fc["txtrrcfieldname"].ToString().ToUpper();
            g.Land_Owner = fc["txtrrclandowner"].ToString().ToUpper();
            g.Agency_Name_1 = fc["cbagency1"].ToString().ToUpper();
            g.Agency_Name_2 = fc["cbagency2"].ToString().ToUpper();
            g.Agency_Name_3 = fc["cbagency3"].ToString().ToUpper();
            g.Where_1 = fc["txtwhere1"].ToString().ToUpper();
            g.Where_2 = fc["txtwhere2"].ToString().ToUpper();
            g.Where_3 = fc["txtwhere3"].ToString().ToUpper();
            g.Who_1 = fc["txtwho1"].ToString().ToUpper();
            g.Who_2 = fc["txtwho2"].ToString().ToUpper();
            g.Who_3 = fc["txtwho3"].ToString().ToUpper();
            g.Date_1 = FormatDate(fc["txtdate1"].ToString());
            g.Date_2 = FormatDate(fc["txtdate2"].ToString());
            g.Date_3 = FormatDate(fc["txtdate3"].ToString());

            if (fc["txttime1"].ToString() == "")
            {
                g.Time_1 = "0000";
            }
            else
            {
                g.Time_1 = fc["txttime1"].ToString();
            }
            if (fc["txttime2"].ToString() == "")
            {
                g.Time_2 = "0000";
            }
            else
            {
                g.Time_2 = fc["txttime2"].ToString();
            }
            if (fc["txttime3"].ToString() == "")
            {
                g.Time_3 = "0000";
            }
            else
            {
                g.Time_3 = fc["txttime3"].ToString();
            }
            g.Spiller = fc["txtspiller"].ToString().ToUpper();
            g.Spiller_Address = fc["txtspilleraddress"].ToString().ToUpper();
            g.Spiller_City = fc["txtspillercity"].ToString().ToUpper();
            g.Spiller_State = fc["txtspillerstate"].ToString().ToUpper();
            g.Spiller_Zip_Code = plainZipcode;
            g.Spiller_Contact = fc["txtcontactperson"].ToString().ToUpper();
            g.Spiller_Contact_Phone = plainContactPhone;
            g.Agcy_Name_1 = fc["cbagcy1"].ToString().ToUpper();
            g.Agcy_Name_2 = fc["cbagcy2"].ToString().ToUpper();
            g.Agcy_Name_3 = fc["cbagcy3"].ToString().ToUpper();
            g.Whr1 = fc["txtwhr1"].ToString().ToUpper();
            g.Whr2 = fc["txtwhr2"].ToString().ToUpper();
            g.Whr3 = fc["txtwhr3"].ToString().ToUpper();
            g.W1 = fc["txtw1"].ToString().ToUpper();
            g.W2 = fc["txtw2"].ToString().ToUpper();
            g.W3 = fc["txtw3"].ToString().ToUpper();
            g.D1 = FormatDate(fc["txtd1"].ToString());
            g.D2 = FormatDate(fc["txtd2"].ToString());
            g.D3 = FormatDate(fc["txtd3"].ToString());
            if (fc["txtti1"].ToString() == "")
            {
                g.Ti1 = "0000";
            }
            else
            {
                g.Ti1 = fc["txtti1"].ToString();
            }
            if (fc["txtti2"].ToString() == "")
            {
                g.Ti2 = "0000";
            }
            else
            {
                g.Ti2 = fc["txtti2"].ToString();
            }
            if (fc["txtti3"].ToString() == "")
            {
                g.Ti3 = "0000";
            }
            else
            {
                g.Ti3 = fc["txtti3"].ToString();
            }
            if (fc["txtlatenotificationcomments"].ToString() != "")
                g.Last_Field = fc["txtlatenotificationcomments"].ToString().ToUpper();
            else
                g.Last_Field = "";
            return g;
        }
        private GLOBaseReportData GetVoidData(string id) //Adds blank values to report, so that the next report can use this ID and use the UPDATE method.
        {
            GLOBaseReportData g = new GLOBaseReportData();
            g.Spill_ID = id;
            g.Drill_Txt = "";
            g.Report_Taken_Date = "";
            g.Date_Search = DateTime.Parse("1/1/1753");
            g.Report_Taken_Time = "";
            g.Notification_Agency = "";
            g.Report_Taken_By = "VOID";
            g.Discharge_Date = "";
            g.Discharge_Time = "";
            g.Discharge_Reported_By = "";
            g.Report_Party_Affiliation = "";
            g.Discharged_Phone_1 = "";
            g.Discharged_Phone_2 = "";
            g.Material_1 = "";
            g.Material_2 = "";
            g.Material_3 = "";
            g.Material_4 = "";
            g.Material_5 = "";
            g.CASUN_1 = "";
            g.CASUN_2 = "";
            g.CASUN_3 = "";
            g.CASUN_4 = "";
            g.CASUN_5 = "";
            g.Amount_Spilled_1 = "";
            g.Amount_Spilled_2 = "";
            g.Amount_Spilled_3 = "";
            g.Amount_Spilled_4 = "";
            g.Amount_Spilled_5 = "";
            g.Unit_Recovered_1 = "";
            g.Unit_Recovered_2 = "";
            g.Unit_Recovered_3 = "";
            g.Unit_Recovered_4 = "";
            g.Unit_Recovered_5 = "";
            g.Spill_County = "";
            g.Origin = "";
            g.Spill_Receiving_Water = "";
            g.Spill_Amount_In_Water = "";
            g.Spill_Amount_In_Water_Units = "";
            g.Land = "";
            g.Spill_In_Water = "";
            g.Coastal_Water = "";
            g.Spill_Air_Release = "";
            g.Spill_Location = "";
            g.NRC_Number = "";
            g.Actions_Taken_Clean_Up_Status = "";
            g.RRC_Lease_Name = "";
            g.RRC_Lease_Number = "";
            g.RRC_Field_Name = "";
            g.Land_Owner = "";
            g.Agency_Name_1 = "";
            g.Agency_Name_2 = "";
            g.Agency_Name_3 = "";
            g.Where_1 = "";
            g.Where_2 = "";
            g.Where_3 = "";
            g.Who_1 = "";
            g.Who_2 = "";
            g.Who_3 = "";
            g.Date_1 = "";
            g.Date_2 = "";
            g.Date_3 = "";
            g.Time_1 = "";
            g.Time_2 = "";
            g.Time_3 = "";
            g.Spiller = "";
            g.Spiller_Address = "";
            g.Spiller_City = "";
            g.Spiller_State = "";
            g.Spiller_Zip_Code = "";
            g.Spiller_Contact = "";
            g.Spiller_Contact_Phone = "";
            g.Agcy_Name_1 = "";
            g.Agcy_Name_2 = "";
            g.Agcy_Name_3 = "";
            g.Whr1 = "";
            g.Whr2 = "";
            g.Whr3 = "";
            g.W1 = "";
            g.W2 = "";
            g.W3 = "";
            g.D1 = "";
            g.D2 = "";
            g.D3 = "";
            g.Ti1 = "";
            g.Ti2 = "";
            g.Ti3 = "";
            g.Last_Field = "";
            return g;
        }
        private string FormatDate(string date)
        {
            string month = "";
            string day = "";
            string year = "";
            if (date != "" && !date.Contains("/"))
            {
                month = date.Substring(0, 2);
                day = date.Substring(2, 2);
                year = date.Substring(4);
                date = month + "/" + day + "/" + year;
            }
            return date;
        }
        private string CreateReport(string SpillID)
        {
            int rptNum = Int32.Parse(SpillID); //Gets the ID from the report and stores it in a string variable.
            string year = "";
            if (corrected == "true")
            {
                year = SpillID.Substring(0, 4);
            }
            else
            {
                year = DateTime.Now.Year.ToString();
            }
            string oldpath = @"\\chem-fs1.ers.local\completed reports\GLO\";
            string path = @"\\chem-fs1.ers.local\completed reports\GLO\" + year + "\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            //System.Data.EntityClient.EntityConnection con = new System.Data.EntityClient.EntityConnection();
            //if(profile=="training" || profile=="training2")
            //    con.ConnectionString = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=MySql.Data.MySqlClient;provider connection string=\"server=2XSERVER.chemtel.local;User Id=david;password=wedding2011;Persist Security Info=True;database=chemreportertest\"";
            //else
            //    con.ConnectionString = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=MySql.Data.MySqlClient;provider connection string=\"server=2XSERVER.chemtel.local;User Id=david;password=wedding2011;Persist Security Info=True;database=chemreporter\"";
            ReportDocument cryRpt = new ReportDocument(); //Defines a report variable.
            string rptLoadPath = @"\\chem-fs1.ers.local\Chemtel Apps\Crystal Reports\mainGLO.rpt";  //This is the path to the report template.
            string outPutFilePath = path + rptNum + ".pdf";
            string ViewingPath = "https://crm.chemtel.net/Completed Reports/GLO/" + year + "/" + rptNum + ".pdf";
            oldpath += rptNum + ".pdf";
            if (System.IO.File.Exists(oldpath))
            {
                System.IO.File.Delete(oldpath);
            }
            cryRpt.Load(rptLoadPath); //Loads the report template used to create the report.

            if (System.IO.File.Exists(outPutFilePath))
            {
                System.IO.File.Delete(outPutFilePath);
            }

            using (chemreporterEntities context = new chemreporterEntities())  //Initializes the Entity Model.
            {
                var query = (from obj in context.globasereportdatas where obj.cntSpillId == rptNum select obj).ToList();  //This query will be used to retrieve the record.
                cryRpt.SetDataSource(query); //The report's data source is set to the query.  This executes the query and creats the report.
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, outPutFilePath); //Converts the report to a PDF file.
            }
            return ViewingPath; //Returns the path of the report to .
        }            
        private string CheckForVoidID()
        {
            string PreviousID = "";
            string sql = "SELECT TOP 1 * FROM globasereportdata WhERE txtReportTakenBy = 'VOID' ORDER BY cntSpillId ASC";
            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    PreviousID = cmd.ExecuteScalar().ToString();
                }
            }
            return PreviousID;

        }
        #endregion

        #region GLO Email Form
        public ActionResult GLOEmailForm(GLOBaseReportData g)
        {
            return View();
        }
        public JsonResult fillGLO()
        {
            string emailgroup = "GLO";
            string emaillist = "";
            using (chemreporterEntities context = new chemreporterEntities())
            {
                var query = (from g in context.gloemails where g.emailgroup == emailgroup select new { g.name }); //Query gets records that have the emailgroup GLO.
                foreach (var item in query)
                    emaillist += item.name.ToString() + ",";
            }
            return Json(emaillist.Trim(','), JsonRequestBehavior.AllowGet);
        }
        public JsonResult fillTCEQ()
        {
            string emailgroup = "TCEQ";
            string emaillist = "";
            using (chemreporterEntities context = new chemreporterEntities())
            {
                var query = (from g in context.gloemails where g.emailgroup == emailgroup select new { g.name }); //Gets records with the emailgroup of TCEQ.
                foreach (var item in query)
                    emaillist += item.name.ToString() + ",";
                return Json(emaillist.Trim(','), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult fillRRC()
        {
            string emailgroup = "RRC";
            string emaillist = "";
            using (chemreporterEntities context = new chemreporterEntities())
            {
                var query = (from g in context.gloemails where g.emailgroup == emailgroup select new { g.name }); //Gets records with the emailgroup of RRC.
                foreach (var item in query)
                    emaillist += item.name.ToString() + ",";
                return Json(emaillist.Trim(','), JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult fillOther()
        {
            string emailgroup = "Other";
            string emaillist = "";
            using (chemreporterEntities context = new chemreporterEntities())
            {
                var query = (from g in context.gloemails where g.emailgroup == emailgroup select new { g.name }); //Gets records with the emailgroup of Other.
                foreach (var item in query)
                    emaillist += item.name.ToString() + ",";
                return Json(emaillist.Trim(','), JsonRequestBehavior.AllowGet);
            }
        }
        //Get GLO Emails based on selection
        public JsonResult coreGLO()
        {
            string name = "A Core GLO";
            string emails = "";
            using (chemreporterEntities context = new chemreporterEntities())
            {
                var query = (from g in context.gloemails where g.name == name select g); //Query gets records the have the name of "A Core GLO.
                foreach (var item in query)
                {
                    if (item.email01.ToString() != "N/A")
                        emails = emails + item.email01.ToString() + ",";
                    if (item.email02.ToString() != "N/A")
                        emails = emails + item.email02.ToString() + ",";
                    if (item.email03.ToString() != "N/A")
                        emails = emails + item.email03.ToString() + ",";
                    if (item.email04.ToString() != "N/A")
                        emails = emails + item.email04.ToString() + ",";
                    if (item.email05.ToString() != "N/A")
                        emails = emails + item.email05.ToString() + ",";
                    if (item.email05.ToString() != "N/A")
                        emails = emails + item.email06.ToString() + ",";
                    if (item.email07.ToString() != "N/A")
                        emails = emails + item.email07.ToString() + ",";
                    if (item.email08.ToString() != "N/A")
                        emails = emails + item.email08.ToString() + ",";
                    if (item.email09.ToString() != "N/A")
                        emails = emails + item.email09.ToString() + ",";
                    if (item.email10.ToString() != "N/A")
                        emails = emails + item.email10.ToString() + ",";
                }
            }
            return Json(emails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult rrcHQOnly()
        {
            string name = "RRC HQ";
            string emails = "";
            using (chemreporterEntities context = new chemreporterEntities())
            {
                var query = (from g in context.gloemails where g.name == name select g); //Gets records with the name of "RRC HQ".
                foreach (var item in query)
                {
                    if (item.email01.ToString() != "N/A")
                        emails = emails + item.email01.ToString() + ",";
                    if (item.email02.ToString() != "N/A")
                        emails = emails + item.email02.ToString() + ",";
                    if (item.email03.ToString() != "N/A")
                        emails = emails + item.email03.ToString() + ",";
                    if (item.email04.ToString() != "N/A")
                        emails = emails + item.email04.ToString() + ",";
                    if (item.email05.ToString() != "N/A")
                        emails = emails + item.email05.ToString() + ",";
                    if (item.email05.ToString() != "N/A")
                        emails = emails + item.email06.ToString() + ",";
                    if (item.email07.ToString() != "N/A")
                        emails = emails + item.email07.ToString() + ",";
                    if (item.email08.ToString() != "N/A")
                        emails = emails + item.email08.ToString() + ",";
                    if (item.email09.ToString() != "N/A")
                        emails = emails + item.email09.ToString() + ",";
                    if (item.email10.ToString() != "N/A")
                        emails = emails + item.email10.ToString() + ",";
                }
            }
            return Json(emails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult tceqRegionsOnly()
        {
            string name = "TCEQ Reg ";
            string fname = "";
            string emails = "";
            int ndx = 1; //Integer that keeps track of the TCEQ region.

            for (int x = 1; x < 17; ++x)
            {
                if (ndx < 10)
                    fname = name + "0" + ndx.ToString();
                else
                    fname = name + ndx.ToString();
                using (chemreporterEntities context = new chemreporterEntities())
                {
                    var query = (from g in context.gloemails where g.name == fname select g); //Query gets the TCEQ region record based on the value of ndx.
                    foreach (var item in query)
                    {
                        if (item.email01.ToString() != "N/A")
                            emails = emails + item.email01.ToString() + ",";
                        if (item.email02.ToString() != "N/A")
                            emails = emails + item.email02.ToString() + ",";
                        if (item.email03.ToString() != "N/A")
                            emails = emails + item.email03.ToString() + ",";
                        if (item.email04.ToString() != "N/A")
                            emails = emails + item.email04.ToString() + ",";
                        if (item.email05.ToString() != "N/A")
                            emails = emails + item.email05.ToString() + ",";
                        if (item.email05.ToString() != "N/A")
                            emails = emails + item.email06.ToString() + ",";
                        if (item.email07.ToString() != "N/A")
                            emails = emails + item.email07.ToString() + ",";
                        if (item.email08.ToString() != "N/A")
                            emails = emails + item.email08.ToString() + ",";
                        if (item.email09.ToString() != "N/A")
                            emails = emails + item.email09.ToString() + ",";
                        if (item.email10.ToString() != "N/A")
                            emails = emails + item.email10.ToString() + ",";
                    }
                }
                ++ndx;
            }
            return Json(emails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult epaOnly()
        {
            string name = "EPA Spill Reports R-6";
            string emails = "";
            using (chemreporterEntities context = new chemreporterEntities())
            {
                var query = (from g in context.gloemails where g.name == name select g); //Gets records with the name of EPA Spill Reports R-6.
                foreach (var item in query)
                {
                    if (item.email01.ToString() != "N/A")
                        emails = emails + item.email01.ToString() + ",";
                    if (item.email02.ToString() != "N/A")
                        emails = emails + item.email02.ToString() + ",";
                    if (item.email03.ToString() != "N/A")
                        emails = emails + item.email03.ToString() + ",";
                    if (item.email04.ToString() != "N/A")
                        emails = emails + item.email04.ToString() + ",";
                    if (item.email05.ToString() != "N/A")
                        emails = emails + item.email05.ToString() + ",";
                    if (item.email05.ToString() != "N/A")
                        emails = emails + item.email06.ToString() + ",";
                    if (item.email07.ToString() != "N/A")
                        emails = emails + item.email07.ToString() + ",";
                    if (item.email08.ToString() != "N/A")
                        emails = emails + item.email08.ToString() + ",";
                    if (item.email09.ToString() != "N/A")
                        emails = emails + item.email09.ToString() + ",";
                    if (item.email10.ToString() != "N/A")
                        emails = emails + item.email10.ToString() + ",";
                }
            }
            return Json(emails, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getEmailsByselection(string name)
        {
            //Gets emails based on selected name in the select lists.
            string emails = "";
            using (chemreporterEntities context = new chemreporterEntities())
            {
                var query = (from g in context.gloemails where g.name == name select g);
                foreach (var item in query)
                {
                    if (item.email01.ToString() != "N/A")
                        emails = emails + item.email01.ToString() + ",";
                    if (item.email02.ToString() != "N/A")
                        emails = emails + item.email02.ToString() + ",";
                    if (item.email03.ToString() != "N/A")
                        emails = emails + item.email03.ToString() + ",";
                    if (item.email04.ToString() != "N/A")
                        emails = emails + item.email04.ToString() + ",";
                    if (item.email05.ToString() != "N/A")
                        emails = emails + item.email05.ToString() + ",";
                    if (item.email05.ToString() != "N/A")
                        emails = emails + item.email06.ToString() + ",";
                    if (item.email07.ToString() != "N/A")
                        emails = emails + item.email07.ToString() + ",";
                    if (item.email08.ToString() != "N/A")
                        emails = emails + item.email08.ToString() + ",";
                    if (item.email09.ToString() != "N/A")
                        emails = emails + item.email09.ToString() + ",";
                    if (item.email10.ToString() != "N/A")
                        emails = emails + item.email10.ToString() + ",";
                }
            }
            return Json(emails, JsonRequestBehavior.AllowGet);
        }
        //Send Email
        public ActionResult SendGLOEmail(FormCollection fc)
        {
            try
            {
                var client = new SendGridClient("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");
                var from = new EmailAddress("ers@ehs.com");
                string profile = Session["Username"].ToString();
                string[] emails = fc["txtEmails"].ToString().Split(',');
                string body = fc["txtemailsubject"].ToString() + "\n" + fc["txtemailbody"].ToString();
                string filepath = fc["txtemailattachment"].ToString();  //Temp variable to hold the report path.
                string subject = fc["txtemailsubject"].ToString();

                //Need a list created for SendGrid to send to multiple email address.
                List<EmailAddress> to = new List<EmailAddress>();
                foreach (string e in emails)
                {
                    if (e.Trim() != null && e.Trim() != "")
                    {
                        to.Add(new EmailAddress(e.Trim()));
                    }
                }
                to.Add(new EmailAddress("ers@ehs.com"));
                to.Add(new EmailAddress("mpepitone@ehs.com"));

                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, "", body, true);

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
                log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\n User: " + profile + "\n ReportType: GLO \n Message: " + response.Result.StatusCode + "\n" + "Subject Line: " + subject +  "\n\n\n");
                log.Close();

                string ResultCode = response.Result.StatusCode.ToString();

                return RedirectToAction("Index", "Home", new { Result = ResultCode });

            }
            catch (Exception ex)
            {
                string path = @"\\chem-fs1.ers.local\Log Files\Chemical.log";
                StreamWriter log;
                if (System.IO.File.Exists(path))
                    log = System.IO.File.AppendText(path);
                else
                    log = System.IO.File.CreateText(path);
                //string sp = " ";
                string mod = "GLOController";
                string pfile = "SendGLOEmail.cs";
                log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\n" + "Error Message: " + ex.Message + "\n" + "File: " + pfile + "\n" + "Method: " + mod + "\n\n\n");
                log.Close();
                return RedirectToAction("Error", "Home", new { ErrorMessage = ex.Message });
            }
        }
        #endregion

        #region GLO Line/Monthly Reports
        public ActionResult LineReports(FormCollection fc)
        {
            if (fc["ReportType"].ToString() == "Line")
            {
                DateTime SearchDate = DateTime.Parse(fc["StartDate"].ToString()); //Gets the date from the user and converts it to DateTime type.
                string[] ar = fc["StartDate"].ToString().Split('-'); //Breaks the date up by using the / as the delimeter.
                string month = ar[1]; //Puts the month in a string variable.
                string day = ar[2]; //Puts the day in a string variable.
                string year = ar[0].Substring(2); //Gets the 2-digit year and puts it in a string variable.
                string rptLoadPath = @"\\chem-fs1.ers.local\Chemtel Apps\Crystal Reports\LineReport.rpt"; //Sets the path to the report template.
                string outPutFilePath = @"\\chem-fs1.ers.local\completed reports\Line Reports\GLOLINEREPORT" + month + day + year + ".pdf"; //Sets the path to the final report file.
                string OpenFilePath = "https://crm.chemtel.net/Completed Reports/Line Reports/GLOLINEREPORT" + month + day + year + ".pdf";
                ReportDocument cryRpt = new ReportDocument(); //Creates a new instance of the report.
                cryRpt.Load(rptLoadPath); //Loads the report template.
                using (chemreporterEntities context = new chemreporterEntities())
                {
                    var query = context.globasereportdatas.Where(obj => obj.DateSearch == SearchDate).ToList(); //Query to get the report records for the specified day.
                    cryRpt.SetDataSource(query); //Sets the report's data source to the query.
                    cryRpt.SetParameterValue(0, SearchDate.ToString("MM/dd/yyyy")); //Sets the report's parameter.
                    cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, outPutFilePath); //Creates a PDF version of the report.
                }
                ViewBag.GLOReportPath = OpenFilePath;
                ViewBag.FilePath = outPutFilePath;
                ViewBag.Subject = "GLO LINE REPORT " + month + "-" + day + "-" + year; //Sets the email's subject line.
                ViewBag.ReportType = "GLO LINE REPORT";
                ViewBag.glo = "false";
            }
            else if (fc["ReportType"].ToString() == "Monthly")
            {
                DataSet ds = new DataSet("New Dataset"); //Creates a new dataset.
                System.Data.DataTable dt = new System.Data.DataTable("New Datatable"); //Creates a new datatable.
                string datStart = fc["StartDate"].ToString(); //Puts the start date of the date range in a string variable.
                string datEnd = fc["EndDate"].ToString(); //Puts the end date of the date range in a string variable.
                DateTime startdate = DateTime.Parse(datStart); //Converts the start date of the date range to DateTime.
                DateTime enddate = DateTime.Parse(datEnd); //Converts the end date of the date range to DateTime.
                string sql = "SELECT * FROM globasereportdata WHERE DateSearch>='" + startdate + "' AND DateSearch<='" + enddate  + "'"; //Query to get the records within the date range.

                using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                {
                    con.Open(); //Opens the database connection.
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        using (SqlDataAdapter adapt = new SqlDataAdapter(cmd))
                        {
                            adapt.SelectCommand = cmd; //Finalizes the parameters.
                            adapt.Fill(dt); //Fills the datatable with the query results.
                        }
                    }
                }

                ds.Tables.Add(dt); //Adds the table.
                string Date = DateTime.Now.ToString("MM/dd/yyyy"); //Sets the current date.
                Date = Date.Replace('/', '-'); //Replaces the / with a - in the current date.
                string outPutFilePath = @"\\chem-fs1.ers.local\completed reports\GLO Excel Reports\" + DateTime.Now.Year + @"\"; //Sets the path to the folder to where the report will reside.
                if (!Directory.Exists(outPutFilePath))
                {
                    Directory.CreateDirectory(outPutFilePath);
                }
                string OpenFilePath = "https://crm.chemtel.net/Completed Reports/GLO Excel Reports/" + DateTime.Now.Year + "/";
                string[] dstart = datStart.Split('-');  //The next few statements get the start date and splits it.
                string month1 = dstart[1];
                string day1 = dstart[2];
                string year1 = dstart[0];
                string[] dend = datEnd.Split('-'); //The next few statements get the end date and splits it.
                string month = dend[1];
                string day = dend[2];
                string year = dend[0];
                string file = outPutFilePath + "GLO Bi-Monthly Report " + month1 + "-" + day1 + "-" + year1 + " to " + month + "-" + day + "-" + year + ".xlsx"; //File
                    
                OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                using (OfficeOpenXml.ExcelPackage p = new OfficeOpenXml.ExcelPackage(new FileInfo(@"\\chem-fs1.ers.local\completed reports\Excel\BlankWeeklyGloReport.xlsx"), true)) //Path to the report template
                {
                    OfficeOpenXml.ExcelWorksheet ws = p.Workbook.Worksheets[0]; //This block of code creates the Excel file.
                    ws.Cells["A2"].LoadFromDataTable(dt, false);
                    Byte[] bin = p.GetAsByteArray();
                    OpenFilePath += "GLO Bi-Monthly Report " + month1 + "-" + day1 + "-" + year1 + " to " + month + "-" + day + "-" + year + ".xlsx";
                    System.IO.File.WriteAllBytes(file, bin);
                }

                ViewBag.Subject = "GLO Report " + month1 + "-" + day1 + "-" + year1 + " to " + month + "-" + day + "-" + year + ".xlsx";
                ViewBag.FilePath = file;
                ViewBag.GLOReportPath = OpenFilePath;
                ViewBag.ReportType = "GLO Monthly Report";
                ViewBag.glo = "false";
            }
            return View("GLOEmailForm", null);
        }
        #endregion
    }
}
