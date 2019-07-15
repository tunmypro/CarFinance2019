using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using AppCar.Annotations;
using AppCar.Model;
using AppCarFinance.Model;
using AppCarFinance.Service;
using Xamarin.Forms;

namespace AppCarFinance.ViewModel
{
    public class MemberViewModel : INotifyPropertyChanged
    {
        public MemberViewModel()
        {
            listMemberses = _apiServices.GetMemberses();
        }
        ApiServices _apiServices = new ApiServices();
        public List<Members> listMemberses { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
