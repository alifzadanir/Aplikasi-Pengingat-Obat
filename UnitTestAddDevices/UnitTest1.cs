//unitTest sudah login
namespace UnitTestAddDevices
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
            public void TestTriggerStateChange()
            {
                // Arrange
                DevicesConfig config = new DevicesConfig();
                Devices device = new Devices(config);

                // Act
                device.ActivateTrigger(Trigger.Login);

                // Assert
                Assert.AreEqual(device.currentState, deviceState.SudahLogin);
            }
        public void TestRuntimeConfiguration()
        {
            
        }

    }
}