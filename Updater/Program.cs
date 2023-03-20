using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace Updater
{
    class Program
    {
        public static void Main(string[] args)
        {
            string fromDir = args[0];
            string toDir = args[1];
            string exeToRun = args[2];

            Console.WriteLine("Киляем процессы!");

            Process[] myProcesses2 = Process.GetProcessesByName(exeToRun);
            for (int i = 1; i < myProcesses2.Length; i++) {
                myProcesses2[i].Kill();
                Console.WriteLine("Убит процесс!");
            }

            Thread.Sleep(300);

            Console.WriteLine("Начинаем перемещение файлов!");

            DirectoryInfo directoryInfo = new DirectoryInfo(fromDir);
            
            foreach(FileInfo file in directoryInfo.GetFiles())
            {
                if(file.Name != "Updater.exe")
                {
                    Console.WriteLine("Перемещаем файл: " + file.FullName);
                    File.Copy(@$"{file.FullName}", @$"{toDir}\{file.Name}", true);
                }
            }

            Console.WriteLine("Нажмите Enter для окончания обновления и запуска программы!");
            Console.ReadLine();
            Process.Start(exeToRun);


        }
    }
}
