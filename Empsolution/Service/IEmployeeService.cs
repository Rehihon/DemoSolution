using Empsolution.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Empsolution.Service
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeeAsync();
        Task<List<Department>> GetDepartmentAsync();
        Task<List<Jobs>> GetJobsAsync();
        Task<List<Jobhistory>> GetJobhistoryAsync();
        Task<List<Address>> GetAddressAsync();
        Task<List<Contact>> GetContactAsync();
       // Task<List<Countries>> GetCountriesAsync();

    }
}
