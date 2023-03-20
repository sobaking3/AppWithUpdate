using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace AppWithUpdate
{
    public class Updater
    {
        public static string path = @"C:\Users\user\Desktop\app";
        public static string currentPath = Directory.GetCurrentDirectory();
        public static string newVersion = File.ReadAllText(path + @"\version.txt");
        public static string currentVersion = File.ReadAllText(currentPath + @"\version.txt");

        public static void Update()
        {
            Process.Start("updater.exe", $"{path} {currentPath} AppWithUpdate.exe");
            Process.GetCurrentProcess().Kill();
            //File.Copy(path, currentPath, true);
            //currentVersion = newVersion;

        }
        public static bool CheckVersion()
        {
            return newVersion == currentVersion;
        }
    }
}
