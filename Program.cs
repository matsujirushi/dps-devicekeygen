using System;
using System.Security.Cryptography;
using System.Text;

namespace dps_devicekeygen
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Azure IoT DPS Device SAS Key Generator");
                Console.WriteLine("Usage:");
                Console.WriteLine("dps-devicekeygen <Group SAS Key> <Device ID>");
                Console.WriteLine();
                return;
            }

            var groupSasKey = args[0];
            var deviceId = args[1];

            var key = Convert.FromBase64String(groupSasKey);
            var hmac = new HMACSHA256(key);
            var deviceSasKey = hmac.ComputeHash(Encoding.UTF8.GetBytes(deviceId));

            Console.WriteLine($"Device ID     :{deviceId}");
            Console.WriteLine($"Device SAS Key:{Convert.ToBase64String(deviceSasKey)}");
        }
    }
}
