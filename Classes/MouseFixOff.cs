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
    internal class MouseFixOff : ICommand
    {
        public void Execute()
        {
            SetRegistryHelper setRegistryHelper = new SetRegistryHelper();
            setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "SmoothMouseXCurve", "0000000000000000156e000000000000004001000000000029dc0300000000000000280000000000", Microsoft.Win32.RegistryValueKind.Binary);
            setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "SmoothMouseYCurve", "0000000000000000fd11010000000000002404000000000000fc12000000000000c0bb0100000000", Microsoft.Win32.RegistryValueKind.Binary);
            setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "MouseSpeed", "0", RegistryValueKind.String);
            setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "MouseThreshold1", "0", RegistryValueKind.String);
            setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "MouseThreshold2", "0", RegistryValueKind.String);
            setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "MouseSensitivity", "10", RegistryValueKind.String);
        }
    }
}
