using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winds_Path.Source.Public;

namespace Winds_Path.Source.Private
{
    class Inventory
    {
        /// <summary>
        /// set the items the player owns and the amount of each item
        /// </summary>
        private Dictionary<CurrentWeapon, int> ownedWeapons = new Dictionary<CurrentWeapon, int>();//all weapons
        private CurrentWeapon CurrentWeapon = new CurrentWeapon();//currently equiped weapon
        private MakeWeapon Weapons = JsonEngine.weapon;//weapon class


        private Dictionary<Armours, int> ownedArmour = new Dictionary<Armours, int>();


        private Dictionary<Items, int> ownedItems = new Dictionary<Items, int>();
        private MakeItem Item = JsonEngine.item;//weapon class


        internal Inventory()
        {
            AddNewWeapon("Broken Sword");
            AddNewWeapon("Broken Bow");
            EquipWeapon("Broken Sword");

            AddItem("Health Potion",2);
            //foreach(KeyValuePair<CurrentWeapon, int> current in ownedWeapons)
            //{
            //    Console.WriteLine("Key: " + current.Key.ToString() + " Value: " + current.Value.ToString());
            //}
            //Console.WriteLine("Current weapon name: " + CurrentWeapon.name);
        }
        internal CurrentWeapon GetCurrentyEquipedWeapon()
        {
            return CurrentWeapon;
        }

        internal void AddNewWeapon(string name)
        {
            CurrentWeapon currentWeapon = new CurrentWeapon();
            if (name.ToLower().Contains("sword"))//do zero becaasue only time owned weapons is zero is during init
            {
                if (ownedWeapons.Count == 0)
                {
                    currentWeapon.name = Weapons.Weapons.sword[0].name;
                    currentWeapon.maxdmg = Weapons.Weapons.sword[0].maxdmg;
                    currentWeapon.mindmg = Weapons.Weapons.sword[0].mindmg;
                    currentWeapon.cost = Weapons.Weapons.sword[0].cost;
                    ownedWeapons.Add(currentWeapon, 1);
                }
                else
                {
                    foreach (KeyValuePair<CurrentWeapon, int> current in ownedWeapons)
                    {
                        if (current.Key.name.ToLower() == name.ToLower())
                        {
                            if (ownedWeapons.Contains(current))//check if weapon is owned
                            {
                                ownedWeapons.Add(current.Key, current.Value + 1);
                                break;
                            }
                            currentWeapon.name = Weapons.Weapons.sword[0].name;
                            currentWeapon.maxdmg = Weapons.Weapons.sword[0].maxdmg;
                            currentWeapon.mindmg = Weapons.Weapons.sword[0].mindmg;
                            currentWeapon.cost = Weapons.Weapons.sword[0].cost;
                            ownedWeapons.Add(currentWeapon, 1);
                            break;
                        }
                    }
                }
            }
            else if (name.ToLower().Contains("bow"))
            {
                if (ownedWeapons.Count == 0)
                {
                    currentWeapon.name = Weapons.Weapons.bow[0].name;
                    currentWeapon.maxdmg = Weapons.Weapons.bow[0].maxdmg;
                    currentWeapon.mindmg = Weapons.Weapons.bow[0].mindmg;
                    currentWeapon.cost = Weapons.Weapons.bow[0].cost;
                    ownedWeapons.Add(currentWeapon, 1);
                }
                else
                {
                    foreach (KeyValuePair<CurrentWeapon, int> current in ownedWeapons)
                    {
                        if (current.Key.name.ToLower() == name.ToLower())
                        {
                            if (ownedWeapons.Contains(current))//check if weapon is owned
                            {
                                ownedWeapons.Add(current.Key, current.Value + 1);
                                break;
                            }
                            currentWeapon.name = Weapons.Weapons.bow[0].name;
                            currentWeapon.maxdmg = Weapons.Weapons.bow[0].maxdmg;
                            currentWeapon.mindmg = Weapons.Weapons.bow[0].mindmg;
                            currentWeapon.cost = Weapons.Weapons.bow[0].cost;
                            ownedWeapons.Add(currentWeapon, 1);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Equip the weapon chosen
        /// </summary>
        /// First checks to see if the name is equal to any of the possible weapons
        /// next check to see if player owns the weapon
        /// next check if weapon is already equiped 
        /// if not equiped equip else do nothing
        internal void EquipWeapon(string name)
        {
            foreach (KeyValuePair<CurrentWeapon, int> current in ownedWeapons)
            {
                if(current.Key.name.ToLower() == name.ToLower())//check if names match
                {
                    if (ownedWeapons.Contains(current))//check if weapon is owned
                    {
                        if (!CurrentWeapon.Equals(current)) { CurrentWeapon = current.Key; break; }//equiped if not currently equiped
                    }
                }
            }
        }

        internal void AddItem(string name, int amount)
        {
            if (ownedItems.Count == 0)
            {
                Items it = new Items();
                it.name = Item.Items[0].name;
                it.cost = Item.Items[0].cost;
                it.health = Item.Items[0].health;
                it.amount = Item.Items[0].amount;
                ownedItems.Add(it, amount);
            }
            else {
                foreach (KeyValuePair<Items, int> current in ownedItems)
                {
                    if (current.Key.name == name) current.Key.amount += amount;
                }
            }
        }

        internal Items GetItem(string name)
        {
            foreach (KeyValuePair<Items, int> current in ownedItems)
            {
                if (current.Key.name == name) return current.Key;
            }
            return null;
        }
        internal Items RemoveItemAmount(string name, int amount = 1)
        {
            foreach (KeyValuePair<Items, int> current in ownedItems)
            {
                if (current.Key.name == name) { current.Key.amount-= amount;return current.Key; }
            }
            return null;
        }
    }
}