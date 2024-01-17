using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crm.chemtelinc.com.Models;

namespace crm.chemtelinc.com.Controllers
{
    public class MSDSSearchController : Controller
    {
        string SqlSearchCriteria = "";
        // GET: MSDSSearch
        public ActionResult Index()
        {
            List<MSDSSearch> m = new List<MSDSSearch>();
            m = GetRecords();
            return View(m.ToList());
        }


        public List<MSDSSearch> GetRecords()
        {
            string Vdocconstring = Properties.Settings.Default.VdocConnectionString;
            string sql = "SELECT TOP 200 Company, ProductName, Language, Manufacturer, ProductNumber, Date, MIS, FileName, CommonName FROM msds ORDER BY Date";
            List<MSDSSearch> m = new List<MSDSSearch>();
            using (SqlConnection con = new SqlConnection(Vdocconstring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        MSDSSearch ms = new MSDSSearch();
                        ms.Company = sdr["Company"].ToString();
                        ms.ProductName = sdr["ProductName"].ToString();
                        ms.Language = sdr["Language"].ToString();
                        ms.Manufacturer = sdr["Manufacturer"].ToString();
                        ms.ProductNumber = sdr["ProductNumber"].ToString();
                        ms.Date = sdr["Date"].ToString();
                        ms.MIS = sdr["MIS"].ToString();
                        ms.FileName = sdr["FileName"].ToString();
                        ms.CommonName = sdr["CommonName"].ToString();
                        m.Add(ms);
                    }
                }
            }
            return m;
        }

