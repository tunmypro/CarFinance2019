using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Microcharts;
using SkiaSharp;
using Entry = Microcharts.Entry;

namespace AppCarFinance
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        private Page2ViewModel page2 = new Page2ViewModel();

        public Page2()
        {
            InitializeComponent();
        }

        private void getgen(object sender, EventArgs e)
        {
            Cars car = ((Cars)(Picker1.SelectedItem));
            Picker2.ItemsSource = getGens(car.carcode);
            Picker2.ItemDisplayBinding = new Binding("genname");
            Picker2.SelectedItem = 0;
            Label.Text = "ราคา :";
        }

        private IList getGens(int carCarcode)
        {
            var gen = page2.GenList.Where(a => a.gencar == carCarcode).OrderBy(x => x.gencar).ToList();
            return gen;
        }

        public ObservableCollection<Gens> ValueList { get; private set; }

        private void getprice(object sender, EventArgs e)
        {
            Gens gen = ((Gens)(Picker2.SelectedItem));

            if (gen != null)
            {
                var price = page2.GenList.Where(x => x.genname == gen.genname).FirstOrDefault().gencost;
                Label.Text = String.Format("ราคา : {0:0.##}", price);
                Slider.Maximum = Convert.ToDouble(price);
                Slider.Minimum = 0;
                Slider.Value = Convert.ToDouble(price);
                //setChart(price);
                setmicroChart(Convert.ToSingle(Slider.Value));
            }
            else
            {
                Label.Text = "ราคา :";
            }
        }

        private void Handle_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 10000);
            Slider.Value = newStep * 10000;
            DisplayLabel.Text = Slider.Value.ToString();
            DisplayLabel.TranslateTo(Slider.Value * ((Slider.Width - 300) / Slider.Maximum), 0, 10);
            //setChart(Convert.ToDecimal(Slider.Value));
            setmicroChart(Convert.ToSingle(Slider.Value));
        }

        //public void setChart(decimal? value)
        //{
        //    this.ValueList = new ObservableCollection<Gens>();
        //    ValueList.Add(new Gens { genname = "48 เดือน", gencost = value / 48 });
        //    ValueList.Add(new Gens { genname = "36 เดือน", gencost = value / 36 });
        //    ValueList.Add(new Gens { genname = "24 เดือน", gencost = value / 24 });
        //    ValueList.Add(new Gens { genname = "12 เดือน", gencost = value / 12 });
        //    Chart.ItemsSource = ValueList;
        //    Chart.XBindingPath = "genname";
        //    Chart.YBindingPath = "gencost";
        //}

        public void setmicroChart(float value)
        {
            List<Entry> entries = new List<Entry>
            {
                new Entry(value/48)
                {
                    ValueLabel = string.Format("{0:N0}",value/48),
                    Label = "48 Month",
                    Color = SKColor.Parse("#2c3e50")
                },
                new Entry(value/36)
                {
                    ValueLabel = string.Format("{0:N0}",value/36),
                    Label = "36 Month",
                    Color = SKColor.Parse("#77d065")
                },
                new Entry(value/24)
                {
                    ValueLabel = string.Format("{0:N0}",value/24),
                    Label = "24 Month",
                    Color = SKColor.Parse("#b455b6")
                },
                new Entry(value/12)
                {
                    ValueLabel = string.Format("{0:N0}",value/12),
                    Label = "12 Month",
                    Color = SKColor.Parse("#3498db")
                }
            };

            ChartView.Chart = new BarChart() { Entries = entries };
        }
    }
}
