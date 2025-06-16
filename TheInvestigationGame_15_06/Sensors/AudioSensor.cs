using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestigationGame_15_06.Sensors;
using TheInvestigationGame_15_06.IranianAgents;

namespace TheInvestigationGame_15_06.Sensors
{
    internal class AudioSensor : Sensor
    {
        public override string Name => "Audio Sensor";

        public override string Activate(IranianAgent agent)
        {
            return "Audio Sensor activate";
        }
    }
}
