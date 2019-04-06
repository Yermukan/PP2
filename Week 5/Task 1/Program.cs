using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace task1
{
    [Serializable]
    public class ComplexNumber
    {
        [XmlElement(ElementName = "Real part")]
        public int a;
        [XmlElement(ElementName = "Imaginary Part")]
        public int b;
        public ComplexNumber() { }

        public void print()
        {
            Console.WriteLine(a + "+" + b + "i");
        }
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
            ComplexNumber CN = new ComplexNumber();
            CN.a = 2; CN.b = 6;
            FileStream fs = new FileStream("CN.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xml = new XmlSerializer(typeof(ComplexNumber));
            xml.Serialize(fs, CN);
            fs.Close();
        }
        static void DeSer()
        {
            FileStream fs = new FileStream("CN.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xml = new XmlSerializer(typeof(ComplexNumber));
            ComplexNumber CN = xml.Deserialize(fs) as ComplexNumber;
            CN.print();
            fs.Close();
        }
    }
}