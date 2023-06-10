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
    internal class SvcHostSplitThresholdCommandOn : ICommand
    {
        public void Execute()
        {
            GetTotalVisibleMemoryHelper getTotalVisibleMemory = new GetTotalVisibleMemoryHelper();
            SetRegistryHelper setRegistryHelper = new SetRegistryHelper();
            int mem = getTotalVisibleMemory.GetTotalVisibleMemorySize() + 1024000;

            setRegistryHelper.SetRegistry(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control", "SvcHostSplitThresholdInKB", mem, RegistryValueKind.DWord);
        }
    }
}
