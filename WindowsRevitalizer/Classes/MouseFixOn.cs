using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Classes.Helpers;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes
{
    internal class MouseFixOn : ICommand
    {
        public void Execute() 
        {
            DPIHelper dPIHelper = new DPIHelper();
            SetRegistryHelper setRegistryHelper = new SetRegistryHelper();
            float scalingFactor = dPIHelper.getScalingFactor();

            setRegistryHelper.SetRegistry("HKEY_CURRENT_USER\\Control Panel\\Mouse", "MouseSpeed", "0", RegistryValueKind.String);
            setRegistryHelper.SetRegistry("HKEY_CURRENT_USER\\Control Panel\\Mouse", "MouseThreshold1", "0", RegistryValueKind.String);
            setRegistryHelper.SetRegistry("HKEY_CURRENT_USER\\Control Panel\\Mouse", "MouseThreshold2", "0", RegistryValueKind.String);
            setRegistryHelper.SetRegistry("HKEY_CURRENT_USER\\Control Panel\\Mouse", "MouseSensitivity", "10", RegistryValueKind.String);
            setRegistryHelper.SetRegistry("HKEY_CURRENT_USER\\Control Panel\\Mouse", "SmoothMouseYCurve", "0000000000000000000038000000000000007000000000000000A800000000000000E00000000000", RegistryValueKind.Binary);

            switch (scalingFactor) 
            {
                case 1F:
                    setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "SmoothMouseXCurve", "0000000000000000C0CC0C0000000000809919000000000040662600000000000033330000000000", RegistryValueKind.Binary);
                    break;
                case 1.25F:
                    setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "SmoothMouseXCurve", "00000000000000000000100000000000000020000000000000003000000000000000400000000000", RegistryValueKind.Binary);
                    break;
                case 1.5F:
                    setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "SmoothMouseXCurve", "0000000000000000303313000000000060662600000000009099390000000000C0CC4C0000000000", RegistryValueKind.Binary);
                    break;
                case 1.75F:
                    setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "SmoothMouseXCurve", "00000000000000006066160000000000C0CC2C000000000020334300000000008099590000000000", RegistryValueKind.Binary);
                    break;
                case 2F:
                    setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "SmoothMouseXCurve", "000000000000000090991900000000002033330000000000B0CC4C00000000004066660000000000", RegistryValueKind.Binary);
                    break;
                case 2.25F:
                    setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "SmoothMouseXCurve", "0000000000000000C0CC1C0000000000809939000000000040665600000000000033730000000000", RegistryValueKind.Binary);
                    break;
                case 2.5F:
                    setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "SmoothMouseXCurve", "00000000000000000000200000000000000040000000000000006000000000000000800000000000", RegistryValueKind.Binary);
                    break;
                case 3F:
                    setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "SmoothMouseXCurve", "00000000000000006066260000000000C0CC4C000000000020337300000000008099990000000000", RegistryValueKind.Binary);
                    break;
                case 3.5F:
                    setRegistryHelper.SetRegistry(@"HKEY_CURRENT_USER\Control Panel\Mouse", "SmoothMouseXCurve", "0000000000000000C0CC2C0000000000809959000000000040668600000000000033B30000000000", RegistryValueKind.Binary);
                    break;
                default:
                    Console.WriteLine("Couldn't find your Display Scaling Percentage!");
                    break;
            }
        }   
    }
}
