using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empsolution.Model
{
    public class Department
    {
        public int DepID { get; set; }
        public string? DepName { get; set; }
        public int MangerID { get; set; }
        public int AddressId { get; set; }
        public string? NameOfManager { get; set; }
        public string? Description {  get; set; }


    }
}
