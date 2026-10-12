using Empsolution.Model;
using Empsolution.Models;
using Empsolution.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Empsolution.ViewModels
{

    public class EditRecordsViewModel : ViewModelBase
    {
        public string ButtonContent;
        private static ScreenValues _singlescreenValues; 
        private static ObservableCollection<ScreenValues> _screenValues;
        private ICommand c_saveContactCommand;
        private ICommand c_saveAddressCommand;
        private ICommand c_saveEmployeeCommand;
        private string? _screenNotify;
        private string? _setScreenValue;
        private EmployeeService _employeeService;
        private Department _deparmentSelectedRecord = new();
        private int processCount = 0;

        private Employee _employees;
        private List<Department> _departments;
        private List<Contact> _contacts;
        private List<Jobs> _jobs;
        private List<Address> _address;
        private Address _editAddress;
        private Contact _contact;
        private readonly RecordService _recordService;
        private readonly NavigationService _navigationService;
        private List<AddNewEmployees> _newEmployeeRecord = new();
        private List<Employee> _personList;

        private Department _newDepartment;


        public List<Department> Departments { get => _recordService.GetDepartmentRecords(); }

        public List<Jobs> Jobs { get => _recordService.GetEmpJobRecords(); }
        public Employee EditEmployee
        {
            get => _employees;
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(EditEmployee));
            }
        }

        public Contact EditContact
        {
            get => _contact;
            set
            {
                _contact = value;
                OnPropertyChanged(nameof(EditContact));
            }
        }
         public ScreenValues SingleScreenValue
        {
            get => _singlescreenValues;
            set
            {
                _singlescreenValues = value;
            }
        }

        public Address EditAddress
        {
            get => _editAddress;
            set
            {
                _editAddress = value;
                OnPropertyChanged(nameof(EditAddress));
            }
        }


        public void GetEmployee(Employee employee)
        {
            _employees = employee;
            _singlescreenValues = _recordService.GetSingleScreenRecord(employee.EmployeeId);
        }

        public void SetAddress(Address address)
        {
            _editAddress = address;
            _singlescreenValues = _recordService.GetSingleScreenRecord(address.EmployeeId);
        }

        public void SetContact(Contact contact)
        {
            _contact = contact;
            _singlescreenValues = _recordService.GetSingleScreenRecord(contact.EmployeeId);
        }


        public EditRecordsViewModel()
        {
            _employeeService = App.Host.Services.GetRequiredService<EmployeeService>();
            _recordService = App.Host.Services.GetRequiredService<RecordService>();

        }

        public async Task SaveEmployeeChangesAsync(int Id, Employee newEmployee)
        {
            try
            {
              var upadateRecord =  await _employeeService.UpdateEmployeeAsync(Id, newEmployee);
            }
            catch (Exception ex)
            {
                var message = ServiceExceptionHandler.GetErrorMessage(
                    ex,
                    " save Update changes Service");

                MessageBox.Show(
                    message,
                    "Service Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }  
        }

        public async Task SaveContactChangesAsync()
        {
            Contact NewContact = new();
            var original = SingleScreenValue;
            NewContact.ContactId = original.ContactId;
            NewContact.EmployeeId = original.EmployeeId;


            if (!string.IsNullOrWhiteSpace(EditContact.HomephoneNumber) && EditContact.HomephoneNumber != original.HomephoneNumber)
            {
                NewContact.HomephoneNumber = EditContact.HomephoneNumber;
            }

            if (!string.IsNullOrWhiteSpace(EditContact.MobilPhoneNumber) && EditContact.MobilPhoneNumber != original.MobilePhoneNumber)
            {
                NewContact.MobilPhoneNumber = EditContact.MobilPhoneNumber;
            }

            if (!string.IsNullOrWhiteSpace(EditContact.Email) && EditContact.Email != original.Email)
            {
                NewContact.Email = EditContact.Email;
            }
            if (!string.IsNullOrWhiteSpace(EditContact.EmergencyContactName) && EditContact.EmergencyContactName != original.EmergencyContactName)
            {
                NewContact.EmergencyContactName = EditContact.EmergencyContactName;
            }

            if (!string.IsNullOrWhiteSpace(EditContact.EmergencyPhoneNumber) && EditContact.EmergencyContactName != original.EmergencyPhoneNumber)
            {
                NewContact.EmergencyPhoneNumber = EditContact.EmergencyPhoneNumber;
            }


            try
            {
              var  updateRecord =   await _employeeService.UpdateContractAsync(original.ContactId, NewContact);
            }
            catch (Exception ex)
            {
                var message = ServiceExceptionHandler.GetErrorMessage(
                    ex,
                    " save Update changes Service");

                MessageBox.Show(
                    message,
                    "Service Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }
        public async Task SaveAddrtessChangesAsync(int Id, Address newAddress)
        {
            try
            {
              var updatedAddress=  await _employeeService.UpdateAddressAsync(Id, newAddress);
            }
            catch (Exception ex)
            {
                var message = ServiceExceptionHandler.GetErrorMessage(
                    ex,
                    " save Update changes Service");

                MessageBox.Show(
                    message,
                    "Service Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

        }
        public ICommand SaveContactCommand
        {
            get
            {
                if (c_saveContactCommand == null)
                {
                    c_saveContactCommand = new RelayCommand(param => this.SaveContactChangesAsync(), null
                        );
                }
                return c_saveContactCommand;
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





        public static class ServiceExceptionHandler
        {
            public static string GetErrorMessage(Exception ex, string serviceName)
            {
                if (ex is HttpRequestException)
                {
                    return $"Unable to connect to {serviceName}.\n\n" +
                           "Please check your internet connection and try again.";
                }

                if (ex is TaskCanceledException)
                {
                    return $"{serviceName} is taking too long to respond.\n\n" +
                           "Please try again later.";
                }

                return $"An error occurred while communicating with {serviceName}.\n\n" +
                       "Please try again later.";
            }
        }


    }
   

}
