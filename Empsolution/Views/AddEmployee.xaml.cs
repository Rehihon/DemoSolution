using Empsolution.Model;
using Empsolution.Models;
using Empsolution.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Empsolution.Views
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class AddEmployee : Page
    {
        public EmployeeViewModel ViewModel = new EmployeeViewModel();
        public AddEmployee()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
       
        private void Button_CloseApp(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new MainPage());
        }

        private void SelectedCellChanged_Clicked(object sender, SelectedCellsChangedEventArgs e)
        {
            if (sender is DataGrid dataGrid &&
               dataGrid.SelectedItem is AddNewEmployees SelectedNewEmployee)
            {
                if (DepartmentName.SelectedItem is Department DepaDeparmentSelectedRecord)
                {
                    SelectedNewEmployee.DepID = DepaDeparmentSelectedRecord.DepID;
                }
                if (JobTitle.SelectedItem is Jobs JobSelectedRecord)
                {
                    SelectedNewEmployee.JobID = JobSelectedRecord.JobID;
                }

            }
        }

        private void SeveRecord_click(object sender, RoutedEventArgs e)
        {
            ViewModel.AsyncButton_Click();
        }
    }
}
