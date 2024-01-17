using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ChemicalLibrary;
using crm.chemtelinc.com.Models;
using CrystalDecisions.Shared;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace crm.chemtelinc.com.Controllers
{
    public class TCEQController : Controller
    {
        public string constring = Properties.Settings.Default.chemicalConnectionString; //Class-level variable containg the connection string to the database.
        public string constringTest = Properties.Settings.Default.chemicalTestConnectionString; //Class-level variable containg the connection string to the database.
        string AttachedPath = "";
        public string IDRevise = "";
        bool submitted = false;
        bool updated = false;
        bool cancel = false;

        #region Load TCEQ Report
        public ActionResult TCEQReport()
        {
            //Check if user is logged in, if not, force login.
            if (Session["Username"] == null || Session["Username"].ToString() == "")
            {
                return RedirectToAction("Index", "Home", new { e = "You must login before proceeding!" });
            }
            //Get new Report ID
            int NewID = LastID();
            NewID = NewID + 1;
            ViewBag.NewID = NewID.ToString();

            //Get county list for dropdown
            List<string> Counties = new List<string>();
            Counties = CountyListNames();
            ViewBag.Counties = Counties;
            return View();
        }
        private int LastID()
        {
            int IDReport = 0;
            string strsql = "SELECT id FROM tceqreport ORDER BY id DESC";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        IDReport = int.Parse(rdr["id"].ToString());
                        break;
                    }
                }
            }
            return IDReport;
        }
        private List<string> CountyListNames()
        {
            List<string> C = new List<string>();
            string strsql = "SELECT countyName FROM glocountylist";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        C.Add(rdr[0].ToString());
                    }
                }
                if (C.Count == 0)
                {
                    C.Add("no county names found");
                }
            }
            return C;
        }
        #endregion
        #region Submit TCEQ Report
        public ActionResult SubmitTCEQReport(FormCollection fc)
        {
            TCEQ T = GetData(fc);
            if (fc["btnsubmit"].ToString() == "Update")
            {
                if (Update.UpdateTCEQ(constring, T))
                {
                    int ID = T.ID_TCEQ;
                    if (FillDataSet(ID))
                    {
                        submitted = true;
                    }
                }
            } else
            {
                if (Add.AddTCEQ(constring, T))
                {
                    int ID = this.LastID();
                    if (FillDataSet(ID))
                    {
                        submitted = true;
                    }
                }
            }
            TCEQEmailContact tef = new TCEQEmailContact();
            tef.ID = fc["TBIDReport"];
            tef.Reqion = fc["TBRegion"].ToString();
            tef.FilePath = AttachedPath;
            tef.FileViewPath = "https://crm.chemtel.net/Completed Reports/TCEQ/2023/TCEQ-" + fc["TBIDReport"].ToString() + ".pdf";
            tef.County = fc["CBCounty"].ToString();
            return View("TCEQEmailForm", tef);
        }
        private TCEQ GetData(FormCollection fc)
        {
            TCEQ t = new TCEQ();
            if (fc["TBIDReport"].ToString() != "")
            {
                t.ID_TCEQ = Int32.Parse(fc["TBIDReport"].ToString());
            }
            t.ERS_Operator = fc["TBERS"].ToString().ToUpper();
            t.Report_Date = fc["DTreportdate"].ToString();
            t.Report_Time = fc["TBRTime"].ToString();
            t.Incident_Date = fc["DTtincidentdate"].ToString();
            t.Incident_Time = fc["TBincidenttime"].ToString();
            t.Report_By = fc["TBreportedby"].ToString().ToUpper();
            t.Contact_Number = fc["TBContactNumber"].ToString();
            if (fc["TBContactNumber2"].ToString() == "")
            {
                t.Contact_Number_2 = "(000) 000-0000";
            } else
            {
                t.Contact_Number_2 = fc["TBContactNumber2"].ToString();
            }
            t.Emergency = fc["CBEmergency"].ToString();
            t.Description = fc["TBDescription"].ToString().ToUpper();
            t.Location = fc["TBLocation"].ToString().ToUpper();
            t.County = fc["CBCounty"].ToString();
            t.Material1 = fc["TBM1"].ToString().ToUpper();
            t.Material2 = fc["TBM2"].ToString().ToUpper();
            t.Material3 = fc["TBM3"].ToString().ToUpper();
            t.Material4 = fc["TBM4"].ToString().ToUpper();
            t.Material5 = fc["TBM5"].ToString().ToUpper();
            if (fc["TBCAS1"].ToString() == "") { t.CAS1 = "NA"; } else { t.CAS1 = fc["TBCAS1"].ToString(); }
            if (fc["TBCAS2"].ToString() == "") { t.CAS2 = "NA"; } else { t.CAS2 = fc["TBCAS2"].ToString(); }
            if (fc["TBCAS3"].ToString() == "") { t.CAS3 = "NA"; } else { t.CAS3 = fc["TBCAS3"].ToString(); }
            if (fc["TBCAS4"].ToString() == "") { t.CAS4 = "NA"; } else { t.CAS4 = fc["TBCAS4"].ToString(); }
            if (fc["TBCAS5"].ToString() == "") { t.CAS5 = "NA"; } else { t.CAS5 = fc["TBCAS5"].ToString(); }
            t.Amount1 = fc["TBAmount1"].ToString();
            t.Amount2 = fc["TBAmount2"].ToString();
            t.Amount3 = fc["TBAmount3"].ToString();
            t.Amount4 = fc["TBAmount4"].ToString();
            t.Amount5 = fc["TBAmount5"].ToString();
            t.Unit1 = fc["CBUnit1"].ToString();
            t.Unit2 = fc["CBUnit2"].ToString();
            t.Unit3 = fc["CBUnit3"].ToString();
            t.Unit4 = fc["CBUnit4"].ToString();
            t.Unit5 = fc["CBUnit5"].ToString();
            if (fc["CHAir"] != null && fc["CHAir"].ToString() == "Air")
            {
                t.Media_Affected = "Air";
            }
            if (fc["CHWater"] != null && fc["CHWater"].ToString() == "Water")
            {
                if (t.Media_Affected == "NA")
                {
                    t.Media_Affected = "Water";
                }
                else { t.Media_Affected = t.Media_Affected + ", Water"; }
            }
            if (fc["CHLand"] != null && fc["CHLand"].ToString() == "Land")
            {
                if (t.Media_Affected == "NA")
                {
                    t.Media_Affected = "Land";
                }
                else { t.Media_Affected = t.Media_Affected + ", Land"; }
            }
            if (fc["TBRW"].ToString() == "") { t.Receiving_Water = "N/A"; } else { t.Receiving_Water = fc["TBRW"].ToString().ToUpper(); }
            t.Amount_Water = fc["TBRWAmount"].ToString();
            t.Unit_Water = fc["CBRWUnit"].ToString();
            if (fc["TBPRCompany"].ToString() == "") { t.PR_Company = "UNKNOWN"; } else { t.PR_Company = fc["TBPRCompany"].ToString(); }
            if (fc["TBPRStreet"].ToString() == "") { t.PR_Street = "UNKNOWN"; } else { t.PR_Street = fc["TBPRStreet"].ToString(); }
            if (fc["TBPRCity"].ToString() == "") { t.PR_City = "UNKNOWN"; } else { t.PR_City = fc["TBPRCity"].ToString(); }
            if (fc["TBPRState"].ToString() == "") { t.PR_State = "NA"; } else { t.PR_State = fc["TBPRState"].ToString(); }
            if (fc["TBPRZipCode"].ToString() != "")
            {
                string Zip1 = fc["TBPRZipCode"].ToString().Substring(0, 5);
                string Zip2 = fc["TBPRZipCode"].ToString().Substring((fc["TBPRZipCode"].ToString().Length - 4), 4);
                t.PR_ZipCode = Zip1 + "-" + Zip2;
            } else
            {
                t.PR_ZipCode = "00000-0000";
            }
            if (fc["TBPRContact"].ToString() == "") { t.PR_Contact = "UNKNOWN"; } else { t.PR_Contact = fc["TBPRContact"].ToString(); }
            if (fc["TBPRPhone"].ToString() == "") { t.PR_Phone = "(000) 000-0000"; } else { t.PR_Phone = fc["TBPRPhone"].ToString(); }
            t.ResponderName = fc["TBRName"].ToString();
            t.NotificationTime = fc["TBNTime"].ToString();
            return t;
        }


        #endregion
        #region TCEQ Email Form
        public ActionResult TCEQEmailForm(TCEQEmailContact tef)
        {
            return View(tef);
        }

        public ActionResult CorrectTCEQReport(FormCollection fc)
        {
            ViewBag.Revised = "true";
            TCEQ t = new TCEQ(constring, int.Parse(fc["ReportID"].ToString()));  //Gets the desired report and puts it into a custom class variable.
            List<string> Counties = new List<string>(); //Get county list for dropdown
            Counties = CountyListNames();
            ViewBag.Counties = Counties;
            return View("TCEQReport", t);
        }

        public ActionResult SendTCEQEmail(FormCollection fc)
        {
            var client = new SendGridClient("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");
            var from = new EmailAddress("ers@ehs.com");
            string profile = Session["Username"].ToString();
            string[] emails = fc["ToEmails"].ToString().Split(',');
            string body = "<br />" + fc["Message"].ToString() + "<br />" + "<br />" + Session["Fullname"].ToString() + "<br />" + "<htm><body> <img src=\"cid:Image\"> </body></html>";
            string filepath = fc["Attachment"].ToString();  //Temp variable to hold the report path.
            string subject = fc["Subject"].ToString();
            //Need a list created for SendGrid to send to multiple email address.
            var to = new List<EmailAddress>();
            to.Add(new EmailAddress("mpepitone@ehs.com"));
            to.Add(new EmailAddress("ers@ehs.com"));
            //foreach (string email in emails)
            //{
            //    to.Add(new EmailAddress(email));
            //}

            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, to, subject, "", body);            
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
            client.SendEmailAsync(msg).Wait();
            return RedirectToAction("TCEQReport");
        }
        #endregion
        #region TCEQ Logs
        public ActionResult TCEQReportLog()
        {
            List<TceqLog> TceqLogList = new List<TceqLog>();
            string sqlcmd = "SELECT TOP 100 * FROM tceqreport ORDER BY ID DESC";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        string[] ReportDate = sdr["ReportDate"].ToString().Split(' ');
                        string[] IncidentDate = sdr["IncidentDate"].ToString().Split(' ');
                        TceqLog t = new TceqLog();
                        t.ID = Int32.Parse(sdr["id"].ToString());
                        t.ERS = sdr["Operator"].ToString();
                        t.ReportDate = ReportDate[0];
                        t.ReportTime = sdr["ReportTime"].ToString();
                        t.IncidentDate = IncidentDate[0];
                        t.IncidentTime = sdr["IncidentTime"].ToString();
                        t.ReportedBy = sdr["ReportedBy"].ToString();
                        t.ContactNumber = sdr["ContactNumber"].ToString();
                        t.OtherNumbers = sdr["ContactNumber2"].ToString();
                        t.County = sdr["County"].ToString();
                        t.NotificationTime = sdr["NotificationTime"].ToString();
                        TceqLogList.Add(t);
                    }
                }
            };
            return View(TceqLogList.ToList());
        }
        public ActionResult LineReport(FormCollection fc)
        {
            return RedirectToAction("TCEQReportLog");
        }
        public ActionResult ReportSearch(FormCollection fc)
        {
            if (fc["submittype"].ToString() == "Search")
            {
                List<TceqLog> TceqLogList = new List<TceqLog>();
                string sqlcmd = "SELECT * FROM tceqreport WHERE ID LIKE '%" + fc["reportid"] + "%' ORDER BY ID DESC";
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                    {
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            string[] ReportDate = sdr["ReportDate"].ToString().Split(' ');
                            string[] IncidentDate = sdr["IncidentDate"].ToString().Split(' ');
                            TceqLog t = new TceqLog();
                            t.ID = Int32.Parse(sdr["id"].ToString());
                            t.ERS = sdr["Operator"].ToString();
                            t.ReportDate = ReportDate[0];
                            t.ReportTime = sdr["ReportTime"].ToString();
                            t.IncidentDate = IncidentDate[0];
                            t.IncidentTime = sdr["IncidentTime"].ToString();
                            t.ReportedBy = sdr["ReportedBy"].ToString();
                            t.ContactNumber = sdr["ContactNumber"].ToString();
                            t.OtherNumbers = sdr["ContactNumber2"].ToString();
                            t.County = sdr["County"].ToString();
                            t.NotificationTime = sdr["NotificationTime"].ToString();
                            TceqLogList.Add(t);
                        }
                    }
                };
                return View("TCEQReportLog", TceqLogList.ToList());
            }
            else if (fc["submittype"].ToString() == "Revise") //Revise Selected or Typed Report ID
            {
                ViewBag.Revised = "true";
                TCEQ t = new TCEQ(constring, int.Parse(fc["reportid"].ToString()));  //Gets the desired report and puts it into a custom class variable.
                //Get county list for dropdown
                List<string> Counties = new List<string>();
                Counties = CountyListNames();
                ViewBag.Counties = Counties;
                return View("TCEQReport", t);
            }
            return View("TCEQReportLog"); 
        }
        private string GetReportDate(string ReportID)
        {
            string ReportDate = "";
            string sqlcmd = "SELECT ReportDate FROM tceqreport WHERE id = @id";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@id", ReportID); 
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        ReportDate = sdr["ReportDate"].ToString();
                    }
                }
            }
            return ReportDate;
        }
        #endregion
        private bool FillDataSet(int ID)
        {
            TCEQDataSet dt = new TCEQDataSet();
            tceqcrystalreport r = new tceqcrystalreport();
            DataSet dataSeccion = new DataSet("DataS2");
            string query = "SELECT * FROM tceqreport WHERE id =" + ID.ToString();
            using (SqlConnection c = new SqlConnection(constring))
            {
                c.Open();
                SqlDataAdapter data = new SqlDataAdapter(query, c);
                data.FillSchema(dataSeccion, SchemaType.Source, "Sesscion");
                data.Fill(dataSeccion, "Sesscion");
            }
            DataTable datos;
            datos = dataSeccion.Tables["Sesscion"];
            DataRow fila;
            DataRow Row;
            foreach (DataRow dtcurrent in datos.Rows)
            {
                string year = DateTime.Now.Year.ToString();
                if (dt.TceqReport.Rows.Count > 0)
                { break; }
                else
                {
                    Row = dt.Material.NewRow();
                    fila = dt.TceqReport.NewRow();
                    //ID
                    fila["id"] = dtcurrent["id"];
                    // Operator
                    fila["Operator"] = dtcurrent["Operator"].ToString();
                    // ReportDate 
                    string[] dat = dtcurrent["ReportDate"].ToString().Split('/');
                    string result = dat[0] + "/" + dat[1] + "/" + dat[2].Substring(0, 4);
                    fila["ReportDate"] = result;
                    //Report Time
                    fila["ReportTime"] = dtcurrent["ReportTime"].ToString();
                    // IncidentDate
                    string[] di = dtcurrent["IncidentDate"].ToString().Split('/');
                    string IncDate = di[0] + "/" + di[1] + "/" + di[2].Substring(0, 4);
                    fila["IncidentDate"] = IncDate;
                    // IncidentTime 
                    fila["IncidentTime"] = dtcurrent["IncidentTime"].ToString();
                    // ReportedBy 
                    fila["ReportedBy"] = dtcurrent["ReportedBy"].ToString();
                    // ContactNumber 
                    fila["ContactNumber"] = dtcurrent["ContactNumber"].ToString();
                    // ContactNumber2 
                    fila["ContactNumber2"] = dtcurrent["ContactNumber2"].ToString();
                    // Emergency 
                    fila["Emergency"] = dtcurrent["Emergency"].ToString();
                    // Description 
                    fila["Description"] = dtcurrent["Description"].ToString();
                    // Location 
                    fila["Location"] = dtcurrent["Location"].ToString();
                    // County 
                    fila["County"] = dtcurrent["County"].ToString();
                    // MediaAffected 
                    fila["MediaAffected"] = dtcurrent["MediaAffected"].ToString();
                    // ReceivingWater 
                    fila["ReceivingWater"] = dtcurrent["ReceivingWater"].ToString();
                    // AmountWater 
                    fila["AmountWater"] = dtcurrent["AmountWater"].ToString();
                    // UnitWater 
                    fila["UnitWater"] = dtcurrent["UnitWater"].ToString();
                    // PRCompany 
                    fila["PRCompany"] = dtcurrent["PRCompany"].ToString();
                    // PRStreet 
                    fila["PRStreet"] = dtcurrent["PRStreet"].ToString();
                    // PRCity 
                    fila["PRCity"] = dtcurrent["PRCity"].ToString();
                    // PRState 
                    fila["PRState"] = dtcurrent["PRState"].ToString();
                    // PRZipCode 
                    fila["PRZipCode"] = dtcurrent["PRZipCode"].ToString();
                    // PRContact 
                    fila["PRContact"] = dtcurrent["PRContact"].ToString();
                    // PRPhone 
                    fila["PRPhone"] = dtcurrent["PRPhone"].ToString();
                    // Material1 
                    Row["Material"] = dtcurrent["Material1"].ToString();
                    Row["CAS"] = dtcurrent["CAS1"].ToString();
                    Row["Amount"] = dtcurrent["Amount1"].ToString();
                    Row["Unit"] = dtcurrent["Unit1"].ToString();
                    dt.Material.Rows.Add(Row);
                    // Material2
                    if (dtcurrent["Material2"].ToString() != "")
                    {
                        DataRow Row2 = dt.Material.NewRow();
                        Row2["Material"] = dtcurrent["Material2"].ToString();
                        Row2["CAS"] = dtcurrent["CAS2"].ToString();
                        Row2["Amount"] = dtcurrent["Amount2"].ToString();
                        Row2["Unit"] = dtcurrent["Unit2"].ToString();
                        dt.Material.Rows.Add(Row2);
                    }
                    // Material3
                    if (dtcurrent["Material3"].ToString() != "")
                    {
                        DataRow Row3 = dt.Material.NewRow();
                        Row3["Material"] = dtcurrent["Material3"].ToString();
                        Row3["CAS"] = dtcurrent["CAS3"].ToString();
                        Row3["Amount"] = dtcurrent["Amount3"].ToString();
                        Row3["Unit"] = dtcurrent["Unit3"].ToString();
                        dt.Material.Rows.Add(Row3);
                    }
                    // Material4
                    if (dtcurrent["Material4"].ToString() != "")
                    {
                        DataRow Row4 = dt.Material.NewRow();
                        Row4["Material"] = dtcurrent["Material4"].ToString();
                        Row4["CAS"] = dtcurrent["CAS4"].ToString();
                        Row4["Amount"] = dtcurrent["Amount4"].ToString();
                        Row4["Unit"] = dtcurrent["Unit4"].ToString();
                        dt.Material.Rows.Add(Row4);
                    }
                    // Material5
                    if (dtcurrent["Material5"].ToString() != "")
                    {
                        DataRow Row5 = dt.Material.NewRow();
                        Row5["Material"] = dtcurrent["Material5"].ToString();
                        Row5["CAS"] = dtcurrent["CAS5"].ToString();
                        Row5["Amount"] = dtcurrent["Amount5"].ToString();
                        Row5["Unit"] = dtcurrent["Unit5"].ToString();
                        dt.Material.Rows.Add(Row5);
                    }
                    dt.TceqReport.Rows.Add(fila);
                    string path = @"\\chem-fs1.ers.local\Completed Reports\TCEQ\" + year + "\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    string outPutFilePath = path + "TCEQ-" + ID + ".pdf";
                    r.SetDataSource(dt);
                    r.ExportToDisk(ExportFormatType.PortableDocFormat, outPutFilePath);
                    System.Diagnostics.Process.Start(outPutFilePath);
                    AttachedPath = outPutFilePath;
                }
            }
            return true;
        }
        public string SearchRegionCountyName(string county)
        {
            string region = "";
            string strsql = "SELECT countyTNRCCDistrictNumber FROM glocountylist WHERE countyName =@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", county);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        region = rdr["countyTNRCCDistrictNumber"].ToString();
                    }
                }
            }
            return region;
        }
        public JsonResult CountyChange(string County)
        {
            string region = "";
            string callnumber = "";
            string strsql = "SELECT countyTNRCCDistrictNumber FROM glocountylist WHERE countyName =@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", County);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        region = rdr["countyTNRCCDistrictNumber"].ToString();
                    }
                }
            }
            string str = "SELECT * FROM tceqafterhours WHERE ID =@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(str, cn))
                {
                    cmd.Parameters.AddWithValue("@id", region);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        callnumber = rdr["PrimaryContact"].ToString();
                    }
                }
            }
            return Json(new { Region = region, CallNumber = callnumber }, JsonRequestBehavior.AllowGet);
        }
    }
}
