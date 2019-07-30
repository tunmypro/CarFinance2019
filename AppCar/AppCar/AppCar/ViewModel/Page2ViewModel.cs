using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AppCar.Annotations;
using AppCar.Model;
using AppCarFinance.Service;
using Xamarin.Forms;

namespace AppCar.ViewModel
{
    public class Page2ViewModel : INotifyPropertyChanged
    {
        public Page2ViewModel()
        {
            carList = _apiServices.GetCarses().Result;
            GenList = _apiServices.GetGentes().Result;
        }


        ApiServices _apiServices = new ApiServices();
        private ObservableCollection<Gens> _GenList;

        public ObservableCollection<Gens> GenList
        {
            get => _GenList;
            set
            {
                _GenList = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Cars> _carList;

        public ObservableCollection<Cars> carList
        {
            get => _carList;
            set
            {
                _carList = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
