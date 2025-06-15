using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestigationGame_15_06.Sensors
{
    //Reveals one correct sensor type from the secret list.
    internal class ThermalSensor : Sensor
    {
        public override string Name => "Thermal Sensor";
        public override bool Activate()
        {
            bool activated = true;
            Console.WriteLine("Thermal Sensor Activated");
            return activated;
        }
    }
}
