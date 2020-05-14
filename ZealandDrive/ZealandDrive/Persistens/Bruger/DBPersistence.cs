using ClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZealandDrive.Model;

namespace ZealandDrive.Persistens.Bruger
{
    class DBPersistence : IPersistens <Users>
    {
        private string URI = @"http://localhost:60951/api/Users/";
        public async Task<ICollection<Users>> Load()
        {
            List<Users> liste = new List<Users>();

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(URI);
                liste = JsonConvert.DeserializeObject<List<Users>>(json);
            }

            return liste;
        }

        public async Task<bool> Update(Users users)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(users);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PutAsync(URI + users.Id, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task <bool> Opret(Users users)
        {
            using (HttpClient client = new HttpClient())
            {

                    string json = JsonConvert.SerializeObject(users);
                    StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    var x = await client.PostAsync(URI, stringContent);
                    return x.IsSuccessStatusCode;
            }
        }

        public async Task <Users> Delete(Users users)
        {
            using (HttpClient client = new HttpClient())
            {
                var x = await client.DeleteAsync(URI + users.Id);
                if (x.IsSuccessStatusCode)
                {
                    string str = await x.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Users>(str);
                }
                return null;
            }
        }
    }
}
