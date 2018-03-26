namespace PowerManager
{
    using System;
    using System.Runtime.InteropServices;

    internal static class CallPowerInformation
    {
        [DllImport("powrprof.dll")]
        public static extern uint SetSuspendState(
            bool hibernate,
            bool forceCritical,
            bool disableWakeEvent);

        [DllImport("powrprof.dll")]
        public static extern uint CallNtPowerInformation(
            int informationLevel,
            IntPtr lpInputBuffer,
            int nInputBufferSize,
            out SYSTEM_POWER_INFORMATION spi,
            int nOutputBufferSize);

        [DllImport("powrprof.dll")]
        public static extern uint CallNtPowerInformation(
            int informationLevel,
            IntPtr lpInputBuffer,
            int nInputBufferSize,
            out ulong outval,
            int nOutputBufferSize);

        [DllImport("powrprof.dll")]
        public static extern uint CallNtPowerInformation(
            int informationLevel,
            IntPtr lpInputBuffer,
            int nInputBufferSize,
            out SYSTEM_BATTERY_STATE spi,
            int nOutputBufferSize);

        [DllImport("powrprof.dll")]
        public static extern uint CallNtPowerInformation(
            int informationLevel,
            IntPtr lpInputBuffer,
            int nInputBufferSize,
            out IntPtr lpOutBuffer,
            int nOutputBufferSize);
    }
}
