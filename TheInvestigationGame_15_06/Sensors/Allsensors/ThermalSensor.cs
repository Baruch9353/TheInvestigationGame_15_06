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
            List<Sensor> undiscovered = GetUndiscoveredWeaknesses(agent);
            if (undiscovered.Count > 0)
            {
                Sensor chosen = PickRandomWeakness(undiscovered);
                result += $"Get another weakness: {chosen.Name}\n";
            }
            else
            {
                result += "No new weaknesses to reveal.\n";
            }
            return result;
        }
        private List<Sensor> GetUndiscoveredWeaknesses(IranianAgent agent)
        {
            List<Sensor> undiscovered = new List<Sensor>();
            foreach (Sensor secretSensor in agent.sensorManager.secretSensors)
            {
                if (!IsSensorAttached(agent, secretSensor))
                {
                    undiscovered.Add(secretSensor);
                }
            }
            return undiscovered;
        }
        private bool IsSensorAttached(IranianAgent agent, Sensor sensor)
        {
            foreach (Sensor attached in agent.sensorManager.attachedSensors)
            {
                if (attached.Name == sensor.Name)
                    return true;
            }
            return false;
        }
        private Sensor PickRandomWeakness(List<Sensor> sensors)
        {
            int index = SensorManager.rand.Next(sensors.Count);
            return sensors[index];
        }
    }
}