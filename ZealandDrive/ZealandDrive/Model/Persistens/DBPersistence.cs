using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Model.Persistens
{
    class DBPersistence : IPersistens
    {
        private string URI = "data source=zealand-drive.database.windows.net;initial catalog=ZealandDrive;persist security info=True;user id=zealand-drive-admin;password=Secret1!;MultipleActiveResultSets=True;App=EntityFramework";
        public async Task<ICollection<User>> LoadUsers()
        {
            List<User> liste = new List<User>();

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(URI);
                liste = JsonConvert.DeserializeObject<List<User>>(json);
            }

            return liste;
        }

        public void SaveUser(ICollection<User> users)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool OpretUser(User user)
        {
            throw new NotImplementedException();
        }

        public User DeleteUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
