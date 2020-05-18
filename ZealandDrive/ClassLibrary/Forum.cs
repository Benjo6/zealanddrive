using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class Forum
    {
        private int _id;
        private string _header;
        private string _content;
        // maybe private int userid;

        public Forum() : this("","",0)
        {
        }

        public Forum(string header, string content, int id)
        {
            _header = header;
            _content = content;
            _id = id;
        }

        public string Header { get => _header; set => _header = value; }
        public string Besked { get => _content; set => _content = value; }
        public int ID { get => _id; set => _id = value; }

        public override string ToString()
        {
            return $"header = {_header}, content = {_content}, id = {_id}";
        }
    }
}
