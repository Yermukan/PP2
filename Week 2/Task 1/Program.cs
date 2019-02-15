using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = Console.ReadLine();
            FileStream fs = new FileStream(@"C:\GIT\PP2\Week 2\input1.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            //FileStream FS = new FileStream(@"C:\GIT\PP2\Week 2\output1.txt",FileMode.Create,FileAccess.Write);
            //StreamWriter sw = new StreamWriter(FS);
            string s = sr.ReadLine();
            //char[] array = s.ToCharArray();
            int k = 1;
            for (int i = 0; i < s.Length / 2; i++)
            {
               
                if (s[i] != s[s.Length - 1 - i])
                {

                    k = 0;
                    Console.WriteLine("No");


                }
            }

            if(k == 1) Console.WriteLine("Yes");
            Console.ReadKey();
        }
    }
}