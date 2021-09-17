using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winds_Path.Source.Private
{
    internal class Item
    {
        internal string name { get; set; }
        internal int health { get; set; }
    }

    internal class MakeItem
    {
        internal List<Item> Items { get; set; }
    }
    

}
