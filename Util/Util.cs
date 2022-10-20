using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.net
{
    public class Util
    {
        public static Random rand = new Random();
        public static string GenerateRandomElementString(List<string> list)
        {
            int aRandomPos = rand.Next(list.Count);
            string currName = list[aRandomPos];
            return currName;
        }
    }
}