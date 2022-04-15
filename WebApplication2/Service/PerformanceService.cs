using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using WebApplication2.Entity;

namespace WebApplication2.Service
{
    public class PerformanceService
    {
        public static double GetActiveDisk(Performance performance)
        {
#pragma warning disable CA1416
            var cpuCounter = new PerformanceCounter(performance.Category, performance.Counter, performance.Instance);

            var value = cpuCounter.NextValue();
            if (value <= 0.0)
            {
                Thread.Sleep(1000);
                value = cpuCounter.NextValue();
            }
#pragma warning restore CA1416
            return value;
        }

        public static double GetFreeSpacePercent()
        {
            double total = 0;
            double used = 0;

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                total += drive.TotalSize;
                used += drive.AvailableFreeSpace;
            }

            if (total > 0)
            {
                double res = Math.Round((total - used) / total * 100, 2);
                return res;
            }

            return -1;
        }
    }
}