using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AppCar.Annotations;
using AppCar.Model;
using AppCarFinance.Service;
using Xamarin.Forms;

namespace AppCar.ViewModel
{
    public class Page2ViewModel : INotifyPropertyChanged
    {
        public Page2ViewModel()
        {
            carList = _apiServices.GetCarses().OrderBy(x => x.carbrand).ToList();
        }

        ApiServices _apiServices = new ApiServices();
        private Cars _selectedCars;
        private string _price;
        private Gens _getPrice;
        public List<Cars> carList { get; set; }
        public List<Gens> GenList { get; set; }

        public Cars SelectedCars
        {
            get => _selectedCars;
            set
            {
                if (_selectedCars != value)
                {
                    _selectedCars = value;
                    OnPropertyChanged();
                    price = _apiServices.GetGentes().Where(x => x.gencar == _selectedCars.carcode).FirstOrDefault().gencost.ToString();
                }
            }
        }


        //เปลี่ยนเป็นคอมมาน
        public Command getPrice
        {
            get
            {
                return new Command(() =>
                {
                    price = _apiServices.GetGentes().Where(x => x.gencar == _selectedCars.carcode).FirstOrDefault().gencost.ToString();
                    //price = "ราคาประเมิณ : " + GenList.Where(x => x.gencar == _selectedCars.carcode).FirstOrDefault().gencost;
                });
            }
        }

        public string price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
