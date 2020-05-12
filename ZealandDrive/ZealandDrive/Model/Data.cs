using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Model
{
    class Data
    {

        private static string conn = "data source=zealand-drive.database.windows.net;initial catalog=ZealandDrive;persist security info=True;user id=zealand-drive-admin;password=Secret1!;multipleactiveresultsets=True;application name=EntityFramework";

        private async Task<IList<User>> HentAlleUser()
        {

            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(conn);
                IList<User> users = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<User>>(content);
                return users;
            }
        }

        private async Task<User> HentEn(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(conn + id);
                User users = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(content);
                return users;
            }
        }

        private async Task<bool> OpretUser(User g)
        {
            using (HttpClient client = new HttpClient())
            {
                String jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(g);
                StringContent content =
                new StringContent(jsonStr, Encoding.UTF8, "application/json");
                HttpResponseMessage resultMessage =
               await client.PostAsync(conn, content);
                if (resultMessage.IsSuccessStatusCode)
                {
                    string okRes = await resultMessage.Content.ReadAsStringAsync();
                    bool res = Newtonsoft.Json.JsonConvert.DeserializeObject<bool>(okRes);
                    return res;
                }
            }
            return false;
        }

        private async Task<bool> OpdaterUser(User u, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(u);
                StringContent content =
                new StringContent(jsonStr, Encoding.UTF8, "application/json");
                HttpResponseMessage resultMessage =
               await client.PutAsync(conn + id, content);
                if (resultMessage.IsSuccessStatusCode)
                {
                    string okRes = await resultMessage.Content.ReadAsStringAsync();
                    bool res = Newtonsoft.Json.JsonConvert.DeserializeObject<bool>(okRes);
                    return res;
                }
            }
            return false;
        }

        private async Task<User> SletUser(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resultMessage =
               await client.DeleteAsync(conn + id);
                if (resultMessage.IsSuccessStatusCode)
                {
                    string okRes = await resultMessage.Content.ReadAsStringAsync();
                    User res = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(okRes);
                    return res;
                }
                return null;
            }
        }
        //private async Task<IList<Hotel>> HentAlleHotel()
        //{

        //    using (HttpClient client = new HttpClient())
        //    {
        //        string content = await client.GetStringAsync(URI1);
        //        IList<Hotel> hotels = JsonConvert.DeserializeObject<IList<Hotel>>(content);
        //        return hotels;
        //    }
        //}
        //private async Task<Hotel> HentEt(int id)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        string content = await client.GetStringAsync(URI1 + id);
        //        Hotel hotels = JsonConvert.DeserializeObject<Hotel>(content);
        //        return hotels;
        //    }
        //}

        //private async Task<bool> OpretHotel(Hotel h)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        String jsonStr = JsonConvert.SerializeObject(h);
        //        StringContent content =
        //        new StringContent(jsonStr, Encoding.UTF8, "application/json");
        //        HttpResponseMessage resultMessage =
        //       await client.PostAsync(URI1, content);
        //        if (resultMessage.IsSuccessStatusCode)
        //        {
        //            string okRes = await resultMessage.Content.ReadAsStringAsync();
        //            bool res = JsonConvert.DeserializeObject<bool>(okRes);
        //            return res;
        //        }
        //    }
        //    return false;
        //}
        //private async Task<bool> OpdaterHotel(Hotel h, int id)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        String jsonStr = JsonConvert.SerializeObject(h);
        //        StringContent content =
        //        new StringContent(jsonStr, Encoding.UTF8, "application/json");
        //        HttpResponseMessage resultMessage =
        //       await client.PutAsync(URI1 + id, content);
        //        if (resultMessage.IsSuccessStatusCode)
        //        {
        //            string okRes = await resultMessage.Content.ReadAsStringAsync();
        //            bool res = JsonConvert.DeserializeObject<bool>(okRes);
        //            return res;
        //        }
        //    }
        //    return false;
        //}

        //private async Task<Hotel> SletHotel(int id)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        HttpResponseMessage resultMessage =
        //       await client.DeleteAsync(URI1 + id);
        //        if (resultMessage.IsSuccessStatusCode)
        //        {
        //            string okRes = await resultMessage.Content.ReadAsStringAsync();
        //            Hotel res = JsonConvert.DeserializeObject<Hotel>(okRes);
        //            return res;
        //        }
        //        return null;
        //    }
        //}
    }
}