        public ActionResult SearchMSDS(FormCollection fc)
        {
            string SearchCriteria = fc["SearchBy"].ToString();
            string SearchTerm = fc["Search"].ToString();
            string AdvSearchCrit = "";
            string AdvSearchTerm = "";
            string AdvSortBy = "";
            string AdvSortOrder = "";

            if (fc["AdvSearchBy"] != null && fc["AdvSearchBy"].ToString() != "")
            {
                AdvSearchCrit = fc["AdvSearchBy"].ToString();
            }
            if (fc["AdvSearch"] != null && fc["AdvSearch"].ToString() != "")
            {
                AdvSearchTerm = fc["AdvSearch"].ToString();
            }
            if (fc["AdvSortBy"] != null && fc["AdvSortBy"].ToString() != "")
            {
                AdvSortBy = fc["AdvSortBy"].ToString();
            }
            if (fc["AdvSortOrder"] != null && fc["AdvSortOrder"].ToString() != "")
            {
                AdvSortOrder = fc["AdvSortOrder"].ToString();
            }


            string Vdocconstring = Properties.Settings.Default.VdocConnectionString;
            string sql = "SELECT ID, Company, ProductName, Language, Manufacturer, ProductNumber, Date, MIS, FileName, CommonName FROM msds ";
            //WHERE statements based on 
            if (SearchCriteria == "Product Name/Product Number")
            {
                sql += "WHERE (ProductName LIKE '%" + SearchTerm + "%' OR ProductNumber LIKE '%" + SearchTerm + "%')";
                if (AdvSearchTerm != null && AdvSearchTerm != "")
                {
                    sql += " AND [" + AdvSearchCrit + "] LIKE '%"+ AdvSearchTerm + "%'";
                }
            }
            if (SearchCriteria == "Company")
            {
                sql += "WHERE Company LIKE '%" + SearchTerm + "%'";
                if (AdvSearchTerm != null && AdvSearchTerm != "")
                {
                    sql += " AND [" + AdvSearchCrit + "] LIKE '%" + AdvSearchTerm + "%'";
                }
            }
            if (SearchCriteria == "Product Name")
            {
                sql += "WHERE ProductName LIKE '%" + SearchTerm + "%'";
                if (AdvSearchTerm != null && AdvSearchTerm != "")
                {
                    sql += " AND [" + AdvSearchCrit + "] LIKE '%" + AdvSearchTerm + "%'";
                }
            }
            if (SearchCriteria == "Language")
            {
                sql += "WHERE Language LIKE '%" + SearchTerm + "%'";
                if (AdvSearchTerm != null && AdvSearchTerm != "")
                {
                    sql += " AND [" + AdvSearchCrit + "] LIKE '%" + AdvSearchTerm + "%'";
                }
            }
            if (SearchCriteria == "Manufacturer")
            {
                sql += "WHERE Manufacturer LIKE '%" + SearchTerm + "%'";
                if (AdvSearchTerm != null && AdvSearchTerm != "")
                {
                    sql += " AND [" + AdvSearchCrit + "] LIKE '%" + AdvSearchTerm + "%'";
                }
            }
            if (SearchCriteria == "Product Number")
            {
                sql += "WHERE ProductNumber LIKE '%" + SearchTerm + "%'";
                if (AdvSearchTerm != null && AdvSearchTerm != "")
                {
                    sql += " AND [" + AdvSearchCrit + "] LIKE '%" + AdvSearchTerm + "%'";
                }
            }
            if (SearchCriteria == "Date")
            {
                sql += "Date LIKE '%" + SearchTerm + "%'";
                if (AdvSearchTerm != null && AdvSearchTerm != "")
                {
                    sql += " AND [" + AdvSearchCrit + "] LIKE '%" + AdvSearchTerm + "%'";
                }
            }

            //Add the ORDER BY based on user selection
            if (AdvSortBy != null && AdvSortBy != "")
            {
                sql += " ORDER BY [" + AdvSortBy + "]";
            }
            //Add the sort order ASC or DESC based on user selection
            if (AdvSortOrder != null && AdvSortOrder != "")
            {
                sql += " " + AdvSortOrder; 
            }

            ViewBag.SearchTerm = SearchTerm;
            ViewBag.AdvSearchTerm = AdvSearchTerm;

            List<MSDSSearch> m = new List<MSDSSearch>();
            using (SqlConnection con = new SqlConnection(Vdocconstring))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        MSDSSearch ms = new MSDSSearch();
                        ms.ID = sdr["ID"].ToString();
                        ms.Company = sdr["Company"].ToString();
                        ms.ProductName = sdr["ProductName"].ToString();
                        ms.Language = sdr["Language"].ToString();
                        ms.Manufacturer = sdr["Manufacturer"].ToString();
                        ms.ProductNumber = sdr["ProductNumber"].ToString();
                        ms.Date = sdr["Date"].ToString();
                        ms.MIS = sdr["MIS"].ToString();
                        ms.FileName = sdr["FileName"].ToString();
                        ms.CommonName = sdr["CommonName"].ToString();
                        m.Add(ms);
                    }
                }
            }
            return View("Index", m);
        }

        public ActionResult SortData(string SqlSearchCriteria)
        {
            ViewBag.SqlSearchCriteria = SqlSearchCriteria;
            string sql = SqlSearchCriteria + ", Date DESC";
            string Vdocconstring = Properties.Settings.Default.VdocConnectionString;

            List<MSDSSearch> m = new List<MSDSSearch>();
            using (SqlConnection con = new SqlConnection(Vdocconstring))
            {
                using (SqlCommand cmd = new SqlCommand(SqlSearchCriteria, con))
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        MSDSSearch ms = new MSDSSearch();
                        ms.ID = sdr["ID"].ToString();
                        ms.Company = sdr["Company"].ToString();
                        ms.ProductName = sdr["ProductName"].ToString();
                        ms.Language = sdr["Language"].ToString();
                        ms.Manufacturer = sdr["Manufacturer"].ToString();
                        ms.ProductNumber = sdr["ProductNumber"].ToString();
                        ms.Date = sdr["Date"].ToString();
                        ms.MIS = sdr["MIS"].ToString();
                        ms.FileName = sdr["FileName"].ToString();
                        ms.CommonName = sdr["CommonName"].ToString();
                        m.Add(ms);
                    }
                }
            }
            return View("Index", m);
        }
    }
}