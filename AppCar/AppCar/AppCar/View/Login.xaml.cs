using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCar.ViewModel;
using AppCarFinance;
using AppCarFinance.Model;
using AppCarFinance.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCar.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        ApiServices _api = new ApiServices();

        private void Login_Clicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;
            if (string.IsNullOrEmpty(username))
            {
                userError.Text = "กรุณากรอก ชื่อผู้ใช้";
            }
            else userError.Text = "";
            if (string.IsNullOrEmpty(password))
            {
                passwordError.Text = "กรุณากรอก รหัสผ่าน";
            }
            else passwordError.Text = "";

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                Logins login = new Logins
                {
                    loguser = username,
                    logpass = password
                };
                var data = _api.LoginMember(login).Result;
                LoginViewModel viewModel = new LoginViewModel();
                if (data == null)
                {
                    DisplayAlert("ล้มเหลว", "ยูสเซอร์เนม หรือพาสเวิร์ด ผิดพลาด", "OK");
                }
                else
                {
                    viewModel.GetLogin(data);

                    if (data.logtype == 1 || data.logtype == 2)
                    {
                        Application.Current.MainPage = new Admin();
                    }
                    else if (data.logtype == 3)
                    {
                        Application.Current.MainPage = new ViewMember();
                    }
                }
            }
        }
    }
}