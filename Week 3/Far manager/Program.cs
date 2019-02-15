using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FarManager
{
    class Layer // class layer with variables(int,FileSystemInfo[])
    {
        public FileSystemInfo[] Content
        {
            get;
            set;
        }
        int selectedIndex;

        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                if (value < 0)
                {
                    selectedIndex = Content.Length - 1;
                }
                else if (value >= Content.Length)
                {
                    selectedIndex = 0;
                }
                else
                {
                     selectedIndex=value;
                }
            }
        }

        public void Draw() // function to make our FAR look interestin
        {
            Console.BackgroundColor = ConsoleColor.Black; // Our FAR's background is black
            Console.Clear(); //  refreshing
            for (int i = 0; i < Content.Length; i++) //чтобы не выйти за рамки
            {
                if (i == selectedIndex) // Condition which works if the Cursor is equal to the index of the array
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (Content[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine((i + 1) + ". " + Content[i].Name);
            }
        }
    }
    enum FarMode
    {
        DirectoryView, FileView
    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo root = new DirectoryInfo(@"C:\Users\Yermukhan-Laptop\source\repos\QWERTY");  // Предоставляет методы экземпляра класса для создания, 
            // перемещения и перечисления в каталогах и подкаталогах. Этот класс не наследуется.
            Stack<Layer> history = new Stack<Layer>();
            FarMode farMode = FarMode.DirectoryView;
            history.Push( // pushing all content from dirInfo;
                new Layer
                {
                    Content = root.GetFileSystemInfos(),
                    SelectedIndex = 0
                });
            while (true) //Cycle works until  is true

                {
                    if (farMode == FarMode.DirectoryView)
                {
                    history.Peek().Draw(); //  paints the first page
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();  // reading a key
                switch (consoleKeyInfo.Key) {
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedIndex++;
                        break;
                    case ConsoleKey.Enter:
                        int x = history.Peek().SelectedIndex;
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x];
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo d = fileSystemInfo as DirectoryInfo;
                            history.Push(new Layer { Content = d.GetFileSystemInfos(), SelectedIndex = 0 }); // если папка то добавляю в стек
                        }
                        else
                        {
                            farMode = FarMode.FileView;
                            using (FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fs)) // если файл то читаем
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (farMode == FarMode.DirectoryView)
                        {
                            history.Pop();  // if u press backspace, stack pops its element
                        }
                        else if (farMode == FarMode.FileView)
                        {
                            farMode = FarMode.DirectoryView;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.F2: // чтобы изменить имя папки или файла
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        string name = Console.ReadLine();
                        int x2 = history.Peek().SelectedIndex;
                        FileSystemInfo fileSystemInfo2 = history.Peek().Content[x2];
                        if (fileSystemInfo2.GetType() == typeof(DirectoryInfo))  // if selected item is dir
                        {
                            DirectoryInfo d2 = fileSystemInfo2 as DirectoryInfo;
                            Directory.Move(fileSystemInfo2.FullName, d2.Parent.FullName + "/" + name);
                            history.Peek().Content = d2.Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            FileInfo fs2 = fileSystemInfo2 as FileInfo; //  // if selected item is file
                            File.Move(fileSystemInfo2.FullName, fs2.Directory.FullName + "/" + name);
                            history.Peek().Content = fs2.Directory.GetFileSystemInfos();
                        }
                        break;
                    case ConsoleKey.Delete: // чтобы удалить файл или папку
                        int x3 = history.Peek().SelectedIndex;
                        FileSystemInfo fileSystemInfo3 = history.Peek().Content[x3];
                        if (fileSystemInfo3.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo d3 = fileSystemInfo3 as DirectoryInfo;
                            Directory.Delete(fileSystemInfo3.FullName, true);
                            history.Peek().Content = d3.Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            FileInfo fs3 = fileSystemInfo3 as FileInfo;
                            File.Delete(fileSystemInfo3.FullName);
                            history.Peek().Content = fs3.Directory.GetFileSystemInfos();
                        }
                        history.Peek().SelectedIndex--;
                        break;
                }
            }
        }
    }
}
