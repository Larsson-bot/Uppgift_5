using Microsoft.Azure.Devices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5_ServiceClient.Services
{
    public class ServiceClientService
    {
        private ServiceClient serviceClient;

        public ServiceClientService(string connectionstring)
        {
            serviceClient = ServiceClient.CreateFromConnectionString(connectionstring);


            //Task.Delay(5000).Wait();
            //ServiceClientService.InvokeMethodAsync("DeviceApp", "SetInterval", "10").GetAwaiter();
        }
        public async Task<CloudToDeviceMethodResult> InvokeMethodAsync(string deviceId, string methodName, string payload)
        {
            var methodInvocation = new CloudToDeviceMethod(methodName) { ResponseTimeout = TimeSpan.FromSeconds(30) };
            methodInvocation.SetPayloadJson(payload);

            var response = await serviceClient.InvokeDeviceMethodAsync(deviceId, methodInvocation);

            Console.WriteLine($"Response Status: {response.Status}");
            Console.WriteLine(response.GetPayloadAsJson());
            return response;
        }
    }
}
