/*
 * Author: Masato Kuster
 * Date: 24.06.2026
 * Version: 1.0.0
 * Project: Windows Debloater Tool
 * Description: Core application logic for a Windows optimization tool that removes unnecessary system components and improves performance.
 */
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
        private static readonly ManagementObjectSearcher ramQuery =
            new ManagementObjectSearcher("SELECT FreePhysicalMemory, TotalVisibleMemorySize FROM Win32_OperatingSystem");

        // cpu usage
        public static string GetCpuUsage()
        {
            cpuCounter.NextValue();
            System.Threading.Thread.Sleep(500);
            return ((int)cpuCounter.NextValue()).ToString();
        }

        public static string GetRamUsage()
        {
            foreach (var obj in ramQuery.Get())
            {
                float total = float.Parse(obj["TotalVisibleMemorySize"].ToString()) / 1024f / 1024f;
                float free = float.Parse(obj["FreePhysicalMemory"].ToString()) / 1024f / 1024f;
                return $"{total - free:0.0}/{total:0.0} GB";
            }
            return "-";
        }

        // running processes
        public static Process[] GetProcesses() => Process.GetProcesses();

        }
    }