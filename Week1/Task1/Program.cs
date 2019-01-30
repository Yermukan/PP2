using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{ 
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            n = Convert.ToInt32(Console.ReadLine());// We add integer n this the size of the numbers.
            string[] numbers = Console.ReadLine().Split(' '); // This is an array of strings, I need this in the future to write all elements.
            List<int> prime = new List<int>(); // I opened the list so that in the future I could put Prime Numbers there
            for(int i=0; i<n;i++){ // i opened loop(for) to run from zero to n;
                int y = int.Parse(numbers[i]); // I give the value of the element y to number n
                int x=1; // I give  the value to the integer x ,  when numbers are prime x=1
                for(int j=2; j<y; j++){ // I opened a loop(for) 
                    if(y%j==0){
                        x=0;
                 } 
                    }
                    if(x==1 && y>1)
                        prime.Add(y);
                    }
            Console.WriteLine(prime.Count);
            for(int i=0; i<prime.Count; i++)
                Console.Write(prime[i]+ " ");
            Console.ReadKey();
        }
    }
}
