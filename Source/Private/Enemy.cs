using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winds_Path.Source.Public;

namespace Winds_Path.Source.Private
{
    
    internal class Enemy
    {
        internal string name { get; set; }
        internal int health { get; set; }
        internal int maxdmg { get; set; }
        internal int mindmg { get; set; }

    }

    internal class MakeEnemy
    {
        internal List<Enemy> Enemies { get; set; }

        internal Enemy GenerateRandom()
        {

            int rand = Utilites.GenerateRandomNumber(0, Enemies.Count());
            return Enemies[rand];
        }
    }
}
