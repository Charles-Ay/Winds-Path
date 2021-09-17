using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winds_Path.Source.Private
{
    public class Sword
    {
        public string name { get; set; }
        public int maxdmg { get; set; }
        public int mindmg { get; set; }
        public int cost { get; set; }
    }

    public class Bow
    {
        public string name { get; set; }
        public int maxdmg { get; set; }
        public int mindmg { get; set; }
        public int cost { get; set; }
    }

    public class Weapons
    {
        public static List<Sword> sword { get; set; }
        public static List<Bow> bow { get; set; }
    }


}
