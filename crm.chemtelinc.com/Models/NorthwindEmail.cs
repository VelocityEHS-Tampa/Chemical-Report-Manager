using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemicalLibrary
{
    public class NorthwindEmail
    {
        string _toEmails, _subject, _body, _filepath, _reporttype;
        int _id;
        public int ID { get { return _id; } set { _id = value; } }
        public string ToEmails
        {
            get { return _toEmails; }
            set { _toEmails = value; }
        }
        public string Subject { get { return _subject; } set { _subject = value; } }
        public string Body { get { return _body; } set { _body = value; } }
        public string FilePath { get { return _filepath; } set { _filepath = value; } }
        public string ReportType { get { return _reporttype; } set { _reporttype = value; } }
        public NorthwindEmail()
        {
            _toEmails = "";
            _subject = "";
            _body = "";
            _filepath = "";
            _reporttype = "";
        }
    }
}