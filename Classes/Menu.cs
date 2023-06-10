using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsRevitalizer.Classes.Helpers;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes
{
    internal class Menu : IMenu
    {
        public void StartMenu()
        {
            
            BackHelper back = new BackHelper();
            ILogger logger = new FileLoggerHelper(@$"C:\WindowsRevitalizer\{DateTime.Today:yyyy-MM-dd}.txt");
            OutputLoggerHelper outputLogger = new OutputLoggerHelper(logger);
            ConsolePropertiesHelper properties = new ConsolePropertiesHelper();
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

            Console.SetOut(outputLogger);
            properties.SetConsoleProperties("Windows Revitalizer");

            AnsiConsole.Status()
                .Start("Loading...", ctx =>
                {
                    ctx.SpinnerStyle(Style.Parse("red"));
                    
                    Thread.Sleep(1000);
                    ctx.Status("Patching things up...");
                    
                    Thread.Sleep(2000);
                    Console.Clear();
                });

            AnsiConsole.Write(new FigletText("Windows Revitalizer\n")
                .Centered()
                .Color(Color.Red));


            List<ICommand> commands = new List<ICommand>
            {
                new DISM(),
                new SFC(),
                new SvcHostSplitThresholdCommandOn(),
                new SvcHostSplitThresholdCommandOff(),
                new CSRSSOn(),
                new CSRSSOff(),
                new TimerResolutionOn(),
                new TimerResolutionOff(),
                new MSIOn(),
                new MSIOff(),
                new AffinityOn(),
                new AffinityOff(),
                new MemoryOptimizationOn(),
                new MemoryOptimizationOff(),
                new MouseFixOn(),
                new MouseFixOff(),
                new DisableHDCP(),
                new EnableHDCP(),
                new EnableNVIDIATweaks(),
                new DisableNVIDIATweaks(),
                new DisableNVIDIATelemetry(),
                new EnableNVIDIATelemetry(),
                new TCPIPOn(),
                new TCPIPOff(),
                new OptimizeNetshOn(),
                new OptimizeNetshOff(),
                new ReduceAudioLatencyOn(),
                new ReduceAudioLatencyOff(),
                new DisableMitigations(),
                new EnableMitigations(),
                new DisableTaskOffloading(),
                new EnableTaskOffloading(),
                new DSCPOn(),
                new DSCPOff(),
                new DisableCStates(),
                new EnableCStates(),
                new PState0On(),
                new PState0Off(),
                new DisableIdle(),
                new EnableIdle(),
                new BCDTweaksOn(),
                new BCDTweaksOff(),
                new DisableUSBPowerSavings(),
                new EnableUSBPowerSavings(),
                new HardwareAnalyzer()
            };

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What do you want to do?")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more features)[/]")
                    .HighlightStyle(Color.Red)
                    .AddChoices(new[] {
                        "Run the Deployment Image Servicing and Management (DISM) tool",
                        "Run the System File Checker (SFC) tool",
                        "Debloat",
                        "SvcHostSplitThreshold | On",
                        "SvcHostSplitThreshold | Off",
                        "CSRSS High Priority | On",
                        "CSRSS High Priority | Off",
                        "Timer Resolution | On",
                        "Timer Resolution | Off",
                        "MSI Mode | On",
                        "MSI Mode | Off",
                        "Affinity | On",
                        "Affinity | Off",
                        "Memory Optimization | On",
                        "Memory Optimization | Off",
                        "Mouse Fix | On",
                        "Mouse Fix | Off",
                        "Disable HDCP",
                        "Enable HDCP",
                        "Enable NVIDIA Tweaks",
                        "Disable NVIDIA Tweaks",
                        "Disable NVIDIA Telemetry",
                        "Enable NVIDIA Telemetry",
                        "Optimize TCP/IP | On",
                        "Optimize TCP/IP | Off",
                        "Optimize Netsh | On",
                        "Optimize Netsh | Off",
                        "Reduce Audio Latency (REAL.exe) | On",
                        "Reduce Audio Latency (REAL.exe) | Off",
                        "Disable Mitigations",
                        "Enable Mitigations",
                        "Disable Task Offloading",
                        "Enable Task Offloading",
                        "DSCP Tweak | On",
                        "DSCP Tweak | Off",
                        "Disable C-States",
                        "Enable C-States",
                        "PStates 0 | On",
                        "PStates 0 | Off",
                        "Disable Idle",
                        "Enable Idle",
                        "BCDEdit Tweaks | On",
                        "BCDEdit Tweaks | Off",
                        "Disable USB Power Savings",
                        "Enable USB Power Savings",
                        "Hardware Analyzer"
                    }));

            for (int i = 0; i <= commands.Count; i++)
            {

            }
            switch (choice)
            {
                case "Run the Deployment Image Servicing and Management (DISM) tool":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[0].Execute();
                    back.Back();
                    break;
                case "Run the System File Checker (SFC) tool":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[1].Execute();
                    back.Back();
                    break;
                case "SvcHostSplitThreshold | On":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[2].Execute();
                    back.Back();
                    break;
                case "SvcHostSplitThreshold | Off":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[3].Execute();
                    back.Back();
                    break;
                case "CSRSS High Priority | On":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[4].Execute();
                    back.Back();
                    break;
                case "CSRSS High Priority | Off":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[5].Execute();
                    back.Back();
                    break;
                case "Timer Resolution | On":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[6].Execute();
                    back.Back();
                    break;
                case "Timer Resolution | Off":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[7].Execute();
                    back.Back();
                    break;
                case "MSI Mode | On":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[8].Execute();
                    back.Back();
                    break;
                case "MSI Mode | Off":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[9].Execute();
                    back.Back();
                    break;
                case "Affinity | On":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[10].Execute();
                    back.Back();
                    break;
                case "Affinity | Off":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[11].Execute();
                    back.Back();
                    break;
                case "Memory Optimization | On":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[12].Execute();
                    back.Back();
                    break;
                case "Memory Optimization | Off":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[13].Execute();
                    back.Back();
                    break;
                case "Mouse Fix | On":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[14].Execute();
                    back.Back();
                    break;
                case "Mouse Fix | Off":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[15].Execute();
                    back.Back();
                    break;
                case "Disable HDCP":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[16].Execute();
                    back.Back();
                    break;
                case "Enable HDCP":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[17].Execute();
                    back.Back();
                    break;
                case "Enable NVIDIA Tweaks":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[18].Execute();                   
                    back.Back();
                    break;
                case "Disable NVIDIA Tweaks":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[19].Execute();
                    back.Back();
                    break;
                case "Disable NVIDIA Telemetry":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[20].Execute();
                    back.Back();
                    break;
                case "Enable NVIDIA Telemetry":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[21].Execute();
                    back.Back();
                    break;
                case "Optimize TCP/IP | On":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[22].Execute();
                    back.Back();
                    break;
                case "Optimize TCP/IP | Off":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[23].Execute();
                    back.Back();
                    break;
                case "Optimize Netsh | On":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[24].Execute();
                    back.Back();
                    break;
                case "Optimize Netsh | Off":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[25].Execute();
                    back.Back();
                    break;
                case "Reduce Audio Latency (REAL.exe) | On":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[26].Execute();
                    back.Back();
                    break;
                case "Reduce Audio Latency (REAL.exe) | Off":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[27].Execute();
                    back.Back();
                    break;
                case "Disable Mitigations":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[28].Execute();
                    back.Back();
                    break;
                case "Enable Mitigations":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[29].Execute();
                    back.Back();
                    break;
                case "Disable Task Offloading":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[30].Execute();
                    back.Back();
                    break;
                case "Enable Task Offloading":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[31].Execute();
                    back.Back();
                    break;
                case "DSCP Tweak | On":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[32].Execute();
                    back.Back();
                    break;
                case "DSCP Tweak | Off":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[33].Execute();
                    back.Back();
                    break;
                case "Disable C-States":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[34].Execute();
                    back.Back();
                    break;
                case "Enable C-States":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[35].Execute();
                    back.Back();
                    break;
                case "PStates 0 | On":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[36].Execute();
                    back.Back();
                    break;
                case "PStates 0 | Off":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[37].Execute();
                    back.Back();
                    break;
                case "Disable Idle":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[38].Execute();
                    back.Back();
                    break;
                case "Enable Idle":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[39].Execute();
                    back.Back();
                    break;
                case "BCDEdit Tweaks | On":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[40].Execute();
                    back.Back();
                    break;
                case "BCDEdit Tweaks | Off":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[41].Execute();
                    back.Back();
                    break;
                case "Disable USB Power Savings":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[42].Execute();
                    back.Back();
                    break;
                case "Enable USB Power Savings":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                    commands[43].Execute();
                    back.Back();
                    break;
                case "Hardware Analyzer":
                    commands[44].Execute();
                    back.Back();
                    break;
                case "Debloat":
                    AnsiConsole.WriteLine($"You've selected the {choice} feature!\n");
                // Code for Debloat
                    break; 
                default:
                    Console.WriteLine("\nThis feature has not been implemented yet!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    back.Back();
                    break;
            }
        }

        private void CurrentDomain_ProcessExit(object? sender, EventArgs e)
        {
            Console.Title = "Exiting...";
        }
    }
}
