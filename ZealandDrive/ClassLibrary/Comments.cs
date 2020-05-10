﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Comments
    {
        private int _id;
        private string _text;
        private int _userId;
        private int _routeId;


     

        public int Id { get => _id; set => _id = value; }
        public string Text { get => _text; set => _text = value; } 

        public int UserId
        {
            get => _userId;
            set => _userId = value;
        }

        public int RouteId
        {
            get => _routeId;
            set => _routeId = value;
        }

        public Comments()
        {

        }
        public Comments(int id, string text, int userId, int routeId)
        {
            _id = id;
            _text = text;
            _userId = userId;
            _routeId = routeId;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
