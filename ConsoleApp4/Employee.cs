using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Employee : Person
    {
        protected string department;
        protected string position;
        protected uint salary;

        public Employee(string firstname, string lastname, string patronim, Gender gender,
                       string department, string position, uint salary) : base(gender, firstname, lastname, patronim)
        {
            this.department = department;
            this.position = position;
            this.salary = salary;
        }
        public Employee(Person p, string department, string position, uint salary) :
            this(p.Firstname, p.Lastname, p.Patronim, p.Gender, department, position, salary)
        { }

        public uint Department
        {
            set { this.department = Console.ReadLine(); }
        }
        public uint Position
        {
            set { this.position = Console.ReadLine(); }
        }
        public uint Salary
        {
            set { this.salary = Convert.ToUInt32(Console.ReadLine()); }
            get { return this.salary; }
        }
        public string Info()
        {
            // Пример работы со StringBuilder
            StringBuilder result = new StringBuilder();

            result.Append(department).Append("-").Append(position).Append(salary);

            return result.ToString();
        }
        // IAccessCardHolder
        public override string ToString()
        {
            return $"{base.ToString()}; {Info()}";
        }
    }
}
