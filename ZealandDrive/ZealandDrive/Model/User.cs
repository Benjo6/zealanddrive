using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Model
{
    class User
    {
        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


        public User()
        {

        }

        public User(string name, string lastname, string email, string password)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"name is: {Name}, lastname is: {Lastname}, Email is: {Email}, Password is: {Password}";
        }
    }
}
