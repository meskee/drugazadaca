using dz2_zad4;
using dz2_zad5;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Zad5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var universities = GetAllCroatianUniversities();

            var allCroatianStudents = universities.SelectMany(b => b.Students).Distinct().ToArray();
            var croatianStudentsOnMultipleUniversities = universities.SelectMany(b => b.Students)
                .GroupBy(s => s)
                .Where(sG => sG.Count() > 1)
                .Select(sG => sG.Key).ToArray();
            var studentsOnMaleOnlyUniversities = universities.Where(u => u.Students.All(s => s.Gender != Gender.Female))
                .SelectMany(b => b.Students).Distinct().ToArray();

            Console.Out.WriteLine("All Croatian students :");
            foreach (var student in allCroatianStudents)
                if ((bool)(student != null)) Console.Out.WriteLineAsync(student.ToString());
            Console.Out.WriteLine();

            Console.Out.WriteLine("Croatian students on multiple universities :");
            foreach (var student in croatianStudentsOnMultipleUniversities)
                if ((bool)(student != null)) Console.Out.WriteLineAsync(student.ToString());
            Console.Out.WriteLine();

            Console.Out.WriteLine("Students on male only universities :");
            foreach (var student in studentsOnMaleOnlyUniversities)
                if ((bool)(student != null)) Console.Out.WriteLineAsync(student.ToString());
            Console.Out.WriteLine();

            Console.ReadKey();
        }

        private static IEnumerable<University> GetAllCroatianUniversities()
        {
            var zagreb = new University { Name = "Zagreb" };
            var zadar = new University { Name = "Zadar" };
            var split = new University { Name = "Split" };

            var ivan = new Student("Ivan", "23", Gender.Male);
            var marko = new Student("Marko", "26", Gender.Male);
            var filip = new Student("Filip", "22", Gender.Male);
            var ana = new Student("Ana", "19", Gender.Female);
            var dora = new Student("Dora", "20", Gender.Female);

            zagreb.Students = new[] { marko, filip, dora };
            zadar.Students = new[] { filip, ana };
            split.Students = new[] { ivan, marko };

            return new[] { zagreb, zadar, split };
        }
    }
}
