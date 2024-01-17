using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemicalLibrary
{
    public class TCEQEmailContact
    {
        public string Reqion { get; set; }
        /*public string PrimaryContact { get; set; }
        public string SecondaryContact { get; set; }
        public string TertiaryContact { get; set; }
        public string RegionalDirector { get; set; }*/
        public string EmailAddress { get; set; }

      //  public TCEQEmailContact(string region,string primary,string second,string tertiary,string regionaldirector, string emailaddress)
       public TCEQEmailContact(string region, string emailaddress)
        {
            this.Reqion=region;
            /*this.PrimaryContact=primary;
            this.SecondaryContact=second;
            this.TertiaryContact=tertiary;
            this.RegionalDirector=regionaldirector;*/
            this.EmailAddress=emailaddress;        
        }
    }
}
