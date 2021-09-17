using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        internal Player()
        {
            Inventory inventory = new Inventory();
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
    }
}
