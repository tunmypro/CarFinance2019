using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCar.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();

            IncomeViewModel vm  = new IncomeViewModel();
            Label1.Text = vm.listIncome.sumin;
            Label2.Text = vm.listIncome.sumex;
            Label3.Text = vm.listIncome.total;
        }
    }
}