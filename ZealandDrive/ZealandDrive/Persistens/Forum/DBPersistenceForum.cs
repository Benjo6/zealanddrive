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
        private string URI = @"http://zealand-drive.azurewebsites.net/api/Forums/";
        public async Task<ICollection<Forum>> Load()
        {
            List<Forum> liste = new List<Forum>();

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(URI);
                liste = JsonConvert.DeserializeObject<List<Forum>>(json);
            }

            return liste;
        }

        public async Task<bool> Update(Forum ruter)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(ruter);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PutAsync(URI + ruter.ID, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Opret(Forum ruter)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(ruter);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PostAsync(URI, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task<Forum> Delete(Forum ruter)
        {
            using (HttpClient client = new HttpClient())
            {
                var x = await client.DeleteAsync(URI + ruter.ID);
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