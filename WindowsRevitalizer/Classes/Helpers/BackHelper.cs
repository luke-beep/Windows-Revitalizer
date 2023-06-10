using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes.Helpers
{
    internal class BackHelper
    {
        public void Back()
        {
            Menu menu = new();
            Thread.Sleep(500);
            Console.Clear();
            menu.StartMenu();
        }
    }
}
