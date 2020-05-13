using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ZealandDrive.Model.Persistens
{
    class FilePersistence : IPersistens<User>
    {
        private static StorageFolder folder = ApplicationData.Current.LocalFolder;
        private const String FileName = "UsersFil.json";
        private List<User> _cacheUsers = new List<User>();


        public async Task<ICollection<User>> Load()
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

        public async void Save(ICollection<User> users)
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

        public Task<bool> Update(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Opret(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Delete(User user)
        {
            throw new NotImplementedException();
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
