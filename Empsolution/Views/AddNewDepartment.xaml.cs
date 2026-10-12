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
    public partial class AddNewDepartment : Page
    {
       private  EmployeeViewModel viewModel=new EmployeeViewModel();
        public AddNewDepartment()
        {
            InitializeComponent();
            DataContext = viewModel;
           

        }
        
        private void ExitPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DepPage());
        }

        private void GoToProject_Click(object sender, RoutedEventArgs e)
        {


        }

        private void GoToExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DepPage());
        }

        private void PersonSearch_click(object sender, RoutedEventArgs e)
        {
            viewModel.SelectEmployee();
            var records = viewModel.PersonList.ToList();
            PersonList.ItemsSource = records;
            this.PersonList.Visibility=Visibility.Visible;

        }
        
        private void ComboBox_SetManagerId(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox &&
              comboBox.SelectedItem is Employee selectedEmployee)
            {
                viewModel.SelectEmployee();
                DeptRecord.DataContext = viewModel.NewDepartment;
                
                GenrateGrideView();

            }
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
            //var textBlockFactory2 = new FrameworkElementFactory(typeof(TextBlock));
            //textBlockFactory2.SetValue(
            //   TextBlock.FontWeightProperty,
            //   Visibility.Collapsed);

            textBlockFactory2.SetBinding(
            TextBlock.TextProperty,
            new Binding("SelectedDepartment.DepId"));

            var comboBoxTemplate = new DataTemplate();
            var comboBox = new FrameworkElementFactory(typeof(ComboBox));
            comboBox.SetBinding(ComboBox.ItemsSourceProperty,
                     new Binding());
            comboBox.AddHandler(
                    ComboBox.SelectionChangedEvent,
                     new SelectionChangedEventHandler(ComboBox_SetManagerId));
            comboBox.SetBinding(ComboBox.SelectedItemProperty,
                                 new Binding("viewModel.SelectedPerson")
                                    {
                                        Mode = BindingMode.TwoWay
                                    });
            //comboBox.SetValue(ComboBox.StyleProperty, Visibility.Collapsed);
            comboBox.SetValue( FrameworkElement.NameProperty, "PersonList");

            comboBoxTemplate.VisualTree = comboBox;
            var bottontemplate = new DataTemplate();

            var button = new FrameworkElementFactory(typeof(Button));
            button.SetValue(Button.ContentProperty, "Search Employee");

            button.AddHandler(
                Button.ClickEvent,
                new RoutedEventHandler(PersonSearch_click));

            bottontemplate.VisualTree = button;


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
                     Header = "Search Employee",
                     DisplayMemberBinding = new Binding("viewModel.SearchValue"),
                     CellTemplate = template
                 });
            //gridView.Columns.Add(
            //    new GridViewColumn
            //    {
            //       // Header = "Search Employee",
            //       // DisplayMemberBinding = new Binding("viewModel.SearchValue"),
            //        CellTemplate = bottontemplate
            //    });

            //gridView.Columns.Add(
            //   new GridViewColumn
            //   {
                   
            //        Header = "Select Employee",
            //       // DisplayMemberBinding = new Binding("viewModel.SearchValue"),
            //       CellTemplate = comboBoxTemplate
            //   });

            gridView.Columns.Add(
                new GridViewColumn
                {
                    Header = "Department ",
                    DisplayMemberBinding = new Binding("viewModel.NewDepartment.DepName"),
                    CellTemplate = template
                });
            gridView.Columns.Add(
               new GridViewColumn
               {
                   Header = "Description ",
                   DisplayMemberBinding = new Binding("viewModel.NewDepartment.Description"),
                   CellTemplate = template
               });

            //DepartmentListView.View= gridView;
            //DepartmentListView.ItemsSource = viewModel.NewDepartment;

        }

        private void SaveDepartmentChanges_click(object sender, RoutedEventArgs e)
        {
            //DepartmentView.DeptRecord
            viewModel.AsyncSaveDept_Click();
        }

    }

}
