using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winds_Path.Source.Private
{
    internal class Plate
    {
        internal string name { get; set; }
        internal int health { get; set; }
        internal int defense { get; set; }
        internal int cost { get; set; }
    }

    internal class Armours
    {
        internal List<Plate> plate { get; set; }
    }

    internal class MakeArmour
    {
        internal Armours Armours { get; set; }
    }
}
