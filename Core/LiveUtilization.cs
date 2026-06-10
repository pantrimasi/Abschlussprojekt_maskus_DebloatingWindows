using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using Microsoft.Win32;

namespace WindowsDebloater.Core
{
    public static class LiveUtilization
    {
        // cpu
        private static readonly PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        // ram used/total
        public static string GetRamUsage()
        {
            var query = new ManagementObjectSearcher("SELECT FreePhysicalMemory, TotalVisibleMemorySize FROM Win32_OperatingSystem");
            foreach (var obj in query.Get())
            {
                float total = float.Parse(obj["TotalVisibleMemorySize"].ToString()) / 1024f / 1024f;
                float free = float.Parse(obj["FreePhysicalMemory"].ToString()) / 1024f / 1024f;
                float used = total - free;
                return $"{used:0.0}/{total:0.0} GB";
            }
            return "-";
        }

        // running processes
        public static Process[] GetProcesses() => Process.GetProcesses();

        }
    }