using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Task_4
{
    public class SimpleFileCopy
    {

        static void Main(string[] args)
        {
            string Filename = "info.txt";
            string sourcePath = @"C:\GIT\PP2\Week 2\path";
            string destPath = @"C:\GIT\PP2\Week 2\path 1";

            string sourceFile = Path.Combine(sourcePath, Filename);
            string destFile = Path.Combine(destPath, Filename);

            File.Copy(sourceFile, destFile);
            Console.WriteLine("File copied");

            if (File.Exists(@"C:\GIT\PP2\Week 2\path\info.txt"))
            {
                try
                {
                    File.Delete(@"C:\GIT\PP2\Week 2\path\info.txt");
                    Console.WriteLine("File deleated");
                }
                catch (IOException)
                {
                    Console.WriteLine("IOException");
                }
            }
        }
    }
}