using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.Provider;
using AppCarFinance.Helpers;
using AppCarFinance.Model;
using Newtonsoft.Json;

namespace AppCarFinance.Service
{
    class ApiServices
    {
        HttpClient httpClient = new HttpClient();
        //public async Task<List<Members>> GetMember()
        //{
        //    var client = new HttpClient();
        //    var json = await client.GetStringAsync(Constant.Api + "api/members");
        //    var members = JsonConvert.DeserializeObject<List<Members>>(json);
        //    return members;
        //}

        public List<Members> GetMemberses()
        {
            HttpResponseMessage response = httpClient.GetAsync("https://webcarfinance.conveyor.cloud/api/members").Result;
            return response.Content.ReadAsAsync<List<Members>>().Result;
        }
    }
}
