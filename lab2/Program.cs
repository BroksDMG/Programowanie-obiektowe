using System;
using System.Collections.Generic;

namespace lab_2
{
    public abstract class Vehicle
    {
        public double Weight { get; init; }
        public int MaxSpeed { get; init; }
        protected int _mileage;
        public int Mealeage
        {
            get { return _mileage; }
        }
        public abstract decimal Drive(int distance);
        public override string ToString()
        {
            return $"Vehicle{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage} }}";
        }
    }
    public abstract class Scooter : Vehicle
    {
        public bool isDriver { get; set; }
    }
    public class ElecticScooter : Scooter
    {
        public int BatteriesLevel { get; set; }
        public double MaxRange;
        public bool isCharger;
        public int ChargeBaterries(int time)
        {

            if (isCharger && BatteriesLevel != 100)
            {
                BatteriesLevel += time * 3;
            }
            BatteriesLevel = Math.Min(BatteriesLevel, 100);
            return BatteriesLevel;
        }


        public override decimal Drive(int distance)
        {
            MaxRange = BatteriesLevel / 3;

            if (isDriver && distance < MaxRange)
            {
                _mileage += distance;
                BatteriesLevel -= distance * 3;
                return (decimal)(distance / (double)MaxSpeed);
            }
            return -1;

        }
        public override string ToString()
        {
            return $"ElecticScooter{{ Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage},BatteriesLevel: {BatteriesLevel} }}";
        }
    }

    public class Car : Vehicle
    {
        public bool isFuel { get; set; }
        public bool isEngineWorking { get; set; }
        public override decimal Drive(int distance)
        {
            if (isFuel && isEngineWorking)
            {
                _mileage += distance;
                return (decimal)(distance / (double)MaxSpeed);
            }
            return -1;
        }
        public override string ToString()
        {
            return $"Car{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}";
        }
    }
    public class Bicycle : Vehicle
    {
        public bool isDriver { get; set; }
        public override decimal Drive(int distance)
        {
            if (isDriver)
            {
                _mileage += distance;
                return (decimal)(distance / (double)MaxSpeed);
            }
            return -1;
        }
        public override string ToString()
        {
            return $"Bicycle{{Weight: {Weight}, MaxSpeed: {MaxSpeed}, Mileage: {_mileage}}}"; ;
        }
    }

    public class Cooker : IElectric
    {
        public int supply()
        {
            throw new NotImplementedException();
        }
    }
    interface IElectric
    {
        int supply();
    }
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //string[] array= input.Split(" ");
            //double item1 = Convert.ToInt32(array[0]);
            //double item2 = Convert.ToInt32(array[1]);
            //double item3 = Convert.ToInt32(array[2]) ;
            //if(item1<0&& item2 < 0 && item3 < 0)
            //{
            //    Console.WriteLine("Błędne dane.Długości boków muszą być dodatnie!");
            //}else if(item1 + item2 < item3 && item1 + item3 < item2 && item2 + item3 < item1)
            //{
            //    Console.WriteLine("Błędne dane. Trójkąta nie można zbudować!");
            //}


            //Console.WriteLine(array[2]);




            Car car = new Car() { isEngineWorking = true, isFuel = true, MaxSpeed = 100 };

            Vehicle vehicle = car;
            Vehicle anotherVehicle = new Bicycle();
            Vehicle[] vehicles = new Vehicle[3];
            vehicles[0] = car;
            vehicles[1] = anotherVehicle;
            vehicles[2] = new Car();
            foreach (Vehicle v in vehicles)
            {
                Console.WriteLine(v);
                Console.WriteLine(v.Drive(14));
                if (v is Car)
                {
                    Car acurrentCar = v as Car;
                }
            }
            IElectric[] electrics = new IElectric[3];

            electrics[1] = new Cooker();
            //IAgregate agregate = new IntAggregate();
            //IIterator iterator = agregate.createIterator();

            //while (iterator.HasNext())
            //{
            //    Console.WriteLine(iterator.GetNext());
            //}
            List<string> names = new List<string>()
            {
                "Adam",
                "Ewa",
                "Karol"
            };
            List<string>.Enumerator enumerator = names.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            foreach (var name in names)//While(enumerator.MoveNext())
            {
                Console.WriteLine(name);//enumerator.Current
            }
            Flyable[] flyables = new Flyable[3];
            flyables[0] = new Hydroplane();
            flyables[1] = new Duck();
            flyables[2] = new Wasp();
            int someVehcielscounter = 0;
            foreach (var someVehicle in flyables)
            {
                if (someVehicle is Swimmingable)
                {
                    someVehcielscounter++;
                }
            }
            Console.WriteLine($"Liczba obiektów implementujących jednocześnie interfejsy Swimmingable i flyable wynosi: {someVehcielscounter}");




