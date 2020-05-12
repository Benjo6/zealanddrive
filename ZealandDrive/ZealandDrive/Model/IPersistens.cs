using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Model
{
    interface IPersistens
    {
        bool OpretUser(User user);
    }
}
