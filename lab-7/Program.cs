using System;

namespace lab_7
{
    class Program
    {
        delegate double operation(double a, double b);
        //zdefiniuj delegata zwracającego bool z agrumentem string o nzawie stringPredicate
        delegate bool stringPredicate(string a);
        public static double Add(double a , double b)
            {
                return a + b;
            }
        public static double Mul(double a,double b)
        {
            return a * b;
        }
        public static bool Str(string a)
        {
            if (a.Length == 5)
            {
                return true;
            }
            else return false;
        }
        static void Main(string[] args)
        {
           
            operation op = Add;
            Console.WriteLine(op.Invoke(4,6));//1
            op = Mul;
            Console.WriteLine(op.Invoke(4,6));//2

            stringPredicate st = Str;
            Console.WriteLine(st.Invoke("abcdf"));
            Func<double, double, double> funcOperator = delegate (double a, double b)
            {
                return a * b;
            };
            Func<int, string> Format = delegate (int number)
             {
                 return string.Format("{0:x}", number);
             };
            Console.WriteLine(Format.Invoke(10));
            Predicate<string> OnlyFive = Str;
            Predicate<int> InRage = delegate (int a)
             {
                 return a >= 0 && a <= 100;
             };
            Console.WriteLine(InRage.Invoke(67));
            Func<int, int, int, bool> InRange1 = delegate (int value, int min, int max)
                {
                    return value >= min && value <= max;
                };
            Action<string> Print = delegate (string s)
            {
                Console.WriteLine(s);
            };
            Action<string> PrintLambda = s => Console.WriteLine(s);
            Func<int, int, int,bool> InRageLambda = (value, min, max) => value >= min && value <= max;
            operation Div = (a, b) =>
            {
                if (b != 0)
                {
                    return a / b;

                }
                else
                {
                    throw new Exception("b is zero!");
                }
            };
            Console.WriteLine(Div.Invoke(5,3));
 
        }
    }
}
