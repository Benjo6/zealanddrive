using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Model
{
    interface IPersistens
    {
        Task<ICollection<User>> LoadUsers();
        void SaveUser(ICollection<User> user);

        bool OpretUser(User user);

        bool UpdateUser(User user);


        User DeleteUser(User user);

    }
}
