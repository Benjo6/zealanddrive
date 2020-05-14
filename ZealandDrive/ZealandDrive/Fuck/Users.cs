using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Fuck
{
    class Users
    {
        public string Name { get => Name; set => Name = value; }

        public string Lastname { get => Lastname; set => Lastname = value; }

        public string Email { get => Email; set => Email = value; }

        public string Password { get => Password; set => Password = value; }
        public int Id { get => Id; set => Id = value; }


        public Users()
        {

        }

        public Users(string name, string lastname, string email, string password)
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
