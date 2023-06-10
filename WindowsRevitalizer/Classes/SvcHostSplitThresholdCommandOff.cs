using Microsoft.Win32;
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
    internal class SvcHostSplitThresholdCommandOff : ICommand
    {
        public void Execute()
        {
            SetRegistryHelper setRegistryHelper = new SetRegistryHelper();
            setRegistryHelper.SetRegistry(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control", "SvcHostSplitThresholdInKB", 3670016, RegistryValueKind.DWord);
        }

    }
}
