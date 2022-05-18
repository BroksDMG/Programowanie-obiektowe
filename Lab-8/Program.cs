using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_8
{
    record Student (string Name, int Ects);
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = { 4, 5,6,8, 1, 2, 7,8,9};
            Console.WriteLine("Hello World!");
            Predicate<int> predicate = n =>
            {
                Console.WriteLine("Predykat dla " + n);
                return n % 2 == 0 && n > 4;
            };
            IEnumerable<int> enumerable = 
                from n in ints
                where predicate.Invoke(n)
                select n;
            int sum = enumerable.Sum();
            Console.WriteLine("suma = " + sum);
            Console.WriteLine( "Ewaluacja");
            Console.WriteLine(string.Join(", ",enumerable));

            string[] strings = { "aa", "bb", "cc", "ddddd", "abc", "bab" };
            //zapisz LINQ, które zwróci łańcuch o długości 3 znaków ze strings
            //wyświetl wynik wyrażenia
            

            Console.WriteLine(string.Join(",", from d in strings where d.Length == 3 select " str =" + d.ToUpper()));
            Console.WriteLine(
                string.Join(" ,",
                from i in ints
                select i.ToString("X")
                ));


            Student[] students =
            {
                new Student("Ewa",12),
                new Student("Karol",42),
                new Student("Adam",62),
                new Student("Ola",22),
                new Student("Ewa",62),
                new Student("Adam",32)
            };
            Console.WriteLine(string.Join("\n",
                from s in students
                where s.Ects > 40
                orderby s.Name descending 
                select s.Name
                ));
            IEnumerable<IGrouping<string, Student>> group = 
                from s in students
                group s by s.Name;
            foreach (var item in group)
            {
                Console.WriteLine(item.Key +" " + item.Count());
            }
            IEnumerable<(string Key, int)> namesGroup = from s in students
            group s by s.Name into gr
            select(gr.Key, gr.Count());
            Console.WriteLine(string.Join("\n",namesGroup));

            //Oblicz ilu studentów ma te samą liczbę unktów Ects

            IEnumerable<(int Key, int)> ectesGroup = from s in students
            group s by s.Ects into gre
            select (gre.Key, gre.Count());
            Console.WriteLine(string.Join("\n", ectesGroup));
            ///fluent api

            IEnumerable<int> evens = ints.Where(n => n % 2 == 0).OrderBy(n=>n);
            Console.WriteLine(string.Join(", ",evens));
            Console.WriteLine(string.Join("\n",students.OrderBy(s => s.Name).ThenBy(s => s.Ects)));

            ////////////////////////////////////
            IEnumerable<(int Key, int)> enumerable1 = students
                .GroupBy(s => s.Ects)
                .Select(gr => (gr.Key, gr.Count()));
            Student tenStudent= students.ElementAtOrDefault(10);
            Console.WriteLine(tenStudent);
            bool allPassed = students.All(s => s.Ects > 10);
            // czy w ints są same liczby paryste ? wyświetl true lub false
            Console.WriteLine(ints.All(s=>s%2==0));
            //czy w ints jest przynajmniej jedna liczba parzysta 
            Console.WriteLine(ints.Any(s=>s%2==0));

            Enumerable.Range(0, 100).Where(n => n % 2 == 0).Sum();
            Random random = new Random();
            random.Next(5);
            //wygeneruj tablice 1000 liczb losowych w zakresie od 0 do 9

            int[] vs= Enumerable.Range(0, 1000).Select(n=> random.Next(10)).ToArray();
            // wygeneruj tablice liczb pierwszych mniejszych od 100
            IEnumerable<int> primes = Enumerable.Range(1, 100).Where(n =>
            {
               return Enumerable.Range(2, n - 1).All(i => n % i != 0);

            });
            Console.WriteLine(string.Join(", ",primes));
            


        }
    }
}
