using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPHCracker.Model
{
    class ADBDictionary
    {
        private Dictionary<ADBCommands, String> dic = new Dictionary<ADBCommands, string>();

        public ADBDictionary()
        {
            //ADB
            dic.Add(ADBCommands.EXECUTE, "adb");

            dic.Add(ADBCommands.DEVICES, "adb devices");
            dic.Add(ADBCommands.REBOOT, "adb reboot");
            dic.Add(ADBCommands.RECOVERY, "adb recovery");
            dic.Add(ADBCommands.BOOTLOADER, "adb bootloader");

            dic.Add(ADBCommands.PUSH, "adb push -p");
            dic.Add(ADBCommands.PULL, "adb pull -p");
            dic.Add(ADBCommands.INSTALL, "adb install");

            dic.Add(ADBCommands.SHELL, "adb shell");
            //TODO - fix SU-Problem
            dic.Add(ADBCommands.SHELLROOT, $"adb shell \"su -c '[BEFEHL]'\"");
            dic.Add(ADBCommands.GETPROP, "adb shell getprop");
            dic.Add(ADBCommands.SETPROP, $"adb shell \"su -c 'setprop [TAG] [PROP]'\"");

            dic.Add(ADBCommands.STOPSERVER, "adb kill-server");

            //FASTBOOT
            dic.Add(ADBCommands.UNLOCK, "fastboot flashing unlock");
            dic.Add(ADBCommands.FLASHRECOVERY, "fastboot flash recovery");
            dic.Add(ADBCommands.FLASHVENDOR, "fastboot flash vendor");
        }

        public Dictionary<ADBCommands, String> GetDictionary()
        {
            return this.dic;
        }
    }
}
