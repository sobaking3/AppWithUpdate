using System;

namespace AppWithUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            if (Updater.CheckVersion())
            {

                DoSomeWork();
            }
            else
            {
                Updater.Update();
            }
        }
        private static void DoSomeWork()
        {
            Console.WriteLine("Я ОБНАВИЛАСЬ Я МАЛАДЕЦ");
        }
    }
}

