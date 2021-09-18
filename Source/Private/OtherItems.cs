using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winds_Path.Source.Private
{
    public class Items
    {
        public string name { get; set; }
        public int health { get; set; }
        public int amount { get; set; }
        public int cost { get; set; }
    }

    public class MakeItem
    {
        public List<Items> Items { get; set; }
    }
}