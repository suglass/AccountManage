using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebAuto
{
  public static class ProcessExtensions
  {
    public static bool ProcessExists(int id)
    {
      return ((IEnumerable<Process>) Process.GetProcesses()).Any<Process>((Func<Process, bool>) (x => x.Id == id));
    }

    private static string FindIndexedProcessName(int pid)
    {
      try
      {
        string processName = Process.GetProcessById(pid).ProcessName;
        Process[] processesByName = Process.GetProcessesByName(processName);
        string instanceName = (string) null;
        for (int index = 0; index < processesByName.Length; ++index)
        {
          instanceName = index == 0 ? processName : processName + "#" + (object) index;
          if ((int) new PerformanceCounter("Process", "ID Process", instanceName).NextValue() == pid)
            return instanceName;
        }
        return instanceName;
      }
      catch
      {
        return string.Empty;
      }
    }

    private static int FindPidFromIndexedProcessName(string indexedProcessName)
    {
      try
      {
        return (int) new PerformanceCounter("Process", "Creating Process ID", indexedProcessName).NextValue();
      }
      catch
      {
        return -1;
      }
    }

    public static int GetParentID(this Process process)
    {
      return ProcessExtensions.FindPidFromIndexedProcessName(ProcessExtensions.FindIndexedProcessName(process.Id));
    }
  }
}
