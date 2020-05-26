using ClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZealandDrive.Model;

namespace ZealandDrive.Persistens.F
{
    class DBPersistenceForum : IPersistens<Forum>
    {
        private string URI = @"https://restserver20200521122545.azurewebsites.net/api/Fora/";
        public async Task<ICollection<Forum>> Load()
        {
            List<Forum> forums;
            using (HttpClient client = new HttpClient())
            {
                string jstring = await client.GetStringAsync(URI);
                forums = JsonConvert.DeserializeObject<List<Forum>>(jstring);
            }
            return forums;
            //return null;
        }

        public async Task<bool> Update(Forum ruter)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(ruter);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PutAsync(URI + ruter.id, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Opret(Forum f)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(f);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PostAsync(URI, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task<Forum> Delete(Forum ruter)
        {
            using (HttpClient client = new HttpClient())
            {
                var x = await client.DeleteAsync(URI + ruter.id);
                if (x.IsSuccessStatusCode)
                {
                    string str = await x.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Forum>(str);
                }
                return null;
            }
        }
    }
}