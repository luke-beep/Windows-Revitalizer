using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes.Helpers
{
    internal class ConsolePropertiesHelper : IConsoleProperties
    {
        public void SetConsoleProperties(string Title)
        {
            int screenWidth = Console.LargestWindowWidth;
            int screenHeight = Console.LargestWindowHeight;

            int consoleWidth = screenWidth / 2;
            int consoleHeight = screenHeight / 2;

            Console.SetWindowSize(consoleWidth, consoleHeight);
            Console.Title = Title;
        }
    }

}
