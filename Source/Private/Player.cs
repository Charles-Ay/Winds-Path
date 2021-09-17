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
        internal Player()
        {
            Inventory inventory = new Inventory();
            this.money = 0;
        }
    }
}
