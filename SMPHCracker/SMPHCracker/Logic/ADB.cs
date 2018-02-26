using SMPHCracker.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SMPHCracker.Logic
{
    static class ADB
    {
        private static String command;
        private static Dictionary<ADBCommands, String> dic = new Dictionary<ADBCommands, string>();

        public static void start()
        {
            dic.Add(ADBCommands.DEVICES, "adb devices");
        }

        private static ProcessStartInfo ProcessInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            WorkingDirectory = System.IO.Path.GetDirectoryName(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName) + "\\adb",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        //----- Commands

        public static string test(ADBCommands command, params string[] str)
        {
            return ExecuteCommand(String.Join(" ",dic[command],String.Join(" ",str)));
        }

        public static String Execute(String command = null, String difj = null)
        {
            return ExecuteCommand("adb " + command);
        }

        public static String Devices()                                 //devices
        {
            command = "adb devices";

            return ExecuteCommand(command);
        }
        public static String Reboot()                                  //reboot
        {
            command = "adb reboot";

            return ExecuteCommand(command);
        }
        public static String RebootRecovery()                          //reboot recovery
        {
            command = "adb reboot recovery";

            return ExecuteCommand(command);
        }
        public static String RebootBootloader()                        //reboot bootloader
        {
            command = "adb reboot bootloader";

            return ExecuteCommand(command);
        }

        public static String Push(String datei, String ziel)           //push              + DATEI, ZIEL
        {
            command = "adb push -p " + datei + " " + ziel;

            return ExecuteCommand(command);
        }
        public static String Pull(String datei, String ziel)           //pull              + DATEI, ZIEL
        {
            command = "adb pull -p " + datei + " " + ziel;

            return ExecuteCommand(command);
        }

        public static String InstallAPK(String apk)                    //install           + APK
        {
            command = "adb install " + apk;

            return ExecuteCommand(command);
        }

        //----- Fastboot
        public static String FlashingUnlock()                          //flashing unlock
        {
            command = "fastboot flashing unlock";

            return ExecuteCommand(command);
        }
        public static String FlashingUnlock(String code)               //flashing unlock   + CODE
        {
            command = "fastboot flashing unlock " + code;

            return ExecuteCommand(command);
        }

        public static String FlashRecovery(String recovery)            //flash recovery    + RECOVERY
        {
            command = "fastboot flash recovery " + recovery;

            return ExecuteCommand(command);
        }

        public static String FlashVendor(String vendor)                //flash vendor      + VENOR
        {
            command = "fastboot flash vendor " + vendor;

            return ExecuteCommand(command);
        }

        //----- Shell
        public static String Shell(String befehl, Boolean root)    //shell              + Befehl
        {
            if (!root)
            {
                command = "adb shell " + befehl;
            }
            else
            {
                command = "adb shell \"su -c '" + befehl + "'\"";
            }

            return ExecuteCommand(command);
        }

        public static String Getprop(String tag)
        {
            command = "adb shell getprop " + tag;

            return ExecuteCommand(command);
        }

        public static String Setprop(String tag, String prop)
        {
            command = "adb shell setprop " + tag + " " + prop;

            return ExecuteCommand(command);
        }

        public static String SetpropRoot(String tag, String prop)
        {
            command = "adb shell \"su -c 'setprop " + tag + " " + prop + "'\"";

            return ExecuteCommand(command);
        }

        public static String GetName()
        {
            return Getprop("ro.product.brand") + Getprop("ro.product.model");
        }

        public static void StopServer()
        {
            ExecuteCommand("adb kill-server");
        }

        //-----

        private static String ExecuteCommand(String command)
        {
            ProcessInfo.Arguments = "/C " + command;

            Process Process = Process.Start(ProcessInfo);

            //string error = Process.StandardOutput.ReadToEnd();
            string standard = Process.StandardOutput.ReadToEnd();

            return standard;

            return String.IsNullOrEmpty(Process.StandardOutput.ReadToEnd()) ? Process.StandardError.ReadToEnd() : Process.StandardOutput.ReadToEnd() ;
        }

        //public static void Test()
        //{
        //    Process process = new Process();
        //
        //    process.StartInfo.FileName = "cmd.exe";
        //    process.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\adb";
        //    process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
        //    process.StartInfo.RedirectStandardInput = true;
        //    process.StartInfo.UseShellExecute = false;
        //    process.StartInfo.RedirectStandardOutput = true;
        //
        //    process.Start();
        //
        //    process.StandardInput.WriteLine("adb start-server");
        //    Console.WriteLine(process.StandardOutput.ReadLine());
        //    process.StandardInput.WriteLine("stop");
        //    Console.WriteLine(process.StandardOutput.ReadLine());
        //}
    }
}


