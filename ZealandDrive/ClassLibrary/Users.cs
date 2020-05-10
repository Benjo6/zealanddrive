using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Users
    {
        private int _id;
        private string _email;
        private string _name;
        private string _lastname;
        private string _password;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Lastname
        {
            get => _lastname;
            set => _lastname = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public Users(int id, string email, string name, string lastname, string password)
        {
            _id = id;
            _email = email;
            _name = name;
            _lastname = lastname;
            _password = password;
        }

        public Users()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
