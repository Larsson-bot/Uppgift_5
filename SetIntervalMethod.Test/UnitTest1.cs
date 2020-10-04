using System;
using Uppgift_5_ServiceClient.Services;
using Xunit;

namespace SetIntervalMethod.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("DeviceApp", "SetInterval", "5", "200")]
        [InlineData("DeviceApp", "GetInterval", "5", "501")]
        public void Test1(string deviceId, string methodName, string payload, string expected)
        {
            var servicedevice = new ServiceClientService("HostName=Uppgift3.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=7wIVTaZwXFEk8T3lCVBpWE5FN1xlqnp7I9m2CPetOYc=");
            var response = servicedevice.InvokeMethodAsync(deviceId, methodName, payload);
            Assert.Equal(expected, response.Result.Status.ToString());
        }
    }
}
