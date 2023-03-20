using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace AppWithUpdate
{
    public class Updater
    {
        public static void Update()
        {
            Process.Start("updater.exe");
            Process.GetCurrentProcess().Kill();
            //File.Copy(path, currentPath, true);
            //currentVersion = newVersion;

        }
        public static bool CheckVersion()
        {
            return 1 == 1;
        }
    }
}
