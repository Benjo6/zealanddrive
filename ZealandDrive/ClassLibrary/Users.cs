using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;


namespace ClassLibrary
{
    public class Users
    {
        private int _id;
        private string _name;
        private string _lastName;
        private string _email;
        private string _password;
        //private string _tmpPassword;
        //private string _token;

        public string name { get => _name; set => _name =value ; }
        public string lastname { get=> _lastName; set => _lastName = value; }
        public string email { get => _email; set => _email = value; }
        public string password { get => _password; set => _password = value; }
       // public string tmpPassword { get => _password; set => _password = value; }
       // public string token { get => _password; set => _password = value; }

        public int id { get => _id; set => _id = value; }


        public Users()
        {

        }

        public Users(string name, string lastname, string email, string password, string tmpPassword, string token)
        {
            _name = name;
            _lastName = lastname;
            _email = email;
            _password = password;
           // _tmpPassword = tmpPassword;
            //_token = token;
        }

        public bool CheckInformation()
        {
            if (!email.Equals("") && !password.Equals(""))
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return $"name is: {name}, lastname is: {lastname}, Email is: {email}, Password is: {password}";
        }
    }
}

