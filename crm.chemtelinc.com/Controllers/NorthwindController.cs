using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using ChemicalLibrary;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SendGrid;
using SendGrid.Helpers.Mail;
using ChemicalLibrary;

namespace crm.chemtelinc.com.Controllers
{
    public class NorthwindController : Controller
    {
        string constring = Properties.Settings.Default.chemicalConnectionString;
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

            if (fc["Revised"].ToString() != "true")
            {
                Add.AddNorthwindGenInc(constring, ngi); //Add new report data to the database.
                ngi.ID = GetLatestGenIncID();
            } else
            {
                ngi.ID = Int32.Parse(fc["ReportID"].ToString());
                Update.UpdateNorthindGeneralIncident(constring, ngi);
            }
            //start prep for email autopopulation.
            NorthwindEmail nwe = new NorthwindEmail();
            DateTime callDate = ngi.Call_Date;
            DateTime callTime = DateTime.Parse(ngi.Call_Time);
            DateTime incidentDate = ngi.Incident_Date;
            DateTime incidentTime = DateTime.Parse(ngi.Incident_Time);
            DateTime notificationDate = ngi.NotificationDate;
            DateTime notificationTime = DateTime.Parse(ngi.NotificationTime);


            string filepath = CreateGenIncReport(ngi.ID, ngi.Call_Date.Year.ToString());


            nwe.ID = ngi.ID;
            nwe.FilePath = filepath;
            nwe.ToEmails = "mpepitone@ehs.com,ers@ehs.com,ben@nwmidstream.com,dbarton@nwmidstream.com,agarza@nwmidstream.com,emiller@nwmidstream.com,rregister@nwmidstream.com,ssanders@nwmidstream.com,jsouthard@nwmidstream.com,jsisk@nwmidstream.com,jyamartino@nwmidstream.com";
            if (ngi.IncidentType == "Vehicle Accident")
            {
                nwe.ToEmails += ",egarza@nwmidstream.com,npeters@nwmidstream.com";
            }
            nwe.Subject = "Incident Notification: ";
            if (fc["ddlFacilityOrProject"].ToString() == "Yes")
            {
                nwe.Subject += callDate.ToString("yyyyMMdd") + " | " + ngi.IncidentLocation + " | " + ngi.IncidentType;
            }
            else
            {
                nwe.Subject += callDate.ToString("yyyyMMdd") + " | " + ngi.Incident_City + ", " + ngi.Incident_State + " | " + ngi.IncidentType;
            }
            nwe.Body = "The Northwind Incident Hotline was notified at " + ngi.NotificationTime + " EST that at approximately " + ngi.Incident_Time + " " +ngi.Incident_Time_Zone + " on " + incidentDate.ToString("yyyy-MM-dd") + ", " +
               ngi.IncidentDetails + ". This occurred at " + ngi.IncidentLocation + " near " + ngi.Incident_City + ", " + ngi.Incident_State + ".";
            if (ngi.InjuryExposureIllness == "Yes")
            {
                nwe.Body += " There was a report of an injury, exposure, or illness associated with this incident.";
            } else
            {
                nwe.Body += " There were no injuries reported.";
            }
            if (ngi.ChemicalSpillRelease == "Yes") //If there was a chemical/product spill/release
            {
                nwe.Body += " There was a report of a chemical/product spill/release.";
                if (ngi.WaterbodiesImpacted == "Yes") //If there were bodies 
                {
                    nwe.Body += " The spill/release did impact one or more water bodies. " + ngi.ImpactedAreas + ".";
                }
            } else
            {
                nwe.Body += " There was no reported spill/release.";
            }
            nwe.Body += " An incident report will be initiated within the Northwind Incident Management System and assigned to the EHSR Advisor for update and completion.";
            return View("EmailForm", nwe);
        }

