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
            Money money = Money.Of(10, Currency.PLN);
            //money *5->*(money,5)
            Money result = money * 5;
            Console.WriteLine(result.value);
            Money sum = money + result;
            Console.WriteLine(sum.value);
            Console.WriteLine(sum<money);
            Console.WriteLine(money==Money.Of(10,Currency.PLN));
            Console.WriteLine(money != Money.Of(10, Currency.PLN));
            long a = 10l;
            int b = 5;
            a = b;
            b = a;

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
        PLN = 1,
        USD = 2,
        EUR = 3
    }
    public class Money
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
    }


}
