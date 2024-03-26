using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Faster.Library
{
    public class PowerLib
    {
        [DllImport("kernel32.dll")]
        private static extern uint SetThreadExecutionState(uint Flags);
        private const uint ES_SYSTEM_REQUIRED = 0x00000001;
        private const uint ES_DISPLAY_REQUIRED = 0x00000002;
        private const uint ES_CONTINUOUS = 0x80000000;

        public static void SetNotSleep(bool keepDisplayOn = true)
        {
            SetThreadExecutionState(keepDisplayOn ? ES_CONTINUOUS | ES_SYSTEM_REQUIRED | ES_DISPLAY_REQUIRED :
                ES_CONTINUOUS | ES_SYSTEM_REQUIRED);
        }

        public static void RestoreSleep()
        {
            SetThreadExecutionState(ES_CONTINUOUS);
        }
    }
}
