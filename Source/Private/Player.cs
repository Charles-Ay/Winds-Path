using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winds_Path.Source.Public;

namespace Winds_Path.Source.Private
{
    class Player
    {
        /// <summary>
        /// the name of the player
        /// </summary>
        internal string name { get; set; }
        internal int money { get; set; }
        internal int health { get; set; }
        internal int defense { get; set; }
        internal int attack { get; set;  }
        internal int maxhp { get; set; }
        internal Inventory inventory;
        internal Player()
        {
            this.money = 0;
            this.health = 30;
            this.defense = 5;
            this.attack = 10;
            this.maxhp = health;
            inventory = new Inventory();
            this.money = 0;
        }

        internal void Uppercase()
        {
            char up = name[0];
            up = Char.ToUpper(up);
            for(int i = 1;i < name.Length; ++i)
            {
               string.Concat(up , name[i]);
            }
        }

        /// <summary>
        /// Calculate the damage the player will do
        /// </summary>
        /// <returns>damage player will do</returns>
        /// dmg = random((attack/2 + attack/4),attack)
        internal int CalculateAttack()
        {
            int dmg = Utilites.GenerateRandomNumber((attack / 2) + (attack / 4) , attack + 1);
            dmg += Utilites.GenerateRandomNumber(inventory.GetCurrentyEquipedWeapon().mindmg, inventory.GetCurrentyEquipedWeapon().mindmg + 1);
            return dmg;
        }
    }
}
