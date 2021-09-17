using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft;
using Newtonsoft.Json;
using Microsoft.CSharp;

namespace Winds_Path.Source.Private
{
    class Inventory
    {
        public static void parse()
        {
           string json = FileEngine.ReadFileFromGIT("Database", "Weapon.json");
           Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);
           Console.WriteLine(myDeserializedClass.Weapons.ToString());
        }
    }

    public class Root
    {
        public Weapons Weapons { get; set; }
    }
}