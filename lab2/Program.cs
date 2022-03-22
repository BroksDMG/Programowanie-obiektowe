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
    public abstract class Scooter: Vehicle
    {
        public bool isDriver { get; set; }
    }
    public class ElecticScooter : Scooter
    {
        public int BatteriesLevel { get; set; }
        public double MaxRange ;
        public bool isCharger;
        public int ChargeBaterries(int time)
        {

            if  (isCharger&&BatteriesLevel!=100)
            {
                BatteriesLevel += time * 3;
            }
            BatteriesLevel = Math.Min(BatteriesLevel, 100);
            return BatteriesLevel;
        }
        
            
        public override decimal Drive(int distance)
        {
            MaxRange = BatteriesLevel / 3;
            
            if(isDriver&& distance < MaxRange)
            {
                _mileage += distance;
                BatteriesLevel -= distance*3;
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

            //Car car = new Car() { isEngineWorking = true, isFuel = true, MaxSpeed = 100 };

            //Vehicle vehicle = car;
            //Vehicle anotherVehicle = new Bicycle();
            //Vehicle[] vehicles = new Vehicle[3];
            //vehicles[0] = car;
            //vehicles[1] = anotherVehicle;
            //vehicles[2] = new Car();
            //foreach (Vehicle v in vehicles)
            //{
            //    Console.WriteLine(v);
            //    Console.WriteLine(v.Drive(14));
            //    if (v is Car)
            //    {
            //        Car acurrentCar = v as Car;
            //    }
            //}
            //IElectric[] electrics = new IElectric[3];

            //electrics[1] = new Cooker();
            //IAgregate agregate = new IntAggregate();
            //IIterator iterator = agregate.createIterator();

            //while (iterator.HasNext())
            //{
            //    Console.WriteLine(iterator.GetNext());
            //}
            //List<string> names = new List<string>()
            //{
            //    "Adam",
            //    "Ewa",
            //    "Karol"
            //};
            //List<string>.Enumerator enumerator = names.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current);
            //}
            //foreach (var name in names)//While(enumerator.MoveNext())
            //{
            //    Console.WriteLine(name);//enumerator.Current
            //}
            //Flyable[] flyables = new Flyable[3];
            //flyables[0] = new Hydroplane();
            //flyables[1] = new Duck();
            //flyables[2] = new Wasp();
            //int someVehcielscounter = 0;
            //foreach (var someVehicle in flyables)
            //{
            //    if(someVehicle is Swimmingable)
            //    {
            //        someVehcielscounter++;
            //    }
            //}
            //Console.WriteLine($"Liczba obiektów implementujących jednocześnie interfejsy Swimmingable i flyable wynosi: {someVehcielscounter}");

            IAgregate aggregate = new IntAggregate();
            for (var iterator = aggregate.createIterator(); iterator.HasNext();)
            {
                Console.WriteLine(iterator.GetNext());
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

    class IntAggregate : IAgregate
    {

        internal double[,] array = {
            {1,2},
            {3,4 },
            {5,6 },
            {7,8 }
        };
        public IIterator createIterator()
        {
           return new IntItertor(this);
        }
    }
   
    //class IntItertor : IIterator
    //{
    //    private int count = 0;
    //    private IntAggregate _aggregate;

    //    public IntItertor(IntAggregate aggregate)
    //    {
    //        _aggregate = aggregate;
    //    }

    //    public int GetNext()
    //    {
           
            
    //        if (count == 3)
    //        {
    //            return _aggregate._c;
    //        }
    //        switch (++count)
    //        {
    //            case 1:
    //                return _aggregate._a;
    //            case 2:
    //                return _aggregate._b;
    //            case 3:
    //                return _aggregate._c;
    //            default:
    //                throw new Exception();
    //        }
    //    }

    //    public bool HasNext()
    //    {
    //        return count < 3;
    //    }
    //}
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

            for (int i = 0; i < _aggregate.array.GetLength(0); i++)
            {
                for (int j = 0; j < _aggregate.array.GetLength(1); j++)
                {
                    count--;

                    Console.WriteLine(_aggregate.array[i,j]);
                }
            }
            return (int)_aggregate.array[count, count++];

        }

        public bool HasNext()
        {
          
            return count < _aggregate.array.Length;
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
