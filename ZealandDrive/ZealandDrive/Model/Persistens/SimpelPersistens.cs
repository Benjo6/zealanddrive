using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Model.Persistens
{
    class SimpelPersistens : IPersistens<User>
    {
        
        // simple list in memory  disappear when shutting down the app
        private static List<User> _users;

        public SimpelPersistens()
        {
            _users = populateUsers();
        }



        public async Task<ICollection<User>> Load()
        {
            return new List<User>(_users);
        }

        public void  Save(Task<ICollection<User>> users)
        
            {
                throw new NotImplementedException();
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




        private List<User> populateUsers()
        {
            List<User> initialUsers = new List<User>();

            initialUsers.Add(new User("Benjamin", "x", "xx", "xxx"));
            initialUsers.Add(new User("Lukas", "x", "xx", "xxx"));
            initialUsers.Add(new User("Morten", "x", "xx", "xxx"));
            initialUsers.Add(new User("Michelle", "x", "xx", "xxx"));

            return initialUsers;
        }
    }

}

