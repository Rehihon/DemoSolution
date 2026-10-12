using Empsolution.Model;
using Empsolution.Service;
using System.Collections.ObjectModel;
namespace Empsolution.ViewModels
{


    public class RecordService :ViewModelBase
    {

        public RecordService()
        {
        }
       

        public static List<Employee> _employees;
        public  static List<Department> _department { get; set; }
        public static List<Department> Departments
        {
            get => _department;
        }

        public static List<Employee> Employees 
        {
             get => _employees; 
          
          set{ _employees = value; }
        }


        private static List<Address> _addresses;

        private static List<Address> Address { get => _addresses;
            set
            {
                _addresses = value;
               
            }
        }
        private  static List<Contact> _contact;
        private static List<Contact> Contacts { get => _contact;
            set
            {
                _contact = value;
            }
        }
        private  static List<Jobs> _jobs;    
        private static List<Jobs> Jobs
        {
            get => _jobs;
            set
            {
                _jobs = value;
            }
        }
        private static ObservableCollection<ScreenValues> _screenValues;
        private  ObservableCollection<ScreenValues> ScreenValues
        {
            get => _screenValues;
            set
            {
                _screenValues = value;
            }
        }
        public ScreenValues GetSingleScreenRecord(int employeeId)
        {
            var record =  ScreenValues 
                .FirstOrDefault(x => x.EmployeeId == employeeId);
            return record;
        }

        public ObservableCollection<ScreenValues> GetScreenRecords(int depId)
        {
            var depid = depId;
             var  record = new ObservableCollection<ScreenValues>(
                 ScreenValues.Where(x => x.DepID == depId));
            return record;

        }
        public void AddScreenRecord(ObservableCollection<ScreenValues> records)
        {
            foreach (var record in records)
            {
                _screenValues.Add(record);
                OnPropertyChanged(nameof(ScreenValues));
            }
        }
        public   List<Employee> GetEmployeeRecords()
        {
            return _employees;
        }
        public void AddEmployeeRecord(List<Employee> records)
        {
            _employees.AddRange(records);
           
        }

        public List<Department> GetDepartmentRecords()
        {
            return Departments;
        }
        public void AddDepartmentRecord(List<Department> records)
        {
          _department.AddRange(records);
        }

        public List<Contact> GetEmpContactRecords()
        {
            return Contacts;
        }
        public void AddContactRecord(List<Contact> records)
        {
            _contact.AddRange(records);
        }

        public List<Address> GetEmpAddressRecords()
        {
            return Address;
        }
        public void AddAddressRecord(List<Address> records)
        {
            _addresses.AddRange(records);
        }

        public List<Jobs> GetEmpJobRecords()
        {
            return Jobs;
        }
        public void AddJobRecord(List<Jobs> records)
        {
            var _record = records;
            foreach (var job in _record)
            _jobs.Add(job);
            OnPropertyChanged(nameof(Jobs));
        }

        public async Task InitializeRecordAsync(EmployeeService employeeService)
        {
          var _employeeService = employeeService;
            await LoadDataAsync(_employeeService);
        }

        private async Task LoadDataAsync(EmployeeService employeeService)
        {
          var  _employeeService = employeeService;
            _employees = await _employeeService.GetEmployeeAsync();
            
            var _departments = await _employeeService.GetDepartmentAsync();

            foreach (var record in _departments)
            {
                record.NameOfManager = _employees
                     .Where(a => a.EmployeeId == record.MangerID)
                     .Select(a => a.FirstName + " " + a.Surename)
                     .FirstOrDefault();
                
            }
            _department= _departments;

            _addresses = await _employeeService.GetAddressAsync();
            _jobs = await _employeeService.GetJobsAsync();

            _contact = await _employeeService.GetContactAsync();

            SelectScreenValues();
        }
        public ObservableCollection<Employee> People { get; }
        private void SelectScreenValues()
        {
            _screenValues = new ObservableCollection<ScreenValues>(
              from emp in Employees
              join dept in Departments on emp.DepId equals dept.DepID
              join addr in Address on emp.EmployeeId equals addr.EmployeeId
              join contact in Contacts on emp.EmployeeId equals contact.EmployeeId
               join man in Employees on dept.MangerID equals man.EmployeeId
              join job in Jobs on emp.JobID equals job.JobID
              select new ScreenValues
              {
                  EmployeeId = emp.EmployeeId,
                  FirstName = emp.FirstName,
                  Surename = emp.Surename,
                  DOB= emp.DOB,
                  HireDate = emp.HireDate,
                  JobID = job.JobID,
                  DepID = dept.DepID,
                  JobTitle = job.Job_Title,
                  MangerID = dept.MangerID,
                  ManagerName = man.FirstName + ' ' + man.Surename,
                  DepName = dept.DepName,
                  ContactId = contact.ContactId,
                  Email = contact.Email,
                  Description = contact.Description,
                  HomephoneNumber = contact.HomephoneNumber,
                  MobilePhoneNumber = contact.MobilPhoneNumber,
                  EmergencyPhoneNumber = contact.EmergencyPhoneNumber,
                  EmergencyContactName = contact.EmergencyContactName,
                  CurrentAddress = new Address
                  {
                      AddressId = addr.AddressId,
                      Line1 = addr.Line1,
                      Line2 = addr.Line2,
                      Country = addr.Country,
                      County = addr.County,
                      Postcode = addr.Postcode
                  }
              });
        }
    }
}