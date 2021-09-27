
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Winds_Path.Source.Private;

namespace Winds_Path.Source.Public
{
    class MainGame
    {

        internal static Player player;
        static void Main(string[] args)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) Console.SetWindowSize(200, 35);
            for (int i = 0; i < 0; ++i)
            {
                Console.WriteLine("Gathering Resources Please Wait.");
                Thread.Sleep(100);
                Console.WriteLine("Gathering Resources Please Wait..");
                Thread.Sleep(100);
                Console.WriteLine("Gathering Resources Please Wait...");
                Thread.Sleep(100);
                Console.Clear();

            }
            Console.Write("");
            FileEngine.Init();
            JsonEngine.Init();
            CreateNewPlayer();
            Story.IntroStory();
            Story.Awaken();

            Console.WriteLine("Thanks For Playing");
        }
        private static void CreateNewPlayer()
        {
            player = new Player();
        }
    }
}