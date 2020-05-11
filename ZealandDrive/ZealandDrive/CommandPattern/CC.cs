using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.CommandPattern
{
    public class CC: ICC
    {
        private CompositeCommand _opretRuteCommand = new CompositeCommand();

        public CompositeCommand OpretRuteCommand
        {
            get { return _opretRuteCommand; }
        }
    }
}
