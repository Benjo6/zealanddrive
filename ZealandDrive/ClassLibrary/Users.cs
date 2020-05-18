﻿using System;
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
        private string _tmpPassword;
        private string _token;

        public string name { get => _name; set => _name =value ; }

        public string lastname { get=> _lastName; set => _lastName = value; }

        public string email { get => _email; set => _email = value; }

        public string password { get => _password; set => _password = value; }
        public string tmpPassword { get => _password; set => _password = value; }
        // her vælger man at krypter passwordet ved at tage passwordet og lave det om til exkempelvis HMAC kryptering.
        public string token { get => _password; set => _password = value; }
        // Her vælger man at lave et token der bliver ved med at sendes rundt i header filen, sådan at man ved hvem der er logget ind. 
        // Hvis brugeren er logget ud bliver token fjernet i databasen og derfor at burgeren ikke loget ind mere, selv om han har sin gamle token kode.

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
            _tmpPassword = tmpPassword;
            _token = token;
        }

        public override string ToString()
        {
            return $"name is: {name}, lastname is: {lastname}, Email is: {email}, Password is: {password}, tmp password is: {tmpPassword}, Password is: {token}";
        }
    }
}

