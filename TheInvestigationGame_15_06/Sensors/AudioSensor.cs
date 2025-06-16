using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInvestigationGame_15_06
{
    //Basic sensor.No special ability.
    internal class AudioSensor : Sensor
    {
        public override string Name => "Audio Sensor";

        public override string Activated { get; protected set; } = "";

        public override void Activate()
        {
            Activated = "activated";
        }
    }

}
