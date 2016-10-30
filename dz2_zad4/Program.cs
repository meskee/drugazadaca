using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz2_zad4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Example1(); //true
            Example2(); //1

            Console.In.Read();
        }

        private static void Example1()
        {
            var list = new List<Student>()
            {
                new Student ("Ivan", jmbag:"001234567")
            };

            var ivan = new Student("Ivan", jmbag: "001234567");

            var anyIvanExists = list.Any(s => (bool) (s == ivan));
            Console.Out.WriteLine(anyIvanExists);
        }

        private static void Example2()
        {
            var list = new List<Student>()
            {
                new Student ("Ivan", jmbag: "001234567"),
                new Student ("Ivan", jmbag: "001234567")
            };

            var distinctStudents = list.Distinct().Count();
            Console.Out.WriteLine(distinctStudents);
        }
    }
}
