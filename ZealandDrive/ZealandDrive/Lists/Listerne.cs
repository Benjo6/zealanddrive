using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Lists
{
    public class Listerne
    {
        private ObservableCollection<string> _hoursList;
        private ObservableCollection<string> _minutesList;


        public Listerne()
        {
            _hoursList = new ObservableCollection<string>(DoHours());
            _minutesList = new ObservableCollection<string>(DoMinutes());

            
        }
        public ObservableCollection<string> Timer
        {
            get { return _hoursList; }
        }
        public ObservableCollection<string> Minutter
        {
            get { return _minutesList; }
        }

        public ObservableCollection<string> DoHours()
        {
            ObservableCollection<string> vs = new ObservableCollection<string>();
            vs.Add("01");
            vs.Add("02");
            vs.Add("03");
            vs.Add("04");
            vs.Add("05");
            vs.Add("06");
            vs.Add("07");
            vs.Add("08");
            vs.Add("09");
            vs.Add("10");
            vs.Add("11");
            vs.Add("12");
            vs.Add("13");
            vs.Add("14");
            vs.Add("15");
            vs.Add("16");
            vs.Add("17");
            vs.Add("18");
            vs.Add("19");
            vs.Add("20");
            vs.Add("21");
            vs.Add("22");
            vs.Add("23");
            vs.Add("24");
            return vs;

        }

        public ObservableCollection<string> DoMinutes()
        {
            ObservableCollection<string> vs = new ObservableCollection<string>();
            vs.Add("01");
            vs.Add("02");
            vs.Add("03");
            vs.Add("04");
            vs.Add("05");
            vs.Add("06");
            vs.Add("07");
            vs.Add("08");
            vs.Add("09");
            vs.Add("10");
            vs.Add("11");
            vs.Add("12");
            vs.Add("13");
            vs.Add("14");
            vs.Add("15");
            vs.Add("16");
            vs.Add("17");
            vs.Add("18");
            vs.Add("19");
            vs.Add("20");
            vs.Add("21");
            vs.Add("22");
            vs.Add("23");
            vs.Add("24");
            vs.Add("25");
            vs.Add("26");
            vs.Add("27");
            vs.Add("28");
            vs.Add("29");
            vs.Add("30");
            vs.Add("31");
            vs.Add("32");
            vs.Add("33");
            vs.Add("34");
            vs.Add("35");
            vs.Add("36");
            vs.Add("37");
            vs.Add("38");
            vs.Add("39");
            vs.Add("40");
            vs.Add("41");
            vs.Add("42");
            vs.Add("43");
            vs.Add("44");
            vs.Add("45");
            vs.Add("46");
            vs.Add("47");
            vs.Add("48"); 
            vs.Add("49");
            vs.Add("50");
            vs.Add("51");
            vs.Add("52");
            vs.Add("53");
            vs.Add("54");
            vs.Add("55");
            vs.Add("56");
            vs.Add("57");
            vs.Add("58");
            vs.Add("59");
            vs.Add("60");
            return vs;
        }
    }
}
