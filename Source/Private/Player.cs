using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winds_Path.Source.Private
{
    partial class Player
    {
        string name;
        internal string GetPlayerName() { return name; }
        internal void SetPlayerName(string name) { this.name = name; }
        internal Player()
        {
            Inventory in1 = new Inventory();
        }
    }
}
