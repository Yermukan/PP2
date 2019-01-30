using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());//int n its
            string[,] array = new string[n,n];
            for (int i = 0; i <= n; i++)
            { 
                for (int j = 0; j <= i; j++)
                {
                    array[i, j] = "[*]";
                    Console.Write(array [i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
