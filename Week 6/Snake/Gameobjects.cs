using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class GameObjects
    {
        public List<Point> body;
        public char sign;
        public ConsoleColor color;

        public GameObjects() { }

        public GameObjects(int x, int y, char sign, ConsoleColor color)
        {
            body = new List<Point> { new Point(x, y) };
            this.sign = sign;
            this.color = color;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (Point p in body)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
                Console.ForegroundColor = color;
            }
        }
        public void f()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (Point p in body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                {
                    Console.SetCursorPosition(p.x, p.y);
                    Console.Write('O');
                    Console.ForegroundColor = color;
                }
                else
                {
                    Console.SetCursorPosition(p.x, p.y);
                    Console.Write(sign);
                    Console.ForegroundColor = color;
                }
            }

        }
        public bool IsColl(GameObjects obj)
        {
            foreach (Point p in obj.body)
            {
                if (body[0].x == p.x && body[0].y == p.y)
                    return true;
            }
            return false;
        }
        public bool IsCollItself(GameObjects obj)
        {
            for (int i = 1; i < obj.body.Count; i++)
            {
                if (body[i].x == body[0].x && body[i].y == body[0].y)
                    return true;
            }
            return false;
        }
        public void Clear()
        {
            foreach (var point in body)
            {
                Console.SetCursorPosition(point.x, point.y);
                Console.ForegroundColor = Console.BackgroundColor;
                Console.Write(' ');
            }
        }
    }
}

