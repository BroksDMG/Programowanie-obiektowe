using System;
using static Person;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = Person.Of("Aleks");
            Console.WriteLine(person.Name);
            DateTime dateTime = DateTime.Parse("03-02-2022");
            Console.WriteLine(dateTime);
            DateTime newDate = dateTime.AddDays(2);
            Console.WriteLine(newDate + " " + dateTime);
            string name = "adam";
            string v = name.Substring(0, 2);
            Console.WriteLine("adam" == name);
            Money money = Money.Of(10m, Currency.PLN);
            //money *5->*(money,5)
            Money result = money * 5;
            Console.WriteLine(result.value);
            Money sum = money + result;
            Console.WriteLine(sum.value);
            Console.WriteLine(sum<money);
            Console.WriteLine(money==Money.Of(10,Currency.PLN));
            Console.WriteLine(money != Money.Of(10, Currency.PLN));
            long a = 10l;
            a = 10000000000000000L;
            int b = 5;
            a = b;
            b = (int)a;
            // operatory rzutowania
            //decimal amount = money;
            double cost = (double)money;
            float price = (float)money;
            //Console.WriteLine(amount);
            Console.WriteLine(cost);
            Console.WriteLine(price);
            // to string
            Console.WriteLine("ToString");
            Console.WriteLine(money.ToString());

            money.Equals(cost);
            Money[] pricies =
            {
                Money.Of(11,Currency.PLN),
                Money.Of(12,Currency.PLN),
                Money.Of(16,Currency.USD),
                Money.Of(17,Currency.USD),
                Money.Of(18,Currency.USD),
                Money.Of(12,Currency.EUR),

            };
            Console.WriteLine("Sort");
            Array.Sort(pricies);
            foreach (var m in pricies)
            {
                Console.WriteLine(m.ToString());
            }
        }
    }
}



class Person
{
    private string _name;
    private Person(string name)
    {
        _name = name;
    }

    public static Person Of(string name)
    {
        if (name != null && name.Length >= 2)
        {
            return new Person(name);
        }
        else
        {
            throw new ArgumentOutOfRangeException("Imię zbyt krótkie!");

        }
    }
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value != null && value.Length >= 2)
            {
                _name = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Imię zbyt krótkie");
            }
        }

     
    }

    public enum Currency
    {
        PLN = 2,
        USD = 3,
        EUR = 1
    }
    public class Money:IEquatable<Money>, IComparable<Money>
    {
        private readonly decimal _value;
        private readonly Currency _Currency;
        private Money(decimal value, Currency currency)
        {
            _value = value;
            _Currency = currency;
        }
        public decimal value
        {
            get
            {
                return _value;
            }
        }
        public Currency Currency
        {
            get
            {
                return _Currency;
            }
        }
        public static Money? Of(decimal value, Currency currency)
        {
            return value < 0 ? null : new Money(value, currency);
        }
        public static Money operator *(Money a,decimal b)
        {
            
            return Money.Of(a._value * b, a._Currency);
        }
        public static Money operator +(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentOutOfRangeException("Difrence currences");
            }
                return Money.Of(a._value * b._value, a._Currency);
        }
        public static bool operator >(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentOutOfRangeException("Difrence currences");
            }
            return a._value > b._value;
        }
        public static bool operator <(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentOutOfRangeException("Differebt currencies");
            }
            return a._value < b._value;
        }
        public static bool operator ==(Money a, Money b)
        {
            
            return a._value == b._value&& a.Currency==b.Currency;
        }
        public static bool operator !=(Money a, Money b)
        {

            return !(a == b);
        }
        public static implicit operator decimal(Money money)
        {
            return money.value;
        }
        public static explicit operator double(Money money)
        {
            return (double)money.value;
        }
        public static explicit operator float(Money money)
        {
            return (float)money.value;
        }
        public override string ToString()
        {
            return $"Value:{_value} ,Currency:{_Currency}";

        }

        public override bool Equals(object obj)
        {
            return obj is Money money &&
                   _value == money._value &&
                   _Currency == money._Currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_value, _Currency);
        }
        public bool Equals (Money other)
        {
            return _value == other._value && 
                _Currency == other._Currency;
        }

        public int CompareTo(Money other)
        {
            int result = _Currency.CompareTo(other._Currency);
            if (result == 0)
            {
                return -_value.CompareTo(other._value);

            }
            else
            {
                return result;
            }
        }        
    }

    public class Tank
    {
        public readonly int Capacity;
        private int _level;
        public Tank(int capacity)
        {
            Capacity = capacity;
        }
        public int Level
        {
            get { return _level; }
            set
            {
                if (value < 0 || value > Capacity) throw new ArgumentOutOfRangeException();
                _level = value;
            }
        }
        public bool Consume(int w)
        {
            if (w > _level)
            {
                return false;
            }
            Level = _level - w;
            return true;
        }
        public void Refuel(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Argument cant be non positive!");
            }
            if (_level + amount > Capacity)
            {
                throw new ArgumentException("Argument is to large!");
            }
            _level += amount;
        }
        public bool Refuel(Tank sourceTank, int amount)
        {
            if (this.Level + amount > Capacity)
            {
                return false;
            }
            if (sourceTank.Consume(amount))
            {
                this.Refuel(amount);
                return true;
            }

            return false;
        }

    }

}
