using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChemicalLibrary;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace crm.chemtelinc.com.Controllers
{
    public class NorthwindController : Controller
    {
        // GET: Northwind
        #region Get Views
        public ActionResult GeneralIncident()
        {
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                ViewBag.ErrorMessage = "You must login before proceeding!";
                return RedirectToAction("Index", "Home", new { e = "You must login before proceeding!" });
            }
            return View(new NorthwindGenInc());
        }

        public ActionResult Pipeline()
        {
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                ViewBag.ErrorMessage = "You must login before proceeding!";
                return RedirectToAction("Index", "Home", new { e = "You must login before proceeding!" });
            }
            return View(new NorthwindPipeline());
        }

        public ActionResult EmailForm(NorthwindEmail n)
        {
            return View(n);
        }
        #endregion

        #region Form Submissions
        public ActionResult SubmitNewGenIncReport(FormCollection fc)
        {
            NorthwindGenInc ngi = new NorthwindGenInc();
            ngi = GetGenIncData(fc);
            Add.AddNorthwindGenInc(Session["constring"].ToString(), ngi); //Add new report data to the database.
            
            //start prep for email autopopulation.
            NorthwindEmail nwe = new NorthwindEmail();
            DateTime callDate = ngi.Call_Date;
            DateTime callTime = DateTime.Parse(ngi.Call_Time);
            DateTime incidentDate = ngi.Incident_Date;
            DateTime incidentTime = DateTime.Parse(ngi.Incident_Time);
            DateTime notificationDate = ngi.NotificationDate;
            DateTime notificationTime = DateTime.Parse(ngi.NotificationTime);

            nwe.ToEmails = "mpepitone@ehs.com";
            nwe.Subject = "Incident Notification: ";
            if (fc["ddlFacilityOrProject"].ToString() == "Yes")
            {
                nwe.Subject += callDate.ToString("yyyyMMdd") + " | " + ngi.IncidentLocation + " | " + ngi.IncidentType;
            }
            else
            {
                nwe.Subject += callDate.ToString("yyyyMMdd") + " | " + ngi.Incident_County + ", " + ngi.Incident_State + " | " + ngi.IncidentType;
            }

            nwe.Body = "The Northwind Hotline was notified at " + ngi.NotificationTime + " " + ngi.Incident_Time_Zone + " that at approximately " +
                ngi.Incident_Time + " " + ngi.Incident_Time_Zone + " on " + incidentDate.ToString("MM/dd/yyyy");
            return View("EmailForm", nwe);
        }

        public ActionResult SubmitNewPipelineReport(FormCollection fc)
        {
            NorthwindPipeline n = new NorthwindPipeline();
            NorthwindEmail nwe = new NorthwindEmail();

            n = GetPipelineData(fc);
            Add.AddNorthwindPipeline(Session["constring"].ToString(), n);
            n.ID = GetLatestPipelineID(); // Gets and sets the new ID that was just entered.

            string filepath = CreatePipelineReport(n.ID, n.Call_Date.Year.ToString());
            string CallTime12Hr = "";
            if (Int32.Parse(n.Call_Time.Substring(0,2)) > 12 )
            {
                CallTime12Hr = (Int32.Parse(n.Call_Time.Substring(0, 2)) - 12).ToString(); // Get the 12 hr format of the time for PM.
                CallTime12Hr += ":" + Int32.Parse(n.Call_Time.Substring(3, 2)) + " PM";
            } else
            {
                CallTime12Hr = n.Call_Time + " AM"; // Keeps the time as is for AM.
            }

            nwe.ToEmails = "mpepitone@ehs.com,ers@ehs.com,NWLeadership@nwmidstream.com," + n.NotifiedEmail;
            nwe.FilePath = filepath;
            nwe.Subject = "Northwind Pipeline Incident Notification: " + n.Call_Date.ToString("yyyyMMdd") + " : " + n.County + ", " + n.State;
            nwe.Body = "The Northwind Pipeline Emergency Hotline was notified at: " + CallTime12Hr + " " + n.TimeZone + " of a potential incident occurring on or near Northwind operated assets.\n" +
                "The Northwind Operations team has been notified of the situation and is in the process of investigating the reported issue. \n" +
                "The initial details provided by the caller are in the attached report.  Additional information will be provided as it becomes available.";
            return View("EmailForm", nwe);
        }

        public ActionResult SendNorthwindEmail(FormCollection fc)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("ers@ehs.com");
            string[] emails = fc["txtToEmails"].ToString().Split(',');
            string body = fc["txtBody"].ToString();
            string subject = fc["txtSubject"].ToString();
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
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, "", body, true);
            //Attach Saved PDF to email
            var filename = Path.GetFileName(fc["txtFilePath"].ToString());
            var bytes = System.IO.File.ReadAllBytes(fc["txtFilePath"].ToString()); //Get Attachment Bytes
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment(filename, file); //Add Attachment to email.
            var response = client.SendEmailAsync(msg);

            string ResultCode = response.Result.StatusCode.ToString();

            return RedirectToAction("Index", "Home", new { Result = ResultCode });
        }
        #endregion

        private NorthwindGenInc GetGenIncData(FormCollection fc)
        {
            NorthwindGenInc n = new NorthwindGenInc();
            n.ERS_Operator = fc["ersop"].ToString();
            n.Caller_Name = fc["txtcallername"].ToString();
            n.Caller_Phone_Number = fc["txtcallerphonenumber"].ToString();
            n.EmpOrContract = fc["EmpOrContract"].ToString();
            n.ContractedCompany = fc["ContractedCompany"].ToString();
            n.Call_Date = DateTime.Parse(fc["txtcalldate"].ToString());
            n.Call_Time = fc["txtcalltime"].ToString();
            n.Incident_Date = DateTime.Parse(fc["txtincidentdate"].ToString());
            n.Incident_Time = fc["txtincidenttime"].ToString();
            n.Incident_Time_Zone = fc["txtincidenttimezone"].ToString();
            n.Incident_City = fc["txtincidentcity"].ToString();
            n.Incident_State = fc["txtstate"].ToString();
            n.Incident_County = fc["txtincidentcounty"].ToString();
            n.FacilityOrProject = fc["ddlFacilityOrProject"].ToString();
            n.IncidentLocation = fc["txtIncidentLocation"].ToString();
            n.IncidentType = fc["IncidentType"].ToString();
            n.WaterbodiesImpacted = fc["WaterbodiesImpacted"].ToString();
            n.ImpactedAreas = fc["txtimpactedareas"].ToString();
            n.IncidentDetails = fc["txtincidentdetails"].ToString();
            n.IndividualSafety = fc["IndSafeTxt"].ToString();
            n.Notify_911 = fc["txtnotify911"].ToString();
            n.Transport_ToHospital = fc["txttransportedtohospital"].ToString();
            n.Media_On_Scene = fc["txtmediaonscene"].ToString();
            n.Emergency_Responders = fc["txtemergencyresponders"].ToString();
            n.HSERName = fc["txthsername"].ToString();
            n.HSERContactNumber = fc["txthsercontactnumber"].ToString();
            n.NotificationDate = DateTime.Parse(fc["NotificationDate"].ToString());
            n.NotificationTime = fc["NotificationTime"].ToString();

            return n;
        }
        private NorthwindPipeline GetPipelineData(FormCollection fc)
        {
            NorthwindPipeline n = new NorthwindPipeline();
            n.Call_Date = DateTime.Parse(fc["txtcalldate"].ToString());
            n.Call_Time = fc["txtcalltime"].ToString();
            n.Incident_Date = DateTime.Parse(fc["txtdate"].ToString());
            n.Incident_Time = fc["txttime"].ToString();
            n.TimeZone = fc["txttimezone"].ToString();
            n.City = fc["txtcity"].ToString();
            n.State = fc["txtstate"].ToString();
            n.County = fc["txtcounty"].ToString();
            n.GeneralDirectionFrom = fc["GenDirFrom"].ToString();
            n.ClosestLandmark = fc["ClosestLandmark"].ToString();
            n.Intersection = fc["txtintersection"].ToString();
            n.Observing = fc["txtobserving"].ToString();

            if (fc["cbblackorwhitesmoke"] != null && fc["cbblackorwhitesmoke"].ToString() == "on")
            {
                n.Smoke = "TRUE";
                if (n.SeeingHearingSmelling == "")
                    n.SeeingHearingSmelling = "Black Or White Smoke";
                else
                    n.SeeingHearingSmelling += ", " + "Black Or White Smoke";
            }
            else
                n.Smoke = "FALSE";
            if (fc["cbflames"] != null && fc["cbflames"].ToString() == "on")
            {
                n.Flames = "TRUE";
                if (n.SeeingHearingSmelling == "")
                    n.SeeingHearingSmelling = "Flames";
                else
                    n.SeeingHearingSmelling += ", " + "Flames";
            }
            else
                n.Flames = "FALSE";
            if (fc["cbhissing"] != null && fc["cbhissing"].ToString() == "on")
            {
                n.Hissing = "TRUE";
                if (n.SeeingHearingSmelling == "")
                    n.SeeingHearingSmelling = "Hissing";
                else
                    n.SeeingHearingSmelling += ", " + "Hissing";
            }
            else
                n.Hissing = "FALSE";
            if (fc["cbliquid"] != null && fc["cbliquid"].ToString() == "on")
            {
                n.Liquid = "TRUE";
                if (n.SeeingHearingSmelling == "")
                    n.SeeingHearingSmelling = "Liquid";
                else
                    n.SeeingHearingSmelling += ", " + "Liquid";
            }
            else
                n.Liquid = "FALSE";
            if (fc["cboilysheen"] != null && fc["cboilysheen"].ToString() == "on")
            {
                n.Oily_Sheen = "TRUE";
                if (n.SeeingHearingSmelling == "")
                    n.SeeingHearingSmelling = "Oily Sheen";
                else
                    n.SeeingHearingSmelling += ", " + "Oily Sheen";
            }
            else
                n.Oily_Sheen = "FALSE";
            if (fc["cbotherpipelinemarkers"] != null && fc["cbotherpipelinemarkers"].ToString() == "on")
            {
                n.Other_Pipeline_Markers = "TRUE";
                if (n.SeeingHearingSmelling == "")
                    n.SeeingHearingSmelling = "Other Pipeline Markers";
                else
                    n.SeeingHearingSmelling += ", " + "Other Pipeline Markers";
            }
            else
                n.Other_Pipeline_Markers = "FALSE";
            if (fc["cbrotteneggodor"] != null && fc["cbrotteneggodor"].ToString() == "on")
            {
                n.Rotten_Egg_Odor = "TRUE";
                if (n.SeeingHearingSmelling == "")
                    n.SeeingHearingSmelling = "Rotten Egg Odor";
                else
                    n.SeeingHearingSmelling += ", " + "Rotten Egg Odor";
            }
            else
                n.Rotten_Egg_Odor = "FALSE";
            if (fc["cbvaporsormist"] != null && fc["cbvaporsormist"].ToString() == "on")
            {
                n.Vapor_Or_Mist = "TRUE";
                if (n.SeeingHearingSmelling == "")
                    n.SeeingHearingSmelling = "Vapor Or Mist";
                else
                    n.SeeingHearingSmelling += ", " + "Vapor Or Mist";
            }
            else
                n.Vapor_Or_Mist = "FALSE";

            if (n.SeeingHearingSmelling == "")
            {
                n.SeeingHearingSmelling = "N/A";
            }
            n.ROW_OR_Well_Pad = fc["txtroeworwellpad"].ToString();
            n.Tanks = fc["txttanks"].ToString();
            n.Landowner = fc["txtlandowner"].ToString();
            n.Lease_Well_Name = fc["txtleasewellname"].ToString();
            n.Caller_Name = fc["txtcallername"].ToString();
            n.Caller_Phone = fc["txtcallerphone"].ToString();
            n.Notify_911 = fc["txtnotify911"].ToString();
            n.Anyone_Injured = fc["txtanyoneinjured"].ToString();
            n.Immediate_Danger = fc["txtimmediatedanger"].ToString();
            n.Relation_ToIncident = fc["txtrelationtoincident"].ToString();
            n.Safely_Warn = fc["txtsafelywarn"].ToString();
            n.Report_Taker_Name = fc["txtreporttakername"].ToString();
            n.Report_Taker_Email = fc["txtreporttakeremail"].ToString();
            //n.Temperature = "";
            //n.Wind_Speed = "";
            //n.Wind_Direction = "";
            //n.Weather_Conditions = "";
            n.NotifiedName = fc["txtname"].ToString();
            n.NotifiedNumber = fc["txtcontactnumber"].ToString();
            n.NotifiedEmail = fc["txtcontactemail"].ToString();
            n.NotificationDate = DateTime.Parse(fc["NotificationDate"].ToString());
            n.NotificationTime = fc["NotificationTime"].ToString();
            return n;
        }
        private string CreatePipelineReport(int id, string Year)
        {
            try
            {
                string path = @"\\chem-fs1.ers.local\completed reports\Northwind Incidents\Pipeline\" + Year + "\\";
                string oldpath = @"\\chem-fs1.ers.local\completed reports\Northwind Incidents\Pipeline\" + Year + "\\Northwind Pipeline - " + id.ToString() + ".pdf";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                ReportDocument cryRpt = new ReportDocument(); //Defines a report variable.
                string rptLoadPath = @"\\chem-fs1.ers.local\Chemtel Apps\Crystal Reports\NorthwindPipelineIncident.rpt";  //This is the path to the report template.
                string outPutFilePath = path + "Northwind Pipeline - " +  id.ToString() + ".pdf"; //Sets the path to the PDF file
                if (System.IO.File.Exists(oldpath))
                {
                    System.IO.File.Delete(oldpath);
                }
                cryRpt.Load(rptLoadPath); //Loads the report template used to create the report.
                using (chemreporterEntities context = new chemreporterEntities())  //Initializes the Entity Model.
                {
                    var query = (from obj in context.NorthwindPipelineIncidents where obj.ID == id select obj).ToList();  //This query will be used to retrieve the record.
                    cryRpt.SetDataSource(query); //The report's data source is set to the query.  This executes the query and creats the report.
                                                 // cryRpt.SetParameterValue(0, id); //Sets the parameter value.
                    cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, outPutFilePath); //Converts the report to a PDF file.
                }
                return outPutFilePath; //Returns the path of the report to btnsubmit_Click so the email form can attach it.
            } catch (Exception ex)
            {
                string path = @"\\chem-fs1.ers.local\Log Files\Chemical.log";
                StreamWriter log;
                if (System.IO.File.Exists(path))
                    log = System.IO.File.AppendText(path);
                else
                    log = System.IO.File.CreateText(path);
                //string sp = " ";
                string mod = "CreatePipelineReport";
                string pfile = "CrestwoodController.cs";
                log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\n" + "Error Message: " + ex.Message + "\n" + "File: " + pfile + "\n" + "Method: " + mod + "\n\n\n");
                log.Close();

                var client = new SendGridClient("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");
                var from = new EmailAddress("ers@ehs.com");
                string body = "Check the log file!\n" + ex.Message;
                string subject = "Chemical Report Manager Error";
                var to = new EmailAddress("mpepitone@ehs.com");
                var msg = MailHelper.CreateSingleEmail(from, to, subject, "", body);
                client.SendEmailAsync(msg);
                return "false";
            }
        }
        private int GetLatestPipelineID()
        {
            int id = 0;
            string strsql = "SELECT TOP 1 id FROM NorthwindPipelineIncidents ORDER BY ID DESC";
            using (SqlConnection cn = new SqlConnection(Session["constring"].ToString()))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {

                    id = int.Parse(cmd.ExecuteScalar().ToString());
                }
            }
            return id;
        }
    }
}