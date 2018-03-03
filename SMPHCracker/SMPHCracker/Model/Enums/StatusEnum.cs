using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.Model.Enums
{
    public enum StatusEnum
    {
        NoDevice,
        Unauthorized,
        ADB,
        Root,       // + ADB
        Recovery,    // + Root
        Sideload
    }
}
