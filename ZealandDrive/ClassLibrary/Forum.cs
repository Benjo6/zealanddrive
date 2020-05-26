using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Forum
    {
        private int _id;
        private string _header;
        private string _content;
        private int _userId;
        // maybe private int userid;

        public Forum() 
        {
        }

        public Forum(string header, string content, int id)
        {
            _header = header;
            _content = content;
            _id = id;
        }

        public string header { get => _header; set => _header = value; }
        public string content { get => _content; set => _content = value; }
        public int id { get => _id; set => _id = value; }
        public int userId { get => _userId; set => _userId = value; }

        public override string ToString()
        {
            return $"header = {_header}, content = {_content}, id = {_id}, user id = {_userId}";
        }
    }
}
