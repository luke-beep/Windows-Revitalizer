using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsRevitalizer.Classes.Helpers
{
    internal class GetPhysicalCoreCountHelper
    {
        public int GetPhysicalCoreCount() {
            int physicalCoreCount = 0;
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT NumberOfCores FROM Win32_Processor"))
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    physicalCoreCount += int.Parse(obj["NumberOfCores"].ToString());
                }
            }
            return physicalCoreCount;
        }
    }
}
