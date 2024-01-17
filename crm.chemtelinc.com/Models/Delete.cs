using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public static class Delete
    {
     
        #region ChemicalReporter

        public static void DeleteAgencyList(string constring, AgencyList a)
        {
            string strsql = "DELETE FROM agencylist WHERE agencyId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", a.Agency_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteATandTAssociateData(string constring, ATandTAssociateData a)
        {
            string strsql = "DELETE FROM atandtassociatedata WHERE rptid=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", a.Report_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteATandTVolunteerData(string constring, ATandTVolunteerData a)
        {
            string strsql = "DELETE FROM atandtvolunteerdata WHERE rptid=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", a.Report_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteAvailableSpillIDs(string constring, AvailableSpillID a)
        {
            string strsql = "DELETE FROM availablespillids WHERE Id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", a.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteCompanyInformation(string constring, CompanyInformation c)
        {
            string strsql = "DELETE FROM companyinformation WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", c.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteGeneralIncidentIDs(string constring, GeneralIncidentIDs g)
        {
            string strsql = "DELETE FROM generalincidentids WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", g.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteGgeneralIncidentReportData(string constring, GeneralIncidentReportData g)
        {
            string strsql = "DELETE FROM generalincidentreportdata WHERE IncidentId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", g.Incident_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteGLOBaseReportData(string constring, GLOBaseReportData g)
        {
            string strsql = "DELETE FROM globasreportdata WHERE cntSpillId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", g.Spill_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteGLOCountyList(string constring, GLOCountyList g)
        {
            string strsql = "DELETE FROM glocountylist WHERE countyCode=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", g.County_Code);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteGLOEmails(string constring, GLOEmails g)
        {
            string strsql = "DELETE FROM gloemails WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", g.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DdeleteGLOIDs(string constring, GLOID g)
        {
            string strsql = "DELETE FROM gloids WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", g.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteKnowledgeBase(string constring, Knowlegebase k)
        {
            string strsql = "DELETE FROM knowledgebase WHERE knowledgebase_id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", k.Knowledgebase_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteMODRequests(string constring, MODRequest m)
        {
            string strsql = "DELETE FROM modrequests WHERE modrequestid=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", m.MOD_Request_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteNonCoastal(string constring, NonCoastal n)
        {
            string strsql = "DELETE FROM noncoastal WHERE nonCoastalType=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", n.Non_Coastal_Type);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteOldGLO(string constring, OldGLO g)
        {
            string strsql = "DELETE FROM oldglo WHERE cntSpillId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", g.Spill_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteOtherIDs(string constring, OtherID o)
        {
            string strsql = "DELETE FROM otherids WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", o.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteShellOilIncidentData(string constring, ShellOilIncidentData s)
        {
            string strsql = "DELETE FROM shelloilincidentdata WHERE incid=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", s.Inc_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteSpillOrigin(string constring, SpillOrigin s)
        {
            string strsql = "SELETE FROM spillorigin WHERE originId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", s.Origin_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteSpillUnits(string constring, SpillUnits s)
        {
            string strsql = "DELETE FROM spillunits WHERE unitId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", s.Unit_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteCleanShotIDs(string constring, CleanshotIDs c)
        {
            string strsql = "DELETE FROM cleanshotids WHERE id= @id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", c.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteTheoChemCleanShotIncidents(string constring, TheoChemCleanshotIncident t)
        {
            string strsql = "DELETE FROM theochemcleanshotincidents WHERE incidentId=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", t.Incident_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteTheoChemContactInformation(string constring, TheoChemContactInformation t)
        {
            string strsql = "DELETE FROM theochemcontactinformation WHERE contactid=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", t.Contact_ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteTickets(string constring, Ticket t)
        {
            string strsql = "DELETE FROM tickets WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", t.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteCrestGeneralIncident(string constring, CrestGeneralIncident c)
        {
            string strsql = "DELETE FROM crestgeneralincidents WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", c.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        

        public static void DeleteCrestPipelineIncidents(string constring, CrestPipelineIncident c)
        {
            string strsql = "DELETE FROM crestpipelineindents WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", c.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteCrestERS(string constring, CrestERS c)
        {
            string strsql = "DELETE FROM cresters WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", c.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteCrestPipelineMember(string constring, CrestPipelineMember c)
        {
            string strsql = "DELETE FROM crestpipelinemembers WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", c.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteCrestwoodTransportationList(string constring, CrestwoodTransportation t)
        {
            string strsql = "DELETE FROM crestwoodtransportationlist WHERE id=@i";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@i", t.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteCrestwoodAllNotifications(string constring, CrestAllNotifications c)
        {
            string strsql = "DELETE FROM crestallnotifications WHERE id=@i";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@i", c.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteVeoliaNonIncident(string constring, VeoliaNonIncident v)
        {
            string strsql = "DELETE FROM veolianonincident WHERE id=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", v.ID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion
    }
}
