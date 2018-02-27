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
        private static Dictionary<ADBCommands, String> dic = new ADBDictionary().GetDictionary();
        private static String path = AppDomain.CurrentDomain.BaseDirectory;

        private static ProcessStartInfo ProcessInfo = new ProcessStartInfo
        {
            /**
             * Ausführen der adb.exe
             * Prüfung, ob adb.exe sich im Verzeichnis befindet
             **/
            FileName = "cmd.exe",
            WorkingDirectory = System.IO.Path.GetDirectoryName(Directory.Exists(Path.Combine(path, "adb")) ? Path.Combine(path, "adb") : Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName, "adb")),
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        public static string Execute(ADBCommands command, params string[] str)
        {
            if(command == ADBCommands.SHELLROOT || command == ADBCommands.SETPROP)
                str = (str ?? Enumerable.Empty<string>()).Concat(Enumerable.Repeat("'\"", 1)).ToArray();

            return ExecuteCommand(String.Join(" ",dic[command],String.Join(" ",str)));
        }

        private static String ExecuteCommand(String command)
        {
            ProcessInfo.Arguments = "/C " + command;

            Process Process = Process.Start(ProcessInfo);

            string error = Process.StandardError.ReadToEnd();

            return String.IsNullOrEmpty(error) ? Process.StandardOutput.ReadToEnd() : error ;
        }
    }
}


