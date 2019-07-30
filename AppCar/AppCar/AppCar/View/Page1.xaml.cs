using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCarFinance.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCar.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
        private MemberViewModel memberViewModel = new MemberViewModel();
		public Page1 ()
		{
			InitializeComponent ();
		}

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var value = SearchBar.Text;
            var data = memberViewModel.listMemberses.Where(x => x.memname.Contains(value)).ToList();
            ListView.ItemsSource = data;
        }
    }
}