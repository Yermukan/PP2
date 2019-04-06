using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
namespace Task2
{
    public class Mark
    {
        public int x;
        public int Filter(int n)
        {
            if (n > 100)
                return 100;
            if (n < 0)
                return 0;
            else
                return n;
        }

        public int Grade
        {
            get
            {
                return x;
            }
            set
            {
                x = Filter(value);
            }
        }
        public Mark() { }
        public Mark(int Grade_)
        {
            Grade = Grade_;
        }
        public string getletter(int n)
        {
            if (n >= 95)
                return "A";
            else if (n >= 90)
            {
                return "-A";
            }
            else if (n >= 85)
            {
                return "+B";
            }
            else if (n >= 80)
            {
                return "B";
            }
            else if (n >= 75)
            {
                return "-B";
            }
            else if (n >= 70)
            {
                return "+C";
            }
            else if (n >= 65)
            {
                return "C";
            }
            else
            {
                return "-C";
            }
        }

        public string print(int nn)
        {
            string p = ("Mark: " + getletter(nn) + " Point " + nn);
            return p;
        }
        class Program
        {
            static void Main(string[] args)
            {
                Ser();
                DeSer();
            }

            static void Ser()
            {
                List<Mark> marks = new List<Mark>();
                Random random = new Random();
                for (int i = 0; i < 5; i++)
                {
                    marks.Add(new Mark(random.Next(50, 100)));
                }
                FileStream fs = new FileStream("Marks.xml", FileMode.Create, FileAccess.Write);
                XmlSerializer xml = new XmlSerializer(typeof(List<Mark>));
                xml.Serialize(fs, marks);
                fs.Close();
            }
            static void DeSer()
            {
                FileStream fs = new FileStream("Marks.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer xml = new XmlSerializer(typeof(List<Mark>));
                List<Mark> marks = xml.Deserialize(fs) as List<Mark>;
                foreach (Mark m in marks)
                {
                    string p = m.print(m.Grade);
                    Console.WriteLine(p);
                }
                fs.Close();
            }
        }
    }
}