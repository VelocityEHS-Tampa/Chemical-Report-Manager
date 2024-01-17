using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crm.chemtelinc.com.Models
{
    public class MSDSSearch
    {
        private string _id, _company, _productname, _language, _manufacturer, _productnumber, _date, _mis, _filename, _commonname;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }
        public string ProductName
        {
            get { return _productname; }
            set { _productname = value; }
        }
        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }
        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }
        public string ProductNumber
        {
            get { return _productnumber; }
            set { _productnumber = value; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public string MIS
        {
            get { return _mis; }
            set { _mis = value; }
        }
        public string FileName
        {
            get { return _filename; }
            set { _filename = value; }
        }
        public string CommonName
        {
            get { return _commonname; }
            set { _commonname = value; }
        }

        public MSDSSearch()
        {
            _company = "";
            _productname = "";
            _language = "";
            _manufacturer = "";
            _productnumber = "";
            _date = "";
            _mis = "";
            _filename = "";
            _commonname = "";
        }
    }
}