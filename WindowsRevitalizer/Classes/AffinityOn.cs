using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Classes.Helpers;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes
{
    internal class AffinityOn : ICommand
    {
        public void Execute()
        {
            GetPhysicalCoreCountHelper getPhysicalCoreCountHelper = new GetPhysicalCoreCountHelper();
            ExecuteBatchFromWebHelper executeBatchFromWeb = new ExecuteBatchFromWebHelper();
            int logicalCoreCount = Environment.ProcessorCount;
            
            if (logicalCoreCount == getPhysicalCoreCountHelper.GetPhysicalCoreCount()) {
                executeBatchFromWeb.ExecuteBatchScriptFromWeb("https://raw.githubusercontent.com/luke-beep/Windows-Revitalizer/main/Resources/AffinityON.bat");
            }
            else if(logicalCoreCount > getPhysicalCoreCountHelper.GetPhysicalCoreCount())
            {
                executeBatchFromWeb.ExecuteBatchScriptFromWeb("https://raw.githubusercontent.com/luke-beep/Windows-Revitalizer/main/Resources/AffinityONHyperThreading.bat");
            }
            else if(getPhysicalCoreCountHelper.GetPhysicalCoreCount() == 2)
            {
                
            }
            else if(getPhysicalCoreCountHelper.GetPhysicalCoreCount() == 4)
            {
                executeBatchFromWeb.ExecuteBatchScriptFromWeb("https://raw.githubusercontent.com/luke-beep/Windows-Revitalizer/main/Resources/Affinity4Cores.bat");
            }
        }
    }
}
