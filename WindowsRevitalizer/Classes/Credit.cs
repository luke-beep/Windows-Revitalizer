using Microsoft.Win32;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Classes.Helpers;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes
{
    internal class Credit : ICommand
    {
        public void Execute() 
        {
            BackHelper backHelper = new();
            Credit _credit = new();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\WindowsRevitalizer");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            if (key == null)
            {
                var credit = new Table();
                credit.AddColumn("Credit");
                credit.AddRow("Hellzerg's Optimizer");
                credit.AddRow("HoneCTRL");
                credit.AddRow("luke-beep");
                credit.Alignment(Justify.Center);

                AnsiConsole.Write(credit);
                Thread.Sleep(4000);


                var accept = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .HighlightStyle(Color.Red)
                .PageSize(10)
                .Title("[red]Continue[/]?")
                .AddChoices(new[]
                {
                "Yes", "No"
                }));
                if (accept == "Yes") {
                    Registry.CurrentUser.CreateSubKey(@"Software\WindowsRevitalizer");
                    backHelper.Back();
                }
                else
                {
                    Console.Clear();
                    _credit.Execute();
                }
            }
        }
    }
}
