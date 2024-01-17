using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using ChemicalLibrary;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace crm.chemtelinc.com.Controllers
{
    public class OtherReportsController : Controller
    {
        public string constring = Properties.Settings.Default.chemicalConnectionString; //Class-level variable containg the connection string to the database.
        public string GMconstring = Properties.Settings.Default.GoldmineConnectionString; //Class-level variable containg the connection string to the database.
        public string constringTest = Properties.Settings.Default.chemicalTestConnectionString; //Class-level variable containg the connection string to the database.
        bool ok = true; //Flag used for recursive calls when automatically generating an ID.
        bool updated = false; //Flag that tells the program if the current report is an updated one.
        string BackToReport = "false";
        public string generalid = ""; //Holds the ID number when opening a report for update (when opening a report from the General Log).
        string reviewedby = "";
        string revieweddate = "";
        string sentdate = "";
        string comments = ""; 
        string emailsent = "";
        public int incid = 0; //Variable to hold an ID if the user is opening the report from the log.
        int updateid = 0;
        bool closing = false; //Flag to determine if the form is ready to close.
        string notes = "";

        #region Clean Shot Report Functions
        public ActionResult CleanShotReport()
        {
            //Check if user is logged in, if not, force login.
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                return RedirectToAction("Index", "Home", new { e = "You must login before proceeding!" });
            }
            TheoChemCleanshotIncident t = new TheoChemCleanshotIncident();
            ViewBag.ID = "CS-"+GetNewCleanShotID();
            return View(t);
        }
        public ActionResult SearchCleanShotReport(FormCollection fc)
        {
            TheoChemCleanshotIncident t = new TheoChemCleanshotIncident(Session["constring"].ToString(), fc["cbsearch"].ToString());
            updated = true;  //Sets the corrected flag to true.
            ViewBag.Updated = "true";
            return View("CleanShotReport", t);
        }
        public ActionResult SubmitCleanShotReport(FormCollection fc)
        {
            TheoChemCleanshotIncident t = GetCleanShotRecordData(fc); //Gets the data from the form and puts it into a custom class variable.
            int AlreadyUsedID = CheckID(t.Incident_ID);
            if (fc["Updated"].ToString() != "true" && AlreadyUsedID == 0)
            {
                Add.AddTheoChemCleanShotIncidents(Session["constring"].ToString(), t); //Adds the data to the database if the report is a new report.
                CreateCleanShotReport(t); //Method call to create a PDF version of the report
            }
            else
            {
                Update.UpdateTheoChemCleanShotIncidents(Session["constring"].ToString(), t); //Updates the report if the report is an updated report.
                CreateCleanShotReport(t); //Method call to create a PDF version of the report.
                updated = false;
            }
            //ShowReport(t);
            return View("OtherReportsCleanShotEmailForm", t);
        }
        private int CheckID(string id)
        {
            int AlreadyUsedID = 0;
            string sql = "SELECT COUNT(*) FROM theochemcleanshotincidents WHERE incidentID = @id";
            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("id", id);
                    AlreadyUsedID = Int32.Parse(cmd.ExecuteScalar().ToString());
                }
            }
            return AlreadyUsedID;
        }
        private TheoChemCleanshotIncident GetCleanShotRecordData(FormCollection fc)
        {
            TheoChemCleanshotIncident t = new TheoChemCleanshotIncident();
            t.Incident_ID = fc["txtincidentid"].ToString();
            t.Ers_Operator = fc["txtersop"].ToString();
            t.Report_Date = fc["txtdate"].ToString();
            t.Report_Time = fc["txttime"].ToString();
            t.Caller_Name = fc["txtcallersname"].ToString();
            t.Caller_Phone = fc["txtcallersphone"].ToString();
            t.Caller_Affiliate = fc["txtcallersaffiliation"].ToString();
            t.Caller_Fax_Email = fc["txtcallersfaxemail"].ToString();
            t.Incident_Street = fc["txtincidentstreet"].ToString();
            t.Incident_City = fc["txtincidentcity"].ToString();
            t.Incident_State = fc["txtincidentstate"].ToString();
            t.Incident_Country = fc["txtincidentcountry"].ToString();
            t.Incident_Time_Zone = fc["cbincidenttimezone"].ToString();
            t.Incident_Date = fc["txtincidentdate"].ToString();
            t.Incident_Time = fc["txtincidenttime"].ToString();
            t.Question_1 = fc["txtquest1"].ToString();
            t.Question_2_Quantity = fc["txtquest2qty"].ToString();
            t.Question_2_Units = fc["cbquest2units"].ToString();
            t.Question_3 = fc["cbquest3"].ToString();
            t.Question_4 = fc["cbquest4"].ToString();
            t.Question_5 = fc["cbquest5"].ToString();
            t.Question_6 = fc["cbquest6"].ToString();
            t.Question_7 = fc["cbquest7"].ToString();
            t.Question_8 = fc["cbquest8"].ToString();
            t.Question_9 = fc["cbquest9"].ToString();
            t.Question_10_Yes_Or_No = fc["cbquest10yesorno"].ToString();
            t.Question_10_IfYes_What = fc["txtquest10ifyeswhat"].ToString();
            t.Question_11_Yes_Or_No = fc["cbquest11yesorno"].ToString();
            t.Question_11_If_Yes_What = fc["txtquest11ifyeswhat"].ToString();
            t.Question_12 = fc["cbquest12"].ToString();
            t.Question_13 = fc["cbquest13"].ToString();
            t.Question_14 = fc["txtquest14"].ToString();
            t.Question_15 = fc["cbquest15"].ToString();
            t.Question_16 = fc["cbquest16"].ToString();
            t.Question_17 = fc["cbquest17"].ToString();
            t.Add_It_Comments_Details = fc["txtincidentdetails"].ToString();
            t.Sub_Name = fc["txtsubscribersname"].ToString();
            t.Sub_Administrative_Contact = fc["txtadmincontact"].ToString();
            t.Sub_Phone = fc["txtphonenumber"].ToString();
            t.Sub_Fax = fc["txtfaxnumber"].ToString();
            t.Sub_Email = fc["txtemailaddress"].ToString();
            t.Sub_Address = fc["txtphysicaladdress"].ToString();
            t.Sub_City_State_Zip = fc["txtcitystatezip"].ToString();
            t.Email_Sent = "";
            t.Comments = "";
            t.Type = fc["cbtype"].ToString();
            return t;
        }
        private void CreateCleanShotReport(TheoChemCleanshotIncident c)
        {
            string year = "";
            if (c.Incident_ID != "")
            {
                year = c.Incident_ID.Substring(3, 4);
            }
            else
            {
                year = DateTime.Now.Year.ToString();
            }
            string bpath = @"\\chem-fs1.ers.local\completed reports\Buster Incident Reports\" + year + "\\";
            string oldbpath = @"\\chem-fs1.ers.local\completed reports\Buster Incident Reports\" + year + "\\" + c.Incident_ID + ".pdf";
            string tpath = @"\\chem-fs1.ers.local\completed reports\Theochem Clean Shot Incident Reports\" + year + "\\";
            string oldtpath = @"\\chem-fs1.ers.local\completed reports\Theochem Clean Shot Incident Reports\" + year + "\\" + c.Incident_ID + ".pdf";
            if (!Directory.Exists(bpath))
            {
                Directory.CreateDirectory(bpath);
            }
            if (!Directory.Exists(tpath))
            {
                Directory.CreateDirectory(tpath);
            }
            ReportDocument cryRpt = new ReportDocument(); //Creates an instance of a new report.
            string rptLoadPath = ""; //Puts the path of the report template in a string.
                                        // if(cbtype.Text=="Buster")
                                        //  rptLoadPath = @"\\chem-fs1.ers.local\Chemtel Apps\Crystal Reports\buster.rpt";
                                        // else
            rptLoadPath = @"\\chem-fs1.ers.local\Chemtel Apps\Crystal Reports\cleanShot1.rpt";
            string outPutFilePath = ""; //Sets the final report file in string.
            if (c.Type == "Buster")
            {
                outPutFilePath = bpath + c.Incident_ID + ".pdf";
                if (System.IO.File.Exists(oldbpath))
                {
                    System.IO.File.Delete(oldbpath);
                }
            }
            else
            {
                outPutFilePath = tpath + c.Incident_ID + ".pdf";
                if (System.IO.File.Exists(oldtpath))
                {
                    System.IO.File.Delete(oldtpath);
                }
            }
            cryRpt.Load(rptLoadPath); //Loads the report template.
            using (chemreporterEntities context = new chemreporterEntities())
            {
                var query = (from t in context.theochemcleanshotincidents where t.incidentId == c.Incident_ID select t).ToList(); //Query for report record.
                cryRpt.SetDataSource(query); //Sets the data source of the report to the query.
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, outPutFilePath); //Converts the report to a PDF file.
            }
        }
        private void ShowReport(TheoChemCleanshotIncident t)
        {
            string yr = t.Incident_ID.Substring(3, 4);
            string path = "";
            if (t.Type == "Buster")
                path = @"https://crm.chemtel.net/completed reports/Buster Incident Reports/" + yr + "/" + t.Incident_ID + ".pdf";
            else
                path = @"https://crm.chemtel.net/completed reports/Theochem Clean Shot Incident Reports/" + yr + "/" + t.Incident_ID + ".pdf";
        }
        public ActionResult OtherReportsCleanShotEmailForm(TheoChemCleanshotIncident t)
        {            
            return View();
        }
        public string GetNewCleanShotID()
        {
            int id = 0;
            int year = 0;
            string strsql = "SELECT TOP 1 SUBSTRING(incidentId, 4, 10) as newIncidentID FROM theochemcleanshotincidents ORDER BY incidentID DESC"; // Gets the LAST ID userd.
            using (SqlConnection cn = new SqlConnection(Session["constring"].ToString()))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        id = int.Parse(rdr[0].ToString());
                }
            }
            year = int.Parse(id.ToString().Substring(0, 4)); //Gets the year of the most recent ID to check if it can be incremented like so, or up to the next year.
            if (DateTime.Now.Year > year)
            {
                year++;
                string NewYearID = "";
                NewYearID= year + "0001";
                return NewYearID;
            } else
            {
                ++id;
                return id.ToString();
            }
        }
        public ActionResult SendCleanShotEmail(FormCollection fc)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("ers@ehs.com");
            string[] emails = fc["txtemailto"].ToString().Split(',');
            string ERSName = Session["FullName"].ToString();
            string profile = Session["Username"].ToString();
            string body = "VelocityEHS Incident Report " + fc["txtIncidentid"] + " for " + fc["txtSubName"] + "<br /><br />" + fc["txtemailbody"].ToString() + "<br />" + "<br />" + ERSName + "<br /> <html><body> <img src=\"cid:Image\"> </body></html>";

            SendGrid.Helpers.Mail.Attachment att = new SendGrid.Helpers.Mail.Attachment();
            var imgbytes = System.IO.File.ReadAllBytes(@"\\chem-fs1.ers.local\Chemtel Apps\Signatures\Signatures.jpg"); //Get Attachment Bytes
            var imgfile = Convert.ToBase64String(imgbytes);

            //Need a list created for SendGrid to send to multiple email address.
            List <EmailAddress> to = new List<EmailAddress>();
            foreach (string email in emails)
            {
                if (email.Trim() != null && email.Trim() != "")
                {
                    to.Add(new EmailAddress(email.Trim()));
                }
            }
            to.Add(new EmailAddress("mpepitone@ehs.com"));
            to.Add(new EmailAddress("ers@ehs.com"));
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, fc["txtemailsubject"].ToString(), "", body, true);
            //Attach Saved PDF to email
            var filename = Path.GetFileName(fc["txtemailattachment"].ToString());
            var bytes = System.IO.File.ReadAllBytes(fc["txtemailattachment"].ToString()); //Get Attachment Bytes
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment(filename, file); //Add Attachment to email.
            msg.AddAttachment("VelocitySignature", imgfile, "image/jpg", "inline", "Image"); //Add Attachment to email.
            var response = client.SendEmailAsync(msg);

            string path = @"\\chem-fs1.ers.local\Log Files\CRMEmails.log";
            StreamWriter log;
            if (System.IO.File.Exists(path))
                log = System.IO.File.AppendText(path);
            else
                log = System.IO.File.CreateText(path);
            log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\n" + "ReportType: Cleanshot \n IncidentID: " + fc["txtIncidentid"] + "Message: " + response.Result.StatusCode + "\n" + "\n\n\n");
            log.Close();

            string ResultCode = response.Result.StatusCode.ToString();

            return RedirectToAction("Index", "Home", new { Result = ResultCode });

        }
        #endregion
        #region Shell Oil Report Functions
        public ActionResult ShellOilReport()
        {
            //Check if user is logged in, if not, force login.
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                return RedirectToAction("Index", "Home", new { e = "You must login before proceeding!" });
            }
            ShellOilIncidentData s = new ShellOilIncidentData();
            return View(s);
        }
        public JsonResult GetNewShellID()
        {
            int id = 0;
            string strsql = "SELECT TOP 1 incid FROM shelloilincidentdata ORDER BY incid DESC"; // Gets the LAST ID userd.
            using (SqlConnection cn = new SqlConnection(Session["constring"].ToString()))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        id = int.Parse(rdr[0].ToString());
                }
            }
            ++id;
            return Json(new { NewID = id.ToString() }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SearchShellReport(FormCollection fc)
        {
            ShellOilIncidentData s = new ShellOilIncidentData(Session["constring"].ToString(), Int32.Parse(fc["IDSearch"].ToString()));
            ViewBag.Updated = "true";
            return View("ShellOilReport", s);
        }
        public ActionResult SubmitShellReport(FormCollection fc)
        {
            try
            {
                ShellOilIncidentData s = GetShellRecordData(fc); //Method call to get the data from the form and put it in a custom class variable.
                if (fc["Updated"].ToString() != "true") //Determines whether the current report is an updated report or a new report.
                    Add.AddShellOilIncidentData(Session["constring"].ToString(), s); //Adds the record to the database if the report is a new report.
                else
                {
                    Update.UpdateShellOilIncidentData(Session["constring"].ToString(), s); //Updates an existing record if the current report is an updated report.
                }
                updated = false; //Sets the updated flag to false so the form can close.
                CreateShellReport(fc); //Method call to create a PDF version of the report.
                return View("ShellOilReportEmailForm", s);
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
                string mod = "SubmitShellReport";
                string pfile = "OtherReportsController.cs";
                log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" +
                    "Time: " + DateTime.Now.ToShortTimeString() + "\n" +
                    "User: " + Session["username"].ToString() + "\n" +
                    "Incident ID: " + fc["txtincidentid"].ToString() + "\n" +
                    "Error Message: " + ex.Message + "\n" +
                    "File: " + pfile + "\n" +
                    "Method: " + mod + "\n\n\n"
                    );
                log.Close();

                var client = new SendGridClient("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");
                var from = new EmailAddress("ers@ehs.com");
                string body = "Check the Log File!";
                string subject = "A new error log has been written.";
                var to = new List<EmailAddress>();
                to.Add(new EmailAddress("mpepitone@ehs.com"));
                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, "", body);
                client.SendEmailAsync(msg);

                return RedirectToAction("Error", "Home", new { ErrorMessage = ex.Message });
            }
        }
        private ShellOilIncidentData GetShellRecordData(FormCollection fc)
        {
            ShellOilIncidentData s = new ShellOilIncidentData();
            s.Inc_ID = int.Parse(fc["txtincidentid"].ToString());
            s.ERS_Operator = fc["txtersoperator"].ToString();
            s.Date = fc["txtdate"].ToString();
            s.Time = fc["txttime"].ToString();
            s.Caller_Name_1 = fc["txtcallername"].ToString();
            s.Caller_Name_2 = "";
            s.Caller_Name_3 = "";
            s.Caller_Phone_1 = fc["txtphone"].ToString();
            s.Caller_Phone_2 = "";
            s.Caller_Phone_3 = "";
            s.Caller_Ext_1 = fc["txtext"].ToString();
            s.Caller_Ext_2 = "";
            s.Caller_Ext_3 = "";
            s.Caller_Alt_Phone_1 = fc["txtaltphone"].ToString();
            s.Caller_Alt_Phone_2 = "";
            s.Caller_Alt_Phone_3 = "";
            s.Caller_Alt_Ext_1 = fc["txtaltext"].ToString();
            s.Caller_Alt_Ext_2 = "";
            s.Caller_Alt_Ext_3 = "";
            s.Comments = fc["txtcomments"].ToString();
            s.Staff_Name = fc["txtstaffname"].ToString();
            s.Staff_Phone = fc["txtstaffphone"].ToString();
            s.Staff_Ext = fc["txtstaffext"].ToString();
            s.Staff_Report_Time = fc["txtstafftime"].ToString();
            s.Staff_Time_Zone = "CST";
            s.Follow_Up_Name_1 = fc["txtfollowupname1"].ToString();
            s.Follow_Up_Name_2 = fc["txtfollowupname2"].ToString();
            s.Follow_Up_Name_3 = fc["txtfollowupname3"].ToString();
            s.Follow_Up_Name_4 = fc["txtfollowupname4"].ToString();
            s.Follow_Up_Name_5 = fc["txtfollowupname5"].ToString();
            s.Follow_Up_Phone_1 = fc["txtfollowupphone1"].ToString();
            s.Follow_Up_Phone_2 = fc["txtfollowupphone2"].ToString();
            s.Follow_Up_Phone_3 = fc["txtfollowupphone3"].ToString();
            s.Follow_Up_Phone_4 = fc["txtfollowupphone4"].ToString();
            s.Follow_Up_Phone_5 = fc["txtfollowupphone5"].ToString();
            s.Follow_Up_Ext_1 = fc["txtfollowupext1"].ToString();
            s.Follow_Up_Ext_2 = fc["txtfollowupext2"].ToString();
            s.Follow_Up_Ext_3 = fc["txtfollowupext3"].ToString();
            s.Follow_Up_Ext_4 = fc["txtfollowupext4"].ToString();
            s.Follow_Up_Ext_5 = fc["txtfollowupext5"].ToString();
            s.Follow_Up_Time_1 = fc["txtfollowuptime1"].ToString();
            s.Follow_Up_Time_2 = fc["txtfollowuptime2"].ToString();
            s.Follow_Up_Time_3 = fc["txtfollowuptime3"].ToString();
            s.Follow_Up_Time_4 = fc["txtfollowuptime4"].ToString();
            s.Follow_Up_Time_5 = fc["txtfollowuptime5"].ToString();
            if (fc["txtfollowuptime1"].ToString() != "") { s.Follow_Up_Time_Zone_1 = "CST"; } else { s.Follow_Up_Time_Zone_1 = ""; }
            if (fc["txtfollowuptime2"].ToString() != "") { s.Follow_Up_Time_Zone_2 = "CST"; } else { s.Follow_Up_Time_Zone_2 = ""; }
            if (fc["txtfollowuptime3"].ToString() != "") { s.Follow_Up_Time_Zone_3 = "CST"; } else { s.Follow_Up_Time_Zone_3 = ""; }
            if (fc["txtfollowuptime4"].ToString() != "") { s.Follow_Up_Time_Zone_4 = "CST"; } else { s.Follow_Up_Time_Zone_4 = ""; }
            if (fc["txtfollowuptime5"].ToString() != "") { s.Follow_Up_Time_Zone_5 = "CST"; } else { s.Follow_Up_Time_Zone_5 = ""; }
            s.Email_Sent = emailsent;
            s.Notes = notes;
            return s;
        }
        private void CreateShellReport(FormCollection fc)
        {
            string yr = "";
            if (incid != 0)
            {
                string[] ar = fc["txtdate"].ToString().Split('/');
                yr = ar[ar.Length - 1].ToString();
            }
            else
            {
                yr = DateTime.Now.Year.ToString();
            }

            string path = @"\\chem-fs1.ers.local\completed reports\Shell Oil Incident Reports\" + yr + "\\";
            string oldpath = @"\\chem-fs1.ers.local\completed reports\Shell Oil Incident Reports\" + fc["txtincidentid"].ToString() + ".pdf";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ReportDocument cryRpt = new ReportDocument(); //Creates a new instance of the report.
            int id = int.Parse(fc["txtincidentid"].ToString()); //Converts the ID to an integer.
            string rptLoadPath = @"\\chem-fs1.ers.local\Chemtel Apps\Crystal Reports\shelloilincident2.rpt"; //Sets the path of the report template.
            string outPutFilePath = path + fc["txtincidentid"].ToString() + ".pdf"; //Sets the path of the report file.
            if (System.IO.File.Exists(oldpath))
            {
                System.IO.File.Delete(oldpath);
            }
            cryRpt.Load(rptLoadPath); //Loads the report template.
            using (chemreporterEntities context = new chemreporterEntities())
            {
                var query = (from t in context.shelloilincidentdatas where t.incid == id select t).ToList(); //Query to get the record of the submitted report.
                cryRpt.SetDataSource(query); //Sets the data source of the report to the query.
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, outPutFilePath); //Creats a PDF version of the report.
            }
            ViewBag.ShellOilReport = outPutFilePath;
            ViewBag.ShowShellOilReport = "https://crm.chemtel.net/Completed Reports/Shell Oil Incident Reports/" + yr + "/" + fc["txtincidentid"].ToString() + ".pdf";
        }
        public ActionResult ShellOilReportEmailForm(ShellOilIncidentData s)
        {
            return View();
        }
        public ActionResult SendShellReport(FormCollection fc)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("ers@ehs.com");
            string profile = Session["Username"].ToString();
            string[] emails = fc["txtemailto"].ToString().Split(',');
            string ERSName = Session["FullName"].ToString();
            string body = "<br /> VelocityEHS Incident Report " + fc["IncidentID"] + " for Shell Oil Products<br /><br />" + fc["txtemailbody"].ToString() + "<br />" + "<br />" + ERSName + "<br /> <html><body> <img src=\"cid:Image\"> </body></html>";
            string filepath = fc["txtemailattachment"].ToString();  //Temp variable to hold the report path.

            //Need a list created for SendGrid to send to multiple email address.
            List<EmailAddress> to = new List<EmailAddress>();
            foreach (string email in emails)
            {
                if (email.Trim() != null && email.Trim() != "")
                {
                    to.Add(new EmailAddress(email.Trim()));
                }
            }
            to.Add(new EmailAddress("mpepitone@ehs.com"));
            to.Add(new EmailAddress("ers@ehs.com"));

            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, fc["txtemailsubject"].ToString(), "", body, true);
            //Attach image 
            SendGrid.Helpers.Mail.Attachment att = new SendGrid.Helpers.Mail.Attachment();
            var imgbytes = System.IO.File.ReadAllBytes(@"\\chem-fs1.ers.local\Chemtel Apps\Signatures\Signatures.jpg"); //Get Attachment Bytes
            var imgfile = Convert.ToBase64String(imgbytes);
            msg.AddAttachment("VelocitySignature", imgfile, "image/jpg", "inline", "Image"); //Add Attachment to email.
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
            log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\n" + "ReportType: Shell Oil \n IncidentID: "+ fc["IncidentID"] + "\n Message: " + response.Result.StatusCode + "\n" + "\n\n\n");
            log.Close();

            string ResultCode = response.Result.StatusCode.ToString();

            return RedirectToAction("Index", "Home", new { Result = ResultCode });

        }
        #endregion
        #region Report Logs Functions
        public ActionResult OtherReportsLogs()
        {
            ViewBag.LogSelected = Request.QueryString["LogSelected"].ToString();
            return View();
        }
        #endregion
        #region General Incident Report Functions
        public ActionResult GeneralIncident()
        {
            //Check if user is logged in, if not, force login.
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                return RedirectToAction("Index", "Home", new { e = "You must login before proceeding!" });
            }
            ViewBag.ID = GenIncYearCheck();
            GeneralIncidentReportData g = new GeneralIncidentReportData();
            return View(g);
        }
        public ActionResult SearchGenIncReport(FormCollection fc)
        {
            GeneralIncidentReportData g = new GeneralIncidentReportData(Session["constring"].ToString(), fc["cbsearch"].ToString());
            ViewBag.Updated = "true";
            ViewBag.ID = Int32.Parse(g.Incident_ID);
            return View("GeneralIncident", g);
        }

        public ActionResult SubmitGenIncForm(FormCollection fc)
        {
            try
            {
                string txtincidentid = fc["txtincidentid"].ToString();
                GeneralIncidentReportData g = GetRecordData(fc);  //Gets the data from the form and puts it in a custom report class.
                if (fc["Updated"].ToString() != "true") //Sees if the current report is a new report or an updated.
                {
                    Add.AddGeneralIncidentReportData(Session["constring"].ToString(), g);
                    CreateGenIncReport(txtincidentid); //Method call to create a PDF version of the report.
                    UpdateID(g.Incident_ID, g.Ers_Operator); //Updates the ID to make it unavailable and to put the operator's name in the table.
                }
                else
                {
                    Update.UpdateGeneralIncidentReportData(Session["constring"].ToString(), g); //Updates the report record if the current report is an updated report.
                    GeneralEditProcess(txtincidentid);
                    CreateGenIncReport(txtincidentid); //Method call to create a PDF version of the report.
                }
                return View("OtherReportsGeneralIncidentEmailForm", g); //Move to email form with report details.
            } catch (Exception ex)
            {
                string path = @"\\chem-fs1.ers.local\Log Files\Chemical.log";
                StreamWriter log;
                if (System.IO.File.Exists(path))
                    log = System.IO.File.AppendText(path);
                else
                    log = System.IO.File.CreateText(path);
                //string sp = " ";
                string mod = "SubmitGenIncForm";
                string pfile = "OtherReportsController.cs";
                log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" +
                    "Time: " + DateTime.Now.ToShortTimeString() + "\n" +
                    "User: " + Session["username"].ToString() + "\n" +
                    "Incident ID: " + fc["txtincidentid"].ToString() + "\n" +
                    "Error Message: " + ex.Message + "\n" +
                    "File: " + pfile + "\n" +
                    "Method: " + mod + "\n\n\n"
                    );
                log.Close();

                var client = new SendGridClient("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");
                var from = new EmailAddress("ers@ehs.com");
                string body = "Check the Log File!";
                string subject = "A new error log has been written.";
                var to = new EmailAddress("mpepitone@ehs.com");
                var msg = MailHelper.CreateSingleEmail(from, to, subject, " ", body);
                client.SendEmailAsync(msg);

                return RedirectToAction("Error", "Home", new { ErrorMessage = ex.Message });
            }
        }
        private void CreateGenIncReport(string txtincidentid)
        {
            string year = "";
            if (generalid != "")
            {
                year = txtincidentid.Substring(0, 4);
            }
            else
            {
                year = DateTime.Now.Year.ToString();
            }
            string path = @"\\chem-fs1.ers.local\completed reports\General Incidents\" + year + "\\";
            string oldpath = @"\\chem-fs1.ers.local\completed reports\General Incidents\" + year + "\\" + txtincidentid + ".pdf";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ReportDocument cryRpt = new ReportDocument(); //Create an instance of the report.
            string rptLoadPath = "";
            // if(cbreporttype.Text=="General Incident")
            rptLoadPath = @"\\chem-fs1.ers.local\Chemtel Apps\Crystal Reports\GenIncRpt1.rpt"; //Put the path of the report template in a string variable.
            string outPutFilePath = path + txtincidentid + ".pdf"; //Put the path of the final report path in a string variable.
            if (System.IO.File.Exists(oldpath))
            {

            System.IO.File.Delete(oldpath);
            }
            System.Diagnostics.Process[] myp = System.Diagnostics.Process.GetProcessesByName(outPutFilePath);
            cryRpt.Load(rptLoadPath); //Load the report template.
            using (chemreporterEntities objctx = new chemreporterEntities())
            {
                var getIncData = (from obj in objctx.generalincidentreportdatas where obj.IncidentId == txtincidentid select obj).ToList(); //Get the record for the report.

                cryRpt.SetDataSource(getIncData); //Set the data source of the report to the query.
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, outPutFilePath); //Convert the report to a PDF file.
            }
            cryRpt.Dispose();
        }
        private GeneralIncidentReportData GetRecordData(FormCollection fc)
        {
            GeneralIncidentReportData g = new GeneralIncidentReportData();
            g.Incident_ID = fc["txtincidentid"].ToString();
            g.Ers_Operator =  fc["txtersop"].ToString();
            g.Date =  fc["txtdate"].ToString();
            g.Time =  fc["txttime"].ToString();
            g.Callers_Name =  fc["txtcallersname"].ToString();
            g.Callers_Phone =  fc["txtcallersphone"].ToString();
            g.Callers_Affiliation =  fc["txtcallersaffiliation"].ToString();
            g.Callers_Fax_Or_Email =  fc["txtcallersfaxoremail"].ToString();
            g.Incident_Street =  fc["txtincidentstreet"].ToString();
            g.Incident_City =  fc["txtincidentcity"].ToString();
            if (fc["txtincidentstate"] != null && fc["txtincidentstate"] != "")
            {
                g.Incident_State = fc["txtincidentstate"].ToString();
            }
            else
            {
                g.Incident_State = fc["txtincidentProvidence"].ToString();
            }
            g.Incident_Country =  fc["txtincidentcountry"].ToString();
            g.Incident_Date =  fc["txtincidentdate"].ToString();
            g.Incident_Time =  fc["txtincidenttime"].ToString();
            g.Incident_Time_Zone =  fc["cbincidenttimezone"].ToString();
            g.Material_Name =  fc["txtmaterialname"].ToString();
            g.Product_Number =  fc["txtproductnumber"].ToString();
            g.Quantity_Spilled =  fc["txtquantityspilledorreleased"].ToString();
            g.Epa_Reg_No =  fc["txteparegno"].ToString();
            //g.Cleanup_Crew_Requirements =  fc["txtcleanupcrewrequirement"].ToString();
            //g.Agencies_On_Site =  fc["txtagenciesonsite"].ToString();
            g.Accident_Or_Deliberate =  fc["cbaccidentalordeliberate"].ToString();
            g.Incident_Details =  fc["txtincidentdeails"].ToString();
            g.Involve_Fire =  fc["cbinvolvefire"].ToString();
            g.Where_Did_You_Get_Our_Number =  fc["cbwheredidyougetournumberfrom"].ToString();
            g.Status_Of_Release =  fc["cbstatusofrelease"].ToString();
            g.Dispersion_Of_Msds_Information =  fc["cbdispersionofmsdsinfo"].ToString();
            g.Subscribers_Name = fc["txtsubscribersname"].Substring(0, fc["txtsubscribersname"].Length - 8);
            g.Subscribers_MIS = fc["txtsubscribersname"].Substring(fc["txtsubscribersname"].Length - 7);
            g.Spill_Or_Exposure =  fc["cbspillorexposure"].ToString();
            g.Type_Of_Exposure =  fc["cbtypeofexposure"].ToString();
            g.Num_Of_Casualties =  fc["cbnumofcasualties"].ToString();
            g.Num_Of_Injuries =  fc["cbnumofinjuries"].ToString();
            if (fc["txtmedpersonnelname"].ToString() == "") { g.Med_Personnel_Name = "Not Applicable"; } else { g.Med_Personnel_Name = fc["txtmedpersonnelname"].ToString(); }
            if (fc["txtpatientscondtion"].ToString() == "") { g.Patient_Condition = "Not Applicable"; } else { g.Patient_Condition = fc["txtpatientscondtion"].ToString(); }
            if (fc["txthospitalcliniclocation"].ToString() == "") { g.Hospital_Clinic_Location = "Not Applicable"; } else { g.Hospital_Clinic_Location = fc["txthospitalcliniclocation"].ToString(); }
            g.Reviewed_By = reviewedby;
            g.Reviewed_Date = revieweddate;
            g.Sent_Date = sentdate;
            g.Comments = comments;
            if (fc["txtincidentzipcode"].ToString() == "") { g.Incident_Zip_Code = "00000"; } else { g.Incident_Zip_Code = fc["txtincidentzipcode"].ToString(); }
            g.Report_Type = "General Incident";
            g.Callers_Phone_Ext =  fc["txtcallersphoneext"].ToString();
            if (!updated)
            {
                g.Date_Changed = "N/A";
                g.Username = "N/A";
            }
            else
            {
                string datenow = DateTime.Now.ToShortDateString();
                g.Date_Changed = datenow;
                g.Username = System.Environment.UserName;
            }
            return g;
        }
        private void UpdateID(string txtincidentid, string txtersop)
        {
            int id = int.Parse(txtincidentid);
            OtherID o = new OtherID(Session["constring"].ToString(), id);
            o.User = txtersop;
            ChemicalLibrary.Update.UpdateOtherIDs(Session["constring"].ToString(), o);
        }
        private void GeneralEditProcess(string txtincidentid)
        {
            try
            {
                if (!CheckGeneralEditsTable(txtincidentid))
                {
                    GeneralIncidentEdits g = new GeneralIncidentEdits();
                    g.ID = txtincidentid;
                    g.Username = System.Environment.UserName;
                    g.Edit_Date = DateTime.Now;
                    g.Number_Of_Edits = 1;
                    Add.AddGeneralIncidentEdits(Session["constring"].ToString(), g);
                }
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
                string mod = "GeneralEditProcess";
                string pfile = "frmcrmOtherReportsandLogsGeneralIncident.cs";
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
                message.To.Add(to.ToString());
                message.From = from;
                message.Subject = subject;
                message.Body = msg;
                smtp.Send(message);
            }
        }
        private bool CheckGeneralEditsTable(string txtincidentid)
        {
            try
            {
                GeneralIncidentEdits g = new GeneralIncidentEdits(Session["constring"].ToString(), txtincidentid);
                if (g.Username != null)
                {
                    int edits = g.Number_Of_Edits;
                    edits++;
                    g.Number_Of_Edits = edits;
                    g.Username = System.Environment.UserName;
                    g.Edit_Date = DateTime.Now;
                    ChemicalLibrary.Update.UpdateGeneralIncidentEdits(Session["constring"].ToString(), g);
                    return true;
                }
                else
                {
                    return false;
                }
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
                string mod = "CheckGeneralEditsTable";
                string pfile = "frmcrmOtherReportsandLogsGeneralIncident.cs";
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
                message.To.Add(to.ToString());
                message.From = from;
                message.Subject = subject;
                message.Body = msg;
                smtp.Send(message);
                return false;
            }
        }
        private void ShowReport(string txtincidentid)
        {
            string yr = txtincidentid.Substring(0, 4);
            string path = @"\\chem-fs1.ers.local\completed reports\General Incidents\" + yr + "\\" + txtincidentid + ".pdf"; //Test path
            //string path = @"\\chem-fs1.ers.local\completed reports\General Incidents\" + yr + "\\" + txtincidentid + ".pdf";
            if (System.IO.File.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
            else
            {
                var smtpCreds = new NetworkCredential(@"CHEMTEL\emergency", "ERS*33602");
                SmtpClient smtp = new SmtpClient("mail.chemtelinc.com", 587);
                MailAddress from = new MailAddress("ers@ehs.com");
                MailAddressCollection to = new MailAddressCollection();
                MailMessage message = new MailMessage();
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = smtpCreds;
                string msg = "The path it could not open: " + path;
                string subject = "ShowReport message for General Incident Report";
                to.Add("mpepitone@ehs.com");
                message.From = from;
                message.Subject = subject;
                message.Body = msg;
                smtp.Send(message);
            }
        }
        //ID Check
        private int GenIncYearCheck()
        {
            int id = OtherIDCreation.GetLastID(Session["constring"].ToString()); //Gets the last ID in the ID table.
            string year = id.ToString().Substring(0, 4); //Extracts the year from the ID number.
            if (OtherIDCreation.CheckYear(year)) //Makes sure the year that was extracted from the ID number is the current year.
            {
                id = id+1; //INCREMENT LAST USED ID BY 1
                return id;

                //IF THIS CODE HAS NOT BEEN UN-COMMENTED OUT IN 30 DAYS, DELETE CODE CHUNK. (06/19/2023)

                //int oldid = OtherIDCreation.SearchForAvailableID(Session["constring"].ToString()); //Looks for an ID in the table that's available.
                //if (oldid > 0)  //Checks to see if an available ID was found.
                //{
                //    if (Search.CheckIncidentID(Session["constring"].ToString(), oldid.ToString())) //Makes sure the available ID that was found doesn't have a report associated with it.
                //    {
                //        id = oldid; //Copies the available ID to the id variable
                //        OtherID oid = new OtherID(Session["constring"].ToString(), id); //Gets the ID record from the ID table
                //        oid.Available = 1;
                //        oid.User = "";
                //        Update.UpdateOtherIDs(Session["constring"].ToString(), oid); //Updates the ID record to make thhe ID unavailable.
                //    }
                //    else //The statements below are executed only if the available ID has a report associated with it.
                //    {
                //        OtherID o = new OtherID(Session["constring"].ToString(), oldid); //Gets the record of the available ID.
                //        GeneralIncidentReportData g = new GeneralIncidentReportData(Session["constring"].ToString(), oldid.ToString()); //Gets the ID's report record.
                //        o.Available = 1;
                //        o.User = g.Ers_Operator; //Gets the operator's name from the report record and puts it in the ID record.
                //        Update.UpdateOtherIDs(Session["constring"].ToString(), o); //Updates the ID record to make that ID permanently unavailable.
                //        GenIncYearCheck(); //Recursive method call to get the next available ID.
                //        ok = false; //This flag is used to ensure that the statements below don't get executed after the recursive method call returns.
                //    }
                //}
                //else //The statements below are executed only if an available ID is NOT found.
                //{
                //    if (ok) //Makes sure recursion hasn't occured.
                //    {
                //        id = OtherIDCreation.Increment(id); //Increments the last ID in the ID table by 1.
                //        OtherID oid = new OtherID(); //Creates a new ID instance.
                //        oid.ID = id;
                //        oid.Available = 1;
                //        oid.User = "";
                //        Add.AddOtherIDs(Session["constring"].ToString(), oid); //Adds the new ID to the ID table.
                //    }
                //}
                //if (ok)
                //    return id; //Puts the generated ID in the ID textbox.  If this statement excutes on a recursive call, it won't execute on the original call.

                //END OF CODE CHUNK TO BE REMOVED

            }
            else  //The statement below executes only if the year extracted from the last ID in the ID table isn't the current year.
            {
               id = NewYear(int.Parse(year)); //Method call to generate an ID number for the new year.
            }
            return id; //Puts the generated ID in the ID textbox.  If this statement excutes on a recursive call, it won't execute on the original call.
        }

        public JsonResult CheckForNewGenIncID()
        {
            int NewID = GenIncYearCheck();
            return Json(new { NEWID = NewID }, JsonRequestBehavior.AllowGet);
        }

        //increment id to new year
        private int NewYear(int year)
        {
            string txtincidentid;
            year++;
            string yr = year.ToString() + "0001";
            txtincidentid = yr;
            //OtherID o = new OtherID();
            //o.ID = int.Parse(txtincidentid);
            //o.Available = 1;
            //o.User = "";
            //Add.AddOtherIDs(Session["constring"].ToString(), o);
            return int.Parse(txtincidentid);
        }
        [HttpPost]
        public ActionResult SendGenIncMail(FormCollection fc, HttpPostedFileBase[] AttachFile)
        {
            string txtemailto = fc["txtemailto"].ToString();
            string profile = Session["Username"].ToString();
            var client = new SendGridClient("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");
            var from = new EmailAddress("ers@ehs.com");
            string[] emails = fc["txtemailto"].ToString().Split(',');
            string ERSName = Session["FullName"].ToString();
            string body = "VelocityEHS Incident Report " + fc["IncidentID"] + " for " + fc["SubscribersName"] + "<br /><br />" + fc["txtemailmessage"].ToString() + "<br />" + "<br />" + ERSName + "<br />" + "<html><body> <img src=\"cid:Image\"> </body></html>";
            string[] FileNames = { "" };

            SendGrid.Helpers.Mail.Attachment att = new SendGrid.Helpers.Mail.Attachment();
            var imgbytes = System.IO.File.ReadAllBytes(@"\\chem-fs1.ers.local\Chemtel Apps\Signatures\Signatures.jpg"); //Get Attachment Bytes
            var imgfile = Convert.ToBase64String(imgbytes);

            //Need a list created for SendGrid to send to multiple email address.
            List<EmailAddress> to = new List<EmailAddress>();
            foreach (string email in emails)
            {
                if (email.Trim() != null && email.Trim() != "")
                {
                    to.Add(new EmailAddress(email.Trim()));
                }
            }
            to.Add(new EmailAddress("ers@ehs.com"));
            to.Add(new EmailAddress("mpepitone@ehs.com"));

            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, fc["txtemailsubject"].ToString(), "", body, true);

            //Attach Report PDF to email
            var Reportbytes = System.IO.File.ReadAllBytes(fc["AttachedReport"].ToString()); //Get Attachment Bytes
            var Reportfile = Convert.ToBase64String(Reportbytes);
            msg.AddAttachment(fc["IncidentID"] + ".pdf", Reportfile); //Add Attachment to email.

            //Attach Additional Files to email
            foreach (HttpPostedFileBase f in AttachFile)
            {
                //Checking file is available to save.  
                if (f != null)
                {
                    var ServerSavePath = Path.Combine(Server.MapPath("~/TempFiles/") + f.FileName);
                    //Save file to server folder  
                    f.SaveAs(ServerSavePath);
                    var bytes = System.IO.File.ReadAllBytes(ServerSavePath); //Get Attachment Bytes
                    var file = Convert.ToBase64String(bytes);
                    msg.AddAttachment(f.FileName, file); //Add Attachment to email.
                }
            }
            msg.AddAttachment("VelocitySignature", imgfile, "image/jpg", "inline", "Image"); //Add Attachment to email.
            var response = client.SendEmailAsync(msg);

            string path = @"\\chem-fs1.ers.local\Log Files\CRMEmails.log";
            StreamWriter log;
            if (System.IO.File.Exists(path))
                log = System.IO.File.AppendText(path);
            else
                log = System.IO.File.CreateText(path);
            log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\n" + "ReportType: General Incident \n IncidentID: " + fc["IncidentID"] + "\n Message: " + response.Result.StatusCode + "\n" + "\n\n\n");
            log.Close();

            string ResultCode = response.Result.StatusCode.ToString();

            return RedirectToAction("Index", "Home", new { Result = ResultCode });
        }
        public string GetNameUser(string user)
        {
            string result = "";
            string parameter = user.ToUpper();
            if (parameter == "JPERDOMO")
            {
                result = "Jerri Perdomo";
                return result;
            }
            else if (parameter == "TCOCKRELL")
            {
                result = "Terri Cockrell";
                return result;
            }
            else if (parameter == "CBOTELHO" || parameter == "CCOCKRELL")
            {
                result = "Chrissy Botelho";
                return result;
            }
            else if (parameter == "TOWENS")
            {
                result = "Tonya Owens";
                return result;
            }
            else if (parameter == "LWECKERLE")
            {
                result = "Lynn Weckerle";
                return result;
            }
            else if (parameter == "SWARDINO")
            {
                result = "Sandy Wardino";
                return result;
            }
            else if (parameter == "SWECKERLE")
            {
                result = "Simond Weckerle";
                return result;
            }
            else if (parameter == "ACLEMENTS")
            {
                result = "Austin Clements";
                return result;
            }
            else if (parameter == "MWILLIAMS")
            {
                result = "Machelle Williams";
                return result;
            }
            else
            if (parameter == "SCOURTNEY")
            {
                result = "Sterling Courtney";
                return result;
            }
            else
            if (parameter == "JHARVEY")
            {
                result = "Juli Harvey";
                return result;
            }
            else
            if (parameter == "SSCHULTE")
            {
                result = "Shaye Schulte";
                return result;
            }
            else
            if (parameter == "MPEPITONE")
            {
                result = "Michael Pepitone";
                return result;
            }
            else
            {
                return result;
            }
        }
        public ActionResult OtherReportsGeneralIncidentEmailForm(GeneralIncidentReportData g)
        {
            return View(g);
        }
        #endregion
    }
}