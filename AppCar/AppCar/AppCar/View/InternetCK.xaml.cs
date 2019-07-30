using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using AppCarFinance;
using Java.Lang;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCar.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InternetCK : ContentPage
	{
		public InternetCK ()
		{
			InitializeComponent ();
		}

        private void Button_OnClicked(object sender, EventArgs e)
        {
            JavaSystem.Exit(0);
        }
    }
}