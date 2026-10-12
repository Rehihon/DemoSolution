using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empsolution.Model
{
    public class Jobs
    {
        public int JobID { get; set; }
        public string? Job_Title { get; set; }
        public decimal Min_salary { get; set; }
        public decimal Max_Salary { get; set; }
        public string? Description { get; set; }
    }
}

