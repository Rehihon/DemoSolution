using Empsolution.Model;
using Empsolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class EditContact : Window
    {
        private EditRecordsViewModel viewModel =new();
        private readonly Contact _contact;
        public EditContact(Contact contact)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.SetContact(contact);
            ContactRecord.DataContext = contact;


        }

        private void SavedEditedContact_Click(object sender, RoutedEventArgs e)
        {

            Contact NewContact = new();
            var original = viewModel.SingleScreenValue;
            NewContact.ContactId = original.ContactId;
            NewContact.EmployeeId = original.EmployeeId;

            if (!string.IsNullOrWhiteSpace(HomePhoneNumber.Text) && HomePhoneNumber.Text != original.HomephoneNumber)
            {
                NewContact.HomephoneNumber = HomePhoneNumber.Text;
            }

            if (!string.IsNullOrWhiteSpace(MobilePhoneNumber.Text) && MobilePhoneNumber.Text != original.MobilePhoneNumber)
            {
                NewContact.MobilPhoneNumber = MobilePhoneNumber.Text;
            }

            if (!string.IsNullOrWhiteSpace(Email.Text) && Email.Text != original.Email)
            {
                NewContact.Email = Email.Text;
            }
            if (!string.IsNullOrWhiteSpace(EmergencyContactName.Text) && EmergencyContactName.Text != original.EmergencyContactName)
            {
                NewContact.EmergencyContactName = EmergencyContactName.Text;
            }

            if (!string.IsNullOrWhiteSpace(EmergencyPhoneNumber.Text) && EmergencyContactName.Text != original.EmergencyPhoneNumber)
            {
                NewContact.EmergencyPhoneNumber = EmergencyPhoneNumber.Text;
            }
           // viewModel.SaveContactChangesAsync(_contact.ContactId, NewContact);

            this.Close();


        }
    }
}
