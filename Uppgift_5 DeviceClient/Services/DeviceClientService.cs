using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift_5_DeviceClient.Services
{
   public class DeviceClientService
    {
        private static Random rnd = new Random();
        private static DeviceClient deviceClient;
        private static int _interval = 10;
        public DeviceClientService(string connectionstring)
        {
            deviceClient = DeviceClient.CreateFromConnectionString(connectionstring);
            deviceClient.SetMethodHandlerAsync("SetInterval", SetTelemetryIntervalAsync, null).GetAwaiter();
        }
        public static async Task<MethodResponse> SetTelemetryIntervalAsync(MethodRequest methodRequest, object userContext)
        {
            SetInterval(Convert.ToInt32(methodRequest.DataAsJson));
            Console.WriteLine($"Interval set to {_interval} seconds");
            return await Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(methodRequest.DataAsJson), 200));
        }
        public static bool SetInterval(int interval)
        {
            try
            {
                _interval = interval;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static async Task SendMessageAsync()
        {
            while (true)
            {
                double temp = 10 + rnd.NextDouble() * 15;
                double hum = 40 + rnd.NextDouble() * 20;
                var data = new
                {
                    temperature = temp,
                    humidity = hum
                };
                var json = JsonConvert.SerializeObject(data);
                var payload = new Message(Encoding.UTF8.GetBytes(json));
            

                await deviceClient.SendEventAsync(payload);
                Console.WriteLine($"Message sent: {json}");
                await Task.Delay(_interval * 1000);
            }
        }
    }
}
