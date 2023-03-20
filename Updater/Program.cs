using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.IO;

namespace Updater
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Current version: " + GetAssemblyVersion());
            //LoadUpdate();
        }

        private static string GetAssemblyVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion;
        }

        private static void LoadUpdate()
        {
            SftpClient sftp = new SftpClient("176.113.82.114", 1234, "root", "px50c20UHs");

            sftp.Connect();

            string version;

            using (Stream stream = File.Create("version.txt"))
            {
                Console.WriteLine(sftp.WorkingDirectory);
                sftp.DownloadFile("updates/version.txt", stream);
            }

            version = File.ReadAllText("version.txt").Trim();

            Console.WriteLine("Последняя версия: " + version);

            using (Stream stream = File.Create("update.zip"))
            {
                sftp.DownloadFile($"updates/{version}.zip", stream);
            }

            Console.WriteLine($"Скачано обновление: /updates/{version}.zip");
        }
    }
}
