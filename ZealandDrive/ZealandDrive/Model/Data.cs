using ClassLibrary;
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

        private async Task<IList<Users>> HentAlleUser()
        {

            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(conn);
                IList<Users> users = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Users>>(content);
                return users;
            }
        }

        private async Task<Users> HentEn(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(conn + id);
                Users users = Newtonsoft.Json.JsonConvert.DeserializeObject<Users>(content);
                return users;
            }
        }

        private async Task<bool> OpretUser(Users g)
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

        private async Task<bool> OpdaterUser(Users u, int id)
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

        private async Task<Users> SletUser(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resultMessage =
               await client.DeleteAsync(conn + id);
                if (resultMessage.IsSuccessStatusCode)
                {
                    string okRes = await resultMessage.Content.ReadAsStringAsync();
                    Users res = Newtonsoft.Json.JsonConvert.DeserializeObject<Users>(okRes);
                    return res;
                }
                return null;
            }
        }
        private async Task<IList<Car>> HentAlleCar()
        {

            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(conn);
                IList<Car> car = Newtonsoft.Json.JsonConvert.DeserializeObject<IList<Car>>(content);
                return car;
            }
        }

        private async Task<Car> HentEnCar(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string content = await client.GetStringAsync(conn + id);
                Car car = Newtonsoft.Json.JsonConvert.DeserializeObject<Car>(content);
                return car;
            }
        }

        private async Task<bool> OpretCar(Car c)
        {
            using (HttpClient client = new HttpClient())
            {
                String jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(c);
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

        private async Task<bool> OpdaterCar(Car c, int id)
        {
            using (HttpClient client = new HttpClient())
            {
                String jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(c);
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

        private async Task<Car> SletCar(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage resultMessage =
               await client.DeleteAsync(conn + id);
                if (resultMessage.IsSuccessStatusCode)
                {
                    string okRes = await resultMessage.Content.ReadAsStringAsync();
                    Car res = Newtonsoft.Json.JsonConvert.DeserializeObject<Car>(okRes);
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

