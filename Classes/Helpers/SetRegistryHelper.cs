using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsRevitalizer.Classes.Helpers
{
    internal class SetRegistryHelper
    {
        public void SetRegistry(string path, string? valueName, object value, RegistryValueKind registryValueKind)
        {
            try
            {
                Registry.SetValue(path, valueName, value, registryValueKind);
            }
            catch (System.Security.SecurityException ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
