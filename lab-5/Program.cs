using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_5
{
    class Team:IEnumerable<String>
    {
        public string Leader { get; init; }
        public string ScrumMaster { get; init; }
        public string Developer { get; init; }

        public IEnumerator<string> GetEnumerator()
        {
            //return new TeamEnumerator(this);
            yield return Leader;        //dla pierwszego wywołania MoveNext
            yield return ScrumMaster;   //dla drugiego wywołania MoveNext
            yield return Developer;     //dla trzeciego wywołania MoveNext
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class TeamEnumerator : IEnumerator<String>
    {
        private Team _team;
        private int _count =-1;
        public TeamEnumerator(Team team)
        { 

                }
        public string Current
        {
            get
            {
                return _count switch
                {
                    0 => _team.Leader,
                    1=>_team.ScrumMaster,
                    2=>_team.Developer
                };
            }
        }
        Object IEnumerator.Current => throw new NotImplementedException();

       

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            return ++_count < 3;
        }

        public void Reset()
        {
            _count = -1;
        }
    }
    class Parking:IEnumerable<String>
    {
        private string[] _cars = { "fiat", "audi", "bmw" ,null,"ford"};
        public String this[char index]
        {
            //index jako litery alfabetu 'a' ,'b',itd.
            get
            {
                //test czy index 
                return _cars[index- 'a']; 
            }
            set
            {
                 _cars[index -'a'] = value;
            }
        }
        public IEnumerator<string> GetEnumerator()
        {
            foreach (string car  in _cars)
            {
                if (car != null)
                {
                    yield return car;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();   
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Team team = new Team() { Leader = "Nowak", Developer = "Kos", ScrumMaster = "Marzec" };
            IEnumerator<string> member = team.GetEnumerator();
            while (member.MoveNext())
            {
                Console.WriteLine(member.Current);
            }
            
            foreach (string mem in team)
            {
                Console.WriteLine(mem);
            }
            Console.WriteLine(string.Join(",",team));
            Parking parking = new Parking();
            parking['d'] = "Dacia"; 
            Console.WriteLine(string.Join(", ",parking));
        }
    }
}
