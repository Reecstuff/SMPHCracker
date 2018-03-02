using SMPHCracker.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SMPHCracker.Logic
{
    static class ADB
    {
        private static String path = AppDomain.CurrentDomain.BaseDirectory;

        private static ProcessStartInfo ProcessInfo = new ProcessStartInfo
        {
            /**
             * Ausführen der adb.exe
             * Prüfung, ob adb.exe sich im Verzeichnis befindet
             **/
            FileName = "cmd.exe",
            WorkingDirectory = Directory.Exists(Path.Combine(path, "adb")) ? Path.Combine(path, "adb") : Path.Combine(new DirectoryInfo(path).Parent.Parent.FullName, "adb"),
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        public static string ExecuteCommand(String command)
        {
            ProcessInfo.Arguments = "/C " + command;

            Process Process = Process.Start(ProcessInfo);

            string error = Process.StandardError.ReadToEnd();

            return String.IsNullOrEmpty(error) ? Process.StandardOutput.ReadToEnd() : error;
        }
    }
}


