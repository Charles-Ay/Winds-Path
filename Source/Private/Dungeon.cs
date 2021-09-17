using System;
using Winds_Path.Source.Public;

namespace Winds_Path.Source.Private
{
    class Dungeon
    {
        private static Enemy enemy;
        private static MakeEnemy mk = new MakeEnemy();
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

            int choice = Console.Read();
            bool valid = false;

            while (true)
            {
                while (valid != true)
                {
                    if (choice == '1') break;
                    else if (choice == '2') goto end_of_loop;
                }
            }
        end_of_loop:;

        }

        private static void FightOptions()
        {
            Console.WriteLine("\tYour HP: " + MainGame.player.health);
            Console.WriteLine("\t" + enemy.name+ "'s HP: " + enemy.health + "\n");
            Console.WriteLine("\tWhat would you like to do?");
            Console.WriteLine("\t1. Attack");
            Console.WriteLine("\t2. Use HP potion");
            Console.WriteLine("\t3. RUN!!!");
        }
        private static void CreateEnemy()
        {
           enemy = mk.GenerateRandom();
        }
    }
}