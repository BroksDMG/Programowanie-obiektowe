using System;
using System.Collections.Generic;

namespace lab_6
{
    class Student:IComparable<Student>
    {
        public string Name { get; set; }
        public int Ects { get; set; }

        public int CompareTo(Student other)
        {
            return Name.CompareTo(other.Name);
        }

        public override bool Equals(object obj)
        {
            Console.WriteLine("Student Equals");
            return obj is Student student &&
                   Name == student.Name &&
                   Ects == student.Ects;
        }

        public override int GetHashCode()
        {
            Console.WriteLine("student HashxCode");
            return HashCode.Combine(Name, Ects);
        }

        public override string ToString()
        {
            return $"Name = {Name}, Ects = {Ects}";
        }
        class Program
        {
            static void Main(string[] args)
            {
                ICollection<string> names = new List<string>();
                names.Add("Ewa");
                names.Add("Karol");
                names.Add("Robert");
                names.Add("Robert");
                Console.WriteLine(names.Contains("Karol"));
                names.Remove("Ewa");
                foreach (string name in names)
                {
                    Console.WriteLine(name);
                }
                //wykonaj to samo co wyżej dla kolekcji z obiektami student

                ICollection<Student> students = new List<Student>();


                Console.WriteLine("----------------------------------");
                students.Add(new Student() { Name = "Robert", Ects = 17 });
                students.Add(new Student() { Name = "Karol", Ects = 15 });
                students.Add(new Student() { Name = "Ewa", Ects = 12 });
                Console.WriteLine(students.Contains(new Student() { Name = "Ewa", Ects = 12 }));
                students.Remove(new Student() { Name = "Ewa", Ects = 12 });
                foreach (Student student in students)
                {
                    Console.WriteLine(student.Name + " " + student.Ects);
                }
                List<Student> List = (List<Student>)students;
                Console.WriteLine(List[0]);
                List[0] = new Student() { };
                List.Insert(0, new Student() { Name = "Ania", Ects = 45 });

                int index = List.IndexOf(new Student() { Name = "Karol", Ects = 15 });
                Console.WriteLine(index);

                ISet<string> setNames = new HashSet<string>();
                setNames.Add("Ewa");
                setNames.Add("Karol");
                setNames.Add("Robert");
                Console.WriteLine(string.Join(", ", setNames));
                Console.WriteLine("---------------------------------");
                ISet<Student> studentGroup = new HashSet<Student>();
                studentGroup.Add(List[0]);
                studentGroup.Add(List[1]);
                studentGroup.Add(List[2]);
                studentGroup.Add(new Student() { Name="Ania",Ects=45});
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine(student) ;
                }
                Console.WriteLine("-------------------Contains------------------");
                Console.WriteLine(studentGroup.Contains(List[2]));
                List.Add(new Student() { Name = "Ela", Ects = 56 });
                List.Add(new Student() { Name = "Marek", Ects = 16 });
                List<Student> result = new List<Student>();
                //Console.WriteLine("-------jak nie robic-------");
                //foreach (Student student in List)
                //{
                //    if (studentGroup.Contains(student))
                //    {
                //        result.Add(student);
                //    }
                //}
                Console.WriteLine("----jak robić-----");
                //ISet<Student> set = new HashSet<Student>(List);
                ISet<Student> commonSet = new HashSet<Student>(studentGroup);
                //commonSet.IntersectWith(set);
                Console.WriteLine(string.Join(", ", commonSet));

                //ISet<Student> sortedSet = new SortedSet<Student>(studentGroup);
                //sortedSet.Add(new Student() { Name = "Ewa", Ects = 34 });
                //foreach (Student s in sortedSet)
                //{
                //    Console.WriteLine(s);

                //}
                Dictionary<Student, List<string>> phones = new Dictionary<Student,List< string>>();
                phones[List[0]] = new List<string>();
                phones[List[0]].Add( "3243653");
                //phones[new Student() { Name = "Kamil", Ects = 34, }] = "224124124";
                foreach (var item in phones)
                {
                    Console.WriteLine(item.Key+" "+item.Value);
                }
                Console.WriteLine(string.Join(", ", phones.Keys));
                Console.WriteLine(string.Join(", ", phones.Values));
            }
        }
    }
}
