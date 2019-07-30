using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppCar.Model;
using AppCar.ViewModel;
using AppCarFinance.Helpers;
using AppCarFinance.Model;
using Newtonsoft.Json;

namespace AppCarFinance.Service
{
    class ApiServices
    {
        HttpClient httpClient = new HttpClient();

        public async Task<ObservableCollection<Members>> GetMemberses()
        {
            HttpResponseMessage response = httpClient.GetAsync("https://testapi-kc3.conveyor.cloud/api/members").Result;
            return await response.Content.ReadAsAsync<ObservableCollection<Members>>();
        }

        public async Task<ObservableCollection<Cars>> GetCarses()
        {
            HttpResponseMessage response = httpClient.GetAsync("https://testapi-kc3.conveyor.cloud/api/cars").Result;
            return await response.Content.ReadAsAsync<ObservableCollection<Cars>>();
        }

        public async Task<ObservableCollection<Gens>> GetGentes()
        {
            HttpResponseMessage response = httpClient.GetAsync("https://testapi-kc3.conveyor.cloud/api/gens").Result;
            return await response.Content.ReadAsAsync<ObservableCollection<Gens>>();
        }

        public async Task<In_Ex> GetIncome()
        {
            HttpResponseMessage response = httpClient.GetAsync("https://testapi-kc3.conveyor.cloud/api/In_Ex").Result;
            return await response.Content.ReadAsAsync<In_Ex>();
        }

        public async Task<Logins> LoginMember(Logins data)
        {
            HttpResponseMessage response = httpClient.PostAsJsonAsync("https://testapi-kc3.conveyor.cloud/api/loginapi/", data).Result;
            return await response.Content.ReadAsAsync<Logins>();
        }

        public async Task<ObservableCollection<staleMember>> getStale()
        {
            HttpResponseMessage response = httpClient.GetAsync("https://testapi-kc3.conveyor.cloud/api/stale").Result;
            return await response.Content.ReadAsAsync<ObservableCollection<staleMember>>();
        }
    }
}
