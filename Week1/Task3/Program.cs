using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            // We add integer n this the size of the array.
            string[] numb = Console.ReadLine().Split(' ');
            // This is an array of strings, I need this in the future to write all the elements of the array.
            int[] array = new int[n];
            // This is an array of integers.
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(numb[i]);
            }
            // I opened a loop(for) to write all the elements from the array.
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " " + array[i] + " ");
            }
            // This time I opened a loop(for) to write duplicate array elements.
            Console.ReadKey();
        }
    }
}
