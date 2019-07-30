using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCar.ViewModel;
using AppCarFinance;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCar.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewMember : ContentPage
	{
        private  LoginViewModel _loginViewModel = new LoginViewModel();
		public ViewMember ()
		{
			InitializeComponent ();
            var data = _loginViewModel.getmem;
            Label1.Text = data.logmem;
            Label2.Text = data.memname + " " + data.memlname;
            Label3.Text = data.memtel;
            Label4.Text = data.memcareer;
            Label5.Text = data.memage;
            Label6.Text = data.memline;
            Label7.Text = data.loanmoney;
            Label8.Text = data.loanmonth;
            Label9.Text = data.loadpermonth;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}