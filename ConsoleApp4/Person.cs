using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp4
{
    public enum Gender { Male, Female, Other }

    public class Person:IReadble
    {
        protected string firstname;
        protected string lastname;
        protected string patronim;
        protected Gender gender;

        public Person(Gender gender, string firstname, string lastname, string patronim = "")
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.patronim = patronim;
            this.gender = gender;
        }
        public Person()
        {
            this.firstname = " ";
            this.lastname = " ";
            this.patronim = " ";
            this.gender = Gender.Other;
        }

        public void Write(TextWriter output)
        {
            output.WriteLine(this.ToString());
        }

        

        public string Firstname
        {
            get { return this.firstname; }
        }

        public string Lastname
        {
            get { return this.lastname; }
        }

        public string Patronim
        {
            get { return this.patronim; }
        }

        public Gender Gender
        {
            get { return this.gender; }
        }

        public string FullName
        {
            get
            {
                return String.Join(" ", this.lastname, this.firstname, this.patronim).Trim();
            }
        }

        public override string ToString()
        {
            return $"{FullName}; {gender}";
        }
        public void FromString(string data)
        {
            string[] components = data.Split(';');

            string[] nameComponents = components[0].Split(' ');
            string firstname;
            string lastname;
            string patronim;

            if (nameComponents.Length == 3) // с отчеством
            {
                firstname = nameComponents[1];
                lastname = nameComponents[0];
                patronim = nameComponents[2];
            }
            else if (nameComponents.Length == 2) // без отчества
            {
                firstname = nameComponents[1];
                lastname = nameComponents[0];
                patronim = "";
            }
            else
                throw new FormatException("Unaxpected Name Format");

            string gender = components[1].Trim();
            Gender g = Gender.Other;

            switch (gender[0])
            {
                case 'М':
                case 'м':
                case 'M':
                case 'm':
                    g = Gender.Male;
                    break;
                case 'Ж':
                case 'ж':
                case 'F':
                case 'f':
                    g = Gender.Female;
                    break;
            }

            this.firstname = firstname;
            this.lastname = lastname;
            this.patronim = patronim;
            this.gender = g;
        }
    }
}
