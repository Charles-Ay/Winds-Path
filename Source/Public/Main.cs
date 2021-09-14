using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Winds_Path.Source.Private;

namespace Winds_Path
{
    class MainGame
    {
        static void Main(string[] args)
        {
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) Console.SetWindowSize(200,35);
            //Console.WriteLine(Console.LargestWindowWidth);
            //Console.WriteLine(Console.LargestWindowHeight);
            FileEngine.Init();
            Story.IntroStory();
        }
    }
}
