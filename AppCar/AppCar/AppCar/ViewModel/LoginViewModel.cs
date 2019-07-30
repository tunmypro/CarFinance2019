using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using AppCar.Annotations;
using AppCar.Model;
using AppCar.View;
using AppCarFinance.Model;
using AppCarFinance.Service;

namespace AppCar.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private ApiServices _memberServices = new ApiServices();
        public static Logins _Member { get; set; }

        public Logins getmem { get; set; }

        public LoginViewModel()
        {
            getmem = _Member;
        }

        public Logins GetLogin(Logins data)
        {
            var result = _memberServices.LoginMember(data).Result;
            _Member = result;
            getmem = getmem;
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
