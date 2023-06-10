using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Interfaces;
using System.Configuration.Install;
using System.ServiceProcess;
using System.Reflection;
using WindowsRevitalizer.Classes.Helpers;

namespace WindowsRevitalizer.Classes
{
    internal class TimerResolutionOn : ICommand
    {
        public void Execute()
        {
            GetOperatingSystemBuildNumberHelper getOperatingSystemBuildNumberHelper = new GetOperatingSystemBuildNumberHelper();
            ExecuteBatchFromWebHelper executeBatchFromWeb = new ExecuteBatchFromWebHelper();
            string buildNumber = getOperatingSystemBuildNumberHelper.GetOperatingSystemBuildNumber();
            string outputPath = Path.Combine(GlobalVariables.SavePath, "SetTimerResolutionService.exe");

            if (!System.IO.File.Exists(outputPath))
            {
                executeBatchFromWeb.ExecuteBatchScriptFromWeb("https://raw.githubusercontent.com/luke-beep/Windows-Revitalizer/main/Resources/downloadSetTimerResolutionService.bat");
            }

            InstallService("STR", "STR", "LukeHjo", outputPath);

            executeBatchFromWeb.ExecuteBatchScriptFromWeb("https://raw.githubusercontent.com/luke-beep/Windows-Revitalizer/main/Resources/TimerResolutionOn.bat");
            if (int.TryParse(buildNumber, out int osBuild))
            {
                if (osBuild >= 19042)
                {
                    executeBatchFromWeb.ExecuteBatchScriptFromWeb("https://raw.githubusercontent.com/luke-beep/Windows-Revitalizer/main/Resources/deleteuseplatformtick.bat");
                }
                else
                {
                    executeBatchFromWeb.ExecuteBatchScriptFromWeb("https://raw.githubusercontent.com/luke-beep/Windows-Revitalizer/main/Resources/adduseplatformtick.bat");
                }
            }
        }
        

        public static void InstallService(string serviceName, string displayName, string description, string serviceFilePath)
        {
            using (ServiceProcessInstaller processInstaller = new ServiceProcessInstaller())
            {
                processInstaller.Account = ServiceAccount.LocalSystem;
                using (ServiceInstaller serviceInstaller = new ServiceInstaller())
                {
                    serviceInstaller.ServiceName = serviceName;
                    serviceInstaller.DisplayName = displayName;
                    serviceInstaller.Description = description;
                    serviceInstaller.StartType = ServiceStartMode.Automatic;
                    serviceInstaller.DelayedAutoStart = true;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    string assemblyPath = Assembly.GetEntryAssembly().Location;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    serviceInstaller.Context = new InstallContext(null, new[] { $"/assemblypath={assemblyPath}" });
                    using (ServiceProcessInstaller serviceProcessInstaller = new ServiceProcessInstaller())
                    {
                        serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
                        Installer[] installers = { serviceProcessInstaller, serviceInstaller };
                        using (TransactedInstaller transactedInstaller = new TransactedInstaller())
                        {
                            transactedInstaller.Installers.AddRange(installers);
                            try
                            {
                                transactedInstaller.Context = new InstallContext(null, new[] { $"/assemblypath={serviceFilePath}" });
                                transactedInstaller.Install(new System.Collections.Hashtable());
                                Console.WriteLine("Service installed successfully.");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Failed to install service: " + ex.Message);
                            }
                        }
                    }
                }
            }
        }
    }
}
