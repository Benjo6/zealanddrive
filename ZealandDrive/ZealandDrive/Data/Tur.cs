using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Data
{
    class Tur
    {
        private string _adresse;
        private string _postnummer;
        private string _by;

        
        public Tur() : this ("","","")
        {
        }

        public Tur(string adresse, string postnummer, string by)
        {
            _adresse = adresse;
            _postnummer = postnummer;
            _by = by;
        }

        public string Adresse { get => _adresse; set => _adresse = value; }
        public string Postnummer { get => _postnummer; set => _postnummer = value; }
        public string By { get => _by; set => _by = value; }
        
        public override string ToString()
        {
            return $"Adresse = {_adresse}, Postnummer = {_postnummer}, by = {_by}";
        }
    }
}
