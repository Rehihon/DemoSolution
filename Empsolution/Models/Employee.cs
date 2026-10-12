using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empsolution.Model
{
    public class Employee :INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public int EmployeeId { get; set; }
        private string _firstName = string.Empty;
        private string _surename = string.Empty;
        private int  _depId;   
        private int _contactId;
        private int _jobId;
        private DateOnly? _dob;
        private DateOnly? _hireDate;

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(FirstName);
                }
            }
        }
        public string? Surename
        {
            get => _surename;
            set
            {
                if (_surename != value)
                {
                    _surename = value;
                    OnPropertyChanged(Surename);
                }
            }
        }
        public int ContactId
        {
            get => _contactId;
            set
            {
                if (_contactId != value)
                {
                    _contactId = value;
                    OnPropertyChanged(nameof(ContactId));
                }
            }
        }
        public DateOnly?  DOB
        {
            get => _dob;
            set
            {
                if (_dob != value)
                {
                    _dob = value;
                    OnPropertyChanged(nameof(JobID));
                }
            }
        }
        public DateOnly? HireDate
        {
            get => _hireDate;
            set
            {
                if (_hireDate != value)
                {
                    _hireDate = value;
                    OnPropertyChanged(nameof(HireDate));
                }
            }
        }
        public int JobID
        {
            get => _jobId;
            set
            {
                if (_jobId != value)
                {
                    _jobId = value;
                    OnPropertyChanged(nameof(JobID));
                }
            }
        }

        public int DepId
        {
            get => _depId;
            set
            {
                if (_depId != value)
                {
                    _depId = value;
                    OnPropertyChanged(nameof(DepId));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
