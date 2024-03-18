using ChemicalLibrary;
using crm.chemtelinc.com.Models;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;

namespace crm.chemtelinc.com.Controllers
{
    public class CrestwoodController : Controller
    {
        public int id = 0;  //Used to determine if a report was opened from the log.  If so, this variable will hold the ID number of that report
        int tmpid = 0;  //Temp variable
        string ersop = "";
        string email = "";  //Holds the ESR member's email address.
        string drill = "";
        string filepath = ""; 
        bool emptyreport = false;  //Flag used to indicate whether the report form is empty, or if a report successfully submitted.  Flag is checked when the form closes.
        string pipelineemail = ",AssetType-Pipeline@crestwoodlp.com";  //Class-level variable that holds the ESR member's email address so it can be passed to the email form.
        string CCemail = "";  //Class-level variable that holds the CC email address(es) so it can be passed to the email form.
        string initials = "";
        string NERegion = ",AL,CO,DE,DC,FL,GA,IN,KY,ME,MA,MI,MS,NH,NJ,NY,NC,OH,PA,RI,SC,TN,VT,VA,WV,";
        string CentralRegion = ",AZ,AR,IL,IA,KS,LA,MN,MO,NB,NM,OK,TX,UT,WI,";
        string NorthRegion = ",AK,CA,HI,ID,MT,NV,ND,OR,SD,WA,WY,";


