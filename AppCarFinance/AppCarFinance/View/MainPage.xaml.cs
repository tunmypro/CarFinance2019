﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
