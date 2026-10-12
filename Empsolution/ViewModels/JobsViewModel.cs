using Empsolution.Model;
using Empsolution.Resource;
using Empsolution.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Empsolution.ViewModels
{
    class JobsViewModel: ViewModelBase
    {
        public RecordService _recordService;
        private List<Jobs> _newJobRecord = new();
        private EmployeeService _employeeService;
        public string ButtonContent;
        private ICommand c_ButtonCommand;
        public List<Jobs> NewJobRecord
        {
            get { return _newJobRecord; }

            set
            {
                _newJobRecord = value;
                OnPropertyChanged(nameof(NewJobRecord));
            }
        }

        public ICommand SubmitJobCommand
        {
            get
            {
                if (c_ButtonCommand == null)
                {
                    c_ButtonCommand = new RelayCommand(param => this.AsyncButton_Click(), null);
                }
                return c_ButtonCommand;
            }
        }

        private Jobs _selectJob = new Jobs();
        public Jobs JobSelectedRecord
        {
            get => _selectJob;
            set
            {
                _selectJob = value;
                NotifyPropertyChanged(nameof(JobSelectedRecord));
            }
        }
        public JobsViewModel()
        {
            _employeeService = App.Host.Services.GetRequiredService<EmployeeService>();
            _recordService = App.Host.Services.GetRequiredService<RecordService>();
        }
        public async Task AsyncButton_Click()
        {
            if (_newJobRecord.Count() > 0)
            {
                foreach (var job in NewJobRecord)
                {
                    var newRecords = await _employeeService.CreateJobRecordAsync(job);
                }
                _recordService.AddJobRecord(NewJobRecord);
            }
        }

    }
}
