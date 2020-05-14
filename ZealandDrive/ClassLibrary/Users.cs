using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Users
    {
        private int _id;
        private string _name;
        private string _lastName;
        private string _email;
        private string _password;

        public string Name { get => _name; set => _name =value ; }

        public string Lastname { get=> _lastName; set => _lastName = value; }

        public string Email { get => _email; set => _email = value; }

        public string Password { get => _password; set => _password = value; }
        public int Id { get => _id; set => _id = value; }


        public Users()
        {

        }

        public Users(string name, string lastname, string email, string password)
        {
            _name = name;
            _lastName = lastname;
            _email = email;
            _password = password;
        }

        public override string ToString()
        {
            return $"name is: {Name}, lastname is: {Lastname}, Email is: {Email}, Password is: {Password}";
        }
    }
}

