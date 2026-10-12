using Empsolution.Service;
using Empsolution.ViewModels;
using Empsolution.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Empsolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private EmployeeViewModel employeeViewModel;
        public MainWindow()
        {
            InitializeComponent();
            AsyncInitializeStartup();
        }

        private async void  AsyncInitializeStartup()
        {
            var _employeeService = App.Host.Services.GetRequiredService<EmployeeService>();
            var recordService = ((App)Application.Current).RecordService;
            await recordService.InitializeRecordAsync(_employeeService);

        }

        private void GoToNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MainPage());
            NavigationBar.Visibility = Visibility.Collapsed;
        }

        private void GoToDepartment_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DepPage());
            NavigationBar.Visibility = Visibility.Collapsed;
        }

        private void GoToExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GoToJobs_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new JobPage());
            NavigationBar.Visibility= Visibility.Collapsed;
        }


    }
}