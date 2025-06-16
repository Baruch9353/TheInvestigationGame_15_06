using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheInvestigationGame_15_06.IranianAgents;

namespace TheInvestigationGame_15_06.Sensors
{
    internal class ThermalSensor : Sensor
    {
        public IranianAgent IranianAgent;

        Random rand = new Random();

        public override string Name => "Thermal Sensor";
        public override string Activated { get; protected set; } = "";
        public override void Activate()
        {
            Activated = "activated";
        }
        //Reveals one correct sensor type from the secret list.
        internal string GetRandomWeakness()
        {
            return $"One correct sensor from the secret list is: " +
                 IranianAgent.selecteSensors[rand.Next(IranianAgent.selecteSensors.Count)].Name;
        }
    }
}
