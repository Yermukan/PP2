using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Student
    {
        public string name;
        public string id;
        public int year;

        public Student()
        {
            name = Console.ReadLine();
            id = Console.ReadLine();
            f();
            InfoPrint();

        }
        public Student(string name, string id)
        {
            this.name = name;
            this.id = id;
            f();
            InfoPrint();

        }
        public void f()
        {
            year = Convert.ToInt32(Console.ReadLine());
        }
        public void InfoPrint()
        {
            Console.WriteLine("name: " + name);
            Console.WriteLine("id: " + id);
            Console.WriteLine("The year of the study: " + (year + 1));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student Askar = new Student();
            Console.WriteLine();
            Student Beisenbek = new Student();
            Console.WriteLine();
            Student Daulet = new Student();
            Console.ReadKey();
        }
    }
}
