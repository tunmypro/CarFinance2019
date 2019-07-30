using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AppCar.Annotations;
using AppCarFinance.Model;
using AppCarFinance.Service;

namespace AppCar.ViewModel
{
    public class IncomeViewModel : INotifyPropertyChanged
    {
        public IncomeViewModel()
        {
            listIncome = _apiServices.GetIncome().Result;
        }
        ApiServices _apiServices = new ApiServices();
        public In_Ex listIncome { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
