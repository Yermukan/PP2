using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    public class Wall : GameObjects
    {
        public int lvlindex;

        public Wall() { }

        public Wall(char sign, ConsoleColor color) : base(0, 0, sign, color)
        {
            body = new List<Point>();
        }

        public void LoadLevel(int lvlindex)
        {
            this.lvlindex = lvlindex;
            body = new List<Point>();
            string filename = "level" + lvlindex + ".txt";
            StreamReader sr = new StreamReader(filename);
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] == '*')
                        body.Add(new Point(j, i));
        }

        public void NextLevel()
        {
            lvlindex++;
            if (lvlindex == 4)
                lvlindex = 1;

            LoadLevel(lvlindex);
        }
    }
}

