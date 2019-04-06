using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(new ThreadStart(CurrentThread));
                Console.WriteLine("Name for your thread number " + (i + 1));
                threads[i].Name = Console.ReadLine();
            }
            foreach (Thread t in threads)
            {
                t.Start();
            }
        }
        static void CurrentThread()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Name of Current Thread is " + Thread.CurrentThread.Name);
            }
        }
    }
}