using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppCar.Model;
using AppCar.ViewModel;
using AppCarFinance.Service;
using AppCarFinance.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCarFinance
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page2 : ContentPage
	{
		public Page2 ()
		{
			InitializeComponent ();
        }

        private void getgen(object sender, EventArgs e)
        {
            Cars car = ((Cars) (Picker1.SelectedItem));
            Picker2.ItemsSource = getGens(car.carcode);
            Picker2.ItemDisplayBinding = new Binding("genname");
            Picker2.SelectedItem = 0;
        }

        private IList getGens(int carCarcode)
        {
            ApiServices _api = new ApiServices();
            var gen = _api.GetGentes().Where(x => x.gencar == carCarcode).OrderBy(x => x.gencar).ToList();
            return gen;
        }
    }
}