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

        public string name { get => _name; set => _name =value ; }

        public string lastname { get=> _lastName; set => _lastName = value; }

        public string email { get => _email; set => _email = value; }

        public string password { get => _password; set => _password = value; }
        public int id { get => _id; set => _id = value; }


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
            return $"name is: {name}, lastname is: {lastname}, Email is: {email}, Password is: {password}";
        }
    }
}

