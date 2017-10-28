using NaControl.App.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NaControl.App.Services
{
    public class GroupService
    {
        HttpClient _client = new HttpClient();
        string BaseUrl = "http://nacontrolapi.azurewebsites.net/";

        public async Task<List<Group>> GetGroupsAsync()
        {
            try
            {
                _client.BaseAddress = new Uri(BaseUrl);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                _client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = _client.GetAsync("api/group").Result;
                string stringData = response.Content.ReadAsStringAsync().Result;
                List<Group> data = JsonConvert.DeserializeObject<List<Group>>(stringData);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
