using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppCar.Model;
using AppCarFinance.Helpers;
using AppCarFinance.Model;
using Newtonsoft.Json;

namespace AppCarFinance.Service
{
    class ApiServices
    {
        HttpClient httpClient = new HttpClient();

        public List<Members> GetMemberses()
        {
            HttpResponseMessage response = httpClient.GetAsync("https://newapi.conveyor.cloud/api/members").Result;
            return response.Content.ReadAsAsync<List<Members>>().Result;
        }

        public List<Cars> GetCarses()
        {
            HttpResponseMessage response = httpClient.GetAsync("https://newapi.conveyor.cloud/api/cars").Result;
            return response.Content.ReadAsAsync<List<Cars>>().Result;
        }

        public List<Gens> GetGentes()
        {
            HttpResponseMessage response = httpClient.GetAsync("https://newapi.conveyor.cloud/api/gens").Result;
            return response.Content.ReadAsAsync<List<Gens>>().Result;
        }
    }
}
