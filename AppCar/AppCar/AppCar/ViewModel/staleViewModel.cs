using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using AppCar.Annotations;
using AppCar.Model;
using AppCarFinance.Model;
using AppCarFinance.Service;

namespace AppCar.ViewModel
{
    class staleViewModel : INotifyPropertyChanged
    {
        public staleViewModel()
        {
            listStale = _apiServices.getStale().Result;
        }
        ApiServices _apiServices = new ApiServices();
        public ObservableCollection<staleMember> listStale { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
