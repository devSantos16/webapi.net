using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.net.models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public char Sex { get; set; }

        public Person(string name, string lastName, string birthDate, char sex)
        {
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Sex = sex;
        }
        public Person()
        {
        }
    }
}