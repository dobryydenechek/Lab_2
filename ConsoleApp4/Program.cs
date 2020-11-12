using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        public static Person GetRandomPerson(Random rnd)
        {
            string[] firstnames_fem =
            {
                "Мария", "София", "Оксана", "Ирина", "Елена"
            };
            string[] firstnames_man =
            {
                "Евдоким", "Георгий", "Вениамин", "Арсений", "Иннокентий"
            };
            string[] lastnames_fem =
            {
                "Куморова", "Бородина", "Пузырина", "Рожкова", "Серницева"
            };
            string[] lastnames_man =
             {
                "Кривозявка", "Фазан", "Вектор", "Кокушкин", "Серобаба"
            };
            string[] patronim_fem =
            {
                "Рудольфовна", "Гагиковна", "Арнольдовна", "Алеговна", "Карловна"
            };
            string[] patronim_man =
            {
                "Зинаидович", "Акакиевич", "Никитич", "Добрынич", "Пересветыч"
            };



            int g = rnd.Next(2);
            if (g == 0)
            {
                string firstname = firstnames_fem[rnd.Next(firstnames_fem.Length)];
                string lastname = lastnames_fem[rnd.Next(lastnames_fem.Length)];
                string patronim = patronim_fem[rnd.Next(patronim_fem.Length)];

                return new Person(Gender.Female, firstname, lastname, patronim);
            }
            else
            {
                string firstname = firstnames_man[rnd.Next(firstnames_man.Length)];
                string lastname = lastnames_man[rnd.Next(lastnames_man.Length)];
                string patronim = patronim_man[rnd.Next(patronim_man.Length)];

                return new Person(Gender.Male, firstname, lastname, patronim);
            }
        }
        public static Student GetRandomStudent(Random rnd)
        {
            string[] tracks =
            {
                "ПОКС", "ИБ", "ПИ", "БД", "СК"
            };
            uint[] courses =
            {
                1,2,3,4
            };
            uint[] groups =
            {
                1,2,3,4,5,6,7,8,9
            };
            Person p = GetRandomPerson(rnd);

            string track = tracks[rnd.Next(tracks.Length)];
            uint course = courses[rnd.Next(courses.Length)];
            uint group = groups[rnd.Next(groups.Length)];
            Student std = new Student(p, track, course, group);
            return std;
        }

        public static Employee GetRandomEmployee(Random rnd)
        {
            string[] positions =
            {
                " уборщица ", " преподаватель ", " менеджер ", " директор ", " врач "
            };
            string[] departments =
            {
                " отдел продаж ", " отдел ИТ ", " отдел кадров ", " бухгалтерия "
            };
            uint[] salarys =
            {
                11000,20000,43000,23000,50000
            };
            Person p = GetRandomPerson(rnd);

            string position = positions[rnd.Next(positions.Length)];
            string department = departments[rnd.Next(departments.Length)];
            uint salary = salarys[rnd.Next(salarys.Length)];
            return new Employee(p, department, position, salary);
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Person[] person = new Person[10];
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Пёрсоны:");
            for (int i = 0; i < 10; i++)
            {
                person[i] = GetRandomPerson(rnd);
                Console.WriteLine(person[i]);
            }

            Student[] student = new Student[10];
            List<Student> first_course_std = new List<Student>();
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Студенты:");
            for (int i = 0; i < 10; i++)
            {
                student[i] = GetRandomStudent(rnd);
                
                Console.WriteLine(student[i]);
                if (student[i].Course == 1)
                {
                    first_course_std.Add(student[i]);
                }
            }

            Employee[] employee = new Employee[10];
            uint min_s = 100000000;
            Employee employee_min_s = null;
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Работники:");
            for (int j = 0; j < 10; j++)
            {
                employee[j] = GetRandomEmployee(rnd);
                
                Console.WriteLine(employee[j]);
                if (employee[j].Salary < min_s)
                {
                    min_s = employee[j].Salary;
                    employee_min_s = employee[j];
                    
                }
            }
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Работник с минимальной зарплатой:");
            Console.WriteLine(employee_min_s.Firstname + " " + employee_min_s.Salary);

            Console.WriteLine("-----------------------------------------------------------");


            Console.WriteLine("Студенты первого курса:");
            for (int i = 0; i < first_course_std.Count; i++)
            {
                Console.WriteLine(first_course_std[i].Lastname + " " + first_course_std[i].Firstname + " " + first_course_std[i].Patronim);
            }
            var persons = new List<Person>();
            var input = new StreamReader("students.csv", Encoding.GetEncoding(1251));

            while (!input.EndOfStream)
            {
               var p = ObjectReader.Read<Person>(input);
                persons.Add(p);
            }
            input.Close();

            var output = new StreamWriter("output.csv", false, Encoding.GetEncoding(1251));

            foreach(var p in persons)
            {
                var s = new Student(p, "ПОКС", 3, 1);
                s.Write(output);
            }
            output.Close();
            Console.Read();
            

        }
    }
}
