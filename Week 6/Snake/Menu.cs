using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
    public class Menu
    {
        public int cursor;
        public string[] menu =
        {
            "CONTINUE",
            "NEW GAME",
            "EXIT"
        };

        public Menu() { }

        public void ShowMenu()
        {
            Console.Clear();
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("W E L C O M E");
            int x = 32; int y = 12;
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = ConsoleColor.Green;
                if (cursor == i)
                    Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(menu[i] + " " + cursor + " " + i);
                Console.ForegroundColor = ConsoleColor.Green;
                y += 2;
            }
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                if (cursor == 0)
                {
                    GameState contgame = LoadGame();
                    contgame.Start();
                }
                if (cursor == 1)
                {
                    GameState newgame = new GameState();
                    newgame.reg();
                }
                if (cursor == 2)
                {
                    Console.Write("OUT");
                    Console.ReadKey();
                }
            }
            if (key.Key == ConsoleKey.Escape)
                Environment.Exit(0);

            MoveCursor(key);
            ShowMenu();
        }
        public GameState LoadGame()
        {
            FileStream fs = new FileStream("loader.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xml = new XmlSerializer(typeof(GameState));
            GameState game = xml.Deserialize(fs) as GameState;
            fs.Close();
            return game;
        }

        public void MoveCursor(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                cursor--;
                if (cursor < 0)
                    cursor = 2;
            }
            if (key.Key == ConsoleKey.DownArrow)
            {
                cursor++;
                if (cursor > 2)
                    cursor = 0;
            }
        }
    }
}
