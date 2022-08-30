using System;
using LibreHardwareMonitor.Hardware;

namespace Exporter
{

    public static class ExportClass
    {
        public class UpdateVisitor : IVisitor
        {
            public void VisitComputer(IComputer computer)
            {
                computer.Traverse(this);
            }
            public void VisitHardware(IHardware hardware)
            {
                hardware.Update();
                foreach (IHardware subHardware in hardware.SubHardware) subHardware.Accept(this);
            }
            public void VisitSensor(ISensor sensor) { }

            public void VisitParameter(IParameter parameter) { }


        }

        static Computer computer;

        static ExportClass()
        {
            computer = new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = false,
                IsMotherboardEnabled = true,
                IsControllerEnabled = false,
                IsNetworkEnabled = false,
                IsStorageEnabled = false
            };
        }

        public static string Export()
        {
            computer.Open();

            computer.Accept(new UpdateVisitor());

            string outstr = "";

            foreach (IHardware hardware in computer.Hardware)
            {
                outstr += String.Format("Hardware\t{0}\t{1}\n", hardware.Name, hardware.HardwareType);

                foreach (IHardware subhardware in hardware.SubHardware)
                {
                    outstr += String.Format("Hardware\t{0}\t{1}\n", subhardware.Name, subhardware.HardwareType);

                    foreach (ISensor sensor in subhardware.Sensors)
                    {
                        outstr += String.Format("{0}\t{1}\t{2:0}\n", sensor.Name, sensor.SensorType, sensor.Value);
                    }
                }

                foreach (ISensor sensor in hardware.Sensors)
                {
                    outstr += String.Format("{0}\t{1}\t{2:0}\n", sensor.Name, sensor.SensorType, sensor.Value);
                }
            }

            return outstr;

        }

        public static string ExportReport()
        {
            Computer comp = new Computer()
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = false,
                IsMotherboardEnabled = false,
                IsControllerEnabled = false,
                IsNetworkEnabled = false,
                IsStorageEnabled = false
            };

            comp.Open();
            string outstr = comp.GetReport();
            comp.Close();
            return outstr;
        }
    }
}
