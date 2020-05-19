using ClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Persistens.Bil
{
    class DBPersistenceCar : IPersistens<Car>
    {
        private string URI = @"http://zealand-drive.azurewebsites.net/api/cars/";
        public async Task<ICollection<Car>> Load()
        {
            List<Car> liste = new List<Car>();

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(URI);
                liste = JsonConvert.DeserializeObject<List<Car>>(json);
            }

            return liste;
        }

        public async Task<bool> Update(Car car)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(car);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PutAsync(URI + car.id, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Opret(Car car)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(car);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PostAsync(URI, stringContent);
                return x.IsSuccessStatusCode;
            }
        }



        public async Task<Car> Delete(Car car)
        {
            using (HttpClient client = new HttpClient())
            {
                var x = await client.DeleteAsync(URI + car.id);
                if (x.IsSuccessStatusCode)
                {
                    string str = await x.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Car>(str);
                }
                return null;
            }
        }
    }
}