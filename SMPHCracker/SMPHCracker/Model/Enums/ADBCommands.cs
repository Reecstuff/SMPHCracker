using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.Model.Enums
{
    public enum ADBCommands
    {
        //ADB
        EXECUTE,        //[COMMAND]

        DEVICES,        //devices
        REBOOT,         //reboot
        RECOVERY,       //reboot recovery
        BOOTLOADER,     //reboot bootloader

        PUSH,           //push [DATEI] [ZIEL]
        PULL,           //pull [DATEI] [ZIEL]
        INSTALL,        //install [APK]

        SHELL,          //shell [COMMAND]
        SHELLROOT,      //shell su [COMMAND]
        GETPROP,        //shell getprop [TAG]
        SETPROP,        //shell su setprop [TAG] [PROP]

        STOPSERVER,     //kill-server

        //FASTBOOT
        UNLOCK,         //flashing unlock [CODE](OPTIONAL)
        FLASHRECOVERY,  //flash recovery [RECOVERY]
        FLASHVENDOR,    //flash vendor [VENDOR]
    }
}
