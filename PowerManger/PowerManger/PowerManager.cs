// <summary>
//   Defines the PowerManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PowerManager
{
    using System;
    using System.Runtime.InteropServices;

    [ComVisible(true)]
    [Guid("4AC30934-C332-4AEB-8D1D-BBAE2503A9A8")]
    [ClassInterface(ClassInterfaceType.None)]
    public class PowerManager : IPowerManager
    {
        public double GetLastSleepTime()
        {
            var t = Marshal.SizeOf(typeof(ulong));
            uint statusSuccess = 0;
            ulong retvalue;
            uint callsuccess = CallPowerInformation.CallNtPowerInformation(
                15, 
                IntPtr.Zero, 
                0, 
                out retvalue, 
                t);
            if (callsuccess == statusSuccess)
            {
                return (double)retvalue; // VBA only supports Double
            }

            return 0;
        }

        public double GetLastWakeTime()
        {
            uint statusSuccess = 0;
            ulong retvalue;
            uint callsuccess = CallPowerInformation.CallNtPowerInformation(
                14, 
                IntPtr.Zero, 
                0, 
                out retvalue, 
                Marshal.SizeOf(typeof(ulong)));
            if (callsuccess == statusSuccess)
            {
                return (double)retvalue; // VBA only supports Double
      }

            return 0;
        }

        public SYSTEM_BATTERY_STATE GetBatteryState()
        {
            SYSTEM_BATTERY_STATE sbs;

            uint status = CallPowerInformation.CallNtPowerInformation(
                5,
                IntPtr.Zero,
                0,
                out sbs,
                Marshal.SizeOf(typeof(SYSTEM_BATTERY_STATE)));
           return sbs;
        }

        public SYSTEM_POWER_INFORMATION GetSystemPowerInformation()
        {
            uint statusSuccess = 0;
            SYSTEM_POWER_INFORMATION spi;

            uint retval = CallPowerInformation.CallNtPowerInformation(
                12,
                IntPtr.Zero,
                0,
                out spi,
                Marshal.SizeOf(typeof(SYSTEM_POWER_INFORMATION)));
            if (retval == statusSuccess)
            {
                return spi;
            }

            return spi;
        }

        public void SetSleepState()
        {
            CallPowerInformation.SetSuspendState(false, false, false);
        }

        public double ReserveHyberFile()
        {
            int size = Marshal.SizeOf(typeof(byte));
            var pBool = Marshal.AllocHGlobal(size);
            Marshal.WriteByte(pBool, 0, 1);  // last parameter 0 (FALSE), 1 (TRUE)

            uint retval = CallPowerInformation.CallNtPowerInformation(
                10,
                pBool,
                0,
                out pBool,
                    size);
            Marshal.FreeHGlobal(pBool);
            return retval;
        }

        public double FreeHybernatoinFile()
        {
            int size = Marshal.SizeOf(typeof(byte));
            var pBool = Marshal.AllocHGlobal(size);
            Marshal.WriteByte(pBool, 0, 0);  // last parameter 0 (FALSE), 1 (TRUE)

            uint retval = CallPowerInformation.CallNtPowerInformation(
                10,
                pBool,
                0,
                out pBool,
                size);
            Marshal.FreeHGlobal(pBool);
            return retval;
        }
    }
}
