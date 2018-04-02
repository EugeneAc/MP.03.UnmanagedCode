namespace PowerManager
{
    using System.Runtime.InteropServices;

    [ComVisible(true)]
    [Guid("A08FFF04-3BF7-4912-A5A3-8DEB73626DBC")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IPowerManager
    {
        double GetLastSleepTime();

        double GetLastWakeTime();

        SYSTEM_BATTERY_STATE GetBatteryState();

        SYSTEM_POWER_INFORMATION GetSystemPowerInformation();

        void SetSleepState();

        bool ReserveHyberFile();

        bool FreeHybernatoinFile();

    }
}