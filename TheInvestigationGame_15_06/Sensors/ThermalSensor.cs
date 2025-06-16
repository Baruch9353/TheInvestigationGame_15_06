using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestigationGame_15_06.IranianAgents;

namespace TheInvestigationGame_15_06.Sensors
{
    //Reveals one correct sensor type from the secret list.
    internal class ThermalSensor : Sensor
    {
       
        public override string Name => "Thermal Sensor";
        public override string Activate()
        {
            return "activated";
        }
    }
}
