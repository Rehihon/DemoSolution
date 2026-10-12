using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empsolution.Model
{
    public class Contact
    {

        public int ContactId { get; set; }
        public int EmployeeId { get; set; }
        public string Email { get; set; }
        public string HomephoneNumber { get; set; }
        public string MobilPhoneNumber { get; set; }
        public string EmergencyPhoneNumber { get; set; }
        public string EmergencyContactName { get; set; }
        public string Description { get; set; }
    }

}
