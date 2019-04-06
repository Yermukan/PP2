using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_2
{
    public class MyThread
    {
        public Thread thread;
        public MyThread(string name)
        {
            thread = new Thread(new ThreadStart(count));
            thread.Name = name;
        }
        void count()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name + " выводит " + (i + 1));
            }
            Console.WriteLine(Thread.CurrentThread.Name + (" завершился"));
        }
        public void StartThread()
        {
            thread.Start();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            MyThread t1 = new MyThread("Thread 1");
            MyThread t2 = new MyThread("Thread 2");
            MyThread t3 = new MyThread("Thread 3");

            t1.StartThread();
            t2.StartThread();
            t3.StartThread();
        }
    }
}