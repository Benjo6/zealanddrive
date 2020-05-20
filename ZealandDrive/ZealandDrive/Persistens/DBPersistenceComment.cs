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
    class DBPersistenceComment : IPersistens<Comments>
    {
        private string URI = @"http://zealand-drive.azurewebsites.net/api/comments/";
        public async Task<ICollection<Comments>> Load()
        {
            List<Comments> comments;
            using (HttpClient client = new HttpClient())
            {
                string jstring = await client.GetStringAsync(URI);
                comments = JsonConvert.DeserializeObject<List<Comments>>(jstring);
            }
            return comments;
            //return null;
        }

        public async Task<bool> Update(Comments comments)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(comments);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PutAsync(URI + comments.id, stringContent);
                return x.IsSuccessStatusCode;
            }
        }

        public async Task<bool> Opret(Comments comments)
        {
            using (HttpClient client = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(comments);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var x = await client.PostAsync(URI, stringContent);
                return x.IsSuccessStatusCode;
            }
        }



        public async Task<Comments> Delete(Comments comment)
        {
            using (HttpClient client = new HttpClient())
            {
                var x = await client.DeleteAsync(URI + comment.id);
                if (x.IsSuccessStatusCode)
                {
                    string str = await x.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Comments>(str);
                }
                return null;
            }
        }
    }
}
