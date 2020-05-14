using ClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Model.Persistens
{
    class DBPersistence : IPersistens <User>
    {
        private string URI = @"http://zealand-drive.azurewebsites.net/api/users/";
        public async Task<ICollection<User>> Load()
        {
            List<User> liste = new List<User>();

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(URI);
                liste = JsonConvert.DeserializeObject<List<User>>(json);
            }

            return liste;
        }

        public async Task<bool> Update(User user)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(user);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PutAsync(URI + user.Id, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task <bool> Opret(User user)
        {
            using (HttpClient client = new HttpClient())
            {

                    string json = JsonConvert.SerializeObject(user);
                    StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    var x = await client.PostAsync(URI, stringContent);
                    return x.IsSuccessStatusCode;
            }
        }

        public async Task <User> Delete(User user)
        {
            using (HttpClient client = new HttpClient())
            {
                var x = await client.DeleteAsync(URI + user.Id);
                if (x.IsSuccessStatusCode)
                {
                    string str = await x.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<User>(str);
                }
                return null;
            }
        }
    }
}
