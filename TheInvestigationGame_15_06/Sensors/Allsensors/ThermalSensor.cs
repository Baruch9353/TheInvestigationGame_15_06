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
            string result = "\nThermal Sensor activated!\n";
            var grouped = agent.sensorManager.secretSensors.GroupBy(s => s.Name);
            foreach (var group in grouped)
            {
                string sensorName = group.Key;
                int requiredCount = group.Count();
                int revealedCount = agent.sensorManager.attachedSensors.Count(s => s.Name == sensorName);
                if (revealedCount < requiredCount)
                {
                    result += $"\nGet another weakness: {sensorName}\n";
                    break; 
                }
            }
            return result;
        }
    }
}