using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student { FirstName = "dfdf" };

            // Сериализация
            XmlSerializer serializer = new XmlSerializer(typeof(Student));
            using (FileStream fileStream = new FileStream("person.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, student);
            }

            Console.WriteLine("Объект сериализован в файл person.xml");
        }
    }
}
