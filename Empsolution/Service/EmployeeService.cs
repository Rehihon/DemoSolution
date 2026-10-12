using Empsolution.Model;
using Empsolution.Models;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;


namespace Empsolution.Service

{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private List<ScreenValues> screenValues;
        public async Task<List<Employee>> GetEmployeeAsync()
        {   try { 
            var employee = await _httpClient.GetFromJsonAsync<List<Employee>>("api/Employee");
            return employee ?? new List<Employee>();
            }
            catch (Exception ex)
            {
                var message = ServiceExceptionHandler.GetErrorMessage(
                    ex,
                    "Get Employee Service");

                MessageBox.Show(
                    message,
                    "Service Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return null;
            }
        }
        public async Task<List<Department>> GetDepartmentAsync()
        {   
            try { 
            var departments = await _httpClient.GetFromJsonAsync<List<Department>>("api/Department");

            return departments ?? new List<Department>();
            }
            catch (Exception ex)
            {
                var message = ServiceExceptionHandler.GetErrorMessage(
                    ex,
                    "Get Department Service");

                MessageBox.Show(
                    message,
                    " Service Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return null;
            }
        }
        public async Task<List<Jobs>> GetJobsAsync()
        {
            try { 

            var jobs = await _httpClient.GetFromJsonAsync<List<Jobs>>("api/Jobs");

            return jobs ?? new List<Jobs>();
            }
            catch (Exception ex)
            {
                var message = ServiceExceptionHandler.GetErrorMessage(
                    ex,
                    "Get Jobs Service");

                MessageBox.Show(
                    message,
                    "Service Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return null;
            }
        }
        public async Task<List<Address>> GetAddressAsync()
        {
            try { 

            var address = await _httpClient.GetFromJsonAsync<List<Address>>("api/Address");

            return address ?? new List<Address>();
            }
            catch (Exception ex)
            {
                var message = ServiceExceptionHandler.GetErrorMessage(
                    ex,
                    "Get Address Service");

                MessageBox.Show(
                    message,
                    "Service Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return null;
            }
        }
        public async Task<List<Contact>> GetContactAsync()
        {
            try { 
            var contact = await _httpClient.GetFromJsonAsync<List<Contact>>("api/Contact");

            return contact ?? new List<Contact>();
            }
            catch (Exception ex)
            {
                var message = ServiceExceptionHandler.GetErrorMessage(
                    ex,
                    "Get Contact Service");

                MessageBox.Show(
                    message,
                    "Service Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return null;
            }

        }
       
        public async Task<List<Jobhistory>> GetJobhistoryAsync()
        {
            var jobhistory = await _httpClient.GetFromJsonAsync<List<Jobhistory>>("api/Jobhistory");

            return jobhistory ?? new List<Jobhistory>();
        }

        private async Task<Address> CreateAddressAsync(Address content)
        {
            try { 
            var response = await _httpClient.PostAsJsonAsync("api/Address", content);
            response.EnsureSuccessStatusCode();

            var createdAddress =
                await response.Content.ReadFromJsonAsync<Address>();

            return createdAddress;
            }
            catch (Exception ex)
            {
                var message = ServiceExceptionHandler.GetErrorMessage(
                    ex,
                    "Save Address Service");

                MessageBox.Show(
                    message,
                    "Service Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return null;
            }

        }

        public async Task<Jobs> CreateJobRecordAsync(Jobs content)
        {
             
            try
            { 
            var response = await _httpClient.PostAsJsonAsync("api/Jobs", content);
            response.EnsureSuccessStatusCode();

            var createdJobs =
                await response.Content.ReadFromJsonAsync<Jobs>();

            return createdJobs;
                }
                catch (Exception ex)
                {
                    var message = ServiceExceptionHandler.GetErrorMessage(
                        ex,
                        " Save jobs Service");

                    MessageBox.Show(
                        message,
                        "Service Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                return null;
                }
            }

        public async Task<Department> CreateDepartmentAsync(Department content)
        {
             try
            { 
            var response = await _httpClient.PostAsJsonAsync("api/Department", content);
            response.EnsureSuccessStatusCode();
            var createdJobs = await response.Content.ReadFromJsonAsync<Department>();

                    return createdJobs;

             }
                    catch (Exception ex)
                    {
                        var message = ServiceExceptionHandler.GetErrorMessage(
                            ex,
                            " save Department Service");

                        MessageBox.Show(
                            message,
                            "Service Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);

                        return null;
                    }
        }
        private async Task<Employee> CreateEmployeeAsync(Employee content)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Employee", content);
            response.EnsureSuccessStatusCode();

            var person =
                await response.Content.ReadFromJsonAsync<Employee>();

            return person;
        }

        private async Task<Contact> CreateContactAsync(Contact content)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Contact", content);
            response.EnsureSuccessStatusCode();

            var contact =
                await response.Content.ReadFromJsonAsync<Contact>();

            return contact;
        }

        public async Task<Employee> UpdateEmployeeAsync(int Id, Employee content)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Employee",content);
            response.EnsureSuccessStatusCode();

            var updateRecord =
                await response.Content.ReadFromJsonAsync<Employee>();

            return updateRecord;
        }


        public async Task<Contact> UpdateContractAsync(int id,Contact content)
        {
            try
            {

                var response = await _httpClient.PutAsJsonAsync($"api/Contact",  content);
                response.EnsureSuccessStatusCode();

                var updateRecord = 
                 await response.Content.ReadFromJsonAsync<Contact>();
                return updateRecord;
            }
            catch (Exception ex)
            {
                var message = ServiceExceptionHandler.GetErrorMessage(
                    ex,
                    " save Department Service");

                MessageBox.Show(
                    message,
                    "Service Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return null;
            }

        }

        public async Task<Address> UpdateAddressAsync(int Id, Address content)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Address", content);
                response.EnsureSuccessStatusCode();

                var updateRecord =
                    await response.Content.ReadFromJsonAsync<Address>();

                return updateRecord;
            }
            catch (Exception ex)
            {
                var message = ServiceExceptionHandler.GetErrorMessage(
                    ex,
                    " save Department Service");

                MessageBox.Show(
                    message,
                    "Service Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return null;
            }

        }




        public async Task<List<ScreenValues>> CreateEmplyeeRecordsAsync(List<AddNewEmployees> requests)
        {
            foreach (var request in requests)
            {
                ScreenValues screenValue = new ScreenValues();
                Address address = new Address();
                var employee = new Employee();
                employee.FirstName = request.FirstName;
                employee.Surename = request.Surename;
                employee.HireDate = request.HireDate;
                employee.HireDate = request.HireDate;
                employee.DepId = request.DepID;
                employee.JobID = request.JobID;

                var person = await CreateEmployeeAsync(employee);

                screenValue.EmployeeId = person.EmployeeId;
                screenValue.FirstName = request.FirstName;
                screenValue.Surename = request.Surename;
                screenValue.HireDate = request.HireDate;
                screenValue.HireDate = request.HireDate;
                screenValue.DepID = request.DepID;
                screenValue.JobID = request.JobID;

                //var address = request.CurrentAddress;

                address.EmployeeId = person.EmployeeId;
                address.Line1 = request.Line1;
                address.Line2 = request.Line2;
                address.County = request.County;
                address.Country = request.Country;
               
                var response = await CreateAddressAsync(address);

               // request. = response.AddressId;
                screenValue.CurrentAddress = response;


                var contact = new Contact();
               // contact.ContactId = request.ContactId;
                contact.Email = request.Email;
                contact.EmployeeId = person.EmployeeId;
                contact.HomephoneNumber = request.HomephoneNumber;
                contact.MobilPhoneNumber = request.MobilPhoneNumber;
                contact.EmergencyPhoneNumber = request.EmergencyPhoneNumber;
                contact.EmergencyContactName = request.EmergencyContactName;
                contact.Description = request.Description;
                 var responsecontact = await CreateContactAsync(contact);
                //request.ContactId = responsecontact.ContactId;

                screenValue.ContactId = responsecontact.ContactId;
                screenValue.Email = responsecontact.Email;
                screenValue.EmergencyContactName= responsecontact.EmergencyContactName;
                screenValue.EmergencyPhoneNumber= responsecontact.EmergencyPhoneNumber;
                screenValue.HomephoneNumber= responsecontact.HomephoneNumber;
                screenValue.MobilePhoneNumber= responsecontact.MobilPhoneNumber;
                screenValue.Description= responsecontact.Description;
                screenValues.Add(screenValue);

            }

            return screenValues;
        }

    }
}