        public ActionResult SubmitNewPipelineReport(FormCollection fc)
        {
            NorthwindPipeline n = new NorthwindPipeline();
            NorthwindEmail nwe = new NorthwindEmail();
            n = GetPipelineData(fc);

            if (fc["Revised"].ToString() != "true") //New report
            {
                Add.AddNorthwindPipeline(constring, n);
                n.ID = GetLatestPipelineID(); // Gets and sets the new ID that was just entered.
            }
            else // Updated report (user clicked Back To Report button)
            {
                n.ID = Int32.Parse(fc["ReportID"].ToString());
                Update.UpdateNorthwindPipeline(constring, n);
            }
            string filepath = CreatePipelineReport(n.ID, n.Call_Date.Year.ToString());
            string LocationString = "";
            if (n.City == "UNK")
            {
                LocationString = n.ClosestLandmark;
            }
            else
            {
                LocationString = n.City;
            }


            nwe.ID = n.ID;
            nwe.ReportType = "Pipeline";
            nwe.ToEmails = "mpayne@nwmidstream.com,rregister@nwmidstream.com,avillalobos@nwmidstream.com,ben@nwmidstream.com,emiller@nwmidstream.com,jsouthard@nwmidstream.com,dbarton@nwmidstream.com,jyamartino@nwmidstream.com,klewis@nwmidstream.com,jsisk@nwmidstream.com,mpepitone@ehs.com,ers@ehs.com";
            nwe.FilePath = filepath;
            nwe.Subject = "Pipeline Incident Notification: " + n.Call_Date.ToString("yyyyMMdd") + " " + n.County + ", " + n.State;
            nwe.Body = "Northwind's Pipeline Emergency Hotline was notified at: " + DateTime.Parse(n.Call_Time).ToString("HH:mm") + " of a potential incident located in " + n.County + ", " + n.State + " near " + LocationString
                 + ". Northwind personnel have been notified of the situation and are currently investigating the report." +
                " Additional details are attached to this email.";
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

        public ActionResult BackToReport(FormCollection fc)
        {
            ViewBag.Revised = "true";
            if (fc["ReportType"].ToString() == "Pipeline")
            {
                NorthwindPipeline nwp = new NorthwindPipeline(constring, int.Parse(fc["reportid"].ToString()));  //Gets the desired report and puts it into a custom class variable.
                return View("Pipeline", nwp);
            } else
            {
                NorthwindGenInc ngi = new NorthwindGenInc(constring, int.Parse(fc["reportid"].ToString()));
                return View("GeneralIncident", ngi);
            }
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
            //n.Incident_County = fc["txtincidentcounty"].ToString();
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
            n.InjuryExposureIllness = fc["InjuryExposureIllness"].ToString();
            n.ChemicalSpillRelease = fc["ChemicalSpillRelease"].ToString();

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
            n.DirectionFromLandmark = fc["DirectionFromLandmark"].ToString();
            n.ClosestLandmark = fc["ClosestLandmark"].ToString();
            n.DistanceFromLandmark = fc["DistanceFromLandmark"].ToString();
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
                string outPutFilePath = path + "Northwind Pipeline - " + id.ToString() + ".pdf"; //Sets the path to the PDF file
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
                string mod = "CreatePipelineReport";
                string pfile = "NorthwindController.cs";
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
        private string CreateGenIncReport(int id, string Year)
        {
            try
            {
                string path = @"\\chem-fs1.ers.local\completed reports\Northwind Incidents\General Incident\" + Year + "\\";
                string oldpath = @"\\chem-fs1.ers.local\completed reports\Northwind Incidents\General Incident\" + Year + "\\Northwind GI - " + id.ToString() + ".pdf";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                ReportDocument cryRpt = new ReportDocument(); //Defines a report variable.
                string rptLoadPath = @"\\chem-fs1.ers.local\Chemtel Apps\Crystal Reports\NorthwindGenInc.rpt";  //This is the path to the report template.
                string outPutFilePath = path + "Northwind GI - " + id.ToString() + ".pdf"; //Sets the path to the PDF file
                if (System.IO.File.Exists(oldpath))
                {
                    System.IO.File.Delete(oldpath);
                }
                cryRpt.Load(rptLoadPath); //Loads the report template used to create the report.
                using (chemreporterEntities context = new chemreporterEntities())  //Initializes the Entity Model.
                {
                    var query = (from obj in context.NorthwindGeneralIncidents where obj.ID == id select obj).ToList();  //This query will be used to retrieve the record.
                    cryRpt.SetDataSource(query); //The report's data source is set to the query.  This executes the query and creats the report.
                                                 // cryRpt.SetParameterValue(0, id); //Sets the parameter value.
                    cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, outPutFilePath); //Converts the report to a PDF file.
                }
                return outPutFilePath; //Returns the path of the report to btnsubmit_Click so the email form can attach it.
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
                string mod = "CreateGenIncReport";
                string pfile = "NorthwindController.cs";
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
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {

                    id = int.Parse(cmd.ExecuteScalar().ToString());
                }
            }
            return id;
        }
        private int GetLatestGenIncID()
        {
            int id = 0;
            string strsql = "SELECT TOP 1 id FROM NorthwindGeneralIncidents ORDER BY ID DESC";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {

                    id = int.Parse(cmd.ExecuteScalar().ToString());
                }
            }
            return id;
        }

