using ClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Persistens
{
    class DBPersistencePassenger : IPersistens <Passenger>
    {
        private string URI = @"http://zealand-drive.azurewebsites.net/api/passengers/";
        public async Task<ICollection<Passenger>> Load()
        {
            List<Passenger> passengers;
            using (HttpClient client = new HttpClient())
            {
                string jstring = await client.GetStringAsync(URI);
                passengers = JsonConvert.DeserializeObject<List<Passenger>>(jstring);
            }
            return passengers;
            //return null;
        }

        public async Task<bool> Update(Passenger passenger)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(passenger);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PutAsync(URI + passenger.id, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Opret(Passenger passenger)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(passenger);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PostAsync(URI, stringContent);
                return x.IsSuccessStatusCode;
            }
        }



        public async Task<Passenger> Delete(Passenger passenger)
        {
            using (HttpClient client = new HttpClient())
            {
                var x = await client.DeleteAsync(URI + passenger.id);
                if (x.IsSuccessStatusCode)
                {
                    string str = await x.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Passenger>(str);
                }
                return null;
            }
        }
    }
}
