using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winds_Path.Source.Public;

namespace Winds_Path.Source.Private
{
    
    public class Enemy
    {
        public string name { get; set; }
        public int health { get; set; }
        public int maxdmg { get; set; }
        public int mindmg { get; set; }
        public int GetDamageDone(int min, int max)
        {
            return Utilites.GenerateRandomNumber(min, max + 1);
        }

    }

    public class MakeEnemy
    {
        public List<Enemy> Enemies { get; set; }

        public Enemy GenerateRandomEnemy()
        {
            int rand = Utilites.GenerateRandomNumber(0, Enemies.Count());
            return Enemies[rand];
        }
    }
}
