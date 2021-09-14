using System;
using System.Collections.Generic;
using System.Threading;
using Winds_Path.Source.Private;

namespace Winds_Path
{
    class Story
    {
        /// <summary>
        /// Game Intro
        /// </summary>
        public static void IntroStory()
        {
            string hello = "*cough cough*............" +
                "\nHello there stranger. Would you like to hear a story?(Y/N): ";
            TextDelay(hello, 40);

            string userChoice = Console.ReadLine();
            userChoice.ToLower();
            bool valid = false;

            while (!valid)
            {
                if (userChoice == "y" || userChoice == "yes") 
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    TextDelay(FileEngine.ReadFileFromGIT("Story", "Intro.txt"), 40); 
                    valid = true;
                    
                }
                else if (userChoice == "n" || userChoice == "no") valid = true;
                else
                {
                    Console.ForegroundColor
                    = ConsoleColor.Red;
                    Console.Error.Write("Sorry I didn't hear you. Would you like to hear a story?(Y/N): ", Console.ForegroundColor);
                    userChoice = Console.ReadLine();
                    userChoice.ToLower();
                }
            }
            Title("CompanyName.txt");
            Title("Title.txt", "green");
        }
        /// <summary>
        /// Print characters after delay
        /// </summary>
        /// <param name="text">text to print</param>
        /// <param name="time">time to wait between characters</param>
        public static void TextDelay(string text, int time)
        {
            foreach(char letter in text)
            {
                Console.Write(letter);
                Thread.Sleep(time);
            }
        }
        /// <summary>
        /// Print diffrent title and headings
        /// </summary>
        /// <param name="file">file name</param>
        /// <param name="color">color to set text to</param>
        public static void Title(string file, String color = "white")
        {
            switch (color)
            {
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Error.WriteLine(FileEngine.ReadFileFromGIT("Title", file), Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;//reset back to white
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Error.WriteLine(FileEngine.ReadFileFromGIT("Title", file), Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

        }
        
    }
}