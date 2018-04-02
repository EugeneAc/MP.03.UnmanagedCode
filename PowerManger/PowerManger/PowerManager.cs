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
        private const uint StatusSuccess = 0;

        /// <summary>
        /// The get last sleep time.
        /// </summary>
        /// <returns>
        /// returns time interval in 100-nanoseconds units, at the last system sleep time
        /// </returns>
        public double GetLastSleepTime()
        {
            var t = Marshal.SizeOf(typeof(ulong));
            ulong retvalue;

            uint callsuccess = CallPowerInformation.CallNtPowerInformation(
                15, 
                IntPtr.Zero, 
                0, 
                out retvalue, 
                t);
            if (callsuccess == StatusSuccess)
            {
                return (double)retvalue; // VBA only supports Double
            }

            return 0;
        }

        /// <summary>
        /// The get last wake time.
        /// </summary>
        /// <returns>
        /// returns time interval in 100-nanosecond units, at the last system wake time 
        /// </returns>
        public double GetLastWakeTime()
        {
            ulong retvalue;

            uint callsuccess = CallPowerInformation.CallNtPowerInformation(
                14, 
                IntPtr.Zero, 
                0, 
                out retvalue, 
                Marshal.SizeOf(typeof(ulong)));
            if (callsuccess == StatusSuccess)
            {
                return (double)retvalue; // VBA only supports Double
            }

            return 0;
        }

        public SYSTEM_BATTERY_STATE GetBatteryState()
        {
            SYSTEM_BATTERY_STATE sbs;

            CallPowerInformation.CallNtPowerInformation(
                5,
                IntPtr.Zero,
                0,
                out sbs,
                Marshal.SizeOf(typeof(SYSTEM_BATTERY_STATE)));

           return sbs;
        }

        public SYSTEM_POWER_INFORMATION GetSystemPowerInformation()
        {
            SYSTEM_POWER_INFORMATION spi;

            uint retval = CallPowerInformation.CallNtPowerInformation(
                12,
                IntPtr.Zero,
                0,
                out spi,
                Marshal.SizeOf(typeof(SYSTEM_POWER_INFORMATION)));

            return spi;
        }

        public void SetSleepState()
        {
            CallPowerInformation.SetSuspendState(false, false, false);
        }

        public bool ReserveHyberFile()
        {
            int size = Marshal.SizeOf(typeof(byte));
            var pBool = Marshal.AllocHGlobal(size);
            Marshal.WriteByte(pBool, 0, 1);  // last parameter 0 (FALSE), 1 (TRUE)

            uint retval = CallPowerInformation.CallNtPowerInformation(
                10,
                pBool,
                Marshal.SizeOf(typeof(bool)),
                out pBool,
                    0);
            Marshal.FreeHGlobal(pBool);
            if (retval == StatusSuccess)
            {
                return true;
            }

            return false;
        }

        public bool FreeHybernatoinFile()
        {
            int size = Marshal.SizeOf(typeof(byte));
            var pBool = Marshal.AllocHGlobal(size);
            Marshal.WriteByte(pBool, 0, 0);  // last parameter 0 (FALSE), 1 (TRUE)

            uint retval = CallPowerInformation.CallNtPowerInformation(
                10,
                pBool,
                Marshal.SizeOf(typeof(bool)),
                out pBool,
                0);
            Marshal.FreeHGlobal(pBool);
            if (retval == StatusSuccess)
            {
                return true;
            }

            return false;
        }
    }
}
