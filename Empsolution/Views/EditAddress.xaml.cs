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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class EditAddress : Window
    {
        private EditRecordsViewModel viewModel = new EditRecordsViewModel();
        private readonly Employee _employee;
        private readonly Address _address;
        public EditAddress(Address address)
        {
            InitializeComponent();
            _address = address;
            viewModel.SetAddress(address);
            DeptRecord.DataContext = viewModel.EditAddress;

        }

        private void SavedEditedAddress_Click(object sender, RoutedEventArgs e)
        {
            Address NewAddress = new();
            var original = viewModel.SingleScreenValue;
            if (!string.IsNullOrWhiteSpace(AddresLine1.Text) && AddresLine1.Text != original.CurrentAddress.Line1)
            {
                NewAddress.Line1 = AddresLine1.Text;
            }

            if (!string.IsNullOrWhiteSpace(AddressLine2.Text) && AddressLine2.Text != original.CurrentAddress.Line2)
            {
                NewAddress.Line2 = AddressLine2.Text;
            }

            if (!string.IsNullOrWhiteSpace(AddressCounty.Text) && AddressCounty.Text != original.CurrentAddress.County)
            {
                NewAddress.County = AddressCounty.Text;
            }
            if (!string.IsNullOrWhiteSpace(addresscountry.Text) && addresscountry.Text != original.CurrentAddress.Country)
            {
                NewAddress.Country = addresscountry.Text;
            }

            if (!string.IsNullOrWhiteSpace(Postcode.Text) && Postcode.Text != original.CurrentAddress.Postcode)
            {
                NewAddress.Postcode = Postcode.Text;
            }
            viewModel.SaveAddrtessChangesAsync(_address.AddressId, NewAddress);

            this.Close();
        }
    }
}
