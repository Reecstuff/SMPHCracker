using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace SMPHCracker.Logic
{
    public class Zipper
    {

       
        //private string zipPath = Directory.Exists(Path.Combine(path, "sideloadFiles\\update.zip")) ? Path.Combine(path, "sideloadFiles\\update.zip") : Path.Combine(new DirectoryInfo(path).Parent.Parent.FullName, "sideloadFiles\\update.zip");

        public void MakeZip(string file)
        {
            DirectoryInfo directoryinfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            FileInfo fileinfo = directoryinfo.EnumerateFiles("update.zip", SearchOption.AllDirectories).FirstOrDefault() ?? directoryinfo.Parent.Parent.EnumerateFiles("update.zip", SearchOption.AllDirectories).FirstOrDefault();
            string zipPath = fileinfo.FullName;
            
            using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("shell.sh");
                    using (StreamWriter writer = new StreamWriter(entry.Open()))
                    {
                        writer.WriteLine("#!/sbin/sh");
                        writer.WriteLine(String.Empty);
                        writer.WriteLine("rm -rf /data/system/*.key");
                        writer.WriteLine(String.Empty);
                    }
                }
            }
        }

    }
}
