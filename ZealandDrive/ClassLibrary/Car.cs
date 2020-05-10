using System;
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
        private int _year;
        private int _seats;
        private int _userId;

        public int UserId
        {
            get => _userId;
            set => _userId = value;
        }


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Color { get => _color; set => _color = value; }
        public string Brand { get => _brand; set => _brand = value; }
        public string Model { get => _model; set => _model = value; }
        public int Year { get => _year; set => _year = value; }
        public int Seats { get => _seats; set => _seats = value; }

        public Car()
        {

        }

        public Car(int id, string color, string brand, string model, int year, int seats, int userId)
        {
            _id = id;
            _color = color;
            _brand = brand;
            _model = model;
            _year = year;
            _seats = seats;
            _userId = userId;
        }

        public override string ToString()
        {
            return $"Id = {_id}, color = {_color}, brand = {_brand}, model = {_model}, year = {_year}, seats = {_seats}, userId = {_userId}";
        }
    }
}
