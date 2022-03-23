using System;

namespace lab_3
{
    class Stack<T>
    { 
        private T[] arr = new T[10];// string[]
        private int _last = -1;
        public void Push(T item)      //Push(string item)
        {
            arr[++_last] = item;

        }

        public T Pop()                //string Pop()
        {
            return arr[_last--];
        }
    }

    class Student
    {
        private string _firstName;
        public int Egzamin { get; set; }
        public void Push(Stack<String> stack)
        {
            stack.Push(_firstName);
        }

        public T GetReward<T>(T reward)
        {
            if (Egzamin > 50)
            {
                return reward;
            } else
                return default;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            Stack<string> stackString = new Stack<string>();

            stack.Push(1);
            stack.Push(5);
            stack.Push(9);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Student student = new Student() { Egzamin = 60 };
            string v= student.GetReward<string>("Gratulacje");
            Console.WriteLine(v);
            ValueTuple<String, decimal, int> product = ValueTuple.Create("laptop", 1200m, 2);
            Console.WriteLine(product);
            var laptop = ("laptop", 1200m, 2);
            Console.WriteLine(product==laptop);
            ( string name, decimal price, int quentity) tuple = ("laptop", 3000m, 4);
            laptop = tuple;
            Console.WriteLine(laptop);
            var tuple1 = (nameof: "laptop", price: 1299);
        }
    }
}
