
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Winds_Path.Source.Private;

namespace Winds_Path
{
    class MainGame
    {
        internal static Player player = new Player();
        static void Main(string[] args)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) Console.SetWindowSize(200, 35);

            FileEngine.Init();
            Story.IntroStory();
            Story.Awaken();


        }
    }
}