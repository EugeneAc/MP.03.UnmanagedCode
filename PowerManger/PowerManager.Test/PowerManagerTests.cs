namespace PowerManager.Test
{
  using System;
  using global::PowerManager;
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class PowerManagerTests
  {
    PowerManager _manager;

    [TestInitialize]
    public void Initialize()
    {
      _manager = new PowerManager();
    }

    [TestMethod]
      public void TestGetPowerInfo()
    {
      var powerinfo = _manager.GetSystemPowerInformation();
      Assert.IsTrue((uint)powerinfo.Idleness>0);
      Console.WriteLine("TimeRemaining " + powerinfo.TimeRemaining);
      Console.WriteLine("CoolingMode " + powerinfo.CoolingMode);
      Console.WriteLine("Idleness " + (uint)powerinfo.Idleness);
      Console.WriteLine("MaxIdlenessAllowed " + (uint)powerinfo.MaxIdlenessAllowed);
    }

    [TestMethod]
    public void TestGetLastSleepTime()
    {
      var retvalue = _manager.GetLastSleepTime();
      Assert.IsTrue(retvalue!=0);
      Console.WriteLine(retvalue);
    }

    [TestMethod]
    public void TestGetLastWakeTime()
    {
      var retvalue = _manager.GetLastWakeTime();
      Assert.IsTrue(retvalue!=0);
      Console.WriteLine(retvalue);
    }

    [TestMethod]
    public void TestGetBatteryState()
    {
      var batteryState = _manager.GetBatteryState();
      Assert.IsTrue(batteryState.AcOnLine);
      Console.WriteLine("AcOnLine " + batteryState.AcOnLine);
      Console.WriteLine("BatteryPresent " + batteryState.BatteryPresent);
      Console.WriteLine("Charging " + batteryState.Charging);
      Console.WriteLine("Discharging " + batteryState.Discharging);
      Console.WriteLine("MaxCapacity " + (uint)batteryState.MaxCapacity);
      Console.WriteLine("Rate " + (uint)batteryState.Rate);
      Console.WriteLine("RemainingCapacity " + (uint)batteryState.RemainingCapacity);
      Console.WriteLine("EstimatedTime " + (uint)batteryState.EstimatedTime);
    }

    [TestMethod]
    public void TestSleepState()
    {
         //manager.SetSleepState();
    }

    [TestMethod]
    public void TestReserveHybernationFile()
    {
      var filesize = _manager.ReserveHyberFile();
      Assert.IsTrue(filesize > 0);
      Console.WriteLine(filesize);
    }

    [TestMethod]
    public void TestFreeHybernationFile()
    {
      var filesize = _manager.FreeHybernatoinFile();
      Assert.IsTrue(filesize > 0);
      Console.WriteLine(filesize);
    }
  }
}
