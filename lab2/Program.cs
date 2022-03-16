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

    public  class Scooter : Vehicle, IElectric
    {
        public override decimal Drive(int distance)
        {
            throw new NotImplementedException();
        }

        public int supply()
        {
            throw new NotImplementedException();
        }
    }
    public  class Cooker : IElectric
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
            Car car = new Car() { isEngineWorking = true, isFuel = true, MaxSpeed = 100 };

            Vehicle vehicle = car;
            Vehicle anotherVehicle = new Bicycle();
            Vehicle[] vehicles = new Vehicle[3];
            vehicles[0] = car;
            vehicles[1] = anotherVehicle;
            vehicles[2] = new Car();
            foreach(Vehicle v in vehicles)
            {
                Console.WriteLine(v);
                Console.WriteLine(v.Drive(14));
                if (v is Car)
                {
                    Car acurrentCar = v as Car;
                }
            }
            IElectric[] electrics = new IElectric[3];
            electrics[0] = new Scooter();
            electrics[1] = new Cooker();
            IAgregate agregate = new IntAggregate();
            IIterator iterator= agregate.createIterator();

            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.GetNext());
            }
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

        }
    }
    class IntAggregate : IAgregate
    {
        internal int _a = 4;
        internal int _b = 6;
        internal int _c = 2;

        public IIterator createIterator()
        {
           return new IntItertor(this);
        }
    }
    class IntItertor : IIterator
    {
        private int count = 0;
        private IntAggregate _aggregate;

        public IntItertor(IntAggregate aggregate)
        {
            _aggregate = aggregate;
        }

        public int GetNext()
        {
            if (count == 3)
            {
                return _aggregate._c;
            }
            switch (++count)
            {
                case 1:
                    return _aggregate._a;
                case 2:
                    return _aggregate._b;
                case 3:
                    return _aggregate._c;
                default:
                    throw new Exception();
            }
        }

        public bool HasNext()
        {
            return count < 3;
        }
    }

    interface IAgregate
    {
        IIterator createIterator();
    }
    interface IIterator
    {
        bool HasNext();
        int GetNext();
    }
}
