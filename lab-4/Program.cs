using System;

namespace lab_4
{
    enum Degree
    {
        A=50,
        B=45,
        C=40,
        D=35,
        E=30,
        F=20,
        G=10
    }
    class Program
    {
        public static double Convert(Degree degree)
        {
            return degree switch
            {
                Degree.A => 5.0,
                Degree.B => 4.5,
                Degree.C => 4.0,
                Degree.D => 3.5,
                Degree.E => 3.0,
                Degree.F => 2.0,
                _ => 1.0

            };
        }
        public static string DefreeType(Degree degree)
        {
            return degree switch
            {
                Degree.A or Degree.B or Degree.C or Degree.D or Degree.E => "Pozytywna",
                _ => "Negatywna"
            };
        }
        public static Degree GetDegree(int points)
        {
            return points switch
            {
                > 90 => Degree.A,
                > 80 and <= 90 => Degree.B,
                >70 and <=80=> Degree.C,
                >60 and <=70=> Degree.D,
                >50 and <=60=> Degree.E,
                _=> Degree.F

            };
        }
        public static (string,bool)[] Egzams(( string name, int points, char egzam)[] egzamInfo)
        {
            (string, bool)[] result = new (string, bool)[egzamInfo.Length];
            int i = 0;
            foreach(var item in egzamInfo)
            {
                result[i++] = (item.name,
                    item switch
                    {
                        { points: > 20, egzam: 'C' } => true,
                        { points: > 30, egzam: 'A' } => true,
                        { points:>40,egzam:'B'}=>true,
                        _ => false
                    }
                    );
            }
                return result;
        }
        record Student (string Name, int Ects);
        static void Main(string[] args)
        {

            

            Degree studentDegree = Degree.C;
            Console.WriteLine((int) studentDegree);
            foreach (string name in  Enum.GetNames<Degree>())
            {
                Console.WriteLine(name);
            };
            foreach (int value in Enum.GetValues<Degree>())
            {
                Console.WriteLine(value);
        }

            Console.WriteLine("wpisz ocene");
            string str = Console.ReadLine();
            try
            {
                studentDegree = Enum.Parse<Degree>(str);
                Console.WriteLine($"Wpisałeś ocenę {studentDegree} {(int)studentDegree}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("nieznana ocewna");
            }
            Student student = new Student("Karol", 23);
            Console.WriteLine(student);
            
        //Console.WriteLine("Hello World!"+GamerLevel.MEDIUM);
        //GamerLevel gamerLevel = GamerLevel.PRO;
        //int gamerLevelValue = (int)gamerLevel;
        //Console.WriteLine(gamerLevelValue);
        //foreach (string name in Enum.GetNames<GamerLevel>())
        //{
        //    Console.WriteLine(name);
        //}
        //foreach (int value in Enum.GetValues<Oceny>())
        //{
        //    Console.WriteLine(value);
        //}
    }

    }
    public enum GamerLevel
    {
        NOOB,
        MEDIUM,
        PRO,
        MASTER
    }
    public enum Oceny
    {
        DOSTATECZNY = 30,
        DOSTATECZNY_PLUS = 35,
        DOBRY = 40,
        DOBRY_PLUS = 45,
        BARDZO_DOBRY = 50
    }
}
