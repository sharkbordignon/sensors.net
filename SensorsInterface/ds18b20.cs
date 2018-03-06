using System;
using System.IO;
using System.Linq;
using System.Text;

namespace SensorsInterface
{
    public class ds18b20
    {
        public void PrintTemp()
        {
            DirectoryInfo devicesDir = new DirectoryInfo("/sys/bus/w1/devices");

            foreach (var deviceDir in devicesDir.EnumerateDirectories("28*"))
            {
                var w1slavetext =
                    deviceDir.GetFiles("w1_slave").FirstOrDefault().OpenText().ReadToEnd();
                string temptext =
                    w1slavetext.Split(new string[] { "t=" }, StringSplitOptions.RemoveEmptyEntries)[1];

                double temp = double.Parse(temptext) / 1000;

                Console.WriteLine(string.Format("Device {0} reported temperature {1}C",
                    deviceDir.Name, temp));
            }
        }
    }
}