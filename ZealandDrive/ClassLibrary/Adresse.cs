using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class Adresse
    {
        private string _adresse;
        private string _postnummer;
        private string _by;


        public Adresse() : this("", "", "")
        {
        }

        public Adresse(string adresse, string postnummer, string by)
        {
            _adresse = adresse;
            _postnummer = postnummer;
            _by = by;
        }

        public string Adr { get => _adresse; set => _adresse = value; }
        public string Postnummer { get => _postnummer; set => _postnummer = value; }
        public string By { get => _by; set => _by = value; }

        public override string ToString()
        {
            return $"Adresse = {_adresse}, Postnummer = {_postnummer}, by = {_by}";
        }
    }
}
