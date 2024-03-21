using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChemicalLibrary;

namespace crm.chemtelinc.com.Controllers
{
    public class NorthwindController : Controller
    {
        // GET: Northwind
        #region Get Views
        public ActionResult GeneralIncident()
        {

            return View(new NorthwindGenInc());
        }

        public ActionResult Pipeline()
        {
            return View();
        }

        public ActionResult EmailForm(NorthwindEmail n)
        {
            return View(n);
        }
        #endregion

        #region Form Submissions
        public ActionResult SubmitNewReport(FormCollection fc)
        {
            NorthwindGenInc ngi = new NorthwindGenInc();
            ngi = GetData(fc);
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

        public ActionResult SendEmail()
        {
            return RedirectToAction("Index", "Home", new { Result = "Accepted" });
        }
        #endregion

        private NorthwindGenInc GetData(FormCollection fc)
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

            //if (n.IncidentNature == "Workplace Violence") { n.wpviolence = "TRUE"; }
            //if (n.IncidentNature == "Third Party Complaint") { n.TPComplaint = "TRUE"; }
            //if (n.IncidentNature == "Vehicle Accident") { n.Vehicle_Accident = "TRUE"; }
            //if (n.IncidentNature == "Spill Or Release") { n.Spill_Or_Release = "TRUE"; }
            //if (n.IncidentNature == "Injury") { n.Injury = "TRUE"; }
            //if (n.IncidentNature == "Illness or Chemical Exposure") { n.Illness_Or_Exposure = "TRUE"; }
            //if (n.IncidentNature == "Fire") { n.Fire = "TRUE"; }
            //if (n.IncidentNature == "Line Strike") { n.Pipeline_Strike = "TRUE"; }
            //if (n.IncidentNature == "Property Damage") { n.Property_Damage = "TRUE"; }
            //if (n.IncidentNature == "Theft") { n.Theft = "TRUE"; }
            //if (n.IncidentNature == "Reg. Visit") { n.RegVisit = "TRUE"; }
            //if (n.IncidentNature == "Drill or Safety System Test") { n.Hazard = "TRUE"; }
            //if (n.IncidentNature == "Hazard Report/Near Miss") { n.Drill = "TRUE"; }

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


    }
}