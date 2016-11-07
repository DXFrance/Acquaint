using Acquaint.Abstractions;
using Acquaint.Data;
using Acquaint.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acquaint.Native.UWP.Mvvm
{
    public class ViewModel : ViewModelBase
    {
        static Lazy<FilesystemOnlyAcquaintanceDataSource> _FilSystemDataSource= new Lazy<FilesystemOnlyAcquaintanceDataSource>(() => new FilesystemOnlyAcquaintanceDataSource());

        private IDataSource<Acquaintance> _DataSource;
        private List<Acquaintance> _acquaintances;
        public List<Acquaintance> Acquaintances
        {
            get
            {
                return _acquaintances;
            }
            private set
            {
                _acquaintances = value;

                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    RaisePropertyChanged(() => Acquaintances);
                });
            }
        }

        public ViewModel()
        {
            Acquaintances = new List<Acquaintance>();
            Task.Run(() => LoadData());
        }

        public async void LoadData()
        {
            _DataSource = _FilSystemDataSource.Value;
            Acquaintances = (await _DataSource.GetItems()).ToList();
        }
    }
}
