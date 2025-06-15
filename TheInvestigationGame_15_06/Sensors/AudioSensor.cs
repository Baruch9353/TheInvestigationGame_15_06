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
        public override bool Activate()
        {
            bool activated = true;
            Console.WriteLine("Audio Sensor Activated");
            return activated;
        }
    }
}
