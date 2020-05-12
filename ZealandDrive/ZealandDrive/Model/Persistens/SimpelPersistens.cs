using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Model.Persistens
{
    class SimpelPersistens : IPersistens
    {
        
        // simple list in memory  disappear when shutting down the app
        private static List<User> _users;

        public SimpelPersistens()
        {
            _users = populateUsers();
        }



        public async Task<ICollection<User>> LoadUsers()
        {
            return new List<User>(_users);
        }

        public void SaveUser(ICollection<User> users)
        {
            _users.Clear();
            foreach (User user in users)
            {
                _users.Add(user);
            }
        }

        public bool UpdateUser(User user)
        {
            User userToBeUpdated = _users.Find(k => k.Id == user.Id);
            if (userToBeUpdated == null)
            {
                return false;
            }

            userToBeUpdated.Name = user.Name;
            userToBeUpdated.Lastname = user.Lastname;
            userToBeUpdated.Email = user.Email;
            userToBeUpdated.Password = user.Password;

            return true;
        }

        public bool OpretUser(User user)
        {
            _users.Add(user);
            return true;
        }

        public User DeleteUser(User user)
        {
            User userToBeDeleted = _users.Find(k => k.Id == user.Id);
            _users.Remove(userToBeDeleted);
            return userToBeDeleted;
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

