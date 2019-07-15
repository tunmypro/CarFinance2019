using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Android.Provider;
using AppCarFinance.Annotations;
using AppCarFinance.Model;
using AppCarFinance.Service;
using Xamarin.Forms;

namespace AppCarFinance.ViewModel
{
    class MemberViewModel : INotifyPropertyChanged
    {
        public MemberViewModel()
        {
            listMemberses = _apiServices.GetMemberses();
        }
        ApiServices _apiServices = new ApiServices();
        public List<Members>  listMemberses { get; set; }

        //public List<Members> Members
        //{
        //    get => _memberses;
        //    set
        //    {
        //        if(Equals(value,_memberses)) return;
        //        _memberses = value;
        //        OnPropertyChanged();
        //    }
        //}


        //public ICommand GetMemberCommand
        //{
        //    get
        //    {
        //        return new Command(async () => { Members = await _apiServices.GetMemberses().ToList(); });
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
