using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using WindowsRevitalizer.Classes;
using WindowsRevitalizer.Classes.Helpers;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (Is64Bit.Is64BitOperatingSystem())
            {
                ILogger logger = new FileLoggerHelper(@$"C:\WindowsRevitalizer\{DateTime.Today:yyyy-MM-dd}.txt");
                logger.ClearLogFile();
                Menu menu = new();
                menu.StartMenu();
                //ICommand hardwareModules = new HardwareAnalyzer();
                //hardwareModules.Execute();
                
            }
            else
            {
                Console.WriteLine("This application is only supported on 64-bit systems!");
                Environment.Exit(0);
            }
        }
    }
}