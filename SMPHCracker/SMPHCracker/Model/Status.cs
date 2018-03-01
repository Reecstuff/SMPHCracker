using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.Model
{
    public enum Status
    {
        NoDevice,
        Unauthorized,
        ADB,
        Root,       // + ADB
        Recovery,    // + Root
        Sideload
    }
}