        #region Log Functions
        public ActionResult CrestwoodLogs()
        {
            string LogType = Request.QueryString["SelectedLog"].ToString();
            ViewBag.LogSelected = LogType;
            List<CrestwoodLog> CrestLogList = new List<CrestwoodLog>();

            if (LogType == "GeneralIncident")
            {
                string sqlcmd = "SELECT TOP 100 * FROM crestgeneralincidents ORDER BY id DESC";
                using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                    {
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            CrestwoodLog c = new CrestwoodLog();
                            c.id = Int32.Parse(sdr["id"].ToString());
                            c.CallerName = sdr["CallerName"].ToString();
                            c.IncidentDate = sdr["IncidentDate"].ToString();
                            c.IncidentNature = sdr["IncidentNature"].ToString();
                            c.Initials = sdr["Initials"].ToString();
                            c.County = sdr["County"].ToString();
                            c.Drill = sdr["Drill"].ToString();
                            c.Incident_Contractor_Or_Employee = sdr["Incident_Contractor_Or_Employee"].ToString();
                            c.IndividualSafety = sdr["IndividualSafety"].ToString();
                            c.WeaponReported = sdr["WeaponReported"].ToString();
                            c.WeaponType = sdr["WeaponType"].ToString();
                            c.wpviolence = sdr["wpviolence"].ToString();
                            c.FacilityOrProject = sdr["FacilityOrProject"].ToString();
                            c.RegionOrFacility = sdr["RegionOrFacility"].ToString();
                            c.ContractorName = sdr["ContractorName"].ToString();
                            c.FacilityOrProjectSelection = sdr["FacilityOrProjectSelection"].ToString();
                            c.OccuredOnPipeline = sdr["OccuredOnPipeline"].ToString();
                            c.NotificationDate = sdr["NotificationDate"].ToString();
                            c.NotificationTime = sdr["NotificationTime"].ToString();
                            c.PC_CWLocOrTransport = sdr["PC_CWLocOrTransport"].ToString();
                            c.SusAct = sdr["SusAct"].ToString();
                            c.SpillOrReleaseIntoAtmo = sdr["SpillOrReleaseIntoAtmo"].ToString();
                            c.MaterialSpilled = sdr["MaterialSpilled"].ToString();
                            c.WaterbodiesImpacted = sdr["WaterbodiesImpacted"].ToString();
                            c.ContainedOnSite = sdr["ContainedOnSite"].ToString();
                            c.SpillContainedSecondary = sdr["SpillContainedSecondary"].ToString();
                            CrestLogList.Add(c);
                        }
                    }
                }
                return View(CrestLogList.ToList());
            } else if (LogType == "Pipeline")
            {
                string sqlcmd = "SELECT TOP 100 * FROM crestpiplineincidents ORDER BY id DESC";
                using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                    {
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            CrestwoodLog c = new CrestwoodLog();
                            c.id = Int32.Parse(sdr["id"].ToString());
                            c.County = sdr["County"].ToString();
                            c.State = sdr["State"].ToString();
                            c.Observing = sdr["Observing"].ToString();
                            c.Date = sdr["Date"].ToString();
                            c.Initials = sdr["Initials"].ToString();
                            c.NotificationDate = sdr["NotificationDate"].ToString();
                            c.NotificationTime = sdr["NotificationTime"].ToString();
                            c.Drill = sdr["Drill"].ToString();
                            CrestLogList.Add(c);
                        }
                    }
                }
                return View(CrestLogList.ToList());
            }
            
            else if (LogType == "811") {
                string sqlcmd = "SELECT TOP 100 * FROM crest811 WHERE requestticketnumber != '' ORDER BY id DESC";
                using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                    {
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            CrestwoodLog c = new CrestwoodLog();
                            c.id = Int32.Parse(sdr["id"].ToString());
                            c.Date = sdr["todaydate"].ToString();
                            c.Time = sdr["todaytime"].ToString();
                            c.ExcavationDate = sdr["excavationdate"].ToString();
                            c.ExcavationTime = sdr["excavationtime"].ToString();
                            c.NormalOrEmergency = sdr["normaloremergency"].ToString();
                            c.RequestTicketNo = sdr["requestticketnumber"].ToString();
                            c.PersonCompanyName = sdr["personcompanyname"].ToString();
                            c.CallbackNumber = sdr["callbacknumber"].ToString();
                            c.EmailAddress = sdr["emailaddress"].ToString();
                            c.City = sdr["city"].ToString();
                            c.State = sdr["state"].ToString();
                            c.County = sdr["county"].ToString();
                            c.WorkDate = sdr["workdate"].ToString();
                            c.Street = sdr["street"].ToString();
                            c.Intersection= sdr["intersection"].ToString();
                            c.Nature= sdr["nature"].ToString();
                            c.Remarks= sdr["remarks"].ToString();
                            c.FacilityName = sdr["FacilityName"].ToString();
                            CrestLogList.Add(c);
                        }
                    }
                }
                return View(CrestLogList.ToList());
            } else if (LogType == "LockedGate")
            {
                string sqlcmd = "SELECT id, callername, callernumber, state, county, name, contactnumber, location FROM crest811 WHERE state !='' AND county !='' AND callername !='' AND callernumber !='' AND name !=''AND contactnumber !='' AND location !='' ORDER BY id DESC";
                using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                    {
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            CrestwoodLog c = new CrestwoodLog();
                            c.id = Int32.Parse(sdr["id"].ToString());
                            c.CallerName = sdr["callername"].ToString();
                            c.CallerNumber = sdr["callernumber"].ToString();
                            c.State = sdr["state"].ToString();
                            c.County = sdr["county"].ToString();
                            c.Name = sdr["name"].ToString();
                            c.ContactNumber = sdr["contactnumber"].ToString();
                            c.Location = sdr["location"].ToString();
                            CrestLogList.Add(c);
                        }
                    }
                }
                return View(CrestLogList.ToList());
            }
            else
            {
                return View(CrestLogList.ToList());
            }
        }
        public ActionResult ReportLogSearch(FormCollection fc)
        {
            List<CrestwoodLog> CrestLogList = new List<CrestwoodLog>();
            if (fc["submittype"].ToString() == "Search")
            {
                if (fc["logtype"].ToString() == "GeneralIncident")
                {
                    string sqlcmd = "SELECT * FROM crestgeneralincidents WHERE id LIKE '%" + fc["reportid"] + "%' ORDER BY id DESC";
                    using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                        {
                            con.Open();
                            SqlDataReader sdr = cmd.ExecuteReader();
                            while (sdr.Read())
                            {
                                CrestwoodLog c = new CrestwoodLog();
                                c.id = Int32.Parse(sdr["id"].ToString());
                                c.CallerName = sdr["CallerName"].ToString();
                                c.IncidentDate = sdr["IncidentDate"].ToString();
                                c.IncidentNature = sdr["IncidentNature"].ToString();
                                c.Initials = sdr["Initials"].ToString();
                                c.County = sdr["County"].ToString();
                                c.Drill = sdr["Drill"].ToString();
                                c.Incident_Contractor_Or_Employee = sdr["Incident_Contractor_Or_Employee"].ToString();
                                c.IndividualSafety = sdr["IndividualSafety"].ToString();
                                c.WeaponReported = sdr["WeaponReported"].ToString();
                                c.WeaponType = sdr["WeaponType"].ToString();
                                c.wpviolence = sdr["wpviolence"].ToString();
                                c.FacilityOrProject = sdr["FacilityOrProject"].ToString();
                                c.RegionOrFacility = sdr["RegionOrFacility"].ToString();
                                c.ContractorName = sdr["ContractorName"].ToString();
                                c.FacilityOrProjectSelection = sdr["FacilityOrProjectSelection"].ToString();
                                c.OccuredOnPipeline = sdr["OccuredOnPipeline"].ToString();
                                c.NotificationDate = sdr["NotificationDate"].ToString();
                                c.NotificationTime = sdr["NotificationTime"].ToString();
                                c.PC_CWLocOrTransport = sdr["PC_CWLocOrTransport"].ToString();
                                c.SusAct = sdr["SusAct"].ToString();
                                c.SpillOrReleaseIntoAtmo = sdr["SpillOrReleaseIntoAtmo"].ToString();
                                c.MaterialSpilled = sdr["MaterialSpilled"].ToString();
                                c.WaterbodiesImpacted = sdr["WaterbodiesImpacted"].ToString();
                                c.ContainedOnSite = sdr["ContainedOnSite"].ToString();
                                c.SpillContainedSecondary = sdr["SpillContainedSecondary"].ToString();
                                CrestLogList.Add(c);
                            }
                        }
                    };
                } else if (fc["logtype"].ToString() == "Pipeline")
                {
                    string sqlcmd = "SELECT * FROM crestpiplineincidents WHERE id LIKE '%" + fc["reportid"] + "%' ORDER BY id DESC";
                    using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
                    {
                        using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                        {
                            con.Open();
                            SqlDataReader sdr = cmd.ExecuteReader();
                            while (sdr.Read())
                            {
                                CrestwoodLog c = new CrestwoodLog();
                                c.id = Int32.Parse(sdr["id"].ToString());
                                c.County = sdr["County"].ToString();
                                c.State = sdr["state"].ToString();
                                c.Observing = sdr["Observing"].ToString();
                                c.Date = sdr["Date"].ToString();
                                c.Initials = sdr["Initials"].ToString();
                                c.NotificationDate = sdr["NotificationDate"].ToString();
                                c.NotificationTime = sdr["NotificationTime"].ToString();
                                c.Drill = sdr["Drill"].ToString();
                                CrestLogList.Add(c);
                            }
                        }
                    };
                }
                ViewBag.LogSelected = fc["logtype"].ToString();
                return View("CrestwoodLogs", CrestLogList.ToList());
            }
            else if (fc["submittype"].ToString() == "Revise") //Revise Selected or Typed Report ID
            {
                if (fc["logtype"].ToString() == "GeneralIncident")
                {
                    ViewBag.Revised = "true";
                    CrestGeneralIncident cgi = new CrestGeneralIncident(Session["constring"].ToString(), int.Parse(fc["reportid"].ToString()));  //Gets the desired report and puts it into a custom class variable.
                    return View("GeneralIncident", cgi);
                } else
                {
                    ViewBag.Revised = "true";
                    CrestPipelineIncident cpi = new CrestPipelineIncident(Session["constring"].ToString(), int.Parse(fc["reportid"].ToString()));
                    return View("PipelineReport", cpi);
                }
            }
            return View("CrestwoodLogs");
        }

        public ActionResult BackToReport(FormCollection fc)
        {
            if (fc["ReportType"].ToString() == "General Incident")
            {
                ViewBag.Revised = "true";
                CrestGeneralIncident cgi = new CrestGeneralIncident(Session["constring"].ToString(), int.Parse(fc["reportid"].ToString()));  //Gets the desired report and puts it into a custom class variable.
                return View("GeneralIncident", cgi);
            }
            else
            {
                ViewBag.Revised = "true";
                CrestPipelineIncident cpi = new CrestPipelineIncident(Session["constring"].ToString(), int.Parse(fc["reportid"].ToString()));
                return View("PipelineReport", cpi);
            }
        }

        [HttpGet]
        public JsonResult GetYearByID(string LogSelected, string id)
        {
            string ReportYear = "0000";
            string sqlcmd = "";
            if (LogSelected == "Pipeline")
            {
                sqlcmd = "SELECT TOP 1 calldate FROM crestpiplineincidents WHERE id = @id";
            }
            else
            {
                sqlcmd = "SELECT TOP 1 calldate FROM crestgeneralincidents WHERE id = @id";
            }

            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    ReportYear = cmd.ExecuteScalar().ToString();
                }
            }
            ReportYear = ReportYear.Split('/')[2];
            return Json(new { ReportYear = ReportYear }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateCrestwoodInitials(string IncidentID, string Initials, string ReportType)
        {
            string sql = "";
            if (ReportType == "GeneralIncident")
            {
                sql = "UPDATE crestgeneralincidents SET initials = '" + Initials + "' WHERE id = " + IncidentID;
            } else if (ReportType == "Pipeline")
            {
                sql = "UPDATE crestpiplineincidents SET initials = '" + Initials + "' WHERE id = " + IncidentID;
            }
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

        public JsonResult GenerateReport(string StartDate, string EndDate, string ReportType)
        {
            System.Data.DataTable dt = new System.Data.DataTable("New Datatable");
            DataSet ds = new DataSet("New Dataset");
            string[] dstart = StartDate.Split('-');  //The next few statements get the start date and splits it.
            string month1 = dstart[1];
            string day1 = dstart[2];
            string year1 = dstart[0];
            string[] dend = EndDate.Split('-'); //The next few statements get the end date and splits it.
            string month = dend[1];
            string day = dend[2];
            string year = dend[0];
            string FrakenStartDate = month1 + "/" + day1 + "/" + year1;
            string FrakenEndDate = month + "/" + day + "/" + year;
            string outPutFilePath = "";
            string loadfilepath = "";
            string sql = "";
            string file = "";
            string FileTemplate = "";

            if (ReportType =="GeneralIncident")
            {
                outPutFilePath = @"\\chem-fs1.ers.local\completed reports\Crestwood Incidents\GeneralIncident\Crest General Excel Report\";
                loadfilepath = "https://crm.chemtel.net/Completed Reports/Crestwood Incidents/GeneralIncident/Crest General Excel Report/Crestwood General Incident Report from " + month1 + "-" + day1 + "-" + year1 + " to " + month + "-" + day + "-" + year + ".xlsx"; //File path to have file automatically download when completed
                sql = "SELECT id, incidentdate, calldate, incidentnature, incidentcity, incidentstate, incidentdescription FROM crestgeneralincidents WHERE incidentdate BETWEEN @startdate AND  @enddate"; //Query to get the records within the date range.
                file = outPutFilePath + "Crestwood General Incident Report from " + month1 + "-" + day1 + "-" + year1 + " to " + month + "-" + day + "-" + year + ".xlsx"; //File
                FileTemplate = @"\\chem-fs1.ers.local\completed reports\Excel\CrestGeneralIncident.xlsx";
            } else
            {
                outPutFilePath = @"\\chem-fs1.ers.local\completed reports\Crestwood Incidents\Pipeline\Crest Pipeline Excel Report\";
                sql = "SELECT date , calldate , city, state, observing FROM crestpiplineincidents WHERE date BETWEEN @startdate AND @enddate";
                FileTemplate = @"\\chem-fs1.ers.local\completed reports\Excel\CrestPipelinesIncident.xlsx";
                file = outPutFilePath + "Crestwood Pipelines Incident Report from " + month1 + "-" + day1 + "-" + year1 + " to " + month + "-" + day + "-" + year + ".xlsx";
                loadfilepath = "https://crm.chemtel.net/Completed Reports/Crestwood Incidents/Pipeline/Crest Pipeline Excel Report/Crestwood Pipelines Incident Report from " + month1 + "-" + day1 + "-" + year1 + " to " + month + "-" + day + "-" + year + ".xlsx";
            }

            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                List<string> list = new List<string>();
                SqlCommand cmd = new SqlCommand(sql, con); //Setting up the command object.
                SqlDataAdapter adapt = new SqlDataAdapter(); //Creating an adapter to hold the results of the query.
                cmd.Parameters.AddWithValue("@startdate", FrakenStartDate); //Sets the start date parameter.
                cmd.Parameters.AddWithValue("@enddate", FrakenEndDate); //Sets the end date parameter.
                adapt.SelectCommand = cmd; //Finalizes the parameters.
                adapt.Fill(dt); //Fills the datatable with the query results.
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                if (dt.Rows.Count != 0)
                {
                    ds.Tables.Add(dt); //Adds the table.
                    using (ExcelPackage p = new ExcelPackage(new FileInfo(FileTemplate), true))
                    {
                        ExcelWorksheet ws = p.Workbook.Worksheets[0]; //This block of code creates the Excel file.
                        ws.Cells["A2"].LoadFromDataTable(ds.Tables[0], false);
                        var workbook = p.Workbook;
                        workbook.View.ShowSheetTabs = false;
                        Byte[] bin = p.GetAsByteArray();
                        System.IO.File.WriteAllBytes(file, bin);
                    }
                }
            }
            return Json(new { success = "Success", file = loadfilepath }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Crestwood General Incident Functions
        public ActionResult GeneralIncident()
        {
            //Check if user is logged in, if not, force login.
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                ViewBag.ErrorMessage = "You must login before proceeding!";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Revised = "false";
            return View(new CrestGeneralIncident());
        }
        public ActionResult SubmitCrestGenInc(FormCollection fc)
        {
            try
            {
                CrestGeneralIncident c = new CrestGeneralIncident();
                CrestEmailForm cef = new CrestEmailForm();
                c = GetGenIncData(fc);
                int idd = 0;
                if (fc["btnsubmit"] == "Update")
                {
                    c.ID = Int32.Parse(fc["ReportID"].ToString());
                    Update.UpdateCrestGeneralIncidents(Session["constring"].ToString(), c);
                    idd = c.ID;
                    filepath = CreateGenIncReport(idd, c.Call_Date);  //Calls a method to create the PDF file of the report just added by passing the reports ID number to the method.  //Returns the path to the report.
                } else
                {
                    Add.AddCrestGeneralIncidents(Session["constring"].ToString(), c); //This static method adds a new report to the database
                    idd = GetLatestGenIncID(); //Gets the ID of the report just created and returns it
                    filepath = CreateGenIncReport(idd, c.Call_Date);  //Calls a method to create the PDF file of the report just added by passing the reports ID number to the method.  //Returns the path to the report.
                }          
                //Create new EmailForm Model to pass along
                cef.Type = "General Incident";
                cef.Name = c.ERS_Name_1;
                cef.PhoneNumber = c.ERS_Contact_Number_1;
                cef.ESREmail = fc["txtersemail1"].ToString();
                if (c.Incident_Contractor_Or_Employee == "Private Citizen")
                {
                    cef.CallerEmail = "";
                } else
                {
                    cef.CallerEmail = c.Caller_Email;
                }
                cef.Location = c.ERS_Location_1;
                string[] ar = c.ERS_Location_1.Split(' ');  //Splits the value in location based on space and stores the pieces into an array.
                string region = ar[0];
                cef.Region = region;
                cef.State = c.Incident_State;
                cef.ID = idd;
                cef.FilePath = filepath;
                cef.Drill = c.Drill;
                cef.Transportation = c.Equipment_Or_People;
                cef.EmpOrContract = c.Incident_Contractor_Or_Employee;
                cef.PC_CWLocOrTransport = c.PC_CWLocOrTransport;
                cef.IncidentType = c.Incident_Nature;
                cef.FacilityOrConstruction = c.FacilityOrProjectSelection;
                cef.Pipeline = c.OccuredOnPipeline;
                if (c.Notify_911 == "Yes" || c.Media_On_Scene == "Yes" || c.Transport_ToHospital == "Yes" || c.Emegency_Responders == "Yes")
                {
                    cef.HighProfile = "True";
                }
                return View("CrestwoodSendEmail", cef);
            } catch (Exception ex)
            {
                //Write Error Message in Log
                string path = @"\\chem-fs1.ers.local\Log Files\Chemical.log";
                StreamWriter log;
                if (System.IO.File.Exists(path))
                    log = System.IO.File.AppendText(path);
                else
                    log = System.IO.File.CreateText(path);
                string mod = "SubmitCrestGenInc";
                string pfile = "CrestwoodController.cs";
                log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" +
                    "Time: " + DateTime.Now.ToShortTimeString() + "\n" +
                    "User: " + Session["username"].ToString() + "\n" +
                    "Error Message: " + ex.Message + "\n" +
                    "File: " + pfile + "\n" +
                    "Method: " + mod + "\n\n\n"
                    );
                log.Close();
                //Send Email to IT informing of new log message
                var client = new SendGridClient("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");
                var from = new EmailAddress("ers@ehs.com");
                string body = "Check the Log File!";
                string subject = "A new error log has been written.";
                var to = new List<EmailAddress>();
                to.Add(new EmailAddress("mpepitone@ehs.com"));
                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, "", body);
                client.SendEmailAsync(msg);
                //Send to Error Screen.
                return RedirectToAction("Error", "Home", new { ErrorMessage = ex.Message });
            }

        }
        public ActionResult CrestwoodSendEmail(CrestEmailForm c)
        {
            return View();
        }
        private CrestGeneralIncident GetGenIncData (FormCollection fc)
        {
            CrestGeneralIncident c = new CrestGeneralIncident();
            try
            {
                c.Caller_Name = fc["txtcallername"].ToString();
                c.Caller_Phone_Number = fc["txtcallerphonenumber"].ToString();
                c.Incident_Date = DateTime.Parse(fc["txtincidentdate"].ToString());
                c.Incident_State = fc["txtstate"].ToString();
                c.Incident_County = fc["txtcounty"].ToString();
                c.Incident_Description = fc["txtincidentdetails"].ToString();

                if (fc["IncidentType"] == "RegVisit")
                {
                    c.Agency_Ispection_Of_Visit = "TRUE";
                    c.Incident_Nature = "Regulatory Visit";
                }
                else
                {
                    c.Agency_Ispection_Of_Visit = "FALSE";
                }

                if (fc["IncidentType"] == "Fire")
                {
                    c.Fire_Or_Explosion = "TRUE";
                    c.Incident_Nature = "Fire";
                }
                else
                {
                    c.Fire_Or_Explosion = "FALSE";
                }

                if (fc["IncidentType"] == "Injury")
                {
                    c.Injury = "TRUE";
                    c.Incident_Nature = "Injury";
                }
                else
                {
                    c.Injury = "FALSE";
                }

                if (fc["IncidentType"] == "Third Party Complaint")
                {
                    c.Landowner = "TRUE";
                    c.Incident_Nature = "Third Party Complaint";
                }
                else
                {
                    c.Landowner = "FALSE";
                }

                if (fc["IncidentType"] == "Hazard")
                {
                    c.Potential_hazard_Or_Near_Miss = "TRUE";
                    c.Incident_Nature = "Hazard Report";
                }
                else
                {
                    c.Potential_hazard_Or_Near_Miss = "FALSE";
                }

                if (fc["IncidentType"] == "PropertyDamage")
                {
                    c.Property_Damage = "TRUE";
                    c.Incident_Nature = "Property Damage";
                }
                else
                {
                    c.Property_Damage = "FALSE";
                }

                if (fc["IncidentType"] == "SpillRelease")
                {
                    c.Spill_Or_Release = "TRUE";
                    c.Incident_Nature = "Spill Or Release";
                }
                else
                {
                    c.Spill_Or_Release = "FALSE";
                }

                if (fc["IncidentType"] == "Theft")
                {
                    c.Theft = "TRUE";
                    c.Incident_Nature = "Theft";
                }
                else
                {
                    c.Theft = "FALSE";
                }

                if (fc["IncidentType"] == "Vehicle Accident")
                {
                    c.Vehicle_Accident = "TRUE";
                    c.Incident_Nature = "Vehicle Accident (in motion)";
                }
                else
                {
                    c.Vehicle_Accident = "FALSE";
                }

                if (fc["IncidentType"] == "LineStrike")
                {
                    c.Pipeline_Strike = "TRUE";
                    c.Incident_Nature = "Line Strike";
                }
                else
                {
                    c.Pipeline_Strike = "FALSE";
                }

                if (fc["IncidentType"] == "illnessExposure")
                {
                    c.Other = "TRUE";
                    c.Incident_Nature = "Illness or Chemical Exposure";
                }
                else
                {
                    c.Other = "FALSE";
                }

                if (fc["IncidentType"] == "Drill")
                {
                    c.Drill = "TRUE";
                    c.Incident_Nature = "Drill or Safety System Test";
                }
                else
                {
                    c.Drill = "FALSE";
                }

                if (fc["IncidentType"] == "WPViolence")
                {
                    c.wpviolence = "TRUE";
                    c.Incident_Nature = "Workplace Violence";
                }
                else
                {
                    c.wpviolence = "FALSE";
                }

                if (fc["IncidentType"] == "SusActivity")
                {
                    c.SusAct = "TRUE";
                    c.Incident_Nature = "Suspicious Activity/Security Threat";
                }
                else
                {
                    c.SusAct = "FALSE";
                }

                c.Impacted_Areas = fc["txtimpactedareas"].ToString();
                //Private citizen nulls out these fields
                if (fc["EmpOrContract"].ToString() != "Private Citizen")
                {
                    c.Report_Taker_Name = fc["txtreporttakername"].ToString();
                    c.Report_Taker_Email = fc["txtreporttakeremail"].ToString();
                    //c.Dispatcher_Or_Employee = fc["txtdispatcheroremployee"].ToString();
                    //c.Contractor_Or_Employee = fc["txtcontractororemployee"].ToString();
                    //c.Equipment_Or_People = fc["txtequipmentorpeople"].ToString();
                }
                c.ERS_Name_1 = fc["txtersname1"].ToString();
                c.ERS_Contact_Number_1 = fc["txterscontactnumber1"].ToString();
                c.ERS_Location_1 = fc["txterslocation1"].ToString();
                c.Notify_911 = fc["txtnotify911"].ToString();
                c.Transport_ToHospital = fc["txttransportedtohospital"].ToString();
                c.Emegency_Responders = fc["txtemergencyresponders"].ToString();
                c.Media_On_Scene = fc["txtmediaonscene"].ToString();
                if (fc["txtfacilityname"].ToString() != "" && fc["txtfacilityname"] != null)
                {
                    c.Incident_Facility_Name = fc["txtfacilityname"].ToString();
                }
                c.Incident_Intersection = fc["txtincidentintersection"].ToString();
                c.Incident_City = fc["txtincidentcity"].ToString();
                c.Incident_Time = fc["txtincidenttime"].ToString();
                c.Incident_Time_Zone = fc["txtincidenttimezone"].ToString();
                c.Caller_Email = fc["txtcalleremail"].ToString();
                c.Call_Date = fc["txtcalldate"].ToString();
                c.Call_Time = fc["txtcalltime"].ToString();
                if (fc["ersop"].ToString() == "")
                {
                    c.ERS_Operator = Session["Username"].ToString();
                }
                else
                {
                    c.ERS_Operator = fc["ersop"].ToString();
                }
                if (c.Dispatcher_Or_Employee == "Yes" || c.Tractor_Trailer == "Yes")
                    c.Dispatcher_Employee = "Yes";
                else
                    c.Dispatcher_Employee = "No";
                c.Incident_Contractor_Or_Employee = fc["EmpOrContract"].ToString();
                if (fc["IndSafeTxt"].ToString() == "") { c.IndividualSafety = "N/A"; } else { c.IndividualSafety = fc["IndSafeTxt"].ToString(); }
                if (fc["ReportWeaponTxt"].ToString() == "") { c.WeaponReported = "N/A"; } else { c.WeaponReported = fc["ReportWeaponTxt"].ToString(); }
                if (fc["WeaponTypeTxt"].ToString() == "") { c.WeaponType = "N/A"; } else { c.WeaponType = fc["WeaponTypeTxt"].ToString(); }
                if (fc["TxtContractorName"].ToString() == "") { c.ContractorName = "N/A"; } else { c.ContractorName = fc["TxtContractorName"].ToString(); }
                c.FacilityOrProject = fc["ddlFacilityOrProject"].ToString();
                if (fc["TxtRegionOrFacility"] != null && fc["TxtRegionOrFacility"].ToString() != "")
                {
                    c.RegionOrFacility = fc["TxtRegionOrFacility"].ToString();
                }
                else
                {
                    c.RegionOrFacility = "N/A-refer to Incident Location Above.";
                }
                if (fc["ddlFacilityOrProjectSelection"] != null && fc["ddlFacilityOrProjectSelection"].ToString() != "")
                {
                    c.FacilityOrProjectSelection = fc["ddlFacilityOrProjectSelection"].ToString();
                }
                else
                {
                    c.FacilityOrProjectSelection = "N/A";
                }
                c.OccuredOnPipeline = fc["OccuredOnPipelineDDL"].ToString();
                c.NotificationDate = fc["NotificationDate"].ToString();
                c.NotificationTime = fc["NotificationTime"].ToString();
                if (fc["cbPC_CWLocOrTransport"] != null && fc["cbPC_CWLocOrTransport"] != "")
                {
                    c.PC_CWLocOrTransport = fc["cbPC_CWLocOrTransport"].ToString();
                }
                else
                {
                    c.PC_CWLocOrTransport = "N/A";
                }
                c.SpillOrReleaseIntoAtmo = fc["SpillOrReleaseIntoAtmo"];
                c.MaterialSpilled = fc["MaterialSpilled"].ToString();
                c.WaterbodiesImpacted = fc["WaterbodiesImpacted"];
                c.ContainedOnSite = fc["ContainedOnSite"];
                c.SpillContainedSecondary = fc["SpillContainedSecondary"];
                c.ControlDevices = fc["ControlDevices"];
                c.PrimaryWorkLocation = fc["WorkLocation"].ToString();

            } catch (Exception e)
            {
                string path = @"\\chem-fs1.ers.local\Log Files\Chemical.log";
                StreamWriter log;
                if (System.IO.File.Exists(path))
                    log = System.IO.File.AppendText(path);
                else
                    log = System.IO.File.CreateText(path);
                //string sp = " ";
                string mod = "GetGenIncData";
                string pfile = "CrestwoodController.cs";
                log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\n" + "Error Message: " + e.Message + "\n" + "File: " + pfile + "\n" + "Method: " + mod + "\n\n\n");
                log.Close();
                RedirectToAction("Error", "Home", new { ErrorMessage = e.Message});
            }
            return c;
        }
        private string CreateGenIncReport(int iid, string txtcalldate)
        {
            string yr = "";
            if (id > 0)
            {
                string[] ar = txtcalldate.Split('/');
                yr = ar[ar.Length - 1].ToString();
            }
            else
            {
                yr = DateTime.Now.Year.ToString();
            }
            //string path = @"\\chem-fs1.ers.local\completed reports\Crestwood Incidents\GeneralIncident\" + yr + "\\";
            //string oldpath = @"\\chem-fs1.ers.local\completed reports\Crestwood Incidents\GeneralIncident\" + iid.ToString() + ".pdf";
            //if (Environment.MachineName.ToLower() == "dev1")
            //{
            string path = @"\\chem-fs1.ers.local\completed reports\Crestwood Incidents\GeneralIncident\" + yr + "\\";
            string oldpath = @"\\chem-fs1.ers.local\completed reports\Crestwood Incidents\GeneralIncident\" + yr + "\\" + iid.ToString() + ".pdf";
            //}

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            ReportDocument cryRpt = new ReportDocument(); //Defines a report variable.
            int rptNum = iid; //Gets the ID from the report and stores it in a string variable.
            string rptLoadPath = @"\\chem-fs1.ers.local\Chemtel Apps\Crystal Reports\crestgeneralincidentreport1.rpt";  //This is the path to the report template.
            string outPutFilePath = path + iid.ToString() + ".pdf";  //This variable contains the path to the PDF report file.
            if (System.IO.File.Exists(oldpath))
            {
                System.IO.File.Delete(oldpath);
            }
            cryRpt.Load(rptLoadPath); //Loads the report template used to create the report.
            using (chemreporterEntities context = new chemreporterEntities())  //Initializes the Entity Model.
            {
                var query = (from obj in context.crestgeneralincidents where obj.id == rptNum select obj).ToList();  //This query will be used to retrieve the record.
                cryRpt.SetDataSource(query); //The report's data source is set to the query.  This executes the query and creats the report.
                // cryRpt.SetParameterValue(0, id); //Sets the parameter value.
                cryRpt.ExportToDisk(ExportFormatType.PortableDocFormat, outPutFilePath); //Converts the report to a PDF file.
            }
            return outPutFilePath; //Returns the path of the report to btnupdate_Click so the email form can attach it.
        }
        private int GetLatestGenIncID()
        {
            int id = 0;
            string strsql = "SELECT id FROM crestgeneralincidents";
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
            return id;
        }
        #endregion
        #region Crestwood Pipeline Incident Function
        public ActionResult PipelineReport()
        {
            //Check if user is logged in, if not, force login.
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                ViewBag.ErrorMessage = "You must login before proceeding!";
                return RedirectToAction("Index", "Home");
            }
            return View(new CrestPipelineIncident());
        }
        public ActionResult SubmitCrestPipeline(FormCollection fc)
        {
            try
            {
                CrestPipelineIncident c = new CrestPipelineIncident();
                if (fc["Revised"].ToString() != "true") // if report is new 
                {
                    c = GetPipelineData(fc);
                    Add.AddCrestPipelineIncident(Session["constring"].ToString(), c);
                    int idd = GetLatestPipelineID();  //Calls a method to get the ID of the newly added report and put it in an integer variable.
                    string filepath = CreatePipelineReport(idd, c.Call_Date);  //Calls a method to create a PDF file of the report.  It passes in the ID of the newly added report and returns the path to the PDF file.
                    System.Diagnostics.Process.Start(filepath);  //Opens the PDF file in the user's computer's default PDF viewer.
                    CrestEmailForm cef = new CrestEmailForm();
                    //Enter information to pass to the email form
                    cef.Type = "Pipeline";  //Transfers the string "Pipeline" to the Email form's public variable "type".
                    cef.Name = c.Name_1;  //Transfers the ESR member's name to the Email form's public variable "name".
                    cef.PhoneNumber = c.Contact_Number_1;  //Transfers the ESR member's phone number to the Email form's public variable "phonenumber"
                    cef.ESREmail = email;  //Transfer's the ESR member's email address to the Email form's public variable "email".
                    cef.Location = c.Location_1;  //Transfers the ESR member's location to the Email form's public variable "location".
                    cef.Drill = c.Drill;
                    string[] ar = c.Location_1.Split();  //Splits the ESR member's location into pieces and stores the pieces in an array
                    string region = ar[0].ToString();  //Takes the first element in the array and stores it in a string variable.
                    cef.Region = region;  //Transfers the ESR member's region to the Email form's public variable "region".
                    cef.ID = idd;  //Transfers the report's ID number to the email form's public variable "id".
                    cef.FilePath = filepath;  //Transfers the path to the report's PDF file to the email form's public variable "filepath".
                    return View("CrestwoodSendEmail", cef);
                } else //if report is being updated 
                {
                    c = GetPipelineData(fc); //Calls this method to get the data from the form and return it to the instance of the CrestPipelineIncident class 
                    c.ID = Int32.Parse(fc["ReportID"].ToString());  //Copies the report ID to the ID property of the instance of the CrestPipelineIncident class
                    ChemicalLibrary.Update.UpdateCrestPiplineIncident(Session["constring"].ToString(), c);  //This static method updates the report record in the database by passing in the connection string and the class instance
                    string filepath = CreatePipelineReport(c.ID, c.Call_Date);  //This method recreates the PDF file of the report by passing in the report ID.  The path to the PDF file is returned.
                    System.Diagnostics.Process.Start(filepath); //Opens the PDF file in the user's computer's default PDF viewer
                    CrestEmailForm cef = new CrestEmailForm();
                    //Enter information to pass to the email form
                    cef.Type = "Pipeline";  //Transfers the string "Pipeline" to the Email form's public variable "type".
                    cef.Name = c.Name_1;  //Transfers the ESR member's name to the Email form's public variable "name".
                    cef.PhoneNumber = c.Contact_Number_1;  //Transfers the ESR member's phone number to the Email form's public variable "phonenumber"
                    cef.ESREmail = email;  //Transfer's the ESR member's email address to the Email form's public variable "email".
                    cef.Location = c.Location_1;  //Transfers the ESR member's location to the Email form's public variable "location".
                    cef.Drill = c.Drill;
                    string[] ar = c.Location_1.Split();  //Splits the ESR member's location into pieces and stores the pieces in an array
                    string region = ar[0].ToString();  //Takes the first element in the array and stores it in a string variable.
                    cef.Region = region;  //Transfers the ESR member's region to the Email form's public variable "region".
                    cef.ID = Int32.Parse(fc["ReportID"].ToString());  //Transfers the report's ID number to the email form's public variable "id".
                    cef.FilePath = filepath;  //Transfers the path to the report's PDF file to the email form's public variable "filepath".
                    return View("CrestwoodSendEmail", cef);
                }
            }
            catch (Exception ex)
            {
                //Write Error Message in Log
                string path = @"\\chem-fs1.ers.local\Log Files\Chemical.log";
                StreamWriter log;
                if (System.IO.File.Exists(path))
                    log = System.IO.File.AppendText(path);
                else
                    log = System.IO.File.CreateText(path);
                string mod = "SubmitCrestPipeline";
                string pfile = "CrestwoodController.cs";
                log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" +
                    "Time: " + DateTime.Now.ToShortTimeString() + "\n" +
                    "User: " + Session["username"].ToString() + "\n" +
                    "Error Message: " + ex.Message + "\n" +
                    "File: " + pfile + "\n" +
                    "Method: " + mod + "\n\n\n"
                    );
                log.Close();
                //Send Email to IT informing of new log message
                var client = new SendGridClient("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");
                var from = new EmailAddress("ers@ehs.com");
                string body = "Check the Log File!";
                string subject = "A new error log has been written.";
                var to = new List<EmailAddress>();
                to.Add(new EmailAddress("mpepitone@ehs.com"));
                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, "", body);
                client.SendEmailAsync(msg);
                //Send to Error Screen.
                return RedirectToAction("Error", "Home", new { ErrorMessage = ex.Message });
            }
        }
        private CrestPipelineIncident GetPipelineData(FormCollection fc)
        {
            CrestPipelineIncident c = new CrestPipelineIncident();
            c.County = fc["txtcounty"].ToString();
            c.State = fc["txtstate"].ToString();
            c.Directions = fc["txtdirections"].ToString();
            c.Observing = fc["txtobserving"].ToString();
            if (fc["cbblackorwhitesmoke"] != null && fc["cbblackorwhitesmoke"].ToString() == "on")
            {
                c.Black_Or_White_Smoke = "TRUE";
                if (c.Seeing_Hearing_Smelling == "")
                    c.Seeing_Hearing_Smelling = "Black Or White Smoke";
                else
                    c.Seeing_Hearing_Smelling += ", " + "Black Or White Smoke";
            }
            else
                c.Black_Or_White_Smoke = "FALSE";
            if (fc["cbflames"] != null && fc["cbflames"].ToString() == "on")
            {
                c.Flames = "TRUE";
                if (c.Seeing_Hearing_Smelling == "")
                    c.Seeing_Hearing_Smelling = "Flames";
                else
                    c.Seeing_Hearing_Smelling += ", " + "Flames";
            }
            else
                c.Flames = "FALSE";
            if (fc["cbhissing"] != null && fc["cbhissing"].ToString() == "on")
            {
                c.Hissing = "TRUE";
                if (c.Seeing_Hearing_Smelling == "")
                    c.Seeing_Hearing_Smelling = "Hissing";
                else
                    c.Seeing_Hearing_Smelling += ", " + "Hissing";
            }
            else
                c.Hissing = "FALSE";
            if (fc["cbliquid"] != null && fc["cbliquid"].ToString() == "on")
            {
                c.Liquid = "TRUE";
                if (c.Seeing_Hearing_Smelling == "")
                    c.Seeing_Hearing_Smelling = "Liquid";
                else
                    c.Seeing_Hearing_Smelling += ", " + "Liquid";
            }
            else
                c.Liquid = "FALSE";
            if (fc["cboilysheen"] != null && fc["cboilysheen"].ToString() == "on")
            {
                c.Oily_Sheen = "TRUE";
                if (c.Seeing_Hearing_Smelling == "")
                    c.Seeing_Hearing_Smelling = "Oily Sheen";
                else
                    c.Seeing_Hearing_Smelling += ", " + "Oily Sheen";
            }
            else
                c.Oily_Sheen = "FALSE";
            if (fc["cbotherpipelinemarkers"] != null && fc["cbotherpipelinemarkers"].ToString() == "on")
            {
                c.Other_Pipeline_Markers = "TRUE";
                if (c.Seeing_Hearing_Smelling == "")
                    c.Seeing_Hearing_Smelling = "Other Pipeline Markers";
                else
                    c.Seeing_Hearing_Smelling += ", " + "Other Pipeline Markers";
            }
            else
                c.Other_Pipeline_Markers = "FALSE";
            if (fc["cbrotteneggodor"] != null && fc["cbrotteneggodor"].ToString() == "on")
            {
                c.Rotten_Egg_Odor = "TRUE";
                if (c.Seeing_Hearing_Smelling == "")
                    c.Seeing_Hearing_Smelling = "Rotten Egg Odor";
                else
                    c.Seeing_Hearing_Smelling += ", " + "Rotten Egg Odor";
            }
            else
                c.Rotten_Egg_Odor = "FALSE";
            if (fc["cbvaporsormist"] != null && fc["cbvaporsormist"].ToString() == "on")
            {
                c.Vapor_Or_Mist = "TRUE";
                if (c.Seeing_Hearing_Smelling == "")
                    c.Seeing_Hearing_Smelling = "Vapor Or Mist";
                else
                    c.Seeing_Hearing_Smelling += ", " + "Vapor Or Mist";
            }
            else
                c.Vapor_Or_Mist = "FALSE";
            if (c.Seeing_Hearing_Smelling == "")
                c.Seeing_Hearing_Smelling = "N/A";
            c.ROW_OR_Well_Pad = fc["txtroeworwellpad"].ToString();
            c.Tanks = fc["txttanks"].ToString();
            c.Landowner = fc["txtlandowner"].ToString();
            c.Caller_Name = fc["txtcallername"].ToString();
            c.Caller_Phone = fc["txtcallerphone"].ToString();
            c.Notify_911 = fc["txtnotify911"].ToString(); 
            c.Anyone_Injured = fc["txtanyoneinjured"].ToString();
            c.Immediate_Danger = fc["txtimmediatedanger"].ToString();
            c.Relation_ToIncident = fc["txtrelationtoincident"].ToString();
            c.Safely_Warn = fc["txtsafelywarn"].ToString();
            c.Temperature = fc["txttemp"].ToString();
            c.Wind_Speed = fc["txtwindspeed"].ToString();
            c.Wind_Direction = fc["txtwinddirection"].ToString();
            c.Weather_Conditions = fc["txtweatherconditions"].ToString();
            c.Name_1 = fc["txtname1"].ToString();
            c.Name_2 = "";
            c.Name_3 = "";
            c.Contact_Number_1 = fc["txtcontactnumber1"].ToString();
            c.Contact_Number_2 = "";
            c.Contact_Number_3 = "";
            c.Location_1 = fc["txtlocation1"].ToString();
            c.Location_2 = "";
            c.Location_3 = "";
            c.Lease_Well_Name = fc["txtleasewellname"].ToString();
            c.Distance_From_Landmark = "";
            c.Distance_From_Town = "";
            c.Intersection_Or_Milemarker = "";
            c.Directions = fc["txtdirections"].ToString();
            c.City = fc["txtcity"].ToString();
            c.Date = fc["txtdate"].ToString();
            c.Time = fc["txttime"].ToString();
            c.Time_Zone = fc["txttimezone"].ToString();
            //c.Number_Of_Injuries = 0;
            c.Number_Of_Injuries = int.Parse(fc["txtnumofinjuries"].ToString());
            c.Report_Taker_Name = fc["txtreporttakername"].ToString();
            c.Report_Taker_Email = fc["txtreporttakeremail"].ToString();
            c.Description = "";
            c.Caller_Email = fc["txtcalleremail"].ToString();
            c.Caller_Affiliation = "";
            c.Caller_Title = "";
            c.Name_4 = "";
            c.Name_5 = "";
            c.Contact_Number_4 = "";
            c.Contact_Number_5 = "";
            c.Location_4 = "";
            c.Location_5 = "";
            c.Call_Date = fc["txtcalldate"].ToString();
            c.Call_Time = fc["txtcalltime"].ToString();
            c.ERS_Operator = System.Environment.UserName;
            c.NotificationDate = fc["NotificationDate"].ToString();
            c.NotificationTime = fc["NotificationTime"].ToString();
            if (initials != "")
                c.Initials = initials;
            else
                c.Initials = "";
            c.Drill = fc["cbDrill"].ToString();
            return c;
        }
        private void GetPipelineRecord() //Gets record data for searching for old reports.
        {
            //CrestPipelineIncident c = new CrestPipelineIncident(Session["constring"].ToString(), id);
            //TxtReportLogID.Text = ReportLogs.InsertStartLog(id.ToString(), "CrestPipline", c.ERS_Operator, 1, constring).ToString();
            //txtcounty.Text = c.County;
            //txtstate.Text = c.State;
            //txtdirections.Text = c.Directions;
            //txtobserving.Text = c.Observing;
            //if (c.Black_Or_White_Smoke == "TRUE")
            //    cbblackorwhitesmoke.Checked = true;
            //if (c.Flames == "TRUE")
            //    cbflames.Checked = true;
            //if (c.Hissing == "TRUE")
            //    cbhissing.Checked = true;
            //if (c.Liquid == "TRUE")
            //    cbliquid.Checked = true;
            //if (c.Oily_Sheen == "TRUE")
            //    cboilysheen.Checked = true;
            //if (c.Other_Pipeline_Markers == "TRUE")
            //    cbotherpipelinemarkers.Checked = true;
            //if (c.Rotten_Egg_Odor == "TRUE")
            //    cbrotteneggodor.Checked = true;
            //if (c.Vapor_Or_Mist == "TRUE")
            //    cbvaporsormist.Checked = true;
            //txtroeworwellpad.Text = c.ROW_OR_Well_Pad;
            //txttanks.Text = c.Tanks;
            //txtlandowner.Text = c.Landowner;
            //txtcallername.Text = c.Caller_Name;
            //txtcalleremail.Text = c.Caller_Email;
            //txtcallerphone.Text = c.Caller_Phone;
            //txtnotify911.Text = c.Notify_911;
            //txtanyoneinjured.Text = c.Anyone_Injured;
            //txtimmediatedanger.Text = c.Immediate_Danger;
            //txtrelationtoincident.Text = c.Relation_ToIncident;
            //txtsafelywarn.Text = c.Safely_Warn;
            //txttemp.Text = c.Temperature;
            //txtwindspeed.Text = c.Wind_Speed;
            //txtwinddirection.Text = c.Wind_Direction;
            //txtweatherconditions.Text = c.Weather_Conditions;
            //txtname1.Text = c.Name_1;
            //CrestERS e = new CrestERS(Session["constring"].ToString(), txtname1.Text);
            //email = e.Email;
            //txtname2.Text = c.Name_2;
            //txtname3.Text = c.Name_3;
            //txtcontactnumber1.Text = c.Contact_Number_1;
            //txtcontactnumber2.Text = c.Contact_Number_2;
            //txtcontactnumber3.Text = c.Contact_Number_3;
            //txtlocation1.Text = c.Location_1;
            //txtlocation2.Text = c.Location_2;
            //txtlocation3.Text = c.Location_3;
            //txtleasewellname.Text = c.Lease_Well_Name;
            //txtdirections.Text = c.Directions;
            //txtcity.Text = c.City;
            //txtdate.Text = c.Date.ToString("MM/dd/yyyy");
            //txttime.Text = c.Time;
            //txttimezone.Text = c.Time_Zone;
            //txtnumofinjuries.Text = c.Number_Of_Injuries.ToString();
            //txtreporttakername.Text = c.Report_Taker_Name;
            //txtreporttakeremail.Text = c.Report_Taker_Email;
            //txtdescription.Text = c.Description;
            //txtname4.Text = c.Name_4;
            //txtname5.Text = c.Name_5;
            //txtcontactnumber4.Text = c.Contact_Number_4;
            //txtcontactnumber5.Text = c.Contact_Number_5;
            //txtlocation4.Text = c.Location_4;
            //txtlocation5.Text = c.Location_5;
            //NotificationDate.Text = c.NotificationDate;
            //NotificationTime.Text = c.NotificationTime;
            //if (c.Call_Date == "")
            //    txtcalldate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            //else
            //    txtcalldate.Text = c.Call_Date;
            //if (c.Call_Time == "")
            //    txtcalltime.Text = DateTime.Now.ToString("HHmm");
            //else
            //    txtcalltime.Text = c.Call_Time;
            //initials = c.Initials;
            //if (c.Drill == "Yes")
            //{
            //    cbDrill.SelectedIndex = 0;
            //}
            //else if (c.Drill == "No")
            //{
            //    cbDrill.SelectedIndex = 1;
            //}
            //else
            //{
            //    cbDrill.SelectedIndex = -1;
            //}
        }
        private int GetLatestPipelineID()
        {
            int id = 0;
            string strsql = "SELECT TOP 1 id FROM crestpiplineincidents ORDER BY ID DESC";
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
        private string CreatePipelineReport(int iid, string calldate)
        {
            try
            {
                string yr = "";
                if (id > 0)
                {
                    string[] ar = calldate.Split('/');
                    yr = ar[ar.Length - 1].ToString();
                }
                else
                {
                    yr = DateTime.Now.Year.ToString();
                }
                string path = @"\\chem-fs1.ers.local\completed reports\Crestwood Incidents\Pipeline\" + yr + "\\";
                string oldpath = @"\\chem-fs1.ers.local\completed reports\Crestwood Incidents\Pipeline\" + yr + "\\" + iid.ToString() + ".pdf";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                ReportDocument cryRpt = new ReportDocument(); //Defines a report variable.
                int rptNum = iid; //Gets the ID from the report and stores it in a string variable.
                string rptLoadPath = @"\\chem-fs1.ers.local\Chemtel Apps\Crystal Reports\crestpipelinereport1.rpt";  //This is the path to the report template.
                string outPutFilePath = path + iid.ToString() + ".pdf"; //Sets the path to the PDF file
                if (System.IO.File.Exists(oldpath))
                {
                    System.IO.File.Delete(oldpath);
                }
                cryRpt.Load(rptLoadPath); //Loads the report template used to create the report.
                using (chemreporterEntities context = new chemreporterEntities())  //Initializes the Entity Model.
                {
                    var query = (from obj in context.crestpiplineincidents where obj.id == rptNum select obj).ToList();  //This query will be used to retrieve the record.
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

                var smtpCreds = new System.Net.NetworkCredential(@"CHEMTEL\emergency", "ERS*33602");
                SmtpClient smtp = new SmtpClient("mail.chemtelinc.com", 587);
                MailAddress from = new MailAddress("ers@ehs.com");
                MailAddressCollection to = new MailAddressCollection();
                MailMessage message = new MailMessage();
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = smtpCreds;
                string msg = "Check the log file!\n" + ex.Message;
                string subject = "Chemical Report Manager Error";
                to.Add("mpepitone@ehs.com");
                message.To.Add(to.ToString());
                message.From = from;
                message.Subject = subject;
                message.Body = msg;
                smtp.Send(message);
                return "false";
            }
        }

        [HttpGet]
        public JsonResult SearchByContactName(string contactName, string contactState, string contactCounty)
        {
            string strsql = "SELECT * FROM crestpipelinemembers WHERE contactname=@con AND state=@st AND county=@co";
            string contactphone = "";
            using (SqlConnection cn = new SqlConnection(Session["constring"].ToString()))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@con", contactName);
                    cmd.Parameters.AddWithValue("@st", contactState);
                    cmd.Parameters.AddWithValue("@co", contactCounty);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        contactphone = rdr["phone"].ToString();
                    }
                }
            }
            return Json(contactphone, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetPipelinePhoneList(string State, string County)
        {
            string NamesList = Utilities.GetDirector(Session["constring"].ToString(), State, County);
            string WindowContent = "";
            string Phone_Number = "";
            if (NamesList.Length > 0)
            {
                NamesList = NamesList.Substring(0, NamesList.Length - 1);
                string[] Names = NamesList.Split(':');
                WindowContent = "Please call ";
                foreach (string n in Names)
                {
                    string[] ar = n.Split('_');
                    NamesList = ar[0].ToString();
                    Phone_Number = ar[1].ToString();
                    WindowContent += "\n\n" + NamesList + " at " + Phone_Number;
                }
            }
            return Json(new { PhoneList = WindowContent }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region Crestwood Locked Gate Functions
        public ActionResult LockedGateReport()
        {
            //Check if user is logged in, if not, force login.
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                ViewBag.ErrorMessage = "You must login before proceeding!";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Names = Search.GetNames(Session["constring"].ToString());
            return View();
        }
        public ActionResult SubmitLockedGateReport(FormCollection fc)
        {
            Crest811 c = new Crest811();
            c = GetLGData(fc);
            Add.AddCrest811(Session["constring"].ToString(), c);
            return RedirectToAction("LockedGateReport", new {Result = "Success"});
        }
        //Get on call ERS member's names

        private Crest811 GetLGData(FormCollection fc)
        {
            //separate Name and ID.
            var NameID = fc["txtname"].Split('_');
            string txtname = NameID[0];

            Crest811 c = new Crest811();
            c.Today_Date = DateTime.Now.ToShortDateString();
            c.Today_Time = DateTime.Now.ToString("HH:mm");
            c.State = fc["txtstate"].ToString();
            c.County = fc["txtcounty"].ToString();
            c.Caller_Name = fc["txtcallername"].ToString();
            c.Caller_Number = fc["txtcallernumber"].ToString();
            c.Name = txtname;
            c.Contact_Number = fc["txtcontactnumber"].ToString();
            c.Location = fc["txtlocation"].ToString();
            c.FacilityName = fc["FacilityName"].ToString();
            return c;
        }
        //Get ERS member's phone and location
        public JsonResult SearchByID(int ID)
        {
            string strsql = "SELECT * FROM cresters WHERE id=@id";
            string PhoneAndLocation = "";

            using (SqlConnection cn = new SqlConnection(Session["constring"].ToString()))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        PhoneAndLocation = rdr["phone"].ToString() + "_" + rdr["location"].ToString() + "_" + rdr["email"].ToString();
                    }
                }
            }
            return Json(PhoneAndLocation, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmailAddress(string name)
        {
            string email = "";
            string strsql = "SELECT email FROM cresters WHERE name=@n";
            using (SqlConnection cn = new SqlConnection(Session["constring"].ToString()))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                        email = rdr[0].ToString();
                }
            }
            return Json(email, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 811 Report Functions
        public ActionResult EightOneOneReport()
        {
            string date = DateTime.Now.ToShortDateString(); //Gets the current date.
            string time = DateTime.Now.ToString("HHmm"); //Gets the current time in military timw.
            CalculateTime(time);  //This method converts the current time into central time.
            int hr = int.Parse(time.Substring(0, 2));
            if (hr == 0)
                date = DateTime.Now.AddDays(-1).ToShortDateString();
            else
                date = DateTime.Now.ToShortDateString();
            ViewBag.txtreportdate = date;
            //Check if user is logged in, if not, force login.
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                ViewBag.ErrorMessage = "You must login before proceeding!";
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult Submit811Report(FormCollection fc)
        {
            Crest811 c = new Crest811();
            c = Get811Data(fc);
            Add.AddCrest811(Session["constring"].ToString(), c);
            return RedirectToAction("EightOneOneReport", new { Result = "Success" });
        }
        private Crest811 Get811Data(FormCollection fc)
        {
            Crest811 c = new Crest811();
            c.Today_Date = DateTime.Now.ToShortDateString();
            c.Today_Time = DateTime.Now.ToString("HH:mm");
            c.Excavation_Date = fc["txtexcavationdate"].ToString();
            c.Excavation_Time = fc["txtexcavationtime"].ToString();
            c.Normal_Or_Emergency = fc["txtnormaloremergency"].ToString();
            c.Request_Ticket_Number = fc["txtrequestticketnumber"].ToString();
            c.Person_Company_Name = fc["txtpersoncompanyname"].ToString();
            c.Callback_Number = fc["txtcallbacknumber"].ToString();
            c.Email_Address = fc["txtemailaddress"].ToString();
            c.City = fc["txtcity"].ToString();
            c.State = fc["txtstate"].ToString();
            c.County = fc["txtcounty"].ToString();
            c.Street = fc["txtstreet"].ToString();
            c.Intersection = fc["txtintersection"].ToString();
            c.Nature = fc["txtnature"].ToString();
            c.Remarks = fc["txtremarks"].ToString();
            return c;
        }
        public string GetNotifications(string txtstate, string txtcounty)
        {
            string lblresult = "";
            string strsql = "SELECT * FROM crestpipelinemembers WHERE state=@s AND county=@c ORDER BY contact";
            using (SqlConnection cn = new SqlConnection(Session["constring"].ToString()))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@s", txtstate);
                    cmd.Parameters.AddWithValue("@c", txtcounty);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string name = rdr["contactname"].ToString();
                        string phone = rdr["phone"].ToString();
                        if (lblresult == "")
                        {
                            lblresult = "Please call " + name + " at " + phone + "\n";
                        }
                        else
                        {
                            lblresult += name + " at " + phone + "\n";
                        }
                    }
                }
            }
            return lblresult;
        }
        #endregion
        #region Crestwood Email Functions          
        //this will be an ajax call for when the email form loads
        //Ajax call for formatted Gen Inc emails
        [HttpGet]
        public JsonResult GetGeneralIncidentRecord(int id)
        {
            CrestGeneralIncident c = new CrestGeneralIncident(Session["constring"].ToString(), id);
            string txtemailto = GetAllNotificationEmails();
            txtemailto = txtemailto.Trim(',');
            string subject = FomatSubject(c.Call_Date, c.Incident_State, c.Incident_Nature);
            string body = FormatGeneralIncidentBody(c);
            return Json(new { txtemailto = txtemailto, subject = subject, body = body }, JsonRequestBehavior.AllowGet);
        }
        private string GetAllNotificationEmails()
        {
            string emaillist = "";
            List<string> emails = new List<string>();
            emails = Search.GetAllNotificationEmails(Session["constring"].ToString());
            foreach (string email in emails)
            {
                emaillist += "," + email;
            }
            return emaillist;
        }
        private string FomatSubject(string date, string state, string natureofincident)
        {
            string subject = "";
            string subjectdate = FormatSubjectDate(date);
            subject = "Hotline Notification " + subjectdate + ": " + state + ", " + natureofincident;
            return subject;
        }
        private string FormatSubjectDate(string date)
        {
            string subjectdate = "";
            string[] ar = DateTime.Parse(date).ToString("MM/dd/yyyy").Split('/');
            string month = ar[0];
            string day = ar[1];
            string year = ar[2];
            subjectdate = year + month + day;
            return subjectdate;
        }
        private string FormatGeneralIncidentBody(CrestGeneralIncident c)
        {
            string body = "Incident Category: " + c.Incident_Nature + "<br/><br/>The HSER emergency hotline was notified at " + c.Call_Time + " EST" + " on " + c.Call_Date + ". ";
            if (drill == "true")
            {
                body = body + "A DRILL OR SAFETY SYSTEM TEST OCCURRED. Scenario: ";
            }
            body = body + c.Incident_Description + "  This occurred at/on " + c.Incident_Intersection + " in/near " + c.Incident_City + ", " + c.Incident_State + " at " + c.Incident_Time + " " + c.Incident_Time_Zone + " on " + c.Incident_Date.ToString("MM/dd/yyyy") + ".  ";


            if (c.Spill_Or_Release == "FALSE")
            {
                body += "There was no reported release.  ";
            }
            else
            {
                body += "A release was reported.  ";
            }
            body += "An incident report will be initiated in the Enviance System and assigned to " + c.Report_Taker_Name + ".  Please access system to review for accuracy and update report with any additional supporting documentation by EOB ";
            string dayofweek = DateTime.Now.DayOfWeek.ToString();
            if (dayofweek == "Monday")
                dayofweek = "Tuesday";
            else if (dayofweek == "Tuesday")
                dayofweek = "Wednesday";
            else if (dayofweek == "Wednesday")
                dayofweek = "Thursday";
            else if (dayofweek == "Thursday")
                dayofweek = "Friday";
            else if (dayofweek == "Friday")
                dayofweek = "Monday";
            body += dayofweek + ".";
            body += "\r\n\r\nLink to system: <a href=\"https://www.enviance.com/customerlogin/customerlogin.aspx\">Enviance</a> ";
            body += "<br/><br/> To report errors in this notification text, distribution recipients, omissions, or others concerns, please the click link to <a href='mailto:dana.chapman@crestwoodlp.com?subject=feedback alert: VelocityEHS notification'>submit to your internal admin</a>.";
            return body;
        }
        //Ajax call for formatted Pipeline emails
        [HttpGet]
        public JsonResult GetPipelineIncidentRecord(int id)
        {
            CrestPipelineIncident c = new CrestPipelineIncident(Session["constring"].ToString(), id);
            string txtemailto = GetAllNotificationEmails();
            txtemailto += ",AssetType-Pipeline@crestwoodlp.com";
            string subject = "Hotline Notification:  Pipeline Incident on " + c.Call_Date + " at approximately " + c.Call_Time + " " + "EST" + "at " + c.City + ", " + c.State + " in " + c.County + " county";
            string body = FormatPipelineIncidentBody(c);
            return Json(new { txtemailto = txtemailto, subject = subject, body = body }, JsonRequestBehavior.AllowGet);
        }
        private string FormatPipelineIncidentBody(CrestPipelineIncident c)
        {
            string body = "";
            if (drill == "Yes")
            {
                body += "DRILL/PROTOCOL TEST <br/><br/>";
            }
            body += "<b>What is your location? </b> " + c.City + ", " + c.State + ", " + c.County + " county <br/><br/>";
            body += "<b>What are you observing right now?</b> " + c.Observing + "<br/><br/>";
            body += "<b>What are you seeing, hearing or smelling?</b> ";
            if (c.Hissing == "TRUE")
                body += "Hissing ";
            if (c.Black_Or_White_Smoke == "TRUE")
                body += "Black or White Smoke ";
            if (c.Flames == "TRUE")
                body += "Flames ";
            if (c.Liquid == "TRUE")
                body += "Liquid ";
            if (c.Rotten_Egg_Odor == "TRUE")
                body += "Rotten Egg Odor ";
            if (c.Other_Pipeline_Markers == "TRUE")
                body += "Other Pipeline Markers ";
            if (c.Oily_Sheen == "TRUE")
                body += "Oily Sheen ";
            if (c.Vapor_Or_Mist == "TRUE")
                body += "Vapor or Mist ";
            body += "<br/><br/>";
            body += "<b>Can you tell from your location if this is occuring on a pipeline ROW or a Well-pad location?</b> ";
            body += c.ROW_OR_Well_Pad + "<br/><br/>";
            body += "<b>Do you see ANY tanks near or at the location where this incident is occuring?</b> " + c.Tanks + "<br/><br/>";
            body += "<b>Are you the landowner?</b> " + c.Landowner + "<br/><br/>";
            body += "<b>What is the Lease/Well Name?</b> " + c.Lease_Well_Name + "<br/><br/>";
            body += "<b>What is your name?</b> " + c.Caller_Name + "<br/>";
            body += "<b>What is the phone number you are calling from?</b> " + c.Caller_Phone + "<br/><br/>";
            body += "<b>Have you already contacted 9-1-1?</b> " + c.Notify_911 + "<br/>";
            body += "<b>Is anyone injured or needing medical assistance?</b> " + c.Anyone_Injured + "<br/><br/>";
            body += "<b>Can you tell if anyone is in immediate danger?</b> " + c.Immediate_Danger + "<br/><br/>";
            body += "<b>Where are they in relation to the incident?</b> " + c.Relation_ToIncident + "<br/><br/>";
            body += "<b>Can you safely warn them to stay away from the incident?</b> " + c.Safely_Warn + "<br/><br/>";
            body += "<br/><br/><br/> To report errors in this notification text, distribution recipients, omissions, or others concerns, please the click link to <a href='mailto:dana.chapman@crestwoodlp.com?subject=feedback alert: VelocityEHS notification'>submit to your internal admin</a>.";
            return body;
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SendCrestwoodEmail(FormCollection fc)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("ers@ehs.com");
            string emaillist = fc["txtemailto"].ToString();
            string[] emails = fc["txtemailto"].ToString().Split(',');
            string body = fc["txtemailbody"].ToString();
            
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
            //Attach Saved PDF to email
            var filename = Path.GetFileName(fc["txtemailattachment"].ToString());
            var bytes = System.IO.File.ReadAllBytes(fc["txtemailattachment"].ToString()); //Get Attachment Bytes
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment(filename, file); //Add Attachment to email.
            var response = client.SendEmailAsync(msg);

            string path = @"\\chem-fs1.ers.local\Log Files\CRMEmails.log";
            StreamWriter log;
            if (System.IO.File.Exists(path))
                log = System.IO.File.AppendText(path);
            else
                log = System.IO.File.CreateText(path);
            log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\n" + "ReportType: Crestwood \n Message: " + response.Result.StatusCode + "\n" + "\n\n\n");
            log.Close();

            string ResultCode = response.Result.StatusCode.ToString();

            return RedirectToAction("Index", "Home", new { Result = ResultCode });
        }
        #endregion
        #region Manager Tab
        #region HSER MEMBERS
        public ActionResult HSERMembers()
        {
            return View();
        }
        public JsonResult HSERMemberInfo(string id)
        {
            string sdate = "";
            string edate = "";
            string phone = "";
            string email = "";
            string strsql = "SELECT * FROM cresters WHERE id=@id ORDER BY name ASC";
            using (SqlConnection cn = new SqlConnection(Session["constring"].ToString()))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        sdate = rdr["startdate"].ToString();
                        edate = rdr["enddate"].ToString();
                        phone = rdr["phone"].ToString();
                        email = rdr["email"].ToString();
                    }
                }
            }
            return Json(new { StartDate = sdate, EndDate = edate, Phone = phone, Email = email }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateHSERInfo(int ID, string StartDate, string EndDate, string Name, string Phone, string Email, string Location, string ButtonType)
        {
            CrestERS c = new CrestERS();
            c.ID = ID;
            c.Start_Date = DateTime.Parse(StartDate + " 9:00");
            c.End_Date = DateTime.Parse(EndDate + " 09:00");
            c.Name = Name;
            c.Phone = Phone;
            c.Email = Email;
            c.Location = Location;

            if (ButtonType == "Add") {
                c.ID = 0;
                Add.AddCrestERS(Session["constring"].ToString(), c);  //Calls a static method to add the name to the database.  Passes in the connection string and the class instance.
            }
            else if (ButtonType == "Update") { 
                c.ID = ID;
                Update.UpdateCrestERS(Session["constring"].ToString(), c);  //Calls a static method to update the record in the database.  Passes in the connection string and the class instance.
            }
            else if (ButtonType == "Delete")
            {
                c.ID = ID;
                Delete.DeleteCrestERS(Session["constring"].ToString(), c);  //Calls a static method to delete the record from the database.  Passes in the connection string and the class instance.
            }
            return Json(new { success="Success" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region PIPELINE MEMBERS
        public ActionResult PipelineMembers()
        {
            return View();
        }
        public JsonResult PipelineMemberInfo(int ID)
        {
            CrestPipelineMember c = new CrestPipelineMember(Session["constring"].ToString(), ID);

            return Json(new { OperatorName=c.Operator_Name, State=c.State, County=c.County, ConName=c.Contact_Name, Phone=c.Phone, Contact=c.Contact, ID=c.ID }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdatePipelineMembers(int ID, string OpName, string State, string County, string ConName, string Phone, int ConOrder, string BtnType)
        {
            CrestPipelineMember c = new CrestPipelineMember();
            c.Operator_Name=OpName;
            c.State=State;
            c.County=County;
            c.Contact_Name=ConName;
            c.Phone=Phone;
            c.Contact = ConOrder;
            if (BtnType == "Add") {
                c.ID=0;
                Add.AddCrestPipelineMember(Session["constring"].ToString(), c);
            }
            else if (BtnType == "Update") { 
                c.ID=ID;
                Update.UpdateCrestPipelineMember(Session["constring"].ToString(), c);
            }
            else if (BtnType == "Delete") { 
                c.ID=ID;
                Delete.DeleteCrestPipelineMember(Session["constring"].ToString(), c);
            }
            return Json(new { success="Success" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region TRANSPORTATION LIST
        public ActionResult TransportList()
        {
            return View();
        }
        public JsonResult TransportInfo(string name)
        {
            CrestwoodTransportation c = new CrestwoodTransportation(Session["constring"].ToString(), name);

            return Json(new { ID = c.ID, Name = c.Name, Email = c.Email, Indiana = c.Indiana, NewJersey=c.NewJersey, WestVirginia=c.WestVirginia}, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateTransport(int ID, string Name, string Email, int Indiana, int NewJersey, int WestVirginia, string btnType)
        {
            CrestwoodTransportation c = new CrestwoodTransportation();
            c.Name = Name;
            c.Email = Email;
            c.Indiana = Indiana;
            c.NewJersey = NewJersey;
            c.WestVirginia = WestVirginia;
            if (btnType == "Add")
            {
                c.ID = 0;
                Add.AddCrestwoosTransportationList(Session["constring"].ToString(), c);
            } else if (btnType == "Update")
            {
                c.ID = ID;
                Update.UpdateCrestwoodTransportationList(Session["constring"].ToString(), c);
            } else if (btnType == "Delete")
            {
                c.ID = ID;
                Delete.DeleteCrestwoodTransportationList(Session["constring"].ToString(), c);
            }
            return Json(new { success="Success" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region ALL NOTIFICATIONS
        public ActionResult AllNotifications()
        {
            return View();
        }
        public JsonResult AllNotificationsInfo(string name)
        {
            CrestAllNotifications c = new CrestAllNotifications(Session["constring"].ToString(), name);

            return Json(new { ID = c.ID, Name = c.Name, Email = c.Email }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateAllNotificationMembers(int ID, string Name, string Email, string btnType)
        {
            CrestAllNotifications c = new CrestAllNotifications();
            c.Name = Name;
            c.Email = Email;
            if (btnType == "Add")
            {
                c.ID = 0;
                Add.AddCrestAllNotifications(Session["constring"].ToString(), c);
            }
            else if (btnType == "Update")
            {
                c.ID = ID;
                Update.UpdateCrestwoodAllNotifications(Session["constring"].ToString(), c);
            }
            else if (btnType == "Delete")
            {
                c.ID = ID;
                Delete.DeleteCrestwoodAllNotifications(Session["constring"].ToString(), c);
            }
            return Json(new { success = "Success" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #endregion
        #region Miscellaneous Functions

        public JsonResult GetPipelineNames(string state, string county)
        {
            string names = "";
            string strsql = "SELECT DISTINCT contactname FROM crestpipelinemembers WHERE state=@s AND county=@c ORDER BY contactname";
            using (SqlConnection cn = new SqlConnection(Session["constring"].ToString()))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@s", state);
                    cmd.Parameters.AddWithValue("@c", county);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        names += rdr["contactname"].ToString() + ",";
                    }
                }
            }
            return Json(names.Trim(','), JsonRequestBehavior.AllowGet);
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
        #endregion
    }
}