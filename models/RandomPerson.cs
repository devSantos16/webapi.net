using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.net;

namespace webapi.net.models
{
    public class RandomPerson : Person
    {
        private Random rand = new Random();
        public RandomPerson()
        {
            this.Name = Util.GenerateRandomElementString(GetListName());
            this.LastName = Util.GenerateRandomElementString(GetListLastName());
            this.BirthDate = Convert.ToString(RandomDay().ToString("dd/MM/yyyy"));
            this.Sex = GetRandomSex();
        }
        private List<string> GetListName()
        {
            return new List<string>() {
                "Caio",
                "Kalel",
                "Emanuel",
                "Douglas",
                "Gabriel",
            };
        }

        private List<string> GetListLastName()
        {
            return new List<string>(){
                "Barbosa Valenti",
                "Dos Santos Paz",
                "Silvano Lisboa",
                "Augusto Oliveira Henzel"
            };
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