using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{

    class Program
    {

        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine()); // We add integer n this the size of the array.
            string[] numb = Console.ReadLine().Split(' '); // This is an array of strings, I need this  to write all the elements of the array
            int[] array = new int[n];//  // This is an array of integers.
            f(n, numb, array);
        }
        public static void f(int n, string[] numb, int[] array) // This is my method.
        {
            //array = new int[n];// Array of integers, size - n.
            List<int> arr = new List<int>();
            
            for (int i = 0; i < array.Length; i++)//  I opened a loop(for) to write all the elements from the array.
            {
                array[i] = int.Parse(numb[i]); // elements numb is also in string, I convert this to int.
            }
            for (int i = 0; i < array.Length; i++) //  I opened a loop(for) to write all the elements from the array.
            {
                //Console.Write(array[i] + " " + array[i] + " "); // to write duplicate array elements.
                arr.Add(array[i]);
                arr.Add(array[i]);
            }
        }
    }
}