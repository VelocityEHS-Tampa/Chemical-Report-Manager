using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChemicalLibrary
{
    public class NorthwindEmail
    {
        string _toEmails, _subject, _body, _filepath;

        public string ToEmails
        {
            get { return _toEmails; }
            set { _toEmails = value; }
        }
        public string Subject { get { return _subject; } set { _subject = value; } }
        public string Body { get { return _body; } set { _body = value; } }
        public string FilePath { get { return _filepath; } set { _filepath = value; } }

        public NorthwindEmail()
        {
            _toEmails = "";
            _subject = "";
            _body = "";
            _filepath = "";
        }
    }
}