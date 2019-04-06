using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Xml.Serialization;

namespace Snake
{
    public class GameState : Program
    {
        public bool IsAlive;
        public string name;
        public int timer = 150;
        public Serpent serpent;

        public Wall wall;
        public Food food;
        public Menu menu = new Menu();

        public GameState()
        {
            IsAlive = true;
            name = "";
            wall = new Wall('#', ConsoleColor.Green);
            food = new Food(2, 2, '$', ConsoleColor.Red);
            serpent = new Serpent(4, 4, 'O', ConsoleColor.White);
            while (food.IsColl(serpent) || food.IsColl(wall))
                food.Generate();
            wall.LoadLevel(1);
        }

        public GameState(Serpent serpent, Wall wall, Food food, String name)
        {
            IsAlive = true;
            this.name = name;
            this.serpent = serpent;
            this.wall = wall;
            this.food = food;
            while (food.IsColl(serpent) || food.IsColl(wall))
                food.Generate();
            wall.LoadLevel(1);
        }

        public void reg()
        {
            Console.SetCursorPosition(30, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("PLEASE, WRITE YOUR NAME: ");
            name = Console.ReadLine();
            Console.Clear();
            Start();
        }
        bool save = false;
        int counter = 0;
        public void Start()
        {
            IsAlive = true;
            Thread thread = new Thread(Cont);
            thread.Start();
            while (IsAlive)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.S)
                {
                    GameState savegame = new GameState(serpent, wall, food, name);
                    savegame.Save(savegame);
                    Console.Clear();
                    save = true;
                    Bye();
                }
                else
                    serpent.Goo(key);
            }
        }

        public void Save(GameState game)
        {
            if (File.Exists("loader.xml"))
                File.Delete("loader.xml");
            FileStream fs = new FileStream("loader.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer xml = new XmlSerializer(typeof(GameState));
            xml.Serialize(fs, game);
            fs.Close();
        }

        public void Bye()
        {
            Console.Clear();
            Console.SetCursorPosition(30, 10);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GAME BY - - - Author " + name);
            Console.WriteLine();
            Console.WriteLine("Game is Saved");
        }

        public void Dead()
        {
            Console.Clear();
            Console.SetCursorPosition(30, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME IS OVER");
            Console.WriteLine();
            Console.WriteLine(" Author: {0} Your score is {1}", name, counter);
            Console.WriteLine();
            Console.WriteLine("Press R to reset game or press ESC to qiit");
            ConsoleKeyInfo keyy = Console.ReadKey();
            if (keyy.Key == ConsoleKey.R)
            {
                System.Diagnostics.Process.Start(@"C:\Users\Yermukhan-Laptop\source\repos\Week 6 ,7\Snake\bin\Debug\Snake.exe");
                Environment.Exit(0);
            }
            if (keyy.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
        }
        public void Cont()
        {
            while (IsAlive)
            {
                if (save)
                {
                    Thread.Sleep(1000);
                    break;
                }
                serpent.Clear();
                serpent.Move();
                if (serpent.IsColl(food))
                {
                    while (food.IsColl(serpent) || food.IsColl(wall))
                        food.Generate();
                    serpent.body.Add(new Point(0, 0));
                    counter += 10;
                    if (counter % 50 == 0)
                    {
                        serpent.Clear();
                        serpent.body[0] = new Point(4, 4);
                        if (counter == 150)
                        {
                            Console.Clear();
                            Console.SetCursorPosition(40, 10);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("CONGRATULATION YOU WIN THIS GAME");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.ReadKey();
                            break;
                        }
                        wall.Clear();
                        wall.NextLevel();

                    }
                }
                if (serpent.IsCollItself(serpent) || serpent.IsColl(wall))
                {
                    Dead();
                }

                serpent.f();
                food.Draw();
                wall.Draw();
                Console.SetCursorPosition(30, 25);
                Console.WriteLine(name + " Score: " + counter);
                Console.SetCursorPosition(30, 27);
                int level = (counter / 50) + 1;
                Console.WriteLine("Level: " + level);
                Thread.Sleep(timer);
                if (level == 2)
                    timer = 100;
                if (level == 3)
                    timer = 50;
            }
            Environment.Exit(0);
        }
    }

}
