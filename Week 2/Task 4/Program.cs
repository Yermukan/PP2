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
            //string Filename = "info.txt";
            FileStream fs = new FileStream(@"C:\GIT\PP2\Week 2\path\info.txt", FileMode.Create, FileAccess.Write);

            string sourcePath = @"C:\GIT\PP2\Week 2\path\info.txt";
            string destPath = @"C:\GIT\PP2\Week 2\path 1\info.txt";

            // string sourceFile = Path.Combine(sourcePath, );
            // string destFile = Path.Combine(destPath, Filename);

            File.Copy(sourcePath, destPath);
            File.Delete(@"C:\GIT\PP2\Week 2\path\info.txt");

            Console.WriteLine("File copied");

            /* if (File.Exists(@"C:\GIT\PP2\Week 2\path\info.txt"))
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
        
            } */
            }
        }
    }
