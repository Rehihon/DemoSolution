using Empsolution.Service;
using Empsolution.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
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

namespace Empsolution.Views
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordInBox.Password;
            if (username == "admin" && password == "12345")
            {
                MainWindow mainWindow = new MainWindow();

                // var vm = App.Host.Services.GetRequiredService<EmployeeViewModel>();
                //InitializeStartup();
                var apiservice = App.Host.Services.GetRequiredService<EmployeeService>();
                var recordService = App.Host.Services.GetRequiredService<RecordService>();
                
                mainWindow.Show();
                this.Close();
            }
            else
            {

                ErrorTextBlock.Text = "Invalid username or password.";
                ErrorTextBlock.Visibility = Visibility.Visible;
            }
        }
        protected async void InitializeStartup()
        {
            var window = App.Host.Services.GetRequiredService<MainWindow>();

            //var vm = App.Host.Services.GetRequiredService<EmployeeViewModel>();
            //await vm.InitializeAsync();

        }
        public LoginWindow()
        {
            InitializeComponent();
        }
    }
}
