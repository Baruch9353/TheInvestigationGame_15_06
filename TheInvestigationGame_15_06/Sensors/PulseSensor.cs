using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestigationGame_15_06.IranianAgents;

namespace TheInvestigationGame_15_06.Sensors
{
    internal class PulseSensor : Sensor
    {
        private int activationCount = 0;
        private bool isBroken = false;

        public override string Name => "Pulse Sensor";

        public override string Activate(IranianAgent agent)
        {
            if (isBroken)
            {
                return "Pulse Sensor is broken and can't be used.";
            }

            activationCount++;

            if (activationCount >= 3)
            {
                isBroken = true;
                return "Pulse Sensor has broken after 3 activations.";
            }

            return $"Pulse Sensor activated ({activationCount}/3). You can use it {3 - activationCount} more times.";

        }
    }
}

