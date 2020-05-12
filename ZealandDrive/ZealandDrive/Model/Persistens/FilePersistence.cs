using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ZealandDrive.Model.Persistens
{
    class FilePersistence : IPersistens
    {
        private static StorageFolder folder = ApplicationData.Current.LocalFolder;
        private const String FileName = "UsersFil.json";
        private List<User> _cacheUsers = new List<User>();


        public async Task<ICollection<User>> LoadUsers()
        {
            if (await DoesExists(FileName))
            {
                StorageFile dataFile = await folder.GetFileAsync(FileName);
                string dataJSON = await FileIO.ReadTextAsync(dataFile);

                _cacheUsers = JsonConvert.DeserializeObject<List<User>>(dataJSON);
            }

            _cacheUsers = (_cacheUsers == null) ? new List<User>() : new List<User>(_cacheUsers);
            return _cacheUsers;
        }

        public async void SaveUser(ICollection<User> users)
        {
            _cacheUsers = new List<User>(users);

            StorageFile file;
            if (await DoesExists(FileName))
            {
                file = await folder.CreateFileAsync(FileName, CreationCollisionOption.ReplaceExisting);
            }
            else
            {
                file = await folder.CreateFileAsync(FileName);
            }

            await FileIO.WriteTextAsync(file, JsonConvert.SerializeObject(users));
        }

        public bool UpdateUser(User user)
        {
            User fundetuser = _cacheUsers.Find(k => k.Id == user.Id);

            if (fundetuser != null)
            {
                fundetuser.Name = user.Name;
                fundetuser.Lastname = user.Lastname;
                fundetuser.Email = user.Email;
                fundetuser.Password = user.Password;

                SaveUser(_cacheUsers);
                return true;
            }

            return false;
        }

        public bool OpretUser(User user)
        {
            _cacheUsers.Add(user);
            SaveUser(_cacheUsers);
            return true;
        }

        public User DeleteUser(User user)
        {
            User fundetuser = _cacheUsers.Find(k => k.Id == user.Id);

            if (fundetuser != null)
            {
                _cacheUsers.Remove(fundetuser);
                SaveUser(_cacheUsers);
            }

            return user;
        }


        private async Task<bool> DoesExists(String filename)
        {
            bool exists = false;
            IReadOnlyList<StorageFile> files = await folder.GetFilesAsync();
            foreach (StorageFile file in files)
            {
                if (file.Name == filename)
                {
                    return true; // exists 
                }
            }
            return exists;
        }
    }
}
