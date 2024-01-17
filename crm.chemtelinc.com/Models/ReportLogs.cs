using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace ChemicalLibrary
{
    public static class ReportLogs
    {

        public static int InsertStartLog(string ReportID, string ReportType, string Operator, int Corrected,  string constring)
        {
            int NewReportLogID = 0;
            try
            {
                //Inserts new report log with start time, report type, and operator

                int StartTime = (int)DateTime.Now.TimeOfDay.TotalMinutes;
                string ReportDate = DateTime.Now.ToString("yyyy-MM-dd"); 

                string insertcmd = "INSERT INTO ReportLog (ReportID, ReportType, Operator, StartTime, ReportDate, Corrected) VALUES (@ReportID, @ReportType, @Operator, @StartTime, @ReportDate, @Corrected)";
                string getlastid = "SELECT TOP 1 ReportLogID FROM ReportLog ORDER BY ReportLogID DESC";

                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand(insertcmd, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@ReportID", ReportID);
                        cmd.Parameters.AddWithValue("@ReportType", ReportType);
                        cmd.Parameters.AddWithValue("@Operator", Operator);
                        cmd.Parameters.AddWithValue("@StartTime", StartTime);
                        cmd.Parameters.AddWithValue("@ReportDate", ReportDate);
                        cmd.Parameters.AddWithValue("@Corrected", Corrected);
                        cmd.ExecuteNonQuery();
                    }
                    //Get the newly inserted ID
                    using (SqlCommand cmd2 = new SqlCommand(getlastid, con))
                    {
                        NewReportLogID = (int)cmd2.ExecuteScalar();
                    }
                }
                return NewReportLogID;
            } catch (Exception e)
            {
                //MessageBox.Show("An error has occured in this program.  The IT department has been notified of this error.", "Chemical Report Manager", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                string path = @"\\chem-fs1.ers.local\Log Files\Chemical.log";
                StreamWriter log;
                if (File.Exists(path))
                    log = File.AppendText(path);
                else
                    log = File.CreateText(path);
                //string sp = " ";
                string mod = "BTConvert_Click";
                string pfile = "frmcrmTCEQReport.cs";
                log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\n" + "Function Name: " + "Error Message: InsertStartLog \n" + e.Message + "\n" + "File: " + pfile + "\n" + "Method: " + mod + "\n\n\n");
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
                to.Add("mpepitone@ehs.com");
                // to.Add("mpepitone@ehs.com");
                message.To.Add(to.ToString());
                message.From = from;
                message.Subject = subject;
                message.Body = msg;
                smtp.Send(message);
            }
            return NewReportLogID;
        }

        public static void UpdateReportLog(string ReportLogID, string constring)
        {
            try
            {
                //Updates the specific report log
                string getstarttime = "SELECT StartTime FROM ReportLog WHERE ReportLogID = @ReportLogID";
                string updatecmd = "UPDATE ReportLog SET EndTime = @EndTime, MinutesTaken = @MinutesTaken WHERE ReportLogID = @ReportLogID";
                int EndTime = (int)DateTime.Now.TimeOfDay.TotalMinutes;
                int StartTime = 0;

                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand(getstarttime, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@ReportLogID", ReportLogID);
                        StartTime = (int)cmd.ExecuteScalar();
                    }
                }
                //Get the total number of minutes it took to complete the report by subtracting the end time with the start time.
                int MinutesTaken = (EndTime - StartTime);

                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd2 = new SqlCommand(updatecmd, con))
                    {
                        con.Open();
                        cmd2.Parameters.AddWithValue("@EndTime", EndTime);
                        cmd2.Parameters.AddWithValue("@MinutesTaken", MinutesTaken);
                        cmd2.Parameters.AddWithValue("@ReportLogID", ReportLogID);
                        cmd2.ExecuteNonQuery();
                    }
                }
            } catch (Exception e)
            {
                //MessageBox.Show("An error has occured in this program.  The IT department has been notified of this error.", "Chemical Report Manager", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                string path = @"\\chem-fs1.ers.local\Log Files\Chemical.log";
                StreamWriter log;
                if (File.Exists(path))
                    log = File.AppendText(path);
                else
                    log = File.CreateText(path);
                //string sp = " ";
                string mod = "BTConvert_Click";
                string pfile = "frmcrmTCEQReport.cs";
                log.WriteLine("Date: " + DateTime.Now.ToShortDateString() + "\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\n" + "Function Name: " + "Error Message: UpdateReportLog \n" + e.Message + "\n" + "File: " + pfile + "\n" + "Method: " + mod + "\n\n\n");
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
                to.Add("mpepitone@ehs.com");
                // to.Add("mpepitone@ehs.com");
                message.To.Add(to.ToString());
                message.From = from;
                message.Subject = subject;
                message.Body = msg;
                smtp.Send(message);
            }
        }

        public static void DeleteReportLog(string ReportLogID, string constring)
        {
            string sqlcmd = "DELETE FROM reportlog WHERE ReportLogID = @ReportLogID";

            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@ReportLogID", ReportLogID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
