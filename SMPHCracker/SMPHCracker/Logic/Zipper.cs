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
        private static String path = AppDomain.CurrentDomain.BaseDirectory;
        private string startPath = Directory.Exists(Path.Combine(path, "sideloadFiles")) ? Path.Combine(path, "sideloadFiles") : Path.Combine(new DirectoryInfo(path).Parent.Parent.FullName, "sideloadFiles");
        private string zipPath = Directory.Exists(Path.Combine(path, "sideloadFiles\\update.zip")) ? Path.Combine(path, "sideloadFiles\\update.zip") : Path.Combine(new DirectoryInfo(path).Parent.Parent.FullName, "sideloadFiles\\update.zip");

        public void MakeZip(string file)
        {
            if (File.Exists(zipPath))
                File.Delete(zipPath);
            
            startPath = Path.Combine(startPath, file);
            ZipFile.CreateFromDirectory(startPath, zipPath);

            //using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
            //{
            //    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            //    {
            //        ZipArchiveEntry entry = archive.CreateEntry("META-INF\\com\\google\\android\\updater-script");
            //        using (StreamWriter writer = new StreamWriter(entry.Open()))
            //        {
            //            writer.WriteLine("ui_print(\"****************************************\");");
            //            writer.WriteLine("ui_print(\"* Script generated for SMPHCracker. *\");");
            //            writer.WriteLine("ui_print(\"* Run custom script! *\");");
            //            writer.WriteLine("ui_print(\"****************************************\");");
            //            writer.WriteLine();
            //        }
            //    }
            //}
        }
    }
}
