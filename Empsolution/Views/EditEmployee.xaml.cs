using Empsolution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Empsolution.ViewModels;

namespace Empsolution.Views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditEmployee : Window

    {
        private EditRecordsViewModel viewModel = new EditRecordsViewModel();

        private readonly Employee _employee = new Employee();
        public EditEmployee(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            viewModel.GetEmployee(employee);
            DeptRecord.DataContext = viewModel.EditEmployee;




        }

        private void SavedEditedEmployee_Click(object sender, RoutedEventArgs e)
        {
            var original = viewModel.SingleScreenValue; 
            Employee NewEmployee = new();
            NewEmployee.EmployeeId= _employee.EmployeeId;
            if (!string.IsNullOrWhiteSpace(firstName.Text) && firstName.Text != original.FirstName)
            {
                NewEmployee.FirstName = firstName.Text;
            }

            var jobSelectItem = JobTitle.SelectedItem as Jobs;
            if (jobSelectItem.JobID != null && jobSelectItem.JobID != original.JobID)
            {
                NewEmployee.JobID = jobSelectItem.JobID;
            }

            var departmenttItem = DepName.SelectedItem as Department;
            if (departmenttItem.DepID != null && departmenttItem.DepID != original.DepID)
            {
                NewEmployee.DepId = departmenttItem.DepID;
            }
            if (!string.IsNullOrWhiteSpace(surename.Text) && surename.Text != original.Surename)
            {
                NewEmployee.Surename = surename.Text;
            }

            if (DateOnly.TryParse(dob.Text, out DateOnly dobValue))
            {
                if (dobValue != original.DOB)
                {
                    NewEmployee.DOB = dobValue;
                }
            }
            if (DateOnly.TryParse(startdate.Text, out DateOnly startValue))
            {
                if (startValue != original.HireDate)
                {
                    NewEmployee.HireDate = startValue;
                }
            }

            viewModel.SaveEmployeeChangesAsync(NewEmployee.EmployeeId, NewEmployee);

            this.Close();
        }
        private void SetCurrentJob_Event(object sender, RoutedEventArgs e)
        {

            var selectValue = viewModel.Jobs.FirstOrDefault(p => p.JobID == viewModel.SingleScreenValue.JobID);
            var id = JobTitle.SelectedItem = selectValue;
        }

        private void SetDepartmentCurrentId_event(object sender, RoutedEventArgs e)
        {
            var selectValue = viewModel.Departments.FirstOrDefault(p => p.DepID == viewModel.SingleScreenValue.DepID);
            DepName.SelectedValue = selectValue;
        }
        private void JobTitle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                
             //   =viewModel.SingleScreenValue.JobID;
        }
    }
}
