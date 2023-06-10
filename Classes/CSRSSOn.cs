using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Classes.Helpers;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes
{
    internal class CSRSSOn : ICommand
    {
        public void Execute()
        {
            SetRegistryHelper setRegistryHelper = new SetRegistryHelper();
            setRegistryHelper.SetRegistry(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\csrss.exe\PerfOptions", "CpuPriorityClass", 4, RegistryValueKind.DWord);
            setRegistryHelper.SetRegistry(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\csrss.exe\PerfOptions", "IoPriority", 3, RegistryValueKind.DWord);
            setRegistryHelper.SetRegistry(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "NoLazyMode", 1, RegistryValueKind.DWord);
            setRegistryHelper.SetRegistry(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "AlwaysOn", 1, RegistryValueKind.DWord);
            setRegistryHelper.SetRegistry(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "NetworkThrottlingIndex", 10, RegistryValueKind.DWord);
            setRegistryHelper.SetRegistry(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Multimedia\SystemProfile", "SystemResponsiveness", 0, RegistryValueKind.DWord);
        }
    }
}
