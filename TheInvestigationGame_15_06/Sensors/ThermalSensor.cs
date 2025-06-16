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
            foreach (Sensor secret in agent.sensorManager.secretSensors)
            {
                    string result = "Thermal Sensor activated!";
                    if (!agent.sensorManager.IsRevealed())
                    {
                        result += $" Get another weakness: {secret.Name}";
                    }
                    return result;
            }
            return "Thermal Sensor activated!";
        }
    }
}
