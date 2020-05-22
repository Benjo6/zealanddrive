﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Schema;

namespace ClassLibrary
{
    public class Car
    {
        private int _id;
        private string _color;
        private string _brand;
        private string _model;
        private string _nummerplade;
        private int _year;
        private int _seats;
        private int _userId;
        private Singleton x;


        public int userId
        {
            get => x.UserCurrent;
            
        }


        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string color { get => _color; set => _color = value; }
        public string brand { get => _brand; set => _brand = value; }
        public string model { get => _model; set => _model = value; }
        public string nummerplade { get => _nummerplade; set => _nummerplade = value; }
        public int year { get => _year; set => _year = value; }
        public int seats { get => _seats; set => _seats = value; }

        public Car()
        {

        }

        public Car(int id, string color, string brand, string model, string nummerplade, int year, int seats, int userId)
        {
            x = Singleton.Instance;
            _id = id;
            _color = color;
            _brand = brand;
            _model = model;
            _nummerplade = nummerplade;
            _year = year;
            _seats = seats;
            _userId = userId;
        }

        public override string ToString()
        {
            return $"color = {_color}, brand = {_brand}, model = {_model}, nummerplade = {_nummerplade}, year = {_year}, seats = {_seats}";
        }
    }
}
