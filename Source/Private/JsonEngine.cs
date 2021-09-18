using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft;
using Newtonsoft.Json;


namespace Winds_Path.Source.Private
{
    class JsonEngine 
    {
        internal static MakeWeapon weapon;
        internal static MakeArmour armour;
        internal static MakeEnemy enemy;
        internal static MakeItem item;
        internal static void Init()
        {
            string json = FileEngine.ReadFileFromGIT("Database", "Weapon.json");//json to convert
            weapon = JsonConvert.DeserializeObject<MakeWeapon>(json);//convert json to lists
            //string s = weapons.Weapons.bow[0].name;
            //Console.WriteLine(weapon.Weapons.sword[0].name);

            json = FileEngine.ReadFileFromGIT("Database", "Armour.json");
            armour = JsonConvert.DeserializeObject<MakeArmour>(json);

            json = FileEngine.ReadFileFromGIT("Database", "Enemy.json");
            enemy = JsonConvert.DeserializeObject<MakeEnemy>(json);
             
            json = FileEngine.ReadFileFromGIT("Database", "OtherItem.json");
            item = JsonConvert.DeserializeObject<MakeItem>(json);
        }
    }

}
