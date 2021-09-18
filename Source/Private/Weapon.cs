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

    public class CurrentWeapon
    {
        public string name { get; set; }
        public int maxdmg { get; set; }
        public int mindmg { get; set; }
        public int cost { get; set; }
    }

    public class Weapons
    {
        /// <summary>
        /// Broken Sword, Novice Sword, Adept Sword
        /// </summary>
        public List<Sword> sword { get; set; }
        /// <summary>
        /// Broken Bow, Novice Bow, Adept Bow
        /// </summary>
        public List<Bow> bow { get; set; }
    }
    public class MakeWeapon
    {
        public Weapons Weapons { get; set; }
    }

}
