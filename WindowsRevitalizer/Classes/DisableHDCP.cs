using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Classes.Helpers;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes
{
    internal class DisableHDCP : ICommand
    {
        public void Execute()
        {
            HardwareHelper hardwareHelper = new HardwareHelper();
            SetRegistryHelper setRegistryHelper = new SetRegistryHelper();
            ExecuteBatchFromWebHelper executeBatchFromWebHelper = new ExecuteBatchFromWebHelper();
            var NVIDIA = hardwareHelper.CheckForNvidiaGPU();
            if (NVIDIA)
            {
                executeBatchFromWebHelper.ExecuteBatchScriptFromWeb("https://raw.githubusercontent.com/luke-beep/Windows-Revitalizer/main/Resources/DisableHDCP.bat");
            }
        }
    }
}
