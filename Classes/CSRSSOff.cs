﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Classes.Helpers;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes
{
    internal class CSRSSOff : ICommand
    {
        public void Execute() {
            ExecuteBatchFromWebHelper executeBatchFromWeb = new ExecuteBatchFromWebHelper();
            executeBatchFromWeb.ExecuteBatchScriptFromWeb("https://raw.githubusercontent.com/luke-beep/Windows-Revitalizer/main/Resources/CSRSSOff.bat");
        }
    }
}
