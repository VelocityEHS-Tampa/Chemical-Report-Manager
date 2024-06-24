using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crm.chemtelinc.com.Models;
using Microsoft.IdentityModel.Tokens;
using DuoUniversal;
using System.Threading.Tasks;

namespace crm.chemtelinc.com.Controllers
{

    public class HomeController : Controller
    {
        string ClientId = "DIXAIJZXU2J7LJJ9PZRW"; //Setting from Duo
        //NEW OIDC SECRET 1Fa73J1WgMbccHoBWTpR8ijwnfznDLjgTX8rGP4P
        //OLD SECRET IOTgcps6k2qvJtQzz0I07QXNLrhjev34dDP9XhZl
        string ClientSecret = "1Fa73J1WgMbccHoBWTpR8ijwnfznDLjgTX8rGP4P"; //Setting from Duo
        string ApiHost = "api-64691b0c.duosecurity.com"; //Setting from Duo
        string RedirectUri = ""; //This is the URL you will redirect to after authentication. It does not need to be publically accessible.
        public ActionResult Index()
        {
            Session.Add("constring", "");
            if (Request.Url.AbsoluteUri.Contains("crmtest.chemtel.net") || Request.Url.AbsoluteUri.Contains("localhost"))
            {
                Session["constring"] = Properties.Settings.Default.chemicalTestConnectionString;
                RedirectUri = "https://crmtest.chemtel.net";
            }
            else
            {
                Session["constring"] = Properties.Settings.Default.chemicalConnectionString;
                RedirectUri = "https://crm.chemtel.net";
            }
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {

            string username = fc["username"].ToString();
            string password = fc["password"].ToString();
            //Throw error if missing field.
            if (username == "" || password == "")
            {
                ViewBag.ErrorMessage = "Invalid Username/Password combination";
                return View();
            }

            //Start validation process
            string LoginValidated = ValidatePass(username, password);

            if (LoginValidated == "Yes")
            {
                Session.Add("SessionStartTime", DateTime.Now);
                Session.Add("Username", username);
                
                HttpCookie UserCookie = new HttpCookie("UserCookie");
                UserCookie.Value = username;
                UserCookie.Expires = DateTime.Now.AddHours(1);

                GetAcctInfo(username);
                if (password == "Password1" || Int32.Parse(Session["DaysBetween"].ToString()) >= 90)
                {
                    RedirectUri = "https://crm.chemtel.net/Home/ResetPassword";
                    InitiateDuo(username); //User should be the username trying to login.
                    return View("ResetPassword");
                } else
                {
                    ViewBag.ErrorMessage = "Successful Login!";
                    RedirectUri = "https://crm.chemtel.net/Home/Index";
                    //Add DUO MFA Code here
                    InitiateDuo(username); //User should be the username trying to login.
                    return View("Index");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Username/Password combination";
                return View();
            }
        }
        public void InitiateDuo(string User)
        {
            //Create client using config settings
            Client duoClient = new ClientBuilder(ClientId, ClientSecret, ApiHost, RedirectUri).Build();
            Session["client"] = duoClient;

            // Check if Duo seems to be healthy and able to service authentications.
            // If Duo were unhealthy, you could possibly send user to an error page, or implement a fail mode
            var isDuoHealthy = duoClient.DoHealthCheck();

            // Generate a random state value to tie the authentication steps together
            string state = Client.GenerateState();
            // Save the state and username in the session for later
            Session["STATE_SESSION_KEY"] = state;
            Session["USERNAME_SESSION_KEY"] = User;

            // Get the URI of the Duo prompt from the client.  This includes an embedded authentication request.
            string promptUri = duoClient.GenerateAuthUri(User, state);

            // Redirect the user's browser to the Duo prompt.
            // The Duo prompt, after authentication, will redirect back to the configured Redirect URI to complete the authentication flow.
            // In this example, that is /duo_callback, which is implemented in Callback.cshtml.cs.
            Response.Redirect(promptUri, false);
        }
        public ActionResult ResetPassword()
        {
            return View();
        }
        public ActionResult PasswordChangeResults(FormCollection fc)
        {
            string username = Session["username"].ToString();
            string password = fc["NewPassword"].ToString();
            string SqlCmd = "UPDATE CRMWebU SET Password = @p, LastPassChange = @lpc WHERE Username = @un";

            string EncPass = PassEncrypt.EncodePassword(password);

            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(SqlCmd, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@p", EncPass);
                    cmd.Parameters.AddWithValue("@un", username);
                    cmd.Parameters.AddWithValue("@lpc", DateTime.Now.ToShortDateString());
                    cmd.ExecuteNonQuery();
                }
            }
            GetAcctInfo(username);
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session["Username"] = null;
            Session["FullName"] = null;
            Session["AccountType"] = null;
            return View("Index");
        }
        public ActionResult MSDSSearch()
        {
            return View();
        }
        private string ValidatePass(string username, string password)
        {
            string Validated = "No";
            string DBPass = "";
            string SqlCmd = "SELECT Password FROM CRMWebU WHERE username = @username";

            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(SqlCmd, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@username", username);
                    DBPass = cmd.ExecuteScalar().ToString();
                }
            }

            string EncPass = PassEncrypt.EncodePassword(password);

            if (EncPass == DBPass)
            {
                Validated = "Yes";
            }

            return Validated;
        }
        private void GetAcctInfo(string username)
        {
            string SqlCmd = "Select * FROM CRMWebU WHERE Username = @username";
            using (SqlConnection con = new SqlConnection(Session["constring"].ToString()))
            {
                using (SqlCommand cmd = new SqlCommand(SqlCmd, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Session.Add("Username", sdr["Username"].ToString());
                        Session.Add("FullName", sdr["Name"].ToString());
                        Session.Add("AccountType", sdr["UserType"].ToString());
                        Session.Add("LastPassChange", sdr["LastPassChange"].ToString());
                        //Get how many days it has been since the last password change.
                        TimeSpan ts = DateTime.Now - DateTime.Parse(sdr["LastPassChange"].ToString());
                        Session.Add("DaysBetween", Math.Round(ts.TotalDays));
                    }
                }
            }
        }
        public JsonResult CheckFileModifications()
        {
            DateTime StartDate = DateTime.Parse(Session["SessionStartTime"].ToString());
            DateTime ModifiedFile = System.IO.File.GetLastWriteTime(@"\\chem-fs1.ers.local\Chemtel Websites\crm.chemtel.net\README.txt");
            bool NewUpdate = false;

            if (ModifiedFile > StartDate)
            {
                NewUpdate = true;
            }

            return Json(new { FileModified = NewUpdate }, JsonRequestBehavior.AllowGet);
        }
        //Novartis Registration Lookup
        public ActionResult NovartisRegLookup()
        {
            return View();
        }
        public JsonResult NovRegSites(string Division)
        {
            string constring = Properties.Settings.Default.CustomSitesConnectionString;
            string SiteList = "";
            string sql = "SELECT DISTINCT hsesite FROM Pharma_globalsites WHERE division = @SelectedDiv";

            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SelectedDiv", Division);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        SiteList += sdr[0].ToString() + ",";
                    }
                }
            }

            return Json(new { SiteList = SiteList }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult NovRegCountries(string Division, string Site)
        {
            string constring = Properties.Settings.Default.CustomSitesConnectionString;
            string CountryList = "";
            string sql = "SELECT DISTINCT country FROM Pharma_globalsites WHERE division = @SelectedDiv AND hsesite = @SelectedSite";

            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@SelectedDiv", Division);
                    cmd.Parameters.AddWithValue("@SelectedSite", Site);
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        CountryList += sdr[0].ToString() + ",";
                    }
                }
            }
            return Json(new { CountryList = CountryList }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RegistrationSearch(FormCollection fc)
        {
            string constring = Properties.Settings.Default.CustomSitesConnectionString;
            List<NovartisLookup> RegLookUp = new List<NovartisLookup>();
            string Division = "";
            string Site = "";
            string Country = "";
            string SqlCommand = "SELECT * FROM Pharma_GlobalSites ";

            //if there is at least 1 selection when form is submitted, we need the WHERE clause.
            if (fc["SelectedDivision"] != null || fc["SelectedSite"] != null || fc["SelectedCountry"] != null)
            {
                SqlCommand += "WHERE ";
            }

            if (fc["SelectedDivision"] != null && fc["SelectedDivision"].ToString() != "") 
            {
                SqlCommand += "division = '" + fc["SelectedDivision"].ToString() + "'";
            } 
            if (fc["SelectedSite"] != null && fc["SelectedSite"].ToString() != "") 
            { 
                SqlCommand += "AND hsesite = '" + fc["SelectedSite"].ToString() + "'";
            } 
            if (fc["SelectedCountry"] != null && fc["SelectedCountry"].ToString() != "") 
            { 
                SqlCommand += "AND country = '" + fc["SelectedCountry"].ToString() + "'";
            }

            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand(SqlCommand,con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        NovartisLookup n = new NovartisLookup();
                        n.ID = Int32.Parse(reader["id"].ToString());
                        n.Division = reader["division"].ToString();
                        n.Site = reader["site"].ToString();
                        n.Country = reader["country"].ToString();
                        n.hseSite = reader["hsesite"].ToString();
                        n.CountryCode = reader["countrycode"].ToString();
                        n.PrimaryContact = reader["primarycontact"].ToString();
                        n.PrimaryNumber = reader["primarynumber"].ToString();
                        n.PhoneCode = reader["phonecode"].ToString();
                        n.PrimaryContactEmail = reader["primarycontactemail"].ToString();
                        n.SecondaryContact = reader["secondarycontact"].ToString();
                        n.SecondaryContactEmail = reader["secondarycontactemail"].ToString();
                        n.Translator = reader["translator"].ToString();
                        n.Language = reader["language"].ToString();
                        n.InjuryContact = reader["injurycontact"].ToString();
                        n.InjuryPhoneNumber = reader["injuryphonenumber"].ToString();
                        n.InjuryEmail = reader["injuryemail"].ToString();
                        n.ReleaseContact = reader["releasecontact"].ToString();
                        n.ReleasePhoneNumber = reader["releasephonenumber"].ToString();
                        n.ReleaseEmail = reader["releaseemail"].ToString();
                        n.DateRegistered = reader["dateregistered"].ToString();
                        RegLookUp.Add(n);
                    }
                }
            }
            ViewBag.RegLookUpResults = RegLookUp;
            return View("NovartisRegLookup");
        }
    }
}