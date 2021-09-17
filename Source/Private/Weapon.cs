using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winds_Path.Source.Private
{
    internal class Sword
    {
        internal string name { get; set; }
        internal int maxdmg { get; set; }
        internal int mindmg { get; set; }
        internal int cost { get; set; }
    }

    internal class Bow
    {
        internal string name { get; set; }
        internal int maxdmg { get; set; }
        internal int mindmg { get; set; }
        internal int cost { get; set; }
    }

    internal class Weapons
    {
        internal List<Sword> sword { get; set; }
        internal List<Bow> bow { get; set; }
    }
    internal class MakeWeapon
    {
        internal Weapons Weapons { get; set; }
    }

}
