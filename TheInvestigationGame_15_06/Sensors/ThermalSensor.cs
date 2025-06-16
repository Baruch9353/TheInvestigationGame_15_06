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
        public override string Name => "Thermal Sensor";
        public override string Activate(IranianAgent agent)
        {
            return GetAnotherWeakness(agent);

        }
        private static string GetAnotherWeakness(IranianAgent agent)
        {
            foreach (Sensor secret in agent.secretSensors)
            {
                if (!agent.IsSensorRevealed(secret))
                {
                    return $"Thermal Sensor activated! Get another weakness: {secret.Name}";
                }
            }
            return "Thermal Sensor activate";
        }
    }
}
