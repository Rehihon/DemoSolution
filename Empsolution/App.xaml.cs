using System.Configuration;
using System.Data;
using Empsolution.Views;
using Empsolution.ViewModels;
using System.Net.Http;
using Empsolution.Service;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;

namespace Empsolution
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public RecordService RecordService { get; }= new RecordService();
        //public object Services { get; set; }
        public static IHost Host { get; } =
        Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
        .ConfigureServices((context, services) =>
        {
            // Register HttpClient
            string apiUrl = (string)Application.Current.Resources["ApiUrl"];
            services.AddHttpClient<EmployeeService>(client =>
            {
              client.BaseAddress = new Uri("http://localhost:5259/");
               // client.BaseAddress = new Uri(apiUrl);
            });
          
            
            
            services.AddSingleton<EmployeeViewModel>();
            services.AddSingleton<RecordService>();
            
            
            services.AddSingleton<MainWindow>();
        })
        .Build();

        protected override void OnStartup(StartupEventArgs e)
        {
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Hide();
            //base.OnStartup(e);
            
            var loginWindow = new LoginWindow();
            loginWindow.Show();
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await Host.StopAsync();
            Host.Dispose();

            base.OnExit(e);
        }
    }

}
