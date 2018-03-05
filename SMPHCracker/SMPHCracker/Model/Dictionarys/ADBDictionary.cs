using SMPHCracker.Model.Enums;
using System;
using System.Collections.Generic;

namespace SMPHCracker.Model.Dictionarys
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
            dic.Add(ADBCommands.SHELLROOT, "adb shell \"su -c '");
            dic.Add(ADBCommands.GETPROP, "adb shell getprop");
            dic.Add(ADBCommands.SETPROP, "adb shell \"su -c 'setprop");

            dic.Add(ADBCommands.STOPSERVER, "adb kill-server");

            //FASTBOOT
            dic.Add(ADBCommands.UNLOCK, "fastboot flashing unlock");
            dic.Add(ADBCommands.FLASHRECOVERY, "fastboot flash recovery");
            dic.Add(ADBCommands.FLASHVENDOR, "fastboot flash vendor");

            //SIDELOAD
            dic.Add(ADBCommands.SIDELOADFLASH, "adb sideload /update.zip");
        }

        public Dictionary<ADBCommands, String> GetDictionary()
        {
            return this.dic;
        }
    }
}
