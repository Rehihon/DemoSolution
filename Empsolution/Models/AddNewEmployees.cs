using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empsolution.Models
{
    public class AddNewEmployees
    {
    public string? FirstName { get; set; }
    public string? Surename { get; set; }
    public DateOnly? HireDate { get; set; }
    public DateOnly? DOB { get; set; }
    public int JobID { get; set; }
    public int DepID { get; set; }
    public string Line1 { get; set; }
    public string? Line2 { get; set; }
    public string? Postcode { get; set; }
    public string? County { get; set; }
    public string Country { get; set; } 
    public string Email { get; set; }
    public string HomephoneNumber { get; set; }
     public string MobilPhoneNumber { get; set; }
    public string EmergencyPhoneNumber { get; set; }
    public string EmergencyContactName { get; set; }
    public string Description { get; set; }

    }
}
