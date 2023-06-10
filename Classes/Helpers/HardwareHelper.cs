using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WindowsRevitalizer.Classes.Helpers
{
    internal class HardwareHelper
    {
        public bool CheckForNvidiaGPU()
        {
            bool hasNvidiaGPU = false;

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController WHERE AdapterCompatibility LIKE '%NVIDIA%'");
                ManagementObjectCollection collection = searcher.Get();

                hasNvidiaGPU = collection.Count > 0;
            }
            catch (ManagementException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return hasNvidiaGPU;
        }
        public bool CheckForAMDGPU()
        {
            bool hasAMDGPU = false;

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController WHERE AdapterCompatibility LIKE '%AMD%'");
                ManagementObjectCollection collection = searcher.Get();

                hasAMDGPU = collection.Count > 0;
            }
            catch (ManagementException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return hasAMDGPU;
        }
    }
}
