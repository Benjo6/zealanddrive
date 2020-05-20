using ClassLibrary;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using ZealandDrive.Model;

namespace ZealandDrive.Persistens.Bruger
{
    class DBPersistence : IPersistens<Users>
    {
        private string URI = @"http://zealand-drive.azurewebsites.net/api/users/";
        public async Task<ICollection<Users>> Load()
        {
            List<Users> users;
            using (HttpClient client = new HttpClient())
            {
                string jstring = await client.GetStringAsync(URI);
                users = JsonConvert.DeserializeObject<List<Users>>(jstring);
            }
            return users;
            //return null;
        }

        public async Task<bool> Update(Users users)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(users);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PutAsync(URI + users.id, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Opret(Users users)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(users);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PostAsync(URI, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task<Users> Delete(Users users)
        {
            using (HttpClient client = new HttpClient())
            {
                var x = await client.DeleteAsync(URI + users.id);
                if (x.IsSuccessStatusCode)
                {
                    string str = await x.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Users>(str);
                }
                return null;
            }
        }

        public async Task<Users> LogInd(Users user)
        {
            using (HttpClient client = new HttpClient())
            {
                string jstring = await client.GetStringAsync(URI + user.id);
                user = JsonConvert.DeserializeObject<Users>(jstring);
            }
            return user;
        }


    }
}