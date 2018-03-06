using System;

namespace SensorsInterface
{

    public class Program
    {
        public static ds18b20 sensor = new ds18b20();
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            while (true)
            {
                sensor.PrintTemp();

            }
        }
    }
}

