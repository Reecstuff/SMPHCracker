using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.Model
{
    public enum Status
    {
        NoDevice = -1,
        Unauthorized = 0,
        ADB = 1,
        Root = 21,       // + ADB
        Recovery = 321,    // + Root
        Sideload = 5
    }
}
