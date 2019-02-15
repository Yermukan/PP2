using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_3
{
    class Program
    {
        public static void probel(int a)
        {
            for (int i = 0; i < a; i++)
            {
                Console.Write("    ");
            }
        }
        public static void dir(DirectoryInfo dirs, int a)
        {
            foreach (FileInfo fi in dirs.GetFiles())
            {
                probel(a);
                Console.WriteLine(fi.Name);
            }
            foreach (DirectoryInfo di in dirs.GetDirectories())
            {
                probel(a);
                Console.WriteLine(di.Name);
                dir(di, a + 1);
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\GIT\PP2\Week 1");
            dir(di, 0);
        }
    }
}
