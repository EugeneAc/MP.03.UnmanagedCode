
using System.Runtime.InteropServices;

namespace PowerManager
{
  [StructLayout(LayoutKind.Sequential)]
  public struct SYSTEM_POWER_INFORMATION
    {
        public int MaxIdlenessAllowed;
        public int Idleness;
        public int TimeRemaining;
        public byte CoolingMode;
    }
}
