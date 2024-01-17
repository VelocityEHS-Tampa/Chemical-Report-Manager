using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemicalLibrary
{
   public class SAEMMember
    {
        public string Name { get; set; }        
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public SAEMMember(string name, string contactnumber, string email)
        {
            this.Name = name;
            this.ContactNumber = contactnumber;
            this.Email = email;
        }
    }
}
