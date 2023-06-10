using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Interfaces;
using WindowsRevitalizer.Classes.Helpers;

namespace WindowsRevitalizer.Classes
{
    internal class MSIOn : ICommand
    {
        public void Execute()
        {
            ExecuteBatchFromWebHelper executeBatchFromWeb = new ExecuteBatchFromWebHelper();
            executeBatchFromWeb.ExecuteBatchScriptFromWeb("https://raw.githubusercontent.com/luke-beep/Windows-Revitalizer/main/Resources/MSION.bat");
        }
    }
}
