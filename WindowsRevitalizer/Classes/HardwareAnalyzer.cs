using Microsoft.Win32;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using WindowsRevitalizer.Classes.Helpers;
using WindowsRevitalizer.Interfaces;

namespace WindowsRevitalizer.Classes
{
    internal class HardwareAnalyzer : ICommand
    {
        public void Execute()
        {
            HardwareLoader HardwareLoader = new();
            BackHelper backHelper = new();

            List<CPU> cpus = HardwareLoader.GetCPUs();
            VirtualMemory vm = HardwareLoader.GetVM();
            List<RAM> ramModules = HardwareLoader.GetRAM();
            List<Motherboard> motherboards = HardwareLoader.GetMotherboards();
            List<Disk> disks = HardwareLoader.GetDisks();
            List<GPU> gpus = HardwareLoader.GetGPUs();
            List<AudioDevice> audioDevices = HardwareLoader.GetAudioDevices();
            List<Volume> Volumes = new();
            List<Volume> Opticals = new();
            List<Volume> Removables = new();
            List<NetworkDevice> PhysicalAdapters = new();
            List<NetworkDevice> VirtualAdapters = new();
            List<Keyboard> Keyboards = new();
            List<PointingDevice> PointingDevices = new();
            

            var CPU = new Tree("");
            foreach (CPU cpu in cpus)
            {
                _ = CPU.AddNode(new Table()
                 .Title(cpu.Name)
                 .AddColumn("Name")
                 .AddColumn("Value")
                 .AddRow("L2 Cache", cpu.L2CacheSize.ToString())
                 .AddRow("L3 Cache", cpu.L3CacheSize.ToString())
                 .AddRow("Cores", cpu.Cores.ToString())
                 .AddRow("Threads", cpu.LogicalCpus.ToString())
                 .AddRow("Virtualization", cpu.Virtualization)
                 .AddRow("Data Execution Prevention", cpu.DataExecutionPrevention)
                 .AddRow("Stepping", cpu.Stepping)
                 .AddRow("Revision", cpu.Revision)

                 .Collapse()
                 );
            }
            var RAM = new Tree("");
            foreach (RAM ram in ramModules)
            {
                _ = RAM.AddNode(new Table()
                   .Title(ram.Manufacturer)
                   .AddColumn("Name")
                   .AddColumn("Value")
                   .AddRow("Capacity", ram.Capacity.ToString())
                   .AddRow("Form Factor (DIMM/SODIMM)", ram.FormFactor)
                   .AddRow("Memory Type", ram.MemoryType)
                   .AddRow("Speed (MT/s)", ram.Speed.ToString())
                   .AddRow("RAM Bank (Module or Bar)", ram.BankLabel)

                   .Collapse()
                  );
            }
            var VirtualMemory = new Tree("");

            var VirtualMemoryRoot = VirtualMemory.AddNode(new Table()
                .Title("Virtual Memory")
                .AddColumn("Name")
                .AddColumn("Value")
                .AddRow("Total Virtual Memory", vm.TotalVirtualMemory.ToString())
                .AddRow("Allocated Virtual Memory", vm.UsedVirtualMemory.ToString())
                .AddRow("Available Virtual Memory", vm.AvailableVirtualMemory.ToString())
                
                .Collapse()
                );

            var GPU = new Tree("");

            foreach (GPU gpu in gpus)
            {
                _ = GPU.AddNode(new Table()
                .Title(gpu.Name)
                .AddColumn("Name")
                .AddColumn("Value")
                .AddRow("VRAM", gpu.Memory.ToString())
                .AddRow("Resolution (X-axis)", gpu.ResolutionX.ToString())
                .AddRow("Resolution (Y-axis)", gpu.ResolutionY.ToString())
                .AddRow("Refresh Rate (Hz)", gpu.RefreshRate.ToString())
                .AddRow("DAC Type (Obsolete)", gpu.DACType)
                .AddRow("VRAM Type (eg. GDDR6)", gpu.VideoMemoryType)

                .Collapse()
                );
            }

            var Disks = new Tree("");
            foreach (Disk disk in disks)
            {
                Disks.AddNode(new Table()
                   .Title(disk.Model)
                   .AddColumn("Name")
                   .AddColumn("Value")
                   .AddRow("Capacity", disk.Capacity.ToString())
                   .AddRow("Bytes Per Sector", disk.BytesPerSector.ToString())
                   .AddRow("Firmware Revision", disk.FirmwareRevision)
                   .AddRow("Media Type", disk.MediaType)
                   
                   .Collapse()
                 );
            }

            var _physicalAdapters = new Tree("");
            foreach (NetworkDevice physicalAdapters in PhysicalAdapters)
            {
                _physicalAdapters.AddNode(new Table()
                   .Title(physicalAdapters.ProductName)
                   .AddColumn("Name")
                   .AddColumn("Value")
                   .AddRow("Adapter Type", physicalAdapters.AdapterType)
                   .AddRow("Manufacturer", physicalAdapters.Manufacturer)
                   .AddRow("MAC Address", physicalAdapters.MacAddress)
                   .AddRow("Physical Adapter", physicalAdapters.PhysicalAdapter)
                   .AddRow("Service Name", physicalAdapters.ServiceName)
                   
                   .Collapse()
                 );
            }
            var _virtualAdapters = new Tree("");
            foreach (NetworkDevice virtualAdapters in VirtualAdapters)
            {
                _virtualAdapters.AddNode(new Table()
                   .Title(virtualAdapters.ProductName)
                   .AddColumn("Name")
                   .AddColumn("Value")
                   .AddRow("Adapter Type", virtualAdapters.AdapterType)
                   .AddRow("Manufacturer", virtualAdapters.Manufacturer)
                   .AddRow("MAC Address", virtualAdapters.MacAddress)
                   .AddRow("Physical Adapter", virtualAdapters.PhysicalAdapter)
                   .AddRow("Service Name", virtualAdapters.ServiceName)
                   
                   .Collapse()
                 );
            }

            var _Keyboards = new Tree("");
            foreach (Keyboard keyboard in Keyboards)
            {
                _Keyboards.AddNode(new Table()
                    .Title(keyboard.Name)
                   .AddColumn("Name")
                   .AddColumn("Value")
                   .AddRow("Layout", keyboard.Layout)
                   .AddRow("Function Keys", keyboard.FunctionKeys.ToString())
                   .AddRow("Status", keyboard.Status)
                   .AddRow("Locked", keyboard.Locked)
                   
                   .Collapse()
                 );
            }

            var _PointingDevices = new Tree("");
            foreach (PointingDevice pointingDevice in PointingDevices)
            {
                _PointingDevices.AddNode(new Table()
                   .AddColumn("Name")
                   .AddColumn("Value")
                   .Title(pointingDevice.Name)
                   .AddRow("Manufacturer", pointingDevice.Manufacturer)
                   .AddRow("Buttons", pointingDevice.Buttons.ToString())
                   .AddRow("Status", pointingDevice.Status)
                   .AddRow("Locked", pointingDevice.Locked)
                   .AddRow("Hardware Type", pointingDevice.HardwareType)
                   .AddRow("Pointing Type", pointingDevice.PointingType)
                   .AddRow("Device Interface (DI)", pointingDevice.DeviceInterface)
                   
                   .Collapse()
                 );
            }

            var AudioDevices = new Tree("");
            foreach (AudioDevice audioDevice in audioDevices)
            {
                AudioDevices.AddNode(new Table()
                    .Title(audioDevice.ProductName)
                   .AddColumn("Name")
                   .AddColumn("Value")
                   .AddRow("Manufacturer", audioDevice.Manufacturer)
                   .AddRow("Status", audioDevice.Status)
                   
                   .Collapse()
                 );
            }

            var Motherboards = new Tree("");
            foreach (Motherboard motherboard in motherboards)
            {
                Motherboards.AddNode(new Table()
                   .AddColumn("Name")
                   .AddColumn("Value")
                   .Title(motherboard.Model)
                   .AddRow("Manufacturer", motherboard.Manufacturer)
                   .AddRow("BIOS Name", motherboard.BIOSName)
                   .AddRow("Product", motherboard.Product)
                   .AddRow("Chipset", motherboard.Chipset)
                   .AddRow("Version", motherboard.Version)
                   .AddRow("System Model", motherboard.SystemModel)
                   .AddRow("BIOS Name", motherboard.BIOSName)
                   .AddRow("BIOS Manufacturer (E.g. American Megatrend (AMI))", motherboard.BIOSManufacturer)
                   .AddRow("BIOS Version", motherboard.BIOSVersion)
                   .AddRow("BIOS Build Number", motherboard.BIOSBuildNumber)
                   
                   .Collapse()
                );
            }

            var _Volumes = new Tree("");
            foreach (Volume volume in Volumes)
            {
                _Volumes.AddNode(new Table()
                   .Title(volume.Label)
                   .AddColumn("Name")
                   .AddColumn("Value")
                   .AddRow("Capacity", volume.Capacity.ToString())
                   .AddRow("Drive Letter", volume.DriveLetter)
                   .AddRow("File System", volume.FileSystem)
                   
                   .Collapse()
                );
            }   
            AnsiConsole.Write(CPU);
            Console.WriteLine("\n");
            AnsiConsole.Write(RAM);
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            AnsiConsole.Write(VirtualMemory);
            Console.WriteLine("\n");
            AnsiConsole.Write(GPU);
            Console.WriteLine("\n");
            AnsiConsole.Write(AudioDevices);
            Console.WriteLine("\n");
            AnsiConsole.Write(_Keyboards);
            Console.WriteLine("\n");
            AnsiConsole.Write(_PointingDevices);
            Console.WriteLine("\n");
            AnsiConsole.Write(Disks);
            Console.WriteLine("\n");
            AnsiConsole.Write(_Volumes);
            Console.WriteLine("\n");
            AnsiConsole.Write(Motherboards);
            Console.WriteLine("\n");
            AnsiConsole.Write(_physicalAdapters);
            Console.WriteLine("\n");
            AnsiConsole.Write(_virtualAdapters);
            Console.WriteLine("\n");
            var accept = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .HighlightStyle(Color.Red)
                .PageSize(10)
                .Title("[red]Go back[/]?")
                .AddChoices(new[]
                {
                "Yes", "No"
                }));
            if (accept == "Yes")
            {
                backHelper.Back();
            }
            else
            {
                Console.ReadLine();
            }
        }
    }
}
        
    

