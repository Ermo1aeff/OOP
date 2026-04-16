using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР5
{
    public class Group
    {
        public string GroupName { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public void PrintGroup()
        {
            Console.WriteLine($"\n--- Группа: {GroupName} ---");
            foreach (var student in Students)
            {
                Console.WriteLine(student.ToString());
            }
            Console.WriteLine("---------------------------\n");
        }
    }
}
