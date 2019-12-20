using System;
using System.Diagnostics;


namespace GenericModel.Other
{
    public class ProgramHelper
    {
        public static void LogProgramStatus()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            Process currentProcess = Process.GetCurrentProcess();
            
            // "Computer, CPU: " + cpuCounter.NextValue() + "%"
            // "Computer, RAM: " + ramCounter.NextValue() + "MB"));

            // "Process, total processor time: " + currentProcess.TotalProcessorTime
            // "Process, physical memory usage: " + string.Format("{0:n0}", currentProcess.WorkingSet64)
            // "Process, PagedMemorySize64: " + string.Format("{0:n0}", currentProcess.PagedMemorySize64)
            // "Process, GC.GetTotalMemory: " + string.Format("{0:n0}", GC.GetTotalMemory(true))
        }
    }
}
