using ClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ZealandDrive.Persistens
{
    class FilePersistence : IPersistens<Users>
    {
        private static StorageFolder folder = ApplicationData.Current.LocalFolder;
        private const String FileName = "UsersFil.json";
        private List<Users> _cacheUsers = new List<Users>();


        public async Task<ICollection<Users>> Load()
        {
            if (await DoesExists(FileName))
            {
                StorageFile dataFile = await folder.GetFileAsync(FileName);
                string dataJSON = await FileIO.ReadTextAsync(dataFile);

                _cacheUsers = JsonConvert.DeserializeObject<List<Users>>(dataJSON);
            }

            _cacheUsers = (_cacheUsers == null) ? new List<Users>() : new List<Users>(_cacheUsers);
            return _cacheUsers;
        }

        public async void Save(ICollection<Users> users)
        {
            _cacheUsers = new List<Users>(users);

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

        public Task<bool> Update(Users user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Opret(Users user)
        {
            throw new NotImplementedException();
        }

        public Task<Users> Delete(Users user)
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
