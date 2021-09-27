using System;
using Winds_Path.Source.Public;

namespace Winds_Path.Source.Private
{
    class Dungeon
    {
        private static Enemy enemy;
        private static MakeEnemy mk = JsonEngine.enemy;
        private static Items items;
        private static int defeated;
        internal static void Welcome()
        {
            Story.Title("Dungeon.txt", "Red");
            Console.WriteLine();
            PlayOptions();

        }
        private static void PlayOptions()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("\tWhat would you like to do?");
            Console.WriteLine("\t1. Fight");
            Console.WriteLine("\t2. Exit dungeon");

            
            bool valid = false;
            while (!isDead())
            {
                int choice = Console.Read();
                valid = false;
                while (valid != true)
                {
                    if (choice == '1') 
                    {
                        valid = true;
                        CreateEnemy();
                        FightOptions();
                        break; 
                    }
                    else if (choice == '2') goto end_of_loop;
                }
            }
        end_of_loop:;

        }

        private static void ShowFightOptions()
        {
            Console.WriteLine("\tYour HP: " + MainGame.player.health);
            Console.WriteLine("\t" + enemy.name + "'s HP: " + enemy.health + "\n");
            Console.WriteLine("\tWhat would you like to do?");
            Console.WriteLine("\t1. Attack");
            Console.WriteLine("\t2. Use HP potion");
            Console.WriteLine("\t3. RUN!!!");

        }
        private static void FightOptions()
        {
            Console.ReadLine();//flush

            while (enemy.health > 0 && !isDead2())
            {
                ShowFightOptions();
                int choice = Console.Read();

                if(choice == '1') 
                {
                    attack();
                    Console.ReadLine();//flsuh
                }
                else if(choice == '2')
                {
                    heal();
                    Console.WriteLine("\tPlayer has healed: " + items.health);
                    Console.WriteLine();
                    Console.ReadLine();//flsuh
                }
                else if (choice == '3')
                {
                    if (Utilites.GenerateRandomNumber(1, 11) > 3) Console.WriteLine("Got away successfully");
                    else hit();
                    Console.ReadLine();//flsuh
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("INVALID", Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }
            }

        }
        private static void DeadOptions()
        {
        if (defeated == 1) Console.WriteLine("You defeated " + defeated + " enemy\n");
        else Console.WriteLine("You defeated " + defeated + " enemies\n");
            Console.WriteLine("######################");
            Console.WriteLine("# Leaving Dungeon... #");
            Console.WriteLine("######################");
            Console.WriteLine();
        }

        private static void CreateEnemy()
        {
            enemy = mk.GenerateRandomEnemy();
        }

        private static void hit()
        { 
            MainGame.player.health -= enemy.GetDamageDone(enemy.mindmg, enemy.maxdmg);
        }

        private static bool isDead() 
        {
            if (MainGame.player.health > 0) return false;
            else 
            {
                DeadOptions();
                return true;
            } 
        }
        private static bool isDead2()
        {
            if (MainGame.player.health > 0) return false;
            return true;
        }
        private static void attack()
        {
            enemy.health -= MainGame.player.CalculateAttack();
            if (enemy.health <= 0) WinOptions();
            else hit();
        }

        private static void WinOptions()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(" # " + enemy.name + " was defeated! #");
            Console.WriteLine(" # " + CalculateDrop() + " gold was dropped! #");
            int drop = CalculateRareDrop();
            if (drop > 0)
            {
                if(drop == 1) Console.WriteLine(" # " + CalculateRareDrop() + " potion was dropped! #");
                else Console.WriteLine(" # " + CalculateRareDrop() + " potions were dropped! #");
            }
            ++defeated;
            Console.ReadLine();
            PlayOptions();
        }

        private static int CalculateDrop()
        {
            int drop = Utilites.GenerateRandomNumber(1,11);
            MainGame.player.money += drop;
            return drop;
        }

        private static int CalculateRareDrop()
        {
            if(Utilites.GenerateRandomNumber(1,4) == 1)
            {
                int drop = Utilites.GenerateRandomNumber(1, 4);
                MainGame.player.inventory.AddItem("Health Potion", drop);
                return drop;
            }
            return 0;
        }
        private static void heal()
        {
            items = MainGame.player.inventory.GetItem("Health Potion");
            if(items.amount > 0)
            {
                if (MainGame.player.health + items.health > MainGame.player.maxhp) MainGame.player.health = MainGame.player.maxhp;
                else MainGame.player.health += items.health;
                items = MainGame.player.inventory.RemoveItemAmount("Health Potion");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Out of potions :(", Console.ForegroundColor);
                Console.ForegroundColor = ConsoleColor.White;
            }
           
        }
    }
}