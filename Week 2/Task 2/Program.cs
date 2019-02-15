using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream FS = new FileStream(@"C:\GIT\PP2\Week 2\Input.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(FS);
            FileStream fs = new FileStream(@"C:\GIT\PP2\Week 2\output.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            string s = sr.ReadLine();
            string[] numbers = s.Split(' ');
            for (int i = 0; i < numbers.Length; i++)
            {
                int x = int.Parse(numbers[i]);
                int k = 1;
                for (int j = 2; j < x; j++)
                {
                    if (x % j == 0)
                    {
                        k = 0;
                    }
                }
                if (k == 1 && x > 1)
                {
                    sw.Write(x + " ");
                }
            }
            sw.Close();
            fs.Close();
            sr.Close();
            FS.Close();

        }
    }
}
