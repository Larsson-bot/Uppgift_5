using System;
using Uppgift_5_ServiceClient.Services;

namespace Uppgift_5_ServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var device = new ServiceClientService("HostName=Uppgift3.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=7wIVTaZwXFEk8T3lCVBpWE5FN1xlqnp7I9m2CPetOYc=");

            Console.ReadKey();
        }
    }
}