        #region Log Functions
        public ActionResult NorthwindLogs()
        {
            string LogType = Request.QueryString["SelectedLog"].ToString();
            ViewBag.LogSelected = LogType;
            List<NorthwindLog> NWLogList = new List<NorthwindLog>();

            if (LogType == "GeneralIncident")
            {
                string sqlcmd = "SELECT TOP 100 * FROM NorthwindGeneralIncidents ORDER BY id DESC";
                using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                    {
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            NorthwindLog c = new NorthwindLog();
                            c.id = Int32.Parse(sdr["ID"].ToString());
                            c.ERSOperator = sdr["ERSOperator"].ToString();
                            c.CallerName = sdr["CallerName"].ToString();
                            c.CallerPhone = sdr["CallerPhone"].ToString();
                            c.Incident_Contractor_Or_Employee = sdr["EmpOrContract"].ToString();
                            c.ContractedCompany = sdr["ContractedCompany"].ToString();
                            c.CallDate = sdr["CallDate"].ToString().Split(' ')[0];
                            c.CallTime = sdr["CallTime"].ToString();
                            c.IncidentDate = sdr["IncidentDate"].ToString().Split(' ')[0];
                            c.IncidentTime = sdr["IncidentTime"].ToString();
                            c.IncidentTimeZone = sdr["IncidentTimeZone"].ToString();
                            c.IncidentCity = sdr["IncidentCity"].ToString();
                            c.State = sdr["IncidentState"].ToString();
                            c.FacilityOrProject = sdr["FacilityOrProject"].ToString();
                            c.IncidentLocation = sdr["IncidentLocation"].ToString();
                            c.IncidentNature = sdr["IncidentNature"].ToString();
                            c.InjuryExposureIllness = sdr["InjuryExposureIllness"].ToString();
                            c.ChemicalSpillRelease = sdr["ChemicalSpillRelease"].ToString();
                            c.WaterBodiesImpacted = sdr["WaterbodiesImpacted"].ToString();
                            c.ImpactedArea = sdr["ImpactedAreaDetails"].ToString();
                            c.IncidentDetails = sdr["IncidentDetails"].ToString();
                            c.IndividualSafety = sdr["IndividualSafety"].ToString();
                            c.Notify911 = sdr["Notify911"].ToString();
                            c.TransportToHospital = sdr["TransportToHospital"].ToString();
                            c.MediaOnScene = sdr["MediaOnScene"].ToString();
                            c.EMSOnScene = sdr["EmergencyResponders"].ToString();
                            c.HSERName = sdr["HSERName"].ToString();
                            c.HSERPhone = sdr["HSERPhone"].ToString();
                            c.NotificationDate = sdr["NotificationDate"].ToString().Split(' ')[0];
                            c.NotificationTime = sdr["NotificationTime"].ToString();
                            NWLogList.Add(c);
                        }
                    }
                }
                return View(NWLogList.ToList());
            }
            else if (LogType == "Pipeline")
            {
                string sqlcmd = "SELECT TOP 100 * FROM NorthwindPipelineIncidents ORDER BY id DESC";
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                    {
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            NorthwindLog c = new NorthwindLog();
                            c.id = Int32.Parse(sdr["ID"].ToString());
                            c.County = sdr["County"].ToString();
                            c.State = sdr["State"].ToString();
                            c.Observing = sdr["Observing"].ToString();
                            c.Date = sdr["CallDate"].ToString();
                            c.NotificationDate = sdr["NotificationDate"].ToString();
                            c.NotificationTime = sdr["NotificationTime"].ToString();
                            NWLogList.Add(c);
                        }
                    }
                }
                return View(NWLogList.ToList());
            }
            else
            {
                return View(NWLogList.ToList());
            }
        }
        public ActionResult ReportLogSearch(FormCollection fc)
        {
            List<NorthwindLog> NWLogList = new List<NorthwindLog>();
            if (fc["submittype"].ToString() == "Search")
            {
                if (fc["logtype"].ToString() == "GeneralIncident")
                {
                    string sqlcmd = "SELECT * FROM NorthwindGeneralIncidents WHERE id LIKE '%" + fc["reportid"] + "%' ORDER BY id DESC";
                    using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                        {
                            con.Open();
                            SqlDataReader sdr = cmd.ExecuteReader();
                            while (sdr.Read())
                            {
                                NorthwindLog c = new NorthwindLog();
                                c.id = Int32.Parse(sdr["ID"].ToString());
                                c.ERSOperator = sdr["ERSOperator"].ToString();
                                c.CallerName = sdr["CallerName"].ToString();
                                c.CallerPhone = sdr["CallerPhone"].ToString();
                                c.Incident_Contractor_Or_Employee = sdr["EmpOrContract"].ToString();
                                c.ContractedCompany = sdr["ContractedCompany"].ToString();
                                c.CallDate = sdr["CallDate"].ToString();
                                c.CallTime = sdr["CallTime"].ToString();
                                c.IncidentDate = sdr["IncidentDate"].ToString();
                                c.IncidentTime = sdr["IncidentTime"].ToString();
                                c.IncidentTimeZone = sdr["IncidentTimeZone"].ToString();
                                c.IncidentCity = sdr["IncidentCity"].ToString();
                                c.State = sdr["IncidentState"].ToString();
                                c.FacilityOrProject = sdr["FacilityOrProject"].ToString();
                                c.IncidentLocation = sdr["IncidentLocation"].ToString();
                                c.IncidentNature = sdr["IncidentNature"].ToString();
                                c.InjuryExposureIllness = sdr["InjuryExposureIllness"].ToString();
                                c.ChemicalSpillRelease = sdr["ChemicalSpillRelease"].ToString();
                                c.WaterBodiesImpacted = sdr["WaterbodiesImpacted"].ToString();
                                c.ImpactedArea = sdr["ImpactedAreaDetails"].ToString();
                                c.IncidentDetails = sdr["IncidentDetails"].ToString();
                                c.IndividualSafety = sdr["IndividualSafety"].ToString();
                                c.Notify911 = sdr["Notify911"].ToString();
                                c.TransportToHospital = sdr["TransportToHospital"].ToString();
                                c.MediaOnScene = sdr["MediaOnScene"].ToString();
                                c.EMSOnScene = sdr["EmergencyResponders"].ToString();
                                c.HSERName = sdr["HSERName"].ToString();
                                c.HSERPhone = sdr["HSERPhone"].ToString();
                                c.NotificationDate = sdr["NotificationDate"].ToString();
                                c.NotificationTime = sdr["NotificationTime"].ToString();
                                NWLogList.Add(c);
                            }
                        }
                    };
                }
                else if (fc["logtype"].ToString() == "Pipeline")
                {
                    string sqlcmd = "SELECT * FROM NorthwindPipelineIncidents WHERE id LIKE '%" + fc["reportid"] + "%' ORDER BY id DESC";
                    using (SqlConnection con = new SqlConnection(constring))
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                        {
                            con.Open();
                            SqlDataReader sdr = cmd.ExecuteReader();
                            while (sdr.Read())
                            {
                                NorthwindLog c = new NorthwindLog();
                                c.id = Int32.Parse(sdr["id"].ToString());
                                c.County = sdr["County"].ToString();
                                c.State = sdr["state"].ToString();
                                c.Observing = sdr["Observing"].ToString();
                                c.Date = sdr["CallDate"].ToString();
                                c.NotificationDate = sdr["NotificationDate"].ToString();
                                c.NotificationTime = sdr["NotificationTime"].ToString();
                                NWLogList.Add(c);
                            }
                        }
                    };
                }
                ViewBag.LogSelected = fc["logtype"].ToString();
                return View("NorthwindLogs", NWLogList.ToList());
            }
            else if (fc["submittype"].ToString() == "Revise") //Revise Selected or Typed Report ID
            {
                if (fc["logtype"].ToString() == "Pipeline")
                {
                    ViewBag.Revised = "true";
                    NorthwindPipeline nwpi = new NorthwindPipeline(constring, int.Parse(fc["reportid"].ToString()));
                    return View("Pipeline", nwpi);
                } else
                {

                    ViewBag.Revised = "true";
                    NorthwindGenInc ngi = new NorthwindGenInc(constring, int.Parse(fc["reportid"].ToString()));
                    return View("GeneralIncident", ngi);
                }
            }
            return View("CrestwoodLogs");
        }
        #endregion
    }
}