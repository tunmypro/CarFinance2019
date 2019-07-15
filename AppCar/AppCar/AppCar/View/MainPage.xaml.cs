using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCar.View;
using Xamarin.Forms;

namespace AppCarFinance
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            Detail = new NavigationPage(new Page1());

            IsPresented = false;
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Page1());
            IsPresented = false;
        }

        private void Button_OnClicked2(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Page2());
            IsPresented = false;
        }

        private void Button_OnClicked3(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Login());
            IsPresented = false;
        }

        private void Button_OnClicked4(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new MapPage());
            IsPresented = false;
        }
    }
}
