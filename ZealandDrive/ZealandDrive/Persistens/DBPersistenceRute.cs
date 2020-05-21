using ClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Persistens.Rute
{
    class DBPersistenceRute : IPersistens<Route>
    {
        private string URI = @"https://restserver20200521122545.azurewebsites.net/api/routes/";
        public async Task<ICollection<Route>> Load()
        {
            List<Route> routes;
            using (HttpClient client = new HttpClient())
            {
                string jstring = await client.GetStringAsync(URI);
                routes = JsonConvert.DeserializeObject<List<Route>>(jstring);
            }
            return routes;
        }

        public async Task<bool> Update(Route ruter)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(ruter);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PutAsync(URI + ruter.id, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Opret(Route ruter)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(ruter);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PostAsync(URI, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task<Route> Delete(Route ruter)
        {
            using (HttpClient client = new HttpClient())
            {
                var x = await client.DeleteAsync(URI + ruter.id);
                if (x.IsSuccessStatusCode)
                {
                    string str = await x.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Route>(str);
                }
                return null;
            }
        }
    }
}