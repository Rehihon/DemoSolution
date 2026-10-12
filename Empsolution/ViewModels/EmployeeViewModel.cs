using Empsolution.Model;
using Empsolution.Models;
using Empsolution.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Navigation;


namespace Empsolution.ViewModels
{
    public class EmployeeViewModel : ViewModelBase

    { 
        public string ButtonContent;
        private static ObservableCollection<ScreenValues> _screenValues;
        private ICommand c_ButtonCommand;
        private ICommand c_DepartmentCommand;
        private string? _screenNotify;
        private string? _setScreenValue;
        private EmployeeService _employeeService;
        private Department _deparmentSelectedRecord = new();
        private int processCount = 0;

        private  Employee _employees;
        private List<Department> _departments;
        private List<Contact> _contact;
        private List<Jobs> _jobs;
        private List<Address> _address;
        private int _departmentId = 0;
        private readonly RecordService _recordService;
        private readonly NavigationService _navigationService;
        private List<AddNewEmployees> _newEmployeeRecord = new();
        private List<Employee> _personList;

        private string? _errorMessage;

        public string? ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                }
            }
        }

        private Department _newDepartment;
        public Department NewDepartment
        {
            get { return _newDepartment; }
            set { _newDepartment = value;
                OnPropertyChanged(nameof(NewDepartment));
            }
        }
        
        public List<Employee> PersonList{ 
            get=> _personList ;
            set
            {
                _personList = value;
                OnPropertyChanged(nameof(PersonList));
            }
        }
        public List<AddNewEmployees> NewEmployeeRecord 
        { get { return _newEmployeeRecord; }
        
         set { _newEmployeeRecord = value; 
              OnPropertyChanged(nameof(NewEmployeeRecord)) ; }
         }

        private List<Jobs> _newJobRecord = new();
        public List<Jobs> NewJobRecord
        {
            get { return _newJobRecord; }

            set
            {
                _newJobRecord = value;
                OnPropertyChanged(nameof(NewJobRecord));
            }
        }

        public Employee? SelectedEmployee
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged();

                if (_employees == null)
                {
                    NewDepartment = new Department();
                    return;
                }

                NewDepartment = new Department
                {
                    MangerID = _employees.EmployeeId,
                    NameOfManager =
                        $"{_employees.FirstName} {_employees.Surename}"
                };
            }
        }

        public Department DeparmentSelectedRecord
        {
            get => _deparmentSelectedRecord;
            set
            {
                _deparmentSelectedRecord = value;
                NotifyPropertyChanged(nameof(DeparmentSelectedRecord));
            }
        }

        private Jobs _selectJob = new Jobs();
        public Jobs JobSelectedRecord
        {
            get => _selectJob;
            set
            {
                _selectJob = value;
                NotifyPropertyChanged(nameof(JobSelectedRecord));
            }
        }
        public List<Department> Departments { get=> _recordService.GetDepartmentRecords(); }

        public List<Employee> Employees { get =>_recordService.GetEmployeeRecords(); }
        public List<Address> Address { get => _recordService.GetEmpAddressRecords(); } 
        public List<Contact> Contacts { get => _recordService.GetEmpContactRecords(); } 
        public List<Jobs> Jobs { get  => _recordService.GetEmpJobRecords(); }

        public ICommand ButtonCommand
        {
            get
            {
                return c_ButtonCommand;
            }
            set
            {
                c_ButtonCommand = value;
            }
        }


        public void GetPersonList(string name)
        {
            _personList = new List<Employee>(
                Employees.Where(a => a.FirstName == name).ToList()


             );   

        }

        private  ScreenValues _selectedPerson;
        public ScreenValues SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                _selectedPerson = value;
               
                NotifyPropertyChanged(nameof(SelectedPerson));
            }
        }

        private AddNewEmployees _addNewEmployees;
        public AddNewEmployees SelectedNewEmployee
        {
            get => _addNewEmployees;
            set
            {
                _addNewEmployees = value;
                
                NotifyPropertyChanged(nameof(SelectedNewEmployee));
            }
        }

        private string _searchValue;
        public string SearchValue
        {
            get => _searchValue;

            set
            {
                if (_searchValue != value)
                {
                    _searchValue = value;
                    NotifyPropertyChanged(nameof(SearchValue));
                    SelectEmployee();
                }

            }
        }

        public void SelectEmployee()
        {
            if (string.IsNullOrWhiteSpace(SearchValue))
            {
                PersonList = new List<Employee>();
                return;
            }

            try
            {
                PersonList = Employees
                    .Where(x =>
                        (x.FirstName?.Contains(
                            SearchValue,
                            StringComparison.OrdinalIgnoreCase) ?? false) ||
                        (x.Surename?.Contains(
                            SearchValue,
                            StringComparison.OrdinalIgnoreCase) ?? false))
                    .ToList();

                ErrorMessage = null;
            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, "Error searching employees.");

                PersonList = new List<Employee>();
                ErrorMessage = "Unable to search employees.";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }


        public ObservableCollection<ScreenValues> ScreenValueRecords
        { get => _recordService.GetScreenRecords(_departmentId); }


        public ICommand SubmitCommand
        {
            get
            {
                if (c_ButtonCommand == null)
                {
                    c_ButtonCommand = new RelayCommand(param => this.AsyncButton_Click(), null
                        );
                }
                return c_ButtonCommand;
            }
        }

        public ICommand SubmitDeptCommand
        {
            get
            {
                if (c_DepartmentCommand == null)
                {

                    c_DepartmentCommand = new RelayCommand(param => this.AsyncSaveDept_Click(), null
                        );
                }
                return c_DepartmentCommand;
            }
        }

        public EmployeeViewModel(EmployeeService employeeService)
            
        {

            _employeeService = employeeService;
            
            //ScreenValues = new ScreenValues();
        }
        public EmployeeViewModel()
        {
            _employeeService = App.Host.Services.GetRequiredService<EmployeeService>();
            _recordService = App.Host.Services.GetRequiredService<RecordService>();
        }
        
        public EmployeeViewModel(EmployeeService employeeService, RecordService recordService)
        {
            _recordService = recordService;
            _employeeService = employeeService;
           // LoadDataAsync();
        } 

        public async Task InitializeAsync()
        {
            await _recordService.InitializeRecordAsync(_employeeService);
           // await LoadDataAsync();
        }

        private ObservableCollection<ScreenValues> Newrecords = new();
        public async Task AsyncButton_Click()
        {
            if (NewEmployeeRecord.Count() > 0)
            {
                foreach (var record in NewEmployeeRecord)
                {
                    record.DepID = DeparmentSelectedRecord.DepID;
                    record.JobID = JobSelectedRecord.JobID;
                  ////  _newEmployeeRecord.Add(record);
                }
                var newRecords = await _employeeService.CreateEmplyeeRecordsAsync(NewEmployeeRecord);
                foreach (var record in newRecords)
                {
                    Newrecords.Add(record);
                }
                _recordService.AddScreenRecord(Newrecords);
            }
        }
            
        public async Task AsyncSaveDept_Click()
        {
            if (!(NewDepartment==null))
            {   
                    var newRecords = await _employeeService.CreateDepartmentAsync(NewDepartment);
            }
        }

        public void Combo_SelectionChanged(int depId)
        {
            _departmentId = depId;
            OnPropertyChanged(nameof(ScreenValueRecords));
        }

        public ObservableCollection<Employee> People { get; }
       
    }

}
