using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.Model
{
    public enum Status
    {
        NoDevice = 0,
        Unauthorized = 1,
        ADB = 2,
        Root = 32,       // + ADB
        Recovery = 432,    // + Root
        Sideload = 5
    }
}
