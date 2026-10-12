using Empsolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empsolution.Model
{
    public class ScreenValues
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string Surename { get; set; }
        public int? CountactID { get; set; }
        public DateOnly? HireDate { get; set; }
        public int JobID { get; set; }
        public DateOnly? DOB  {get;set;}
        public int DepID { get; set; }
        public string DepName { get; set; }
        public int ContactId { get; set; }
        public string Email { get; set; }
        public string HomephoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string EmergencyPhoneNumber { get; set; }
        public string EmergencyContactName { get; set; }
        public string JobTitle { get; set; }
        public string ManagerName { get; set; }
        public int MangerID { get; set; }
        public Address CurrentAddress { get; set; }
        public string? FsrtValue { get; set; }
        public string? SCdValue { get; set; }
        public string? SumValue { get; set; }
        public bool? Display { get; set; }
        public string? ContactTYpe { get; set; }
        public string Screenmessage { get; set; }
        public string Description { get; set; }


    }
}
