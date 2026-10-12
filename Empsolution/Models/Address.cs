using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empsolution.Model
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Postcode { get; set; }
        public string? County { get; set; }
        public int CountryID { get; set; }
        public  int EmployeeId { get; set; }    
        public string Country { get; set; }
    }
}
