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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace Empsolution.Views
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    
    
    public partial class MainPage : Page
    {
        private  Employee SelectedEmployee = new Employee();     
        EmployeeViewModel employeeViewModelVm = new EmployeeViewModel();
        private ObservableCollection<ScreenValues> screenValues = new();
        private Address SelectedAddress = new Address();
        private Contact SelectedContact  = new Contact();

        public MainPage()
        {
            
            InitializeComponent();

            //var services = App.Host.Services.GetRequiredService<EmployeeService>();
            //var recordService = ((App)Application.Current).RecordService;
             employeeViewModelVm = new EmployeeViewModel();
            //DataContext = employeeViewmodelVm;
           // employeeViewmodelVm.StartLoadDataAsync();
           

        }

        protected async void InitializeStartup()
        {
            await employeeViewModelVm.InitializeAsync();
        }
        private void GoToNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddEmployee());
            //MainFrame.Navigate(new AddEmployee());

        }

        private void AddNewEmployee_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddEmployee());
           // MainFrame.Navigate(new AddEmployee());

        }

        private void ToToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this)?.Close();
        }

        private void PerformSelection_changed(object sender, SelectionChangedEventArgs e)
        {  

            if (sender is ComboBox comboBox &&
                comboBox.SelectedItem is Department selectedDepartment)
            {
                var depId = selectedDepartment.DepID;

                employeeViewModelVm.Combo_SelectionChanged(depId);
                screenValues = employeeViewModelVm.ScreenValueRecords;

                GenrateGrideView();

            }
            
            //employeeViewModelVm.Combo_SelectionChanged();
        }
        private void GenrateGrideView()
        {
            var textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));

            textBlockFactory.SetValue(
                TextBlock.MarginProperty,
                new Thickness(10, 5, 10, 5));

            textBlockFactory.SetValue(
                TextBlock.FontSizeProperty,
                16.0);

            textBlockFactory.SetValue(
                TextBlock.ForegroundProperty,
                Brushes.Blue);

            textBlockFactory.SetValue(
                TextBlock.FontWeightProperty,
                FontWeights.Bold);
            
            var textBlockFactory2 = new FrameworkElementFactory(typeof(TextBlock));
            textBlockFactory2.SetValue(
               TextBlock.VisibilityProperty,
               Visibility.Collapsed);

            textBlockFactory2.SetBinding(
            TextBlock.TextProperty,
            new Binding("SelectedDepartment.DepId"));

            var template = new DataTemplate
            {
                VisualTree = textBlockFactory
            };

            var template2 = new DataTemplate
            {
                VisualTree = textBlockFactory2
            };

            var gridView = new GridView();

            gridView.Columns.Add(
                 new GridViewColumn
                 {
                     Header = "First Name", DisplayMemberBinding = new Binding("FirstName"),  CellTemplate = template
                 }); 
            gridView.Columns.Add( new GridViewColumn
            {
                Header = "LastName",DisplayMemberBinding = new Binding("Surename"),
                CellTemplate = template
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Hire Date",DisplayMemberBinding = new Binding("HireDate"),
                CellTemplate = template
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Date Of Birth",
                DisplayMemberBinding = new Binding("DOB"),
                CellTemplate = template

            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Manager",
                DisplayMemberBinding = new Binding("ManagerName"),
                CellTemplate = template

            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Mobile Number",
                DisplayMemberBinding = new Binding("MobilePhoneNumber"),
                CellTemplate = template

            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = " Home Phone Number",
                DisplayMemberBinding = new Binding("HomephoneNumber"),
                CellTemplate = template

            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Email",
                DisplayMemberBinding = new Binding("Email"),
                CellTemplate = template

            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Emergency Contact Name",
                DisplayMemberBinding = new Binding("EmergencyContactName"),
                CellTemplate = template

            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Emergency Phone Number",
                DisplayMemberBinding = new Binding("EmergencyPhoneNumber"),
                CellTemplate = template

            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Relationship",
                DisplayMemberBinding = new Binding("Description"),
                CellTemplate = template

            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "DepId",
                DisplayMemberBinding = new Binding("DepId"),
                CellTemplate = template2

            });
            //var listView = new ListView
            //{
            //    View = gridView
            //};

            var itemStyle = new Style(typeof(ListViewItem));

            var contextMenu = new ContextMenu();

            var editEmployee = new MenuItem
            {
                Header = "Edit Employee"
            };

            editEmployee.Click += EditEmployee_Click;

            contextMenu.Items.Add(editEmployee);

            var editAddress = new MenuItem
            {
                Header = "Edit Address"
            };

            editAddress.Click += EditAddress_Click;

            contextMenu.Items.Add(editAddress);

            var editContact = new MenuItem
            {
                Header = "Edit Contacts"
            };

            editContact.Click += EditContact_Click;

            contextMenu.Items.Add(editContact);



            itemStyle.Setters.Add(new Setter
            {
                Property = ListViewItem.ContextMenuProperty,
                Value = contextMenu
            });

            //listView.ItemContainerStyle = itemStyle;


            peopleListView.View =gridView;
            peopleListView.ItemsSource = screenValues;
            peopleListView.ItemContainerStyle = itemStyle;

        }

        private void PeopleListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (peopleListView.SelectedItem is ScreenValues selectedPerson)
            {
               
                SelectedEmployee.EmployeeId = selectedPerson.EmployeeId;
                SelectedEmployee.FirstName = selectedPerson.FirstName;
                SelectedEmployee.Surename = selectedPerson.Surename;
                SelectedEmployee.EmployeeId = selectedPerson.EmployeeId;
                SelectedEmployee.DepId = selectedPerson.DepID;
                SelectedEmployee.JobID = selectedPerson.JobID;
                SelectedEmployee.ContactId = selectedPerson.ContactId;
                SelectedEmployee.HireDate = selectedPerson.HireDate;
                SelectedEmployee.DOB= selectedPerson.DOB;

                SelectedAddress.EmployeeId = selectedPerson.EmployeeId;
                SelectedAddress.AddressId = selectedPerson.CurrentAddress.AddressId;
                SelectedAddress.Line1 = selectedPerson.CurrentAddress.Line1;
                SelectedAddress.Line2 = selectedPerson.CurrentAddress.Line2;
                SelectedAddress.County = selectedPerson.CurrentAddress.County;
                SelectedAddress.Postcode = selectedPerson.CurrentAddress.Postcode;
                SelectedAddress.Country = selectedPerson.CurrentAddress.Country;

                SelectedContact.EmployeeId = selectedPerson.EmployeeId;
                SelectedContact.ContactId = selectedPerson.ContactId;
                SelectedContact.HomephoneNumber = selectedPerson.HomephoneNumber;
                SelectedContact.MobilPhoneNumber = selectedPerson.MobilePhoneNumber;
                SelectedContact.EmergencyContactName = selectedPerson.EmergencyContactName;
                SelectedContact.EmergencyPhoneNumber = selectedPerson.EmergencyPhoneNumber;
                SelectedContact.Description = selectedPerson.Description;





                // Do whatever you need with the selected person
            }
        }
        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            // Handle selected
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            var employee = peopleListView.SelectedItem;
            if (sender is MenuItem menuItem &&
                SelectedEmployee != null )
            {
                var editWindow = new EditEmployee(SelectedEmployee);

                editWindow.Owner = Window.GetWindow(this);

                // Modeless window
                editWindow.Show();
            }

        }

        private void EditAddress_Click(object sender, RoutedEventArgs e)
        {
            var employee = peopleListView.SelectedItem;
            if (sender is MenuItem menuItem &&
                SelectedEmployee != null)
            {
                var editWindow = new EditAddress(SelectedAddress);

                editWindow.Owner = Window.GetWindow(this);

                // Modeless window
                editWindow.Show();
            }


        }
        private void EditContact_Click(object sender, RoutedEventArgs e)
        {
            var employee = peopleListView.SelectedItem;
            if (sender is MenuItem menuItem &&
                SelectedEmployee != null)
            {
                var editWindow = new EditContact(SelectedContact);

                editWindow.Owner = Window.GetWindow(this);

                // Modeless window
                editWindow.Show();
            }

        }
    }

}
