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
    class DBPersistence : IPersistens<Route>
    {
        private string URI = @"http://localhost:60951/api/Car/";
        public async Task<ICollection<Route>> Load()
        {
            List<Route> liste = new List<Route>();

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(URI);
                liste = JsonConvert.DeserializeObject<List<Route>>(json);
            }

            return liste;
        }

        public async Task<bool> Update(Route users)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(users);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PutAsync(URI + users.Id, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Opret(Route users)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(users);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PostAsync(URI, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task<Route> Delete(Route users)
        {
            using (HttpClient client = new HttpClient())
            {
                var x = await client.DeleteAsync(URI + users.Id);
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