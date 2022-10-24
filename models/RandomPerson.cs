using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.net;
using webapi.net.Context;

namespace webapi.net.models
{
    public class RandomPerson : Person
    {
        private Random rand = new Random();
        
        public RandomPerson(PersonContext context)
        {
            int count = context.Persons.Count();

            this.Name = context.Persons.Find(GetRandomPersonTOID(count + 1)).Name;
            this.LastName = context.Persons.Find(GetRandomPersonTOID(count + 1)).LastName;
            this.BirthDate = context.Persons.Find(GetRandomPersonTOID(count + 1)).BirthDate;
            this.Sex = GetRandomSex();
        }

        protected int GetRandomPersonTOID(int count)
        {
            int pos = rand.Next(count);
            return pos;
        }

        protected char GetRandomSex()
        {
            char[] arrayChar = new char[2];

            arrayChar[0] = 'M';
            arrayChar[1] = 'F';

            int pos = rand.Next(arrayChar.Count());
            return arrayChar[pos];
        }
        DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rand.Next(range));
        }
    }
}