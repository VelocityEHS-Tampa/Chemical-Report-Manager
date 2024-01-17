using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crm.chemtelinc.com.Models
{
    public class NovartisLookup
    {
        private int _id;
        private string _division, _site, _country, _hsesite, _countrycode, _primarycontact, _primarynumber, _phonecode;
        private string _primarycontactemail, _secondarycontact, _secondarycontactemail, _translator, _language, _injurycontact;
        private string _injuryemail, _injuryphonenumber, _releasecontact, _releasephonenumber, _releaseemail, _dateregistered;

        #region Public Variables
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Division
        {
            get { return _division; }
            set { _division = value; }
        }
        public string Site
        {
            get { return _site; }
            set { _site = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string hseSite
        {
            get { return _hsesite; }
            set { _hsesite = value; }
        }
        public string CountryCode
        {
            get { return _countrycode; }
            set { _countrycode = value; }
        }
        public string PrimaryContact
        {
            get { return _primarycontact; }
            set { _primarycontact = value; }
        }
        public string PrimaryNumber
        {
            get { return _primarynumber; }
            set { _primarynumber = value; }
        }
        public string PhoneCode
        {
            get { return _phonecode; }
            set { _phonecode = value; }
        }
        public string PrimaryContactEmail
        {
            get { return _primarycontactemail; }
            set { _primarycontactemail = value; }
        }
        public string SecondaryContact
        {
            get { return _secondarycontact; }
            set { _secondarycontact = value; }
        }
        public string SecondaryContactEmail
        {
            get { return _secondarycontactemail; }
            set { _secondarycontactemail = value; }
        }
        public string Translator
        {
            get { return _translator; }
            set { _translator = value; }
        }
        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }
        public string InjuryContact
        {
            get { return _injurycontact; }
            set { _injurycontact = value; }
        }
        public string InjuryPhoneNumber
        {
            get { return _injuryphonenumber; }
            set { _injuryphonenumber = value; }
        }
        public string InjuryEmail
        {
            get { return _injuryemail; }
            set { _injuryemail = value; }
        }
        public string ReleaseContact
        {
            get { return _releasecontact; }
            set { _releasecontact = value; }
        }
        public string ReleasePhoneNumber
        {
            get { return _releasephonenumber; }
            set { _releasephonenumber = value; }
        }
        public string ReleaseEmail
        {
            get { return _releaseemail; }
            set { _releaseemail = value; }
        }
        public string DateRegistered
        {
            get { return _dateregistered; }
            set { _dateregistered = value; }
        }
        #endregion

        public NovartisLookup()
        {
            _id = 0;
            _division = "";
            _site = "";
            _country = "";
            _hsesite = "";
            _countrycode = "";
            _primarycontact = "";
            _primarynumber = "";
            _phonecode = "";
            _primarycontactemail = "";
            _secondarycontact = "";
            _secondarycontactemail = "";
            _translator = "";
            _language = "";
            _injurycontact = "";
            _injuryphonenumber = "";
            _injuryemail = "";
            _releasecontact = "";
            _releasephonenumber = "";
            _releaseemail = "";
            _dateregistered = "";
        }
    }
}