using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Classes.Helpers;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes
{
    internal class EnableMitigations : ICommand
    {
        public void Execute()
        {
            ExecuteBatchFromWebHelper executeBatchFromWebHelper = new ExecuteBatchFromWebHelper();
            executeBatchFromWebHelper.ExecuteBatchScriptFromWeb("https://raw.githubusercontent.com/luke-beep/Windows-Revitalizer/main/Resources/EnableMitigations.bat");
        }
    }
}
