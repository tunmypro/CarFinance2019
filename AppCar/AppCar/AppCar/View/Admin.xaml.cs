using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCarFinance;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Admin : TabbedPage
    {
        public Admin()
        {
            InitializeComponent();

            Button button = new Button
            {
                Text = "ออกจากระบบ",
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            this.Children.Add(new ContentPage
            {
                Title = "ออกจากระบบ",
                Content = new StackLayout
                {
                    Children ={
                        button
                    }
                }
            });

            button.Clicked += DynamicBtn_Clicked;
        }

        private void DynamicBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}