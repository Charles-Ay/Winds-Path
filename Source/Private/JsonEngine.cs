using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft;
using Newtonsoft.Json;


namespace Winds_Path.Source.Private
{
    class JsonEngine 
    {
        internal static void Init()
        {
            string json = FileEngine.ReadFileFromGIT("Database", "Weapon.json");//json to convert
            MakeWeapon weapons = JsonConvert.DeserializeObject<MakeWeapon>(json);//convert json to lists

            json = FileEngine.ReadFileFromGIT("Database", "Armour.json");
            MakeArmour armours = JsonConvert.DeserializeObject<MakeArmour>(json);

            json = FileEngine.ReadFileFromGIT("Database", "Enemy.json");
            MakeEnemy enemy = JsonConvert.DeserializeObject<MakeEnemy>(json);

            json = FileEngine.ReadFileFromGIT("Database", "OtherItem.json");
            MakeItem item = JsonConvert.DeserializeObject<MakeItem>(json);
        }
    }

}
