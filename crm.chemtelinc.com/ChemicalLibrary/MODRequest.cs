using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ChemicalLibrary
{
    public class MODRequest
    {
        #region Private Fields

        private int _modrequestid;
        private string _ersoperator, _companyname, _nameofcaller, _phone, _ext, _fax, _email, _sendingmethod, _modclient, _datereceived, _datefulfilled, _comments, _prodname1, _manu1;
        private string _qty1, _locatedvia1, _prodname2, _manu2, _qty2, _locatedvia2, _prodname3, _manu3, _qty3, _locatedvia3, _prodname4, _manu4, _qty4, _locatedvia4, _prodname5;
        private string _manu5, _qty5, _locatedvia5, _prodname6, _manu6, _qty6, _locatedvia6, _prodname7, _manu7, _qty7, _locatedvia7, _prodname8, _manu8, _qty8, _locatedvia8, _prodname9;
        private string _manu9, _qty9, _locatedvia9, _prodname10, _manu10, _qty10, _locatedvia10, _totalcost, _price1, _price2, _price3, _price4, _price5, _price6, _price7, _price8;
        private string _price9, _price10, _totalqty, _monthreceived, _yearreceived;

        #endregion
        #region Public Properties
        #region Ints

        public int MOD_Request_ID
        {
            get { return _modrequestid; }
            set { _modrequestid = value; }
        }

        #endregion
        #region Strings

        public string Ers_Operator
        {
            get { return _ersoperator; }
            set { _ersoperator = value; }
        }

        public string Company_Name
        {
            get { return _companyname; }
            set { _companyname = value; }
        }

        public string Name_Of_Caller
        {
            get { return _nameofcaller; }
            set { _nameofcaller = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Ext
        {
            get { return _ext; }
            set { _ext = value; }
        }

        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Sending_Method
        {
            get { return _sendingmethod; }
            set { _sendingmethod = value; }
        }

        public string MOD_Client
        {
            get { return _modclient; }
            set { _modclient = value; }
        }

        public string Date_Received
        {
            get { return _datereceived; }
            set { _datereceived = value; }
        }

        public string Date_Fulfilled
        {
            get { return _datefulfilled; }
            set { _datefulfilled = value; }
        }

        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public string Product_Name_1
        {
            get { return _prodname1; }
            set { _prodname1 = value; }
        }

        public string Product_Name_2
        {
            get { return _prodname2; }
            set { _prodname2 = value; }
        }

        public string Product_Name_3
        {
            get { return _prodname3; }
            set { _prodname3 = value; }
        }

        public string Product_Name_4
        {
            get { return _prodname4; }
            set { _prodname4 = value; }
        }

        public string Product_Name_5
        {
            get { return _prodname5; }
            set { _prodname5 = value; }
        }

        public string Product_Name_6
        {
            get { return _prodname6; }
            set { _prodname6 = value; }
        }

        public string Product_Name_7
        {
            get { return _prodname7; }
            set { _prodname7 = value; }
        }

        public string Product_Name_8
        {
            get { return _prodname8; }
            set { _prodname8 = value; }
        }

        public string Product_Name_9
        {
            get { return _prodname9; }
            set { _prodname9 = value; }
        }

        public string Product_Name_10
        {
            get { return _prodname10; }
            set { _prodname10 = value; }
        }

        public string Manu_1
        {
            get { return _manu1; }
            set { _manu1 = value; }
        }

        public string Manu_2
        {
            get { return _manu2; }
            set { _manu2 = value; }
        }

        public string Manu_3
        {
            get { return _manu3; }
            set { _manu3 = value; }
        }

        public string Manu_4
        {
            get { return _manu4; }
            set { _manu4 = value; }
        }

        public string Manu_5
        {
            get { return _manu5; }
            set { _manu5 = value; }
        }

        public string Manu_6
        {
            get { return _manu6; }
            set { _manu6 = value; }
        }

        public string Manu_7
        {
            get { return _manu7; }
            set { _manu7 = value; }
        }

        public string Manu_8
        {
            get { return _manu8; }
            set { _manu8 = value; }
        }

        public string Manu_9
        {
            get { return _manu9; }
            set { _manu9 = value; }
        }

        public string Manu_10
        {
            get { return _manu10; }
            set { _manu10 = value; }
        }

        public string Qty_1
        {
            get { return _qty1; }
            set { _qty1 = value; }
        }

        public string Qty_2
        {
            get { return _qty2; }
            set { _qty2 = value; }
        }

        public string Qty_3
        {
            get { return _qty3; }
            set { _qty3 = value; }
        }

        public string Qty_4
        {
            get { return _qty4; }
            set { _qty4 = value; }
        }

        public string Qty_5
        {
            get { return _qty5; }
            set { _qty5 = value; }
        }

        public string Qty_6
        {
            get { return _qty6; }
            set { _qty6 = value; }
        }

        public string Qty_7
        {
            get { return _qty7; }
            set { _qty7 = value; }
        }

        public string Qty_8
        {
            get { return _qty8; }
            set { _qty8 = value; }
        }

        public string Qty_9
        {
            get { return _qty9; }
            set { _qty9 = value; }
        }

        public string Qty_10
        {
            get { return _qty10; }
            set { _qty10 = value; }
        }
        
        public string Located_Via_1
        {
            get { return _locatedvia1; }
            set { _locatedvia1 = value; }
        }

        public string Located_Via_2
        {
            get { return _locatedvia2; }
            set { _locatedvia2 = value; }
        }

        public string Located_Via_3
        {
            get { return _locatedvia3; }
            set { _locatedvia3 = value; }
        }

        public string Located_Via_4
        {
            get { return _locatedvia4; }
            set { _locatedvia4 = value; }
        }

        public string Located_Via_5
        {
            get { return _locatedvia5; }
            set { _locatedvia5 = value; }
        }

        public string Located_Via_6
        {
            get { return _locatedvia6; }
            set { _locatedvia6 = value; }
        }

        public string Located_Via_7
        {
            get { return _locatedvia7; }
            set { _locatedvia7 = value; }
        }

        public string Located_Via_8
        {
            get { return _locatedvia8; }
            set { _locatedvia8 = value; }
        }

        public string Located_Via_9
        {
            get {return _locatedvia9;}
            set { _locatedvia9 = value; }
        }

        public string Located_Via_10
        {
            get {return _locatedvia10;}
            set {_locatedvia10=value;}
        }

        public string Total_Cost
        {
            get {return _totalcost;}
            set {_totalcost=value;}
        }

        public string Price_1
        {
            get {return _price1;}
            set {_price1=value;}
        }

        public string Price_2
        {
            get {return _price2;}
            set {_price2=value;}
        }

        public string Price_3
        {
            get {return _price3;}
            set {_price3=value;}
        }

        public string Price_4
        {
            get {return _price4;}
            set {_price4=value;}
        }

        public string Price_5
        {
            get {return _price5;}
            set {_price5=value;}
        }

        public string Price_6
        {
            get {return _price6;}
            set {_price6=value;}
        }

        public string Price_7
        {
            get {return _price7;}
            set {_price7=value;}
        }

        public string Price_8
        {
            get {return _price8;}
            set {_price8=value;}
        }

        public string Price_9
        {
            get {return _price9;}
            set {_price9=value;}
        }

        public string Price_10
        {
            get {return _price10;}
            set {_price10=value;}
        }

        public string Total_Qty
        {
            get {return _totalqty;}
            set {_totalqty=value;}
        }

        public string Month_Received
        {
            get {return _monthreceived;}
            set {_monthreceived=value;}
        }

        public string Year_Received
        {
            get {return _yearreceived;}
            set {_yearreceived=value;}
        }

        #endregion
        #endregion
        #region Public Constructors

        public MODRequest()
        {
            _modrequestid = 0;
            _ersoperator = "";
            _companyname = "";
            _nameofcaller = "";
            _phone = "";
            _ext = "";
            _fax = "";
            _email = "";
            _sendingmethod = "";
            _modclient = "";
            _datereceived = "";
            _datefulfilled = "";
            _comments = "";
            _prodname1 = "";
            _prodname2 = "";
            _prodname3 = "";
            _prodname4 = "";
            _prodname5 = "";
            _prodname6 = "";
            _prodname7 = "";
            _prodname8 = "";
            _prodname9 = "";
            _prodname10 = "";
            _manu1 = "";
            _manu2 = "";
            _manu3 = "";
            _manu4 = "";
            _manu5 = "";
            _manu6 = "";
            _manu7 = "";
            _manu8 = "";
            _manu9 = "";
            _manu10 = "";
            _qty1 = "";
            _qty2 = "";
            _qty3 = "";
            _qty4 = "";
            _qty5 = "";
            _qty6 = "";
            _qty7 = "";
            _qty8 = "";
            _qty9 = "";
            _qty10 = "";
            _locatedvia1 = "";
            _locatedvia2 = "";
            _locatedvia3 = "";
            _locatedvia4 = "";
            _locatedvia5 = "";
            _locatedvia6 = "";
            _locatedvia7 = "";
            _locatedvia8 = "";
            _locatedvia9 = "";
            _locatedvia10 = "";
            _totalcost = "";
            _price1 = "";
            _price2 = "";
            _price3 = "";
            _price4 = "";
            _price5 = "";
            _price6 = "";
            _price7 = "";
            _price8 = "";
            _price9 = "";
            _price10 = "";
            _totalqty = "";
            _monthreceived = "";
            _yearreceived = "";
        }

        public MODRequest(string constring, int id)
        {
            this.MOD_Request_ID = id;
            SearchMODRequestsByID(constring);
        }

        public MODRequest(string constring, string name)
        {
            this.Company_Name = name;
            SearchMODRequestsByCompanyName(constring);
        }

        #endregion
        #region Search Methods

        public void SearchMODRequestsByID(string constring)
        {
            string strsql = "SELECT * FROM modrequests WHERE modrequestid=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.MOD_Request_ID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.MOD_Request_ID = int.Parse(rdr["modrequestid"].ToString());
                        this.Ers_Operator = rdr["ersoperator"].ToString();
                        this.Company_Name = rdr["companyname"].ToString();
                        this.Name_Of_Caller = rdr["nameofcaller"].ToString();
                        this.Phone = rdr["phone"].ToString();
                        this.Ext = rdr["ext"].ToString();
                        this.Fax = rdr["fax"].ToString();
                        this.Email = rdr["email"].ToString();
                        this.Sending_Method = rdr["sendingmethod"].ToString();
                        this.MOD_Client = rdr["modclient"].ToString();
                        this.Date_Received = rdr["datereceived"].ToString();
                        this.Date_Fulfilled = rdr["datefulfilled"].ToString();
                        this.Comments = rdr["comments"].ToString();
                        this.Product_Name_1 = rdr["prodname1"].ToString();
                        this.Product_Name_2 = rdr["prodname2"].ToString();
                        this.Product_Name_3 = rdr["prodname3"].ToString();
                        this.Product_Name_4 = rdr["prodname4"].ToString();
                        this.Product_Name_5 = rdr["prodname5"].ToString();
                        this.Product_Name_6 = rdr["prodname6"].ToString();
                        this.Product_Name_7 = rdr["prodname7"].ToString();
                        this.Product_Name_8 = rdr["prodname8"].ToString();
                        this.Product_Name_9 = rdr["prodname9"].ToString();
                        this.Product_Name_10 = rdr["prodname10"].ToString();
                        this.Manu_1 = rdr["manu1"].ToString();
                        this.Manu_2 = rdr["manu2"].ToString();
                        this.Manu_3 = rdr["manu3"].ToString();
                        this.Manu_4 = rdr["manu4"].ToString();
                        this.Manu_5 = rdr["manu5"].ToString();
                        this.Manu_6 = rdr["manu6"].ToString();
                        this.Manu_7 = rdr["manu7"].ToString();
                        this.Manu_8 = rdr["manu8"].ToString();
                        this.Manu_9 = rdr["manu9"].ToString();
                        this.Manu_10 = rdr["manu10"].ToString();
                        this.Qty_1 = rdr["qty1"].ToString();
                        this.Qty_2 = rdr["qty2"].ToString();
                        this.Qty_3 = rdr["qty3"].ToString();
                        this.Qty_4 = rdr["qty4"].ToString();
                        this.Qty_5 = rdr["qty5"].ToString();
                        this.Qty_6 = rdr["qty6"].ToString();
                        this.Qty_7 = rdr["qty7"].ToString();
                        this.Qty_8 = rdr["qty8"].ToString();
                        this.Qty_9 = rdr["qty9"].ToString();
                        this.Qty_10 = rdr["qty10"].ToString();
                        this.Located_Via_1 = rdr["locatedvia1"].ToString();
                        this.Located_Via_2 = rdr["locatedvia2"].ToString();
                        this.Located_Via_3 = rdr["locatedvia3"].ToString();
                        this.Located_Via_4 = rdr["locatedvia4"].ToString();
                        this.Located_Via_5 = rdr["locatedvia5"].ToString();
                        this.Located_Via_6 = rdr["locatedvia6"].ToString();
                        this.Located_Via_7 = rdr["locatedvia7"].ToString();
                        this.Located_Via_8 = rdr["locatedvia8"].ToString();
                        this.Located_Via_9 = rdr["locatedvia9"].ToString();
                        this.Located_Via_10 = rdr["locatedvia10"].ToString();
                        this.Total_Cost = rdr["totalcost"].ToString();
                        this.Price_1 = rdr["price1"].ToString();
                        this.Price_2 = rdr["price2"].ToString();
                        this.Price_3 = rdr["price3"].ToString();
                        this.Price_4 = rdr["price4"].ToString();
                        this.Price_5 = rdr["price5"].ToString();
                        this.Price_6 = rdr["price6"].ToString();
                        this.Price_7 = rdr["price7"].ToString();
                        this.Price_8 = rdr["price8"].ToString();
                        this.Price_9 = rdr["price9"].ToString();
                        this.Price_10 = rdr["price10"].ToString();
                        this.Total_Qty = rdr["totalqty"].ToString();
                        this.Month_Received = rdr["monthreceived"].ToString();
                        this.Year_Received = rdr["yearreceived"].ToString();
                    }
                }
            }
        }

        public void SearchMODRequestsByCompanyName(string constring)
        {
            string strsql = "SELECT * FROM modrequests WHERE companyname=@id";
            using (SqlConnection cn = new SqlConnection(constring))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand(strsql, cn))
                {
                    cmd.Parameters.AddWithValue("@id", this.Company_Name);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        this.MOD_Request_ID = int.Parse(rdr["modrequestid"].ToString());
                        this.Ers_Operator = rdr["ersoperator"].ToString();
                        this.Company_Name = rdr["companyname"].ToString();
                        this.Name_Of_Caller = rdr["nameofcaller"].ToString();
                        this.Phone = rdr["phone"].ToString();
                        this.Ext = rdr["ext"].ToString();
                        this.Fax = rdr["fax"].ToString();
                        this.Email = rdr["email"].ToString();
                        this.Sending_Method = rdr["sendingmethod"].ToString();
                        this.MOD_Client = rdr["modclient"].ToString();
                        this.Date_Received = rdr["datereceived"].ToString();
                        this.Date_Fulfilled = rdr["datefulfilled"].ToString();
                        this.Comments = rdr["comments"].ToString();
                        this.Product_Name_1 = rdr["prodname1"].ToString();
                        this.Product_Name_2 = rdr["prodname2"].ToString();
                        this.Product_Name_3 = rdr["prodname3"].ToString();
                        this.Product_Name_4 = rdr["prodname4"].ToString();
                        this.Product_Name_5 = rdr["prodname5"].ToString();
                        this.Product_Name_6 = rdr["prodname6"].ToString();
                        this.Product_Name_7 = rdr["prodname7"].ToString();
                        this.Product_Name_8 = rdr["prodname8"].ToString();
                        this.Product_Name_9 = rdr["prodname9"].ToString();
                        this.Product_Name_10 = rdr["prodname10"].ToString();
                        this.Manu_1 = rdr["manu1"].ToString();
                        this.Manu_2 = rdr["manu2"].ToString();
                        this.Manu_3 = rdr["manu3"].ToString();
                        this.Manu_4 = rdr["manu4"].ToString();
                        this.Manu_5 = rdr["manu5"].ToString();
                        this.Manu_6 = rdr["manu6"].ToString();
                        this.Manu_7 = rdr["manu7"].ToString();
                        this.Manu_8 = rdr["manu8"].ToString();
                        this.Manu_9 = rdr["manu9"].ToString();
                        this.Manu_10 = rdr["manu10"].ToString();
                        this.Qty_1 = rdr["qty1"].ToString();
                        this.Qty_2 = rdr["qty2"].ToString();
                        this.Qty_3 = rdr["qty3"].ToString();
                        this.Qty_4 = rdr["qty4"].ToString();
                        this.Qty_5 = rdr["qty5"].ToString();
                        this.Qty_6 = rdr["qty6"].ToString();
                        this.Qty_7 = rdr["qty7"].ToString();
                        this.Qty_8 = rdr["qty8"].ToString();
                        this.Qty_9 = rdr["qty9"].ToString();
                        this.Qty_10 = rdr["qty10"].ToString();
                        this.Located_Via_1 = rdr["locatedvia1"].ToString();
                        this.Located_Via_2 = rdr["locatedvia2"].ToString();
                        this.Located_Via_3 = rdr["locatedvia3"].ToString();
                        this.Located_Via_4 = rdr["locatedvia4"].ToString();
                        this.Located_Via_5 = rdr["locatedvia5"].ToString();
                        this.Located_Via_6 = rdr["locatedvia6"].ToString();
                        this.Located_Via_7 = rdr["locatedvia7"].ToString();
                        this.Located_Via_8 = rdr["locatedvia8"].ToString();
                        this.Located_Via_9 = rdr["locatedvia9"].ToString();
                        this.Located_Via_10 = rdr["locatedvia10"].ToString();
                        this.Total_Cost = rdr["totalcost"].ToString();
                        this.Price_1 = rdr["price1"].ToString();
                        this.Price_2 = rdr["price2"].ToString();
                        this.Price_3 = rdr["price3"].ToString();
                        this.Price_4 = rdr["price4"].ToString();
                        this.Price_5 = rdr["price5"].ToString();
                        this.Price_6 = rdr["price6"].ToString();
                        this.Price_7 = rdr["price7"].ToString();
                        this.Price_8 = rdr["price8"].ToString();
                        this.Price_9 = rdr["price9"].ToString();
                        this.Price_10 = rdr["price10"].ToString();
                        this.Total_Qty = rdr["totalqty"].ToString();
                        this.Month_Received = rdr["monthreceived"].ToString();
                        this.Year_Received = rdr["yearreceived"].ToString();
                    }
                }
            }
        }

        #endregion
    }
}