            Console.WriteLine("Reverse int iteration");
            IntAggregate aggregate1 = new IntAggregate();
            IIterator iterator1 = aggregate1.createIterator();
            while (iterator1.HasNext())
            {
                Console.WriteLine(iterator1.GetNextReverse());
            }
            Console.WriteLine("Even first int iteration");
            IntAggregate aggregate2 = new IntAggregate();
            IIterator iterator2 = aggregate2.createIterator();
            while (iterator2.HasNext())
            {
                Console.WriteLine(iterator2.EvenOdd());
            }

        }
    }
    interface Driveable
    {
        decimal Drive(int distance);
    }
    interface Swimmingable
    {
        decimal Swim(int distance);
    }
    interface Flyable
    {
        bool TakeOff();
        decimal Fly(int disntance);
        bool Land();
    }
    public class Truck : Vehicle, Driveable
    {
        public override decimal Drive(int distance)
        {
            return 0;
        }


    }
    public class Amphibian : Vehicle, Driveable, Swimmingable
    {
        public override decimal Drive(int distance)
        {
            Console.WriteLine("DRIVE");
            return 0;
        }
        public decimal Swim(int distance)
        {
            Console.WriteLine("SWIM");
            return 0;
        }
    }
    public class Hydroplane : Vehicle, Flyable, Swimmingable
    {
        public override decimal Drive(int distance)
        {
            Console.WriteLine("DRIVE");
            return 0;
        }
        public decimal Swim(int distance)
        {
            Console.WriteLine("SWIM");
            return 0;
        }
        public bool TakeOff()
        {
            Console.WriteLine("TAKE OFF");
            return true;
        }
        public decimal Fly(int distance)
        {
            Console.WriteLine("FLY");
            return 0;
        }
        public bool Land()
        {
            Console.WriteLine("LAND");
            return true;
        }
    }
    public class Duck : Swimmingable, Flyable
    {
        public decimal Fly(int disntance)
        {
            throw new NotImplementedException();
        }

        public bool Land()
        {
            throw new NotImplementedException();
        }

        public decimal Swim(int distance)
        {
            throw new NotImplementedException();
        }

        public bool TakeOff()
        {
            throw new NotImplementedException();
        }
    }
    public class Wasp : Flyable
    {
        public decimal Fly(int disntance)
        {
            throw new NotImplementedException();
        }

        public bool Land()
        {
            throw new NotImplementedException();
        }

        public bool TakeOff()
        {
            throw new NotImplementedException();
        }
    }

    interface IAggregate
    {
        IIterator createIterator();
    }

    interface IIterator
    {
        int GetFirst();
        bool HasNext();
        int GetNext();
        int GetNextReverse();
        int EvenOdd();
        /*int DividableCompletly(int k);*/
    }

    class IntAggregate : IAggregate
    {
        internal int _a = 1;
        internal int _b = 2;
        internal int _c = 3;
        internal int _d = 4;
        internal int _e = 5;
        internal int _f = 6;

        public IIterator createIterator()
        {
            return new IntIterator(this);
        }
    }

    class IntIterator : IIterator
    {
        private IntAggregate _aggregate;
        private int count = 0;

        public IntIterator(IntAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        public int GetFirst()
        {
            return _aggregate._a;
        }

        public int GetNext()
        {
            if (count == 6)
            {
                return _aggregate._f;
            }
            switch (++count)
            {
                case 1: return _aggregate._a;
                case 2: return _aggregate._b;
                case 3: return _aggregate._c;
                case 4: return _aggregate._d;
                case 5: return _aggregate._e;
                case 6: return _aggregate._f;
                default: throw new Exception();
            }
        }

        public bool HasNext()
        {
            return count < 6;
        }

        public int GetNextReverse()
        {
            if (count == 6)
            {
                return _aggregate._a;
            }
            switch (++count)
            {
                case 1: return _aggregate._f;
                case 2: return _aggregate._e;
                case 3: return _aggregate._d;
                case 4: return _aggregate._c;
                case 5: return _aggregate._b;
                case 6: return _aggregate._a;
                default: throw new Exception();
            }
        }

        public int EvenOdd()
        {
            if (count == 6)
            {
                return _aggregate._e;
            }
            switch (++count)
            {
                case 1: return _aggregate._b;
                case 2: return _aggregate._d;
                case 3: return _aggregate._f;
                case 4: return _aggregate._a;
                case 5: return _aggregate._c;
                case 6: return _aggregate._e;
                default: throw new Exception();
            }
        }

    }
}
