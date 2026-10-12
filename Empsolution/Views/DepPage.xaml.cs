using Empsolution.Model;
using Empsolution.Service;
using Empsolution.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Empsolution.Views;
using System.Windows;
using System.Windows.Controls;

namespace Empsolution.Views
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class DepPage : Page
    {
        public DepPage()
        {
            InitializeComponent();
        }

        private void GoToExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this)?.Close();
        }

        private void GoToProject_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddNewDepartment());
        }
    }
}
