using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winds_Path.Source.Private
{
    partial class Player
    {
        /// <summary>
        /// the name of the player
        /// </summary>
        internal string name { get; set; }
        internal Player()
        {
            Inventory inventory = new Inventory();
        }
    }
}
