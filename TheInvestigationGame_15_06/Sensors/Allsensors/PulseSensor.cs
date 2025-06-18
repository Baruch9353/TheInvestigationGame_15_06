using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using TheInvestigationGame_15_06.IranianAgents;

namespace TheInvestigationGame_15_06.Sensors
{
    internal class PulseSensor : Sensor
    {
        public override string Name => "Pulse Sensor";
        private int count = 0;
        private bool isBroken = false;
        public override bool IsUsable => !isBroken;

        public override string Activate(IranianAgent agent)
        {
            if (isBroken)
            { 
                 return "\nPulse Sensor is broken and can't be used.\n";
            }
            count++;
            if (count >= 3)
            {
                isBroken = true;
                return "\nPulse Sensor has broken after 3 activations.\n";
            }

            return $"\nPulse Sensor activated ({count}/3).\nYou can use it {3 - count} more times.\n";
        }
    }
}

