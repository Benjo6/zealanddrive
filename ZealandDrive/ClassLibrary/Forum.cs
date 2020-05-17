using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class Forum
    {
        private int id;
        private string header;
        private string besked;
        // maybe private int userid;

        public Forum() : this("","",0)
        {
        }

        public Forum(string Header, string Besked, int Id)
        {
            header = Header;
            besked = Besked;
            id = Id;
        }

        public string Header { get => header; set => header = value; }
        public string Besked { get => besked; set => besked = value; }
        public int ID { get => id; set => id = value; }

        public override string ToString()
        {
            return $"Header = {header}, Besked = {besked}, Id = {id}";
        }
    }
}
